using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LookScan
{
    public partial class EoafControl : UserControl
    {
        public EoafControl()
        {
            InitializeComponent();
            if (Util.EnDiseno) return;

            Almacen.DatosCambiaron += CargarCombosEoaf;
            Almacen.PeriodosCambiaron += CargarCombosEoaf;
            Almacen.ActivoCambio += CargarCombosEoaf;

            CargarCombosEoaf();
        }

        private void CargarCombosEoaf()
        {
            string baseAnterior = cmbPeriodoBaseEoaf.SelectedItem as string;
            string compAnterior = cmbPeriodoCompEoaf.SelectedItem as string;

            cmbPeriodoBaseEoaf.Items.Clear();
            cmbPeriodoCompEoaf.Items.Clear();

            // Se ofrecen primero los periodos con datos; si no hay, se muestran todos.
            var nombres = Almacen.Periodos
                .Where(p => p.TieneDatos)
                .Select(p => p.Nombre)
                .ToList();

            if (nombres.Count == 0) nombres = Almacen.Nombres.ToList();

            foreach (var nombre in nombres)
            {
                cmbPeriodoBaseEoaf.Items.Add(nombre);
                cmbPeriodoCompEoaf.Items.Add(nombre);
            }

            if (nombres.Count == 0) return;

            // Periodo comparado: el activo si tiene datos; si no, el último disponible.
            string comp = compAnterior;
            if (string.IsNullOrEmpty(comp) || !nombres.Any(n => Util.Igual(n, comp)))
            {
                comp = Almacen.Activo != null ? Almacen.Activo.Nombre : nombres[nombres.Count - 1];
            }

            int indiceComp = nombres.FindIndex(n => Util.Igual(n, comp));
            if (indiceComp < 0) indiceComp = nombres.Count - 1;

            // Periodo base: el anterior al comparado.
            string baseNombre = baseAnterior;
            if (string.IsNullOrEmpty(baseNombre) || !nombres.Any(n => Util.Igual(n, baseNombre)))
            {
                baseNombre = indiceComp > 0 ? nombres[indiceComp - 1] : nombres[0];
            }

            int indiceBase = nombres.FindIndex(n => Util.Igual(n, baseNombre));
            if (indiceBase < 0) indiceBase = indiceComp > 0 ? indiceComp - 1 : 0;

            cmbPeriodoBaseEoaf.SelectedIndex = indiceBase;
            cmbPeriodoCompEoaf.SelectedIndex = indiceComp;
        }

        private void btnCalcularEoaf_Click(object sender, EventArgs e)
        {
            string anioBaseStr = cmbPeriodoBaseEoaf.SelectedItem as string;
            string anioCompStr = cmbPeriodoCompEoaf.SelectedItem as string;

            var periodoBase = Almacen.Buscar(anioBaseStr);
            var periodoComp = Almacen.Buscar(anioCompStr);

            if (periodoBase == null || periodoComp == null)
            {
                MessageBox.Show("Debe seleccionar un período base y un período comparado válidos.", "LookScan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Util.Igual(periodoBase.Nombre, periodoComp.Nombre))
            {
                MessageBox.Show("Seleccione dos periodos distintos para comparar.", "LookScan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!periodoBase.TieneDatos || !periodoComp.TieneDatos)
            {
                MessageBox.Show("Uno de los periodos seleccionados no tiene cuentas. Capture datos o use «Cargar Demo».", "LookScan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dgvEoaf.Rows.Clear();

            // Encabezados siempre actualizados con los años elegidos.
            if (dgvEoaf.Columns.Count == 0)
            {
                dgvEoaf.Columns.Add("Cuenta", "Cuenta");
                dgvEoaf.Columns.Add("Clasif", "Clasif.");
                dgvEoaf.Columns.Add("Anio1", "Año 1");
                dgvEoaf.Columns.Add("Anio2", "Año 2");
                dgvEoaf.Columns.Add("Cambios", "Cambio");
                dgvEoaf.Columns.Add("Origen", "Origen");
                dgvEoaf.Columns.Add("Aplicacion", "Aplicación");
            }

            dgvEoaf.Columns[0].HeaderText = "Cuenta";
            dgvEoaf.Columns[1].HeaderText = "Clasif.";
            dgvEoaf.Columns[2].HeaderText = periodoBase.Nombre;
            dgvEoaf.Columns[3].HeaderText = periodoComp.Nombre;
            dgvEoaf.Columns[4].HeaderText = "Cambio";
            dgvEoaf.Columns[5].HeaderText = "Origen";
            dgvEoaf.Columns[6].HeaderText = "Aplicación";

            // La lógica vive en Calculos para que reportes y exportación usen
            // exactamente el mismo resultado que esta pantalla.
            ResultadoEoaf resultado = Calculos.Eoaf(periodoBase, periodoComp);

            foreach (FilaEoaf fila in resultado.Filas)
            {
                dgvEoaf.Rows.Add(
                    fila.Cuenta,
                    fila.Clasificacion,
                    Util.Monto(fila.MontoBase),
                    Util.Monto(fila.MontoComparado),
                    Util.Monto(fila.Cambio),
                    fila.Origen > 0m ? Util.Monto(fila.Origen) : string.Empty,
                    fila.Aplicacion > 0m ? Util.Monto(fila.Aplicacion) : string.Empty);
            }

            int filaTotal = dgvEoaf.Rows.Add(
                "TOTALES",
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                Util.Monto(resultado.TotalOrigen),
                Util.Monto(resultado.TotalAplicacion));

            dgvEoaf.Rows[filaTotal].DefaultCellStyle.Font =
                new System.Drawing.Font(dgvEoaf.Font, System.Drawing.FontStyle.Bold);

            int filaDiferencia = dgvEoaf.Rows.Add(
                "DIFERENCIA (Origen - Aplicación)",
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                Util.Monto(resultado.Diferencia),
                string.Empty);

            dgvEoaf.Rows[filaDiferencia].DefaultCellStyle.Font =
                new System.Drawing.Font(dgvEoaf.Font, System.Drawing.FontStyle.Bold);
        }
    }
}
