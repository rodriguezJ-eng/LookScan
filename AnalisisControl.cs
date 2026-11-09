using System;
using System.Linq;
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
            Almacen.ActivoCambio += () =>
            {
                LlenarPeriodos(false);
                CalcularAV();
                if (_ahCalculado) CalcularAH(false);
            };
            Almacen.DatosCambiaron += () => { CalcularAV(); if (_ahCalculado) CalcularAH(false); };

            LlenarPeriodos(true);
            CalcularAV();
        }

        void LlenarPeriodos(bool inicial)
        {
            var nombres = Almacen.Nombres.ToList();
            if (nombres.Count == 0) return;

            UtilUI.LlenarCombo(cmbPeriodoBaseAH, nombres, false, true);
            UtilUI.LlenarCombo(cmbPeriodoCompAH, nombres, true, true);

            // Se comparan dos periodos consecutivos que tengan datos. Si el periodo
            // activo es el último, se toma el anterior como base.
            var conDatos = Almacen.Periodos
                .Where(p => p.TieneDatos)
                .Select(p => p.Nombre)
                .ToList();

            string baseNombre;
            string compNombre;

            if (conDatos.Count >= 2)
            {
                int indice = conDatos.IndexOf(Almacen.Activo != null ? Almacen.Activo.Nombre : null);
                if (indice < 0) indice = conDatos.Count - 2;
                if (indice >= conDatos.Count - 1) indice = conDatos.Count - 2;

                baseNombre = conDatos[indice];
                compNombre = conDatos[indice + 1];
            }
            else if (conDatos.Count == 1)
            {
                baseNombre = conDatos[0];
                compNombre = conDatos[0];
            }
            else
            {
                baseNombre = nombres.First();
                compNombre = nombres.Last();
            }

            cmbPeriodoBaseAH.SelectedItem = baseNombre;
            cmbPeriodoCompAH.SelectedItem = compNombre;
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
