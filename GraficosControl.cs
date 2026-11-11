using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace LookScan
{
    public partial class GraficosControl : UserControl
    {
        private Chart _chart1;
        private Chart _chart2;
        private Chart _chart3;
        private Chart _chart4;
        private Chart _chart5;
        private Chart _chart6;

        private bool _inicializado;
        private bool _actualizandoCombos;

        public GraficosControl()
        {
            InitializeComponent();
            InicializarComponentesGraficos();
        }

        private void InicializarComponentesGraficos()
        {
            if (Util.EnDiseno) return;

            // Aseguramos que haya datos cargados en el Almacén para que los gráficos funcionen de inmediato
            if (!Almacen.HayDatos)
            {
                Almacen.CargarDemo();
            }

            // Crear y configurar los 6 controles Chart
            _chart1 = CrearChart("Chart1", pnlGrafico1, lblAreaGrafico1);
            _chart2 = CrearChart("Chart2", pnlGrafico2, lblAreaGrafico2);
            _chart3 = CrearChart("Chart3", pnlGrafico3, lblAreaGrafico3);
            _chart4 = CrearChart("Chart4", pnlGrafico4, lblAreaGrafico4);
            _chart5 = CrearChart("Chart5", pnlGrafico5, lblAreaGrafico5);
            _chart6 = CrearChart("Chart6", pnlGrafico6, lblAreaGrafico6);

            // Poblar combos de periodos
            SincronizarPeriodos();

            // Configurar selecciones por defecto en filtros
            _actualizandoCombos = true;
            try
            {
                if (cmbTopN.Items.Count > 0 && cmbTopN.SelectedIndex < 0) cmbTopN.SelectedItem = "5";
                if (cmbOrdenarPor.Items.Count > 0 && cmbOrdenarPor.SelectedIndex < 0) cmbOrdenarPor.SelectedItem = "Valor";
                if (cmbMostrar.Items.Count > 0 && cmbMostrar.SelectedIndex < 0) cmbMostrar.SelectedItem = "Monto";

                ConfigurarComboTipos(cmbTipoGrafico1, cmbEstiloGrafico1, "Barras", "Clásico");
                ConfigurarComboTipos(cmbTipoGrafico2, cmbEstiloGrafico2, "Barras", "Clásico");
                ConfigurarComboTipos(cmbTipoGrafico3, cmbEstiloGrafico3, "Barras", "Clásico");
                ConfigurarComboTipos(cmbTipoGrafico4, cmbEstiloGrafico4, "Barras", "Clásico");
                ConfigurarComboTipos(cmbTipoGrafico5, cmbEstiloGrafico5, "Barras", "Clásico");
                ConfigurarComboTipos(cmbTipoGrafico6, cmbEstiloGrafico6, "Barras", "Clásico");
            }
            finally
            {
                _actualizandoCombos = false;
            }

            // Eventos generales de la barra de herramientas
            btnActualizarTodos.Click += (s, e) => ActualizarTodosLosGraficos();
            cmbPeriodoBaseGraf.SelectedIndexChanged += (s, e) => { if (!_actualizandoCombos) ActualizarTodosLosGraficos(); };
            cmbPeriodoCompGraf.SelectedIndexChanged += (s, e) => { if (!_actualizandoCombos) ActualizarTodosLosGraficos(); };
            cmbTopN.SelectedIndexChanged += (s, e) => { if (!_actualizandoCombos) ActualizarGrafico1(); };
            cmbOrdenarPor.SelectedIndexChanged += (s, e) => { if (!_actualizandoCombos) ActualizarGrafico1(); };
            cmbMostrar.SelectedIndexChanged += (s, e) => { if (!_actualizandoCombos) ActualizarGrafico1(); };

            // Eventos por gráfico individual
            cmbTipoGrafico1.SelectedIndexChanged += (s, e) => { if (!_actualizandoCombos) ActualizarGrafico1(); };
            cmbEstiloGrafico1.SelectedIndexChanged += (s, e) => { if (!_actualizandoCombos) ActualizarGrafico1(); };

            cmbTipoGrafico2.SelectedIndexChanged += (s, e) => { if (!_actualizandoCombos) ActualizarGrafico2(); };
            cmbEstiloGrafico2.SelectedIndexChanged += (s, e) => { if (!_actualizandoCombos) ActualizarGrafico2(); };

            cmbTipoGrafico3.SelectedIndexChanged += (s, e) => { if (!_actualizandoCombos) ActualizarGrafico3(); };
            cmbEstiloGrafico3.SelectedIndexChanged += (s, e) => { if (!_actualizandoCombos) ActualizarGrafico3(); };

            cmbTipoGrafico4.SelectedIndexChanged += (s, e) => { if (!_actualizandoCombos) ActualizarGrafico4(); };
            cmbEstiloGrafico4.SelectedIndexChanged += (s, e) => { if (!_actualizandoCombos) ActualizarGrafico4(); };

            cmbTipoGrafico5.SelectedIndexChanged += (s, e) => { if (!_actualizandoCombos) ActualizarGrafico5(); };
            cmbEstiloGrafico5.SelectedIndexChanged += (s, e) => { if (!_actualizandoCombos) ActualizarGrafico5(); };

            cmbTipoGrafico6.SelectedIndexChanged += (s, e) => { if (!_actualizandoCombos) ActualizarGrafico6(); };
            cmbEstiloGrafico6.SelectedIndexChanged += (s, e) => { if (!_actualizandoCombos) ActualizarGrafico6(); };

            // Suscribirse a cambios en los datos del almacén general
            Almacen.PeriodosCambiaron += SincronizarPeriodos;
            Almacen.DatosCambiaron += ActualizarTodosLosGraficos;
            Almacen.ActivoCambio += SincronizarPeriodos;

            _inicializado = true;

            // Renderizado inicial de todos los gráficos
            ActualizarTodosLosGraficos();
        }

        private Chart CrearChart(string nombre, Panel contenedor, Label etiquetaPlaceholder)
        {
            if (etiquetaPlaceholder != null) etiquetaPlaceholder.Visible = false;

            Chart chart = new Chart();
            chart.Name = nombre;
            chart.Dock = DockStyle.Fill;
            chart.BackColor = Color.White;
            chart.AntiAliasing = AntiAliasingStyles.All;
            chart.TextAntiAliasingQuality = TextAntiAliasingQuality.High;

            contenedor.Controls.Add(chart);
            chart.BringToFront();

            return chart;
        }

        private void ConfigurarComboTipos(ComboBox cmbTipo, ComboBox cmbEstilo, string tipoDefecto, string estiloDefecto)
        {
            if (cmbTipo != null && cmbTipo.Items.Count > 0 && cmbTipo.SelectedIndex < 0)
            {
                int idx = cmbTipo.FindStringExact(tipoDefecto);
                cmbTipo.SelectedIndex = idx >= 0 ? idx : 0;
            }

            if (cmbEstilo != null && cmbEstilo.Items.Count > 0 && cmbEstilo.SelectedIndex < 0)
            {
                int idx = cmbEstilo.FindStringExact(estiloDefecto);
                cmbEstilo.SelectedIndex = idx >= 0 ? idx : 0;
            }
        }

        private void SincronizarPeriodos()
        {
            _actualizandoCombos = true;
            try
            {
                string anteriorBase = cmbPeriodoBaseGraf.SelectedItem as string;
                string anteriorComp = cmbPeriodoCompGraf.SelectedItem as string;

                var nombres = Almacen.Periodos.Where(p => p.TieneDatos).Select(p => p.Nombre).ToList();
                if (nombres.Count == 0) nombres = Almacen.Nombres.ToList();

                cmbPeriodoBaseGraf.Items.Clear();
                cmbPeriodoCompGraf.Items.Clear();

                foreach (var n in nombres)
                {
                    cmbPeriodoBaseGraf.Items.Add(n);
                    cmbPeriodoCompGraf.Items.Add(n);
                }

                // Seleccionar base y comparado coherentes (ej. 2019 base, 2020 comparado)
                if (nombres.Contains("2019") && nombres.Contains("2020"))
                {
                    cmbPeriodoBaseGraf.SelectedItem = "2019";
                    cmbPeriodoCompGraf.SelectedItem = "2020";
                }
                else if (nombres.Count >= 2)
                {
                    cmbPeriodoBaseGraf.SelectedIndex = 0;
                    cmbPeriodoCompGraf.SelectedIndex = 1;
                }
                else if (nombres.Count == 1)
                {
                    cmbPeriodoBaseGraf.SelectedIndex = 0;
                    cmbPeriodoCompGraf.SelectedIndex = 0;
                }
            }
            finally
            {
                _actualizandoCombos = false;
            }

            if (_inicializado)
            {
                ActualizarTodosLosGraficos();
            }
        }

        private Periodo ObtenerPeriodoBase()
        {
            string nombre = cmbPeriodoBaseGraf.SelectedItem as string;
            return Almacen.Buscar(nombre) ?? Almacen.Periodos.FirstOrDefault(p => p.TieneDatos);
        }

        private Periodo ObtenerPeriodoComp()
        {
            string nombre = cmbPeriodoCompGraf.SelectedItem as string;
            return Almacen.Buscar(nombre) ?? Almacen.Periodos.LastOrDefault(p => p.TieneDatos);
        }

        public void ActualizarTodosLosGraficos()
        {
            ActualizarGrafico1();
            ActualizarGrafico2();
            ActualizarGrafico3();
            ActualizarGrafico4();
            ActualizarGrafico5();
            ActualizarGrafico6();
        }

        private ChartArea PrepararArea(Chart chart, string nombreArea = "DefaultArea")
        {
            chart.ChartAreas.Clear();
            chart.Series.Clear();
            chart.Legends.Clear();
            chart.Titles.Clear();

            ChartArea area = new ChartArea(nombreArea);
            area.BackColor = Color.FromArgb(250, 252, 255);
            area.BackSecondaryColor = Color.White;
            area.BackGradientStyle = GradientStyle.TopBottom;

            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 8.5F);
            area.AxisX.LabelStyle.ForeColor = Color.FromArgb(60, 65, 75);
            area.AxisX.LineColor = Color.FromArgb(200, 205, 215);
            area.AxisX.MajorGrid.LineColor = Color.FromArgb(235, 238, 245);
            area.AxisX.Interval = 1;

            area.AxisY.LabelStyle.Font = new Font("Segoe UI", 8.5F);
            area.AxisY.LabelStyle.ForeColor = Color.FromArgb(60, 65, 75);
            area.AxisY.LineColor = Color.FromArgb(200, 205, 215);
            area.AxisY.MajorGrid.LineColor = Color.FromArgb(235, 238, 245);

            chart.ChartAreas.Add(area);

            Legend leyenda = new Legend("DefaultLegend");
            leyenda.Docking = Docking.Top;
            leyenda.Alignment = StringAlignment.Center;
            leyenda.Font = new Font("Segoe UI", 8.5F, FontStyle.Regular);
            leyenda.ForeColor = Color.FromArgb(50, 50, 60);
            leyenda.BackColor = Color.Transparent;
            chart.Legends.Add(leyenda);

            return area;
        }

        private SeriesChartType ObtenerTipoSerie(string tipoTexto)
        {
            if (string.IsNullOrEmpty(tipoTexto)) return SeriesChartType.Column;

            string t = tipoTexto.Trim().ToLowerInvariant();
            if (t.Contains("barras") || t.Contains("columna")) return SeriesChartType.Column;
            if (t.Contains("líneas") || t.Contains("lineas")) return SeriesChartType.Line;
            if (t.Contains("pastel") || t.Contains("pie")) return SeriesChartType.Pie;
            if (t.Contains("dona") || t.Contains("doughnut")) return SeriesChartType.Doughnut;
            if (t.Contains("araña") || t.Contains("radar")) return SeriesChartType.Radar;
            if (t.Contains("polar")) return SeriesChartType.Polar;

            return SeriesChartType.Column;
        }

        private Color[] ObtenerPaleta(string estilo)
        {
            string e = (estilo ?? "").Trim().ToLowerInvariant();

            if (e.Contains("pastel"))
            {
                return new[]
                {
                    Color.FromArgb(100, 181, 246),
                    Color.FromArgb(255, 183, 77),
                    Color.FromArgb(129, 199, 132),
                    Color.FromArgb(229, 115, 115),
                    Color.FromArgb(186, 104, 200),
                    Color.FromArgb(77, 208, 225)
                };
            }

            if (e.Contains("alto contraste") || e.Contains("contraste"))
            {
                return new[]
                {
                    Color.FromArgb(20, 50, 95),
                    Color.FromArgb(200, 35, 45),
                    Color.FromArgb(220, 130, 20),
                    Color.FromArgb(30, 130, 60),
                    Color.FromArgb(110, 40, 140),
                    Color.FromArgb(0, 110, 130)
                };
            }

            // Clásico
            return new[]
            {
                Color.FromArgb(41, 128, 185),
                Color.FromArgb(230, 126, 34),
                Color.FromArgb(39, 174, 96),
                Color.FromArgb(192, 57, 43),
                Color.FromArgb(142, 68, 173),
                Color.FromArgb(22, 160, 133)
            };
        }

        // ─────────────────────────────────────────────────────────────────────
        // 1. ANÁLISIS HORIZONTAL Y VERTICAL (BG / ER)
        // ─────────────────────────────────────────────────────────────────────
        private void ActualizarGrafico1()
        {
            if (_chart1 == null) return;
            PrepararArea(_chart1);

            Periodo baseP = ObtenerPeriodoBase();
            Periodo compP = ObtenerPeriodoComp();

            if (baseP == null || compP == null) return;

            string tipoStr = cmbTipoGrafico1.SelectedItem?.ToString() ?? "Barras";
            string estiloStr = cmbEstiloGrafico1.SelectedItem?.ToString() ?? "Clásico";
            string mostrar = cmbMostrar.SelectedItem?.ToString() ?? "Monto";
            Color[] paleta = ObtenerPaleta(estiloStr);
            SeriesChartType chartType = ObtenerTipoSerie(tipoStr);

            var cuentas = new List<Tuple<string, decimal, decimal>>
            {
                Tuple.Create("Activo Cte", Calculos.ActivoCorriente(baseP), Calculos.ActivoCorriente(compP)),
                Tuple.Create("Activo No Cte", Calculos.ActivoNoCorriente(baseP), Calculos.ActivoNoCorriente(compP)),
                Tuple.Create("Pasivo Cte", Calculos.PasivoCorriente(baseP), Calculos.PasivoCorriente(compP)),
                Tuple.Create("Pasivo No Cte", Calculos.PasivoNoCorriente(baseP), Calculos.PasivoNoCorriente(compP)),
                Tuple.Create("Patrimonio", Calculos.Patrimonio(baseP), Calculos.Patrimonio(compP)),
                Tuple.Create("Ventas", Calculos.Ventas(baseP), Calculos.Ventas(compP)),
                Tuple.Create("Utilidad Neta", Calculos.UtilidadNeta(baseP), Calculos.UtilidadNeta(compP))
            };

            // Top N
            int topN = int.TryParse(cmbTopN.SelectedItem?.ToString(), out int n) ? n : 5;
            if (topN > 0 && topN < cuentas.Count)
            {
                cuentas = cuentas.Take(topN).ToList();
            }

            if (chartType == SeriesChartType.Pie || chartType == SeriesChartType.Doughnut)
            {
                Series serie = new Series("Distribución " + compP.Nombre);
                serie.ChartType = chartType;
                _chart1.Series.Add(serie);

                int colorIdx = 0;
                foreach (var item in cuentas)
                {
                    double valor = Math.Abs((double)item.Item3);
                    if (valor <= 0) continue;

                    int pIdx = serie.Points.AddXY(item.Item1, valor);
                    serie.Points[pIdx].Color = paleta[colorIdx % paleta.Length];
                    serie.Points[pIdx].LegendText = item.Item1;
                    serie.Points[pIdx].ToolTip = string.Format("{0}: C$ {1:N0}", item.Item1, item.Item3);
                    colorIdx++;
                }
            }
            else if (mostrar == "Porcentaje")
            {
                Series serieVar = new Series("Variación % (" + baseP.Nombre + " vs " + compP.Nombre + ")");
                serieVar.ChartType = chartType;
                serieVar.Color = paleta[0];
                _chart1.Series.Add(serieVar);

                foreach (var item in cuentas)
                {
                    decimal baseVal = item.Item2;
                    decimal compVal = item.Item3;
                    decimal pct = baseVal != 0m ? ((compVal - baseVal) / Math.Abs(baseVal)) * 100m : 0m;

                    int pIdx = serieVar.Points.AddXY(item.Item1, (double)pct);
                    serieVar.Points[pIdx].Label = string.Format("{0:0.0}%", pct);
                    serieVar.Points[pIdx].Color = pct >= 0 ? paleta[0] : paleta[3];
                }
            }
            else
            {
                // Monto comparado
                Series serieBase = new Series(baseP.Nombre);
                serieBase.ChartType = chartType;
                serieBase.Color = paleta[0];

                Series serieComp = new Series(compP.Nombre);
                serieComp.ChartType = chartType;
                serieComp.Color = paleta[1];

                _chart1.Series.Add(serieBase);
                _chart1.Series.Add(serieComp);

                foreach (var item in cuentas)
                {
                    serieBase.Points.AddXY(item.Item1, (double)item.Item2);
                    serieComp.Points.AddXY(item.Item1, (double)item.Item3);
                }
            }
        }

        // ─────────────────────────────────────────────────────────────────────
        // 2. RAZONES FINANCIERAS (COMPARADO)
        // ─────────────────────────────────────────────────────────────────────
        private void ActualizarGrafico2()
        {
            if (_chart2 == null) return;
            PrepararArea(_chart2);

            Periodo baseP = ObtenerPeriodoBase();
            Periodo compP = ObtenerPeriodoComp();
            if (baseP == null || compP == null) return;

            string tipoStr = cmbTipoGrafico2.SelectedItem?.ToString() ?? "Barras";
            string estiloStr = cmbEstiloGrafico2.SelectedItem?.ToString() ?? "Clásico";
            Color[] paleta = ObtenerPaleta(estiloStr);
            SeriesChartType chartType = ObtenerTipoSerie(tipoStr);

            var razonesBase = Calculos.Razones(baseP).ToDictionary(r => r.Nombre, r => ExtraerValor(r.ValorTexto));
            var razonesComp = Calculos.Razones(compP).ToDictionary(r => r.Nombre, r => ExtraerValor(r.ValorTexto));

            string[] indicadores = new[]
            {
                "Razón corriente", "Prueba ácida", "Deuda sobre activo",
                "Rotación de activos", "Margen neto", "ROA", "ROE"
            };

            Series serieBase = new Series(baseP.Nombre);
            serieBase.ChartType = chartType;
            serieBase.Color = paleta[0];

            Series serieComp = new Series(compP.Nombre);
            serieComp.ChartType = chartType;
            serieComp.Color = paleta[1];

            _chart2.Series.Add(serieBase);
            _chart2.Series.Add(serieComp);

            foreach (string ind in indicadores)
            {
                double valBase = razonesBase.ContainsKey(ind) ? razonesBase[ind] : 0.0;
                double valComp = razonesComp.ContainsKey(ind) ? razonesComp[ind] : 0.0;

                serieBase.Points.AddXY(ind, valBase);
                serieComp.Points.AddXY(ind, valComp);
            }
        }

        // ─────────────────────────────────────────────────────────────────────
        // 3. CAPITAL NETO DE TRABAJO (CNT) Y CNO
        // ─────────────────────────────────────────────────────────────────────
        private void ActualizarGrafico3()
        {
            if (_chart3 == null) return;
            PrepararArea(_chart3);

            Periodo baseP = ObtenerPeriodoBase();
            Periodo compP = ObtenerPeriodoComp();
            if (baseP == null || compP == null) return;

            string tipoStr = cmbTipoGrafico3.SelectedItem?.ToString() ?? "Barras";
            string estiloStr = cmbEstiloGrafico3.SelectedItem?.ToString() ?? "Clásico";
            Color[] paleta = ObtenerPaleta(estiloStr);
            SeriesChartType chartType = ObtenerTipoSerie(tipoStr);

            decimal cntBase = Calculos.ActivoCorriente(baseP) - Calculos.PasivoCorriente(baseP);
            decimal cntComp = Calculos.ActivoCorriente(compP) - Calculos.PasivoCorriente(compP);

            decimal actOpBase = SumarOperativo(baseP, Clasif.ActivoCorriente);
            decimal pasOpBase = SumarOperativo(baseP, Clasif.PasivoCorriente);
            decimal cnoBase = actOpBase - pasOpBase;

            decimal actOpComp = SumarOperativo(compP, Clasif.ActivoCorriente);
            decimal pasOpComp = SumarOperativo(compP, Clasif.PasivoCorriente);
            decimal cnoComp = actOpComp - pasOpComp;

            var items = new List<Tuple<string, decimal, decimal>>
            {
                Tuple.Create("Activo Cte", Calculos.ActivoCorriente(baseP), Calculos.ActivoCorriente(compP)),
                Tuple.Create("Pasivo Cte", Calculos.PasivoCorriente(baseP), Calculos.PasivoCorriente(compP)),
                Tuple.Create("CNT", cntBase, cntComp),
                Tuple.Create("Act. Operativo", actOpBase, actOpComp),
                Tuple.Create("Pas. Operativo", pasOpBase, pasOpComp),
                Tuple.Create("CNO", cnoBase, cnoComp)
            };

            Series sBase = new Series(baseP.Nombre);
            sBase.ChartType = chartType;
            sBase.Color = paleta[0];

            Series sComp = new Series(compP.Nombre);
            sComp.ChartType = chartType;
            sComp.Color = paleta[1];

            _chart3.Series.Add(sBase);
            _chart3.Series.Add(sComp);

            foreach (var it in items)
            {
                sBase.Points.AddXY(it.Item1, (double)it.Item2);
                sComp.Points.AddXY(it.Item1, (double)it.Item3);
            }
        }

        // ─────────────────────────────────────────────────────────────────────
        // 4. EOAF (ORIGEN Y APLICACIÓN DE FONDOS)
        // ─────────────────────────────────────────────────────────────────────
        private void ActualizarGrafico4()
        {
            if (_chart4 == null) return;
            PrepararArea(_chart4);

            Periodo baseP = ObtenerPeriodoBase();
            Periodo compP = ObtenerPeriodoComp();
            if (baseP == null || compP == null) return;

            string tipoStr = cmbTipoGrafico4.SelectedItem?.ToString() ?? "Barras";
            string estiloStr = cmbEstiloGrafico4.SelectedItem?.ToString() ?? "Clásico";
            Color[] paleta = ObtenerPaleta(estiloStr);
            SeriesChartType chartType = ObtenerTipoSerie(tipoStr);

            ResultadoEoaf eoaf = Calculos.Eoaf(baseP, compP);

            if (chartType == SeriesChartType.Pie || chartType == SeriesChartType.Doughnut)
            {
                Series seriePie = new Series("EOAF");
                seriePie.ChartType = chartType;
                _chart4.Series.Add(seriePie);

                int p1 = seriePie.Points.AddXY("Total Orígenes", (double)eoaf.TotalOrigen);
                seriePie.Points[p1].Color = paleta[2]; // Verde
                seriePie.Points[p1].LegendText = "Orígenes (C$ " + eoaf.TotalOrigen.ToString("N0") + ")";

                int p2 = seriePie.Points.AddXY("Total Aplicaciones", (double)eoaf.TotalAplicacion);
                seriePie.Points[p2].Color = paleta[3]; // Rojo
                seriePie.Points[p2].LegendText = "Aplicaciones (C$ " + eoaf.TotalAplicacion.ToString("N0") + ")";
            }
            else
            {
                // Top Orígenes y Top Aplicaciones
                var topOrigenes = eoaf.Filas.Where(f => f.Origen > 0).OrderByDescending(f => f.Origen).Take(3).ToList();
                var topAplicaciones = eoaf.Filas.Where(f => f.Aplicacion > 0).OrderByDescending(f => f.Aplicacion).Take(3).ToList();

                Series sOrigen = new Series("Orígenes");
                sOrigen.ChartType = chartType;
                sOrigen.Color = paleta[2]; // Verde

                Series sAplicacion = new Series("Aplicaciones");
                sAplicacion.ChartType = chartType;
                sAplicacion.Color = paleta[3]; // Rojo

                _chart4.Series.Add(sOrigen);
                _chart4.Series.Add(sAplicacion);

                // Agregar totales y principales cuentas
                sOrigen.Points.AddXY("Total General", (double)eoaf.TotalOrigen);
                sAplicacion.Points.AddXY("Total General", (double)eoaf.TotalAplicacion);

                foreach (var orig in topOrigenes)
                {
                    string nom = TruncarTexto(orig.Cuenta, 14);
                    sOrigen.Points.AddXY(nom, (double)orig.Origen);
                }

                foreach (var aplic in topAplicaciones)
                {
                    string nom = TruncarTexto(aplic.Cuenta, 14);
                    sAplicacion.Points.AddXY(nom, (double)aplic.Aplicacion);
                }
            }
        }

        // ─────────────────────────────────────────────────────────────────────
        // 5. ESTADO DE FLUJO DE EFECTIVO
        // ─────────────────────────────────────────────────────────────────────
        private void ActualizarGrafico5()
        {
            if (_chart5 == null) return;
            PrepararArea(_chart5);

            Periodo baseP = ObtenerPeriodoBase();
            Periodo compP = ObtenerPeriodoComp();
            if (baseP == null || compP == null) return;

            string tipoStr = cmbTipoGrafico5.SelectedItem?.ToString() ?? "Barras";
            string estiloStr = cmbEstiloGrafico5.SelectedItem?.ToString() ?? "Clásico";
            Color[] paleta = ObtenerPaleta(estiloStr);
            SeriesChartType chartType = ObtenerTipoSerie(tipoStr);

            ResultadoEfe efe = Calculos.Efe(baseP, compP, true);

            decimal flujoOp = ObtenerMontoEfe(efe, "ACTIVIDADES DE OPERACIÓN");
            decimal flujoInv = ObtenerMontoEfe(efe, "ACTIVIDADES DE INVERSIÓN");
            decimal flujoFin = ObtenerMontoEfe(efe, "ACTIVIDADES DE FINANCIACIÓN");
            decimal flujoNeto = flujoOp + flujoInv + flujoFin;

            var items = new List<Tuple<string, decimal>>
            {
                Tuple.Create("Operación", flujoOp),
                Tuple.Create("Inversión", flujoInv),
                Tuple.Create("Financiamiento", flujoFin),
                Tuple.Create("Flujo Neto", flujoNeto)
            };

            Series serie = new Series("Flujo de Efectivo");
            serie.ChartType = chartType;
            _chart5.Series.Add(serie);

            int idx = 0;
            foreach (var item in items)
            {
                int pIdx = serie.Points.AddXY(item.Item1, (double)item.Item2);
                serie.Points[pIdx].Color = item.Item2 >= 0 ? paleta[0] : paleta[3];
                serie.Points[pIdx].Label = string.Format("C$ {0:N0}", item.Item2);
                idx++;
            }
        }

        // ─────────────────────────────────────────────────────────────────────
        // 6. MODELO DUPONT (COMPARADO)
        // ─────────────────────────────────────────────────────────────────────
        private void ActualizarGrafico6()
        {
            if (_chart6 == null) return;
            PrepararArea(_chart6);

            Periodo baseP = ObtenerPeriodoBase();
            Periodo compP = ObtenerPeriodoComp();
            if (baseP == null || compP == null) return;

            string tipoStr = cmbTipoGrafico6.SelectedItem?.ToString() ?? "Barras";
            string estiloStr = cmbEstiloGrafico6.SelectedItem?.ToString() ?? "Clásico";
            Color[] paleta = ObtenerPaleta(estiloStr);
            SeriesChartType chartType = ObtenerTipoSerie(tipoStr);

            var dupontBase = ExtraerDuPontValores(baseP);
            var dupontComp = ExtraerDuPontValores(compP);

            string[] indicadores = new[]
            {
                "Margen Neto (%)",
                "Rot. Activos (veces)",
                "Mult. Capital (veces)",
                "ROA (%)",
                "ROE (%)"
            };

            Series sBase = new Series(baseP.Nombre);
            sBase.ChartType = chartType;
            sBase.Color = paleta[0];

            Series sComp = new Series(compP.Nombre);
            sComp.ChartType = chartType;
            sComp.Color = paleta[1];

            _chart6.Series.Add(sBase);
            _chart6.Series.Add(sComp);

            foreach (string ind in indicadores)
            {
                double valBase = dupontBase.ContainsKey(ind) ? dupontBase[ind] : 0.0;
                double valComp = dupontComp.ContainsKey(ind) ? dupontComp[ind] : 0.0;

                sBase.Points.AddXY(ind, valBase);
                sComp.Points.AddXY(ind, valComp);
            }
        }

        // ─────────────────────────────────────────────────────────────────────
        // MÉTODOS AUXILIARES DE CÁLCULO
        // ─────────────────────────────────────────────────────────────────────
        private Dictionary<string, double> ExtraerDuPontValores(Periodo p)
        {
            var dict = new Dictionary<string, double>();
            if (p == null) return dict;

            decimal ventas = Calculos.Ventas(p);
            decimal activo = Calculos.ActivoTotal(p);
            decimal patrimonio = Calculos.Patrimonio(p);
            decimal un = Calculos.UtilidadNeta(p);

            double margen = ventas != 0m ? (double)((un / ventas) * 100m) : 0.0;
            double rotacion = activo != 0m ? (double)(ventas / activo) : 0.0;
            double multiplicador = patrimonio > 0m ? (double)(activo / patrimonio) : 0.0;
            double roa = activo != 0m ? (double)((un / activo) * 100m) : 0.0;
            double roe = patrimonio > 0m ? (double)((un / patrimonio) * 100m) : 0.0;

            dict["Margen Neto (%)"] = margen;
            dict["Rot. Activos (veces)"] = rotacion;
            dict["Mult. Capital (veces)"] = multiplicador;
            dict["ROA (%)"] = roa;
            dict["ROE (%)"] = roe;

            return dict;
        }

        private decimal SumarOperativo(Periodo p, string clasificacion)
        {
            if (p == null) return 0m;
            return p.BG.Where(c => c.Operativa && Util.Igual(c.Clasificacion, clasificacion)).Sum(c => c.Monto);
        }

        private decimal ObtenerMontoEfe(ResultadoEfe efe, string fragmentoConcepto)
        {
            if (efe == null || efe.Filas == null) return 0m;

            var fila = efe.Filas.FirstOrDefault(f => f.Concepto.IndexOf(fragmentoConcepto, StringComparison.OrdinalIgnoreCase) >= 0);
            return fila != null ? fila.Monto : 0m;
        }

        private double ExtraerValor(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return 0.0;

            string limpio = texto.Replace("%", "").Replace("x", "").Replace("veces", "").Replace("días", "").Replace("C$", "").Replace(",", "").Trim();
            if (double.TryParse(limpio, NumberStyles.Any, CultureInfo.InvariantCulture, out double valor))
            {
                return valor;
            }
            if (double.TryParse(limpio, out valor))
            {
                return valor;
            }
            return 0.0;
        }

        private string TruncarTexto(string texto, int longitudMaxima)
        {
            if (string.IsNullOrEmpty(texto)) return "";
            if (texto.Length <= longitudMaxima) return texto;
            return texto.Substring(0, longitudMaxima - 2) + "..";
        }
    }
}
