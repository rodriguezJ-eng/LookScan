using System;
using System.Linq;
using System.Windows.Forms;

namespace LookScan
{
    public partial class MainForm : Form
    {
        bool _sincronizando;

        public MainForm()
        {
            InitializeComponent();
            ucInicio.IniciarClick += (s, e) => tabControl.SelectedIndex = 1;
            if (Util.EnDiseno) return;

            txtEmpresa.TextChanged += (s, e) => Almacen.Empresa = txtEmpresa.Text;
            Almacen.EmpresaCambio += () =>
            {
                if (Util.Igual(txtEmpresa.Text, Almacen.Empresa)) return;
                txtEmpresa.Text = Almacen.Empresa ?? string.Empty;
            };
            btnAnadirPeriodo.Click += (s, e) => AnadirPeriodo();
            cmbPeriodoActivo.SelectedIndexChanged += (s, e) =>
            {
                if (_sincronizando) return;
                var p = Almacen.Buscar(cmbPeriodoActivo.SelectedItem as string);
                if (p != null) Almacen.Activo = p;
            };
            Almacen.PeriodosCambiaron += SincronizarCombo;
            Almacen.ActivoCambio += SincronizarCombo;
            Almacen.PeriodosCambiaron += CargarPeriodosEnComboBox;
            Almacen.DatosCambiaron += CargarPeriodosEnComboBox;
            Almacen.ActivoCambio += CargarPeriodosEnComboBox;
            SincronizarCombo();
            CargarPeriodosEnComboBox();
            txtEmpresa.Text = Almacen.Empresa ?? string.Empty;
            cmbPeriodoActivo.SelectedIndex = -1;
            cmbPeriodoActivo.Text = string.Empty;
            numAnio.Value = 2020;
        }


        // Refleja en el combo "Periodo activo" la lista y el periodo activo del almacén.
        void SincronizarCombo()
        {
            _sincronizando = true;
            try
            {
                cmbPeriodoActivo.BeginUpdate();
                cmbPeriodoActivo.Items.Clear();

                foreach (var n in Almacen.Nombres)
                {
                    cmbPeriodoActivo.Items.Add(n);
                }

                // Solo seleccionamos si hay un activo explícito y diferente de nulo
                if (Almacen.Activo != null)
                {
                    cmbPeriodoActivo.SelectedItem = Almacen.Activo.Nombre;
                }
                else
                {
                    cmbPeriodoActivo.SelectedIndex = -1;
                    cmbPeriodoActivo.Text = string.Empty;
                }

                cmbPeriodoActivo.EndUpdate();
            }
            finally { _sincronizando = false; }
        }
        

        void AnadirPeriodo()
        {
            try
            {
                string nombre = ((int)numAnio.Value).ToString();
                var existente = Almacen.Buscar(nombre);
                if (existente != null)
                {
                    Almacen.Activo = existente;
                    UtilUI.Aviso("El periodo " + nombre + " ya existe; quedó como periodo activo.");
                    return;
                }
                Almacen.AgregarPeriodo(nombre);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede añadir el periodo: " + ex.Message, "LookScan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CargarPeriodosEnComboBox()
        {
            string anterior = cmbGradoApalancamiento.SelectedItem as string;

            // Solo se ofrecen periodos con datos; si aún no hay ninguno, se muestran todos.
            var nombres = Almacen.Periodos
                .Where(p => p.TieneDatos)
                .Select(p => p.Nombre)
                .ToList();

            if (nombres.Count == 0) nombres = Almacen.Nombres.ToList();

            cmbGradoApalancamiento.Items.Clear();
            foreach (var nombre in nombres) cmbGradoApalancamiento.Items.Add(nombre);

            if (nombres.Count == 0) return;

            string objetivo = Almacen.Activo != null ? Almacen.Activo.Nombre : anterior;
            int indice = -1;

            for (int i = 0; i < nombres.Count; i++)
            {
                if (Util.Igual(nombres[i], objetivo))
                {
                    indice = i;
                    break;
                }
            }

            if (indice < 0) indice = nombres.Count - 1;
            cmbGradoApalancamiento.SelectedIndex = indice;
        }
        private void btnGenerarErYapalancamiento_Click(object sender, EventArgs e)
        {
            try
            {
                string periodoSeleccionado = cmbGradoApalancamiento.SelectedItem as string;
            if (string.IsNullOrEmpty(periodoSeleccionado)) periodoSeleccionado = cmbGradoApalancamiento.Text;

            var periodo = Almacen.Buscar(periodoSeleccionado);

            if (periodo == null || !periodo.TieneDatos)
            {
                MessageBox.Show("Por favor, seleccione un período con datos para analizar.", "LookScan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dgvEstadoDeResultado.Rows.Clear();

            decimal ventas = Calculos.Ventas(periodo);
            decimal costoVentas = Calculos.CostoVentas(periodo);
            decimal gastosOperativos = Calculos.GastosOperativos(periodo);
            decimal gastosFinancieros = Calculos.GastosFinancieros(periodo);
            decimal otrosIngresos = Calculos.OtrosIngresos(periodo);
            decimal impuestos = Calculos.Impuestos(periodo);

            if (ventas == 0m)
            {
                MessageBox.Show("El período seleccionado no registra ventas en el Estado de Resultados.", "LookScan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            decimal utilidadBruta = Calculos.UtilidadBruta(periodo);
            decimal uaii = Calculos.UtilidadOperativa(periodo);
            decimal uai = Calculos.UtilidadAntesImpuestos(periodo);
            decimal utilidadNeta = Calculos.UtilidadNeta(periodo);

            // ==========================================
            // CÁLCULO DE GRADOS DE APALANCAMIENTO
            // ==========================================

            if (dgvGrados.Columns.Count == 0)
            {
                dgvGrados.Columns.Add("Concepto", "Indicador Financiero");
                dgvGrados.Columns.Add("Grado", "Grado / Multiplicador");
                dgvGrados.Columns.Add("Interpretacion", "Interpretación Automática");
                dgvGrados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

            // La tabla es solo de lectura: evita la fila vacía de captura.
            dgvGrados.AllowUserToAddRows = false;
            dgvGrados.ReadOnly = true;

            dgvGrados.Rows.Clear();

            decimal margenContribucion = ventas - costoVentas;
            decimal uaiParaGaf = uaii - gastosFinancieros;

            // El GAO solo tiene sentido económico cuando la UAII es positiva.
            decimal? gao = (uaii > 0m && margenContribucion > 0m)
                ? (decimal?)(margenContribucion / uaii)
                : null;

            // El GAF requiere una UAII positiva y superior a los gastos financieros.
            decimal? gaf = (uaii > 0m && uaiParaGaf > 0m)
                ? (decimal?)(uaii / uaiParaGaf)
                : null;

            decimal? gat = (gao.HasValue && gaf.HasValue)
                ? (decimal?)(gao.Value * gaf.Value)
                : null;

            string interpGao;
            if (!gao.HasValue)
            {
                interpGao = uaii <= 0m
                    ? "No significativo: la UAII es negativa o cero; el GAO no es interpretable en este periodo."
                    : "No calculable: el margen de contribución es negativo o cero.";
            }
            else if (gao.Value > 2m)
            {
                interpGao = $"Alta sensibilidad operativa: por cada 1% de cambio en las ventas, la UAII cambia aproximadamente {gao.Value:N2}%. Estructura con costos fijos elevados.";
            }
            else if (gao.Value >= 1m)
            {
                interpGao = $"Sensibilidad operativa moderada: por cada 1% de cambio en las ventas, la UAII cambia aproximadamente {gao.Value:N2}%.";
            }
            else
            {
                interpGao = $"Sensibilidad operativa baja ({gao.Value:N2}x): predominan los costos variables y la UAII reacciona poco a las ventas.";
            }

            string interpGaf;
            if (!gaf.HasValue)
            {
                interpGaf = uaii <= 0m
                    ? "No significativo: la UAII es negativa o cero; el GAF no es interpretable en este periodo."
                    : "No calculable: la UAII no supera los gastos financieros o no hay deuda financiera relevante.";
            }
            else if (gaf.Value > 2m)
            {
                interpGaf = $"Alto impacto financiero: por cada 1% de cambio en la UAII, la utilidad antes de impuestos cambia aproximadamente {gaf.Value:N2}%.";
            }
            else if (gaf.Value >= 1m)
            {
                interpGaf = $"Impacto financiero moderado: por cada 1% de cambio en la UAII, la utilidad antes de impuestos cambia aproximadamente {gaf.Value:N2}%.";
            }
            else
            {
                interpGaf = $"Impacto financiero bajo ({gaf.Value:N2}x): la deuda financiera amplifica poco el resultado.";
            }

            string interpGat;
            if (!gat.HasValue)
            {
                interpGat = "No significativo: requiere un GAO y un GAF válidos (UAII positiva y superior a los gastos financieros).";
            }
            else if (gat.Value > 2m)
            {
                interpGat = $"Alto apalancamiento total: por cada 1% de cambio en las ventas, la utilidad neta cambia aproximadamente {gat.Value:N2}%.";
            }
            else if (gat.Value >= 1m)
            {
                interpGat = $"Apalancamiento total moderado: por cada 1% de cambio en las ventas, la utilidad neta cambia aproximadamente {gat.Value:N2}%.";
            }
            else
            {
                interpGat = $"Apalancamiento total bajo ({gat.Value:N2}x): menor amplificación del resultado frente a las ventas.";
            }

            dgvGrados.Rows.Add("Grado de Apalancamiento Operativo (GAO)",
                gao.HasValue ? gao.Value.ToString("N2") : "N/D", interpGao);
            dgvGrados.Rows.Add("Grado de Apalancamiento Financiero (GAF)",
                gaf.HasValue ? gaf.Value.ToString("N2") : "N/D", interpGaf);
            dgvGrados.Rows.Add("Grado de Apalancamiento Total (GAT)",
                gat.HasValue ? gat.Value.ToString("N2") : "N/D", interpGat);

            foreach (DataGridViewRow row in dgvGrados.Rows)
            {
                if (row.Cells[1].Value != null)
                {
                    row.Cells[1].Style.Font = new System.Drawing.Font(dgvGrados.Font, System.Drawing.FontStyle.Bold);
                }

                dgvGrados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                if (dgvGrados.Columns.Count >= 3)
                {
                    dgvGrados.Columns[0].Width = 300;
                    dgvGrados.Columns[1].Width = 90;
                    dgvGrados.Columns[2].Width = 900;
                }
            }

            // --- ANÁLISIS VERTICAL (% respecto a las Ventas) ---
            decimal porcVentas = 100m;
            decimal porcCostoVentas = (costoVentas / ventas) * 100m;
            decimal porcUtilBruta = (utilidadBruta / ventas) * 100m;
            decimal porcGastosOp = (gastosOperativos / ventas) * 100m;
            decimal porcUaii = (uaii / ventas) * 100m;
            decimal porcGastosFin = (gastosFinancieros / ventas) * 100m;
            decimal porcOtrosIng = (otrosIngresos / ventas) * 100m;
            decimal porcUai = (uai / ventas) * 100m;
            decimal porcImpuestos = (impuestos / ventas) * 100m;
            decimal porcUtilNeta = (utilidadNeta / ventas) * 100m;

            // --- LLENAR EL DATAGRIDVIEW CON EL ESQUEMA DEL ESTADO DE RESULTADOS ---
            dgvEstadoDeResultado.Rows.Add("Ventas", ventas.ToString("N2"), porcVentas.ToString("0.00") + "%", "Ventas");
            dgvEstadoDeResultado.Rows.Add("(-) Costo de ventas", costoVentas.ToString("N2"), porcCostoVentas.ToString("0.00") + "%", "Costo de ventas");
            dgvEstadoDeResultado.Rows.Add("= UTILIDAD BRUTA", utilidadBruta.ToString("N2"), porcUtilBruta.ToString("0.00") + "%", "Utilidad Bruta");

            dgvEstadoDeResultado.Rows.Add("(-) Gastos operativos", gastosOperativos.ToString("N2"), porcGastosOp.ToString("0.00") + "%", "Gastos operativos");
            dgvEstadoDeResultado.Rows.Add("= UTILIDAD OPERATIVA (EBIT)", uaii.ToString("N2"), porcUaii.ToString("0.00") + "%", "UAII");

            dgvEstadoDeResultado.Rows.Add("(-) Gastos financieros", gastosFinancieros.ToString("N2"), porcGastosFin.ToString("0.00") + "%", "Gastos financieros");
            dgvEstadoDeResultado.Rows.Add("(+) Otros ingresos", otrosIngresos.ToString("N2"), porcOtrosIng.ToString("0.00") + "%", "Otros ingresos");
            dgvEstadoDeResultado.Rows.Add("= UTILIDAD ANTES DE IMPUESTOS (UAI)", uai.ToString("N2"), porcUai.ToString("0.00") + "%", "UAI");

            dgvEstadoDeResultado.Rows.Add("(-) Impuestos", impuestos.ToString("N2"), porcImpuestos.ToString("0.00") + "%", "Impuestos");
            dgvEstadoDeResultado.Rows.Add("= UTILIDAD NETA", utilidadNeta.ToString("N2"), porcUtilNeta.ToString("0.00") + "%", "Utilidad Neta");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede generar el Estado de Resultados y Apalancamiento: " + ex.Message, "LookScan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cmbGradoApalancamiento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
