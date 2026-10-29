using System;
using System.Windows.Forms;

namespace LookScan
{
    public partial class AnalisisControl : UserControl
    {
        bool _ahCalculado;

        public AnalisisControl()
        {
            InitializeComponent();
            if (Util.EnDiseno) return;

            btnCalcularAH.Click += (s, e) => CalcularAH(true);
            UtilUI.AlinearDerecha(dgvBgAH, 1, 2, 3, 4);
            UtilUI.AlinearDerecha(dgvErAH, 1, 2, 3, 4);
            UtilUI.AlinearDerecha(dgvBgAV, 2);
            UtilUI.AlinearDerecha(dgvErAV, 2);

            Almacen.PeriodosCambiaron += () => LlenarPeriodos(false);
            Almacen.ActivoCambio += CalcularAV;
            Almacen.DatosCambiaron += () => { CalcularAV(); if (_ahCalculado) CalcularAH(false); };

            LlenarPeriodos(true);
            CalcularAV();
        }

        void LlenarPeriodos(bool inicial)
        {
            UtilUI.LlenarCombo(cmbPeriodoBaseAH, Almacen.Nombres, false, !inicial);
            UtilUI.LlenarCombo(cmbPeriodoCompAH, Almacen.Nombres, true, !inicial);
        }

        // ── Análisis horizontal (entre dos periodos) ──
        void CalcularAH(bool avisos)
        {
            var a = Almacen.Buscar(cmbPeriodoBaseAH.SelectedItem as string);
            var b = Almacen.Buscar(cmbPeriodoCompAH.SelectedItem as string);
            if (a == null || b == null) { if (avisos) UtilUI.Aviso("Seleccione el periodo base y el periodo comparado."); return; }
            if (avisos && ReferenceEquals(a, b)) { UtilUI.Aviso("Elija dos periodos distintos para comparar."); return; }
            if (avisos && (!a.TieneDatos || !b.TieneDatos))
            {
                UtilUI.Aviso("El periodo " + (!a.TieneDatos ? a.Nombre : b.Nombre) +
                             " no tiene cuentas. Capture datos en la pestaña Datos o use «Cargar Demo».");
                return;
            }

            dgvBgAH.Rows.Clear();
            dgvErAH.Rows.Clear();
            foreach (var f in Calculos.Horizontal(a, b, TipoEstado.BG)) Agregar(dgvBgAH, f);
            foreach (var f in Calculos.Horizontal(a, b, TipoEstado.ER)) Agregar(dgvErAH, f);
            _ahCalculado = true;
        }

        static void Agregar(DataGridView g, FilaComparativa f) =>
            UtilUI.AgregarFila(g, f.Total, f.Cuenta, Util.Monto(f.Base), Util.Monto(f.Comparado), Util.Monto(f.Delta), Util.Pct(f.Pct));

        // ── Análisis vertical (sobre el periodo activo) ──
        void CalcularAV()
        {
            dgvBgAV.Rows.Clear();
            dgvErAV.Rows.Clear();
            var p = Almacen.Activo;
            if (p == null || !p.TieneDatos) return;
            foreach (var f in Calculos.VerticalBG(p)) UtilUI.AgregarFila(dgvBgAV, f.Total, f.Cuenta, f.Clasificacion, Util.Pct(f.Pct));
            foreach (var f in Calculos.VerticalER(p)) UtilUI.AgregarFila(dgvErAV, f.Total, f.Cuenta, f.Clasificacion, Util.Pct(f.Pct));
        }
    }
}
