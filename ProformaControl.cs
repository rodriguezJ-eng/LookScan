using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LookScan
{
    public partial class ProformaControl : UserControl
    {
        private ResultadoProforma _resultado;
        private bool _cargando;

        public ProformaControl()
        {
            InitializeComponent();
            if (Util.EnDiseno) return;

            // Los valores de los controles numéricos se expresan en porcentaje.
            numCrecVentas.Value = 5m;
            numImpuestos.Value = 29.5m;
            numRetenidas.Value = 50m;

            cmbPeriodoProforma.SelectedIndexChanged += (s, e) =>
            {
                if (_cargando) return;
                ActualizarConfiguracion();
            };

            btnGenerarProyeccion.Click += (s, e) => GenerarProyeccion(true);
            btnGuardarProyeccion.Click += (s, e) => GuardarProyeccion();
            btnExportarProformaExcel.Click += (s, e) => ExportarExcel();

            Almacen.PeriodosCambiaron += CargarCombosProforma;
            Almacen.DatosCambiaron += CargarCombosProforma;
            Almacen.ActivoCambio += CargarCombosProforma;

            CargarCombosProforma();
        }

        // ── Periodos base ────────────────────────────────────────────────────

        private void CargarCombosProforma()
        {
            if (_cargando) return;

            _cargando = true;
            try
            {
                string anterior = cmbPeriodoProforma.SelectedItem as string;

                cmbPeriodoProforma.Items.Clear();

                var periodos = Almacen.Periodos
                    .Where(p => p.TieneDatos)
                    .OrderBy(p => p.Nombre, StringComparer.Ordinal)
                    .ToList();

                foreach (Periodo p in periodos)
                    cmbPeriodoProforma.Items.Add(p.Nombre);

                if (cmbPeriodoProforma.Items.Count == 0)
                {
                    cmbPeriodoProforma.SelectedIndex = -1;
                    return;
                }

                int indice = -1;

                if (!string.IsNullOrWhiteSpace(anterior))
                {
                    for (int i = 0; i < cmbPeriodoProforma.Items.Count; i++)
                    {
                        if (Util.Igual(cmbPeriodoProforma.Items[i].ToString(), anterior))
                        {
                            indice = i;
                            break;
                        }
                    }
                }

                if (indice < 0 && Almacen.Activo != null)
                {
                    for (int i = 0; i < cmbPeriodoProforma.Items.Count; i++)
                    {
                        if (Util.Igual(cmbPeriodoProforma.Items[i].ToString(), Almacen.Activo.Nombre))
                        {
                            indice = i;
                            break;
                        }
                    }
                }

                if (indice < 0) indice = cmbPeriodoProforma.Items.Count - 1;
                cmbPeriodoProforma.SelectedIndex = indice;
            }
            finally
            {
                _cargando = false;
            }

            ActualizarConfiguracion();
        }

        private Periodo PeriodoSeleccionado()
        {
            string nombre = cmbPeriodoProforma.SelectedItem as string;
            if (string.IsNullOrWhiteSpace(nombre)) return null;

            Periodo periodo = Almacen.Buscar(nombre);
            return periodo != null && periodo.TieneDatos ? periodo : null;
        }

        private decimal Crecimiento()
        {
            return numCrecVentas.Value / 100m;
        }

        private decimal TasaImpuestos()
        {
            return numImpuestos.Value / 100m;
        }

        private decimal Retencion()
        {
            return numRetenidas.Value / 100m;
        }

        // ── Configuración de cuentas ─────────────────────────────────────────

        private void ActualizarConfiguracion()
        {
            Periodo baseP = PeriodoSeleccionado();

            if (baseP == null)
            {
                dgvConfigCuentas.Rows.Clear();
                return;
            }

            try
            {
                ResultadoProforma temporal = Proforma.Generar(
                    baseP, (int)numAnios.Value, Crecimiento(), TasaImpuestos(), Retencion());

                MostrarConfiguracion(temporal.Config);
            }
            catch (Exception ex)
            {
                dgvConfigCuentas.Rows.Clear();
                MessageBox.Show("No se pudo preparar la configuración: " + ex.Message,
                    "LookScan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void MostrarConfiguracion(IEnumerable<FilaConfigProyeccion> filas)
        {
            dgvConfigCuentas.Rows.Clear();

            if (filas == null) return;

            foreach (FilaConfigProyeccion fila in filas)
            {
                dgvConfigCuentas.Rows.Add(
                    fila.Cuenta,
                    Util.Monto(fila.MontoBase),
                    fila.Metodo,
                    fila.Valor);
            }
        }

        // ── Generación ───────────────────────────────────────────────────────

        private bool GenerarProyeccion(bool avisar)
        {
            Periodo baseP = PeriodoSeleccionado();

            if (baseP == null)
            {
                UtilUI.Aviso("Seleccione un periodo base con datos para generar la proyección.");
                return false;
            }

            try
            {
                _resultado = Proforma.Generar(
                    baseP, (int)numAnios.Value, Crecimiento(), TasaImpuestos(), Retencion());

                MostrarConfiguracion(_resultado.Config);
                MostrarResultados();

                if (avisar)
                {
                    tabProforma.SelectedIndex = 1;
                    UtilUI.Aviso("Proyección generada para " + _resultado.Periodos.Count + " año(s).");
                }

                return true;
            }
            catch (Exception ex)
            {
                _resultado = null;
                MessageBox.Show("No se pudo generar la proyección: " + ex.Message,
                    "LookScan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private void MostrarResultados()
        {
            if (_resultado == null || _resultado.Periodos.Count == 0) return;

            MostrarEstadoResultados();
            MostrarBalance();
            MostrarFlujo();
        }

        private void MostrarEstadoResultados()
        {
            List<Periodo> periodos = _resultado.Periodos;
            PrepararColumnas(dgvProfER, "Cuenta", periodos.Select(p => p.Nombre));

            foreach (Cuenta representante in CuentasOrdenadas(periodos, TipoEstado.ER))
            {
                string clave = Util.Clave(representante.Nombre);
                object[] valores = new object[periodos.Count + 1];
                valores[0] = representante.Nombre;

                for (int i = 0; i < periodos.Count; i++)
                    valores[i + 1] = Util.Monto(MontoDe(periodos[i], TipoEstado.ER, clave));

                dgvProfER.Rows.Add(valores);
            }

            AgregarTotal(dgvProfER, "Ventas", periodos, Calculos.Ventas);
            AgregarTotal(dgvProfER, "Utilidad bruta", periodos, Calculos.UtilidadBruta);
            AgregarTotal(dgvProfER, "Utilidad operativa", periodos, Calculos.UtilidadOperativa);
            AgregarTotal(dgvProfER, "Utilidad antes de impuestos", periodos, Calculos.UtilidadAntesImpuestos);
            AgregarTotal(dgvProfER, "Utilidad neta", periodos, Calculos.UtilidadNeta);
        }

        private void MostrarBalance()
        {
            List<Periodo> periodos = _resultado.Periodos;
            PrepararColumnas(dgvProfBG, "Cuenta", periodos.Select(p => p.Nombre));

            foreach (Cuenta representante in CuentasOrdenadas(periodos, TipoEstado.BG))
            {
                string clave = Util.Clave(representante.Nombre);
                object[] valores = new object[periodos.Count + 1];
                valores[0] = representante.Nombre;

                for (int i = 0; i < periodos.Count; i++)
                    valores[i + 1] = Util.Monto(MontoDe(periodos[i], TipoEstado.BG, clave));

                dgvProfBG.Rows.Add(valores);
            }

            AgregarTotal(dgvProfBG, "Total activo", periodos, Calculos.ActivoTotal);
            AgregarTotal(dgvProfBG, "Total pasivo", periodos, Calculos.PasivoTotal);
            AgregarTotal(dgvProfBG, "Total patrimonio", periodos, Calculos.Patrimonio);
            AgregarTotal(dgvProfBG, "Total pasivo y patrimonio", periodos, Calculos.PasivoYPatrimonio);
        }

        private void MostrarFlujo()
        {
            PrepararColumnas(dgvProfFE, "Concepto", new[] { "Monto" });

            for (int i = 0; i < _resultado.Flujos.Count; i++)
            {
                string nombre = i < _resultado.Periodos.Count
                    ? _resultado.Periodos[i].Nombre
                    : "Año " + (i + 1).ToString();

                int indice = dgvProfFE.Rows.Add("FLUJO DE EFECTIVO — " + nombre);
                dgvProfFE.Rows[indice].DefaultCellStyle.Font =
                    new Font(dgvProfFE.Font, FontStyle.Bold);
                dgvProfFE.Rows[indice].DefaultCellStyle.BackColor = Color.FromArgb(240, 243, 246);

                foreach (FilaEfe fila in _resultado.Flujos[i].Filas)
                {
                    if (fila.Encabezado)
                    {
                        int encabezado = dgvProfFE.Rows.Add(fila.Concepto);
                        dgvProfFE.Rows[encabezado].DefaultCellStyle.Font =
                            new Font(dgvProfFE.Font, FontStyle.Bold);
                    }
                    else
                    {
                        int renglon = dgvProfFE.Rows.Add(fila.Concepto, Util.Monto(fila.Monto));

                        if (fila.Total)
                        {
                            dgvProfFE.Rows[renglon].DefaultCellStyle.Font =
                                new Font(dgvProfFE.Font, FontStyle.Bold);
                        }
                    }
                }

                if (i < _resultado.Flujos.Count - 1)
                    dgvProfFE.Rows.Add(string.Empty);
            }
        }

        // ── Acciones ─────────────────────────────────────────────────────────

        private void GuardarProyeccion()
        {
            if (_resultado == null || _resultado.Periodos.Count == 0)
            {
                if (!GenerarProyeccion(false)) return;
            }

            try
            {
                List<Periodo> agregados = Almacen.AgregarProyeccion(_resultado.Periodos);

                if (agregados.Count == 0)
                {
                    UtilUI.Aviso("No se agregaron periodos proyectados al almacén.");
                    return;
                }

                Repositorio.GuardarProyectoActual();

                string nombres = string.Join(", ", agregados.Select(p => p.Nombre));
                UtilUI.Aviso("Proyección guardada. Periodos añadidos: " + nombres +
                             ".\nEl proyecto quedó guardado en disco.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar la proyección: " + ex.Message,
                    "LookScan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ExportarExcel()
        {
            if (_resultado == null || _resultado.Periodos.Count == 0)
            {
                if (!GenerarProyeccion(false)) return;
            }

            using (var dialogo = new SaveFileDialog())
            {
                dialogo.Title = "Exportar proforma a Excel";
                dialogo.Filter = "Libro de Excel (*.xls)|*.xls";
                dialogo.FileName = "Proforma LookScan.xls";
                dialogo.AddExtension = true;
                dialogo.OverwritePrompt = true;

                if (dialogo.ShowDialog() != DialogResult.OK) return;

                try
                {
                    Exportador.GuardarProformaExcel(_resultado, dialogo.FileName);
                    UtilUI.Aviso("Proforma exportada en:\n" + dialogo.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo exportar la proforma: " + ex.Message,
                        "LookScan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // ── Auxiliares de presentación ───────────────────────────────────────

        private static void PrepararColumnas(DataGridView grid, string primera,
                                             IEnumerable<string> columnas)
        {
            grid.Columns.Clear();
            grid.Rows.Clear();
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            var columnaCuenta = new DataGridViewTextBoxColumn
            {
                HeaderText = primera,
                Name = "colCuenta",
                FillWeight = 220F,
                ReadOnly = true
            };
            grid.Columns.Add(columnaCuenta);

            int indice = 1;

            foreach (string nombre in columnas)
            {
                var columna = new DataGridViewTextBoxColumn
                {
                    HeaderText = nombre,
                    Name = "col" + indice,
                    FillWeight = 100F,
                    ReadOnly = true
                };
                grid.Columns.Add(columna);
                indice++;
            }
        }

        private static void AgregarTotal(DataGridView grid, string etiqueta,
                                         List<Periodo> periodos, Func<Periodo, decimal> selector)
        {
            object[] valores = new object[periodos.Count + 1];
            valores[0] = etiqueta;

            for (int i = 0; i < periodos.Count; i++)
                valores[i + 1] = Util.Monto(selector(periodos[i]));

            int indice = grid.Rows.Add(valores);
            grid.Rows[indice].DefaultCellStyle.Font = new Font(grid.Font, FontStyle.Bold);
        }

        private static List<Cuenta> CuentasOrdenadas(IEnumerable<Periodo> periodos, TipoEstado tipo)
        {
            var representantes = new Dictionary<string, Cuenta>(StringComparer.Ordinal);

            foreach (Periodo periodo in periodos)
            {
                foreach (Cuenta cuenta in periodo.Cuentas.Where(c => c.Tipo == tipo))
                {
                    string clave = Util.Clave(cuenta.Nombre);
                    if (clave.Length == 0) continue;
                    if (!representantes.ContainsKey(clave)) representantes[clave] = cuenta;
                }
            }

            return representantes.Values
                .OrderBy(c => Clasif.Orden(c.Clasificacion))
                .ThenBy(c => Util.Clave(c.Nombre))
                .ToList();
        }

        private static decimal MontoDe(Periodo periodo, TipoEstado tipo, string clave)
        {
            decimal total = 0m;

            foreach (Cuenta cuenta in periodo.Cuentas)
            {
                if (cuenta.Tipo != tipo) continue;
                if (Util.Clave(cuenta.Nombre) != clave) continue;

                total += cuenta.Monto;
            }

            return total;
        }

        private void dgvConfigCuentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
