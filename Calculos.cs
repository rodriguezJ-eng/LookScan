using System;
using System.Collections.Generic;
using System.Linq;

namespace LookScan
{
    public static class Calculos
    {
        private enum FormatoRazon
        {
            Veces,
            Porcentaje,
            Dias
        }

        // ── Totales del balance ──────────────────────────────────────────────

        public static decimal ActivoCorriente(Periodo p)
        {
            return Suma(p, TipoEstado.BG, Clasif.ActivoCorriente);
        }

        public static decimal ActivoNoCorriente(Periodo p)
        {
            return Suma(p, TipoEstado.BG, Clasif.ActivoNoCorriente);
        }

        public static decimal ActivoTotal(Periodo p)
        {
            return ActivoCorriente(p) + ActivoNoCorriente(p);
        }

        public static decimal PasivoCorriente(Periodo p)
        {
            return Suma(p, TipoEstado.BG, Clasif.PasivoCorriente);
        }

        public static decimal PasivoNoCorriente(Periodo p)
        {
            return Suma(p, TipoEstado.BG, Clasif.PasivoNoCorriente);
        }

        public static decimal PasivoTotal(Periodo p)
        {
            return PasivoCorriente(p) + PasivoNoCorriente(p);
        }

        public static decimal Patrimonio(Periodo p)
        {
            return Suma(p, TipoEstado.BG, Clasif.Patrimonio);
        }

        public static decimal PasivoYPatrimonio(Periodo p)
        {
            return PasivoTotal(p) + Patrimonio(p);
        }

        // ── Totales del estado de resultados ─────────────────────────────────

        public static decimal Ventas(Periodo p)
        {
            return Suma(p, TipoEstado.ER, Clasif.Ventas);
        }

        public static decimal CostoVentas(Periodo p)
        {
            return Suma(p, TipoEstado.ER, Clasif.CostoVentas);
        }

        public static decimal GastosOperativos(Periodo p)
        {
            return Suma(p, TipoEstado.ER, Clasif.GastosOperativos);
        }

        public static decimal GastosFinancieros(Periodo p)
        {
            return Suma(p, TipoEstado.ER, Clasif.GastosFinancieros);
        }
        public static decimal OtrosIngresos(Periodo p)
        {
            return Suma(p, TipoEstado.ER, Clasif.OtrosIngresos);
        }

        public static decimal Impuestos(Periodo p)
        {
            return Suma(p, TipoEstado.ER, Clasif.Impuestos);
        }

        public static decimal UtilidadBruta(Periodo p)
        {
            return Ventas(p) - CostoVentas(p);
        }

        public static decimal UtilidadOperativa(Periodo p)
        {
            return UtilidadBruta(p) - GastosOperativos(p);
        }

        public static decimal UtilidadAntesImpuestos(Periodo p)
        {
            return UtilidadOperativa(p) - GastosFinancieros(p) + OtrosIngresos(p);
        }

        public static decimal UtilidadNeta(Periodo p)
        {
            return UtilidadAntesImpuestos(p) - Impuestos(p);
        }

        // ── Análisis horizontal ──────────────────────────────────────────────

        public static IEnumerable<FilaComparativa> Horizontal(Periodo baseP, Periodo comparadoP, TipoEstado tipo)
        {
            var resultado = new List<FilaComparativa>();
            if (baseP == null || comparadoP == null) return resultado;

            Dictionary<string, decimal> montosBase = Montos(baseP, tipo);
            Dictionary<string, decimal> montosComparados = Montos(comparadoP, tipo);
            Dictionary<string, Cuenta> representantes = Representantes(baseP, comparadoP, tipo);

            List<string> claves = montosBase.Keys
                .Union(montosComparados.Keys)
                .Where(k => representantes.ContainsKey(k))
                .OrderBy(k => Clasif.Orden(representantes[k].Clasificacion))
                .ThenBy(k => Util.Clave(representantes[k].Nombre))
                .ToList();

            foreach (string clave in claves)
            {
                decimal baseMonto = montosBase.ContainsKey(clave) ? montosBase[clave] : 0m;
                decimal comparadoMonto = montosComparados.ContainsKey(clave) ? montosComparados[clave] : 0m;
                Cuenta cuenta = representantes[clave];

                resultado.Add(new FilaComparativa
                {
                    Total = false,
                    Cuenta = cuenta.Nombre,
                    Base = baseMonto,
                    Comparado = comparadoMonto,
                    Delta = comparadoMonto - baseMonto,
                    Pct = baseMonto != 0m
                        ? (decimal?)((comparadoMonto - baseMonto) / Math.Abs(baseMonto))
                        : null
                });
            }

            if (tipo == TipoEstado.BG)
            {
                resultado.Add(FilaTotal("Total activo", ActivoTotal(baseP), ActivoTotal(comparadoP)));
                resultado.Add(FilaTotal("Total pasivo y patrimonio",
                    PasivoYPatrimonio(baseP), PasivoYPatrimonio(comparadoP)));
            }
            else
            {
                resultado.Add(FilaTotal("Total ventas", Ventas(baseP), Ventas(comparadoP)));
                resultado.Add(FilaTotal("Utilidad neta", UtilidadNeta(baseP), UtilidadNeta(comparadoP)));
            }

            return resultado;
        }

        // ── Análisis vertical ────────────────────────────────────────────────

        public static IEnumerable<FilaVertical> VerticalBG(Periodo p)
        {
            var resultado = new List<FilaVertical>();
            if (p == null) return resultado;

            decimal totalActivo = ActivoTotal(p);
            decimal totalPasivoPatrimonio = PasivoYPatrimonio(p);

            foreach (Cuenta cuenta in p.BG
                .OrderBy(c => Clasif.Orden(c.Clasificacion))
                .ThenBy(c => Util.Clave(c.Nombre)))
            {
                decimal referencia = Clasif.EsActivo(cuenta.Clasificacion)
                    ? totalActivo
                    : totalPasivoPatrimonio;

                resultado.Add(new FilaVertical
                {
                    Total = false,
                    Cuenta = cuenta.Nombre,
                    Clasificacion = cuenta.Clasificacion,
                    Monto = cuenta.Monto,
                    Pct = referencia != 0m ? (decimal?)(cuenta.Monto / referencia) : null
                });
            }

            resultado.Add(FilaTotalVertical("Total activo", totalActivo, totalActivo));
            resultado.Add(FilaTotalVertical("Total pasivo", PasivoTotal(p), totalPasivoPatrimonio));
            resultado.Add(FilaTotalVertical("Total patrimonio", Patrimonio(p), totalPasivoPatrimonio));
            resultado.Add(FilaTotalVertical("Total pasivo y patrimonio",
                totalPasivoPatrimonio, totalPasivoPatrimonio));

            return resultado;
        }

        public static IEnumerable<FilaVertical> VerticalER(Periodo p)
        {
            var resultado = new List<FilaVertical>();
            if (p == null) return resultado;

            decimal ventas = Ventas(p);

            foreach (Cuenta cuenta in p.ER
                .OrderBy(c => Clasif.Orden(c.Clasificacion))
                .ThenBy(c => Util.Clave(c.Nombre)))
            {
                resultado.Add(new FilaVertical
                {
                    Total = false,
                    Cuenta = cuenta.Nombre,
                    Clasificacion = cuenta.Clasificacion,
                    Monto = cuenta.Monto,
                    Pct = ventas != 0m ? (decimal?)(cuenta.Monto / ventas) : null
                });
            }

            resultado.Add(FilaTotalVertical("Total ventas", ventas, ventas));
            resultado.Add(FilaTotalVertical("Utilidad bruta", UtilidadBruta(p), ventas));
            resultado.Add(FilaTotalVertical("Utilidad operativa", UtilidadOperativa(p), ventas));
            resultado.Add(FilaTotalVertical("Utilidad neta", UtilidadNeta(p), ventas));

            return resultado;
        }

        // ── DuPont ───────────────────────────────────────────────────────────

        public static IEnumerable<KeyValuePair<string, string>> DuPont(Periodo p)
        {
            var resultado = new List<KeyValuePair<string, string>>();
            if (p == null) return resultado;

            decimal ventas = Ventas(p);
            decimal activo = ActivoTotal(p);
            decimal patrimonio = Patrimonio(p);
            decimal utilidadNeta = UtilidadNeta(p);

            decimal? margen = ventas != 0m ? (decimal?)(utilidadNeta / ventas) : null;
            decimal? rotacion = activo != 0m ? (decimal?)(ventas / activo) : null;
            decimal? multiplicador = patrimonio != 0m ? (decimal?)(activo / patrimonio) : null;

            decimal? roe = margen.HasValue && rotacion.HasValue && multiplicador.HasValue
                ? (decimal?)(margen.Value * rotacion.Value * multiplicador.Value)
                : null;

            resultado.Add(new KeyValuePair<string, string>(
                "1) Margen neto (UN / Ventas)", Util.Pct(margen)));

            resultado.Add(new KeyValuePair<string, string>(
                "2) Rotación de activos (Ventas / Activo total)",
                rotacion.HasValue ? Util.Numero(rotacion.Value, 2) + "x" : "N/D"));

            resultado.Add(new KeyValuePair<string, string>(
                "3) Multiplicador de capital (Activo / Patrimonio)",
                multiplicador.HasValue ? Util.Numero(multiplicador.Value, 2) + "x" : "N/D"));

            resultado.Add(new KeyValuePair<string, string>(
                "ROE = 1 × 2 × 3", Util.Pct(roe)));

            return resultado;
        }

        // ── Razones financieras ──────────────────────────────────────────────

         public static IEnumerable<Razon> Razones(Periodo p)
         {
             var resultado = new List<Razon>();
             if (p == null) return resultado;

             decimal activoCorriente = ActivoCorriente(p);
             decimal pasivoCorriente = PasivoCorriente(p);
             decimal inventario = Inventario(p);
             decimal efectivo = Efectivo(p);
             decimal cuentasPorCobrar = CuentasPorCobrar(p);
             decimal cuentasPorPagar = CuentasPorPagar(p);
             decimal activo = ActivoTotal(p);
             decimal pasivo = PasivoTotal(p);
             decimal patrimonio = Patrimonio(p);
             decimal ventas = Ventas(p);
             decimal costo = CostoVentas(p);
             decimal gastosFinancieros = GastosFinancieros(p);

            
             // Liquidez
             AgregarRazon(resultado, "Liquidez", "Razón corriente",
                 activoCorriente, pasivoCorriente, FormatoRazon.Veces,
                 "Soles de activo corriente por cada sol de pasivo corriente. Se espera mayor a 1.");

             AgregarRazon(resultado, "Liquidez", "Prueba ácida",
                 activoCorriente - inventario, pasivoCorriente, FormatoRazon.Veces,
                 "Capacidad de cubrir el pasivo corriente sin vender inventarios. Se espera mayor a 1.");

             AgregarRazon(resultado, "Liquidez", "Prueba defensiva",
                 efectivo, pasivoCorriente, FormatoRazon.Veces,
                 "Cobertura del pasivo corriente usando únicamente efectivo y equivalentes.");

             // Actividad
             AgregarRazon(resultado, "Actividad", "Rotación de inventarios",
                 costo, inventario, FormatoRazon.Veces,
                 "Veces que se renueva el inventario durante el periodo.");

             AgregarRazon(resultado, "Actividad", "Periodo promedio de cobro",
                 cuentasPorCobrar, ventas, FormatoRazon.Dias,
                 "Días promedio que tarda la empresa en recuperar sus cuentas por cobrar.");

             AgregarRazon(resultado, "Actividad", "Periodo promedio de pago",
                 cuentasPorPagar, costo, FormatoRazon.Dias,
                 "Días promedio que tarda la empresa en pagar a sus proveedores.");

             AgregarRazon(resultado, "Actividad", "Rotación de activos",
                 ventas, activo, FormatoRazon.Veces,
                 "Ventas generadas por cada unidad monetaria invertida en activos.");

             // Endeudamiento
             AgregarRazon(resultado, "Endeudamiento", "Deuda sobre activo",
                 pasivo, activo, FormatoRazon.Porcentaje,
                 "Proporción del activo total financiada con deuda.");

             AgregarRazon(resultado, "Endeudamiento", "Deuda sobre patrimonio",
                 pasivo, patrimonio, FormatoRazon.Veces,
                 "Soles de deuda por cada sol de patrimonio. Se espera un valor moderado.");

             AgregarRazon(resultado, "Endeudamiento", "Cobertura de intereses",
                 UtilidadOperativa(p), gastosFinancieros, FormatoRazon.Veces,
                 "Veces que la utilidad operativa cubre los gastos financieros.");

             // Rentabilidad
             AgregarRazon(resultado, "Rentabilidad", "Margen bruto",
                 UtilidadBruta(p), ventas, FormatoRazon.Porcentaje,
                 "Porcentaje de las ventas que queda después del costo de ventas.");

             AgregarRazon(resultado, "Rentabilidad", "Margen operativo",
                 UtilidadOperativa(p), ventas, FormatoRazon.Porcentaje,
                 "Porcentaje de las ventas que queda después de los gastos operativos.");

             AgregarRazon(resultado, "Rentabilidad", "Margen neto",
                 UtilidadNeta(p), ventas, FormatoRazon.Porcentaje,
                 "Porcentaje de las ventas que se convierte en utilidad neta.");

             AgregarRazon(resultado, "Rentabilidad", "ROA",
                 UtilidadNeta(p), activo, FormatoRazon.Porcentaje,
                 "Rentabilidad generada sobre el activo total.");

             AgregarRazon(resultado, "Rentabilidad", "ROE",
                 UtilidadNeta(p), patrimonio, FormatoRazon.Porcentaje,
                 "Rentabilidad generada sobre el patrimonio de los accionistas.");

             // Mercado
             resultado.Add(new Razon
             {
                 Nombre = "Utilidad por acción (EPS)",
                 Grupo = "Mercado",
                 ValorTexto = "N/D",
                 Interpretacion = "Requiere el número de acciones en circulación."
             });

             resultado.Add(new Razon
             {
                 Nombre = "Relación precio/utilidad (P/E)",
                 Grupo = "Mercado",
                 ValorTexto = "N/D",
                 Interpretacion = "Requiere el precio de mercado de la acción."
             });

             resultado.Add(new Razon
             {
                 Nombre = "Rendimiento por dividendo",
                 Grupo = "Mercado",
                 ValorTexto = "N/D",
                 Interpretacion = "Requiere el dividendo por acción y su precio de mercado."
             });

             return resultado;
         }
        

        private static string GenerarInterpretacion(string nombre, decimal valor)
        {
            switch (nombre)
            {
                // --- LIQUIDEZ ---
                case "Razón corriente":
                    if (valor < 1.0m) return $"Alerta: Con {valor:N2}x, los pasivos superan a los activos líquidos; riesgo de iliquidez a corto plazo.";
                    if (valor <= 2.0m) return $"Saludable: Con {valor:N2}x, la empresa cubre adecuadamente sus deudas a corto plazo.";
                    return $"Precaución: {valor:N2}x indica buena liquidez, pero podría reflejar activos ociosos.";

                case "Prueba ácida":
                    if (valor < 1.0m) return $"Riesgo: Con {valor:N2}x, la empresa no podría pagar sus deudas inmediatas sin liquidar inventarios.";
                    return $"Óptimo: Con {valor:N2}x, la empresa posee alta capacidad de pago inmediato sin depender de inventarios.";

                case "Prueba defensiva":
                    if (valor < 0.20m) return $"Baja cobertura: Con {valor:N2}x, el efectivo disponible es bajo frente a las deudas inmediatas.";
                    return $"Adecuada: Con {valor:N2}x, se cuenta con suficiente efectivo para compromisos inminentes.";

                // --- ACTIVIDAD ---
                case "Rotación de inventarios":
                    return $"Eficiencia: El inventario rota {valor:N2} veces en el periodo; indica la velocidad de venta y abastecimiento.";

                case "Periodo promedio de cobro":
                    return $"Gestión de cobro: La empresa tarda en promedio {valor:N2} días en recaudar las cuentas por cobrar de sus clientes.";

                case "Periodo promedio de pago":
                    return $"Política de pagos: Se tardan unos {valor:N2} días en liquidar las obligaciones con proveedores.";

                case "Rotación de activos":
                    return $"Utilización: Cada unidad invertida en activos genera {valor:N2}x en ventas para el periodo.";

                // --- ENDEUDAMIENTO ---
                case "Deuda sobre activo":
                    if (valor > 0.60m) return $"Alto riesgo: El {valor * 100:N1}% de los activos está financiado por acreedores externos.";
                    return $"Estable: El {valor * 100:N1}% de endeudamiento muestra un nivel moderado y seguro.";

                case "Deuda sobre patrimonio":
                    return $"Apalancamiento: Existe un nivel de {valor:N2}x de deuda por cada sol aportado por los accionistas.";

                case "Cobertura de intereses":
                    if (valor < 1.0m) return $"Alerta crítica: La utilidad operativa no alcanza para cubrir los gastos financieros ({valor:N2}x).";
                    return $"Solvente: La utilidad operativa cubre {valor:N2} veces los intereses de la deuda.";

                // --- RENTABILIDAD ---
                case "Margen bruto":
                    return $"Rentabilidad de ventas: Queda un margen bruto del {valor * 100:N1}% después del costo de ventas.";

                case "Margen operativo":
                    return $"Eficiencia operativa: El {valor * 100:N1}% de las ventas representa la ganancia antes de intereses e impuestos.";

                case "Margen neto":
                    if (valor < 0.05m) return $"Margen bajo ({valor * 100:N1}%): La utilidad neta sobre las ventas es reducida.";
                    return $"Buen rendimiento: El {valor * 100:N1}% de las ventas se convierte en ganancia neta para la empresa.";

                case "ROA":
                    return $"Rendimiento de activos: Se generó un {valor * 100:N1}% de utilidad neta en relación con el total de activos.";

                case "ROE":
                    return $"Rentabilidad patrimonial: Los accionistas obtienen un rendimiento del {valor * 100:N1}% sobre su inversión.";

                default:
                    return "Indicador financiero analizado para el periodo actual.";
            }
        }



        // ── Capital de trabajo ───────────────────────────────────────────────

        public static IEnumerable<KeyValuePair<string, string>> Cnt(Periodo p)
        {
            var resultado = new List<KeyValuePair<string, string>>();
            if (p == null) return resultado;

            decimal activoCorriente = ActivoCorriente(p);
            decimal pasivoCorriente = PasivoCorriente(p);
            decimal cnt = activoCorriente - pasivoCorriente;

            resultado.Add(new KeyValuePair<string, string>("Activo corriente", Util.Monto(activoCorriente)));
            resultado.Add(new KeyValuePair<string, string>("Pasivo corriente", Util.Monto(pasivoCorriente)));
            resultado.Add(new KeyValuePair<string, string>("Capital neto de trabajo (CNT)", Util.Monto(cnt)));
            resultado.Add(new KeyValuePair<string, string>("Interpretación",
                cnt >= 0m
                    ? "Positivo: la empresa cubre sus obligaciones de corto plazo."
                    : "Negativo: existe un déficit de liquidez de corto plazo."));

            return resultado;
        }

        public static IEnumerable<KeyValuePair<string, string>> Cno(Periodo p)
        {
            var resultado = new List<KeyValuePair<string, string>>();
            if (p == null) return resultado;

            decimal activoOperativo = SumaOperativa(p, TipoEstado.BG, Clasif.ActivoCorriente);
            decimal pasivoOperativo = SumaOperativa(p, TipoEstado.BG, Clasif.PasivoCorriente);
            decimal cno = activoOperativo - pasivoOperativo;

            resultado.Add(new KeyValuePair<string, string>("Activo corriente operativo", Util.Monto(activoOperativo)));
            resultado.Add(new KeyValuePair<string, string>("Pasivo corriente operativo", Util.Monto(pasivoOperativo)));
            resultado.Add(new KeyValuePair<string, string>("Capital neto de trabajo operativo (CNO)", Util.Monto(cno)));
            resultado.Add(new KeyValuePair<string, string>("Interpretación",
                cno >= 0m
                    ? "Positivo: la operación financia sus recursos de corto plazo."
                    : "Negativo: la operación requiere financiamiento adicional de corto plazo."));

            return resultado;
        }

        // ── Auxiliares ───────────────────────────────────────────────────────

        private static decimal Suma(Periodo p, TipoEstado tipo, string clasificacion)
        {
            if (p == null) return 0m;

            return p.Cuentas
                .Where(c => c.Tipo == tipo && Util.Igual(c.Clasificacion, clasificacion))
                .Sum(c => c.Monto);
        }

        private static decimal SumaOperativa(Periodo p, TipoEstado tipo, string clasificacion)
        {
            if (p == null) return 0m;

            return p.Cuentas
                .Where(c => c.Tipo == tipo && c.Operativa &&
                            Util.Igual(c.Clasificacion, clasificacion))
                .Sum(c => c.Monto);
        }

        private static Dictionary<string, decimal> Montos(Periodo p, TipoEstado tipo)
        {
            var resultado = new Dictionary<string, decimal>(StringComparer.Ordinal);

            foreach (Cuenta cuenta in p.Cuentas.Where(c => c.Tipo == tipo))
            {
                string clave = Util.Clave(cuenta.Nombre);
                if (clave.Length == 0) continue;

                if (resultado.ContainsKey(clave)) resultado[clave] += cuenta.Monto;
                else resultado[clave] = cuenta.Monto;
            }

            return resultado;
        }

        private static Dictionary<string, Cuenta> Representantes(Periodo baseP, Periodo comparadoP, TipoEstado tipo)
        {
            var resultado = new Dictionary<string, Cuenta>(StringComparer.Ordinal);

            foreach (Cuenta cuenta in baseP.Cuentas.Where(c => c.Tipo == tipo))
            {
                string clave = Util.Clave(cuenta.Nombre);
                if (clave.Length > 0) resultado[clave] = cuenta;
            }

            foreach (Cuenta cuenta in comparadoP.Cuentas.Where(c => c.Tipo == tipo))
            {
                string clave = Util.Clave(cuenta.Nombre);
                if (clave.Length > 0 && !resultado.ContainsKey(clave)) resultado[clave] = cuenta;
            }

            return resultado;
        }

        private static FilaComparativa FilaTotal(string nombre, decimal baseMonto, decimal comparadoMonto)
        {
            return new FilaComparativa
            {
                Total = true,
                Cuenta = nombre,
                Base = baseMonto,
                Comparado = comparadoMonto,
                Delta = comparadoMonto - baseMonto,
                Pct = baseMonto != 0m
                    ? (decimal?)((comparadoMonto - baseMonto) / Math.Abs(baseMonto))
                    : null
            };
        }

        private static FilaVertical FilaTotalVertical(string nombre, decimal monto, decimal referencia)
        {
            return new FilaVertical
            {
                Total = true,
                Cuenta = nombre,
                Clasificacion = string.Empty,
                Monto = monto,
                Pct = referencia != 0m ? (decimal?)(monto / referencia) : null
            };
        }

        private static void AgregarRazon(List<Razon> lista, string grupo, string nombre, decimal numerador, decimal denominador, FormatoRazon formato, string descripcionTeorica)
        {
            decimal valor = denominador != 0 ? numerador / denominador : 0;

            string interpretacionDinamica = GenerarInterpretacion(nombre, valor);

            
            string sufijo = "";
            if (formato == FormatoRazon.Porcentaje) sufijo = "%";
            else if (formato == FormatoRazon.Veces) sufijo = "x";
            else if (formato == FormatoRazon.Dias) sufijo = " días";

            lista.Add(new Razon
            {
                Nombre = nombre,
                Grupo = grupo,
                ValorTexto = valor.ToString("N2") + sufijo,
                Interpretacion = interpretacionDinamica
            });
        
        }

        private static decimal Inventario(Periodo p)
        {
            return PorNombre(p, TipoEstado.BG, new[] { Clasif.ActivoCorriente }, "inventario");
        }

        private static decimal CuentasPorCobrar(Periodo p)
        {
            return PorNombre(p, TipoEstado.BG, new[] { Clasif.ActivoCorriente }, "cobrar");
        }

        private static decimal CuentasPorPagar(Periodo p)
        {
            return PorNombre(p, TipoEstado.BG, new[] { Clasif.PasivoCorriente }, "pagar");
        }

        private static decimal Efectivo(Periodo p)
        {
            return PorNombre(p, TipoEstado.BG, new[] { Clasif.ActivoCorriente },
                "efectivo", "caja", "banco");
        }

     
        private static decimal PorNombre(Periodo p, TipoEstado tipo, string[] clasificaciones,
                                         params string[] claves)
        {
            if (p == null || claves == null || claves.Length == 0) return 0m;

            decimal total = 0m;

            foreach (Cuenta cuenta in p.Cuentas.Where(c => c.Tipo == tipo))
            {
                bool coincideClasificacion = clasificaciones == null || clasificaciones.Length == 0;

                if (!coincideClasificacion)
                {
                    foreach (string clasificacion in clasificaciones)
                    {
                        if (Util.Igual(cuenta.Clasificacion, clasificacion))
                        {
                            coincideClasificacion = true;
                            break;
                        }
                    }
                }

                if (!coincideClasificacion) continue;

                string nombre = Util.Clave(cuenta.Nombre);
                bool coincideNombre = false;

                foreach (string clave in claves)
                {
                    if (nombre.Contains(Util.Clave(clave)))
                    {
                        coincideNombre = true;
                        break;
                    }
                }

                if (coincideNombre) total += cuenta.Monto;
            }

            return total;
        }
    }
}
