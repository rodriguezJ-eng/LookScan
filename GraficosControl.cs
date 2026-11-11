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

        public class DatoGraficoItem
        {
            public string Nombre { get; set; }
            public decimal Valor { get; set; }

            public DatoGraficoItem(string nombre, decimal valor)
            {
                Nombre = nombre;
                Valor = valor;
            }
        }

        public GraficosControl()
        {
            InitializeComponent();
            InicializarComponentesGraficos();
        }

        private void InicializarComponentesGraficos()
        {
            if (Util.EnDiseno) return;

            // Se apoya estrictamente de los datos ya proporcionados en el almacén.
            // NO se autacarga demo aquí; los datos solo se cargan mediante el botón "Cargar Demo".

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
            btnActualizarTodos.Click += (s, e) =>
            {
                try
                {
                    ActualizarTodosLosGraficos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pueden actualizar los gráficos: " + ex.Message, "LookScan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };

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
            if (etiquetaPlaceholder != null)
            {
                etiquetaPlaceholder.Text = "No hay datos cargados en el sistema.\nCargue datos o use 'Cargar Demo' en la pestaña Datos.";
                etiquetaPlaceholder.ForeColor = Color.FromArgb(120, 130, 150);
                etiquetaPlaceholder.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                etiquetaPlaceholder.Visible = false;
            }

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
            try
            {
                ActualizarGrafico1();
                ActualizarGrafico2();
                ActualizarGrafico3();
                ActualizarGrafico4();
                ActualizarGrafico5();
                ActualizarGrafico6();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron actualizar todos los gráficos: " + ex.Message, "LookScan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
            if (t.Contains("araña") || t.Contains("arana") || t.Contains("radar")) return SeriesChartType.Radar;
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
                    Color.FromArgb(77, 208, 225),
                    Color.FromArgb(255, 213, 79),
                    Color.FromArgb(161, 136, 127)
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
                    Color.FromArgb(0, 110, 130),
                    Color.FromArgb(180, 100, 0),
                    Color.FromArgb(40, 40, 40)
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
                Color.FromArgb(22, 160, 133),
                Color.FromArgb(243, 156, 18),
                Color.FromArgb(52, 73, 94)
            };
        }

        private void MostrarMensajeVacio(Chart chart, Label lblPlaceholder, string mensaje)
        {
            if (lblPlaceholder != null)
            {
                lblPlaceholder.Text = mensaje;
                lblPlaceholder.Visible = true;
                lblPlaceholder.BringToFront();
            }
            if (chart != null)
            {
                chart.Visible = false;
            }
        }

        private void MostrarChart(Chart chart, Label lblPlaceholder)
        {
            if (lblPlaceholder != null)
            {
                lblPlaceholder.Visible = false;
            }
            if (chart != null)
            {
                chart.Visible = true;
                chart.BringToFront();
            }
        }

        /// <summary>
        /// Motor unificado de renderizado que optimiza gráficos de Pastel (evitando que queden pegados),
        /// Polar (calculando los ángulos 0-360° reales con etiquetas perimetrales),
        /// Araña (Radar), Barras y Líneas.
        /// </summary>
        private void RenderizarGrafico(
            Chart chart,
            Label lblPlaceholder,
            string titulo,
            List<DatoGraficoItem> datosBase,
            List<DatoGraficoItem> datosComp,
            string nombreBase,
            string nombreComp,
            string tipoStr,
            string estiloStr,
            bool esComparativo = true)
        {
            if (chart == null) return;

            // Validar que existan datos
            bool sinBase = datosBase == null || datosBase.Count == 0 || datosBase.All(d => d.Valor == 0);
            bool sinComp = datosComp == null || datosComp.Count == 0 || datosComp.All(d => d.Valor == 0);

            if (sinBase && sinComp)
            {
                MostrarMensajeVacio(chart, lblPlaceholder, "No hay datos registrados para graficar.\nCapture información o use el botón 'Cargar Demo' en la pestaña Datos.");
                return;
            }

            MostrarChart(chart, lblPlaceholder);
            ChartArea area = PrepararArea(chart);
            Color[] paleta = ObtenerPaleta(estiloStr);
            SeriesChartType chartType = ObtenerTipoSerie(tipoStr);

            // =========================================================================
            // CASO 1: PASTEL (PIE) O DONA (DOUGHNUT)
            // =========================================================================
            if (chartType == SeriesChartType.Pie || chartType == SeriesChartType.Doughnut)
            {
                // Para pastel/dona se toma la serie comparada (o base si no hay comparada)
                List<DatoGraficoItem> fuente = (!sinComp ? datosComp : datosBase)
                    .Where(d => d.Valor > 0) // El gráfico de pastel solo admite magnitudes positivas
                    .ToList();

                if (fuente.Count == 0)
                {
                    MostrarMensajeVacio(chart, lblPlaceholder, "Los datos actuales no contienen valores positivos para representar en el gráfico circular.");
                    return;
                }

                decimal total = fuente.Sum(f => f.Valor);

                // Configuración de layout espacioso para el pastel:
                // Se coloca la leyenda a la derecha con scroll/flujo para dar máximo espacio al disco
                chart.Legends[0].Docking = Docking.Right;
                chart.Legends[0].Alignment = StringAlignment.Center;
                chart.Legends[0].Font = new Font("Segoe UI", 9F, FontStyle.Regular);

                // Área interior con margen amplio para que las etiquetas externas no se recorten
                area.Position = new ElementPosition(1, 2, 98, 96);
                area.InnerPlotPosition = new ElementPosition(6, 6, 88, 88);

                Series serie = new Series("Distribución");
                serie.ChartType = chartType;
                serie.BorderColor = Color.White;
                serie.BorderWidth = 2;

                // Propiedades clave de MSChart para evitar que las secciones queden amontonadas:
                serie["PieLabelStyle"] = "Outside";       // Etiquetas FUERA del disco
                serie["PieLineColor"] = "#555555";        // Línea guía hacia cada sección
                serie["3DLabelLineSize"] = "30";          // Longitud de separación de la línea
                serie["PieDrawingStyle"] = "SoftEdge";     // Acabado moderno suave
                serie["DoughnutRadius"] = "55";

                chart.Series.Add(serie);

                int colorIdx = 0;
                foreach (var item in fuente)
                {
                    double pct = total > 0 ? (double)((item.Valor / total) * 100m) : 0.0;
                    int pIdx = serie.Points.AddXY(item.Nombre, (double)item.Valor);
                    DataPoint dp = serie.Points[pIdx];

                    dp.Color = paleta[colorIdx % paleta.Length];
                    // En la rebanada solo se muestra el porcentaje limpio para máxima claridad visual
                    dp.Label = string.Format("{0:0.0}%", pct);
                    dp.LabelForeColor = Color.FromArgb(40, 45, 55);
                    dp.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);

                    // En la leyenda se muestra el nombre completo junto con su porcentaje
                    dp.LegendText = string.Format("{0} ({1:0.0}%)", item.Nombre, pct);
                    dp.ToolTip = string.Format("{0}: C$ {1:N2} ({2:0.0}%)", item.Nombre, item.Valor, pct);

                    colorIdx++;
                }

                return;
            }

            // =========================================================================
            // CASO 2: GRÁFICO POLAR (POLAR REAL CON ÁNGULOS 0° A 360°)
            // =========================================================================
            if (chartType == SeriesChartType.Polar)
            {
                var listaCategorias = (datosComp != null && datosComp.Count > 0 ? datosComp : datosBase)
                    .Select(d => d.Nombre).Distinct().ToList();

                int n = listaCategorias.Count;
                if (n == 0) return;

                double pasoAngulo = 360.0 / n;

                // Configurar el área polar de MSChart con ejes circulares auténticos
                area.AxisX.Minimum = 0;
                area.AxisX.Maximum = 360;
                area.AxisX.Interval = pasoAngulo;
                area.AxisX.Crossing = 0;
                area.AxisX.MajorGrid.LineColor = Color.FromArgb(215, 222, 235);
                area.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
                area.AxisY.MajorGrid.LineColor = Color.FromArgb(220, 225, 235);
                area.AxisX.LabelStyle.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
                area.AxisX.LabelStyle.ForeColor = Color.FromArgb(45, 55, 75);

                Series seriePolarBase = new Series(nombreBase);
                seriePolarBase.ChartType = SeriesChartType.Polar;
                seriePolarBase["PolarDrawingStyle"] = "Line";
                seriePolarBase.Color = Color.FromArgb(210, paleta[0].R, paleta[0].G, paleta[0].B);
                seriePolarBase.BorderWidth = 3;
                seriePolarBase.MarkerStyle = MarkerStyle.Circle;
                seriePolarBase.MarkerSize = 8;
                seriePolarBase.MarkerColor = paleta[0];

                Series seriePolarComp = null;
                if (esComparativo && !string.IsNullOrEmpty(nombreComp))
                {
                    seriePolarComp = new Series(nombreComp);
                    seriePolarComp.ChartType = SeriesChartType.Polar;
                    seriePolarComp["PolarDrawingStyle"] = "Line";
                    seriePolarComp.Color = Color.FromArgb(210, paleta[1].R, paleta[1].G, paleta[1].B);
                    seriePolarComp.BorderWidth = 3;
                    seriePolarComp.MarkerStyle = MarkerStyle.Diamond;
                    seriePolarComp.MarkerSize = 9;
                    seriePolarComp.MarkerColor = paleta[1];
                }

                chart.Series.Add(seriePolarBase);
                if (seriePolarComp != null) chart.Series.Add(seriePolarComp);

                double primerValorBase = 0;
                double primerValorComp = 0;

                for (int i = 0; i < n; i++)
                {
                    string cat = listaCategorias[i];
                    double angulo = i * pasoAngulo;

                    var itemB = datosBase != null ? datosBase.FirstOrDefault(d => Util.Igual(d.Nombre, cat)) : null;
                    var itemC = datosComp != null ? datosComp.FirstOrDefault(d => Util.Igual(d.Nombre, cat)) : null;

                    double valB = itemB != null ? (double)Math.Max(0, itemB.Valor) : 0.0;
                    double valC = itemC != null ? (double)Math.Max(0, itemC.Valor) : 0.0;

                    if (i == 0)
                    {
                        primerValorBase = valB;
                        primerValorComp = valC;
                    }

                    int idxB = seriePolarBase.Points.AddXY(angulo, valB);
                    seriePolarBase.Points[idxB].AxisLabel = cat;
                    seriePolarBase.Points[idxB].ToolTip = string.Format("{0} ({1}): {2:N2}", cat, nombreBase, valB);

                    if (seriePolarComp != null)
                    {
                        int idxC = seriePolarComp.Points.AddXY(angulo, valC);
                        seriePolarComp.Points[idxC].AxisLabel = cat;
                        seriePolarComp.Points[idxC].ToolTip = string.Format("{0} ({1}): {2:N2}", cat, nombreComp, valC);
                    }
                }

                // Cerrar el polígono conectando nuevamente a los 360° con el primer valor
                seriePolarBase.Points.AddXY(360.0, primerValorBase);
                if (seriePolarComp != null)
                {
                    seriePolarComp.Points.AddXY(360.0, primerValorComp);
                }

                return;
            }

            // =========================================================================
            // CASO 3: GRÁFICO ARAÑA (RADAR)
            // =========================================================================
            if (chartType == SeriesChartType.Radar)
            {
                var listaCategorias = (datosComp != null && datosComp.Count > 0 ? datosComp : datosBase)
                    .Select(d => d.Nombre).Distinct().ToList();

                area.AxisX.LabelStyle.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
                area.AxisX.LabelStyle.ForeColor = Color.FromArgb(45, 55, 75);
                area.AxisX.MajorGrid.LineColor = Color.FromArgb(215, 222, 235);
                area.AxisY.MajorGrid.LineColor = Color.FromArgb(220, 225, 235);

                Series serieRadarBase = new Series(nombreBase);
                serieRadarBase.ChartType = SeriesChartType.Radar;
                serieRadarBase["RadarDrawingStyle"] = "Area";
                serieRadarBase.Color = Color.FromArgb(120, paleta[0].R, paleta[0].G, paleta[0].B);
                serieRadarBase.BorderColor = paleta[0];
                serieRadarBase.BorderWidth = 2;
                serieRadarBase.MarkerStyle = MarkerStyle.Circle;
                serieRadarBase.MarkerSize = 7;

                Series serieRadarComp = null;
                if (esComparativo && !string.IsNullOrEmpty(nombreComp))
                {
                    serieRadarComp = new Series(nombreComp);
                    serieRadarComp.ChartType = SeriesChartType.Radar;
                    serieRadarComp["RadarDrawingStyle"] = "Area";
                    serieRadarComp.Color = Color.FromArgb(120, paleta[1].R, paleta[1].G, paleta[1].B);
                    serieRadarComp.BorderColor = paleta[1];
                    serieRadarComp.BorderWidth = 2;
                    serieRadarComp.MarkerStyle = MarkerStyle.Diamond;
                    serieRadarComp.MarkerSize = 8;
                }

                chart.Series.Add(serieRadarBase);
                if (serieRadarComp != null) chart.Series.Add(serieRadarComp);

                foreach (string cat in listaCategorias)
                {
                    var itemB = datosBase != null ? datosBase.FirstOrDefault(d => Util.Igual(d.Nombre, cat)) : null;
                    var itemC = datosComp != null ? datosComp.FirstOrDefault(d => Util.Igual(d.Nombre, cat)) : null;

                    double valB = itemB != null ? (double)Math.Max(0, itemB.Valor) : 0.0;
                    double valC = itemC != null ? (double)Math.Max(0, itemC.Valor) : 0.0;

                    int idxB = serieRadarBase.Points.AddXY(cat, valB);
                    serieRadarBase.Points[idxB].ToolTip = string.Format("{0} ({1}): {2:N2}", cat, nombreBase, valB);

                    if (serieRadarComp != null)
                    {
                        int idxC = serieRadarComp.Points.AddXY(cat, valC);
                        serieRadarComp.Points[idxC].ToolTip = string.Format("{0} ({1}): {2:N2}", cat, nombreComp, valC);
                    }
                }

                return;
            }

            // =========================================================================
            // CASO 4: BARRAS O LÍNEAS
            // =========================================================================
            var categorias = (datosComp != null && datosComp.Count > 0 ? datosComp : datosBase)
                .Select(d => d.Nombre).Distinct().ToList();

            Series sBase = new Series(nombreBase);
            sBase.ChartType = chartType;
            sBase.Color = paleta[0];

            if (chartType == SeriesChartType.Line)
            {
                sBase.BorderWidth = 3;
                sBase.MarkerStyle = MarkerStyle.Circle;
                sBase.MarkerSize = 7;
            }
            else
            {
                sBase["PointWidth"] = "0.6";
            }

            Series sComp = null;
            if (esComparativo && !string.IsNullOrEmpty(nombreComp))
            {
                sComp = new Series(nombreComp);
                sComp.ChartType = chartType;
                sComp.Color = paleta[1];

                if (chartType == SeriesChartType.Line)
                {
                    sComp.BorderWidth = 3;
                    sComp.MarkerStyle = MarkerStyle.Diamond;
                    sComp.MarkerSize = 8;
                }
                else
                {
                    sComp["PointWidth"] = "0.6";
                }
            }

            chart.Series.Add(sBase);
            if (sComp != null) chart.Series.Add(sComp);

            foreach (string cat in categorias)
            {
                var itemB = datosBase != null ? datosBase.FirstOrDefault(d => Util.Igual(d.Nombre, cat)) : null;
                var itemC = datosComp != null ? datosComp.FirstOrDefault(d => Util.Igual(d.Nombre, cat)) : null;

                double valB = itemB != null ? (double)itemB.Valor : 0.0;
                double valC = itemC != null ? (double)itemC.Valor : 0.0;

                int pB = sBase.Points.AddXY(cat, valB);
                sBase.Points[pB].ToolTip = string.Format("{0} ({1}): {2:N2}", cat, nombreBase, valB);

                if (sComp != null)
                {
                    int pC = sComp.Points.AddXY(cat, valC);
                    sComp.Points[pC].ToolTip = string.Format("{0} ({1}): {2:N2}", cat, nombreComp, valC);
                }
            }
        }

        // ─────────────────────────────────────────────────────────────────────
        // 1. ANÁLISIS HORIZONTAL Y VERTICAL (BG / ER)
        // ─────────────────────────────────────────────────────────────────────
        private void ActualizarGrafico1()
        {
            try
            {
                if (_chart1 == null) return;

                Periodo baseP = ObtenerPeriodoBase();
                Periodo compP = ObtenerPeriodoComp();

                if (baseP == null || compP == null || (!baseP.TieneDatos && !compP.TieneDatos))
                {
                    MostrarMensajeVacio(_chart1, lblAreaGrafico1, "No hay datos para los periodos seleccionados.\nPresione 'Cargar Demo' en la pestaña Datos para visualizarlos.");
                    return;
                }

                string tipoStr = cmbTipoGrafico1.SelectedItem?.ToString() ?? "Barras";
                string estiloStr = cmbEstiloGrafico1.SelectedItem?.ToString() ?? "Clásico";
                string mostrar = cmbMostrar.SelectedItem?.ToString() ?? "Monto";
                string ordenar = cmbOrdenarPor.SelectedItem?.ToString() ?? "Valor";

                var lista = new List<Tuple<string, decimal, decimal>>
                {
                    Tuple.Create("Activo Cte", Calculos.ActivoCorriente(baseP), Calculos.ActivoCorriente(compP)),
                    Tuple.Create("Activo No Cte", Calculos.ActivoNoCorriente(baseP), Calculos.ActivoNoCorriente(compP)),
                    Tuple.Create("Pasivo Cte", Calculos.PasivoCorriente(baseP), Calculos.PasivoCorriente(compP)),
                    Tuple.Create("Pasivo No Cte", Calculos.PasivoNoCorriente(baseP), Calculos.PasivoNoCorriente(compP)),
                    Tuple.Create("Patrimonio", Calculos.Patrimonio(baseP), Calculos.Patrimonio(compP)),
                    Tuple.Create("Ventas", Calculos.Ventas(baseP), Calculos.Ventas(compP)),
                    Tuple.Create("Utilidad Neta", Calculos.UtilidadNeta(baseP), Calculos.UtilidadNeta(compP))
                };

                // Ordenar por Valor o Nombre según filtro
                if (ordenar == "Valor")
                {
                    lista = lista.OrderByDescending(t => Math.Abs(t.Item3)).ToList();
                }
                else if (ordenar == "Nombre")
                {
                    lista = lista.OrderBy(t => t.Item1).ToList();
                }

                // Top N
                int topN = int.TryParse(cmbTopN.SelectedItem?.ToString(), out int n) ? n : 5;
                if (topN > 0 && topN < lista.Count)
                {
                    lista = lista.Take(topN).ToList();
                }

                // Si se selecciona mostrar variación porcentual
                if (mostrar == "Porcentaje")
                {
                    var datosVar = lista.Select(t =>
                    {
                        decimal b = t.Item2;
                        decimal c = t.Item3;
                        decimal pct = b != 0m ? ((c - b) / Math.Abs(b)) * 100m : 0m;
                        return new DatoGraficoItem(t.Item1, pct);
                    }).ToList();

                    RenderizarGrafico(
                        _chart1,
                        lblAreaGrafico1,
                        "Variación % (" + baseP.Nombre + " vs " + compP.Nombre + ")",
                        datosVar,
                        null,
                        "Variación %",
                        null,
                        tipoStr,
                        estiloStr,
                        false);
                    return;
                }

                var itemsBase = lista.Select(t => new DatoGraficoItem(t.Item1, t.Item2)).ToList();
                var itemsComp = lista.Select(t => new DatoGraficoItem(t.Item1, t.Item3)).ToList();

                RenderizarGrafico(
                    _chart1,
                    lblAreaGrafico1,
                    "Análisis Horizontal (" + baseP.Nombre + " vs " + compP.Nombre + ")",
                    itemsBase,
                    itemsComp,
                    baseP.Nombre,
                    compP.Nombre,
                    tipoStr,
                    estiloStr,
                    true);
            }
            catch (Exception ex)
            {
                MostrarMensajeVacio(_chart1, lblAreaGrafico1, "No se puede renderizar el gráfico 1: " + ex.Message);
            }
        }

        // ─────────────────────────────────────────────────────────────────────
        // 2. RAZONES FINANCIERAS (COMPARADO)
        // ─────────────────────────────────────────────────────────────────────
        private void ActualizarGrafico2()
        {
            try
            {
                if (_chart2 == null) return;

                Periodo baseP = ObtenerPeriodoBase();
                Periodo compP = ObtenerPeriodoComp();

                if (baseP == null || compP == null || (!baseP.TieneDatos && !compP.TieneDatos))
                {
                    MostrarMensajeVacio(_chart2, lblAreaGrafico2, "No hay datos para calcular razones financieras.\nPresione 'Cargar Demo' en la pestaña Datos.");
                    return;
                }

                string tipoStr = cmbTipoGrafico2.SelectedItem?.ToString() ?? "Barras";
                string estiloStr = cmbEstiloGrafico2.SelectedItem?.ToString() ?? "Clásico";

                var razonesBase = Calculos.Razones(baseP).ToDictionary(r => r.Nombre, r => ExtraerDecimal(r.ValorTexto));
                var razonesComp = Calculos.Razones(compP).ToDictionary(r => r.Nombre, r => ExtraerDecimal(r.ValorTexto));

                string[] indicadores = new[]
                {
                    "Razón corriente", "Prueba ácida", "Deuda sobre activo",
                    "Rotación de activos", "Margen neto", "ROA", "ROE"
                };

                var itemsBase = indicadores.Select(ind =>
                    new DatoGraficoItem(ind, razonesBase.ContainsKey(ind) ? razonesBase[ind] : 0m)).ToList();

                var itemsComp = indicadores.Select(ind =>
                    new DatoGraficoItem(ind, razonesComp.ContainsKey(ind) ? razonesComp[ind] : 0m)).ToList();

                RenderizarGrafico(
                    _chart2,
                    lblAreaGrafico2,
                    "Razones Financieras",
                    itemsBase,
                    itemsComp,
                    baseP.Nombre,
                    compP.Nombre,
                    tipoStr,
                    estiloStr,
                    true);
            }
            catch (Exception ex)
            {
                MostrarMensajeVacio(_chart2, lblAreaGrafico2, "No se puede renderizar el gráfico 2: " + ex.Message);
            }
        }

        // ─────────────────────────────────────────────────────────────────────
        // 3. CAPITAL NETO DE TRABAJO (CNT) Y CNO
        // ─────────────────────────────────────────────────────────────────────
        private void ActualizarGrafico3()
        {
            try
            {
                if (_chart3 == null) return;

                Periodo baseP = ObtenerPeriodoBase();
                Periodo compP = ObtenerPeriodoComp();

                if (baseP == null || compP == null || (!baseP.TieneDatos && !compP.TieneDatos))
                {
                    MostrarMensajeVacio(_chart3, lblAreaGrafico3, "No hay datos para calcular el capital de trabajo.\nPresione 'Cargar Demo' en la pestaña Datos.");
                    return;
                }

                string tipoStr = cmbTipoGrafico3.SelectedItem?.ToString() ?? "Barras";
                string estiloStr = cmbEstiloGrafico3.SelectedItem?.ToString() ?? "Clásico";

                decimal cntBase = Calculos.ActivoCorriente(baseP) - Calculos.PasivoCorriente(baseP);
                decimal cntComp = Calculos.ActivoCorriente(compP) - Calculos.PasivoCorriente(compP);

                decimal actOpBase = SumarOperativo(baseP, Clasif.ActivoCorriente);
                decimal pasOpBase = SumarOperativo(baseP, Clasif.PasivoCorriente);
                decimal cnoBase = actOpBase - pasOpBase;

                decimal actOpComp = SumarOperativo(compP, Clasif.ActivoCorriente);
                decimal pasOpComp = SumarOperativo(compP, Clasif.PasivoCorriente);
                decimal cnoComp = actOpComp - pasOpComp;

                var itemsBase = new List<DatoGraficoItem>
                {
                    new DatoGraficoItem("Activo Cte", Calculos.ActivoCorriente(baseP)),
                    new DatoGraficoItem("Pasivo Cte", Calculos.PasivoCorriente(baseP)),
                    new DatoGraficoItem("CNT", cntBase),
                    new DatoGraficoItem("Act. Operativo", actOpBase),
                    new DatoGraficoItem("Pas. Operativo", pasOpBase),
                    new DatoGraficoItem("CNO", cnoBase)
                };

                var itemsComp = new List<DatoGraficoItem>
                {
                    new DatoGraficoItem("Activo Cte", Calculos.ActivoCorriente(compP)),
                    new DatoGraficoItem("Pasivo Cte", Calculos.PasivoCorriente(compP)),
                    new DatoGraficoItem("CNT", cntComp),
                    new DatoGraficoItem("Act. Operativo", actOpComp),
                    new DatoGraficoItem("Pas. Operativo", pasOpComp),
                    new DatoGraficoItem("CNO", cnoComp)
                };

                RenderizarGrafico(
                    _chart3,
                    lblAreaGrafico3,
                    "Capital Neto de Trabajo (CNT) y CNO",
                    itemsBase,
                    itemsComp,
                    baseP.Nombre,
                    compP.Nombre,
                    tipoStr,
                    estiloStr,
                    true);
            }
            catch (Exception ex)
            {
                MostrarMensajeVacio(_chart3, lblAreaGrafico3, "No se puede renderizar el gráfico 3: " + ex.Message);
            }
        }

        // ─────────────────────────────────────────────────────────────────────
        // 4. EOAF (ORIGEN Y APLICACIÓN DE FONDOS)
        // ─────────────────────────────────────────────────────────────────────
        private void ActualizarGrafico4()
        {
            try
            {
                if (_chart4 == null) return;

                Periodo baseP = ObtenerPeriodoBase();
                Periodo compP = ObtenerPeriodoComp();

                if (baseP == null || compP == null || (!baseP.TieneDatos && !compP.TieneDatos))
                {
                    MostrarMensajeVacio(_chart4, lblAreaGrafico4, "No hay periodos comparativos para generar el EOAF.\nPresione 'Cargar Demo' en la pestaña Datos.");
                    return;
                }

                string tipoStr = cmbTipoGrafico4.SelectedItem?.ToString() ?? "Barras";
                string estiloStr = cmbEstiloGrafico4.SelectedItem?.ToString() ?? "Clásico";

                ResultadoEoaf eoaf = Calculos.Eoaf(baseP, compP);

                // Si el tipo es Pastel o Dona, mostramos Orígenes vs Aplicaciones totales
                SeriesChartType chartType = ObtenerTipoSerie(tipoStr);
                if (chartType == SeriesChartType.Pie || chartType == SeriesChartType.Doughnut)
                {
                    var itemsTotales = new List<DatoGraficoItem>
                    {
                        new DatoGraficoItem("Total Orígenes", eoaf.TotalOrigen),
                        new DatoGraficoItem("Total Aplicaciones", eoaf.TotalAplicacion)
                    };

                    RenderizarGrafico(
                        _chart4,
                        lblAreaGrafico4,
                        "EOAF: Orígenes vs Aplicaciones",
                        itemsTotales,
                        null,
                        "EOAF",
                        null,
                        tipoStr,
                        estiloStr,
                        false);
                    return;
                }

                // Para barras, líneas, polar o radar: tomamos las cuentas principales
                var topOrigenes = eoaf.Filas.Where(f => f.Origen > 0).OrderByDescending(f => f.Origen).Take(3).ToList();
                var topAplicaciones = eoaf.Filas.Where(f => f.Aplicacion > 0).OrderByDescending(f => f.Aplicacion).Take(3).ToList();

                var itemsOrigen = new List<DatoGraficoItem>
                {
                    new DatoGraficoItem("Total General", eoaf.TotalOrigen)
                };
                foreach (var o in topOrigenes) itemsOrigen.Add(new DatoGraficoItem(TruncarTexto(o.Cuenta, 14), o.Origen));

                var itemsAplicacion = new List<DatoGraficoItem>
                {
                    new DatoGraficoItem("Total General", eoaf.TotalAplicacion)
                };
                foreach (var a in topAplicaciones) itemsAplicacion.Add(new DatoGraficoItem(TruncarTexto(a.Cuenta, 14), a.Aplicacion));

                RenderizarGrafico(
                    _chart4,
                    lblAreaGrafico4,
                    "Estado de Origen y Aplicación de Fondos",
                    itemsOrigen,
                    itemsAplicacion,
                    "Orígenes",
                    "Aplicaciones",
                    tipoStr,
                    estiloStr,
                    true);
            }
            catch (Exception ex)
            {
                MostrarMensajeVacio(_chart4, lblAreaGrafico4, "No se puede renderizar el gráfico 4: " + ex.Message);
            }
        }

        // ─────────────────────────────────────────────────────────────────────
        // 5. ESTADO DE FLUJO DE EFECTIVO
        // ─────────────────────────────────────────────────────────────────────
        private void ActualizarGrafico5()
        {
            try
            {
                if (_chart5 == null) return;

                Periodo baseP = ObtenerPeriodoBase();
                Periodo compP = ObtenerPeriodoComp();

                if (baseP == null || compP == null || (!baseP.TieneDatos && !compP.TieneDatos))
                {
                    MostrarMensajeVacio(_chart5, lblAreaGrafico5, "No hay datos para calcular el flujo de efectivo.\nPresione 'Cargar Demo' en la pestaña Datos.");
                    return;
                }

                string tipoStr = cmbTipoGrafico5.SelectedItem?.ToString() ?? "Barras";
                string estiloStr = cmbEstiloGrafico5.SelectedItem?.ToString() ?? "Clásico";

                ResultadoEfe efe = Calculos.Efe(baseP, compP, true);

                decimal flujoOp = ObtenerMontoEfe(efe, "ACTIVIDADES DE OPERACIÓN");
                decimal flujoInv = ObtenerMontoEfe(efe, "ACTIVIDADES DE INVERSIÓN");
                decimal flujoFin = ObtenerMontoEfe(efe, "ACTIVIDADES DE FINANCIACIÓN");
                decimal flujoNeto = flujoOp + flujoInv + flujoFin;

                var items = new List<DatoGraficoItem>
                {
                    new DatoGraficoItem("Operación", flujoOp),
                    new DatoGraficoItem("Inversión", flujoInv),
                    new DatoGraficoItem("Financiación", flujoFin),
                    new DatoGraficoItem("Flujo Neto", flujoNeto)
                };

                RenderizarGrafico(
                    _chart5,
                    lblAreaGrafico5,
                    "Flujo de Efectivo",
                    items,
                    null,
                    "Flujo",
                    null,
                    tipoStr,
                    estiloStr,
                    false);
            }
            catch (Exception ex)
            {
                MostrarMensajeVacio(_chart5, lblAreaGrafico5, "No se puede renderizar el gráfico 5: " + ex.Message);
            }
        }

        // ─────────────────────────────────────────────────────────────────────
        // 6. MODELO DUPONT (COMPARADO)
        // ─────────────────────────────────────────────────────────────────────
        private void ActualizarGrafico6()
        {
            try
            {
                if (_chart6 == null) return;

                Periodo baseP = ObtenerPeriodoBase();
                Periodo compP = ObtenerPeriodoComp();

                if (baseP == null || compP == null || (!baseP.TieneDatos && !compP.TieneDatos))
                {
                    MostrarMensajeVacio(_chart6, lblAreaGrafico6, "No hay datos para calcular el modelo DuPont.\nPresione 'Cargar Demo' en la pestaña Datos.");
                    return;
                }

                string tipoStr = cmbTipoGrafico6.SelectedItem?.ToString() ?? "Barras";
                string estiloStr = cmbEstiloGrafico6.SelectedItem?.ToString() ?? "Clásico";

                var dupontBase = ExtraerDuPontValores(baseP);
                var dupontComp = ExtraerDuPontValores(compP);

                string[] indicadores = new[]
                {
                    "Margen Neto (%)",
                    "Rot. Activos (x)",
                    "Mult. Capital (x)",
                    "ROA (%)",
                    "ROE (%)"
                };

                var itemsBase = indicadores.Select(ind =>
                    new DatoGraficoItem(ind, dupontBase.ContainsKey(ind) ? (decimal)dupontBase[ind] : 0m)).ToList();

                var itemsComp = indicadores.Select(ind =>
                    new DatoGraficoItem(ind, dupontComp.ContainsKey(ind) ? (decimal)dupontComp[ind] : 0m)).ToList();

                RenderizarGrafico(
                    _chart6,
                    lblAreaGrafico6,
                    "Modelo DuPont",
                    itemsBase,
                    itemsComp,
                    baseP.Nombre,
                    compP.Nombre,
                    tipoStr,
                    estiloStr,
                    true);
            }
            catch (Exception ex)
            {
                MostrarMensajeVacio(_chart6, lblAreaGrafico6, "No se puede renderizar el gráfico 6: " + ex.Message);
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
            dict["Rot. Activos (x)"] = rotacion;
            dict["Mult. Capital (x)"] = multiplicador;
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

        private decimal ExtraerDecimal(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return 0m;

            string limpio = texto.Replace("%", "").Replace("x", "").Replace("veces", "").Replace("días", "").Replace("C$", "").Replace(",", "").Trim();
            if (decimal.TryParse(limpio, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal valor))
            {
                return valor;
            }
            if (decimal.TryParse(limpio, out valor))
            {
                return valor;
            }
            return 0m;
        }

        private string TruncarTexto(string texto, int longitudMaxima)
        {
            if (string.IsNullOrEmpty(texto)) return "";
            if (texto.Length <= longitudMaxima) return texto;
            return texto.Substring(0, longitudMaxima - 2) + "..";
        }
    }
}
