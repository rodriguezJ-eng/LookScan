using System;
using System.Drawing;
using System.Windows.Forms;

namespace LookScan
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpInicio = new System.Windows.Forms.TabPage();
            this.tpDatos = new System.Windows.Forms.TabPage();
            this.tpAnalisis = new System.Windows.Forms.TabPage();
            this.tpRazones = new System.Windows.Forms.TabPage();
            this.tpEoaf = new System.Windows.Forms.TabPage();
            this.tpEfe = new System.Windows.Forms.TabPage();
            this.tpDupont = new System.Windows.Forms.TabPage();
            this.tpIa = new System.Windows.Forms.TabPage();
            this.tpResumenGlobal = new System.Windows.Forms.TabPage();
            this.tpReportes = new System.Windows.Forms.TabPage();
            this.tpGraficos = new System.Windows.Forms.TabPage();
            this.tpProforma = new System.Windows.Forms.TabPage();
            this.tpExportar = new System.Windows.Forms.TabPage();
            this.tpAlmacenamiento = new System.Windows.Forms.TabPage();
            this.tpPresupuesto = new System.Windows.Forms.TabPage();
            this.tpInventario = new System.Windows.Forms.TabPage();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tsslPie = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlEncabezado = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.pnlEncabezadoDer = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmpresa = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numAnio = new System.Windows.Forms.NumericUpDown();
            this.btnAnadirPeriodo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbPeriodoActivo = new System.Windows.Forms.ComboBox();
            this.ucInicio = new LookScan.InicioControl();
            this.ucDatos = new LookScan.DatosControl();
            this.ucAnalisis = new LookScan.AnalisisControl();
            this.ucRazones = new LookScan.RazonesControl();
            this.ucEoaf = new LookScan.EoafControl();
            this.ucEfe = new LookScan.EfeControl();
            this.ucDupont = new LookScan.DupontControl();
            this.ucIa = new LookScan.IaControl();
            this.ucResumenGlobal = new LookScan.ResumenGlobalControl();
            this.ucReportes = new LookScan.ReportesControl();
            this.ucGraficos = new LookScan.GraficosControl();
            this.ucProforma = new LookScan.ProformaControl();
            this.ucExportar = new LookScan.ExportarControl();
            this.ucAlmacenamiento = new LookScan.AlmacenamientoControl();
            this.ucPresupuesto = new LookScan.PresupuestoControl();
            this.ucInventario = new LookScan.InventarioControl();
            this.tpGradoApalancamiento = new System.Windows.Forms.TabPage();
            this.grbGradoApalancamiento = new System.Windows.Forms.GroupBox();
            this.lblPeriodoAnalizar = new System.Windows.Forms.Label();
            this.cmbGradoApalancamiento = new System.Windows.Forms.ComboBox();
            this.btnGenerarErYapalancamiento = new System.Windows.Forms.Button();
            this.grbEstadoDeResultado = new System.Windows.Forms.GroupBox();
            this.dgvEstadoDeResultado = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbResultadoApalancamiento = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dgvGrados = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl.SuspendLayout();
            this.tpInicio.SuspendLayout();
            this.tpDatos.SuspendLayout();
            this.tpAnalisis.SuspendLayout();
            this.tpRazones.SuspendLayout();
            this.tpEoaf.SuspendLayout();
            this.tpEfe.SuspendLayout();
            this.tpDupont.SuspendLayout();
            this.tpIa.SuspendLayout();
            this.tpResumenGlobal.SuspendLayout();
            this.tpReportes.SuspendLayout();
            this.tpGraficos.SuspendLayout();
            this.tpProforma.SuspendLayout();
            this.tpExportar.SuspendLayout();
            this.tpAlmacenamiento.SuspendLayout();
            this.tpPresupuesto.SuspendLayout();
            this.tpInventario.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.pnlEncabezado.SuspendLayout();
            this.pnlEncabezadoDer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAnio)).BeginInit();
            this.tpGradoApalancamiento.SuspendLayout();
            this.grbGradoApalancamiento.SuspendLayout();
            this.grbEstadoDeResultado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstadoDeResultado)).BeginInit();
            this.grbResultadoApalancamiento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrados)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpInicio);
            this.tabControl.Controls.Add(this.tpDatos);
            this.tabControl.Controls.Add(this.tpAnalisis);
            this.tabControl.Controls.Add(this.tpRazones);
            this.tabControl.Controls.Add(this.tpDupont);
            this.tabControl.Controls.Add(this.tpGradoApalancamiento);
            this.tabControl.Controls.Add(this.tpEoaf);
            this.tabControl.Controls.Add(this.tpEfe);
            this.tabControl.Controls.Add(this.tpIa);
            this.tabControl.Controls.Add(this.tpResumenGlobal);
            this.tabControl.Controls.Add(this.tpReportes);
            this.tabControl.Controls.Add(this.tpGraficos);
            this.tabControl.Controls.Add(this.tpProforma);
            this.tabControl.Controls.Add(this.tpExportar);
            this.tabControl.Controls.Add(this.tpAlmacenamiento);
            this.tabControl.Controls.Add(this.tpPresupuesto);
            this.tabControl.Controls.Add(this.tpInventario);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 80);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.Padding = new System.Drawing.Point(14, 6);
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1523, 674);
            this.tabControl.TabIndex = 0;
            // 
            // tpInicio
            // 
            this.tpInicio.Controls.Add(this.ucInicio);
            this.tpInicio.Location = new System.Drawing.Point(4, 36);
            this.tpInicio.Name = "tpInicio";
            this.tpInicio.Size = new System.Drawing.Size(1515, 634);
            this.tpInicio.TabIndex = 0;
            this.tpInicio.Text = "Inicio";
            this.tpInicio.UseVisualStyleBackColor = true;
            // 
            // tpDatos
            // 
            this.tpDatos.Controls.Add(this.ucDatos);
            this.tpDatos.Location = new System.Drawing.Point(4, 36);
            this.tpDatos.Name = "tpDatos";
            this.tpDatos.Size = new System.Drawing.Size(1515, 634);
            this.tpDatos.TabIndex = 1;
            this.tpDatos.Text = "Datos";
            this.tpDatos.UseVisualStyleBackColor = true;
            // 
            // tpAnalisis
            // 
            this.tpAnalisis.Controls.Add(this.ucAnalisis);
            this.tpAnalisis.Location = new System.Drawing.Point(4, 36);
            this.tpAnalisis.Name = "tpAnalisis";
            this.tpAnalisis.Size = new System.Drawing.Size(1515, 634);
            this.tpAnalisis.TabIndex = 2;
            this.tpAnalisis.Text = "Análisis";
            this.tpAnalisis.UseVisualStyleBackColor = true;
            // 
            // tpRazones
            // 
            this.tpRazones.Controls.Add(this.ucRazones);
            this.tpRazones.Location = new System.Drawing.Point(4, 36);
            this.tpRazones.Name = "tpRazones";
            this.tpRazones.Size = new System.Drawing.Size(1515, 634);
            this.tpRazones.TabIndex = 3;
            this.tpRazones.Text = "Razones";
            this.tpRazones.UseVisualStyleBackColor = true;
            // 
            // tpEoaf
            // 
            this.tpEoaf.Controls.Add(this.ucEoaf);
            this.tpEoaf.Location = new System.Drawing.Point(4, 36);
            this.tpEoaf.Name = "tpEoaf";
            this.tpEoaf.Size = new System.Drawing.Size(1515, 634);
            this.tpEoaf.TabIndex = 5;
            this.tpEoaf.Text = "EOAF";
            this.tpEoaf.UseVisualStyleBackColor = true;
            // 
            // tpEfe
            // 
            this.tpEfe.Controls.Add(this.ucEfe);
            this.tpEfe.Location = new System.Drawing.Point(4, 36);
            this.tpEfe.Name = "tpEfe";
            this.tpEfe.Size = new System.Drawing.Size(1515, 634);
            this.tpEfe.TabIndex = 6;
            this.tpEfe.Text = "EFE";
            this.tpEfe.UseVisualStyleBackColor = true;
            // 
            // tpDupont
            // 
            this.tpDupont.Controls.Add(this.ucDupont);
            this.tpDupont.Location = new System.Drawing.Point(4, 36);
            this.tpDupont.Name = "tpDupont";
            this.tpDupont.Size = new System.Drawing.Size(1515, 634);
            this.tpDupont.TabIndex = 7;
            this.tpDupont.Text = "DuPont";
            this.tpDupont.UseVisualStyleBackColor = true;
            // 
            // tpIa
            // 
            this.tpIa.Controls.Add(this.ucIa);
            this.tpIa.Location = new System.Drawing.Point(4, 36);
            this.tpIa.Name = "tpIa";
            this.tpIa.Size = new System.Drawing.Size(1515, 634);
            this.tpIa.TabIndex = 8;
            this.tpIa.Text = "IA";
            this.tpIa.UseVisualStyleBackColor = true;
            // 
            // tpResumenGlobal
            // 
            this.tpResumenGlobal.Controls.Add(this.ucResumenGlobal);
            this.tpResumenGlobal.Location = new System.Drawing.Point(4, 36);
            this.tpResumenGlobal.Name = "tpResumenGlobal";
            this.tpResumenGlobal.Size = new System.Drawing.Size(1515, 634);
            this.tpResumenGlobal.TabIndex = 9;
            this.tpResumenGlobal.Text = "Resumen Global";
            this.tpResumenGlobal.UseVisualStyleBackColor = true;
            // 
            // tpReportes
            // 
            this.tpReportes.Controls.Add(this.ucReportes);
            this.tpReportes.Location = new System.Drawing.Point(4, 36);
            this.tpReportes.Name = "tpReportes";
            this.tpReportes.Size = new System.Drawing.Size(1515, 634);
            this.tpReportes.TabIndex = 10;
            this.tpReportes.Text = "Reportes";
            this.tpReportes.UseVisualStyleBackColor = true;
            // 
            // tpGraficos
            // 
            this.tpGraficos.Controls.Add(this.ucGraficos);
            this.tpGraficos.Location = new System.Drawing.Point(4, 36);
            this.tpGraficos.Name = "tpGraficos";
            this.tpGraficos.Size = new System.Drawing.Size(1515, 634);
            this.tpGraficos.TabIndex = 11;
            this.tpGraficos.Text = "Gráficos";
            this.tpGraficos.UseVisualStyleBackColor = true;
            // 
            // tpProforma
            // 
            this.tpProforma.Controls.Add(this.ucProforma);
            this.tpProforma.Location = new System.Drawing.Point(4, 36);
            this.tpProforma.Name = "tpProforma";
            this.tpProforma.Size = new System.Drawing.Size(1515, 634);
            this.tpProforma.TabIndex = 12;
            this.tpProforma.Text = "Proforma";
            this.tpProforma.UseVisualStyleBackColor = true;
            // 
            // tpExportar
            // 
            this.tpExportar.Controls.Add(this.ucExportar);
            this.tpExportar.Location = new System.Drawing.Point(4, 36);
            this.tpExportar.Name = "tpExportar";
            this.tpExportar.Size = new System.Drawing.Size(1515, 634);
            this.tpExportar.TabIndex = 13;
            this.tpExportar.Text = "Exportar";
            this.tpExportar.UseVisualStyleBackColor = true;
            // 
            // tpAlmacenamiento
            // 
            this.tpAlmacenamiento.Controls.Add(this.ucAlmacenamiento);
            this.tpAlmacenamiento.Location = new System.Drawing.Point(4, 36);
            this.tpAlmacenamiento.Name = "tpAlmacenamiento";
            this.tpAlmacenamiento.Size = new System.Drawing.Size(1515, 634);
            this.tpAlmacenamiento.TabIndex = 14;
            this.tpAlmacenamiento.Text = "Almacenamiento";
            this.tpAlmacenamiento.UseVisualStyleBackColor = true;
            // 
            // tpPresupuesto
            // 
            this.tpPresupuesto.Controls.Add(this.ucPresupuesto);
            this.tpPresupuesto.Location = new System.Drawing.Point(4, 36);
            this.tpPresupuesto.Name = "tpPresupuesto";
            this.tpPresupuesto.Size = new System.Drawing.Size(1515, 634);
            this.tpPresupuesto.TabIndex = 15;
            this.tpPresupuesto.Text = "Presupuesto Personal";
            this.tpPresupuesto.UseVisualStyleBackColor = true;
            // 
            // ucPresupuesto
            // 
            this.ucPresupuesto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPresupuesto.Location = new System.Drawing.Point(0, 0);
            this.ucPresupuesto.Name = "ucPresupuesto";
            this.ucPresupuesto.Size = new System.Drawing.Size(1515, 634);
            this.ucPresupuesto.TabIndex = 0;
            // 
            // tpInventario
            // 
            this.tpInventario.Controls.Add(this.ucInventario);
            this.tpInventario.Location = new System.Drawing.Point(4, 36);
            this.tpInventario.Name = "tpInventario";
            this.tpInventario.Size = new System.Drawing.Size(1515, 634);
            this.tpInventario.TabIndex = 16;
            this.tpInventario.Text = "Inventario";
            this.tpInventario.UseVisualStyleBackColor = true;
            // 
            // ucInventario
            // 
            this.ucInventario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucInventario.Location = new System.Drawing.Point(0, 0);
            this.ucInventario.Name = "ucInventario";
            this.ucInventario.Size = new System.Drawing.Size(1515, 634);
            this.ucInventario.TabIndex = 0;
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslPie});
            this.statusStrip.Location = new System.Drawing.Point(0, 754);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1523, 26);
            this.statusStrip.TabIndex = 1;
            // 
            // tsslPie
            // 
            this.tsslPie.Name = "tsslPie";
            this.tsslPie.Size = new System.Drawing.Size(683, 20);
            this.tsslPie.Text = "© 2026 LookScan—Gestión Financiera Operativa — UNIVERSIDAD NACIONAL DE INGENIERÍA" +
    " – RUSB";
            // 
            // pnlEncabezado
            // 
            this.pnlEncabezado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(72)))), ((int)(((byte)(140)))));
            this.pnlEncabezado.Controls.Add(this.lblLogo);
            this.pnlEncabezado.Controls.Add(this.lblSubtitulo);
            this.pnlEncabezado.Controls.Add(this.pnlEncabezadoDer);
            this.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEncabezado.Location = new System.Drawing.Point(0, 0);
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.Size = new System.Drawing.Size(1523, 80);
            this.pnlEncabezado.TabIndex = 2;
            // 
            // lblLogo
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblLogo.Location = new System.Drawing.Point(16, 8);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(168, 46);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "LookScan";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(20, 50);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(230, 21);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Análisis financiero multiperiodo";
            // 
            // pnlEncabezadoDer
            // 
            this.pnlEncabezadoDer.BackColor = System.Drawing.Color.Transparent;
            this.pnlEncabezadoDer.Controls.Add(this.label1);
            this.pnlEncabezadoDer.Controls.Add(this.txtEmpresa);
            this.pnlEncabezadoDer.Controls.Add(this.label2);
            this.pnlEncabezadoDer.Controls.Add(this.numAnio);
            this.pnlEncabezadoDer.Controls.Add(this.btnAnadirPeriodo);
            this.pnlEncabezadoDer.Controls.Add(this.label3);
            this.pnlEncabezadoDer.Controls.Add(this.cmbPeriodoActivo);
            this.pnlEncabezadoDer.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlEncabezadoDer.Location = new System.Drawing.Point(843, 0);
            this.pnlEncabezadoDer.Name = "pnlEncabezadoDer";
            this.pnlEncabezadoDer.Size = new System.Drawing.Size(680, 80);
            this.pnlEncabezadoDer.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre de empresa";
            // 
            // txtEmpresa
            // 
            this.txtEmpresa.Location = new System.Drawing.Point(10, 32);
            this.txtEmpresa.Name = "txtEmpresa";
            this.txtEmpresa.Size = new System.Drawing.Size(220, 29);
            this.txtEmpresa.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(244, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Añadir periodo (año)";
            // 
            // numAnio
            // 
            this.numAnio.Location = new System.Drawing.Point(244, 32);
            this.numAnio.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.numAnio.Minimum = new decimal(new int[] {
            1990,
            0,
            0,
            0});
            this.numAnio.Name = "numAnio";
            this.numAnio.Size = new System.Drawing.Size(110, 29);
            this.numAnio.TabIndex = 3;
            this.numAnio.Value = new decimal(new int[] {
            2025,
            0,
            0,
            0});
            // 
            // btnAnadirPeriodo
            // 
            this.btnAnadirPeriodo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnAnadirPeriodo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnadirPeriodo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(72)))), ((int)(((byte)(140)))));
            this.btnAnadirPeriodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnadirPeriodo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(72)))), ((int)(((byte)(140)))));
            this.btnAnadirPeriodo.Location = new System.Drawing.Point(366, 29);
            this.btnAnadirPeriodo.Name = "btnAnadirPeriodo";
            this.btnAnadirPeriodo.Size = new System.Drawing.Size(130, 30);
            this.btnAnadirPeriodo.TabIndex = 4;
            this.btnAnadirPeriodo.Text = "Añadir periodo";
            this.btnAnadirPeriodo.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label3.Location = new System.Drawing.Point(512, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Periodo a escoger";
            // 
            // cmbPeriodoActivo
            // 
            this.cmbPeriodoActivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPeriodoActivo.FormattingEnabled = true;
            this.cmbPeriodoActivo.Items.AddRange(new object[] {
            "2023",
            "2024",
            "2025"});
            this.cmbPeriodoActivo.Location = new System.Drawing.Point(512, 32);
            this.cmbPeriodoActivo.Name = "cmbPeriodoActivo";
            this.cmbPeriodoActivo.Size = new System.Drawing.Size(130, 29);
            this.cmbPeriodoActivo.TabIndex = 6;
            // 
            // ucInicio
            // 
            this.ucInicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ucInicio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucInicio.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ucInicio.Location = new System.Drawing.Point(0, 0);
            this.ucInicio.Margin = new System.Windows.Forms.Padding(4);
            this.ucInicio.Name = "ucInicio";
            this.ucInicio.Size = new System.Drawing.Size(1515, 634);
            this.ucInicio.TabIndex = 0;
            // 
            // ucDatos
            // 
            this.ucDatos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ucDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDatos.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ucDatos.Location = new System.Drawing.Point(0, 0);
            this.ucDatos.Margin = new System.Windows.Forms.Padding(4);
            this.ucDatos.Name = "ucDatos";
            this.ucDatos.Size = new System.Drawing.Size(1515, 634);
            this.ucDatos.TabIndex = 0;
            // 
            // ucAnalisis
            // 
            this.ucAnalisis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ucAnalisis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucAnalisis.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ucAnalisis.Location = new System.Drawing.Point(0, 0);
            this.ucAnalisis.Margin = new System.Windows.Forms.Padding(4);
            this.ucAnalisis.Name = "ucAnalisis";
            this.ucAnalisis.Size = new System.Drawing.Size(1515, 634);
            this.ucAnalisis.TabIndex = 0;
            // 
            // ucRazones
            // 
            this.ucRazones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ucRazones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucRazones.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ucRazones.Location = new System.Drawing.Point(0, 0);
            this.ucRazones.Margin = new System.Windows.Forms.Padding(4);
            this.ucRazones.Name = "ucRazones";
            this.ucRazones.Size = new System.Drawing.Size(1515, 634);
            this.ucRazones.TabIndex = 0;
            // 
            // ucEoaf
            // 
            this.ucEoaf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ucEoaf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucEoaf.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ucEoaf.Location = new System.Drawing.Point(0, 0);
            this.ucEoaf.Margin = new System.Windows.Forms.Padding(4);
            this.ucEoaf.Name = "ucEoaf";
            this.ucEoaf.Size = new System.Drawing.Size(1515, 634);
            this.ucEoaf.TabIndex = 0;
            // 
            // ucEfe
            // 
            this.ucEfe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ucEfe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucEfe.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ucEfe.Location = new System.Drawing.Point(0, 0);
            this.ucEfe.Margin = new System.Windows.Forms.Padding(4);
            this.ucEfe.Name = "ucEfe";
            this.ucEfe.Size = new System.Drawing.Size(1515, 634);
            this.ucEfe.TabIndex = 0;
            // 
            // ucDupont
            // 
            this.ucDupont.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ucDupont.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDupont.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ucDupont.Location = new System.Drawing.Point(0, 0);
            this.ucDupont.Margin = new System.Windows.Forms.Padding(4);
            this.ucDupont.Name = "ucDupont";
            this.ucDupont.Size = new System.Drawing.Size(1515, 634);
            this.ucDupont.TabIndex = 0;
            // 
            // ucIa
            // 
            this.ucIa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ucIa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucIa.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ucIa.Location = new System.Drawing.Point(0, 0);
            this.ucIa.Margin = new System.Windows.Forms.Padding(4);
            this.ucIa.Name = "ucIa";
            this.ucIa.Size = new System.Drawing.Size(1515, 634);
            this.ucIa.TabIndex = 0;
            // 
            // ucResumenGlobal
            // 
            this.ucResumenGlobal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ucResumenGlobal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucResumenGlobal.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ucResumenGlobal.Location = new System.Drawing.Point(0, 0);
            this.ucResumenGlobal.Margin = new System.Windows.Forms.Padding(4);
            this.ucResumenGlobal.Name = "ucResumenGlobal";
            this.ucResumenGlobal.Size = new System.Drawing.Size(1515, 634);
            this.ucResumenGlobal.TabIndex = 0;
            // 
            // ucReportes
            // 
            this.ucReportes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ucReportes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucReportes.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ucReportes.Location = new System.Drawing.Point(0, 0);
            this.ucReportes.Margin = new System.Windows.Forms.Padding(4);
            this.ucReportes.Name = "ucReportes";
            this.ucReportes.Size = new System.Drawing.Size(1515, 634);
            this.ucReportes.TabIndex = 0;
            // 
            // ucGraficos
            // 
            this.ucGraficos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ucGraficos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucGraficos.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ucGraficos.Location = new System.Drawing.Point(0, 0);
            this.ucGraficos.Margin = new System.Windows.Forms.Padding(4);
            this.ucGraficos.Name = "ucGraficos";
            this.ucGraficos.Size = new System.Drawing.Size(1515, 634);
            this.ucGraficos.TabIndex = 0;
            // 
            // ucProforma
            // 
            this.ucProforma.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ucProforma.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucProforma.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ucProforma.Location = new System.Drawing.Point(0, 0);
            this.ucProforma.Margin = new System.Windows.Forms.Padding(4);
            this.ucProforma.Name = "ucProforma";
            this.ucProforma.Size = new System.Drawing.Size(1515, 634);
            this.ucProforma.TabIndex = 0;
            // 
            // ucExportar
            // 
            this.ucExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ucExportar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucExportar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ucExportar.Location = new System.Drawing.Point(0, 0);
            this.ucExportar.Margin = new System.Windows.Forms.Padding(4);
            this.ucExportar.Name = "ucExportar";
            this.ucExportar.Size = new System.Drawing.Size(1515, 634);
            this.ucExportar.TabIndex = 0;
            // 
            // ucAlmacenamiento
            // 
            this.ucAlmacenamiento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ucAlmacenamiento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucAlmacenamiento.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ucAlmacenamiento.Location = new System.Drawing.Point(0, 0);
            this.ucAlmacenamiento.Margin = new System.Windows.Forms.Padding(4);
            this.ucAlmacenamiento.Name = "ucAlmacenamiento";
            this.ucAlmacenamiento.Size = new System.Drawing.Size(1515, 634);
            this.ucAlmacenamiento.TabIndex = 0;
            // 
            // tpGradoApalancamiento
            // 
            this.tpGradoApalancamiento.Controls.Add(this.grbResultadoApalancamiento);
            this.tpGradoApalancamiento.Controls.Add(this.grbEstadoDeResultado);
            this.tpGradoApalancamiento.Controls.Add(this.grbGradoApalancamiento);
            this.tpGradoApalancamiento.Location = new System.Drawing.Point(4, 36);
            this.tpGradoApalancamiento.Name = "tpGradoApalancamiento";
            this.tpGradoApalancamiento.Size = new System.Drawing.Size(1515, 634);
            this.tpGradoApalancamiento.TabIndex = 15;
            this.tpGradoApalancamiento.Text = "Apalancamiento ";
            this.tpGradoApalancamiento.UseVisualStyleBackColor = true;
            // 
            // grbGradoApalancamiento
            // 
            this.grbGradoApalancamiento.Controls.Add(this.btnGenerarErYapalancamiento);
            this.grbGradoApalancamiento.Controls.Add(this.cmbGradoApalancamiento);
            this.grbGradoApalancamiento.Controls.Add(this.lblPeriodoAnalizar);
            this.grbGradoApalancamiento.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbGradoApalancamiento.Location = new System.Drawing.Point(8, 12);
            this.grbGradoApalancamiento.Name = "grbGradoApalancamiento";
            this.grbGradoApalancamiento.Size = new System.Drawing.Size(1488, 95);
            this.grbGradoApalancamiento.TabIndex = 0;
            this.grbGradoApalancamiento.TabStop = false;
            this.grbGradoApalancamiento.Text = "Grado de Apalancamiento";
            // 
            // lblPeriodoAnalizar
            // 
            this.lblPeriodoAnalizar.AutoSize = true;
            this.lblPeriodoAnalizar.Location = new System.Drawing.Point(12, 46);
            this.lblPeriodoAnalizar.Name = "lblPeriodoAnalizar";
            this.lblPeriodoAnalizar.Size = new System.Drawing.Size(151, 25);
            this.lblPeriodoAnalizar.TabIndex = 0;
            this.lblPeriodoAnalizar.Text = "Periodo a analizar";
            // 
            // cmbGradoApalancamiento
            // 
            this.cmbGradoApalancamiento.FormattingEnabled = true;
            this.cmbGradoApalancamiento.Location = new System.Drawing.Point(169, 43);
            this.cmbGradoApalancamiento.Name = "cmbGradoApalancamiento";
            this.cmbGradoApalancamiento.Size = new System.Drawing.Size(179, 33);
            this.cmbGradoApalancamiento.TabIndex = 1;
            this.cmbGradoApalancamiento.SelectedIndexChanged += new System.EventHandler(this.cmbGradoApalancamiento_SelectedIndexChanged);
            // 
            // btnGenerarErYapalancamiento
            // 
            this.btnGenerarErYapalancamiento.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarErYapalancamiento.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btnGenerarErYapalancamiento.Location = new System.Drawing.Point(367, 38);
            this.btnGenerarErYapalancamiento.Name = "btnGenerarErYapalancamiento";
            this.btnGenerarErYapalancamiento.Size = new System.Drawing.Size(260, 41);
            this.btnGenerarErYapalancamiento.TabIndex = 2;
            this.btnGenerarErYapalancamiento.Text = "Generar Er y calcular grados";
            this.btnGenerarErYapalancamiento.UseVisualStyleBackColor = true;
            this.btnGenerarErYapalancamiento.Click += new System.EventHandler(this.btnGenerarErYapalancamiento_Click);
            // 
            // grbEstadoDeResultado
            // 
            this.grbEstadoDeResultado.Controls.Add(this.dataGridView1);
            this.grbEstadoDeResultado.Controls.Add(this.dgvEstadoDeResultado);
            this.grbEstadoDeResultado.Location = new System.Drawing.Point(12, 113);
            this.grbEstadoDeResultado.Name = "grbEstadoDeResultado";
            this.grbEstadoDeResultado.Size = new System.Drawing.Size(1493, 351);
            this.grbEstadoDeResultado.TabIndex = 1;
            this.grbEstadoDeResultado.TabStop = false;
            this.grbEstadoDeResultado.Text = "Estado de Resultado";
            // 
            // dgvEstadoDeResultado
            // 
            this.dgvEstadoDeResultado.AllowUserToAddRows = false;
            this.dgvEstadoDeResultado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEstadoDeResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEstadoDeResultado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgvEstadoDeResultado.Location = new System.Drawing.Point(13, 25);
            this.dgvEstadoDeResultado.Name = "dgvEstadoDeResultado";
            this.dgvEstadoDeResultado.RowHeadersWidth = 51;
            this.dgvEstadoDeResultado.RowTemplate.Height = 24;
            this.dgvEstadoDeResultado.Size = new System.Drawing.Size(1471, 306);
            this.dgvEstadoDeResultado.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Cuenta";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Valor";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Porcentaje";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Clasificacion";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            // 
            // grbResultadoApalancamiento
            // 
            this.grbResultadoApalancamiento.Controls.Add(this.dgvGrados);
            this.grbResultadoApalancamiento.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbResultadoApalancamiento.Location = new System.Drawing.Point(8, 470);
            this.grbResultadoApalancamiento.Name = "grbResultadoApalancamiento";
            this.grbResultadoApalancamiento.Size = new System.Drawing.Size(1493, 161);
            this.grbResultadoApalancamiento.TabIndex = 3;
            this.grbResultadoApalancamiento.TabStop = false;
            this.grbResultadoApalancamiento.Text = "Grados de apalancamiento";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 388);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(212, 83);
            this.dataGridView1.TabIndex = 0;
            // 
            // dgvGrados
            // 
            this.dgvGrados.AllowUserToOrderColumns = true;
            this.dgvGrados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGrados.BackgroundColor = System.Drawing.Color.White;
            this.dgvGrados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column6,
            this.Column7});
            this.dgvGrados.Location = new System.Drawing.Point(4, 22);
            this.dgvGrados.Name = "dgvGrados";
            this.dgvGrados.RowHeadersVisible = false;
            this.dgvGrados.RowHeadersWidth = 51;
            this.dgvGrados.RowTemplate.Height = 24;
            this.dgvGrados.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dgvGrados.Size = new System.Drawing.Size(1483, 133);
            this.dgvGrados.TabIndex = 0;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Concepto";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Grado";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Interpretacion";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1523, 780);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.pnlEncabezado);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LookScan";
            this.tabControl.ResumeLayout(false);
            this.tpInicio.ResumeLayout(false);
            this.tpDatos.ResumeLayout(false);
            this.tpAnalisis.ResumeLayout(false);
            this.tpRazones.ResumeLayout(false);
            this.tpEoaf.ResumeLayout(false);
            this.tpEfe.ResumeLayout(false);
            this.tpDupont.ResumeLayout(false);
            this.tpIa.ResumeLayout(false);
            this.tpResumenGlobal.ResumeLayout(false);
            this.tpReportes.ResumeLayout(false);
            this.tpGraficos.ResumeLayout(false);
            this.tpProforma.ResumeLayout(false);
            this.tpExportar.ResumeLayout(false);
            this.tpAlmacenamiento.ResumeLayout(false);
            this.tpPresupuesto.ResumeLayout(false);
            this.tpInventario.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.pnlEncabezado.ResumeLayout(false);
            this.pnlEncabezado.PerformLayout();
            this.pnlEncabezadoDer.ResumeLayout(false);
            this.pnlEncabezadoDer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAnio)).EndInit();
            this.tpGradoApalancamiento.ResumeLayout(false);
            this.grbGradoApalancamiento.ResumeLayout(false);
            this.grbGradoApalancamiento.PerformLayout();
            this.grbEstadoDeResultado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstadoDeResultado)).EndInit();
            this.grbResultadoApalancamiento.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpInicio;
        private LookScan.InicioControl ucInicio;
        private System.Windows.Forms.TabPage tpDatos;
        private LookScan.DatosControl ucDatos;
        private System.Windows.Forms.TabPage tpAnalisis;
        private LookScan.AnalisisControl ucAnalisis;
        private System.Windows.Forms.TabPage tpRazones;
        private LookScan.RazonesControl ucRazones;
        private System.Windows.Forms.TabPage tpEoaf;
        private LookScan.EoafControl ucEoaf;
        private System.Windows.Forms.TabPage tpEfe;
        private LookScan.EfeControl ucEfe;
        private System.Windows.Forms.TabPage tpDupont;
        private LookScan.DupontControl ucDupont;
        private System.Windows.Forms.TabPage tpIa;
        private LookScan.IaControl ucIa;
        private System.Windows.Forms.TabPage tpResumenGlobal;
        private LookScan.ResumenGlobalControl ucResumenGlobal;
        private System.Windows.Forms.TabPage tpReportes;
        private LookScan.ReportesControl ucReportes;
        private System.Windows.Forms.TabPage tpGraficos;
        private LookScan.GraficosControl ucGraficos;
        private System.Windows.Forms.TabPage tpProforma;
        private LookScan.ProformaControl ucProforma;
        private System.Windows.Forms.TabPage tpExportar;
        private LookScan.ExportarControl ucExportar;
        private System.Windows.Forms.TabPage tpAlmacenamiento;
        private LookScan.AlmacenamientoControl ucAlmacenamiento;
        private System.Windows.Forms.TabPage tpPresupuesto;
        private LookScan.PresupuestoControl ucPresupuesto;
        private System.Windows.Forms.TabPage tpInventario;
        private LookScan.InventarioControl ucInventario;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tsslPie;
        private System.Windows.Forms.Panel pnlEncabezado;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Panel pnlEncabezadoDer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmpresa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numAnio;
        private System.Windows.Forms.Button btnAnadirPeriodo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbPeriodoActivo;
        private TabPage tpGradoApalancamiento;
        private GroupBox grbGradoApalancamiento;
        private ComboBox cmbGradoApalancamiento;
        private Label lblPeriodoAnalizar;
        private Button btnGenerarErYapalancamiento;
        private GroupBox grbEstadoDeResultado;
        private DataGridView dgvEstadoDeResultado;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private GroupBox grbResultadoApalancamiento;
        private DataGridView dataGridView1;
        private DataGridView dgvGrados;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
    }
}
