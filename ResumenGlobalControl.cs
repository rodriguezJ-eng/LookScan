using System;
using System.Windows.Forms;

namespace LookScan
{
    public partial class ResumenGlobalControl : UserControl
    {
        public ResumenGlobalControl()
        {
            InitializeComponent();
            if (Util.EnDiseno) return;

            btnGenerarResumenGlobal.Click += (s, e) => Generar();

            Almacen.PeriodosCambiaron += Generar;
            Almacen.DatosCambiaron += Generar;
            Almacen.ActivoCambio += Generar;

            Generar();
        }

        private void Generar()
        {
            txtResumenGlobal.Text = MotorIa.ResumenGlobal();
        }
    }
}
