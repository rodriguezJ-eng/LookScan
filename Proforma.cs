using System;
using System.Collections.Generic;
using System.Linq;

namespace LookScan
{
    public class FilaConfigProyeccion
    {
        public string Cuenta { get; set; }
        public decimal MontoBase { get; set; }
        public string Metodo { get; set; }
        public string Valor { get; set; }
    }

    public class ResultadoProforma
    {
        public ResultadoProforma()
        {
            Periodos = new List<Periodo>();
            Flujos = new List<ResultadoEfe>();
            Config = new List<FilaConfigProyeccion>();
        }

        public Periodo Base { get; set; }
        public int Anios { get; set; }
        public decimal Crecimiento { get; set; }
        public decimal TasaImpuestos { get; set; }
        public decimal Retencion { get; set; }
        public List<Periodo> Periodos { get; private set; }
        public List<ResultadoEfe> Flujos { get; private set; }
        public List<FilaConfigProyeccion> Config { get; private set; }
    }

    // Motor de proyección de estados financieros. Las ventas crecen a una tasa
    // anual; costos y gastos se mantienen como proporción de ventas; el
    // patrimonio incorpora la utilidad retenida y el efectivo actúa como
    // partida de cuadre para que el balance cierre.
    public static class Proforma
    {
        public static ResultadoProforma Generar(Periodo baseP, int anios,
                                                decimal crecimiento, decimal tasaImpuestos,
                                                decimal retencion)
        {
            if (baseP == null || !baseP.TieneDatos)
                throw new InvalidOperationException("Seleccione un periodo base con datos para proyectar.");

            if (anios < 1) anios = 1;

            var resultado = new ResultadoProforma
            {
                Base = baseP,
                Anios = anios,
                Crecimiento = crecimiento,
                TasaImpuestos = tasaImpuestos,
                Retencion = retencion
            };

            decimal ventasBase = Calculos.Ventas(baseP);

            for (int anio = 1; anio <= anios; anio++)
            {
                Periodo proyectado = new Periodo(NombreProyectado(baseP, anio));
                proyectado.EsProforma = true;

                decimal factorVentas = (decimal)Math.Pow((double)(1m + crecimiento), anio);
                decimal ventasProyectadas = ventasBase * factorVentas;

                ProyectarResultados(baseP, proyectado, ventasBase, ventasProyectadas, tasaImpuestos);
                ProyectarBalance(baseP, proyectado, ventasBase, ventasProyectadas, retencion);
                CuadrarEfectivo(proyectado);

                resultado.Periodos.Add(proyectado);

                Periodo anterior = anio == 1 ? baseP : resultado.Periodos[anio - 2];
                resultado.Flujos.Add(Calculos.Efe(anterior, proyectado, true));
            }

            resultado.Config.AddRange(Configuracion(baseP, crecimiento, tasaImpuestos, retencion));
            return resultado;
        }

        // ── Estado de resultados ─────────────────────────────────────────────

        private static void ProyectarResultados(Periodo baseP, Periodo proyectado,
                                                decimal ventasBase, decimal ventasProyectadas,
                                                decimal tasaImpuestos)
        {
            foreach (Cuenta cuenta in baseP.ER)
            {
                decimal monto;

                if (EsVentas(cuenta))
                {
                    monto = ventasBase != 0m
                        ? cuenta.Monto * (ventasProyectadas / ventasBase)
                        : cuenta.Monto;
                }
                else if (EsImpuestos(cuenta))
                {
                    // Se calcula después de conocer la utilidad antes de impuestos.
                    monto = 0m;
                }
                else
                {
                    monto = ventasBase != 0m
                        ? cuenta.Monto / ventasBase * ventasProyectadas
                        : cuenta.Monto;
                }

                proyectado.Cuentas.Add(Clonar(cuenta, monto));
            }

            decimal uai = Calculos.UtilidadAntesImpuestos(proyectado);
            decimal impuesto = uai > 0m ? uai * tasaImpuestos : 0m;

            List<Cuenta> cuentasImpuesto = proyectado.ER.Where(EsImpuestos).ToList();

            if (cuentasImpuesto.Count > 0)
            {
                cuentasImpuesto[0].Monto = impuesto;

                for (int i = 1; i < cuentasImpuesto.Count; i++)
                    cuentasImpuesto[i].Monto = 0m;
            }
            else if (impuesto != 0m)
            {
                proyectado.Cuentas.Add(new Cuenta
                {
                    Tipo = TipoEstado.ER,
                    Nombre = "Impuesto a la renta",
                    Clasificacion = Clasif.Impuestos,
                    Operativa = true,
                    Monto = impuesto
                });
            }
        }

        // ── Balance general ──────────────────────────────────────────────────

        private static void ProyectarBalance(Periodo baseP, Periodo proyectado,
                                             decimal ventasBase, decimal ventasProyectadas,
                                             decimal retencion)
        {
            foreach (Cuenta cuenta in baseP.BG)
            {
                decimal monto;

                if (EsEfectivo(cuenta))
                {
                    // El efectivo se define como partida de cuadre al final.
                    monto = 0m;
                }
                else if (Clasif.EsPatrimonio(cuenta.Clasificacion))
                {
                    monto = cuenta.Monto;
                }
                else if (Util.Igual(cuenta.Clasificacion, Clasif.ActivoNoCorriente) ||
                         Util.Igual(cuenta.Clasificacion, Clasif.PasivoNoCorriente))
                {
                    monto = cuenta.Monto;
                }
                else if (Util.Igual(cuenta.Clasificacion, Clasif.PasivoCorriente) && EsDeudaFinanciera(cuenta))
                {
                    monto = cuenta.Monto;
                }
                else if (Util.Igual(cuenta.Clasificacion, Clasif.ActivoCorriente) ||
                         Util.Igual(cuenta.Clasificacion, Clasif.PasivoCorriente))
                {
                    monto = ventasBase != 0m
                        ? cuenta.Monto / ventasBase * ventasProyectadas
                        : cuenta.Monto;
                }
                else
                {
                    monto = cuenta.Monto;
                }

                proyectado.Cuentas.Add(Clonar(cuenta, monto));
            }

            // La utilidad retenida se incorpora al patrimonio. Si hay pérdida,
            // se absorbe completa para no ocultar el deterioro.
            decimal utilidadNeta = Calculos.UtilidadNeta(proyectado);
            decimal retenido = utilidadNeta > 0m ? utilidadNeta * retencion : utilidadNeta;

            if (retenido != 0m)
            {
                Cuenta acumulada = proyectado.BG.FirstOrDefault(EsResultadoAcumulado);

                if (acumulada != null)
                {
                    acumulada.Monto += retenido;
                }
                else
                {
                    proyectado.Cuentas.Add(new Cuenta
                    {
                        Tipo = TipoEstado.BG,
                        Nombre = "Utilidades retenidas",
                        Clasificacion = Clasif.Patrimonio,
                        Operativa = true,
                        Monto = retenido
                    });
                }
            }
        }

        private static void CuadrarEfectivo(Periodo proyectado)
        {
            decimal activoNoEfectivo = proyectado.BG
                .Where(c => Clasif.EsActivo(c.Clasificacion) && !EsEfectivo(c))
                .Sum(c => c.Monto);

            decimal pasivoYPatrimonio = Calculos.PasivoTotal(proyectado) + Calculos.Patrimonio(proyectado);
            decimal efectivoCuadre = pasivoYPatrimonio - activoNoEfectivo;

            List<Cuenta> cuentasEfectivo = proyectado.BG.Where(EsEfectivo).ToList();

            if (cuentasEfectivo.Count > 0)
            {
                cuentasEfectivo[0].Monto = efectivoCuadre;

                for (int i = 1; i < cuentasEfectivo.Count; i++)
                    cuentasEfectivo[i].Monto = 0m;
            }
            else
            {
                proyectado.Cuentas.Add(new Cuenta
                {
                    Tipo = TipoEstado.BG,
                    Nombre = "Efectivo (cuadre)",
                    Clasificacion = Clasif.ActivoCorriente,
                    Operativa = true,
                    Monto = efectivoCuadre
                });
            }
        }

        // ── Configuración mostrada en pantalla ───────────────────────────────

        private static IEnumerable<FilaConfigProyeccion> Configuracion(Periodo baseP,
                                                                       decimal crecimiento,
                                                                       decimal tasaImpuestos,
                                                                       decimal retencion)
        {
            var filas = new List<FilaConfigProyeccion>();
            decimal ventas = Calculos.Ventas(baseP);

            foreach (Cuenta cuenta in baseP.ER
                .OrderBy(c => Clasif.Orden(c.Clasificacion))
                .ThenBy(c => Util.Clave(c.Nombre)))
            {
                string metodo;
                string valor;

                if (EsVentas(cuenta))
                {
                    metodo = "Crecimiento anual";
                    valor = Util.Pct(crecimiento);
                }
                else if (EsImpuestos(cuenta))
                {
                    metodo = "Tasa sobre UAI";
                    valor = Util.Pct(tasaImpuestos);
                }
                else
                {
                    metodo = "% de ventas";
                    valor = ventas != 0m ? Util.Pct(cuenta.Monto / ventas) : "N/D";
                }

                filas.Add(new FilaConfigProyeccion
                {
                    Cuenta = cuenta.Nombre,
                    MontoBase = cuenta.Monto,
                    Metodo = metodo,
                    Valor = valor
                });
            }

            foreach (Cuenta cuenta in baseP.BG
                .OrderBy(c => Clasif.Orden(c.Clasificacion))
                .ThenBy(c => Util.Clave(c.Nombre)))
            {
                string metodo;
                string valor;

                if (EsEfectivo(cuenta))
                {
                    metodo = "Partida de cuadre";
                    valor = "—";
                }
                else if (EsResultadoAcumulado(cuenta))
                {
                    metodo = "Utilidad retenida";
                    valor = Util.Pct(retencion);
                }
                else if (Clasif.EsPatrimonio(cuenta.Clasificacion) ||
                         Util.Igual(cuenta.Clasificacion, Clasif.ActivoNoCorriente) ||
                         Util.Igual(cuenta.Clasificacion, Clasif.PasivoNoCorriente) ||
                         (Util.Igual(cuenta.Clasificacion, Clasif.PasivoCorriente) && EsDeudaFinanciera(cuenta)))
                {
                    metodo = "Constante";
                    valor = "0%";
                }
                else
                {
                    metodo = "% de ventas";
                    valor = ventas != 0m ? Util.Pct(cuenta.Monto / ventas) : "N/D";
                }

                filas.Add(new FilaConfigProyeccion
                {
                    Cuenta = cuenta.Nombre,
                    MontoBase = cuenta.Monto,
                    Metodo = metodo,
                    Valor = valor
                });
            }

            return filas;
        }

        // ── Auxiliares ───────────────────────────────────────────────────────

        private static string NombreProyectado(Periodo baseP, int anio)
        {
            int numero;
            if (int.TryParse(baseP.Nombre.Trim(), out numero))
                return (numero + anio).ToString();

            return baseP.Nombre + " +" + anio;
        }

        private static Cuenta Clonar(Cuenta cuenta, decimal monto)
        {
            return new Cuenta
            {
                Tipo = cuenta.Tipo,
                Nombre = cuenta.Nombre,
                Clasificacion = cuenta.Clasificacion,
                Operativa = cuenta.Operativa,
                Monto = monto
            };
        }

        private static bool EsVentas(Cuenta cuenta)
        {
            return Util.Igual(cuenta.Clasificacion, Clasif.Ventas);
        }

        private static bool EsImpuestos(Cuenta cuenta)
        {
            return Util.Igual(cuenta.Clasificacion, Clasif.Impuestos);
        }

        private static bool EsEfectivo(Cuenta cuenta)
        {
            return Clasif.ClasificadorEfe.ObtenerCategoria(cuenta) ==
                   Clasif.ClasificadorEfe.CategoriaEfe.Efectivo;
        }

        private static bool EsDeudaFinanciera(Cuenta cuenta)
        {
            string nombre = Util.Clave(cuenta.Nombre);

            return nombre.Contains("prestamo") ||
                   nombre.Contains("obligacion financiera") ||
                   nombre.Contains("obligaciones financieras") ||
                   nombre.Contains("bono") ||
                   nombre.Contains("deuda financiera") ||
                   nombre.Contains("leasing financiero");
        }

        private static bool EsResultadoAcumulado(Cuenta cuenta)
        {
            if (!Clasif.EsPatrimonio(cuenta.Clasificacion)) return false;

            string nombre = Util.Clave(cuenta.Nombre);

            return nombre.Contains("deficit acumulado") ||
                   nombre.Contains("resultados acumulados") ||
                   nombre.Contains("utilidades retenidas") ||
                   nombre.Contains("perdidas acumuladas");
        }
    }
}
