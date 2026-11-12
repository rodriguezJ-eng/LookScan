using System;
using System.Windows.Forms;

namespace LookScan
{
    public partial class ReportesControl : UserControl
    {
        private DocumentoInforme _documento;

        public ReportesControl()
        {
            InitializeComponent();
            if (Util.EnDiseno) return;

            btnDescargarTxt.Click += (s, e) => DescargarTexto();
            btnDescargarJsonRep.Click += (s, e) => DescargarJson();

            Almacen.PeriodosCambiaron += ActualizarReporte;
            Almacen.DatosCambiaron += ActualizarReporte;
            Almacen.ActivoCambio += ActualizarReporte;
            Almacen.EmpresaCambio += ActualizarReporte;

            ActualizarReporte();
        }

        private void ActualizarReporte()
        {
            _documento = GeneradorInforme.Generar();
            UtilUI.MostrarTextoEstructurado(txtReporte, Exportador.Texto(_documento));
        }

        private void DescargarTexto()
        {
            if (!Almacen.HayDatos)
            {
                MessageBox.Show("No se puede descargar el informe porque no hay datos disponibles. Use 'Cargar Demo' en la pestaña Datos.", "LookScan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (_documento == null) ActualizarReporte();

            using (var dialogo = new SaveFileDialog())
            {
                dialogo.Title = "Guardar resumen del informe";
                dialogo.Filter = "Archivo de texto (*.txt)|*.txt";
                dialogo.FileName = NombreArchivo("Informe LookScan") + ".txt";
                dialogo.AddExtension = true;
                dialogo.OverwritePrompt = true;

                if (dialogo.ShowDialog() != DialogResult.OK) return;

                try
                {
                    Exportador.GuardarTexto(_documento, dialogo.FileName);
                    UtilUI.Aviso("Resumen guardado en:\n" + dialogo.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar el resumen: " + ex.Message,
                        "LookScan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void DescargarJson()
        {
            if (!Almacen.HayDatos)
            {
                MessageBox.Show("No se pueden descargar los datos porque no hay datos disponibles. Use 'Cargar Demo' en la pestaña Datos.", "LookScan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (_documento == null) ActualizarReporte();

            using (var dialogo = new SaveFileDialog())
            {
                dialogo.Title = "Guardar datos del informe";
                dialogo.Filter = "Archivo JSON (*.json)|*.json";
                dialogo.FileName = NombreArchivo("Datos LookScan") + ".json";
                dialogo.AddExtension = true;
                dialogo.OverwritePrompt = true;

                if (dialogo.ShowDialog() != DialogResult.OK) return;

                try
                {
                    Exportador.GuardarJson(_documento, dialogo.FileName);
                    UtilUI.Aviso("Datos guardados en:\n" + dialogo.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudieron guardar los datos: " + ex.Message,
                        "LookScan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
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
