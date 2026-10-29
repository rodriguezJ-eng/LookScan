using System;
using System.Drawing;
using System.Windows.Forms;

namespace LookScan
{
    partial class AnalisisControl
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            dgvBgAH = new DataGridView();
            dgvBgAHCol0 = new DataGridViewTextBoxColumn();
            dgvBgAHCol1 = new DataGridViewTextBoxColumn();
            dgvBgAHCol2 = new DataGridViewTextBoxColumn();
            dgvBgAHCol3 = new DataGridViewTextBoxColumn();
            dgvBgAHCol4 = new DataGridViewTextBoxColumn();
            grpBgAH = new GroupBox();
            dgvErAH = new DataGridView();
            dgvErAHCol0 = new DataGridViewTextBoxColumn();
            dgvErAHCol1 = new DataGridViewTextBoxColumn();
            dgvErAHCol2 = new DataGridViewTextBoxColumn();
            dgvErAHCol3 = new DataGridViewTextBoxColumn();
            dgvErAHCol4 = new DataGridViewTextBoxColumn();
            grpErAH = new GroupBox();
            tlpAH = new TableLayoutPanel();
            dgvBgAV = new DataGridView();
            dgvBgAVCol0 = new DataGridViewTextBoxColumn();
            dgvBgAVCol1 = new DataGridViewTextBoxColumn();
            dgvBgAVCol2 = new DataGridViewTextBoxColumn();
            grpBgAV = new GroupBox();
            dgvErAV = new DataGridView();
            dgvErAVCol0 = new DataGridViewTextBoxColumn();
            dgvErAVCol1 = new DataGridViewTextBoxColumn();
            dgvErAVCol2 = new DataGridViewTextBoxColumn();
            grpErAV = new GroupBox();
            tlpAV = new TableLayoutPanel();
            tabAnalisis = new TabControl();
            tabAnalisisPage1 = new TabPage();
            tabAnalisisPage2 = new TabPage();
            pnlHeader = new Panel();
            lblTitulo = new Label();
            lblDescripcion = new Label();
            label1 = new Label();
            cmbPeriodoBaseAH = new ComboBox();
            label2 = new Label();
            cmbPeriodoCompAH = new ComboBox();
            btnCalcularAH = new Button();
            pnlToolbar = new Panel();
            pnlBody = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvBgAH).BeginInit();
            grpBgAH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvErAH).BeginInit();
            grpErAH.SuspendLayout();
            tlpAH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBgAV).BeginInit();
            grpBgAV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvErAV).BeginInit();
            grpErAV.SuspendLayout();
            tlpAV.SuspendLayout();
            tabAnalisis.SuspendLayout();
            tabAnalisisPage1.SuspendLayout();
            tabAnalisisPage2.SuspendLayout();
            pnlHeader.SuspendLayout();
            pnlToolbar.SuspendLayout();
            pnlBody.SuspendLayout();
            SuspendLayout();
            // 
            // dgvBgAH
            // 
            dgvBgAH.AllowUserToAddRows = false;
            dgvBgAH.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(247, 249, 252);
            dgvBgAH.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvBgAH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBgAH.BackgroundColor = Color.FromArgb(255, 255, 255);
            dgvBgAH.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(24, 72, 140);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(255, 255, 255);
            dgvBgAH.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvBgAH.ColumnHeadersHeight = 32;
            dgvBgAH.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvBgAH.Columns.AddRange(new DataGridViewColumn[] { dgvBgAHCol0, dgvBgAHCol1, dgvBgAHCol2, dgvBgAHCol3, dgvBgAHCol4 });
            dgvBgAH.Dock = DockStyle.Fill;
            dgvBgAH.EnableHeadersVisualStyles = false;
            dgvBgAH.Location = new Point(8, 28);
            dgvBgAH.Name = "dgvBgAH";
            dgvBgAH.ReadOnly = true;
            dgvBgAH.RowHeadersVisible = false;
            dgvBgAH.RowHeadersWidth = 51;
            dgvBgAH.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBgAH.Size = new Size(950, 168);
            dgvBgAH.TabIndex = 0;
            // 
            // dgvBgAHCol0
            // 
            dgvBgAHCol0.HeaderText = "Cuenta";
            dgvBgAHCol0.MinimumWidth = 6;
            dgvBgAHCol0.Name = "dgvBgAHCol0";
            dgvBgAHCol0.ReadOnly = true;
            // 
            // dgvBgAHCol1
            // 
            dgvBgAHCol1.HeaderText = "Base";
            dgvBgAHCol1.MinimumWidth = 6;
            dgvBgAHCol1.Name = "dgvBgAHCol1";
            dgvBgAHCol1.ReadOnly = true;
            // 
            // dgvBgAHCol2
            // 
            dgvBgAHCol2.HeaderText = "Comparado";
            dgvBgAHCol2.MinimumWidth = 6;
            dgvBgAHCol2.Name = "dgvBgAHCol2";
            dgvBgAHCol2.ReadOnly = true;
            // 
            // dgvBgAHCol3
            // 
            dgvBgAHCol3.HeaderText = "Δ Abs";
            dgvBgAHCol3.MinimumWidth = 6;
            dgvBgAHCol3.Name = "dgvBgAHCol3";
            dgvBgAHCol3.ReadOnly = true;
            // 
            // dgvBgAHCol4
            // 
            dgvBgAHCol4.HeaderText = "Δ %";
            dgvBgAHCol4.MinimumWidth = 6;
            dgvBgAHCol4.Name = "dgvBgAHCol4";
            dgvBgAHCol4.ReadOnly = true;
            // 
            // grpBgAH
            // 
            grpBgAH.Controls.Add(dgvBgAH);
            grpBgAH.Dock = DockStyle.Fill;
            grpBgAH.Location = new Point(3, 3);
            grpBgAH.Name = "grpBgAH";
            grpBgAH.Padding = new Padding(8, 6, 8, 8);
            grpBgAH.Size = new Size(966, 204);
            grpBgAH.TabIndex = 0;
            grpBgAH.TabStop = false;
            grpBgAH.Text = "BG — AH";
            // 
            // dgvErAH
            // 
            dgvErAH.AllowUserToAddRows = false;
            dgvErAH.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(247, 249, 252);
            dgvErAH.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvErAH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvErAH.BackgroundColor = Color.FromArgb(255, 255, 255);
            dgvErAH.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(24, 72, 140);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(255, 255, 255);
            dgvErAH.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvErAH.ColumnHeadersHeight = 32;
            dgvErAH.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvErAH.Columns.AddRange(new DataGridViewColumn[] { dgvErAHCol0, dgvErAHCol1, dgvErAHCol2, dgvErAHCol3, dgvErAHCol4 });
            dgvErAH.Dock = DockStyle.Fill;
            dgvErAH.EnableHeadersVisualStyles = false;
            dgvErAH.Location = new Point(8, 28);
            dgvErAH.Name = "dgvErAH";
            dgvErAH.ReadOnly = true;
            dgvErAH.RowHeadersVisible = false;
            dgvErAH.RowHeadersWidth = 51;
            dgvErAH.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvErAH.Size = new Size(950, 168);
            dgvErAH.TabIndex = 0;
            // 
            // dgvErAHCol0
            // 
            dgvErAHCol0.HeaderText = "Cuenta";
            dgvErAHCol0.MinimumWidth = 6;
            dgvErAHCol0.Name = "dgvErAHCol0";
            dgvErAHCol0.ReadOnly = true;
            // 
            // dgvErAHCol1
            // 
            dgvErAHCol1.HeaderText = "Base";
            dgvErAHCol1.MinimumWidth = 6;
            dgvErAHCol1.Name = "dgvErAHCol1";
            dgvErAHCol1.ReadOnly = true;
            // 
            // dgvErAHCol2
            // 
            dgvErAHCol2.HeaderText = "Comparado";
            dgvErAHCol2.MinimumWidth = 6;
            dgvErAHCol2.Name = "dgvErAHCol2";
            dgvErAHCol2.ReadOnly = true;
            // 
            // dgvErAHCol3
            // 
            dgvErAHCol3.HeaderText = "Δ Abs";
            dgvErAHCol3.MinimumWidth = 6;
            dgvErAHCol3.Name = "dgvErAHCol3";
            dgvErAHCol3.ReadOnly = true;
            // 
            // dgvErAHCol4
            // 
            dgvErAHCol4.HeaderText = "Δ %";
            dgvErAHCol4.MinimumWidth = 6;
            dgvErAHCol4.Name = "dgvErAHCol4";
            dgvErAHCol4.ReadOnly = true;
            // 
            // grpErAH
            // 
            grpErAH.Controls.Add(dgvErAH);
            grpErAH.Dock = DockStyle.Fill;
            grpErAH.Location = new Point(3, 213);
            grpErAH.Name = "grpErAH";
            grpErAH.Padding = new Padding(8, 6, 8, 8);
            grpErAH.Size = new Size(966, 204);
            grpErAH.TabIndex = 1;
            grpErAH.TabStop = false;
            grpErAH.Text = "ER — AH";
            // 
            // tlpAH
            // 
            tlpAH.ColumnCount = 1;
            tlpAH.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpAH.Controls.Add(grpBgAH, 0, 0);
            tlpAH.Controls.Add(grpErAH, 0, 1);
            tlpAH.Dock = DockStyle.Fill;
            tlpAH.Location = new Point(0, 0);
            tlpAH.Name = "tlpAH";
            tlpAH.RowCount = 2;
            tlpAH.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpAH.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpAH.Size = new Size(972, 420);
            tlpAH.TabIndex = 0;
            // 
            // dgvBgAV
            // 
            dgvBgAV.AllowUserToAddRows = false;
            dgvBgAV.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(247, 249, 252);
            dgvBgAV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            dgvBgAV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBgAV.BackgroundColor = Color.FromArgb(255, 255, 255);
            dgvBgAV.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(24, 72, 140);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(255, 255, 255);
            dgvBgAV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dgvBgAV.ColumnHeadersHeight = 32;
            dgvBgAV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvBgAV.Columns.AddRange(new DataGridViewColumn[] { dgvBgAVCol0, dgvBgAVCol1, dgvBgAVCol2 });
            dgvBgAV.Dock = DockStyle.Fill;
            dgvBgAV.EnableHeadersVisualStyles = false;
            dgvBgAV.Location = new Point(8, 28);
            dgvBgAV.Name = "dgvBgAV";
            dgvBgAV.ReadOnly = true;
            dgvBgAV.RowHeadersVisible = false;
            dgvBgAV.RowHeadersWidth = 51;
            dgvBgAV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBgAV.Size = new Size(170, 0);
            dgvBgAV.TabIndex = 0;
            // 
            // dgvBgAVCol0
            // 
            dgvBgAVCol0.HeaderText = "Cuenta";
            dgvBgAVCol0.MinimumWidth = 6;
            dgvBgAVCol0.Name = "dgvBgAVCol0";
            dgvBgAVCol0.ReadOnly = true;
            // 
            // dgvBgAVCol1
            // 
            dgvBgAVCol1.HeaderText = "Clasif.";
            dgvBgAVCol1.MinimumWidth = 6;
            dgvBgAVCol1.Name = "dgvBgAVCol1";
            dgvBgAVCol1.ReadOnly = true;
            // 
            // dgvBgAVCol2
            // 
            dgvBgAVCol2.HeaderText = "% sobre TA/TPP";
            dgvBgAVCol2.MinimumWidth = 6;
            dgvBgAVCol2.Name = "dgvBgAVCol2";
            dgvBgAVCol2.ReadOnly = true;
            // 
            // grpBgAV
            // 
            grpBgAV.Controls.Add(dgvBgAV);
            grpBgAV.Dock = DockStyle.Fill;
            grpBgAV.Location = new Point(3, 3);
            grpBgAV.Name = "grpBgAV";
            grpBgAV.Padding = new Padding(8, 6, 8, 8);
            grpBgAV.Size = new Size(186, 25);
            grpBgAV.TabIndex = 0;
            grpBgAV.TabStop = false;
            grpBgAV.Text = "BG — AV";
            // 
            // dgvErAV
            // 
            dgvErAV.AllowUserToAddRows = false;
            dgvErAV.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = Color.FromArgb(247, 249, 252);
            dgvErAV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            dgvErAV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvErAV.BackgroundColor = Color.FromArgb(255, 255, 255);
            dgvErAV.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle8.BackColor = Color.FromArgb(24, 72, 140);
            dataGridViewCellStyle8.ForeColor = Color.FromArgb(255, 255, 255);
            dgvErAV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            dgvErAV.ColumnHeadersHeight = 32;
            dgvErAV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvErAV.Columns.AddRange(new DataGridViewColumn[] { dgvErAVCol0, dgvErAVCol1, dgvErAVCol2 });
            dgvErAV.Dock = DockStyle.Fill;
            dgvErAV.EnableHeadersVisualStyles = false;
            dgvErAV.Location = new Point(8, 28);
            dgvErAV.Name = "dgvErAV";
            dgvErAV.ReadOnly = true;
            dgvErAV.RowHeadersVisible = false;
            dgvErAV.RowHeadersWidth = 51;
            dgvErAV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvErAV.Size = new Size(170, 0);
            dgvErAV.TabIndex = 0;
            // 
            // dgvErAVCol0
            // 
            dgvErAVCol0.HeaderText = "Cuenta";
            dgvErAVCol0.MinimumWidth = 6;
            dgvErAVCol0.Name = "dgvErAVCol0";
            dgvErAVCol0.ReadOnly = true;
            // 
            // dgvErAVCol1
            // 
            dgvErAVCol1.HeaderText = "Clasif.";
            dgvErAVCol1.MinimumWidth = 6;
            dgvErAVCol1.Name = "dgvErAVCol1";
            dgvErAVCol1.ReadOnly = true;
            // 
            // dgvErAVCol2
            // 
            dgvErAVCol2.HeaderText = "% sobre Ventas";
            dgvErAVCol2.MinimumWidth = 6;
            dgvErAVCol2.Name = "dgvErAVCol2";
            dgvErAVCol2.ReadOnly = true;
            // 
            // grpErAV
            // 
            grpErAV.Controls.Add(dgvErAV);
            grpErAV.Dock = DockStyle.Fill;
            grpErAV.Location = new Point(3, 34);
            grpErAV.Name = "grpErAV";
            grpErAV.Padding = new Padding(8, 6, 8, 8);
            grpErAV.Size = new Size(186, 25);
            grpErAV.TabIndex = 1;
            grpErAV.TabStop = false;
            grpErAV.Text = "ER — AV";
            // 
            // tlpAV
            // 
            tlpAV.ColumnCount = 1;
            tlpAV.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpAV.Controls.Add(grpBgAV, 0, 0);
            tlpAV.Controls.Add(grpErAV, 0, 1);
            tlpAV.Dock = DockStyle.Fill;
            tlpAV.Location = new Point(0, 0);
            tlpAV.Name = "tlpAV";
            tlpAV.RowCount = 2;
            tlpAV.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpAV.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpAV.Size = new Size(192, 62);
            tlpAV.TabIndex = 0;
            // 
            // tabAnalisis
            // 
            tabAnalisis.Controls.Add(tabAnalisisPage1);
            tabAnalisis.Controls.Add(tabAnalisisPage2);
            tabAnalisis.Dock = DockStyle.Fill;
            tabAnalisis.Location = new Point(10, 4);
            tabAnalisis.Name = "tabAnalisis";
            tabAnalisis.Padding = new Point(12, 5);
            tabAnalisis.SelectedIndex = 0;
            tabAnalisis.Size = new Size(980, 458);
            tabAnalisis.TabIndex = 0;
            // 
            // tabAnalisisPage1
            // 
            tabAnalisisPage1.Controls.Add(tlpAH);
            tabAnalisisPage1.Location = new Point(4, 34);
            tabAnalisisPage1.Name = "tabAnalisisPage1";
            tabAnalisisPage1.Size = new Size(972, 420);
            tabAnalisisPage1.TabIndex = 0;
            tabAnalisisPage1.Text = "Análisis Horizontal (AH)";
            tabAnalisisPage1.UseVisualStyleBackColor = true;
            // 
            // tabAnalisisPage2
            // 
            tabAnalisisPage2.Controls.Add(tlpAV);
            tabAnalisisPage2.Location = new Point(4, 34);
            tabAnalisisPage2.Name = "tabAnalisisPage2";
            tabAnalisisPage2.Size = new Size(192, 62);
            tabAnalisisPage2.TabIndex = 1;
            tabAnalisisPage2.Text = "Análisis Vertical (AV)";
            tabAnalisisPage2.UseVisualStyleBackColor = true;
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Controls.Add(lblDescripcion);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1000, 66);
            pnlHeader.TabIndex = 2;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(24, 72, 140);
            lblTitulo.Location = new Point(14, 8);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(110, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Análisis";
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.ForeColor = Color.FromArgb(105, 105, 105);
            lblDescripcion.Location = new Point(16, 42);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(490, 21);
            lblDescripcion.TabIndex = 1;
            lblDescripcion.Text = "Análisis horizontal (entre periodos) y vertical (sobre el periodo activo)";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.FromArgb(70, 80, 100);
            label1.Location = new Point(10, 6);
            label1.Name = "label1";
            label1.Size = new Size(99, 21);
            label1.TabIndex = 0;
            label1.Text = "Periodo base";
            // 
            // cmbPeriodoBaseAH
            // 
            cmbPeriodoBaseAH.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPeriodoBaseAH.FormattingEnabled = true;
            cmbPeriodoBaseAH.Items.AddRange(new object[] { "2023", "2024", "2025" });
            cmbPeriodoBaseAH.Location = new Point(10, 26);
            cmbPeriodoBaseAH.Name = "cmbPeriodoBaseAH";
            cmbPeriodoBaseAH.Size = new Size(110, 29);
            cmbPeriodoBaseAH.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.FromArgb(70, 80, 100);
            label2.Location = new Point(132, 2);
            label2.Name = "label2";
            label2.Size = new Size(146, 21);
            label2.TabIndex = 2;
            label2.Text = "Periodo comparado";
            // 
            // cmbPeriodoCompAH
            // 
            cmbPeriodoCompAH.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPeriodoCompAH.FormattingEnabled = true;
            cmbPeriodoCompAH.Items.AddRange(new object[] { "2023", "2024", "2025" });
            cmbPeriodoCompAH.Location = new Point(132, 26);
            cmbPeriodoCompAH.Name = "cmbPeriodoCompAH";
            cmbPeriodoCompAH.Size = new Size(110, 29);
            cmbPeriodoCompAH.TabIndex = 3;
            // 
            // btnCalcularAH
            // 
            btnCalcularAH.BackColor = Color.FromArgb(24, 72, 140);
            btnCalcularAH.Cursor = Cursors.Hand;
            btnCalcularAH.FlatAppearance.BorderColor = Color.FromArgb(24, 72, 140);
            btnCalcularAH.FlatStyle = FlatStyle.Flat;
            btnCalcularAH.ForeColor = Color.FromArgb(255, 255, 255);
            btnCalcularAH.Location = new Point(258, 24);
            btnCalcularAH.Name = "btnCalcularAH";
            btnCalcularAH.Size = new Size(110, 30);
            btnCalcularAH.TabIndex = 4;
            btnCalcularAH.Text = "Calcular AH";
            btnCalcularAH.UseVisualStyleBackColor = false;
            // 
            // pnlToolbar
            // 
            pnlToolbar.AutoScroll = true;
            pnlToolbar.Controls.Add(label1);
            pnlToolbar.Controls.Add(cmbPeriodoBaseAH);
            pnlToolbar.Controls.Add(label2);
            pnlToolbar.Controls.Add(cmbPeriodoCompAH);
            pnlToolbar.Controls.Add(btnCalcularAH);
            pnlToolbar.Dock = DockStyle.Top;
            pnlToolbar.Location = new Point(0, 66);
            pnlToolbar.Name = "pnlToolbar";
            pnlToolbar.Size = new Size(1000, 62);
            pnlToolbar.TabIndex = 1;
            // 
            // pnlBody
            // 
            pnlBody.Controls.Add(tabAnalisis);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 128);
            pnlBody.Name = "pnlBody";
            pnlBody.Padding = new Padding(10, 4, 10, 10);
            pnlBody.Size = new Size(1000, 472);
            pnlBody.TabIndex = 0;
            // 
            // AnalisisControl
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 246, 250);
            Controls.Add(pnlBody);
            Controls.Add(pnlToolbar);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9.5F);
            Name = "AnalisisControl";
            Size = new Size(1000, 600);
            ((System.ComponentModel.ISupportInitialize)dgvBgAH).EndInit();
            grpBgAH.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvErAH).EndInit();
            grpErAH.ResumeLayout(false);
            tlpAH.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBgAV).EndInit();
            grpBgAV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvErAV).EndInit();
            grpErAV.ResumeLayout(false);
            tlpAV.ResumeLayout(false);
            tabAnalisis.ResumeLayout(false);
            tabAnalisisPage1.ResumeLayout(false);
            tabAnalisisPage2.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlToolbar.ResumeLayout(false);
            pnlToolbar.PerformLayout();
            pnlBody.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBgAH;
        private System.Windows.Forms.DataGridViewCellStyle dgvBgAHHdrStyle;
        private System.Windows.Forms.DataGridViewCellStyle dgvBgAHAltStyle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvBgAHCol0;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvBgAHCol1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvBgAHCol2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvBgAHCol3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvBgAHCol4;
        private System.Windows.Forms.GroupBox grpBgAH;
        private System.Windows.Forms.DataGridView dgvErAH;
        private System.Windows.Forms.DataGridViewCellStyle dgvErAHHdrStyle;
        private System.Windows.Forms.DataGridViewCellStyle dgvErAHAltStyle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvErAHCol0;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvErAHCol1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvErAHCol2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvErAHCol3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvErAHCol4;
        private System.Windows.Forms.GroupBox grpErAH;
        private System.Windows.Forms.TableLayoutPanel tlpAH;
        private System.Windows.Forms.DataGridView dgvBgAV;
        private System.Windows.Forms.DataGridViewCellStyle dgvBgAVHdrStyle;
        private System.Windows.Forms.DataGridViewCellStyle dgvBgAVAltStyle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvBgAVCol0;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvBgAVCol1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvBgAVCol2;
        private System.Windows.Forms.GroupBox grpBgAV;
        private System.Windows.Forms.DataGridView dgvErAV;
        private System.Windows.Forms.DataGridViewCellStyle dgvErAVHdrStyle;
        private System.Windows.Forms.DataGridViewCellStyle dgvErAVAltStyle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvErAVCol0;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvErAVCol1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvErAVCol2;
        private System.Windows.Forms.GroupBox grpErAV;
        private System.Windows.Forms.TableLayoutPanel tlpAV;
        private System.Windows.Forms.TabControl tabAnalisis;
        private System.Windows.Forms.TabPage tabAnalisisPage1;
        private System.Windows.Forms.TabPage tabAnalisisPage2;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPeriodoBaseAH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbPeriodoCompAH;
        private System.Windows.Forms.Button btnCalcularAH;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Panel pnlBody;
    }
}
