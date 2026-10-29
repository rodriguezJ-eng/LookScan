using System;
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
            foreach (var kv in Calculos.DuPont(p))
            {
                bool clave = kv.Key.StartsWith("1)") || kv.Key.StartsWith("2)") || kv.Key.StartsWith("3)") || kv.Key.StartsWith("ROE =");
                UtilUI.AgregarFila(dgvDupont, clave, kv.Key, kv.Value);
            }
        }
    }
}
