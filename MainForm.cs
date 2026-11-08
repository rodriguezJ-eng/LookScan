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

            txtEmpresa.TextChanged += (s, e) => Almacen.Empresa = txtEmpresa.Text.Trim();
            btnAnadirPeriodo.Click += (s, e) => AnadirPeriodo();
            cmbPeriodoActivo.SelectedIndexChanged += (s, e) =>
            {
                if (_sincronizando) return;
                var p = Almacen.Buscar(cmbPeriodoActivo.SelectedItem as string);
                if (p != null) Almacen.Activo = p;
            };
            Almacen.PeriodosCambiaron += SincronizarCombo;
            Almacen.ActivoCambio += SincronizarCombo;
            SincronizarCombo();
            CargarPeriodosEnComboBox();
            
            Almacen.DatosCambiaron += () => {
                txtEmpresa.Text = "ENEL";
            };
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

        private void CargarPeriodosEnComboBox()
        {
            
            cmbGradoApalancamiento.Items.Clear();

     
            foreach (var periodo in Almacen.Periodos)
            {
                cmbGradoApalancamiento.Items.Add(periodo.Nombre);
            }

            if (cmbGradoApalancamiento.Items.Count > 0)
            {
                cmbGradoApalancamiento.SelectedIndex = 0;
            }
        }
        private void btnGenerarErYapalancamiento_Click(object sender, EventArgs e)
        {

            string periodoSeleccionado = cmbGradoApalancamiento.Text;
            var periodo = Almacen.Periodos.FirstOrDefault(p => p.Nombre == periodoSeleccionado);

            if (periodo == null)
            {
                MessageBox.Show("Por favor, seleccione un período válido para analizar.", "LookScan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dgvEstadoDeResultado.Rows.Clear();

            var cuentasER = periodo.Cuentas.Where(c => c.Tipo == TipoEstado.ER).ToList();

            // Variables para capturar exactamente los montos de tus datos
            decimal ventas = 0m;
            decimal costoVentas = 0m;
            decimal totalGastosOp = 0m;
            decimal gastosFinancieros = 0m;
            decimal gastosOperativos = 0m;
            decimal otrosIngresos = 0m;
            decimal impuestos = 0m;

            // Recorrer las cuentas registradas en el periodo para extraer sus montos
            foreach (var cta in cuentasER)
            {
                string clasif = cta.Clasificacion != null ? cta.Clasificacion.ToLower().Trim() : "";

                if (clasif == "ventas" || cta.Clasificacion == Clasif.Ventas)
                {
                    ventas += cta.Monto;
                }
                else if (clasif == "costo de ventas" || cta.Clasificacion == Clasif.CostoVentas)
                {
                    costoVentas += cta.Monto;
                }
                else if (clasif == "gastos operativos" || cta.Clasificacion == Clasif.GastosOperativos)
                {
                    gastosOperativos += cta.Monto; // gastos operativos
                }
                else if (clasif == "gastos operativos" || cta.Clasificacion == Clasif.GastosOperativos)
                {
                    totalGastosOp += cta.Monto; // Acumula todos los gastos operativos
                }
                else if (clasif == "gastos financieros" || cta.Clasificacion == Clasif.GastosFinancieros)
                {
                    gastosFinancieros += cta.Monto; // Acumula todos los gastos financieros
                }
                else if (clasif == "otros ingresos" || cta.Clasificacion == Clasif.OtrosIngresos)
                {
                    otrosIngresos += cta.Monto; // Acumula todos los otros ingresos
                }
                else if (clasif == "impuestos" || cta.Clasificacion == Clasif.Impuestos)
                {
                    impuestos += cta.Monto; // Acumula todos los impuestos
                }
            }

            if (ventas == 0)
            {
                MessageBox.Show("El período seleccionado no registra ventas en el Estado de Resultados.", "LookScan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // ==========================================
            // CÁLCULO DE GRADOS DE APALANCAMIENTO
            // ==========================================

            // 1. Configurar columnas del DataGridView de Grados (si no están hechas en el diseñador)
            if (dgvGrados.Columns.Count == 0)
            {
                dgvGrados.Columns.Add("Concepto", "Indicador Financiero");
                dgvGrados.Columns.Add("Grado", "Grado / Multiplicador");
                dgvGrados.Columns.Add("Interpretacion", "Interpretación Automática");
                dgvGrados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

            dgvGrados.Rows.Clear();

            // 2. Definir costos fijos y variables aproximados según tus acumulados
            decimal margenContribucion = ventas - costoVentas;
            decimal costosFijos = gastosOperativos; // Asumiendo que tus gastos operativos actúan como fijos en el modelo
            decimal uaii = margenContribucion - costosFijos;
            decimal uai = uaii - gastosFinancieros; // Utilidad Antes de Impuestos

            // 3. Calcular los Grados de Apalancamiento de forma segura
            decimal gao = (uaii != 0) ? margenContribucion / uaii : 0m;
            string interpGao = gao > 1
                ? $"Por cada 1% que cambien las ventas, la UAII cambiará en un {gao:N2}%. Alto peso de costos fijos."
                : $"Sensibilidad operativa moderada ({gao:N2}x). Estructura de costos flexible.";

            decimal gaf = (uai != 0) ? uaii / uai : 0m;
            string interpGaf = gaf > 1
                ? $"Por cada 1% que cambie la UAII, la Utilidad Neta cambiará en un {gaf:N2}%. Alto endeudamiento financiero."
                : $"Estructura con bajo impacto de deuda financiera ({gaf:N2}x).";

            decimal gat = gao * gaf;
            string interpGat = gat > 1
                ? $"Por cada 1% que cambien las ventas, la Utilidad Neta final cambiará en un {gat:N2}%."
                : $"Apalancamiento total bajo ({gat:N2}x). Menor riesgo y menor amplificación de utilidades.";

            // 4. Agregar los resultados al DataGridView de Grados
            dgvGrados.Rows.Add("Grado de Apalancamiento Operativo (GAO)", gao.ToString("N2"), interpGao);
            dgvGrados.Rows.Add("Grado de Apalancamiento Financiero (GAF)", gaf.ToString("N2"), interpGaf);
            dgvGrados.Rows.Add("Grado de Apalancamiento Total (GAT)", gat.ToString("N2"), interpGat);

            // Dar formato de negrita a la columna de Grado
            foreach (DataGridViewRow row in dgvGrados.Rows)
            {
                // Verificamos que la celda exista para evitar errores en filas vacías o de totales
                if (row.Cells[1].Value != null)
                {
                    row.Cells[1].Style.Font = new System.Drawing.Font(dgvGrados.Font, System.Drawing.FontStyle.Bold);
                }
                dgvGrados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                // Asegurar que las columnas existan antes de cambiar el ancho
                if (dgvGrados.Columns.Count >= 3)
                {
                    dgvGrados.Columns[0].Width = 300; // Columna 0: Concepto
                    dgvGrados.Columns[1].Width = 90;  // Columna 1: Grado
                    dgvGrados.Columns[2].Width = 900; // Columna 2: Interpretación
                }
            }


            // --- CÁLCULOS SECUENCIALES DEL ESQUEMA ---
            decimal utilidadBruta = ventas - costoVentas;
            uaii = utilidadBruta - gastosOperativos;
            uai = uaii - gastosFinancieros + otrosIngresos;
            decimal utilidadNeta = uai - impuestos; // Utilidad Neta

            // --- ANÁLISIS VERTICAL (% respecto a las Ventas) ---
            decimal porcVentas = 100m;
            decimal porcCostoVentas = (ventas > 0) ? (costoVentas / ventas) * 100 : 0;
            decimal porcUtilBruta = (ventas > 0) ? (utilidadBruta / ventas) * 100 : 0;
            decimal porcGastosOp = (ventas > 0) ? (gastosOperativos / ventas) * 100 : 0;
            decimal porcUaii = (ventas > 0) ? (uaii / ventas) * 100 : 0;
            decimal porcGastosFin = (ventas > 0) ? (gastosFinancieros / ventas) * 100 : 0;
            decimal porcOtrosIng = (ventas > 0) ? (otrosIngresos / ventas) * 100 : 0;
            decimal porcUai = (ventas > 0) ? (uai / ventas) * 100 : 0;
            decimal porcImpuestos = (ventas > 0) ? (impuestos / ventas) * 100 : 0;
            decimal porcUtilNeta = (ventas > 0) ? (utilidadNeta / ventas) * 100 : 0;

            // --- LLENAR EL DATAGRIDVIEW CON EL ESQUEMA EXACTO Y TUS DATOS ---
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

        private void cmbGradoApalancamiento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
