using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LookScan
{
    public partial class EfeControl : UserControl
    {
        private class CambioCuenta
        {
            public Cuenta Cuenta { get; set; }
            public decimal Cambio { get; set; }
        }

        public EfeControl()
        {
            InitializeComponent();
            if (Util.EnDiseno) return;

            Almacen.DatosCambiaron += CargarCombosEfe;
            Almacen.PeriodosCambiaron += CargarCombosEfe;
            Almacen.ActivoCambio += CargarCombosEfe;

            CargarCombosEfe();
        }

        private void CargarCombosEfe()
        {
            string baseAnterior = cmbPeriodoBaseEfe.SelectedItem as string;
            string compAnterior = cmbPeriodoCompEfe.SelectedItem as string;

            cmbPeriodoBaseEfe.Items.Clear();
            cmbPeriodoCompEfe.Items.Clear();

            // Se ofrecen primero los periodos con datos; si no hay, se muestran todos.
            var nombres = Almacen.Periodos
                .Where(p => p.TieneDatos)
                .Select(p => p.Nombre)
                .ToList();

            if (nombres.Count == 0) nombres = Almacen.Nombres.ToList();

            foreach (var nombre in nombres)
            {
                cmbPeriodoBaseEfe.Items.Add(nombre);
                cmbPeriodoCompEfe.Items.Add(nombre);
            }

            if (nombres.Count == 0) return;

            int indiceBase = -1;
            int indiceComp = -1;

            if (!string.IsNullOrEmpty(baseAnterior) && !string.IsNullOrEmpty(compAnterior))
            {
                indiceBase = nombres.FindIndex(n => Util.Igual(n, baseAnterior));
                indiceComp = nombres.FindIndex(n => Util.Igual(n, compAnterior));
            }

            // Si no hay una selección válida, se arranca con el periodo activo y el siguiente.
            if (indiceBase < 0 || indiceComp < 0 || indiceBase == indiceComp)
            {
                int indiceActivo = Almacen.Activo != null
                    ? nombres.FindIndex(n => Util.Igual(n, Almacen.Activo.Nombre))
                    : -1;

                if (indiceActivo < 0) indiceActivo = nombres.Count - 1;

                if (indiceActivo < nombres.Count - 1)
                {
                    indiceBase = indiceActivo;
                    indiceComp = indiceActivo + 1;
                }
                else
                {
                    indiceComp = indiceActivo;
                    indiceBase = indiceActivo > 0 ? indiceActivo - 1 : 0;
                }
            }

            cmbPeriodoBaseEfe.SelectedIndex = indiceBase;
            cmbPeriodoCompEfe.SelectedIndex = indiceComp;
        }

        private void btnCalcularEfe_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreBase = cmbPeriodoBaseEfe.SelectedItem as string;
            string nombreComparado = cmbPeriodoCompEfe.SelectedItem as string;

            var periodoBase = Almacen.Buscar(nombreBase);
            var periodoComp = Almacen.Buscar(nombreComparado);

            if (periodoBase == null || periodoComp == null)
            {
                MessageBox.Show("Por favor, seleccione un Período Base y un Período Comparado válidos.", "LookScan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Util.Igual(periodoBase.Nombre, periodoComp.Nombre))
            {
                MessageBox.Show("Seleccione dos periodos distintos para calcular el flujo de efectivo.", "LookScan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!periodoBase.TieneDatos || !periodoComp.TieneDatos)
            {
                MessageBox.Show("Uno de los periodos seleccionados no tiene cuentas. Capture datos o use «Cargar Demo».", "LookScan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (dgvEfe.Columns.Count == 0)
            {
                dgvEfe.Columns.Add("Concepto", "Concepto del Flujo de Efectivo");
                dgvEfe.Columns.Add("Monto", "Monto");
                dgvEfe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

            dgvEfe.Rows.Clear();
            dgvEfe.BackgroundColor = Color.White;
            dgvEfe.RowHeadersVisible = false;

            // La lógica vive en Calculos para que reportes y exportación usen
            // exactamente el mismo resultado que esta pantalla.
            ResultadoEfe resultado = Calculos.Efe(periodoBase, periodoComp, rbMetodo1.Checked);

            foreach (FilaEfe fila in resultado.Filas)
            {
                int indice = fila.Encabezado
                    ? dgvEfe.Rows.Add(fila.Concepto)
                    : dgvEfe.Rows.Add(fila.Concepto, Util.Monto(fila.Monto));

                if (fila.Encabezado)
                {
                    dgvEfe.Rows[indice].DefaultCellStyle.Font = new Font(dgvEfe.Font, FontStyle.Bold);
                    dgvEfe.Rows[indice].DefaultCellStyle.BackColor = Color.FromArgb(240, 243, 246);
                }
                else if (fila.Total)
                {
                    dgvEfe.Rows[indice].DefaultCellStyle.Font = new Font(dgvEfe.Font, FontStyle.Bold);
                }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede calcular el Flujo de Efectivo: " + ex.Message, "LookScan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
