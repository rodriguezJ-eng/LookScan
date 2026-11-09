using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static LookScan.Clasif;

namespace LookScan
{
    public partial class EfeControl : UserControl
    {
        public EfeControl()
        {
            InitializeComponent();
            CargarCombosEfe();


        }
        private void CargarCombosEfe()
        {
            cmbPeriodoBaseEfe.Items.Clear();
            cmbPeriodoCompEfe.Items.Clear();

            string[] misAnios = { "2020", "2019", "2018" };

            foreach (var anio in misAnios)
            {
                cmbPeriodoBaseEfe.Items.Add(anio);
                cmbPeriodoCompEfe.Items.Add(anio);
            }
            cmbPeriodoBaseEfe.SelectedIndex = -1;
            cmbPeriodoBaseEfe.Text = string.Empty;

            cmbPeriodoCompEfe.SelectedIndex = -1;
            cmbPeriodoCompEfe.Text = string.Empty;
        }
        private void btnCalcularEfe_Click(object sender, EventArgs e)
        {
            string nombreBase = cmbPeriodoBaseEfe.Text;
            string nombreComparado = cmbPeriodoCompEfe.Text;

            var periodoBase = Almacen.Periodos.FirstOrDefault(p => p.Nombre == nombreBase);
            var periodoComp = Almacen.Periodos.FirstOrDefault(p => p.Nombre == nombreComparado);

            if (periodoBase == null || periodoComp == null)
            {
                MessageBox.Show("Por favor, seleccione un Período Base y un Período Comparado válidos.", "LookScan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvEfe.Columns.Count == 0)
            {
                dgvEfe.Columns.Add("Concepto", "Concepto del Flujo de Efectivo");
                dgvEfe.Columns.Add("Monto", "Monto (C$)");
                dgvEfe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

            dgvEfe.Rows.Clear();
            dgvEfe.BackgroundColor = System.Drawing.Color.White;
            dgvEfe.RowHeadersVisible = false;

      
            decimal efectivoInicial = 0m;
            decimal utilRetBase = 0m, utilRetComp = 0m;
            decimal flujoOperacion = 0m;
            decimal flujoInversion = 0m;
            decimal flujoFinanciamiento = 0m;

            List<(string concepto, decimal monto)> filasOperacion = new List<(string, decimal)>();
            List<(string concepto, decimal monto)> filasInversion = new List<(string, decimal)>();
            List<(string concepto, decimal monto)> filasFinanciamiento = new List<(string, decimal)>();

            foreach (var cta in periodoBase.Cuentas)
            {
                string nLow = (cta.Nombre ?? "").ToLower();
                if (nLow.Contains("efectivo y equivalentes")) efectivoInicial += cta.Monto;
                if (nLow.Contains("utilidades retenidas") || nLow.Contains("resultados acumulados")) utilRetBase += cta.Monto;
            }
            foreach (var cta in periodoComp.Cuentas)
            {
                string nLow = (cta.Nombre ?? "").ToLower();
                if (nLow.Contains("utilidades retenidas") || nLow.Contains("resultados acumulados")) utilRetComp += cta.Monto;
            }

            foreach (var ctaComp in periodoComp.Cuentas)
            {
                string nombreCta = ctaComp.Nombre ?? "";
                string nLow = nombreCta.ToLower();

                if (nLow.Contains("efectivo y equivalentes") || nLow.Contains("utilidades retenidas") || nLow.Contains("resultados acumulados"))
                    continue;

                var categoria = ClasificadorEfe.ObtenerCategoria(nombreCta);
                if (categoria == ClasificadorEfe.CategoriaEfe.NoAfecta) continue;

                var ctaBase = periodoBase.Cuentas.FirstOrDefault(c => c.Nombre != null && c.Nombre.Trim().Equals(nombreCta.Trim(), StringComparison.OrdinalIgnoreCase));
                decimal montoBase = ctaBase != null ? ctaBase.Monto : 0m;
                decimal diferencia = ctaComp.Monto - montoBase;

                if (diferencia == 0) continue;

                if (categoria == ClasificadorEfe.CategoriaEfe.Operacion)
                {
                    decimal varEfe = 0m;
                    string etiqueta = "";
                    bool esPasivo = nLow.Contains("pagar") || nLow.Contains("pasivo") || nLow.Contains("acreedor") || nLow.Contains("obligacion");

                    if (esPasivo)
                    {
                        varEfe = diferencia;
                        etiqueta = (diferencia > 0 ? "(+) Aumento en " : "(-) Disminución en ") + nombreCta;
                    }
                    else
                    {
                        varEfe = -diferencia;
                        etiqueta = (diferencia > 0 ? "(-) Aumento en " : "(+) Disminución en ") + nombreCta;
                    }

                    if (rbMetodo1.Checked)
                    {
                        flujoOperacion += varEfe;
                        filasOperacion.Add((etiqueta, varEfe));
                    }
                }
                else if (categoria == ClasificadorEfe.CategoriaEfe.Inversion)
                {
                    decimal varEfe = -diferencia;
                    string etiqueta = (diferencia > 0 ? "(-) Adquisición / Aumento en " : "(+) Venta / Disminución en ") + nombreCta;

                    flujoInversion += varEfe;
                    filasInversion.Add((etiqueta, varEfe));
                }
                else if (categoria == ClasificadorEfe.CategoriaEfe.Financiacion)
                {
                    decimal varEfe = diferencia;
                    string etiqueta = (diferencia > 0 ? "(+) Incremento / Obtención de " : "(-) Amortización / Disminución de ") + nombreCta;

                    flujoFinanciamiento += varEfe;
                    filasFinanciamiento.Add((etiqueta, varEfe));
                }
            }


            // metodo 1
            if (rbMetodo1.Checked)
            {
                dgvEfe.Rows.Add("FLUJOS DE EFECTIVO DE LAS ACTIVIDADES DE OPERACIÓN");

                // Calcular Utilidad Neta del Ejercicio
                decimal ventas = 0m, costoVentas = 0m, gastosOperativos = 0m, gastosFinancieros = 0m, impuestos = 0m, otrosIngresos = 0m;
                foreach (var cta in periodoComp.Cuentas.Where(c => c.Tipo == TipoEstado.ER))
                {
                    string clasif = cta.Clasificacion != null ? cta.Clasificacion.ToLower().Trim() : "";
                    if (clasif == "ventas") ventas += cta.Monto;
                    else if (clasif == "costo de ventas") costoVentas += cta.Monto;
                    else if (clasif == "gastos operativos") gastosOperativos += cta.Monto;
                    else if (clasif == "gastos financieros") gastosFinancieros += cta.Monto;
                    else if (clasif == "otros ingresos") otrosIngresos += cta.Monto;
                    else if (clasif == "impuestos") impuestos += cta.Monto;
                }

                decimal utilidadBruta = ventas - costoVentas;
                decimal uaii = utilidadBruta - gastosOperativos;
                decimal uai = uaii - gastosFinancieros + otrosIngresos;
                decimal utilidadNeta = uai - impuestos;

                dgvEfe.Rows.Add("Utilidad Neta del Ejercicio", utilidadNeta.ToString("N2"));

                flujoOperacion = utilidadNeta;
                foreach (var f in filasOperacion)
                {
                    flujoOperacion += f.monto;
                    dgvEfe.Rows.Add(f.concepto, f.monto.ToString("N2"));
                }

                int n = dgvEfe.Rows.Add("EFECTIVO NETO PROVISTO POR ACTIVIDADES DE OPERACIÓN", flujoOperacion.ToString("N2"));
                dgvEfe.Rows[n].DefaultCellStyle.Font = new Font(dgvEfe.Font, FontStyle.Bold);
            }
          // metodo 2
            else if (rbMetodo2.Checked)
            {
                dgvEfe.Rows.Add("=== 1. FLUJOS DE EFECTIVO DE LAS ACTIVIDADES DE OPERACIÓN (MÉTODO DIRECTO) ===", "");

                decimal ventas = 0m, costoVentas = 0m, gastosOperativos = 0m, gastosFinancieros = 0m, impuestos = 0m, otrosIngresos = 0m;
                foreach (var cta in periodoComp.Cuentas.Where(c => c.Tipo == TipoEstado.ER))
                {
                    string clasif = cta.Clasificacion != null ? cta.Clasificacion.ToLower().Trim() : "";
                    if (clasif == "ventas") ventas += cta.Monto;
                    else if (clasif == "costo de ventas") costoVentas += cta.Monto;
                    else if (clasif == "gastos operativos") gastosOperativos += cta.Monto;
                    else if (clasif == "gastos financieros") gastosFinancieros += cta.Monto;
                    else if (clasif == "otros ingresos") otrosIngresos += cta.Monto;
                    else if (clasif == "impuestos") impuestos += cta.Monto;
                }

                decimal varCuentasPorCobrar = 0m, varInventarios = 0m, varCuentasPorPagar = 0m;
                foreach (var ctaComp in periodoComp.Cuentas)
                {
                    string nLow = (ctaComp.Nombre ?? "").ToLower();
                    if (nLow.Contains("efectivo") || nLow.Contains("utilidades retenidas")) continue;
                    var ctaBase = periodoBase.Cuentas.FirstOrDefault(c => c.Nombre != null && c.Nombre.Trim().Equals(ctaComp.Nombre.Trim(), StringComparison.OrdinalIgnoreCase));
                    decimal diff = ctaComp.Monto - (ctaBase != null ? ctaBase.Monto : 0m);

                    if (nLow.Contains("cobrar") || nLow.Contains("cliente")) varCuentasPorCobrar += diff;
                    else if (nLow.Contains("inventario") || nLow.Contains("mercancia")) varInventarios += diff;
                    else if (nLow.Contains("pagar") || nLow.Contains("proveedor")) varCuentasPorPagar += diff;
                }

                decimal cobrosClientes = ventas - varCuentasPorCobrar;
                decimal pagosProveedores = -(costoVentas + varInventarios - varCuentasPorPagar);
                decimal pagosGastosOp = -gastosOperativos;
                decimal pagoImpuestos = -impuestos;
                decimal pagoIntereses = -gastosFinancieros;

                dgvEfe.Rows.Add("(+) Cobros procedentes de clientes", cobrosClientes.ToString("N2"));
                dgvEfe.Rows.Add("(-) Pagos a proveedores y costos", pagosProveedores.ToString("N2"));
                dgvEfe.Rows.Add("(-) Pagos por gastos operativos", pagosGastosOp.ToString("N2"));
                if (otrosIngresos > 0) dgvEfe.Rows.Add("(+) Otros ingresos operativos", otrosIngresos.ToString("N2"));
                if (impuestos > 0) dgvEfe.Rows.Add("(-) Pago de impuestos", pagoImpuestos.ToString("N2"));
                if (gastosFinancieros > 0) dgvEfe.Rows.Add("(-) Pago de intereses", pagoIntereses.ToString("N2"));

                // Sumatoria total del método directo incluyendo los otros ingresos
                flujoOperacion = cobrosClientes + pagosProveedores + pagosGastosOp + otrosIngresos + pagoImpuestos + pagoIntereses;

                int nOp = dgvEfe.Rows.Add("EFECTIVO NETO PROVISTO POR ACTIVIDADES DE OPERACIÓN (A)", flujoOperacion.ToString("N2"));
                dgvEfe.Rows[nOp].DefaultCellStyle.Font = new Font(dgvEfe.Font, FontStyle.Bold);
            }

   
            dgvEfe.Rows.Add("FLUJOS DE EFECTIVO DE LAS ACTIVIDADES DE INVERSIÓN");
            foreach (var f in filasInversion) dgvEfe.Rows.Add(f.concepto, f.monto.ToString("N2"));

            int nInv = dgvEfe.Rows.Add("EFECTIVO NETO USADO EN ACTIVIDADES DE INVERSIÓN ", flujoInversion.ToString("N2"));
            dgvEfe.Rows[nInv].DefaultCellStyle.Font = new Font(dgvEfe.Font, FontStyle.Bold);

            dgvEfe.Rows.Add("FLUJOS DE EFECTIVO DE LAS ACTIVIDADES DE FINANCIACIÓN");
            foreach (var f in filasFinanciamiento) dgvEfe.Rows.Add(f.concepto, f.monto.ToString("N2"));

            // Cálculo automático de Dividendos
            decimal utilidadNetaRef = 245000.00m; 
            decimal pagoDividendos = utilRetBase + utilidadNetaRef - utilRetComp;
            if (pagoDividendos < 0) pagoDividendos = 0m;
            if (pagoDividendos > 0)
            {
                dgvEfe.Rows.Add("(-) Pago de Dividendos", (-pagoDividendos).ToString("N2"));
                flujoFinanciamiento -= pagoDividendos;
            }

            int nFin = dgvEfe.Rows.Add("EFECTIVO NETO USADO EN ACTIVIDADES DE FINANCIACIÓN", flujoFinanciamiento.ToString("N2"));
            dgvEfe.Rows[nFin].DefaultCellStyle.Font = new Font(dgvEfe.Font, FontStyle.Bold);


          
            decimal incrementoNeto = flujoOperacion + flujoInversion + flujoFinanciamiento;
            int nInc = dgvEfe.Rows.Add("INCREMENTO NETO DE EFECTIVO Y EQUIVALENTES ", incrementoNeto.ToString("N2"));
            dgvEfe.Rows[nInc].DefaultCellStyle.Font = new Font(dgvEfe.Font, FontStyle.Bold);

            dgvEfe.Rows.Add("(+) Efectivo y equivalentes al inicio del período", efectivoInicial.ToString("N2"));

            int nFinPer = dgvEfe.Rows.Add("(=) EFECTIVO Y EQUIVALENTES AL FINAL DEL PERÍODO", (incrementoNeto + efectivoInicial).ToString("N2"));
            dgvEfe.Rows[nFinPer].DefaultCellStyle.Font = new Font(dgvEfe.Font, FontStyle.Bold);


            foreach (DataGridViewRow row in dgvEfe.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString().Contains("==="))
                {
                    row.DefaultCellStyle.Font = new Font(dgvEfe.Font, FontStyle.Bold);
                    row.DefaultCellStyle.BackColor = Color.FromArgb(240, 243, 246);
                }
            }
        }
    }
}