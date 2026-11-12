using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LookScan
{
    public partial class InventarioControl : UserControl
    {
        public class ProductoItem
        {
            public string Codigo { get; set; }
            public string Nombre { get; set; }
            public decimal ExistenciaInicial { get; set; }
            public decimal Entradas { get; set; }
            public decimal Salidas { get; set; }
            public decimal CostoUnitario { get; set; }
            public decimal StockMinimo { get; set; }

            // Fórmulas mínimas solicitadas en la guía:
            // 1. Existencia final = Existencia inicial + Entradas − Salidas
            public decimal ExistenciaFinal => ExistenciaInicial + Entradas - Salidas;

            // 2. Valor del inventario = Existencia final × Costo unitario
            public decimal ValorInventario => ExistenciaFinal * CostoUnitario;

            // 3. Alerta: si la existencia final es menor o igual al stock mínimo, hay que reponer
            public bool RequiereReposicion => ExistenciaFinal <= StockMinimo;

            public override string ToString()
            {
                return string.Format("{0} - {1}", Codigo, Nombre);
            }
        }

        private readonly List<ProductoItem> _productos = new List<ProductoItem>();

        public InventarioControl()
        {
            InitializeComponent();
            AplicarTemaClaroYAmpliar();
            InicializarEventosYDatos();
        }

        private void InicializarEventosYDatos()
        {
            btnGuardarProducto.Click += (s, e) => GuardarProducto();
            btnRegistrarMov.Click += (s, e) => RegistrarMovimiento();
            btnLimpiarMov.Click += (s, e) => LimpiarMovimiento();
            btnEditarProducto.Click += (s, e) => GuardarProducto();
            btnCargarDemo.Click += (s, e) => { CargarDatosFicticios(); ActualizarComboProductos(); RefrescarGrid(); CalcularResumenInventario(); };

            // Pinta la fila de rojo cuando hay que reponer (CellFormatting / RowPrePaint)
            dgvExistencias.CellFormatting += dgvExistencias_CellFormatting;
            dgvExistencias.SelectionChanged += (s, e) => CargarProductoSeleccionado();

            // Cargar el demo de inventario proporcionado.
            CargarDatosFicticios();

            // Llenar formulario de datos con un ejemplo predefinido
            txtCodigo.Text = "P-001";
            txtProducto.Text = "Arroz 1 lb";
            txtExistenciaInicial.Text = "100";
            txtCostoUnitario.Text = "18.21";
            txtStockMinimo.Text = "40";

            txtCantidadMov.Text = "70";
            cmbTipoMov.SelectedItem = "Salida";

            ActualizarComboProductos();
            RefrescarGrid();
            CalcularResumenInventario();
        }

        private void CargarDatosFicticios()
        {
            _productos.Clear();

            _productos.Add(new ProductoItem
            {
                Codigo = "P-001",
                Nombre = "Arroz 1 lb",
                ExistenciaInicial = 100,
                Entradas = 10,
                Salidas = 70,
                CostoUnitario = 18.21m,
                StockMinimo = 40
            });

            _productos.Add(new ProductoItem
            {
                Codigo = "P-002",
                Nombre = "Frijol 1 lb",
                ExistenciaInicial = 80,
                Entradas = 30,
                Salidas = 30,
                CostoUnitario = 20.00m,
                StockMinimo = 30
            });

            _productos.Add(new ProductoItem
            {
                Codigo = "P-003",
                Nombre = "Aceite 1 L",
                ExistenciaInicial = 50,
                Entradas = 0,
                Salidas = 15,
                CostoUnitario = 50.00m,
                StockMinimo = 20
            });

            _productos.Add(new ProductoItem { Codigo = "P-004", Nombre = "Azúcar 1 lb", ExistenciaInicial = 120, Entradas = 0, Salidas = 85, CostoUnitario = 15m, StockMinimo = 50 });
            _productos.Add(new ProductoItem { Codigo = "P-005", Nombre = "Jabón de lavar", ExistenciaInicial = 60, Entradas = 10, Salidas = 50, CostoUnitario = 25m, StockMinimo = 25 });
            _productos.Add(new ProductoItem { Codigo = "P-006", Nombre = "Leche 1 L", ExistenciaInicial = 30, Entradas = 10, Salidas = 0, CostoUnitario = 38m, StockMinimo = 15 });
        }

        private void AplicarTemaClaroYAmpliar()
        {
            BackColor = Color.FromArgb(244, 246, 250);
            pnlPrincipal.BackColor = BackColor;
            foreach (GroupBox grupo in new[] { grpDatosProducto, grpRegistrarMov, grpExistencias, grpResumenAlerta }) grupo.Width = 1000;
            pnlValorTotal.BackColor = Color.FromArgb(226, 240, 255);
            pnlReponer.BackColor = Color.FromArgb(255, 242, 218);
            pnlAlertaBanner.BackColor = Color.FromArgb(255, 232, 232);
            AplicarTemaClaro(this);
        }

        private void AplicarTemaClaro(Control control)
        {
            foreach (Control hijo in control.Controls)
            {
                if (hijo is GroupBox) { hijo.BackColor = Color.White; hijo.ForeColor = Color.FromArgb(45, 55, 72); hijo.Text = Regex.Replace(hijo.Text, @"\s*\([^)]*\)", ""); }
                else if (hijo is TextBox || hijo is ComboBox) { hijo.BackColor = Color.White; hijo.ForeColor = Color.FromArgb(35, 45, 60); }
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

        private void ActualizarComboProductos()
        {
            cmbProductoMov.BeginUpdate();
            cmbProductoMov.Items.Clear();

            foreach (var prod in _productos)
            {
                cmbProductoMov.Items.Add(prod);
            }

            if (cmbProductoMov.Items.Count > 0)
            {
                cmbProductoMov.SelectedIndex = 0;
            }

            cmbProductoMov.EndUpdate();
        }

        private void CargarProductoSeleccionado()
        {
            if (dgvExistencias.SelectedRows.Count == 0) return;
            ProductoItem producto = dgvExistencias.SelectedRows[0].Tag as ProductoItem;
            if (producto == null) return;
            txtCodigo.Text = producto.Codigo;
            txtProducto.Text = producto.Nombre;
            txtExistenciaInicial.Text = producto.ExistenciaInicial.ToString("N0");
            txtCostoUnitario.Text = producto.CostoUnitario.ToString("N2");
            txtStockMinimo.Text = producto.StockMinimo.ToString("N0");
        }

        private void GuardarProducto()
        {
            try
            {
                string codigo = txtCodigo.Text.Trim();
            string nombre = txtProducto.Text.Trim();

            if (string.IsNullOrEmpty(codigo) || string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Por favor ingrese código y nombre del producto.", "LookScan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtExistenciaInicial.Text.Replace(",", "").Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal inicial) &&
                !decimal.TryParse(txtExistenciaInicial.Text.Trim(), out inicial))
            {
                MessageBox.Show("Existencia inicial no válida.", "LookScan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtCostoUnitario.Text.Replace(",", "").Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal costo) &&
                !decimal.TryParse(txtCostoUnitario.Text.Trim(), out costo))
            {
                MessageBox.Show("Costo unitario no válido.", "LookScan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtStockMinimo.Text.Replace(",", "").Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal stockMin) &&
                !decimal.TryParse(txtStockMinimo.Text.Trim(), out stockMin))
            {
                MessageBox.Show("Stock mínimo no válido.", "LookScan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var existente = _productos.FirstOrDefault(p => p.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase));
            if (existente != null)
            {
                existente.Nombre = nombre;
                existente.ExistenciaInicial = inicial;
                existente.CostoUnitario = costo;
                existente.StockMinimo = stockMin;
            }
            else
            {
                _productos.Add(new ProductoItem
                {
                    Codigo = codigo,
                    Nombre = nombre,
                    ExistenciaInicial = inicial,
                    Entradas = 0,
                    Salidas = 0,
                    CostoUnitario = costo,
                    StockMinimo = stockMin
                });
            }

            ActualizarComboProductos();
            RefrescarGrid();
            CalcularResumenInventario();

            MessageBox.Show("Producto guardado correctamente.", "LookScan", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede guardar el producto: " + ex.Message, "LookScan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void RegistrarMovimiento()
        {
            try
            {
                ProductoItem prod = cmbProductoMov.SelectedItem as ProductoItem;
            if (prod == null)
            {
                MessageBox.Show("Seleccione un producto para el movimiento.", "LookScan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tipo = cmbTipoMov.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(tipo))
            {
                MessageBox.Show("Seleccione el tipo de movimiento (Entrada o Salida).", "LookScan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtCantidadMov.Text.Replace(",", "").Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal cantidad) &&
                !decimal.TryParse(txtCantidadMov.Text.Trim(), out cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Ingrese una cantidad válida mayor a cero.", "LookScan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tipo == "Entrada")
            {
                prod.Entradas += cantidad;
            }
            else
            {
                // Salida
                if (cantidad > prod.ExistenciaFinal)
                {
                    DialogResult dr = MessageBox.Show(
                        string.Format("La cantidad a retirar ({0}) supera la existencia actual ({1}). ¿Desea registrarla de todos modos?", cantidad, prod.ExistenciaFinal),
                        "LookScan - Advertencia de Stock",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (dr != DialogResult.Yes) return;
                }
                prod.Salidas += cantidad;
            }

            RefrescarGrid();
            CalcularResumenInventario();
            txtCantidadMov.Clear();
            txtCantidadMov.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede registrar el movimiento: " + ex.Message, "LookScan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LimpiarMovimiento()
        {
            txtCantidadMov.Clear();
            if (cmbProductoMov.Items.Count > 0) cmbProductoMov.SelectedIndex = 0;
            cmbTipoMov.SelectedItem = "Salida";
            txtCantidadMov.Focus();
        }

        private void RefrescarGrid()
        {
            dgvExistencias.Rows.Clear();

            foreach (var p in _productos)
            {
                int index = dgvExistencias.Rows.Add(
                    p.Nombre,
                    p.ExistenciaInicial.ToString("N0"),
                    p.Entradas.ToString("N0"),
                    p.Salidas.ToString("N0"),
                    p.ExistenciaFinal.ToString("N0"),
                    p.ValorInventario.ToString("N2")
                );

                dgvExistencias.Rows[index].Tag = p;
            }
        }

        private void dgvExistencias_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvExistencias.Rows.Count) return;

            DataGridViewRow fila = dgvExistencias.Rows[e.RowIndex];
            ProductoItem prod = fila.Tag as ProductoItem;

            if (prod != null && prod.RequiereReposicion)
            {
                // Alerta visible pero suave: rojo pastel y texto de alto contraste.
                e.CellStyle.BackColor = Color.FromArgb(255, 234, 236);
                e.CellStyle.ForeColor = Color.FromArgb(150, 55, 65);
                e.CellStyle.SelectionBackColor = Color.FromArgb(255, 215, 220);
                e.CellStyle.SelectionForeColor = Color.FromArgb(110, 35, 45);
            }
        }

        /// <summary>
        /// Método central de cálculo para el módulo de inventario requerido en la guía.
        /// Fórmulas de la guía:
        /// 1. Existencia final = Existencia inicial + Entradas − Salidas
        /// 2. Valor del inventario = Existencia final × Costo unitario
        /// 3. Alerta: si la existencia final es menor o igual al stock mínimo, hay que reponer.
        /// </summary>
        public void CalcularResumenInventario()
        {
            decimal totalInventario = 0m;
            int productosAReponer = 0;
            List<string> alertas = new List<string>();

            foreach (var p in _productos)
            {
                totalInventario += p.ValorInventario;

                if (p.RequiereReposicion)
                {
                    productosAReponer++;
                    alertas.Add(string.Format("{0} ({1:N0} de {2:N0} mínimo)", p.Nombre, p.ExistenciaFinal, p.StockMinimo));
                }
            }

            // Actualizar tarjetas de resumen
            lblValorTotal.Text = string.Format("C$ {0:N0}", totalInventario);
            lblProductosReponer.Text = productosAReponer.ToString();

            // Actualizar banner de alerta
            if (productosAReponer > 0)
            {
                pnlAlertaBanner.Visible = true;
                lblAlertaReposicion.Text = "⚠ Reponer: " + string.Join(", ", alertas);
            }
            else
            {
                pnlAlertaBanner.Visible = true;
                lblAlertaReposicion.Text = "✔ Niveles de inventario óptimos. No se requiere reposición.";
                lblAlertaReposicion.ForeColor = Color.FromArgb(70, 210, 110);
                pnlAlertaBanner.BackColor = Color.FromArgb(12, 45, 22);
            }
        }
    }
}
