using System;
using System.Collections.Generic;
using System.Linq;

namespace LookScan
{
    // Construye el documento completo que alimenta reportes y exportaciones.
    // El orden de las secciones es el acordado:
    // DATOS -> ANÁLISIS -> RAZONES -> EOAF -> EFE -> DuPont -> GRÁFICOS -> PROFORMA.
    public static class GeneradorInforme
    {
        public static DocumentoInforme Generar()
        {
            var documento = new DocumentoInforme
            {
                Titulo = "Informe Financiero LookScan",
                Empresa = string.IsNullOrWhiteSpace(Almacen.Empresa) ? "(sin nombre)" : Almacen.Empresa.Trim(),
                Generado = DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                PeriodoActivo = Almacen.Activo != null ? Almacen.Activo.Nombre : string.Empty
            };

            List<Periodo> periodos = MotorIa.PeriodosConDatos();

            AgregarDatos(documento, periodos);
            AgregarAnalisis(documento, periodos);
            AgregarRazones(documento, periodos);
            AgregarEoaf(documento, periodos);
            AgregarEfe(documento, periodos);
            AgregarDuPont(documento, periodos);
            AgregarGraficos(documento);
            AgregarProforma(documento, periodos);

            return documento;
        }

        //  DATOS 

        private static void AgregarDatos(DocumentoInforme documento, List<Periodo> periodos)
        {
            SeccionInforme seccion = documento.AgregarSeccion("DATOS");

            if (periodos.Count == 0)
            {
                seccion.AgregarNota("No hay periodos con datos registrados.");
                return;
            }

            foreach (Periodo p in periodos)
            {
                string sufijo = p.EsProforma ? " (proforma)" : string.Empty;

                TablaInforme balance = seccion.AgregarTabla(
                    "Balance general — " + p.Nombre + sufijo,
                    "Cuenta", "Clasificación", "Monto");

                foreach (Cuenta cuenta in p.BG
                    .OrderBy(c => Clasif.Orden(c.Clasificacion))
                    .ThenBy(c => Util.Clave(c.Nombre)))
                {
                    balance.AgregarFila(cuenta.Nombre, cuenta.Clasificacion, CeldaInforme.Monto(cuenta.Monto));
                }

                balance.AgregarTotal("Total activo", string.Empty,
                    CeldaInforme.Monto(Calculos.ActivoTotal(p)));
                balance.AgregarTotal("Total pasivo", string.Empty,
                    CeldaInforme.Monto(Calculos.PasivoTotal(p)));
                balance.AgregarTotal("Total patrimonio", string.Empty,
                    CeldaInforme.Monto(Calculos.Patrimonio(p)));
                balance.AgregarTotal("Total pasivo y patrimonio", string.Empty,
                    CeldaInforme.Monto(Calculos.PasivoYPatrimonio(p)));

                TablaInforme resultados = seccion.AgregarTabla(
                    "Estado de resultados — " + p.Nombre + sufijo,
                    "Cuenta", "Clasificación", "Monto");

                foreach (Cuenta cuenta in p.ER
                    .OrderBy(c => Clasif.Orden(c.Clasificacion))
                    .ThenBy(c => Util.Clave(c.Nombre)))
                {
                    resultados.AgregarFila(cuenta.Nombre, cuenta.Clasificacion, CeldaInforme.Monto(cuenta.Monto));
                }

                resultados.AgregarTotal("Total ventas", string.Empty,
                    CeldaInforme.Monto(Calculos.Ventas(p)));
                resultados.AgregarTotal("Utilidad bruta", string.Empty,
                    CeldaInforme.Monto(Calculos.UtilidadBruta(p)));
                resultados.AgregarTotal("Utilidad operativa", string.Empty,
                    CeldaInforme.Monto(Calculos.UtilidadOperativa(p)));
                resultados.AgregarTotal("Utilidad neta", string.Empty,
                    CeldaInforme.Monto(Calculos.UtilidadNeta(p)));
            }
        }

        //  ANÁLISIS 

        private static void AgregarAnalisis(DocumentoInforme documento, List<Periodo> periodos)
        {
            SeccionInforme seccion = documento.AgregarSeccion("ANÁLISIS");

            if (periodos.Count == 0)
            {
                seccion.AgregarNota("No hay datos para el análisis horizontal ni vertical.");
                return;
            }

            // Análisis vertical por periodo.
            foreach (Periodo p in periodos)
            {
                string sufijo = p.EsProforma ? " (proforma)" : string.Empty;

                TablaInforme bg = seccion.AgregarTabla(
                    "Análisis vertical del balance — " + p.Nombre + sufijo,
                    "Cuenta", "Clasificación", "Monto", "% del total");

                foreach (FilaVertical fila in Calculos.VerticalBG(p))
                {
                    if (fila.Total)
                        bg.AgregarTotal(fila.Cuenta, fila.Clasificacion,
                            CeldaInforme.Monto(fila.Monto), CeldaInforme.Porcentaje(fila.Pct));
                    else
                        bg.AgregarFila(fila.Cuenta, fila.Clasificacion,
                            CeldaInforme.Monto(fila.Monto), CeldaInforme.Porcentaje(fila.Pct));
                }

                TablaInforme er = seccion.AgregarTabla(
                    "Análisis vertical del estado de resultados — " + p.Nombre + sufijo,
                    "Cuenta", "Clasificación", "Monto", "% de ventas");

                foreach (FilaVertical fila in Calculos.VerticalER(p))
                {
                    if (fila.Total)
                        er.AgregarTotal(fila.Cuenta, fila.Clasificacion,
                            CeldaInforme.Monto(fila.Monto), CeldaInforme.Porcentaje(fila.Pct));
                    else
                        er.AgregarFila(fila.Cuenta, fila.Clasificacion,
                            CeldaInforme.Monto(fila.Monto), CeldaInforme.Porcentaje(fila.Pct));
                }
            }

            // Análisis horizontal entre periodos consecutivos.
            for (int i = 1; i < periodos.Count; i++)
            {
                Periodo baseP = periodos[i - 1];
                Periodo compP = periodos[i];

                TablaInforme bg = seccion.AgregarTabla(
                    "Análisis horizontal del balance — " + baseP.Nombre + " vs " + compP.Nombre,
                    "Cuenta", baseP.Nombre, compP.Nombre, "Variación", "% variación");

                foreach (FilaComparativa fila in Calculos.Horizontal(baseP, compP, TipoEstado.BG))
                {
                    if (fila.Total)
                        bg.AgregarTotal(fila.Cuenta,
                            CeldaInforme.Monto(fila.Base), CeldaInforme.Monto(fila.Comparado),
                            CeldaInforme.Monto(fila.Delta), CeldaInforme.Porcentaje(fila.Pct));
                    else
                        bg.AgregarFila(fila.Cuenta,
                            CeldaInforme.Monto(fila.Base), CeldaInforme.Monto(fila.Comparado),
                            CeldaInforme.Monto(fila.Delta), CeldaInforme.Porcentaje(fila.Pct));
                }

                TablaInforme er = seccion.AgregarTabla(
                    "Análisis horizontal del estado de resultados — " + baseP.Nombre + " vs " + compP.Nombre,
                    "Cuenta", baseP.Nombre, compP.Nombre, "Variación", "% variación");

                foreach (FilaComparativa fila in Calculos.Horizontal(baseP, compP, TipoEstado.ER))
                {
                    if (fila.Total)
                        er.AgregarTotal(fila.Cuenta,
                            CeldaInforme.Monto(fila.Base), CeldaInforme.Monto(fila.Comparado),
                            CeldaInforme.Monto(fila.Delta), CeldaInforme.Porcentaje(fila.Pct));
                    else
                        er.AgregarFila(fila.Cuenta,
                            CeldaInforme.Monto(fila.Base), CeldaInforme.Monto(fila.Comparado),
                            CeldaInforme.Monto(fila.Delta), CeldaInforme.Porcentaje(fila.Pct));
                }
            }
        }

        // RAZONES 

        private static void AgregarRazones(DocumentoInforme documento, List<Periodo> periodos)
        {
            SeccionInforme seccion = documento.AgregarSeccion("RAZONES");

            if (periodos.Count == 0)
            {
                seccion.AgregarNota("No hay datos para calcular razones financieras.");
                return;
            }

            foreach (Periodo p in periodos)
            {
                string sufijo = p.EsProforma ? " (proforma)" : string.Empty;

                TablaInforme tabla = seccion.AgregarTabla(
                    "Razones financieras — " + p.Nombre + sufijo,
                    "Grupo", "Razón", "Valor", "Interpretación");

                foreach (Razon razon in Calculos.Razones(p))
                {
                    tabla.AgregarFila(razon.Grupo, razon.Nombre, razon.ValorTexto, razon.Interpretacion);
                }
            }
        }

        //  EOAF 

        private static void AgregarEoaf(DocumentoInforme documento, List<Periodo> periodos)
        {
            SeccionInforme seccion = documento.AgregarSeccion("EOAF");

            if (periodos.Count < 2)
            {
                seccion.AgregarNota("Se requieren al menos dos periodos con datos para calcular el estado de origen y aplicación de fondos.");
                return;
            }

            for (int i = 1; i < periodos.Count; i++)
            {
                Periodo baseP = periodos[i - 1];
                Periodo compP = periodos[i];
                ResultadoEoaf resultado = Calculos.Eoaf(baseP, compP);

                TablaInforme tabla = seccion.AgregarTabla(
                    "Origen y aplicación de fondos — " + baseP.Nombre + " vs " + compP.Nombre,
                    "Cuenta", "Clasificación", baseP.Nombre, compP.Nombre, "Cambio", "Origen", "Aplicación");

                foreach (FilaEoaf fila in resultado.Filas)
                {
                    tabla.AgregarFila(fila.Cuenta, fila.Clasificacion,
                        CeldaInforme.Monto(fila.MontoBase), CeldaInforme.Monto(fila.MontoComparado),
                        CeldaInforme.Monto(fila.Cambio),
                        CeldaInforme.Monto(fila.Origen), CeldaInforme.Monto(fila.Aplicacion));
                }

                tabla.AgregarTotal("TOTALES", string.Empty, string.Empty, string.Empty, string.Empty,
                    CeldaInforme.Monto(resultado.TotalOrigen), CeldaInforme.Monto(resultado.TotalAplicacion));

                tabla.AgregarTotal("DIFERENCIA (Origen - Aplicación)", string.Empty, string.Empty,
                    string.Empty, string.Empty, CeldaInforme.Monto(resultado.Diferencia), string.Empty);
            }
        }

        //  EFE 

        private static void AgregarEfe(DocumentoInforme documento, List<Periodo> periodos)
        {
            SeccionInforme seccion = documento.AgregarSeccion("EFE");

            if (periodos.Count < 2)
            {
                seccion.AgregarNota("Se requieren al menos dos periodos con datos para calcular el estado de flujo de efectivo.");
                return;
            }

            for (int i = 1; i < periodos.Count; i++)
            {
                Periodo baseP = periodos[i - 1];
                Periodo compP = periodos[i];
                ResultadoEfe resultado = Calculos.Efe(baseP, compP, true);

                TablaInforme tabla = seccion.AgregarTabla(
                    "Estado de flujo de efectivo (método indirecto) — " + baseP.Nombre + " vs " + compP.Nombre,
                    "Concepto", "Monto");

                foreach (FilaEfe fila in resultado.Filas)
                {
                    if (fila.Encabezado)
                    {
                        tabla.AgregarEncabezado(fila.Concepto);
                    }
                    else if (fila.Total)
                    {
                        tabla.AgregarTotal(fila.Concepto, CeldaInforme.Monto(fila.Monto));
                    }
                    else
                    {
                        tabla.AgregarFila(fila.Concepto, CeldaInforme.Monto(fila.Monto));
                    }
                }
            }
        }

        //  DuPont 

        private static void AgregarDuPont(DocumentoInforme documento, List<Periodo> periodos)
        {
            SeccionInforme seccion = documento.AgregarSeccion("DuPont");

            if (periodos.Count == 0)
            {
                seccion.AgregarNota("No hay datos para el análisis DuPont.");
                return;
            }

            foreach (Periodo p in periodos)
            {
                string sufijo = p.EsProforma ? " (proforma)" : string.Empty;

                TablaInforme tabla = seccion.AgregarTabla(
                    "Análisis DuPont — " + p.Nombre + sufijo,
                    "Indicador", "Valor", "Interpretación");

                foreach (Razon razon in Calculos.DuPontRazones(p))
                {
                    tabla.AgregarFila(razon.Nombre, razon.ValorTexto, razon.Interpretacion);
                }
            }
        }

        // GRÁFICOS 

        private static void AgregarGraficos(DocumentoInforme documento)
        {
            SeccionInforme seccion = documento.AgregarSeccion("GRÁFICOS");
            List<Periodo> periodos = MotorIa.PeriodosConDatos();
            if (periodos.Count == 0)
            {
                seccion.AgregarNota("No hay datos registrados para generar gráficos.");
                return;
            }

            Periodo baseP = periodos.First();
            Periodo compP = periodos.Last();
            var resumen = documento.AgregarGrafico("Resumen financiero", baseP.Nombre, compP.Nombre);
            resumen.AgregarPunto("Activo corriente", Calculos.ActivoCorriente(baseP), Calculos.ActivoCorriente(compP));
            resumen.AgregarPunto("Pasivo corriente", Calculos.PasivoCorriente(baseP), Calculos.PasivoCorriente(compP));
            resumen.AgregarPunto("Ventas", Calculos.Ventas(baseP), Calculos.Ventas(compP));
            resumen.AgregarPunto("Utilidad neta", Calculos.UtilidadNeta(baseP), Calculos.UtilidadNeta(compP));

            var capital = documento.AgregarGrafico("Capital neto de trabajo", baseP.Nombre, compP.Nombre);
            capital.AgregarPunto("CNT", Calculos.ActivoCorriente(baseP) - Calculos.PasivoCorriente(baseP), Calculos.ActivoCorriente(compP) - Calculos.PasivoCorriente(compP));
            capital.AgregarPunto("CNO", Calculos.ActivoCorriente(baseP) - Calculos.PasivoCorriente(baseP), Calculos.ActivoCorriente(compP) - Calculos.PasivoCorriente(compP));

            ResultadoEfe efe = Calculos.Efe(baseP, compP, true);
            var flujo = documento.AgregarGrafico("Estado de flujo de efectivo", "Flujo");
            flujo.AgregarPunto("Operación", TotalEfe(efe, "EFECTIVO NETO PROVISTO POR ACTIVIDADES DE OPERACIÓN"));
            flujo.AgregarPunto("Inversión", TotalEfe(efe, "EFECTIVO NETO USADO EN ACTIVIDADES DE INVERSIÓN"));
            flujo.AgregarPunto("Financiación", TotalEfe(efe, "EFECTIVO NETO USADO EN ACTIVIDADES DE FINANCIACIÓN"));
            flujo.AgregarPunto("Flujo neto", TotalEfe(efe, "INCREMENTO NETO DE EFECTIVO Y EQUIVALENTES"));

            seccion.AgregarNota("Los gráficos y sus datos se incluyen en las exportaciones HTML y Excel.");
        }

        private static decimal TotalEfe(ResultadoEfe efe, string concepto)
        {
            FilaEfe fila = efe.Filas.FirstOrDefault(f => f.Total && f.Concepto.IndexOf(concepto, StringComparison.OrdinalIgnoreCase) >= 0);
            return fila == null ? 0m : fila.Monto;
        }

        // PROFORMA 

        private static void AgregarProforma(DocumentoInforme documento, List<Periodo> periodos)
        {
            SeccionInforme seccion = documento.AgregarSeccion("PROFORMA");

            List<Periodo> proformas = periodos.Where(p => p.EsProforma).ToList();

            if (proformas.Count == 0)
            {
                seccion.AgregarNota("No hay periodos proyectados guardados como proforma.");
                return;
            }

            foreach (Periodo p in proformas)
            {
                TablaInforme balance = seccion.AgregarTabla(
                    "Proforma — Balance general " + p.Nombre,
                    "Cuenta", "Clasificación", "Monto");

                foreach (Cuenta cuenta in p.BG
                    .OrderBy(c => Clasif.Orden(c.Clasificacion))
                    .ThenBy(c => Util.Clave(c.Nombre)))
                {
                    balance.AgregarFila(cuenta.Nombre, cuenta.Clasificacion, CeldaInforme.Monto(cuenta.Monto));
                }

                balance.AgregarTotal("Total activo", string.Empty,
                    CeldaInforme.Monto(Calculos.ActivoTotal(p)));
                balance.AgregarTotal("Total pasivo y patrimonio", string.Empty,
                    CeldaInforme.Monto(Calculos.PasivoYPatrimonio(p)));

                TablaInforme resultados = seccion.AgregarTabla(
                    "Proforma — Estado de resultados " + p.Nombre,
                    "Cuenta", "Clasificación", "Monto");

                foreach (Cuenta cuenta in p.ER
                    .OrderBy(c => Clasif.Orden(c.Clasificacion))
                    .ThenBy(c => Util.Clave(c.Nombre)))
                {
                    resultados.AgregarFila(cuenta.Nombre, cuenta.Clasificacion, CeldaInforme.Monto(cuenta.Monto));
                }

                resultados.AgregarTotal("Utilidad neta", string.Empty,
                    CeldaInforme.Monto(Calculos.UtilidadNeta(p)));
            }
        }
    }
}
