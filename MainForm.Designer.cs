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
            tabControl = new TabControl();
            tpInicio = new TabPage();
            ucInicio = new InicioControl();
            tpDatos = new TabPage();
            ucDatos = new DatosControl();
            tpAnalisis = new TabPage();
            ucAnalisis = new AnalisisControl();
            tpRazones = new TabPage();
            ucRazones = new RazonesControl();
            tpValoracion = new TabPage();
            ucValoracion = new ValoracionControl();
            tpEoaf = new TabPage();
            ucEoaf = new EoafControl();
            tpEfe = new TabPage();
            ucEfe = new EfeControl();
            tpDupont = new TabPage();
            ucDupont = new DupontControl();
            tpIa = new TabPage();
            ucIa = new IaControl();
            tpResumenGlobal = new TabPage();
            ucResumenGlobal = new ResumenGlobalControl();
            tpReportes = new TabPage();
            ucReportes = new ReportesControl();
            tpGraficos = new TabPage();
            ucGraficos = new GraficosControl();
            tpProforma = new TabPage();
            ucProforma = new ProformaControl();
            tpExportar = new TabPage();
            ucExportar = new ExportarControl();
            tpAlmacenamiento = new TabPage();
            ucAlmacenamiento = new AlmacenamientoControl();
            statusStrip = new StatusStrip();
            tsslPie = new ToolStripStatusLabel();
            pnlEncabezado = new Panel();
            lblLogo = new Label();
            lblSubtitulo = new Label();
            pnlEncabezadoDer = new Panel();
            label1 = new Label();
            txtEmpresa = new TextBox();
            label2 = new Label();
            numAnio = new NumericUpDown();
            btnAnadirPeriodo = new Button();
            label3 = new Label();
            cmbPeriodoActivo = new ComboBox();
            tabControl.SuspendLayout();
            tpInicio.SuspendLayout();
            tpDatos.SuspendLayout();
            tpAnalisis.SuspendLayout();
            tpRazones.SuspendLayout();
            tpValoracion.SuspendLayout();
            tpEoaf.SuspendLayout();
            tpEfe.SuspendLayout();
            tpDupont.SuspendLayout();
            tpIa.SuspendLayout();
            tpResumenGlobal.SuspendLayout();
            tpReportes.SuspendLayout();
            tpGraficos.SuspendLayout();
            tpProforma.SuspendLayout();
            tpExportar.SuspendLayout();
            tpAlmacenamiento.SuspendLayout();
            statusStrip.SuspendLayout();
            pnlEncabezado.SuspendLayout();
            pnlEncabezadoDer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numAnio).BeginInit();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tpInicio);
            tabControl.Controls.Add(tpDatos);
            tabControl.Controls.Add(tpAnalisis);
            tabControl.Controls.Add(tpRazones);
            tabControl.Controls.Add(tpValoracion);
            tabControl.Controls.Add(tpEoaf);
            tabControl.Controls.Add(tpEfe);
            tabControl.Controls.Add(tpDupont);
            tabControl.Controls.Add(tpIa);
            tabControl.Controls.Add(tpResumenGlobal);
            tabControl.Controls.Add(tpReportes);
            tabControl.Controls.Add(tpGraficos);
            tabControl.Controls.Add(tpProforma);
            tabControl.Controls.Add(tpExportar);
            tabControl.Controls.Add(tpAlmacenamiento);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 80);
            tabControl.Multiline = true;
            tabControl.Name = "tabControl";
            tabControl.Padding = new Point(14, 6);
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1366, 674);
            tabControl.TabIndex = 0;
            // 
            // tpInicio
            // 
            tpInicio.Controls.Add(ucInicio);
            tpInicio.Location = new Point(4, 68);
            tpInicio.Name = "tpInicio";
            tpInicio.Size = new Size(1358, 602);
            tpInicio.TabIndex = 0;
            tpInicio.Text = "Inicio";
            tpInicio.UseVisualStyleBackColor = true;
            // 
            // ucInicio
            // 
            ucInicio.BackColor = Color.FromArgb(244, 246, 250);
            ucInicio.Dock = DockStyle.Fill;
            ucInicio.Font = new Font("Segoe UI", 9.5F);
            ucInicio.Location = new Point(0, 0);
            ucInicio.Margin = new Padding(4, 4, 4, 4);
            ucInicio.Name = "ucInicio";
            ucInicio.Size = new Size(1358, 602);
            ucInicio.TabIndex = 0;
            // 
            // tpDatos
            // 
            tpDatos.Controls.Add(ucDatos);
            tpDatos.Location = new Point(4, 35);
            tpDatos.Name = "tpDatos";
            tpDatos.Size = new Size(1358, 635);
            tpDatos.TabIndex = 1;
            tpDatos.Text = "Datos";
            tpDatos.UseVisualStyleBackColor = true;
            // 
            // ucDatos
            // 
            ucDatos.BackColor = Color.FromArgb(244, 246, 250);
            ucDatos.Dock = DockStyle.Fill;
            ucDatos.Font = new Font("Segoe UI", 9.5F);
            ucDatos.Location = new Point(0, 0);
            ucDatos.Margin = new Padding(4, 4, 4, 4);
            ucDatos.Name = "ucDatos";
            ucDatos.Size = new Size(1358, 635);
            ucDatos.TabIndex = 0;
            // 
            // tpAnalisis
            // 
            tpAnalisis.Controls.Add(ucAnalisis);
            tpAnalisis.Location = new Point(4, 35);
            tpAnalisis.Name = "tpAnalisis";
            tpAnalisis.Size = new Size(1358, 635);
            tpAnalisis.TabIndex = 2;
            tpAnalisis.Text = "Análisis";
            tpAnalisis.UseVisualStyleBackColor = true;
            // 
            // ucAnalisis
            // 
            ucAnalisis.BackColor = Color.FromArgb(244, 246, 250);
            ucAnalisis.Dock = DockStyle.Fill;
            ucAnalisis.Font = new Font("Segoe UI", 9.5F);
            ucAnalisis.Location = new Point(0, 0);
            ucAnalisis.Margin = new Padding(4, 4, 4, 4);
            ucAnalisis.Name = "ucAnalisis";
            ucAnalisis.Size = new Size(1358, 635);
            ucAnalisis.TabIndex = 0;
            // 
            // tpRazones
            // 
            tpRazones.Controls.Add(ucRazones);
            tpRazones.Location = new Point(4, 35);
            tpRazones.Name = "tpRazones";
            tpRazones.Size = new Size(1358, 635);
            tpRazones.TabIndex = 3;
            tpRazones.Text = "Razones";
            tpRazones.UseVisualStyleBackColor = true;
            // 
            // ucRazones
            // 
            ucRazones.BackColor = Color.FromArgb(244, 246, 250);
            ucRazones.Dock = DockStyle.Fill;
            ucRazones.Font = new Font("Segoe UI", 9.5F);
            ucRazones.Location = new Point(0, 0);
            ucRazones.Margin = new Padding(4, 4, 4, 4);
            ucRazones.Name = "ucRazones";
            ucRazones.Size = new Size(1358, 635);
            ucRazones.TabIndex = 0;
            // 
            // tpValoracion
            // 
            tpValoracion.Controls.Add(ucValoracion);
            tpValoracion.Location = new Point(4, 35);
            tpValoracion.Name = "tpValoracion";
            tpValoracion.Size = new Size(1358, 635);
            tpValoracion.TabIndex = 4;
            tpValoracion.Text = "Valoración";
            tpValoracion.UseVisualStyleBackColor = true;
            // 
            // ucValoracion
            // 
            ucValoracion.BackColor = Color.FromArgb(244, 246, 250);
            ucValoracion.Dock = DockStyle.Fill;
            ucValoracion.Font = new Font("Segoe UI", 9.5F);
            ucValoracion.Location = new Point(0, 0);
            ucValoracion.Margin = new Padding(4, 4, 4, 4);
            ucValoracion.Name = "ucValoracion";
            ucValoracion.Size = new Size(1358, 635);
            ucValoracion.TabIndex = 0;
            // 
            // tpEoaf
            // 
            tpEoaf.Controls.Add(ucEoaf);
            tpEoaf.Location = new Point(4, 35);
            tpEoaf.Name = "tpEoaf";
            tpEoaf.Size = new Size(1358, 635);
            tpEoaf.TabIndex = 5;
            tpEoaf.Text = "EOAF";
            tpEoaf.UseVisualStyleBackColor = true;
            // 
            // ucEoaf
            // 
            ucEoaf.BackColor = Color.FromArgb(244, 246, 250);
            ucEoaf.Dock = DockStyle.Fill;
            ucEoaf.Font = new Font("Segoe UI", 9.5F);
            ucEoaf.Location = new Point(0, 0);
            ucEoaf.Margin = new Padding(4, 4, 4, 4);
            ucEoaf.Name = "ucEoaf";
            ucEoaf.Size = new Size(1358, 635);
            ucEoaf.TabIndex = 0;
            // 
            // tpEfe
            // 
            tpEfe.Controls.Add(ucEfe);
            tpEfe.Location = new Point(4, 35);
            tpEfe.Name = "tpEfe";
            tpEfe.Size = new Size(1358, 635);
            tpEfe.TabIndex = 6;
            tpEfe.Text = "EFE";
            tpEfe.UseVisualStyleBackColor = true;
            // 
            // ucEfe
            // 
            ucEfe.BackColor = Color.FromArgb(244, 246, 250);
            ucEfe.Dock = DockStyle.Fill;
            ucEfe.Font = new Font("Segoe UI", 9.5F);
            ucEfe.Location = new Point(0, 0);
            ucEfe.Margin = new Padding(4, 4, 4, 4);
            ucEfe.Name = "ucEfe";
            ucEfe.Size = new Size(1358, 635);
            ucEfe.TabIndex = 0;
            // 
            // tpDupont
            // 
            tpDupont.Controls.Add(ucDupont);
            tpDupont.Location = new Point(4, 35);
            tpDupont.Name = "tpDupont";
            tpDupont.Size = new Size(1358, 635);
            tpDupont.TabIndex = 7;
            tpDupont.Text = "DuPont";
            tpDupont.UseVisualStyleBackColor = true;
            // 
            // ucDupont
            // 
            ucDupont.BackColor = Color.FromArgb(244, 246, 250);
            ucDupont.Dock = DockStyle.Fill;
            ucDupont.Font = new Font("Segoe UI", 9.5F);
            ucDupont.Location = new Point(0, 0);
            ucDupont.Margin = new Padding(4, 4, 4, 4);
            ucDupont.Name = "ucDupont";
            ucDupont.Size = new Size(1358, 635);
            ucDupont.TabIndex = 0;
            // 
            // tpIa
            // 
            tpIa.Controls.Add(ucIa);
            tpIa.Location = new Point(4, 35);
            tpIa.Name = "tpIa";
            tpIa.Size = new Size(1358, 635);
            tpIa.TabIndex = 8;
            tpIa.Text = "IA";
            tpIa.UseVisualStyleBackColor = true;
            // 
            // ucIa
            // 
            ucIa.BackColor = Color.FromArgb(244, 246, 250);
            ucIa.Dock = DockStyle.Fill;
            ucIa.Font = new Font("Segoe UI", 9.5F);
            ucIa.Location = new Point(0, 0);
            ucIa.Margin = new Padding(4);
            ucIa.Name = "ucIa";
            ucIa.Size = new Size(1358, 635);
            ucIa.TabIndex = 0;
            // 
            // tpResumenGlobal
            // 
            tpResumenGlobal.Controls.Add(ucResumenGlobal);
            tpResumenGlobal.Location = new Point(4, 35);
            tpResumenGlobal.Name = "tpResumenGlobal";
            tpResumenGlobal.Size = new Size(1358, 635);
            tpResumenGlobal.TabIndex = 9;
            tpResumenGlobal.Text = "Resumen Global";
            tpResumenGlobal.UseVisualStyleBackColor = true;
            // 
            // ucResumenGlobal
            // 
            ucResumenGlobal.BackColor = Color.FromArgb(244, 246, 250);
            ucResumenGlobal.Dock = DockStyle.Fill;
            ucResumenGlobal.Font = new Font("Segoe UI", 9.5F);
            ucResumenGlobal.Location = new Point(0, 0);
            ucResumenGlobal.Margin = new Padding(4, 4, 4, 4);
            ucResumenGlobal.Name = "ucResumenGlobal";
            ucResumenGlobal.Size = new Size(1358, 635);
            ucResumenGlobal.TabIndex = 0;
            // 
            // tpReportes
            // 
            tpReportes.Controls.Add(ucReportes);
            tpReportes.Location = new Point(4, 35);
            tpReportes.Name = "tpReportes";
            tpReportes.Size = new Size(1358, 635);
            tpReportes.TabIndex = 10;
            tpReportes.Text = "Reportes";
            tpReportes.UseVisualStyleBackColor = true;
            // 
            // ucReportes
            // 
            ucReportes.BackColor = Color.FromArgb(244, 246, 250);
            ucReportes.Dock = DockStyle.Fill;
            ucReportes.Font = new Font("Segoe UI", 9.5F);
            ucReportes.Location = new Point(0, 0);
            ucReportes.Margin = new Padding(4, 4, 4, 4);
            ucReportes.Name = "ucReportes";
            ucReportes.Size = new Size(1358, 635);
            ucReportes.TabIndex = 0;
            // 
            // tpGraficos
            // 
            tpGraficos.Controls.Add(ucGraficos);
            tpGraficos.Location = new Point(4, 35);
            tpGraficos.Name = "tpGraficos";
            tpGraficos.Size = new Size(1358, 635);
            tpGraficos.TabIndex = 11;
            tpGraficos.Text = "Gráficos";
            tpGraficos.UseVisualStyleBackColor = true;
            // 
            // ucGraficos
            // 
            ucGraficos.BackColor = Color.FromArgb(244, 246, 250);
            ucGraficos.Dock = DockStyle.Fill;
            ucGraficos.Font = new Font("Segoe UI", 9.5F);
            ucGraficos.Location = new Point(0, 0);
            ucGraficos.Margin = new Padding(4, 4, 4, 4);
            ucGraficos.Name = "ucGraficos";
            ucGraficos.Size = new Size(1358, 635);
            ucGraficos.TabIndex = 0;
            // 
            // tpProforma
            // 
            tpProforma.Controls.Add(ucProforma);
            tpProforma.Location = new Point(4, 35);
            tpProforma.Name = "tpProforma";
            tpProforma.Size = new Size(1358, 635);
            tpProforma.TabIndex = 12;
            tpProforma.Text = "Proforma";
            tpProforma.UseVisualStyleBackColor = true;
            // 
            // ucProforma
            // 
            ucProforma.BackColor = Color.FromArgb(244, 246, 250);
            ucProforma.Dock = DockStyle.Fill;
            ucProforma.Font = new Font("Segoe UI", 9.5F);
            ucProforma.Location = new Point(0, 0);
            ucProforma.Margin = new Padding(4, 4, 4, 4);
            ucProforma.Name = "ucProforma";
            ucProforma.Size = new Size(1358, 635);
            ucProforma.TabIndex = 0;
            // 
            // tpExportar
            // 
            tpExportar.Controls.Add(ucExportar);
            tpExportar.Location = new Point(4, 35);
            tpExportar.Name = "tpExportar";
            tpExportar.Size = new Size(1358, 635);
            tpExportar.TabIndex = 13;
            tpExportar.Text = "Exportar";
            tpExportar.UseVisualStyleBackColor = true;
            // 
            // ucExportar
            // 
            ucExportar.BackColor = Color.FromArgb(244, 246, 250);
            ucExportar.Dock = DockStyle.Fill;
            ucExportar.Font = new Font("Segoe UI", 9.5F);
            ucExportar.Location = new Point(0, 0);
            ucExportar.Margin = new Padding(4, 4, 4, 4);
            ucExportar.Name = "ucExportar";
            ucExportar.Size = new Size(1358, 635);
            ucExportar.TabIndex = 0;
            // 
            // tpAlmacenamiento
            // 
            tpAlmacenamiento.Controls.Add(ucAlmacenamiento);
            tpAlmacenamiento.Location = new Point(4, 35);
            tpAlmacenamiento.Name = "tpAlmacenamiento";
            tpAlmacenamiento.Size = new Size(1358, 635);
            tpAlmacenamiento.TabIndex = 14;
            tpAlmacenamiento.Text = "Almacenamiento";
            tpAlmacenamiento.UseVisualStyleBackColor = true;
            // 
            // ucAlmacenamiento
            // 
            ucAlmacenamiento.BackColor = Color.FromArgb(244, 246, 250);
            ucAlmacenamiento.Dock = DockStyle.Fill;
            ucAlmacenamiento.Font = new Font("Segoe UI", 9.5F);
            ucAlmacenamiento.Location = new Point(0, 0);
            ucAlmacenamiento.Margin = new Padding(4, 4, 4, 4);
            ucAlmacenamiento.Name = "ucAlmacenamiento";
            ucAlmacenamiento.Size = new Size(1358, 635);
            ucAlmacenamiento.TabIndex = 0;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { tsslPie });
            statusStrip.Location = new Point(0, 754);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(1366, 26);
            statusStrip.TabIndex = 1;
            // 
            // tsslPie
            // 
            tsslPie.Name = "tsslPie";
            tsslPie.Size = new Size(680, 20);
            tsslPie.Text = "© 2026 LookScan | Gestión Financiera Operativa — UNIVERSIDAD NACIONAL DE INGENIERÍA – RUSB";
            // 
            // pnlEncabezado
            // 
            pnlEncabezado.BackColor = Color.FromArgb(24, 72, 140);
            pnlEncabezado.Controls.Add(lblLogo);
            pnlEncabezado.Controls.Add(lblSubtitulo);
            pnlEncabezado.Controls.Add(pnlEncabezadoDer);
            pnlEncabezado.Dock = DockStyle.Top;
            pnlEncabezado.Location = new Point(0, 0);
            pnlEncabezado.Name = "pnlEncabezado";
            pnlEncabezado.Size = new Size(1366, 80);
            pnlEncabezado.TabIndex = 2;
            // 
            // lblLogo
            // 
            lblLogo.AutoSize = true;
            lblLogo.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            lblLogo.ForeColor = Color.FromArgb(255, 255, 255);
            lblLogo.Location = new Point(16, 8);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(168, 46);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "LookScan";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.ForeColor = Color.FromArgb(220, 220, 220);
            lblSubtitulo.Location = new Point(20, 50);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(230, 21);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Análisis financiero multiperiodo";
            // 
            // pnlEncabezadoDer
            // 
            pnlEncabezadoDer.BackColor = Color.Transparent;
            pnlEncabezadoDer.Controls.Add(label1);
            pnlEncabezadoDer.Controls.Add(txtEmpresa);
            pnlEncabezadoDer.Controls.Add(label2);
            pnlEncabezadoDer.Controls.Add(numAnio);
            pnlEncabezadoDer.Controls.Add(btnAnadirPeriodo);
            pnlEncabezadoDer.Controls.Add(label3);
            pnlEncabezadoDer.Controls.Add(cmbPeriodoActivo);
            pnlEncabezadoDer.Dock = DockStyle.Right;
            pnlEncabezadoDer.Location = new Point(686, 0);
            pnlEncabezadoDer.Name = "pnlEncabezadoDer";
            pnlEncabezadoDer.Size = new Size(680, 80);
            pnlEncabezadoDer.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.FromArgb(255, 255, 255);
            label1.Location = new Point(10, 10);
            label1.Name = "label1";
            label1.Size = new Size(153, 21);
            label1.TabIndex = 0;
            label1.Text = "Nombre de empresa";
            // 
            // txtEmpresa
            // 
            txtEmpresa.Location = new Point(10, 32);
            txtEmpresa.Name = "txtEmpresa";
            txtEmpresa.Size = new Size(220, 29);
            txtEmpresa.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.FromArgb(255, 255, 255);
            label2.Location = new Point(244, 10);
            label2.Name = "label2";
            label2.Size = new Size(154, 21);
            label2.TabIndex = 2;
            label2.Text = "Añadir periodo (año)";
            // 
            // numAnio
            // 
            numAnio.Location = new Point(244, 32);
            numAnio.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            numAnio.Minimum = new decimal(new int[] { 1990, 0, 0, 0 });
            numAnio.Name = "numAnio";
            numAnio.Size = new Size(110, 29);
            numAnio.TabIndex = 3;
            numAnio.Value = new decimal(new int[] { 2025, 0, 0, 0 });
            // 
            // btnAnadirPeriodo
            // 
            btnAnadirPeriodo.BackColor = Color.FromArgb(255, 255, 255);
            btnAnadirPeriodo.Cursor = Cursors.Hand;
            btnAnadirPeriodo.FlatAppearance.BorderColor = Color.FromArgb(24, 72, 140);
            btnAnadirPeriodo.FlatStyle = FlatStyle.Flat;
            btnAnadirPeriodo.ForeColor = Color.FromArgb(24, 72, 140);
            btnAnadirPeriodo.Location = new Point(366, 29);
            btnAnadirPeriodo.Name = "btnAnadirPeriodo";
            btnAnadirPeriodo.Size = new Size(130, 30);
            btnAnadirPeriodo.TabIndex = 4;
            btnAnadirPeriodo.Text = "Añadir periodo";
            btnAnadirPeriodo.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.FromArgb(255, 255, 255);
            label3.Location = new Point(512, 10);
            label3.Name = "label3";
            label3.Size = new Size(108, 21);
            label3.TabIndex = 5;
            label3.Text = "Periodo activo";
            // 
            // cmbPeriodoActivo
            // 
            cmbPeriodoActivo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPeriodoActivo.FormattingEnabled = true;
            cmbPeriodoActivo.Items.AddRange(new object[] { "2023", "2024", "2025" });
            cmbPeriodoActivo.Location = new Point(512, 32);
            cmbPeriodoActivo.Name = "cmbPeriodoActivo";
            cmbPeriodoActivo.Size = new Size(130, 29);
            cmbPeriodoActivo.TabIndex = 6;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 246, 250);
            ClientSize = new Size(1366, 780);
            Controls.Add(tabControl);
            Controls.Add(statusStrip);
            Controls.Add(pnlEncabezado);
            Font = new Font("Segoe UI", 9.5F);
            MinimumSize = new Size(1000, 650);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LookScan";
            tabControl.ResumeLayout(false);
            tpInicio.ResumeLayout(false);
            tpDatos.ResumeLayout(false);
            tpAnalisis.ResumeLayout(false);
            tpRazones.ResumeLayout(false);
            tpValoracion.ResumeLayout(false);
            tpEoaf.ResumeLayout(false);
            tpEfe.ResumeLayout(false);
            tpDupont.ResumeLayout(false);
            tpIa.ResumeLayout(false);
            tpResumenGlobal.ResumeLayout(false);
            tpReportes.ResumeLayout(false);
            tpGraficos.ResumeLayout(false);
            tpProforma.ResumeLayout(false);
            tpExportar.ResumeLayout(false);
            tpAlmacenamiento.ResumeLayout(false);
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            pnlEncabezado.ResumeLayout(false);
            pnlEncabezado.PerformLayout();
            pnlEncabezadoDer.ResumeLayout(false);
            pnlEncabezadoDer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numAnio).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.TabPage tpValoracion;
        private LookScan.ValoracionControl ucValoracion;
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
    }
}
