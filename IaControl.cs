using System;
using System.Windows.Forms;

namespace LookScan
{
    public partial class IaControl : UserControl
    {
        public IaControl()
        {
            InitializeComponent();
            if (Util.EnDiseno) return;

            btnPrepararResumen.Click += (s, e) => ActualizarResumen();
            btnGenerarInterpretacion.Click += (s, e) => ActualizarInterpretacion();

            Almacen.PeriodosCambiaron += ActualizarTodo;
            Almacen.ActivoCambio += ActualizarTodo;
            Almacen.DatosCambiaron += ActualizarTodo;

            ActualizarTodo();
        }

        private void ActualizarTodo()
        {
            ActualizarResumen();
            ActualizarInterpretacion();
        }

        private void ActualizarResumen()
        {
            UtilUI.MostrarTextoEstructurado(txtResumenIa, MotorIa.ResumenDatos(Almacen.Activo));
        }

        private void ActualizarInterpretacion()
        {
            UtilUI.MostrarTextoEstructurado(txtInterpretacion, MotorIa.InterpretacionPeriodo(Almacen.Activo));
        }

        private void pnlBody_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
