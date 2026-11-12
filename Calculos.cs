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

        // Totales del balance 

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

        // Totales del estado de resultados 

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

        // Análisis horizontal 

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

        // Análisis vertical 

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
            // Con patrimonio negativo el multiplicador y el ROE no son interpretables.
            decimal? multiplicador = patrimonio > 0m ? (decimal?)(activo / patrimonio) : null;

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

        // Razones financieras 

         public static IEnumerable<Razon> Razones(Periodo p)
         {
             var resultado = new List<Razon>();
             if (p == null) return resultado;

             decimal activoCorriente = ActivoCorriente(p);
             decimal pasivoCorriente = PasivoCorriente(p);
             decimal inventario = Inventario(p);
             decimal efectivo = Efectivo(p);
             decimal cuentasPorCobrar = CuentasPorCobrar(p);
             decimal cuentasPorPagar = CuentasPorPagarComerciales(p);
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
                 "Soles de deuda por cada sol de patrimonio. Se espera un valor moderado.",
                 true);

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
                 "Rentabilidad generada sobre el patrimonio de los accionistas.",
                 true);

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
        

        private static string GenerarInterpretacion(string nombre, decimal? valor,
                                                     decimal numerador, decimal denominador)
        {
            if (!valor.HasValue)
            {
                switch (nombre)
                {
                    case "Deuda sobre patrimonio":
                    case "ROE":
                        return "No interpretable: el patrimonio es cero o negativo; la empresa está descapitalizada y el indicador no refleja la realidad del accionista.";
                    case "Cobertura de intereses":
                        return "No calculable: no hay gastos financieros registrados en el periodo.";
                    case "Periodo promedio de cobro":
                        return "No calculable: no hay ventas registradas en el periodo.";
                    case "Periodo promedio de pago":
                        return "No calculable: no hay costo de ventas registrado en el periodo.";
                    case "Rotación de inventarios":
                        return "No calculable: no hay inventario registrado en el periodo.";
                    default:
                        return "No calculable: el denominador del indicador es cero.";
                }
            }

            decimal v = valor.Value;

            switch (nombre)
            {
                // --- LIQUIDEZ ---
                case "Razón corriente":
                    if (v < 1m) return $"Alerta: con {v:N2}x los pasivos corrientes superan a los activos corrientes; existe riesgo de iliquidez de corto plazo.";
                    if (v <= 2m) return $"Saludable: con {v:N2}x la empresa cubre adecuadamente sus obligaciones de corto plazo.";
                    return $"Precaución: {v:N2}x muestra buena liquidez, pero podría indicar activos corrientes ociosos.";

                case "Prueba ácida":
                    if (v < 1m) return $"Riesgo: con {v:N2}x la empresa no cubriría sus deudas inmediatas sin depender de los inventarios.";
                    return $"Adecuada: con {v:N2}x la empresa cubre sus obligaciones inmediatas sin vender inventarios.";

                case "Prueba defensiva":
                    if (v < 0.2m) return $"Baja cobertura: con {v:N2}x el efectivo disponible es reducido frente a las deudas inmediatas.";
                    if (v < 1m) return $"Cobertura parcial: con {v:N2}x el efectivo cubre solo una parte de los compromisos inmediatos.";
                    return $"Sólida: con {v:N2}x el efectivo cubre los compromisos inmediatos.";

                // --- ACTIVIDAD ---
                case "Rotación de inventarios":
                    if (v < 4m) return $"Rotación baja ({v:N2} veces): el inventario permanece mucho tiempo en la empresa.";
                    if (v < 12m) return $"Rotación moderada ({v:N2} veces): el inventario se renueva con una frecuencia razonable.";
                    return $"Rotación alta ({v:N2} veces): el inventario se renueva rápidamente durante el periodo.";

                case "Periodo promedio de cobro":
                    if (v < 30m) return $"Cobro ágil: la empresa recupera sus cuentas por cobrar en aproximadamente {v:N0} días.";
                    if (v < 60m) return $"Cobro adecuado: el periodo promedio de cobro es de {v:N0} días.";
                    if (v < 90m) return $"Cobro moderado: la empresa tarda cerca de {v:N0} días en recuperar sus cuentas por cobrar.";
                    return $"Cobro prolongado: el periodo promedio de cobro alcanza {v:N0} días y conviene revisar la política de crédito.";

                case "Periodo promedio de pago":
                    if (v < 30m) return $"Pago rápido: la empresa liquida sus obligaciones comerciales en aproximadamente {v:N0} días.";
                    if (v < 60m) return $"Pago adecuado: el periodo promedio de pago es de {v:N0} días.";
                    if (v < 90m) return $"Pago amplio: la empresa tarda cerca de {v:N0} días en pagar a sus proveedores.";
                    return $"Pago muy prolongado: el periodo promedio de pago alcanza {v:N0} días; conviene evaluar el costo financiero implícito.";

                case "Rotación de activos":
                    if (v < 0.5m) return $"Rotación baja ({v:N2}x): los activos generan ventas lentamente.";
                    if (v < 1m) return $"Rotación moderada-baja ({v:N2}x): los activos participan parcialmente en la generación de ventas.";
                    if (v < 2m) return $"Rotación adecuada ({v:N2}x): el nivel de ventas guarda relación con los activos.";
                    return $"Rotación alta ({v:N2}x): se obtiene un uso intensivo de los activos para generar ventas.";

                // --- ENDEUDAMIENTO ---
                case "Deuda sobre activo":
                    if (v < 0m) return "No interpretable: el pasivo o el activo presentan valores negativos.";
                    if (v > 1m) return $"Riesgo alto: el {v * 100:N1}% de los activos está financiado con deuda y los pasivos superan al activo total.";
                    if (v > 0.6m) return $"Endeudamiento alto: el {v * 100:N1}% de los activos se financia con acreedores externos.";
                    if (v > 0.4m) return $"Endeudamiento moderado: el {v * 100:N1}% de los activos se financia con deuda.";
                    return $"Endeudamiento bajo: solo el {v * 100:N1}% de los activos se financia con deuda.";

                case "Deuda sobre patrimonio":
                    if (v < 1m) return $"Apalancamiento bajo: {v:N2}x de deuda por cada sol de patrimonio.";
                    if (v < 2m) return $"Apalancamiento moderado: {v:N2}x de deuda por cada sol de patrimonio.";
                    if (v < 3m) return $"Apalancamiento alto: {v:N2}x de deuda por cada sol de patrimonio.";
                    return $"Apalancamiento muy alto: {v:N2}x de deuda por cada sol de patrimonio; el riesgo financiero es elevado.";

                case "Cobertura de intereses":
                    if (v < 0m) return $"Sin cobertura: la utilidad operativa es negativa y no alcanza a cubrir los gastos financieros ({v:N2}x).";
                    if (v < 1m) return $"Alerta crítica: la utilidad operativa no cubre los gastos financieros ({v:N2}x).";
                    if (v < 3m) return $"Cobertura ajustada: la utilidad operativa cubre {v:N2} veces los gastos financieros.";
                    return $"Cobertura holgada: la utilidad operativa cubre {v:N2} veces los gastos financieros.";

                // --- RENTABILIDAD ---
                case "Margen bruto":
                    if (v < 0m) return $"Pérdida bruta ({v * 100:N1}%): el costo de ventas supera a las ventas.";
                    if (v < 0.15m) return $"Margen bruto bajo ({v * 100:N1}%): queda poco después del costo de ventas.";
                    if (v < 0.3m) return $"Margen bruto moderado ({v * 100:N1}%): retención razonable después del costo de ventas.";
                    return $"Margen bruto alto ({v * 100:N1}%): buen control del costo de ventas.";

                case "Margen operativo":
                    if (v < 0m) return $"Pérdida operativa ({v * 100:N1}%): los gastos operativos superan la utilidad bruta.";
                    if (v < 0.05m) return $"Margen operativo bajo ({v * 100:N1}%): la operación deja poco margen antes de intereses e impuestos.";
                    if (v < 0.15m) return $"Margen operativo moderado ({v * 100:N1}%): la operación retiene una porción razonable de las ventas.";
                    return $"Margen operativo alto ({v * 100:N1}%): eficiencia operativa favorable.";

                case "Margen neto":
                    if (v < 0m) return $"Pérdida neta ({v * 100:N1}%): los costos, gastos e impuestos superan las ventas.";
                    if (v < 0.05m) return $"Margen neto bajo ({v * 100:N1}%): queda poco de cada venta como utilidad neta.";
                    if (v < 0.15m) return $"Margen neto moderado ({v * 100:N1}%): retención razonable de utilidades.";
                    return $"Margen neto alto ({v * 100:N1}%): buen control de costos y retención de utilidades.";

                case "ROA":
                    if (v < 0m) return $"Pérdida sobre activos ({v * 100:N1}%): la utilidad neta es negativa respecto del activo total.";
                    if (v < 0.05m) return $"ROA bajo ({v * 100:N1}%): la utilidad generada sobre los activos es reducida.";
                    if (v < 0.1m) return $"ROA moderado ({v * 100:N1}%): rendimiento razonable sobre el activo total.";
                    return $"ROA alto ({v * 100:N1}%): buena capacidad de los activos para generar utilidad neta.";

                case "ROE":
                    if (v < 0m) return $"Rentabilidad negativa ({v * 100:N1}%): destrucción de valor para el accionista.";
                    if (v < 0.05m) return $"Rentabilidad baja ({v * 100:N1}%): rendimiento reducido sobre el patrimonio.";
                    if (v < 0.15m) return $"Rentabilidad moderada ({v * 100:N1}%): rendimiento razonable sobre el patrimonio.";
                    return $"Rentabilidad alta ({v * 100:N1}%): atractivo para el accionista.";

                default:
                    return "Indicador financiero calculado para el periodo.";
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

        //  DuPont con interpretación 

        public static IEnumerable<Razon> DuPontRazones(Periodo p)
        {
            var resultado = new List<Razon>();
            if (p == null) return resultado;

            decimal ventas = Ventas(p);
            decimal activo = ActivoTotal(p);
            decimal patrimonio = Patrimonio(p);
            decimal utilidadNeta = UtilidadNeta(p);

            decimal? margen = ventas != 0m ? (decimal?)(utilidadNeta / ventas) : null;
            decimal? rotacion = activo != 0m ? (decimal?)(ventas / activo) : null;
            decimal? multiplicador = patrimonio > 0m ? (decimal?)(activo / patrimonio) : null;
            decimal? roe = margen.HasValue && rotacion.HasValue && multiplicador.HasValue
                ? (decimal?)(margen.Value * rotacion.Value * multiplicador.Value)
                : null;

            resultado.Add(new Razon
            {
                Nombre = "1) Margen neto (UN / Ventas)",
                Grupo = "DuPont",
                ValorTexto = Util.Pct(margen),
                Interpretacion = InterpretarDuPont("margen", margen, rotacion, multiplicador, roe, patrimonio)
            });

            resultado.Add(new Razon
            {
                Nombre = "2) Rotación de activos (Ventas / Activo total)",
                Grupo = "DuPont",
                ValorTexto = rotacion.HasValue ? Util.Numero(rotacion.Value, 2) + "x" : "N/D",
                Interpretacion = InterpretarDuPont("rotacion", margen, rotacion, multiplicador, roe, patrimonio)
            });

            resultado.Add(new Razon
            {
                Nombre = "3) Multiplicador de capital (Activo / Patrimonio)",
                Grupo = "DuPont",
                ValorTexto = multiplicador.HasValue ? Util.Numero(multiplicador.Value, 2) + "x" : "N/D",
                Interpretacion = InterpretarDuPont("multiplicador", margen, rotacion, multiplicador, roe, patrimonio)
            });

            resultado.Add(new Razon
            {
                Nombre = "ROE = 1 × 2 × 3",
                Grupo = "DuPont",
                ValorTexto = Util.Pct(roe),
                Interpretacion = InterpretarDuPont("roe", margen, rotacion, multiplicador, roe, patrimonio)
            });

            return resultado;
        }

        private static string InterpretarDuPont(string clave, decimal? margen, decimal? rotacion,
                                                decimal? multiplicador, decimal? roe, decimal patrimonio)
        {
            string k = (clave ?? string.Empty).ToLowerInvariant();

            if (k.Contains("margen"))
            {
                if (!margen.HasValue) return "No calculable: las ventas son cero.";
                if (margen.Value < 0m)
                    return "Pérdida neta (" + Util.Pct(margen) + "): los costos y gastos superan las ventas.";
                if (margen.Value < 0.05m)
                    return "Margen neto bajo (" + Util.Pct(margen) + "): queda poco de cada venta como utilidad.";
                if (margen.Value < 0.15m)
                    return "Margen neto moderado (" + Util.Pct(margen) + "): retención razonable de utilidades.";
                return "Margen neto alto (" + Util.Pct(margen) + "): buen control de costos y retención de utilidades.";
            }

            if (k.Contains("rotacion"))
            {
                if (!rotacion.HasValue) return "No calculable: el activo total es cero.";
                if (rotacion.Value < 0.5m)
                    return "Rotación baja (" + Util.Numero(rotacion.Value, 2) + "x): los activos generan ventas lentamente.";
                if (rotacion.Value < 1m)
                    return "Rotación moderada-baja (" + Util.Numero(rotacion.Value, 2) + "x): uso parcial de los activos.";
                if (rotacion.Value < 2m)
                    return "Rotación adecuada (" + Util.Numero(rotacion.Value, 2) + "x): los activos acompañan el nivel de ventas.";
                return "Rotación alta (" + Util.Numero(rotacion.Value, 2) + "x): uso intensivo de los activos para generar ventas.";
            }

            if (k.Contains("multiplicador"))
            {
                if (!multiplicador.HasValue)
                    return "No interpretable: el patrimonio es negativo o cero; la empresa está descapitalizada.";
                if (multiplicador.Value < 1.5m)
                    return "Apalancamiento bajo (" + Util.Numero(multiplicador.Value, 2) + "x): mayor participación del patrimonio.";
                if (multiplicador.Value < 2.5m)
                    return "Apalancamiento moderado (" + Util.Numero(multiplicador.Value, 2) + "x): equilibrio entre deuda y patrimonio.";
                return "Apalancamiento alto (" + Util.Numero(multiplicador.Value, 2) + "x): mayor dependencia de financiamiento externo.";
            }

            if (k.Contains("roe"))
            {
                if (!roe.HasValue)
                {
                    return patrimonio <= 0m
                        ? "No interpretable: el patrimonio es negativo o cero; el ROE no refleja la rentabilidad del accionista."
                        : "No calculable: faltan datos para el ROE.";
                }

                if (roe.Value < 0m)
                    return "Rentabilidad negativa (" + Util.Pct(roe) + "): destrucción de valor para el accionista.";
                if (roe.Value < 0.05m)
                    return "Rentabilidad baja (" + Util.Pct(roe) + "): rendimiento reducido sobre el patrimonio.";
                if (roe.Value < 0.15m)
                    return "Rentabilidad moderada (" + Util.Pct(roe) + "): rendimiento razonable sobre el patrimonio.";
                return "Rentabilidad alta (" + Util.Pct(roe) + "): atractivo para el accionista.";
            }

            return string.Empty;
        }

        // ── Estado de origen y aplicación de fondos ──────────────────────────

        public static ResultadoEoaf Eoaf(Periodo periodoBase, Periodo periodoComp)
        {
            var resultado = new ResultadoEoaf
            {
                PeriodoBase = periodoBase != null ? periodoBase.Nombre : string.Empty,
                PeriodoComparado = periodoComp != null ? periodoComp.Nombre : string.Empty
            };

            if (periodoBase == null || periodoComp == null) return resultado;

            var montosBase = new Dictionary<string, decimal>(StringComparer.Ordinal);
            var montosComp = new Dictionary<string, decimal>(StringComparer.Ordinal);
            var representantes = new Dictionary<string, Cuenta>(StringComparer.Ordinal);

            foreach (Cuenta cuenta in periodoBase.BG)
            {
                string clave = Util.Clave(cuenta.Nombre);
                if (clave.Length == 0) continue;

                if (!montosBase.ContainsKey(clave)) montosBase[clave] = 0m;
                montosBase[clave] += cuenta.Monto;

                if (!representantes.ContainsKey(clave)) representantes[clave] = cuenta;
            }

            foreach (Cuenta cuenta in periodoComp.BG)
            {
                string clave = Util.Clave(cuenta.Nombre);
                if (clave.Length == 0) continue;

                if (!montosComp.ContainsKey(clave)) montosComp[clave] = 0m;
                montosComp[clave] += cuenta.Monto;

                if (!representantes.ContainsKey(clave)) representantes[clave] = cuenta;
            }

            var claves = montosBase.Keys
                .Union(montosComp.Keys)
                .OrderBy(k => Clasif.Orden(representantes[k].Clasificacion))
                .ThenBy(k => k)
                .ToList();

            foreach (string clave in claves)
            {
                decimal monto1 = montosBase.ContainsKey(clave) ? montosBase[clave] : 0m;
                decimal monto2 = montosComp.ContainsKey(clave) ? montosComp[clave] : 0m;
                decimal cambio = monto2 - monto1;

                if (cambio == 0m) continue;

                Cuenta cuenta = representantes[clave];
                string clasificacion = cuenta.Clasificacion ?? string.Empty;

                decimal origen = 0m;
                decimal aplicacion = 0m;

                if (Clasif.EsActivo(clasificacion))
                {
                    if (cambio > 0m) aplicacion = cambio;
                    else origen = -cambio;
                }
                else if (Clasif.EsPasivo(clasificacion) || Clasif.EsPatrimonio(clasificacion))
                {
                    if (cambio > 0m) origen = cambio;
                    else aplicacion = -cambio;
                }

                resultado.TotalOrigen += origen;
                resultado.TotalAplicacion += aplicacion;

                resultado.Filas.Add(new FilaEoaf
                {
                    Cuenta = cuenta.Nombre,
                    Clasificacion = clasificacion,
                    MontoBase = monto1,
                    MontoComparado = monto2,
                    Cambio = cambio,
                    Origen = origen,
                    Aplicacion = aplicacion
                });
            }

            return resultado;
        }

        // ── Estado de flujo de efectivo ──────────────────────────────────────

        private class CambioCuenta
        {
            public Cuenta Cuenta { get; set; }
            public decimal Cambio { get; set; }
        }

        public static ResultadoEfe Efe(Periodo periodoBase, Periodo periodoComp, bool metodoIndirecto)
        {
            var resultado = new ResultadoEfe
            {
                PeriodoBase = periodoBase != null ? periodoBase.Nombre : string.Empty,
                PeriodoComparado = periodoComp != null ? periodoComp.Nombre : string.Empty,
                MetodoIndirecto = metodoIndirecto
            };

            if (periodoBase == null || periodoComp == null) return resultado;

            decimal efectivoInicial = EfectivoBalance(periodoBase);
            decimal efectivoFinal = EfectivoBalance(periodoComp);
            resultado.EfectivoInicial = efectivoInicial;
            resultado.EfectivoFinalBalance = efectivoFinal;

            var montosBase = new Dictionary<string, decimal>(StringComparer.Ordinal);
            var montosComp = new Dictionary<string, decimal>(StringComparer.Ordinal);
            var representantes = new Dictionary<string, Cuenta>(StringComparer.Ordinal);

            foreach (Cuenta cuenta in periodoBase.BG)
            {
                string clave = Util.Clave(cuenta.Nombre);
                if (clave.Length == 0) continue;

                if (!montosBase.ContainsKey(clave)) montosBase[clave] = 0m;
                montosBase[clave] += cuenta.Monto;

                if (!representantes.ContainsKey(clave)) representantes[clave] = cuenta;
            }

            foreach (Cuenta cuenta in periodoComp.BG)
            {
                string clave = Util.Clave(cuenta.Nombre);
                if (clave.Length == 0) continue;

                if (!montosComp.ContainsKey(clave)) montosComp[clave] = 0m;
                montosComp[clave] += cuenta.Monto;

                if (!representantes.ContainsKey(clave)) representantes[clave] = cuenta;
            }

            var claves = montosBase.Keys
                .Union(montosComp.Keys)
                .OrderBy(k => Clasif.Orden(representantes[k].Clasificacion))
                .ThenBy(k => k)
                .ToList();

            var cambiosOperacion = new List<CambioCuenta>();
            var cambiosInversion = new List<CambioCuenta>();
            var cambiosFinanciacion = new List<CambioCuenta>();
            decimal ajusteNoMonetario = 0m;

            foreach (string clave in claves)
            {
                decimal montoBase = montosBase.ContainsKey(clave) ? montosBase[clave] : 0m;
                decimal montoComp = montosComp.ContainsKey(clave) ? montosComp[clave] : 0m;
                decimal cambio = montoComp - montoBase;

                if (cambio == 0m) continue;

                Cuenta cuenta = representantes[clave];
                var categoria = Clasif.ClasificadorEfe.ObtenerCategoria(cuenta);

                if (categoria == Clasif.ClasificadorEfe.CategoriaEfe.Efectivo) continue;

                if (categoria == Clasif.ClasificadorEfe.CategoriaEfe.NoAfecta)
                {
                    string n = Util.Clave(cuenta.Nombre);
                    bool esResultadoAcumulado = n.Contains("deficit acumulado") ||
                                                n.Contains("resultados acumulados") ||
                                                n.Contains("utilidades retenidas") ||
                                                n.Contains("perdidas acumuladas");

                    if (!esResultadoAcumulado) ajusteNoMonetario += cambio;
                    continue;
                }

                var item = new CambioCuenta { Cuenta = cuenta, Cambio = cambio };

                if (categoria == Clasif.ClasificadorEfe.CategoriaEfe.Operacion)
                    cambiosOperacion.Add(item);
                else if (categoria == Clasif.ClasificadorEfe.CategoriaEfe.Inversion)
                    cambiosInversion.Add(item);
                else if (categoria == Clasif.ClasificadorEfe.CategoriaEfe.Financiacion)
                    cambiosFinanciacion.Add(item);
            }

            decimal utilidadNeta = UtilidadNeta(periodoComp);
            decimal ajustesOperacion = 0m;

            foreach (var item in cambiosOperacion)
            {
                bool esActivo = Clasif.EsActivo(item.Cuenta.Clasificacion);
                ajustesOperacion += esActivo ? -item.Cambio : item.Cambio;
            }

            decimal flujoOperacionIndirecto = utilidadNeta + ajustesOperacion + ajusteNoMonetario;
            decimal flujoInversion = cambiosInversion.Sum(x => -x.Cambio);
            decimal flujoFinanciamiento = cambiosFinanciacion.Sum(x => x.Cambio);
            decimal flujoOperacionDirecto = 0m;

            if (metodoIndirecto)
            {
                AgregarEfe(resultado,
                    "FLUJOS DE EFECTIVO DE LAS ACTIVIDADES DE OPERACIÓN (MÉTODO INDIRECTO)",
                    0m, false, true);
                AgregarEfe(resultado, "Utilidad neta del ejercicio", utilidadNeta);

                foreach (var item in cambiosOperacion)
                {
                    bool esActivo = Clasif.EsActivo(item.Cuenta.Clasificacion);
                    decimal efecto = esActivo ? -item.Cambio : item.Cambio;
                    string etiqueta = EtiquetaOperacion(item.Cuenta, item.Cambio, esActivo);
                    AgregarEfe(resultado, etiqueta, efecto);
                }

                if (ajusteNoMonetario != 0m)
                    AgregarEfe(resultado, "(+/-) Ajuste no monetario (revaluaciones y otros)", ajusteNoMonetario);

                AgregarEfe(resultado,
                    "EFECTIVO NETO PROVISTO POR ACTIVIDADES DE OPERACIÓN",
                    flujoOperacionIndirecto, true);
            }
            else
            {
                AgregarEfe(resultado,
                    "FLUJOS DE EFECTIVO DE LAS ACTIVIDADES DE OPERACIÓN (MÉTODO DIRECTO)",
                    0m, false, true);

                decimal ventas = Ventas(periodoComp);
                decimal costoVentas = CostoVentas(periodoComp);
                decimal gastosOperativos = GastosOperativos(periodoComp);
                decimal gastosFinancieros = GastosFinancieros(periodoComp);
                decimal otrosIngresos = OtrosIngresos(periodoComp);
                decimal impuestos = Impuestos(periodoComp);

                decimal varCxC = 0m;
                decimal varInventario = 0m;
                decimal varGastoAnticipado = 0m;
                decimal varCxPComercial = 0m;
                decimal varGastoAcumulado = 0m;
                decimal varIntereses = 0m;
                decimal varOtros = 0m;

                foreach (var item in cambiosOperacion)
                {
                    Cuenta cuenta = item.Cuenta;
                    decimal cambio = item.Cambio;

                    if (Clasif.ClasificadorEfe.EsCxC(cuenta)) varCxC += cambio;
                    else if (Clasif.ClasificadorEfe.EsInventario(cuenta)) varInventario += cambio;
                    else if (Clasif.ClasificadorEfe.EsGastoAnticipado(cuenta)) varGastoAnticipado += cambio;
                    else if (Clasif.ClasificadorEfe.EsGastoAcumulado(cuenta)) varGastoAcumulado += cambio;
                    else if (Clasif.ClasificadorEfe.EsInteresPorPagar(cuenta)) varIntereses += cambio;
                    else if (Clasif.ClasificadorEfe.EsCxPComercial(cuenta)) varCxPComercial += cambio;
                    else varOtros += Clasif.EsActivo(cuenta.Clasificacion) ? -cambio : cambio;
                }

                decimal cobrosClientes = ventas - varCxC;
                decimal pagosProveedores = -(costoVentas + varInventario - varCxPComercial);
                decimal pagosGastosOperativos = -(gastosOperativos - varGastoAcumulado);
                decimal pagoIntereses = -(gastosFinancieros - varIntereses);
                decimal otrosMovimientos = -varGastoAnticipado + varOtros;

                flujoOperacionDirecto = cobrosClientes + pagosProveedores + pagosGastosOperativos +
                                        otrosIngresos - impuestos + pagoIntereses +
                                        otrosMovimientos + ajusteNoMonetario;

                AgregarEfe(resultado, "(+) Cobros procedentes de clientes", cobrosClientes);
                AgregarEfe(resultado, "(-) Pagos a proveedores y costos", pagosProveedores);
                AgregarEfe(resultado, "(-) Pagos por gastos operativos", pagosGastosOperativos);

                if (otrosIngresos != 0m)
                    AgregarEfe(resultado, "(+) Otros ingresos operativos", otrosIngresos);

                if (impuestos != 0m)
                    AgregarEfe(resultado, "(-) Pago de impuestos", -impuestos);

                if (gastosFinancieros != 0m || varIntereses != 0m)
                    AgregarEfe(resultado, "(-) Pago de intereses", pagoIntereses);

                if (otrosMovimientos != 0m)
                    AgregarEfe(resultado, "(+/-) Otros movimientos operativos", otrosMovimientos);

                if (ajusteNoMonetario != 0m)
                    AgregarEfe(resultado, "(+/-) Ajuste no monetario (revaluaciones y otros)", ajusteNoMonetario);

                AgregarEfe(resultado,
                    "EFECTIVO NETO PROVISTO POR ACTIVIDADES DE OPERACIÓN",
                    flujoOperacionDirecto, true);
            }

            AgregarEfe(resultado, "FLUJOS DE EFECTIVO DE LAS ACTIVIDADES DE INVERSIÓN", 0m, false, true);

            foreach (var item in cambiosInversion)
            {
                string etiqueta = item.Cambio > 0m
                    ? "(-) Aumento / adquisición de " + item.Cuenta.Nombre
                    : "(+) Disminución / venta de " + item.Cuenta.Nombre;

                AgregarEfe(resultado, etiqueta, -item.Cambio);
            }

            AgregarEfe(resultado,
                "EFECTIVO NETO USADO EN ACTIVIDADES DE INVERSIÓN",
                flujoInversion, true);

            AgregarEfe(resultado, "FLUJOS DE EFECTIVO DE LAS ACTIVIDADES DE FINANCIACIÓN", 0m, false, true);

            foreach (var item in cambiosFinanciacion)
            {
                string etiqueta = item.Cambio > 0m
                    ? "(+) Incremento / obtención de " + item.Cuenta.Nombre
                    : "(-) Amortización / disminución de " + item.Cuenta.Nombre;

                AgregarEfe(resultado, etiqueta, item.Cambio);
            }

            AgregarEfe(resultado,
                "EFECTIVO NETO USADO EN ACTIVIDADES DE FINANCIACIÓN",
                flujoFinanciamiento, true);

            decimal flujoOperacion = metodoIndirecto ? flujoOperacionIndirecto : flujoOperacionDirecto;
            decimal incrementoNeto = flujoOperacion + flujoInversion + flujoFinanciamiento;
            decimal efectivoCalculado = efectivoInicial + incrementoNeto;
            resultado.EfectivoCalculado = efectivoCalculado;

            AgregarEfe(resultado, "INCREMENTO NETO DE EFECTIVO Y EQUIVALENTES", incrementoNeto, true);
            AgregarEfe(resultado, "(+) Efectivo y equivalentes al inicio del período", efectivoInicial);
            AgregarEfe(resultado, "(=) EFECTIVO Y EQUIVALENTES AL FINAL DEL PERÍODO", efectivoCalculado, true);
            AgregarEfe(resultado, "Efectivo final según el balance", efectivoFinal);
            AgregarEfe(resultado, "Diferencia (calculado - balance)", efectivoCalculado - efectivoFinal, true);

            return resultado;
        }

        private static void AgregarEfe(ResultadoEfe resultado, string concepto, decimal monto,
                                       bool total = false, bool encabezado = false)
        {
            resultado.Filas.Add(new FilaEfe
            {
                Concepto = concepto,
                Monto = monto,
                Total = total,
                Encabezado = encabezado
            });
        }

        private static decimal EfectivoBalance(Periodo periodo)
        {
            if (periodo == null) return 0m;

            decimal total = 0m;

            foreach (Cuenta cuenta in periodo.BG)
            {
                if (Clasif.ClasificadorEfe.ObtenerCategoria(cuenta) ==
                    Clasif.ClasificadorEfe.CategoriaEfe.Efectivo)
                {
                    total += cuenta.Monto;
                }
            }

            return total;
        }

        private static string EtiquetaOperacion(Cuenta cuenta, decimal cambio, bool esActivo)
        {
            if (esActivo)
            {
                return cambio > 0m
                    ? "(-) Aumento de " + cuenta.Nombre
                    : "(+) Disminución de " + cuenta.Nombre;
            }

            return cambio > 0m
                ? "(+) Aumento de " + cuenta.Nombre
                : "(-) Disminución de " + cuenta.Nombre;
        }

        // Auxiliares 

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

        private static void AgregarRazon(List<Razon> lista, string grupo, string nombre,
                                         decimal numerador, decimal denominador,
                                         FormatoRazon formato, string descripcionTeorica,
                                         bool requiereDenominadorPositivo = false)
        {
            decimal? valor = null;

            bool denominadorValido = denominador != 0m &&
                                     (!requiereDenominadorPositivo || denominador > 0m);

            if (denominadorValido)
            {
                decimal calculado = numerador / denominador;
                if (formato == FormatoRazon.Dias) calculado *= 365m;
                valor = calculado;
            }

            string interpretacionDinamica = GenerarInterpretacion(nombre, valor, numerador, denominador);

            string texto;
            if (!valor.HasValue)
            {
                texto = "N/D";
            }
            else if (formato == FormatoRazon.Porcentaje)
            {
                texto = Util.Numero(valor.Value * 100m, 2) + "%";
            }
            else if (formato == FormatoRazon.Veces)
            {
                texto = Util.Numero(valor.Value, 2) + "x";
            }
            else
            {
                texto = Util.Numero(valor.Value, 0) + " días";
            }

            lista.Add(new Razon
            {
                Nombre = nombre,
                Grupo = grupo,
                ValorTexto = texto,
                Interpretacion = interpretacionDinamica
            });
        }

        private static decimal Inventario(Periodo p)
        {
            return PorNombre(p, TipoEstado.BG, new[] { Clasif.ActivoCorriente }, "inventario");
        }

        private static decimal CuentasPorCobrar(Periodo p)
        {
            // Incluye cuentas por cobrar comerciales, CxC con instituciones y deudores.
            return PorNombre(p, TipoEstado.BG, new[] { Clasif.ActivoCorriente },
                "cobrar", "cxc", "cliente", "deudor");
        }

        private static decimal CuentasPorPagarComerciales(Periodo p)
        {
            if (p == null) return 0m;

            decimal total = 0m;

            foreach (Cuenta cuenta in p.Cuentas.Where(c => c.Tipo == TipoEstado.BG &&
                                                           Util.Igual(c.Clasificacion, Clasif.PasivoCorriente)))
            {
                string nombre = Util.Clave(cuenta.Nombre);

                bool esComercial = nombre.Contains("proveedor") ||
                                   nombre.Contains("acreedor") ||
                                   nombre.Contains("cuentas por pagar") ||
                                   nombre.Contains("por pagar a") ||
                                   nombre.Contains("gastos acumulados");

                // Se excluyen deuda financiera, intereses y obligaciones tributarias.
                bool excluir = nombre.Contains("prestamo") ||
                               nombre.Contains("interes") ||
                               nombre.Contains("financier") ||
                               nombre.Contains("impuesto") ||
                               nombre.Contains("tribut") ||
                               nombre.Contains("sunat") ||
                               nombre.Contains("estado");

                if (esComercial && !excluir) total += cuenta.Monto;
            }

            return total;
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
