using System;
using System.Linq;
using System.Windows.Forms;

namespace LookScan
{
    public partial class DatosControl : UserControl
    {
        public DatosControl()
        {
            InitializeComponent();
            if (Util.EnDiseno) return;

            btnAgregar.Click += (s, e) => AgregarCuenta();
            btnCargarDemo.Click += (s, e) => CargarDemo();
            dgvBalance.CellContentClick += Grid_CellContentClick;
            dgvResultados.CellContentClick += Grid_CellContentClick;
            UtilUI.AlinearDerecha(dgvBalance, 3);
            UtilUI.AlinearDerecha(dgvResultados, 3);

            Almacen.ActivoCambio += Redibujar;
            Almacen.DatosCambiaron += Redibujar;
            Redibujar();
        }

        void AgregarCuenta()
        {
            string nombre = txtNombreCuenta.Text.Trim();
            if (nombre.Length == 0) { UtilUI.Aviso("Escriba el nombre de la cuenta."); txtNombreCuenta.Focus(); return; }
            if (cmbTipoEstado.SelectedItem == null || cmbClasificacion.SelectedItem == null)
            { UtilUI.Aviso("Seleccione el tipo de estado y la clasificación."); return; }

            var tipo = cmbTipoEstado.SelectedItem.ToString() == "BG" ? TipoEstado.BG : TipoEstado.ER;
            string clasif = cmbClasificacion.SelectedItem.ToString();
            if (Clasif.EsDeBalance(clasif) != (tipo == TipoEstado.BG))
            {
                UtilUI.Aviso(tipo == TipoEstado.BG
                    ? "«" + clasif + "» es una clasificación del Estado de Resultados. Cambie el tipo a ER o elija una clasificación de balance."
                    : "«" + clasif + "» es una clasificación del Balance General. Cambie el tipo a BG o elija una clasificación de resultados.");
                return;
            }

            var periodo = Almacen.Activo;
            if (periodo.Cuentas.Any(c => c.Tipo == tipo && Util.Igual(c.Nombre, nombre)))
            { UtilUI.Aviso("Ya existe una cuenta «" + nombre + "» en " + tipo + " del periodo " + periodo.Nombre + "."); return; }

            Almacen.AgregarCuenta(periodo, new Cuenta
            {
                Tipo = tipo, Nombre = nombre, Clasificacion = clasif,
                Operativa = rbOperativa1.Checked, Monto = numMonto.Value
            });
            txtNombreCuenta.Clear();
            numMonto.Value = 0;
            txtNombreCuenta.Focus();
        }

        void CargarDemo()
        {
            if (Almacen.HayDatos &&
                MessageBox.Show("Se reemplazarán las cuentas de los periodos 2023, 2024 y 2025 por los datos de ejemplo. ¿Continuar?",
                    "FINBOT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            Almacen.CargarDemo();
        }

        void Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var g = (DataGridView)sender;
            if (e.RowIndex < 0 || e.ColumnIndex != g.Columns.Count - 1) return;   // última columna = Eliminar
            if (g.Rows[e.RowIndex].Tag is Cuenta c) Almacen.EliminarCuenta(Almacen.Activo, c);
        }

        void Redibujar()
        {
            dgvBalance.Rows.Clear();
            dgvResultados.Rows.Clear();
            var p = Almacen.Activo;
            if (p == null) return;
            foreach (var c in p.BG.OrderBy(x => Clasif.Orden(x.Clasificacion))) Fila(dgvBalance, c);
            foreach (var c in p.ER.OrderBy(x => Clasif.Orden(x.Clasificacion))) Fila(dgvResultados, c);
        }

        static void Fila(DataGridView g, Cuenta c)
        {
            int i = g.Rows.Add(c.Nombre, c.Clasificacion, c.Operativa ? "Sí" : "No", Util.Monto(c.Monto), null);
            g.Rows[i].Tag = c;
        }
    }
}
