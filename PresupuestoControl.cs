using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace LookScan
{
    public partial class PresupuestoControl : UserControl
    {
        private readonly string[] _categoriasGasto = new[]
        {
            "Meriendas", "Transporte", "Copias y materiales", "Personal/Ocio", "Otros"
        };

        private readonly string[] _categoriasIngreso = new[]
        {
            "Apoyo familiar", "Imprevistos", "Materiales", "Personal/Ocio", "Otros"
        };

        public PresupuestoControl()
        {
            InitializeComponent();
            AplicarTemaClaroYAmpliar();
            InicializarEventosYDatos();
        }

        private void InicializarEventosYDatos()
        {
            // Configurar combos iniciales
            cmbMes.SelectedItem = "Agosto";
            numAnio.Value = 2026;

            cmbTipo.SelectedIndexChanged += (s, e) => ActualizarCategorias();
            cmbTipo.SelectedItem = "Gasto";

            txtDescripcion.Text = "Transporte";
            txtMonto.Text = "20.00";

            btnAgregar.Click += (s, e) => AgregarMovimiento();
            btnEliminar.Click += (s, e) => EliminarMovimiento();
            btnLimpiar.Click += (s, e) => LimpiarFormulario();
            dgvMovimientos.SelectionChanged += (s, e) => CargarMovimientoSeleccionado();
            var btnEditar = new Button
            {
                Text = "Editar seleccionado", Location = new Point(815, 115), Size = new Size(160, 38),
                BackColor = Color.FromArgb(24, 72, 140), ForeColor = Color.White, FlatStyle = FlatStyle.Flat
            };
            btnEditar.Click += (s, e) => EditarMovimientoSeleccionado();
            grpRegistro.Controls.Add(btnEditar);
            var btnDemo = new Button
            {
                Text = "Cargar demo de agosto 2026", AutoSize = true,
                Location = new Point(470, 4), BackColor = Color.FromArgb(24, 72, 140), ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnDemo.Click += (s, e) => { CargarDatosFicticios(); CalcularResumen(); };
            pnlEncabezado.Controls.Add(btnDemo);

            // Demo de agosto de 2026 proporcionado para el presupuesto personal.
            CargarDatosFicticios();

            // Calcular el resumen y armar el gráfico
            CalcularResumen();
        }

        private void ActualizarCategorias()
        {
            cmbCategoria.Items.Clear();
            bool esGasto = cmbTipo.SelectedItem?.ToString() == "Gasto";

            if (esGasto)
            {
                cmbCategoria.Items.AddRange(_categoriasGasto);
                cmbCategoria.SelectedItem = "Alimentación";
            }
            else
            {
                cmbCategoria.Items.AddRange(_categoriasIngreso);
                cmbCategoria.SelectedItem = "Salario";
            }
        }

        private void CargarDatosFicticios()
        {
            try
            {
                dgvMovimientos.Rows.Clear();
                Action<int, string, string, decimal> agregar = (dia, tipo, descripcion, monto) =>
                    dgvMovimientos.Rows.Add(tipo, descripcion, monto.ToString("N2"), new DateTime(2026, 8, dia).ToString("dd/MM/yyyy"), descripcion);

                agregar(3, "Ingreso", "Apoyo familiar", 250); agregar(3, "Reserva", "Imprevistos", 55); agregar(3, "Ahorro", "Materiales", 65); agregar(3, "Gasto", "Transporte", 20);
                agregar(4, "Gasto", "Transporte", 20); agregar(4, "Gasto", "Meriendas", 15);
                agregar(5, "Gasto", "Transporte", 20); agregar(5, "Gasto", "Meriendas", 15);
                agregar(6, "Gasto", "Transporte", 20); agregar(6, "Gasto", "Copias y materiales", 10);
                agregar(7, "Gasto", "Transporte", 20); agregar(7, "Gasto", "Personal/Ocio", 10); agregar(8, "Gasto", "Personal/Ocio", 5); agregar(9, "Gasto", "Personal/Ocio", 0);
                agregar(10, "Ingreso", "Apoyo familiar", 250); agregar(10, "Reserva", "Imprevistos", 40); agregar(10, "Ahorro", "Materiales", 0); agregar(10, "Gasto", "Transporte", 20); agregar(10, "Gasto", "Personal/Ocio", 20);
                agregar(11, "Gasto", "Transporte", 20); agregar(11, "Gasto", "Meriendas", 20); agregar(12, "Gasto", "Transporte", 20); agregar(12, "Gasto", "Personal/Ocio", 15); agregar(13, "Gasto", "Transporte", 20); agregar(13, "Gasto", "Personal/Ocio", 15); agregar(14, "Gasto", "Transporte", 20); agregar(14, "Gasto", "Personal/Ocio", 30); agregar(15, "Gasto", "Personal/Ocio", 10); agregar(16, "Gasto", "Personal/Ocio", 5);
                agregar(17, "Ingreso", "Apoyo familiar", 250); agregar(17, "Reserva", "Imprevistos", 55); agregar(17, "Ahorro", "Materiales", 45); agregar(17, "Gasto", "Transporte", 20); agregar(18, "Gasto", "Transporte", 20); agregar(18, "Gasto", "Alimentación/Merienda", 15); agregar(19, "Gasto", "Transporte", 20); agregar(20, "Gasto", "Transporte", 20); agregar(20, "Gasto", "Copias y materiales", 15); agregar(21, "Gasto", "Transporte", 20); agregar(21, "Gasto", "Personal/Ocio", 10); agregar(22, "Gasto", "Personal/Ocio", 10); agregar(23, "Gasto", "Personal/Ocio", 0);
                agregar(24, "Ingreso", "Apoyo familiar", 250); agregar(24, "Reserva", "Imprevistos", 50); agregar(24, "Ahorro", "Personal/Ocio", 30); agregar(24, "Gasto", "Transporte", 20); agregar(25, "Gasto", "Transporte", 20); agregar(25, "Gasto", "Meriendas", 15); agregar(26, "Gasto", "Transporte", 20); agregar(26, "Gasto", "Meriendas", 10); agregar(27, "Gasto", "Transporte", 20); agregar(27, "Gasto", "Copias y materiales", 5); agregar(28, "Gasto", "Transporte", 20); agregar(28, "Gasto", "Personal/Ocio", 20); agregar(29, "Gasto", "Personal/Ocio", 10); agregar(30, "Gasto", "Personal/Ocio", 0);
                agregar(31, "Ingreso", "Apoyo familiar", 250); agregar(31, "Gasto", "Transporte", 20); agregar(31, "Reserva", "Imprevistos", 50); agregar(31, "Ahorro", "Materiales", 50); agregar(31, "Gasto", "Personal/Ocio", 130);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pueden cargar los movimientos de ejemplo: " + ex.Message, "LookScan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AplicarTemaClaroYAmpliar()
        {
            BackColor = Color.FromArgb(244, 246, 250);
            pnlPrincipal.BackColor = BackColor;
            pnlEncabezado.Width = 1000;
            foreach (GroupBox grupo in new[] { grpRegistro, grpMovimientos, grpResumen, grpGrafico }) grupo.Width = 1000;
            pnlIngresos.BackColor = Color.FromArgb(222, 247, 232);
            pnlGastos.BackColor = Color.FromArgb(255, 229, 234);
            pnlSaldo.BackColor = Color.FromArgb(226, 240, 255);
            pnlAhorro.BackColor = Color.FromArgb(255, 242, 218);
            AplicarTemaClaro(this);
        }

        private void AplicarTemaClaro(Control control)
        {
            foreach (Control hijo in control.Controls)
            {
                if (hijo is GroupBox) { hijo.BackColor = Color.White; hijo.ForeColor = Color.FromArgb(45, 55, 72); }
                else if (hijo is TextBox || hijo is ComboBox || hijo is NumericUpDown) { hijo.BackColor = Color.White; hijo.ForeColor = Color.FromArgb(35, 45, 60); }
                else if (hijo is DataGridView)
                {
                    var tabla = (DataGridView)hijo;
                    tabla.BackgroundColor = Color.White;
                    tabla.DefaultCellStyle.BackColor = Color.White;
                    tabla.DefaultCellStyle.ForeColor = Color.FromArgb(35, 45, 60);
                    tabla.DefaultCellStyle.SelectionBackColor = Color.FromArgb(225, 238, 255);
                    tabla.DefaultCellStyle.SelectionForeColor = Color.FromArgb(20, 55, 100);
                    tabla.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(24, 72, 140);
                    tabla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    tabla.GridColor = Color.FromArgb(220, 225, 235);
                }
                else if (hijo is Button) { hijo.BackColor = Color.FromArgb(24, 72, 140); hijo.ForeColor = Color.White; }
                else if (hijo is Label) { hijo.ForeColor = Color.FromArgb(70, 80, 95); hijo.Text = Regex.Replace(hijo.Text, @"\s*\([^)]*\)", ""); }
                AplicarTemaClaro(hijo);
            }
        }

        private void AgregarMovimiento()
        {
            try
            {
                string tipo = cmbTipo.SelectedItem?.ToString();
                string categoria = cmbCategoria.SelectedItem?.ToString();
                string descripcion = txtDescripcion.Text.Trim();
                string montoTexto = txtMonto.Text.Trim()
                    .Replace("C$", "").Replace(",", "").Trim();

                if (string.IsNullOrEmpty(tipo) || string.IsNullOrEmpty(categoria))
                {
                    MessageBox.Show("No se puede registrar el movimiento: por favor seleccione tipo y categoría.", "LookScan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(montoTexto, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal monto) || monto <= 0)
                {
                    if (!decimal.TryParse(montoTexto, out monto) || monto <= 0)
                    {
                        MessageBox.Show("No se puede registrar el movimiento: por favor ingrese un monto válido mayor que cero.", "LookScan",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                int anio = (int)numAnio.Value;
                int mes = cmbMes.SelectedIndex >= 0 ? cmbMes.SelectedIndex + 1 : DateTime.Now.Month;
                int dia = DateTime.Now.Day;
                int maxDias = DateTime.DaysInMonth(anio, mes);
                if (dia > maxDias) dia = maxDias;
                DateTime fechaMov = new DateTime(anio, mes, dia);
                string fecha = fechaMov.ToString("dd/MM/yyyy");

                dgvMovimientos.Rows.Add(tipo, categoria, monto.ToString("N2"), fecha, descripcion);

                // Se recalcula automáticamente el resumen
                CalcularResumen();

                // Limpiar inputs
                txtDescripcion.Clear();
                txtMonto.Clear();
                txtDescripcion.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede registrar el movimiento: " + ex.Message, "LookScan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void EliminarMovimiento()
        {
            try
            {
                if (dgvMovimientos.SelectedRows.Count == 0)
                {
                    MessageBox.Show("No se puede eliminar: seleccione un movimiento en la tabla para eliminar.", "LookScan",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                dgvMovimientos.Rows.RemoveAt(dgvMovimientos.SelectedRows[0].Index);

                // Se recalcula automáticamente el resumen
                CalcularResumen();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede eliminar el movimiento: " + ex.Message, "LookScan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void EditarMovimientoSeleccionado()
        {
            if (dgvMovimientos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un movimiento para editar.", "LookScan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DataGridViewRow fila = dgvMovimientos.SelectedRows[0];
            string monto = txtMonto.Text.Replace("C$", "").Replace(",", "").Trim();
            decimal valor;
            if (!decimal.TryParse(monto, NumberStyles.Any, CultureInfo.InvariantCulture, out valor) && !decimal.TryParse(monto, out valor))
            {
                MessageBox.Show("Ingrese un monto válido para guardar la edición.", "LookScan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            fila.Cells["colTipo"].Value = cmbTipo.SelectedItem;
            fila.Cells["colCategoria"].Value = cmbCategoria.SelectedItem;
            fila.Cells["colMonto"].Value = valor.ToString("N2");
            fila.Cells["colDescripcion"].Value = txtDescripcion.Text.Trim();
            CalcularResumen();
        }

        private void CargarMovimientoSeleccionado()
        {
            if (dgvMovimientos.SelectedRows.Count == 0) return;
            DataGridViewRow fila = dgvMovimientos.SelectedRows[0];
            string tipo = fila.Cells["colTipo"].Value as string;
            if (!string.IsNullOrEmpty(tipo)) cmbTipo.SelectedItem = tipo;
            string categoria = fila.Cells["colCategoria"].Value as string;
            if (!string.IsNullOrEmpty(categoria) && cmbCategoria.Items.Contains(categoria)) cmbCategoria.SelectedItem = categoria;
            txtMonto.Text = fila.Cells["colMonto"].Value == null ? string.Empty : fila.Cells["colMonto"].Value.ToString();
            txtDescripcion.Text = fila.Cells["colDescripcion"].Value == null ? string.Empty : fila.Cells["colDescripcion"].Value.ToString();
        }

        private void LimpiarFormulario()
        {
            txtDescripcion.Clear();
            txtMonto.Clear();
            cmbTipo.SelectedItem = "Gasto";
            cmbCategoria.SelectedItem = "Alimentación";
            txtDescripcion.Focus();
        }

        /// <summary>
        /// Método central de cálculo requerido para la defensa individual.
        /// Fórmulas de la guía:
        /// 1. Saldo disponible = Total ingresos − Total gastos
        /// 2. Capacidad de ahorro (%) = Saldo disponible ÷ Total ingresos × 100
        /// </summary>
        public void CalcularResumen()
        {
            decimal totalIngresos = 0m;
            decimal totalGastos = 0m;
            Dictionary<string, decimal> gastosPorCategoria = new Dictionary<string, decimal>(StringComparer.OrdinalIgnoreCase);

            // Inicializar las categorías de gastos principales para que aparezcan en el gráfico
            gastosPorCategoria["Alimentación"] = 0m;
            gastosPorCategoria["Transporte"] = 0m;
            gastosPorCategoria["Servicios"] = 0m;

            foreach (DataGridViewRow fila in dgvMovimientos.Rows)
            {
                if (fila.IsNewRow) continue;

                string tipo = fila.Cells["colTipo"].Value?.ToString() ?? "";
                string categoria = fila.Cells["colCategoria"].Value?.ToString() ?? "";
                string montoStr = fila.Cells["colMonto"].Value?.ToString() ?? "0";

                montoStr = montoStr.Replace("C$", "").Replace(",", "").Trim();
                decimal.TryParse(montoStr, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal monto);

                if (tipo.Equals("Ingreso", StringComparison.OrdinalIgnoreCase))
                {
                    totalIngresos += monto;
                }
                else if (tipo.Equals("Gasto", StringComparison.OrdinalIgnoreCase))
                {
                    totalGastos += monto;

                    if (!gastosPorCategoria.ContainsKey(categoria))
                        gastosPorCategoria[categoria] = 0m;

                    gastosPorCategoria[categoria] += monto;
                }
            }

            // 1. Saldo disponible = Total ingresos − Total gastos
            decimal saldoDisponible = totalIngresos - totalGastos;

            // 2. Capacidad de ahorro (%) = Saldo disponible ÷ Total ingresos × 100
            decimal capacidadAhorro = 0m;
            if (totalIngresos > 0m)
            {
                capacidadAhorro = (saldoDisponible / totalIngresos) * 100m;
            }

            // Actualizar etiquetas en la interfaz
            lblTotalIngresos.Text = string.Format("C$ {0:N0}", totalIngresos);
            lblTotalGastos.Text = string.Format("C$ {0:N0}", totalGastos);
            lblSaldoDisponible.Text = string.Format("C$ {0:N0}", saldoDisponible);
            lblCapacidadAhorro.Text = string.Format("{0:0.0} %", capacidadAhorro);

            // Actualizar gráfico de gastos por categoría
            ActualizarGrafico(gastosPorCategoria, totalGastos);
        }

        private void ActualizarGrafico(Dictionary<string, decimal> gastosPorCategoria, decimal totalGastos)
        {
            if (chartGastos.Series.IndexOf("Gastos") < 0) return;

            Series serie = chartGastos.Series["Gastos"];
            serie.Points.Clear();

            // Colores correspondientes a las categorías mostradas en la guía
            Color colorVerde = Color.FromArgb(20, 130, 95);
            Color colorMorado = Color.FromArgb(100, 80, 180);
            Color colorNaranja = Color.FromArgb(220, 110, 40);
            Color colorAzul = Color.FromArgb(50, 120, 200);

            // Mostrar al menos Alimentación, Transporte, Servicios en el orden visual
            string[] categoriasOrdenadas = new[] { "Servicios", "Transporte", "Alimentación" };

            foreach (string cat in categoriasOrdenadas)
            {
                decimal monto = gastosPorCategoria.ContainsKey(cat) ? gastosPorCategoria[cat] : 0m;
                double porcentaje = totalGastos > 0m ? (double)((monto / totalGastos) * 100m) : 0.0;

                int index = serie.Points.AddXY(cat, porcentaje);
                DataPoint punto = serie.Points[index];
                punto.Label = string.Format("{0:0}%", porcentaje);
                // La etiqueta queda fuera/al lado de la barra; debe contrastar con el fondo claro.
                punto.LabelForeColor = Color.FromArgb(30, 55, 85);

                if (cat == "Alimentación") punto.Color = colorVerde;
                else if (cat == "Transporte") punto.Color = colorMorado;
                else if (cat == "Servicios") punto.Color = colorNaranja;
                else punto.Color = colorAzul;
            }

            // Agregar cualquier otra categoría adicional si existe
            foreach (var kvp in gastosPorCategoria)
            {
                if (categoriasOrdenadas.Contains(kvp.Key, StringComparer.OrdinalIgnoreCase)) continue;

                double porcentaje = totalGastos > 0m ? (double)((kvp.Value / totalGastos) * 100m) : 0.0;
                int index = serie.Points.AddXY(kvp.Key, porcentaje);
                DataPoint punto = serie.Points[index];
                punto.Label = string.Format("{0:0}%", porcentaje);
                punto.LabelForeColor = Color.FromArgb(30, 55, 85);
                punto.Color = colorAzul;
            }
        }
    }
}
