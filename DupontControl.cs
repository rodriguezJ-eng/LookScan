using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace LookScan
{
    public partial class DupontControl : UserControl
    {
        public DupontControl()
        {
            InitializeComponent();
            if (Util.EnDiseno) return;

            cmbPeriodoDupont.SelectedIndexChanged += (s, e) => Recalcular();
            UtilUI.AlinearDerecha(dgvDupont, 1);
            Almacen.PeriodosCambiaron += () => UtilUI.LlenarCombo(cmbPeriodoDupont, Almacen.Nombres, true);
            Almacen.DatosCambiaron += Recalcular;

            UtilUI.LlenarCombo(cmbPeriodoDupont, Almacen.Nombres, true, false);
            Recalcular();
        }

        void Recalcular()
        {
            dgvDupont.Rows.Clear();
            var p = Almacen.Buscar(cmbPeriodoDupont.SelectedItem as string);
            if (p == null || !p.TieneDatos) return;

            decimal margen = Calculos.UtilidadNeta(p) != 0 && Calculos.Ventas(p) != 0 ? Calculos.UtilidadNeta(p) / Calculos.Ventas(p) : 0m;
            decimal rotacion = Calculos.ActivoTotal(p) != 0 ? Calculos.Ventas(p) / Calculos.ActivoTotal(p) : 0m;
            decimal multiplicador = Calculos.Patrimonio(p) != 0 ? Calculos.ActivoTotal(p) / Calculos.Patrimonio(p) : 0m;
            decimal roe = margen * rotacion * multiplicador;

            foreach (var kv in Calculos.DuPont(p))
            {
                bool clave = kv.Key.StartsWith("1") || kv.Key.StartsWith("2") || kv.Key.StartsWith("3") || kv.Key.StartsWith("ROE =");

                string interpretacion = "";
                string kLower = kv.Key.ToLower();

                // Interpretaciones basadas en la realidad financiera de los datos
                if (kLower.Contains("margen"))
                {
                    if (margen <= 0) interpretacion = " Pérdida operativa; los costos superan los ingresos.";
                    else if (margen > 0.15m) interpretacion = "Excelente control de costos y retención de ganancias.";
                    else interpretacion = "Margen ajustado; requiere optimizar gastos.";
                }
                else if (kLower.Contains("rotación") || kLower.Contains("rotacion"))
                {
                    if (rotacion == 0) interpretacion = "Activos o ventas en cero; verifique el Balance General.";
                    else if (rotacion > 1.0m) interpretacion = "Uso eficiente de los activos para generar ventas.";
                    else interpretacion = "Rotación lenta; activos subutilizados.";
                }
                else if (kLower.Contains("multiplicador"))
                {
                    if (multiplicador <= 0) interpretacion = " Estructura patrimonial anómala o negativa.";
                    else if (multiplicador < 2.0m) interpretacion = "Apalancamiento financiero prudente y equilibrado.";
                    else interpretacion = "Alto endeudamiento; riesgo financiero elevado.";
                }
                else if (kLower.Contains("roe"))
                {
                    if (roe <= 0) interpretacion = " Rentabilidad negativa; destruccion de valor para el socio.";
                    else if (roe > 0.20m) interpretacion = "Rendimiento altamente atractivo para los accionistas.";
                    else interpretacion = "Rentabilidad moderada sobre el patrimonio.";
                }

               
                int index = dgvDupont.Rows.Add(kv.Key, kv.Value, interpretacion);

                if (clave)
                {
                    dgvDupont.Rows[index].DefaultCellStyle.Font = new Font(dgvDupont.Font, FontStyle.Bold);
                }
            }

        }
    }
}
