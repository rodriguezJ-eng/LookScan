using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LookScan
{
    // Exportación sin dependencias externas:
    //  - TXT y JSON con escritura directa.
    //  - HTML con tablas y estilos.
    //  - Excel en formato SpreadsheetML (.xls), una hoja por sección.
    //  - PDF mediante la impresora «Microsoft Print to PDF».
    public static class Exportador
    {
        // Texto plano 

        public static string Texto(DocumentoInforme documento)
        {
            var sb = new StringBuilder();
            if (documento == null) return string.Empty;

            sb.AppendLine(documento.Titulo);
            sb.AppendLine("Empresa: " + documento.Empresa);
            sb.AppendLine("Generado: " + documento.Generado);
            if (!string.IsNullOrEmpty(documento.PeriodoActivo))
                sb.AppendLine("Periodo activo: " + documento.PeriodoActivo);
            sb.AppendLine();

            foreach (SeccionInforme seccion in documento.Secciones)
            {
                sb.AppendLine(new string('=', 78));
                sb.AppendLine(seccion.Titulo);
                sb.AppendLine(new string('=', 78));

                foreach (string nota in seccion.Notas)
                    sb.AppendLine(nota);

                if (seccion.Notas.Count > 0) sb.AppendLine();

                foreach (TablaInforme tabla in seccion.Tablas)
                {
                    sb.AppendLine("— " + tabla.Titulo);
                    sb.AppendLine(string.Join("\t", tabla.Columnas));

                    foreach (FilaInforme fila in tabla.Filas)
                    {
                        if (fila.Encabezado)
                        {
                            sb.AppendLine(fila.Celdas.Count > 0 ? fila.Celdas[0].Texto : string.Empty);
                            continue;
                        }

                        sb.AppendLine(string.Join("\t", fila.Celdas.Select(c => c.Texto)));
                    }

                    sb.AppendLine();
                }
            }

            return sb.ToString();
        }

        public static void GuardarTexto(DocumentoInforme documento, string ruta)
        {
            File.WriteAllText(ruta, Texto(documento), new UTF8Encoding(true));
        }

        // JSON 

        public static string Json(DocumentoInforme documento)
        {
            var sb = new StringBuilder();
            if (documento == null) return "{}";

            sb.Append("{");
            sb.Append("\"titulo\":").Append(JsonTexto(documento.Titulo)).Append(",");
            sb.Append("\"empresa\":").Append(JsonTexto(documento.Empresa)).Append(",");
            sb.Append("\"generado\":").Append(JsonTexto(documento.Generado)).Append(",");
            sb.Append("\"periodoActivo\":").Append(JsonTexto(documento.PeriodoActivo)).Append(",");
            sb.Append("\"secciones\":[");

            for (int s = 0; s < documento.Secciones.Count; s++)
            {
                SeccionInforme seccion = documento.Secciones[s];
                if (s > 0) sb.Append(",");

                sb.Append("{");
                sb.Append("\"titulo\":").Append(JsonTexto(seccion.Titulo)).Append(",");

                sb.Append("\"notas\":[");
                for (int n = 0; n < seccion.Notas.Count; n++)
                {
                    if (n > 0) sb.Append(",");
                    sb.Append(JsonTexto(seccion.Notas[n]));
                }
                sb.Append("],");

                sb.Append("\"tablas\":[");
                for (int t = 0; t < seccion.Tablas.Count; t++)
                {
                    TablaInforme tabla = seccion.Tablas[t];
                    if (t > 0) sb.Append(",");

                    sb.Append("{");
                    sb.Append("\"titulo\":").Append(JsonTexto(tabla.Titulo)).Append(",");

                    sb.Append("\"columnas\":[");
                    for (int c = 0; c < tabla.Columnas.Count; c++)
                    {
                        if (c > 0) sb.Append(",");
                        sb.Append(JsonTexto(tabla.Columnas[c]));
                    }
                    sb.Append("],");

                    sb.Append("\"filas\":[");
                    for (int f = 0; f < tabla.Filas.Count; f++)
                    {
                        FilaInforme fila = tabla.Filas[f];
                        if (f > 0) sb.Append(",");

                        sb.Append("{");
                        sb.Append("\"total\":").Append(fila.Total ? "true" : "false").Append(",");
                        sb.Append("\"encabezado\":").Append(fila.Encabezado ? "true" : "false").Append(",");
                        sb.Append("\"celdas\":[");

                        for (int c = 0; c < fila.Celdas.Count; c++)
                        {
                            CeldaInforme celda = fila.Celdas[c];
                            if (c > 0) sb.Append(",");

                            sb.Append("{");
                            sb.Append("\"texto\":").Append(JsonTexto(celda.Texto)).Append(",");
                            sb.Append("\"numero\":").Append(celda.Numero.HasValue
                                ? celda.Numero.Value.ToString(CultureInfo.InvariantCulture)
                                : "null").Append(",");
                            sb.Append("\"formato\":").Append(JsonTexto(celda.Formato));
                            sb.Append("}");
                        }

                        sb.Append("]}");
                    }
                    sb.Append("]}");
                }
                sb.Append("]}");
            }

            sb.Append("]}");
            return sb.ToString();
        }

        public static void GuardarJson(DocumentoInforme documento, string ruta)
        {
            File.WriteAllText(ruta, Json(documento), new UTF8Encoding(true));
        }

        // HTML 

        public static string Html(DocumentoInforme documento)
        {
            var sb = new StringBuilder();
            if (documento == null) return string.Empty;

            sb.AppendLine("<!DOCTYPE html>");
            sb.AppendLine("<html lang=\"es\">");
            sb.AppendLine("<head>");
            sb.AppendLine("<meta charset=\"utf-8\" />");
            sb.AppendLine("<title>" + HtmlTexto(documento.Titulo) + "</title>");
            sb.AppendLine("<style>");
            sb.AppendLine("body { font-family: Segoe UI, Arial, sans-serif; margin: 32px; color: #202020; }");
            sb.AppendLine("h1 { color: #18488C; margin-bottom: 4px; }");
            sb.AppendLine(".meta { color: #666; margin-bottom: 24px; }");
            sb.AppendLine("h2 { color: #18488C; border-bottom: 2px solid #18488C; padding-bottom: 4px; margin-top: 36px; }");
            sb.AppendLine("h3 { color: #333; margin-bottom: 6px; }");
            sb.AppendLine("table { border-collapse: collapse; width: 100%; margin-bottom: 22px; font-size: 12px; }");
            sb.AppendLine("th { background: #18488C; color: #fff; text-align: left; padding: 6px 8px; }");
            sb.AppendLine("td { border-bottom: 1px solid #e2e2e2; padding: 5px 8px; vertical-align: top; }");
            sb.AppendLine("tr.total td { background: #E8EEF7; font-weight: bold; }");
            sb.AppendLine("tr.encabezado td { background: #F2F4F8; font-weight: bold; }");
            sb.AppendLine(".nota { background: #FFF8E1; border-left: 4px solid #E0A800; padding: 10px 12px; margin-bottom: 18px; }");
            sb.AppendLine(".grafico { page-break-inside: avoid; margin: 20px 0 30px; border: 1px solid #dce3ee; padding: 14px; border-radius: 6px; }");
            sb.AppendLine(".grafico svg { width: 100%; height: 270px; } .grafico text { font-family: Segoe UI, Arial; fill: #394150; font-size: 12px; }");
            sb.AppendLine("</style>");
            sb.AppendLine("</head>");
            sb.AppendLine("<body>");
            sb.AppendLine("<h1>" + HtmlTexto(documento.Titulo) + "</h1>");
            sb.AppendLine("<div class=\"meta\">Empresa: " + HtmlTexto(documento.Empresa) +
                          " · Generado: " + HtmlTexto(documento.Generado) +
                          (string.IsNullOrEmpty(documento.PeriodoActivo)
                              ? string.Empty
                              : " · Periodo activo: " + HtmlTexto(documento.PeriodoActivo)) +
                          "</div>");

            if (documento.Graficos.Count > 0)
            {
                sb.AppendLine("<h2>GRÁFICOS</h2>");
                foreach (GraficoInforme grafico in documento.Graficos)
                    sb.AppendLine(HtmlGrafico(grafico));
            }

            foreach (SeccionInforme seccion in documento.Secciones)
            {
                sb.AppendLine("<h2>" + HtmlTexto(seccion.Titulo) + "</h2>");

                foreach (string nota in seccion.Notas)
                    sb.AppendLine("<div class=\"nota\">" + HtmlTexto(nota) + "</div>");

                foreach (TablaInforme tabla in seccion.Tablas)
                {
                    sb.AppendLine("<h3>" + HtmlTexto(tabla.Titulo) + "</h3>");
                    sb.AppendLine("<table>");

                    sb.AppendLine("<thead><tr>");
                    foreach (string columna in tabla.Columnas)
                        sb.AppendLine("<th>" + HtmlTexto(columna) + "</th>");
                    sb.AppendLine("</tr></thead>");

                    sb.AppendLine("<tbody>");
                    foreach (FilaInforme fila in tabla.Filas)
                    {
                        string clase = fila.Total ? "total" : fila.Encabezado ? "encabezado" : string.Empty;
                        sb.AppendLine("<tr" + (clase.Length > 0 ? " class=\"" + clase + "\"" : string.Empty) + ">");

                        if (fila.Encabezado)
                        {
                            sb.AppendLine("<td colspan=\"" + Math.Max(1, tabla.Columnas.Count) + "\">" +
                                          HtmlTexto(fila.Celdas.Count > 0 ? fila.Celdas[0].Texto : string.Empty) +
                                          "</td>");
                        }
                        else
                        {
                            foreach (CeldaInforme celda in fila.Celdas)
                                sb.AppendLine("<td>" + HtmlTexto(celda.Texto) + "</td>");
                        }

                        sb.AppendLine("</tr>");
                    }
                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");
                }
            }

            sb.AppendLine("</body>");
            sb.AppendLine("</html>");
            return sb.ToString();
        }

        public static void GuardarHtml(DocumentoInforme documento, string ruta)
        {
            File.WriteAllText(ruta, Html(documento), new UTF8Encoding(true));
        }

        private static string HtmlGrafico(GraficoInforme grafico)
        {
            const int ancho = 900, alto = 270, izquierda = 155, arriba = 28, abajo = 42;
            var sb = new StringBuilder();
            decimal maximo = grafico.Puntos.SelectMany(p => p.Valores).Select(v => Math.Abs(v)).DefaultIfEmpty(1m).Max();
            if (maximo == 0m) maximo = 1m;
            int series = Math.Max(1, grafico.Series.Count);
            float espacio = (ancho - izquierda - 25f) / Math.Max(1, grafico.Puntos.Count);
            float anchoBarra = Math.Max(5f, Math.Min(28f, (espacio - 8f) / series));
            Color[] colores = { Color.FromArgb(41, 128, 185), Color.FromArgb(230, 126, 34), Color.FromArgb(39, 174, 96) };

            sb.Append("<div class=\"grafico\"><h3>").Append(HtmlTexto(grafico.Titulo)).Append("</h3><svg viewBox=\"0 0 ").Append(ancho).Append(" ").Append(alto).Append("\">");
            sb.Append("<line x1=\"").Append(izquierda).Append("\" y1=\"").Append(alto - abajo).Append("\" x2=\"").Append(ancho - 15).Append("\" y2=\"").Append(alto - abajo).Append("\" stroke=\"#9ba7b6\"/>");
            for (int i = 0; i < grafico.Puntos.Count; i++)
            {
                PuntoGraficoInforme punto = grafico.Puntos[i];
                float x = izquierda + i * espacio;
                for (int s = 0; s < punto.Valores.Count; s++)
                {
                    decimal valor = punto.Valores[s];
                    float h = (float)(Math.Abs(valor) / maximo * (alto - arriba - abajo));
                    float y = alto - abajo - h;
                    float bx = x + s * anchoBarra;
                    sb.Append("<rect x=\"").Append(bx.ToString(CultureInfo.InvariantCulture)).Append("\" y=\"").Append(y.ToString(CultureInfo.InvariantCulture)).Append("\" width=\"").Append(anchoBarra - 2).Append("\" height=\"").Append(h.ToString(CultureInfo.InvariantCulture)).Append("\" fill=\"#").Append(colores[s % colores.Length].ToArgb().ToString("X8").Substring(2)).Append("\"><title>").Append(HtmlTexto(punto.Etiqueta)).Append(": ").Append(valor.ToString("N2")).Append("</title></rect>");
                }
                sb.Append("<text x=\"").Append(x.ToString(CultureInfo.InvariantCulture)).Append("\" y=\"").Append(alto - 18).Append("\">").Append(HtmlTexto(punto.Etiqueta)).Append("</text>");
            }
            for (int s = 0; s < grafico.Series.Count; s++)
                sb.Append("<rect x=\"").Append(izquierda + s * 130).Append("\" y=\"5\" width=\"12\" height=\"12\" fill=\"#").Append(colores[s % colores.Length].ToArgb().ToString("X8").Substring(2)).Append("\"/><text x=\"").Append(izquierda + 18 + s * 130).Append("\" y=\"16\">").Append(HtmlTexto(grafico.Series[s])).Append("</text>");
            sb.Append("</svg></div>");
            return sb.ToString();
        }

        //  Excel SpreadsheetML 

        public static void GuardarExcel(DocumentoInforme documento, string ruta)
        {
            var sb = new StringBuilder();
            sb.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            sb.AppendLine("<?mso-application progid=\"Excel.Sheet\"?>");
            sb.AppendLine("<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"");
            sb.AppendLine(" xmlns:o=\"urn:schemas-microsoft-com:office:office\"");
            sb.AppendLine(" xmlns:x=\"urn:schemas-microsoft-com:office:excel\"");
            sb.AppendLine(" xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\">");

            sb.AppendLine("<Styles>");
            sb.AppendLine("<Style ss:ID=\"Default\" ss:Name=\"Normal\"><Alignment ss:Vertical=\"Bottom\"/>" +
                          "<Font ss:FontName=\"Calibri\" ss:Size=\"11\"/></Style>");
            sb.AppendLine("<Style ss:ID=\"Titulo\"><Font ss:Bold=\"1\" ss:Size=\"14\" ss:Color=\"#18488C\"/></Style>");
            sb.AppendLine("<Style ss:ID=\"Subtitulo\"><Font ss:Bold=\"1\" ss:Size=\"11\"/></Style>");
            sb.AppendLine("<Style ss:ID=\"Encabezado\"><Font ss:Bold=\"1\" ss:Color=\"#FFFFFF\"/>" +
                          "<Interior ss:Color=\"#18488C\" ss:Pattern=\"Solid\"/></Style>");
            sb.AppendLine("<Style ss:ID=\"Total\"><Font ss:Bold=\"1\"/><Interior ss:Color=\"#E8EEF7\" ss:Pattern=\"Solid\"/></Style>");
            sb.AppendLine("<Style ss:ID=\"Numero\"><NumberFormat ss:Format=\"#,##0.00\"/></Style>");
            sb.AppendLine("<Style ss:ID=\"Porcentaje\"><NumberFormat ss:Format=\"0.0%\"/></Style>");
            sb.AppendLine("<Style ss:ID=\"TotalNumero\"><Font ss:Bold=\"1\"/>" +
                          "<Interior ss:Color=\"#E8EEF7\" ss:Pattern=\"Solid\"/>" +
                          "<NumberFormat ss:Format=\"#,##0.00\"/></Style>");
            sb.AppendLine("<Style ss:ID=\"TotalPorcentaje\"><Font ss:Bold=\"1\"/>" +
                          "<Interior ss:Color=\"#E8EEF7\" ss:Pattern=\"Solid\"/>" +
                          "<NumberFormat ss:Format=\"0.0%\"/></Style>");
            sb.AppendLine("</Styles>");

            List<string> nombres = new List<string>();

            foreach (SeccionInforme seccion in documento.Secciones)
            {
                string nombre = NombreHoja(seccion.Titulo, nombres);
                sb.AppendLine("<Worksheet ss:Name=\"" + XmlTexto(nombre) + "\">");
                sb.AppendLine("<Table>");
                sb.AppendLine("<Column ss:Width=\"320\"/>");

                sb.AppendLine("<Row><Cell ss:StyleID=\"Titulo\"><Data ss:Type=\"String\">" +
                              XmlTexto(seccion.Titulo) + "</Data></Cell></Row>");

                foreach (string nota in seccion.Notas)
                {
                    sb.AppendLine("<Row><Cell><Data ss:Type=\"String\">" + XmlTexto(nota) +
                                  "</Data></Cell></Row>");
                }

                if (seccion.Notas.Count > 0)
                    sb.AppendLine("<Row/>");

                foreach (TablaInforme tabla in seccion.Tablas)
                {
                    sb.AppendLine("<Row><Cell ss:StyleID=\"Subtitulo\"><Data ss:Type=\"String\">" +
                                  XmlTexto(tabla.Titulo) + "</Data></Cell></Row>");

                    sb.AppendLine("<Row>");
                    foreach (string columna in tabla.Columnas)
                    {
                        sb.AppendLine("<Cell ss:StyleID=\"Encabezado\"><Data ss:Type=\"String\">" +
                                      XmlTexto(columna) + "</Data></Cell>");
                    }
                    sb.AppendLine("</Row>");

                    foreach (FilaInforme fila in tabla.Filas)
                    {
                        if (fila.Encabezado)
                        {
                            sb.AppendLine("<Row><Cell ss:StyleID=\"Total\"><Data ss:Type=\"String\">" +
                                          XmlTexto(fila.Celdas.Count > 0 ? fila.Celdas[0].Texto : string.Empty) +
                                          "</Data></Cell></Row>");
                            continue;
                        }

                        sb.AppendLine("<Row>");
                        foreach (CeldaInforme celda in fila.Celdas)
                            sb.AppendLine(CeldaExcel(celda, fila.Total));
                        sb.AppendLine("</Row>");
                    }

                    sb.AppendLine("<Row/>");
                }

                sb.AppendLine("</Table>");
                sb.AppendLine("<WorksheetOptions xmlns=\"urn:schemas-microsoft-com:office:excel\">" +
                              "<FreezePanes/><SplitHorizontal>2</SplitHorizontal><TopRowBottomPane>2</TopRowBottomPane>" +
                              "<ActivePane>2</ActivePane></WorksheetOptions>");
                sb.AppendLine("</Worksheet>");
            }

            foreach (GraficoInforme grafico in documento.Graficos)
            {
                string nombre = NombreHoja("Gráfico " + grafico.Titulo, nombres);
                sb.AppendLine("<Worksheet ss:Name=\"" + XmlTexto(nombre) + "\"><Table>");
                sb.AppendLine("<Row><Cell ss:StyleID=\"Titulo\"><Data ss:Type=\"String\">" + XmlTexto(grafico.Titulo) + "</Data></Cell></Row>");
                sb.AppendLine("<Row><Cell ss:StyleID=\"Encabezado\"><Data ss:Type=\"String\">Categoría</Data></Cell>");
                foreach (string serie in grafico.Series)
                    sb.AppendLine("<Cell ss:StyleID=\"Encabezado\"><Data ss:Type=\"String\">" + XmlTexto(serie) + "</Data></Cell>");
                sb.AppendLine("</Row>");
                foreach (PuntoGraficoInforme punto in grafico.Puntos)
                {
                    sb.AppendLine("<Row><Cell><Data ss:Type=\"String\">" + XmlTexto(punto.Etiqueta) + "</Data></Cell>");
                    foreach (decimal valor in punto.Valores)
                        sb.AppendLine("<Cell ss:StyleID=\"Numero\"><Data ss:Type=\"Number\">" + valor.ToString(CultureInfo.InvariantCulture) + "</Data></Cell>");
                    sb.AppendLine("</Row>");
                }
                sb.AppendLine("</Table></Worksheet>");
            }

            sb.AppendLine("</Workbook>");

            File.WriteAllText(ruta, sb.ToString(), new UTF8Encoding(false));
        }

        private static string CeldaExcel(CeldaInforme celda, bool total)
        {
            string estilo;

            if (celda.Numero.HasValue && Util.Igual(celda.Formato, "porcentaje"))
                estilo = total ? "TotalPorcentaje" : "Porcentaje";
            else if (celda.Numero.HasValue &&
                     (Util.Igual(celda.Formato, "monto") ||
                      (celda.Formato ?? string.Empty).StartsWith("numero", StringComparison.Ordinal)))
                estilo = total ? "TotalNumero" : "Numero";
            else
                estilo = total ? "Total" : "Default";

            if (celda.Numero.HasValue && estilo != (total ? "Total" : "Default"))
            {
                return "<Cell ss:StyleID=\"" + estilo + "\"><Data ss:Type=\"Number\">" +
                       celda.Numero.Value.ToString(CultureInfo.InvariantCulture) + "</Data></Cell>";
            }

            return "<Cell ss:StyleID=\"" + estilo + "\"><Data ss:Type=\"String\">" +
                   XmlTexto(celda.Texto) + "</Data></Cell>";
        }

        // Proforma a Excel 

        public static DocumentoInforme DocumentoProforma(ResultadoProforma resultado)
        {
            var documento = new DocumentoInforme
            {
                Titulo = "Proforma Financiera LookScan",
                Empresa = string.IsNullOrWhiteSpace(Almacen.Empresa) ? "(sin nombre)" : Almacen.Empresa.Trim(),
                Generado = DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                PeriodoActivo = resultado != null && resultado.Base != null ? resultado.Base.Nombre : string.Empty
            };

            SeccionInforme seccion = documento.AgregarSeccion("PROFORMA");

            if (resultado == null || resultado.Periodos.Count == 0)
            {
                seccion.AgregarNota("No hay una proyección generada.");
                return documento;
            }

            TablaInforme parametros = seccion.AgregarTabla("Parámetros de la proyección", "Parámetro", "Valor");
            parametros.AgregarFila("Periodo base", resultado.Base != null ? resultado.Base.Nombre : string.Empty);
            parametros.AgregarFila("Años proyectados", resultado.Anios.ToString());
            parametros.AgregarFila("Crecimiento anual de ventas", Util.Pct(resultado.Crecimiento));
            parametros.AgregarFila("Tasa de impuestos", Util.Pct(resultado.TasaImpuestos));
            parametros.AgregarFila("Utilidades retenidas", Util.Pct(resultado.Retencion));

            TablaInforme config = seccion.AgregarTabla(
                "Configuración de cuentas", "Cuenta", "Monto base", "Método", "% / Valor");

            foreach (FilaConfigProyeccion fila in resultado.Config)
            {
                config.AgregarFila(fila.Cuenta, CeldaInforme.Monto(fila.MontoBase),
                    fila.Metodo, fila.Valor);
            }

            for (int i = 0; i < resultado.Periodos.Count; i++)
            {
                Periodo p = resultado.Periodos[i];

                TablaInforme balance = seccion.AgregarTabla(
                    "Balance general proyectado — " + p.Nombre,
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

                TablaInforme er = seccion.AgregarTabla(
                    "Estado de resultados proyectado — " + p.Nombre,
                    "Cuenta", "Clasificación", "Monto");

                foreach (Cuenta cuenta in p.ER
                    .OrderBy(c => Clasif.Orden(c.Clasificacion))
                    .ThenBy(c => Util.Clave(c.Nombre)))
                {
                    er.AgregarFila(cuenta.Nombre, cuenta.Clasificacion, CeldaInforme.Monto(cuenta.Monto));
                }

                er.AgregarTotal("Utilidad neta", string.Empty, CeldaInforme.Monto(Calculos.UtilidadNeta(p)));

                if (i < resultado.Flujos.Count)
                {
                    TablaInforme fe = seccion.AgregarTabla(
                        "Flujo de efectivo proyectado — " + p.Nombre,
                        "Concepto", "Monto");

                    foreach (FilaEfe fila in resultado.Flujos[i].Filas)
                    {
                        if (fila.Encabezado)
                            fe.AgregarEncabezado(fila.Concepto);
                        else if (fila.Total)
                            fe.AgregarTotal(fila.Concepto, CeldaInforme.Monto(fila.Monto));
                        else
                            fe.AgregarFila(fila.Concepto, CeldaInforme.Monto(fila.Monto));
                    }
                }
            }

            return documento;
        }

        public static void GuardarProformaExcel(ResultadoProforma resultado, string ruta)
        {
            GuardarExcel(DocumentoProforma(resultado), ruta);
        }

        // PDF / impresión 

        public static void Imprimir(DocumentoInforme documento)
        {
            if (documento == null) return;

            using (var impresion = new PrintDocument())
            {
                impresion.DocumentName = documento.Titulo;
                impresion.DefaultPageSettings.Landscape = true;
                impresion.DefaultPageSettings.Margins = new Margins(50, 50, 50, 50);

                if (ImpresoraDisponible("Microsoft Print to PDF"))
                    impresion.PrinterSettings.PrinterName = "Microsoft Print to PDF";

                var lineas = ConstruirLineas(documento);
                int indice = 0;
                int indiceGrafico = 0;
                bool imprimiendoGraficos = false;
                var fuenteNormal = new Font("Consolas", 8.5f);
                var fuenteNegrita = new Font("Consolas", 8.5f, FontStyle.Bold);
                var fuenteTitulo = new Font("Consolas", 11f, FontStyle.Bold);
                float altoLinea = fuenteNormal.GetHeight() + 1f;

                impresion.PrintPage += delegate(object sender, PrintPageEventArgs e)
                {
                    if (imprimiendoGraficos)
                    {
                        DibujarGraficoImpresion(e.Graphics, documento.Graficos[indiceGrafico], e.MarginBounds);
                        indiceGrafico++;
                        e.HasMorePages = indiceGrafico < documento.Graficos.Count;
                        return;
                    }

                    float x = e.MarginBounds.Left;
                    float y = e.MarginBounds.Top;
                    float ancho = e.MarginBounds.Width;
                    float alto = e.MarginBounds.Height;

                    while (indice < lineas.Count)
                    {
                        LineaImpresion linea = lineas[indice];

                        if (y + altoLinea > e.MarginBounds.Top + alto)
                        {
                            e.HasMorePages = true;
                            return;
                        }

                        Font fuente = linea.Titulo ? fuenteTitulo : linea.Negrita ? fuenteNegrita : fuenteNormal;

                        if (linea.Separador)
                        {
                            using (var pluma = new Pen(Color.FromArgb(180, 180, 180)))
                                e.Graphics.DrawLine(pluma, x, y + altoLinea / 2f, x + ancho, y + altoLinea / 2f);
                        }
                        else if (linea.Texto.Length > 0)
                        {
                            e.Graphics.DrawString(linea.Texto, fuente, Brushes.Black, x, y);
                        }

                        y += altoLinea;
                        indice++;
                    }

                    // Tras las tablas se añaden los gráficos en páginas apaisadas.
                    if (indiceGrafico < documento.Graficos.Count)
                    {
                        imprimiendoGraficos = true;
                        e.HasMorePages = true;
                        return;
                    }

                    e.HasMorePages = false;
                };

                using (var dialogo = new PrintDialog())
                {
                    dialogo.Document = impresion;
                    dialogo.UseEXDialog = true;
                    dialogo.AllowSomePages = true;

                    if (dialogo.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            impresion.Print();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("No se pudo imprimir el informe: " + ex.Message,
                                "LookScan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
        }

        private static void DibujarGraficoImpresion(Graphics g, GraficoInforme grafico, Rectangle area)
        {
            using (var titulo = new Font("Segoe UI", 15f, FontStyle.Bold))
            using (var texto = new Font("Segoe UI", 8.5f))
            using (var eje = new Pen(Color.FromArgb(130, 145, 160)))
            using (var azul = new SolidBrush(Color.FromArgb(24, 72, 140)))
            {
                g.DrawString(grafico.Titulo, titulo, azul, area.Left, area.Top);
                int izquierda = area.Left + 150, abajo = area.Bottom - 65, arriba = area.Top + 55;
                g.DrawLine(eje, izquierda, abajo, area.Right - 20, abajo);
                decimal maximo = grafico.Puntos.SelectMany(p => p.Valores).Select(v => Math.Abs(v)).DefaultIfEmpty(1m).Max();
                if (maximo == 0m) maximo = 1m;
                float espacio = (area.Width - 180f) / Math.Max(1, grafico.Puntos.Count);
                Color[] colores = { Color.FromArgb(41, 128, 185), Color.FromArgb(230, 126, 34), Color.FromArgb(39, 174, 96) };
                for (int i = 0; i < grafico.Puntos.Count; i++)
                {
                    PuntoGraficoInforme punto = grafico.Puntos[i];
                    float x = izquierda + i * espacio;
                    for (int s = 0; s < punto.Valores.Count; s++)
                    {
                        float h = (float)(Math.Abs(punto.Valores[s]) / maximo * (abajo - arriba));
                        using (var brocha = new SolidBrush(colores[s % colores.Length]))
                            g.FillRectangle(brocha, x + s * 24, abajo - h, 20, h);
                    }
                    g.DrawString(punto.Etiqueta, texto, Brushes.Black, x, abajo + 8);
                }
                for (int s = 0; s < grafico.Series.Count; s++)
                {
                    using (var brocha = new SolidBrush(colores[s % colores.Length])) g.FillRectangle(brocha, izquierda + s * 145, area.Top + 32, 12, 12);
                    g.DrawString(grafico.Series[s], texto, Brushes.Black, izquierda + 17 + s * 145, area.Top + 30);
                }
            }
        }

        private static bool ImpresoraDisponible(string nombre)
        {
            try
            {
                foreach (string instalada in PrinterSettings.InstalledPrinters)
                {
                    if (Util.Igual(instalada, nombre)) return true;
                }
            }
            catch
            {
                // Si no se puede consultar la lista, se usa el diálogo normal.
            }

            return false;
        }

        private class LineaImpresion
        {
            public string Texto { get; set; }
            public bool Negrita { get; set; }
            public bool Titulo { get; set; }
            public bool Separador { get; set; }
        }

        private static List<LineaImpresion> ConstruirLineas(DocumentoInforme documento)
        {
            var lineas = new List<LineaImpresion>();

            lineas.Add(new LineaImpresion { Texto = documento.Titulo, Titulo = true });
            lineas.Add(new LineaImpresion { Texto = "Empresa: " + documento.Empresa });
            lineas.Add(new LineaImpresion { Texto = "Generado: " + documento.Generado });

            if (!string.IsNullOrEmpty(documento.PeriodoActivo))
                lineas.Add(new LineaImpresion { Texto = "Periodo activo: " + documento.PeriodoActivo });

            lineas.Add(new LineaImpresion { Separador = true });

            foreach (SeccionInforme seccion in documento.Secciones)
            {
                lineas.Add(new LineaImpresion { Texto = seccion.Titulo, Titulo = true });

                foreach (string nota in seccion.Notas)
                    AgregarTextoEnvuelto(lineas, nota, false);

                foreach (TablaInforme tabla in seccion.Tablas)
                {
                    lineas.Add(new LineaImpresion { Texto = "— " + tabla.Titulo, Negrita = true });
                    AgregarTablaImpresion(lineas, tabla);
                    lineas.Add(new LineaImpresion { Texto = string.Empty });
                }

                lineas.Add(new LineaImpresion { Separador = true });
            }

            return lineas;
        }

        private static void AgregarTablaImpresion(List<LineaImpresion> lineas, TablaInforme tabla)
        {
            if (tabla.Columnas.Count == 0) return;

            const int anchoMaximo = 150;
            int columnas = tabla.Columnas.Count;
            int[] anchos = new int[columnas];

            for (int c = 0; c < columnas; c++)
                anchos[c] = Math.Max(4, Math.Min(32, tabla.Columnas[c].Length));

            foreach (FilaInforme fila in tabla.Filas)
            {
                for (int c = 0; c < columnas && c < fila.Celdas.Count; c++)
                    anchos[c] = Math.Max(anchos[c], Math.Min(32, fila.Celdas[c].Texto.Length));
            }

            int total = anchos.Sum() + (columnas - 1) * 2;
            if (total > anchoMaximo)
            {
                double factor = (double)(anchoMaximo - (columnas - 1) * 2) / anchos.Sum();
                for (int c = 0; c < columnas; c++)
                    anchos[c] = Math.Max(4, (int)Math.Floor(anchos[c] * factor));
            }

            lineas.Add(new LineaImpresion
            {
                Texto = FormatearFila(tabla.Columnas.ToArray(), anchos),
                Negrita = true
            });

            foreach (FilaInforme fila in tabla.Filas)
            {
                if (fila.Encabezado)
                {
                    lineas.Add(new LineaImpresion
                    {
                        Texto = fila.Celdas.Count > 0 ? fila.Celdas[0].Texto : string.Empty,
                        Negrita = true
                    });
                    continue;
                }

                string[] valores = new string[columnas];
                for (int c = 0; c < columnas; c++)
                    valores[c] = c < fila.Celdas.Count ? fila.Celdas[c].Texto : string.Empty;

                lineas.Add(new LineaImpresion
                {
                    Texto = FormatearFila(valores, anchos),
                    Negrita = fila.Total
                });
            }
        }

        private static string FormatearFila(string[] valores, int[] anchos)
        {
            var sb = new StringBuilder();

            for (int c = 0; c < anchos.Length; c++)
            {
                if (c > 0) sb.Append("  ");
                string valor = c < valores.Length ? (valores[c] ?? string.Empty) : string.Empty;

                if (valor.Length > anchos[c])
                    valor = valor.Substring(0, Math.Max(0, anchos[c] - 1)) + "…";

                sb.Append(valor.PadRight(anchos[c]));
            }

            return sb.ToString();
        }

        private static void AgregarTextoEnvuelto(List<LineaImpresion> lineas, string texto, bool negrita)
        {
            const int ancho = 150;
            texto = texto ?? string.Empty;

            while (texto.Length > ancho)
            {
                int corte = texto.LastIndexOf(' ', ancho);
                if (corte <= 0) corte = ancho;

                lineas.Add(new LineaImpresion { Texto = texto.Substring(0, corte), Negrita = negrita });
                texto = texto.Substring(corte).TrimStart();
            }

            lineas.Add(new LineaImpresion { Texto = texto, Negrita = negrita });
        }

        // Auxiliares de formato 

        private static string JsonTexto(string texto)
        {
            if (texto == null) return "null";

            var sb = new StringBuilder();
            sb.Append('"');

            foreach (char c in texto)
            {
                switch (c)
                {
                    case '"': sb.Append("\\\""); break;
                    case '\\': sb.Append("\\\\"); break;
                    case '\b': sb.Append("\\b"); break;
                    case '\f': sb.Append("\\f"); break;
                    case '\n': sb.Append("\\n"); break;
                    case '\r': sb.Append("\\r"); break;
                    case '\t': sb.Append("\\t"); break;
                    default:
                        if (c < 32)
                            sb.Append("\\u").Append(((int)c).ToString("x4"));
                        else
                            sb.Append(c);
                        break;
                }
            }

            sb.Append('"');
            return sb.ToString();
        }

        private static string HtmlTexto(string texto)
        {
            if (texto == null) return string.Empty;

            return texto
                .Replace("&", "&amp;")
                .Replace("<", "&lt;")
                .Replace(">", "&gt;")
                .Replace("\"", "&quot;");
        }

        private static string XmlTexto(string texto)
        {
            if (texto == null) return string.Empty;

            return texto
                .Replace("&", "&amp;")
                .Replace("<", "&lt;")
                .Replace(">", "&gt;")
                .Replace("\"", "&quot;")
                .Replace("'", "&apos;");
        }

        private static string NombreHoja(string titulo, List<string> usados)
        {
            string nombre = string.IsNullOrWhiteSpace(titulo) ? "Hoja" : titulo.Trim();

            foreach (char invalido in new[] { '[', ']', ':', '*', '?', '/', '\\' })
                nombre = nombre.Replace(invalido, ' ');

            if (nombre.Length > 31) nombre = nombre.Substring(0, 31);

            string baseNombre = nombre;
            int contador = 2;

            while (usados.Any(u => Util.Igual(u, nombre)))
            {
                string sufijo = " (" + contador + ")";
                int largo = Math.Min(baseNombre.Length, 31 - sufijo.Length);
                nombre = baseNombre.Substring(0, largo) + sufijo;
                contador++;
            }

            usados.Add(nombre);
            return nombre;
        }
    }
}
