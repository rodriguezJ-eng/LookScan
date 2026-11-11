using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace LookScan
{
    public partial class PresupuestoControl : UserControl
    {
        private readonly string[] _categoriasGasto = new[]
        {
            "Alimentación", "Transporte", "Servicios", "Educación", "Salud", "Entretenimiento", "Otros"
        };

        private readonly string[] _categoriasIngreso = new[]
        {
            "Salario", "Ventas", "Honorarios", "Inversiones", "Otros"
        };

        public PresupuestoControl()
        {
            InitializeComponent();
            InicializarEventosYDatos();
        }

        private void InicializarEventosYDatos()
        {
            // Configurar combos iniciales
            cmbMes.SelectedItem = "Noviembre";
            numAnio.Value = 2026;

            cmbTipo.SelectedIndexChanged += (s, e) => ActualizarCategorias();
            cmbTipo.SelectedItem = "Gasto";

            txtDescripcion.Text = "Supermercado";
            txtMonto.Text = "1500.00";

            btnAgregar.Click += (s, e) => AgregarMovimiento();
            btnEliminar.Click += (s, e) => EliminarMovimiento();
            btnLimpiar.Click += (s, e) => LimpiarFormulario();

            // Cargar datos ficticios iniciales como muestra la guía / captura
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
                int anio = (int)numAnio.Value;
                int mes = cmbMes.SelectedIndex >= 0 ? cmbMes.SelectedIndex + 1 : 11;
                dgvMovimientos.Rows.Clear();
                dgvMovimientos.Rows.Add("Ingreso", "Salario", "15,000", string.Format("{0:00}/{1:00}/{2}", 1, mes, anio));
                dgvMovimientos.Rows.Add("Gasto", "Alimentación", "1,500", string.Format("{0:00}/{1:00}/{2}", 3, mes, anio));
                dgvMovimientos.Rows.Add("Gasto", "Transporte", "800", string.Format("{0:00}/{1:00}/{2}", 5, mes, anio));
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pueden cargar los movimientos de ejemplo: " + ex.Message, "LookScan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                dgvMovimientos.Rows.Add(tipo, categoria, monto.ToString("N0"), fecha);

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
                punto.LabelForeColor = Color.White;

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
                punto.LabelForeColor = Color.White;
                punto.Color = colorAzul;
            }
        }
    }
}
