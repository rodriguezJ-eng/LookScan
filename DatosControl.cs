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

            btnCargarDemo.Click += (s, e) => CargarDemo();
            dgvBalance.CellContentClick += Grid_CellContentClick;
            dgvResultados.CellContentClick += Grid_CellContentClick;
            dgvResultados.CellDoubleClick += (s, e) => CargarParaEdicion(dgvResultados, e);
            UtilUI.AlinearDerecha(dgvBalance, 3);
            UtilUI.AlinearDerecha(dgvResultados, 3);

            Almacen.ActivoCambio += Redibujar;
            Almacen.DatosCambiaron += Redibujar;
            Redibujar();
        }

        // Cuenta que se está editando. Null significa que el formulario agrega una nueva.
        private Cuenta cuentaEnEdicion = null;

        void CargarDemo()
        {
            try
            {
                if (Almacen.HayDatos &&
                    MessageBox.Show("Se cargarán los datos de ejemplo para los periodos 2019 y 2020. ¿Continuar?",
                        "LookScan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                Almacen.CargarDemo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar la información demo: " + ex.Message, "LookScan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var g = (DataGridView)sender;
                if (e.RowIndex < 0 || e.ColumnIndex != g.Columns.Count - 1) return;   // última columna = Eliminar
                if (!(g.Rows[e.RowIndex].Tag is Cuenta c)) return;

                if (ReferenceEquals(c, cuentaEnEdicion)) LimpiarFormulario();
                Almacen.EliminarCuenta(Almacen.Activo, c);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar la cuenta: " + ex.Message, "LookScan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Carga todos los campos del formulario con la cuenta de la fila seleccionada.
        void CargarParaEdicion(DataGridView g, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= g.Rows.Count) return;
            if (e.ColumnIndex == g.Columns.Count - 1) return;   // no editar desde el botón Eliminar
            if (!(g.Rows[e.RowIndex].Tag is Cuenta c)) return;

            cuentaEnEdicion = c;

            cmbTipoEstado.SelectedItem = c.Tipo == TipoEstado.BG ? "BG" : "ER";
            txtNombreCuenta.Text = c.Nombre ?? string.Empty;

            if (cmbClasificacion.Items.Contains(c.Clasificacion))
                cmbClasificacion.SelectedItem = c.Clasificacion;
            else if (!string.IsNullOrEmpty(c.Clasificacion))
            {
                cmbClasificacion.Items.Add(c.Clasificacion);
                cmbClasificacion.SelectedItem = c.Clasificacion;
            }

            rbOperativa1.Checked = c.Operativa;
            rbOperativa2.Checked = !c.Operativa;

            decimal monto = c.Monto;
            if (monto < numMonto.Minimum) monto = numMonto.Minimum;
            if (monto > numMonto.Maximum) monto = numMonto.Maximum;
            numMonto.Value = monto;

            btnAgregar.Text = "Actualizar";
            txtNombreCuenta.Focus();
            txtNombreCuenta.SelectAll();
        }

        void LimpiarFormulario()
        {
            cuentaEnEdicion = null;
            btnAgregar.Text = "Agregar";
            txtNombreCuenta.Clear();
            numMonto.Value = 0;
            rbOperativa1.Checked = true;
        }

        // Único manejador de btnAgregar: agrega una cuenta nueva o guarda la edición.
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
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
                if (periodo == null)
                {
                    MessageBox.Show("Seleccione o agregue un periodo antes de registrar cuentas.", "LookScan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool duplicada = periodo.Cuentas.Any(c =>
                    !ReferenceEquals(c, cuentaEnEdicion) &&
                    c.Tipo == tipo && Util.Igual(c.Nombre, nombre));
                if (duplicada)
                { UtilUI.Aviso("Ya existe una cuenta «" + nombre + "» en " + tipo + " del periodo " + periodo.Nombre + "."); return; }

                if (cuentaEnEdicion == null)
                {
                    Almacen.AgregarCuenta(periodo, new Cuenta
                    {
                        Tipo = tipo,
                        Nombre = nombre,
                        Clasificacion = clasif,
                        Operativa = rbOperativa1.Checked,
                        Monto = numMonto.Value
                    });
                }
                else
                {
                    Cuenta c = cuentaEnEdicion;
                    c.Tipo = tipo;
                    c.Nombre = nombre;
                    c.Clasificacion = clasif;
                    c.Operativa = rbOperativa1.Checked;
                    c.Monto = numMonto.Value;
                    Almacen.ActualizarCuenta(periodo, c);
                }

                LimpiarFormulario();
                txtNombreCuenta.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede registrar la cuenta: " + ex.Message, "LookScan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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

        private void dgvBalance_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CargarParaEdicion(dgvBalance, e);
        }
    }
}
