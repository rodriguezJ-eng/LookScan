using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace LookScan
{
    public partial class ExportarControl : UserControl
    {
        public ExportarControl()
        {
            InitializeComponent();
            if (Util.EnDiseno) return;

            btnDescargarJson.Click += (s, e) => ExportarJson();
            btnExportarExcel.Click += (s, e) => ExportarExcel();
            btnExportarPdf.Click += (s, e) => ExportarPdf();
            btnExportarHtml.Click += (s, e) => ExportarHtml();
        }

        private DocumentoInforme GenerarDocumento()
        {
            return GeneradorInforme.Generar();
        }

        private void ExportarJson()
        {
            using (var dialogo = new SaveFileDialog())
            {
                dialogo.Title = "Exportar datos completos a JSON";
                dialogo.Filter = "Archivo JSON (*.json)|*.json";
                dialogo.FileName = NombreArchivo("LookScan") + ".json";
                dialogo.AddExtension = true;
                dialogo.OverwritePrompt = true;

                if (dialogo.ShowDialog() != DialogResult.OK) return;

                try
                {
                    Exportador.GuardarJson(GenerarDocumento(), dialogo.FileName);
                    UtilUI.Aviso("Datos exportados en:\n" + dialogo.FileName);
                }
                catch (Exception ex)
                {
                    Error("No se pudo exportar el JSON", ex);
                }
            }
        }

        private void ExportarExcel()
        {
            using (var dialogo = new SaveFileDialog())
            {
                dialogo.Title = "Exportar datos completos a Excel";
                dialogo.Filter = "Libro de Excel (*.xls)|*.xls";
                dialogo.FileName = NombreArchivo("LookScan") + ".xls";
                dialogo.AddExtension = true;
                dialogo.OverwritePrompt = true;

                if (dialogo.ShowDialog() != DialogResult.OK) return;

                try
                {
                    Exportador.GuardarExcel(GenerarDocumento(), dialogo.FileName);
                    UtilUI.Aviso("Libro de Excel exportado en:\n" + dialogo.FileName);
                }
                catch (Exception ex)
                {
                    Error("No se pudo exportar a Excel", ex);
                }
            }
        }

        private void ExportarPdf()
        {
            try
            {
                Exportador.Imprimir(GenerarDocumento());
            }
            catch (Exception ex)
            {
                Error("No se pudo generar el PDF", ex);
            }
        }

        private void ExportarHtml()
        {
            using (var dialogo = new SaveFileDialog())
            {
                dialogo.Title = "Exportar informe a HTML";
                dialogo.Filter = "Página HTML (*.html)|*.html";
                dialogo.FileName = NombreArchivo("Informe LookScan") + ".html";
                dialogo.AddExtension = true;
                dialogo.OverwritePrompt = true;

                if (dialogo.ShowDialog() != DialogResult.OK) return;

                try
                {
                    Exportador.GuardarHtml(GenerarDocumento(), dialogo.FileName);
                    UtilUI.Aviso("Informe HTML generado en:\n" + dialogo.FileName);

                    try
                    {
                        Process.Start(dialogo.FileName);
                    }
                    catch
                    {
                        // Si no hay un navegador asociado, el archivo queda guardado.
                    }
                }
                catch (Exception ex)
                {
                    Error("No se pudo exportar el HTML", ex);
                }
            }
        }

        private static void Error(string mensaje, Exception ex)
        {
            MessageBox.Show(mensaje + ": " + ex.Message,
                "LookScan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private static string NombreArchivo(string baseNombre)
        {
            string empresa = string.IsNullOrWhiteSpace(Almacen.Empresa)
                ? string.Empty
                : " " + Almacen.Empresa.Trim();

            foreach (char invalido in System.IO.Path.GetInvalidFileNameChars())
                empresa = empresa.Replace(invalido, ' ');

            return (baseNombre + empresa).Trim();
        }
    }
}
