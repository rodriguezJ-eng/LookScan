using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LookScan
{
    // Motor de interpretación local: trabaja únicamente con los datos
    // registrados en Almacen y con los cálculos del proyecto. No usa
    // internet ni servicios externos, y nunca inventa cifras.
    public static class MotorIa
    {
        // ── Resumen de datos del periodo ─────────────────────────────────────

        public static string ResumenDatos(Periodo p)
        {
            var sb = new StringBuilder();
            sb.AppendLine("RESUMEN DE DATOS");
            sb.AppendLine("Empresa: " + NombreEmpresa());
            sb.AppendLine("Generado: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"));

            if (p == null)
            {
                sb.AppendLine();
                sb.AppendLine("No hay un periodo activo. Seleccione o cree un periodo en la pestaña Datos.");
                return sb.ToString();
            }

            sb.AppendLine("Periodo analizado: " + p.Nombre + (p.EsProforma ? " (proforma)" : string.Empty));
            sb.AppendLine();

            if (!p.TieneDatos)
            {
                sb.AppendLine("El periodo no tiene cuentas registradas.");
                sb.AppendLine("Capture los datos en la pestaña Datos o use el botón «Cargar Demo».");
                return sb.ToString();
            }

            decimal ventas = Calculos.Ventas(p);
            decimal utilidadNeta = Calculos.UtilidadNeta(p);
            decimal activo = Calculos.ActivoTotal(p);
            decimal pasivo = Calculos.PasivoTotal(p);
            decimal patrimonio = Calculos.Patrimonio(p);
            decimal cnt = Calculos.ActivoCorriente(p) - Calculos.PasivoCorriente(p);

            sb.AppendLine("Ventas: " + Util.Monto(ventas));
            sb.AppendLine("Utilidad neta: " + Util.Monto(utilidadNeta));
            sb.AppendLine("Activo total: " + Util.Monto(activo));
            sb.AppendLine("Pasivo total: " + Util.Monto(pasivo));
            sb.AppendLine("Patrimonio: " + Util.Monto(patrimonio));
            sb.AppendLine("Capital neto de trabajo (CNT): " + Util.Monto(cnt));
            sb.AppendLine("Cuentas registradas: " + p.Cuentas.Count +
                          " (balance: " + p.BG.Count() + ", resultados: " + p.ER.Count() + ")");
            sb.AppendLine();

            sb.AppendLine("Indicadores clave:");
            sb.AppendLine("- Margen neto: " + Util.Pct(MargenNeto(p)));
            sb.AppendLine("- ROA: " + Util.Pct(Roa(p)));
            sb.AppendLine("- ROE: " + Util.Pct(Roe(p)));
            sb.AppendLine("- Razón corriente: " + Util.Veces(RazonCorriente(p)));
            sb.AppendLine("- Deuda sobre activo: " + Util.Pct(DeudaSobreActivo(p)));

            decimal diferenciaBalance = activo - Calculos.PasivoYPatrimonio(p);
            sb.AppendLine();
            sb.AppendLine("Cuadre del balance: " +
                (Math.Abs(diferenciaBalance) <= 0.5m
                    ? "correcto."
                    : "diferencia de " + Util.Monto(diferenciaBalance) + "."));

            return sb.ToString();
        }

        // ── Interpretación automática de un periodo ──────────────────────────

        public static string InterpretacionPeriodo(Periodo p)
        {
            var sb = new StringBuilder();
            sb.AppendLine("INTERPRETACIÓN AUTOMÁTICA");
            sb.AppendLine("Empresa: " + NombreEmpresa());

            if (p == null)
            {
                sb.AppendLine();
                sb.AppendLine("No hay un periodo activo para interpretar.");
                return sb.ToString();
            }

            sb.AppendLine("Periodo: " + p.Nombre + (p.EsProforma ? " (proforma)" : string.Empty));
            sb.AppendLine();

            if (!p.TieneDatos)
            {
                sb.AppendLine("El periodo no tiene datos. Capture cuentas o use «Cargar Demo» para generar la interpretación.");
                return sb.ToString();
            }

            var razones = Calculos.Razones(p).ToList();

            foreach (string grupo in new[] { "Liquidez", "Actividad", "Endeudamiento", "Rentabilidad" })
            {
                var delGrupo = razones.Where(r => Util.Igual(r.Grupo, grupo)).ToList();
                if (delGrupo.Count == 0) continue;

                sb.AppendLine(grupo.ToUpperInvariant());
                foreach (Razon razon in delGrupo)
                {
                    sb.AppendLine("- " + razon.Nombre + ": " + razon.ValorTexto + ". " + razon.Interpretacion);
                }
                sb.AppendLine();
            }

            sb.AppendLine("DUPONT");
            foreach (Razon razon in Calculos.DuPontRazones(p))
            {
                sb.AppendLine("- " + razon.Nombre + ": " + razon.ValorTexto + ". " + razon.Interpretacion);
            }
            sb.AppendLine();

            Periodo anterior = PeriodoAnterior(p);
            if (anterior != null)
            {
                ResultadoEoaf eoaf = Calculos.Eoaf(anterior, p);
                sb.AppendLine("ORIGEN Y APLICACIÓN DE FONDOS (" + anterior.Nombre + " → " + p.Nombre + ")");
                sb.AppendLine("- Total origen: " + Util.Monto(eoaf.TotalOrigen));
                sb.AppendLine("- Total aplicación: " + Util.Monto(eoaf.TotalAplicacion));
                sb.AppendLine("- Diferencia: " + Util.Monto(eoaf.Diferencia) +
                    (Math.Abs(eoaf.Diferencia) <= 0.5m
                        ? " (origen y aplicación coinciden)."
                        : " (revise las cuentas: el origen no coincide con la aplicación)."));
                sb.AppendLine();

                ResultadoEfe efe = Calculos.Efe(anterior, p, true);
                sb.AppendLine("FLUJO DE EFECTIVO (" + anterior.Nombre + " → " + p.Nombre + ", método indirecto)");
                sb.AppendLine("- Efectivo inicial: " + Util.Monto(efe.EfectivoInicial));
                sb.AppendLine("- Efectivo final calculado: " + Util.Monto(efe.EfectivoCalculado));
                sb.AppendLine("- Efectivo final según balance: " + Util.Monto(efe.EfectivoFinalBalance));
                sb.AppendLine("- Diferencia: " + Util.Monto(efe.Diferencia) +
                    (Math.Abs(efe.Diferencia) <= 0.5m
                        ? " (conciliado)."
                        : " (el flujo no concilia con el balance)."));
                sb.AppendLine();
            }
            else
            {
                sb.AppendLine("No hay un periodo anterior con datos para calcular EOAF ni flujo de efectivo.");
                sb.AppendLine();
            }

            var alertas = Alertas(p);
            sb.AppendLine("ALERTAS");
            if (alertas.Count == 0)
            {
                sb.AppendLine("- Sin alertas relevantes con los datos disponibles.");
            }
            else
            {
                foreach (string alerta in alertas)
                    sb.AppendLine("- " + alerta);
            }

            return sb.ToString();
        }

        // ── Resumen global de todos los periodos ─────────────────────────────

        public static string ResumenGlobal()
        {
            var sb = new StringBuilder();
            sb.AppendLine("RESUMEN GLOBAL");
            sb.AppendLine("Empresa: " + NombreEmpresa());
            sb.AppendLine("Generado: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
            sb.AppendLine();

            List<Periodo> periodos = PeriodosConDatos();
            if (periodos.Count == 0)
            {
                sb.AppendLine("No hay periodos con datos. Capture información o use «Cargar Demo».");
                return sb.ToString();
            }

            sb.AppendLine("Periodos analizados: " + string.Join(", ", periodos.Select(x => x.Nombre)));
            int proformas = periodos.Count(x => x.EsProforma);
            if (proformas > 0)
                sb.AppendLine("Incluye " + proformas + " periodo(s) proyectado(s) como proforma.");
            sb.AppendLine();

            sb.AppendLine("EVOLUCIÓN DE INDICADORES");
            sb.AppendLine("Periodo | Ventas | Utilidad neta | Margen neto | ROA | ROE | Razón corriente | Deuda/activo");

            foreach (Periodo p in periodos)
            {
                sb.AppendLine(
                    p.Nombre +
                    " | " + Util.Monto(Calculos.Ventas(p)) +
                    " | " + Util.Monto(Calculos.UtilidadNeta(p)) +
                    " | " + Util.Pct(MargenNeto(p)) +
                    " | " + Util.Pct(Roa(p)) +
                    " | " + Util.Pct(Roe(p)) +
                    " | " + Util.Veces(RazonCorriente(p)) +
                    " | " + Util.Pct(DeudaSobreActivo(p)));
            }
            sb.AppendLine();

            Periodo primero = periodos[0];
            Periodo ultimo = periodos[periodos.Count - 1];

            sb.AppendLine("TENDENCIAS");
            sb.AppendLine("- Ventas: " + Tendencia(Calculos.Ventas(primero), Calculos.Ventas(ultimo)));
            sb.AppendLine("- Utilidad neta: " + Tendencia(Calculos.UtilidadNeta(primero), Calculos.UtilidadNeta(ultimo)));
            sb.AppendLine("- Margen neto: " + TendenciaPct(MargenNeto(primero), MargenNeto(ultimo)));
            sb.AppendLine("- ROA: " + TendenciaPct(Roa(primero), Roa(ultimo)));
            sb.AppendLine("- ROE: " + TendenciaPct(Roe(primero), Roe(ultimo)));
            sb.AppendLine("- Razón corriente: " + Tendencia(RazonCorriente(primero) ?? 0m, RazonCorriente(ultimo) ?? 0m));
            sb.AppendLine();

            var conUtilidad = periodos
                .Select(p => new { Periodo = p, Utilidad = Calculos.UtilidadNeta(p) })
                .ToList();

            var mejor = conUtilidad.OrderByDescending(x => x.Utilidad).First();
            var peor = conUtilidad.OrderBy(x => x.Utilidad).First();

            sb.AppendLine("MEJOR Y PEOR PERIODO (por utilidad neta)");
            sb.AppendLine("- Mejor: " + mejor.Periodo.Nombre + " con " + Util.Monto(mejor.Utilidad) + ".");
            sb.AppendLine("- Peor: " + peor.Periodo.Nombre + " con " + Util.Monto(peor.Utilidad) + ".");
            sb.AppendLine();

            sb.AppendLine("LECTURA POR GRUPO DE RAZONES (último periodo: " + ultimo.Nombre + ")");
            var razones = Calculos.Razones(ultimo).ToList();

            foreach (string grupo in new[] { "Liquidez", "Actividad", "Endeudamiento", "Rentabilidad" })
            {
                var delGrupo = razones.Where(r => Util.Igual(r.Grupo, grupo)).ToList();
                if (delGrupo.Count == 0) continue;

                sb.AppendLine(grupo + ":");
                foreach (Razon razon in delGrupo)
                    sb.AppendLine("  - " + razon.Nombre + ": " + razon.ValorTexto + ". " + razon.Interpretacion);
            }
            sb.AppendLine();

            sb.AppendLine("DUPONT (último periodo)");
            foreach (Razon razon in Calculos.DuPontRazones(ultimo))
                sb.AppendLine("- " + razon.Nombre + ": " + razon.ValorTexto + ". " + razon.Interpretacion);
            sb.AppendLine();

            sb.AppendLine("ALERTAS GLOBALES");
            var alertasGlobales = new List<string>();

            foreach (Periodo p in periodos)
            {
                foreach (string alerta in Alertas(p))
                    alertasGlobales.Add(p.Nombre + ": " + alerta);
            }

            if (alertasGlobales.Count == 0)
            {
                sb.AppendLine("- Sin alertas relevantes en los periodos analizados.");
            }
            else
            {
                foreach (string alerta in alertasGlobales)
                    sb.AppendLine("- " + alerta);
            }

            sb.AppendLine();
            sb.AppendLine("CONCLUSIÓN");
            sb.AppendLine(ConclusionGlobal(periodos));

            return sb.ToString();
        }

        // ── Alertas ──────────────────────────────────────────────────────────

        public static List<string> Alertas(Periodo p)
        {
            var alertas = new List<string>();
            if (p == null || !p.TieneDatos) return alertas;

            decimal patrimonio = Calculos.Patrimonio(p);
            decimal utilidadNeta = Calculos.UtilidadNeta(p);
            decimal activo = Calculos.ActivoTotal(p);
            decimal pasivo = Calculos.PasivoTotal(p);
            decimal activoCorriente = Calculos.ActivoCorriente(p);
            decimal pasivoCorriente = Calculos.PasivoCorriente(p);
            decimal gastosFinancieros = Calculos.GastosFinancieros(p);
            decimal utilidadOperativa = Calculos.UtilidadOperativa(p);

            if (patrimonio < 0m)
                alertas.Add("Patrimonio negativo (" + Util.Monto(patrimonio) + "): la empresa está descapitalizada.");

            if (utilidadNeta < 0m)
                alertas.Add("Pérdida neta del periodo (" + Util.Monto(utilidadNeta) + ").");

            if (pasivoCorriente > 0m && activoCorriente < pasivoCorriente)
                alertas.Add("Capital de trabajo negativo: el activo corriente no cubre el pasivo corriente.");

            decimal? corriente = RazonCorriente(p);
            if (corriente.HasValue && corriente.Value < 1m)
                alertas.Add("Razón corriente menor a 1 (" + Util.Veces(corriente) + "): riesgo de iliquidez.");

            if (gastosFinancieros != 0m && utilidadOperativa < gastosFinancieros)
                alertas.Add("Cobertura de intereses insuficiente: la utilidad operativa no cubre los gastos financieros.");

            decimal? deuda = DeudaSobreActivo(p);
            if (deuda.HasValue && deuda.Value > 0.6m)
                alertas.Add("Endeudamiento alto: " + Util.Pct(deuda) + " del activo se financia con deuda.");

            if (activo > 0m && Math.Abs(activo - Calculos.PasivoYPatrimonio(p)) > 0.5m)
                alertas.Add("El balance no cuadra: activo y pasivo más patrimonio difieren en " +
                            Util.Monto(activo - Calculos.PasivoYPatrimonio(p)) + ".");

            if (p.EsProforma && EfectivoTotal(p) < 0m)
                alertas.Add("El efectivo de cuadre de la proforma es negativo (" +
                            Util.Monto(EfectivoTotal(p)) + "): la proyección requiere financiamiento adicional.");

            return alertas;
        }

        // ── Auxiliares públicos ──────────────────────────────────────────────

        public static Periodo PeriodoAnterior(Periodo p)
        {
            if (p == null) return null;

            List<Periodo> periodos = PeriodosConDatos();
            int indice = periodos.FindIndex(x => Util.Igual(x.Nombre, p.Nombre));
            return indice > 0 ? periodos[indice - 1] : null;
        }

        public static List<Periodo> PeriodosConDatos()
        {
            return Almacen.Periodos
                .Where(p => p.TieneDatos)
                .OrderBy(p => p.Nombre, StringComparer.Ordinal)
                .ToList();
        }

        public static decimal? MargenNeto(Periodo p)
        {
            if (p == null) return null;
            decimal ventas = Calculos.Ventas(p);
            return ventas != 0m ? (decimal?)(Calculos.UtilidadNeta(p) / ventas) : null;
        }

        public static decimal? Roa(Periodo p)
        {
            if (p == null) return null;
            decimal activo = Calculos.ActivoTotal(p);
            return activo != 0m ? (decimal?)(Calculos.UtilidadNeta(p) / activo) : null;
        }

        public static decimal? Roe(Periodo p)
        {
            if (p == null) return null;
            decimal patrimonio = Calculos.Patrimonio(p);
            return patrimonio > 0m ? (decimal?)(Calculos.UtilidadNeta(p) / patrimonio) : null;
        }

        public static decimal? RazonCorriente(Periodo p)
        {
            if (p == null) return null;
            decimal pasivo = Calculos.PasivoCorriente(p);
            return pasivo != 0m ? (decimal?)(Calculos.ActivoCorriente(p) / pasivo) : null;
        }

        public static decimal? DeudaSobreActivo(Periodo p)
        {
            if (p == null) return null;
            decimal activo = Calculos.ActivoTotal(p);
            return activo != 0m ? (decimal?)(Calculos.PasivoTotal(p) / activo) : null;
        }

        // ── Auxiliares privados ──────────────────────────────────────────────

        private static string NombreEmpresa()
        {
            return string.IsNullOrWhiteSpace(Almacen.Empresa) ? "(sin nombre)" : Almacen.Empresa.Trim();
        }

        private static decimal EfectivoTotal(Periodo p)
        {
            decimal total = 0m;

            foreach (Cuenta cuenta in p.BG)
            {
                if (Clasif.ClasificadorEfe.ObtenerCategoria(cuenta) ==
                    Clasif.ClasificadorEfe.CategoriaEfe.Efectivo)
                {
                    total += cuenta.Monto;
                }
            }

            return total;
        }

        private static string Tendencia(decimal inicial, decimal final)
        {
            if (inicial == 0m)
                return final == 0m ? "sin cambios." : "no comparable (valor inicial cero).";

            decimal variacion = (final - inicial) / Math.Abs(inicial);
            string sentido = variacion > 0m ? "aumentó" : variacion < 0m ? "disminuyó" : "se mantuvo";
            return sentido + " " + Util.Pct(Math.Abs(variacion)) + " (" +
                   Util.Monto(inicial) + " → " + Util.Monto(final) + ").";
        }

        private static string TendenciaPct(decimal? inicial, decimal? final)
        {
            if (!inicial.HasValue || !final.HasValue)
                return "no comparable con los datos disponibles.";

            decimal diferencia = final.Value - inicial.Value;
            if (diferencia == 0m)
                return "sin cambios (" + Util.Pct(inicial) + ").";

            string sentido = diferencia > 0m ? "mejoró" : "empeoró";
            return sentido + " de " + Util.Pct(inicial) + " a " + Util.Pct(final) +
                   " (" + (diferencia > 0m ? "+" : string.Empty) +
                   (diferencia * 100m).ToString("N1") + " p.p.).";
        }

        private static string ConclusionGlobal(List<Periodo> periodos)
        {
            if (periodos == null || periodos.Count == 0)
                return "No hay periodos suficientes para emitir una conclusión.";

            Periodo primero = periodos[0];
            Periodo ultimo = periodos[periodos.Count - 1];

            var partes = new List<string>();

            decimal ventasInicial = Calculos.Ventas(primero);
            decimal ventasFinal = Calculos.Ventas(ultimo);

            if (ventasInicial != 0m)
            {
                decimal variacion = (ventasFinal - ventasInicial) / Math.Abs(ventasInicial);
                partes.Add("Las ventas " + (variacion >= 0m ? "crecieron " : "cayeron ") +
                           Util.Pct(Math.Abs(variacion)) + " entre " + primero.Nombre + " y " + ultimo.Nombre + ".");
            }

            decimal? margen = MargenNeto(ultimo);
            if (margen.HasValue)
            {
                partes.Add("El margen neto del último periodo es " + Util.Pct(margen) +
                           (margen.Value < 0m ? ", lo que confirma una operación con pérdidas." : "."));
            }

            decimal? liquidez = RazonCorriente(ultimo);
            if (liquidez.HasValue)
            {
                partes.Add("La razón corriente se ubica en " + Util.Veces(liquidez) +
                           (liquidez.Value < 1m ? ", por debajo del mínimo recomendado de 1.0x." : ", dentro de un rango aceptable."));
            }

            if (Calculos.Patrimonio(ultimo) < 0m)
                partes.Add("El patrimonio negativo exige revisar la estructura de capital y la viabilidad de la empresa.");

            if (partes.Count == 0)
                return "Los datos disponibles no permiten una conclusión global.";

            return string.Join(" ", partes);
        }
    }
}
