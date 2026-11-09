using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
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
            Almacen.PeriodosCambiaron += LlenarPeriodo;
            Almacen.ActivoCambio += LlenarPeriodo;
            Almacen.DatosCambiaron += Recalcular;

            LlenarPeriodo();
            Recalcular();
        }

        void LlenarPeriodo()
        {
            UtilUI.LlenarCombo(cmbPeriodoDupont, Almacen.Nombres, true, true);

            if (Almacen.Activo != null &&
                Almacen.Nombres.Any(n => Util.Igual(n, Almacen.Activo.Nombre)))
            {
                cmbPeriodoDupont.SelectedItem = Almacen.Activo.Nombre;
            }
        }

        void Recalcular()
        {
            dgvDupont.Rows.Clear();
            var p = Almacen.Buscar(cmbPeriodoDupont.SelectedItem as string);
            if (p == null || !p.TieneDatos) return;

            decimal ventas = Calculos.Ventas(p);
            decimal activo = Calculos.ActivoTotal(p);
            decimal patrimonio = Calculos.Patrimonio(p);
            decimal utilidadNeta = Calculos.UtilidadNeta(p);

            decimal? margen = ventas != 0m ? (decimal?)(utilidadNeta / ventas) : null;
            decimal? rotacion = activo != 0m ? (decimal?)(ventas / activo) : null;
            decimal? multiplicador = patrimonio > 0m ? (decimal?)(activo / patrimonio) : null;
            decimal? roe = margen.HasValue && rotacion.HasValue && multiplicador.HasValue
                ? (decimal?)(margen.Value * rotacion.Value * multiplicador.Value)
                : null;

            foreach (var kv in Calculos.DuPont(p))
            {
                bool clave = kv.Key.StartsWith("1") || kv.Key.StartsWith("2") ||
                             kv.Key.StartsWith("3") || kv.Key.StartsWith("ROE =");

                string interpretacion = Interpretar(kv.Key, margen, rotacion, multiplicador, roe, patrimonio);
                int index = dgvDupont.Rows.Add(kv.Key, kv.Value, interpretacion);

                if (clave)
                {
                    dgvDupont.Rows[index].DefaultCellStyle.Font = new Font(dgvDupont.Font, FontStyle.Bold);
                }
            }
        }

        static string Interpretar(string clave, decimal? margen, decimal? rotacion,
                                  decimal? multiplicador, decimal? roe, decimal patrimonio)
        {
            string k = (clave ?? string.Empty).ToLower();

            if (k.Contains("margen"))
            {
                if (!margen.HasValue) return "No calculable: las ventas son cero.";
                if (margen.Value < 0m)
                    return $"Pérdida neta ({margen.Value:P1}): los costos y gastos superan las ventas.";
                if (margen.Value < 0.05m)
                    return $"Margen neto bajo ({margen.Value:P1}): queda poco de cada venta como utilidad.";
                if (margen.Value < 0.15m)
                    return $"Margen neto moderado ({margen.Value:P1}): retención razonable de utilidades.";
                return $"Margen neto alto ({margen.Value:P1}): buen control de costos y retención de utilidades.";
            }

            if (k.Contains("rotación") || k.Contains("rotacion"))
            {
                if (!rotacion.HasValue) return "No calculable: el activo total es cero.";
                if (rotacion.Value < 0.5m)
                    return $"Rotación baja ({rotacion.Value:N2}x): los activos generan ventas lentamente.";
                if (rotacion.Value < 1m)
                    return $"Rotación moderada-baja ({rotacion.Value:N2}x): uso parcial de los activos.";
                if (rotacion.Value < 2m)
                    return $"Rotación adecuada ({rotacion.Value:N2}x): los activos acompañan el nivel de ventas.";
                return $"Rotación alta ({rotacion.Value:N2}x): uso intensivo de los activos para generar ventas.";
            }

            if (k.Contains("multiplicador"))
            {
                if (!multiplicador.HasValue)
                    return "No interpretable: el patrimonio es negativo o cero; la empresa está descapitalizada.";
                if (multiplicador.Value < 1.5m)
                    return $"Apalancamiento bajo ({multiplicador.Value:N2}x): mayor participación del patrimonio.";
                if (multiplicador.Value < 2.5m)
                    return $"Apalancamiento moderado ({multiplicador.Value:N2}x): equilibrio entre deuda y patrimonio.";
                return $"Apalancamiento alto ({multiplicador.Value:N2}x): mayor dependencia de financiamiento externo.";
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
                    return $"Rentabilidad negativa ({roe.Value:P1}): destrucción de valor para el accionista.";
                if (roe.Value < 0.05m)
                    return $"Rentabilidad baja ({roe.Value:P1}): rendimiento reducido sobre el patrimonio.";
                if (roe.Value < 0.15m)
                    return $"Rentabilidad moderada ({roe.Value:P1}): rendimiento razonable sobre el patrimonio.";
                return $"Rentabilidad alta ({roe.Value:P1}): atractivo para el accionista.";
            }

            return string.Empty;
        }
    }
}
