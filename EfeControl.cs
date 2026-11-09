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

            decimal efectivoInicial = EfectivoBalance(periodoBase);
            decimal efectivoFinal = EfectivoBalance(periodoComp);

            // Se comparan las cuentas de balance por nombre normalizado.
            var montosBase = new Dictionary<string, decimal>(StringComparer.Ordinal);
            var montosComp = new Dictionary<string, decimal>(StringComparer.Ordinal);
            var representantes = new Dictionary<string, Cuenta>(StringComparer.Ordinal);

            foreach (Cuenta cuenta in periodoBase.BG)
            {
                string clave = Util.Clave(cuenta.Nombre);
                if (clave.Length == 0) continue;

                if (!montosBase.ContainsKey(clave)) montosBase[clave] = 0m;
                montosBase[clave] += cuenta.Monto;

                if (!representantes.ContainsKey(clave)) representantes[clave] = cuenta;
            }

            foreach (Cuenta cuenta in periodoComp.BG)
            {
                string clave = Util.Clave(cuenta.Nombre);
                if (clave.Length == 0) continue;

                if (!montosComp.ContainsKey(clave)) montosComp[clave] = 0m;
                montosComp[clave] += cuenta.Monto;

                if (!representantes.ContainsKey(clave)) representantes[clave] = cuenta;
            }

            var claves = montosBase.Keys
                .Union(montosComp.Keys)
                .OrderBy(k => Clasif.Orden(representantes[k].Clasificacion))
                .ThenBy(k => k)
                .ToList();

            var cambiosOperacion = new List<CambioCuenta>();
            var cambiosInversion = new List<CambioCuenta>();
            var cambiosFinanciacion = new List<CambioCuenta>();

            decimal ajusteNoMonetario = 0m;

            foreach (string clave in claves)
            {
                decimal montoBase = montosBase.ContainsKey(clave) ? montosBase[clave] : 0m;
                decimal montoComp = montosComp.ContainsKey(clave) ? montosComp[clave] : 0m;
                decimal cambio = montoComp - montoBase;

                if (cambio == 0m) continue;

                Cuenta cuenta = representantes[clave];
                var categoria = Clasif.ClasificadorEfe.ObtenerCategoria(cuenta);

                if (categoria == Clasif.ClasificadorEfe.CategoriaEfe.Efectivo) continue;

                if (categoria == Clasif.ClasificadorEfe.CategoriaEfe.NoAfecta)
                {
                    string n = Util.Clave(cuenta.Nombre);

                    // El déficit o los resultados acumulados ya se explican por la utilidad neta.
                    bool esResultadoAcumulado = n.Contains("deficit acumulado") ||
                                                n.Contains("resultados acumulados") ||
                                                n.Contains("utilidades retenidas") ||
                                                n.Contains("perdidas acumuladas");

                    if (!esResultadoAcumulado) ajusteNoMonetario += cambio;
                    continue;
                }

                var item = new CambioCuenta { Cuenta = cuenta, Cambio = cambio };

                if (categoria == Clasif.ClasificadorEfe.CategoriaEfe.Operacion)
                    cambiosOperacion.Add(item);
                else if (categoria == Clasif.ClasificadorEfe.CategoriaEfe.Inversion)
                    cambiosInversion.Add(item);
                else if (categoria == Clasif.ClasificadorEfe.CategoriaEfe.Financiacion)
                    cambiosFinanciacion.Add(item);
            }

            decimal utilidadNeta = Calculos.UtilidadNeta(periodoComp);
            decimal ajustesOperacion = 0m;

            foreach (var item in cambiosOperacion)
            {
                bool esActivo = Clasif.EsActivo(item.Cuenta.Clasificacion);
                ajustesOperacion += esActivo ? -item.Cambio : item.Cambio;
            }

            decimal flujoOperacionIndirecto = utilidadNeta + ajustesOperacion + ajusteNoMonetario;

            decimal flujoInversion = cambiosInversion.Sum(x => -x.Cambio);
            decimal flujoFinanciamiento = cambiosFinanciacion.Sum(x => x.Cambio);
            decimal flujoOperacionDirecto = 0m;

            if (rbMetodo1.Checked)
            {
                dgvEfe.Rows.Add("FLUJOS DE EFECTIVO DE LAS ACTIVIDADES DE OPERACIÓN (MÉTODO INDIRECTO)");

                dgvEfe.Rows.Add("Utilidad neta del ejercicio", Util.Monto(utilidadNeta));

                foreach (var item in cambiosOperacion)
                {
                    bool esActivo = Clasif.EsActivo(item.Cuenta.Clasificacion);
                    decimal efecto = esActivo ? -item.Cambio : item.Cambio;
                    string etiqueta = EtiquetaOperacion(item.Cuenta, item.Cambio, esActivo);
                    dgvEfe.Rows.Add(etiqueta, Util.Monto(efecto));
                }

                if (ajusteNoMonetario != 0m)
                {
                    dgvEfe.Rows.Add("(+/-) Ajuste no monetario (revaluaciones y otros)", Util.Monto(ajusteNoMonetario));
                }

                int filaOperacion = dgvEfe.Rows.Add(
                    "EFECTIVO NETO PROVISTO POR ACTIVIDADES DE OPERACIÓN",
                    Util.Monto(flujoOperacionIndirecto));
                dgvEfe.Rows[filaOperacion].DefaultCellStyle.Font = new Font(dgvEfe.Font, FontStyle.Bold);
            }
            else
            {
                dgvEfe.Rows.Add("FLUJOS DE EFECTIVO DE LAS ACTIVIDADES DE OPERACIÓN (MÉTODO DIRECTO)");

                decimal ventas = Calculos.Ventas(periodoComp);
                decimal costoVentas = Calculos.CostoVentas(periodoComp);
                decimal gastosOperativos = Calculos.GastosOperativos(periodoComp);
                decimal gastosFinancieros = Calculos.GastosFinancieros(periodoComp);
                decimal otrosIngresos = Calculos.OtrosIngresos(periodoComp);
                decimal impuestos = Calculos.Impuestos(periodoComp);

                decimal varCxC = 0m;
                decimal varInventario = 0m;
                decimal varGastoAnticipado = 0m;
                decimal varCxPComercial = 0m;
                decimal varGastoAcumulado = 0m;
                decimal varIntereses = 0m;
                decimal varOtros = 0m;

                foreach (var item in cambiosOperacion)
                {
                    Cuenta cuenta = item.Cuenta;
                    decimal cambio = item.Cambio;

                    if (Clasif.ClasificadorEfe.EsCxC(cuenta)) varCxC += cambio;
                    else if (Clasif.ClasificadorEfe.EsInventario(cuenta)) varInventario += cambio;
                    else if (Clasif.ClasificadorEfe.EsGastoAnticipado(cuenta)) varGastoAnticipado += cambio;
                    else if (Clasif.ClasificadorEfe.EsGastoAcumulado(cuenta)) varGastoAcumulado += cambio;
                    else if (Clasif.ClasificadorEfe.EsInteresPorPagar(cuenta)) varIntereses += cambio;
                    else if (Clasif.ClasificadorEfe.EsCxPComercial(cuenta)) varCxPComercial += cambio;
                    else varOtros += Clasif.EsActivo(cuenta.Clasificacion) ? -cambio : cambio;
                }

                decimal cobrosClientes = ventas - varCxC;
                decimal pagosProveedores = -(costoVentas + varInventario - varCxPComercial);
                decimal pagosGastosOperativos = -(gastosOperativos - varGastoAcumulado);
                decimal pagoIntereses = -(gastosFinancieros - varIntereses);
                decimal otrosMovimientos = -varGastoAnticipado + varOtros;

                flujoOperacionDirecto = cobrosClientes + pagosProveedores + pagosGastosOperativos +
                                        otrosIngresos - impuestos + pagoIntereses +
                                        otrosMovimientos + ajusteNoMonetario;

                dgvEfe.Rows.Add("(+) Cobros procedentes de clientes", Util.Monto(cobrosClientes));
                dgvEfe.Rows.Add("(-) Pagos a proveedores y costos", Util.Monto(pagosProveedores));
                dgvEfe.Rows.Add("(-) Pagos por gastos operativos", Util.Monto(pagosGastosOperativos));

                if (otrosIngresos != 0m)
                    dgvEfe.Rows.Add("(+) Otros ingresos operativos", Util.Monto(otrosIngresos));

                if (impuestos != 0m)
                    dgvEfe.Rows.Add("(-) Pago de impuestos", Util.Monto(-impuestos));

                if (gastosFinancieros != 0m || varIntereses != 0m)
                    dgvEfe.Rows.Add("(-) Pago de intereses", Util.Monto(pagoIntereses));

                if (otrosMovimientos != 0m)
                    dgvEfe.Rows.Add("(+/-) Otros movimientos operativos", Util.Monto(otrosMovimientos));

                if (ajusteNoMonetario != 0m)
                    dgvEfe.Rows.Add("(+/-) Ajuste no monetario (revaluaciones y otros)", Util.Monto(ajusteNoMonetario));

                int filaOperacionDirecta = dgvEfe.Rows.Add(
                    "EFECTIVO NETO PROVISTO POR ACTIVIDADES DE OPERACIÓN",
                    Util.Monto(flujoOperacionDirecto));
                dgvEfe.Rows[filaOperacionDirecta].DefaultCellStyle.Font = new Font(dgvEfe.Font, FontStyle.Bold);
            }

            dgvEfe.Rows.Add("FLUJOS DE EFECTIVO DE LAS ACTIVIDADES DE INVERSIÓN");

            foreach (var item in cambiosInversion)
            {
                string etiqueta = item.Cambio > 0m
                    ? "(-) Aumento / adquisición de " + item.Cuenta.Nombre
                    : "(+) Disminución / venta de " + item.Cuenta.Nombre;

                dgvEfe.Rows.Add(etiqueta, Util.Monto(-item.Cambio));
            }

            int filaInversion = dgvEfe.Rows.Add(
                "EFECTIVO NETO USADO EN ACTIVIDADES DE INVERSIÓN",
                Util.Monto(flujoInversion));
            dgvEfe.Rows[filaInversion].DefaultCellStyle.Font = new Font(dgvEfe.Font, FontStyle.Bold);

            dgvEfe.Rows.Add("FLUJOS DE EFECTIVO DE LAS ACTIVIDADES DE FINANCIACIÓN");

            foreach (var item in cambiosFinanciacion)
            {
                string etiqueta = item.Cambio > 0m
                    ? "(+) Incremento / obtención de " + item.Cuenta.Nombre
                    : "(-) Amortización / disminución de " + item.Cuenta.Nombre;

                dgvEfe.Rows.Add(etiqueta, Util.Monto(item.Cambio));
            }

            int filaFinanciamiento = dgvEfe.Rows.Add(
                "EFECTIVO NETO USADO EN ACTIVIDADES DE FINANCIACIÓN",
                Util.Monto(flujoFinanciamiento));
            dgvEfe.Rows[filaFinanciamiento].DefaultCellStyle.Font = new Font(dgvEfe.Font, FontStyle.Bold);

            // Cada método debe reconciliar el mismo efectivo final.
            decimal flujoOperacion = rbMetodo1.Checked
                ? flujoOperacionIndirecto
                : flujoOperacionDirecto;

            decimal incrementoNeto = flujoOperacion + flujoInversion + flujoFinanciamiento;
            decimal efectivoCalculado = efectivoInicial + incrementoNeto;

            int filaIncremento = dgvEfe.Rows.Add(
                "INCREMENTO NETO DE EFECTIVO Y EQUIVALENTES",
                Util.Monto(incrementoNeto));
            dgvEfe.Rows[filaIncremento].DefaultCellStyle.Font = new Font(dgvEfe.Font, FontStyle.Bold);

            dgvEfe.Rows.Add("(+) Efectivo y equivalentes al inicio del período", Util.Monto(efectivoInicial));

            int filaFinal = dgvEfe.Rows.Add(
                "(=) EFECTIVO Y EQUIVALENTES AL FINAL DEL PERÍODO",
                Util.Monto(efectivoCalculado));
            dgvEfe.Rows[filaFinal].DefaultCellStyle.Font = new Font(dgvEfe.Font, FontStyle.Bold);

            dgvEfe.Rows.Add("Efectivo final según el balance", Util.Monto(efectivoFinal));

            int filaDiferencia = dgvEfe.Rows.Add(
                "Diferencia (calculado - balance)",
                Util.Monto(efectivoCalculado - efectivoFinal));
            dgvEfe.Rows[filaDiferencia].DefaultCellStyle.Font = new Font(dgvEfe.Font, FontStyle.Bold);

            foreach (DataGridViewRow row in dgvEfe.Rows)
            {
                if (row.Cells[0].Value != null &&
                    row.Cells[0].Value.ToString().StartsWith("FLUJOS DE EFECTIVO"))
                {
                    row.DefaultCellStyle.Font = new Font(dgvEfe.Font, FontStyle.Bold);
                    row.DefaultCellStyle.BackColor = Color.FromArgb(240, 243, 246);
                }
            }
        }

        private static decimal EfectivoBalance(Periodo periodo)
        {
            if (periodo == null) return 0m;

            decimal total = 0m;

            foreach (Cuenta cuenta in periodo.BG)
            {
                if (Clasif.ClasificadorEfe.ObtenerCategoria(cuenta) ==
                    Clasif.ClasificadorEfe.CategoriaEfe.Efectivo)
                {
                    total += cuenta.Monto;
                }
            }

            return total;
        }

        private static string EtiquetaOperacion(Cuenta cuenta, decimal cambio, bool esActivo)
        {
            if (esActivo)
            {
                return cambio > 0m
                    ? "(-) Aumento de " + cuenta.Nombre
                    : "(+) Disminución de " + cuenta.Nombre;
            }

            return cambio > 0m
                ? "(+) Aumento de " + cuenta.Nombre
                : "(-) Disminución de " + cuenta.Nombre;
        }
    }
}
