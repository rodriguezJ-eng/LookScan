using System;
using System.Drawing;
using System.Windows.Forms;

namespace LookScan
{
    partial class ProformaControl
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
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle16 = new DataGridViewCellStyle();
            dgvConfigCuentas = new DataGridView();
            dgvConfigCuentasCol0 = new DataGridViewTextBoxColumn();
            dgvConfigCuentasCol1 = new DataGridViewTextBoxColumn();
            dgvConfigCuentasCol2 = new DataGridViewTextBoxColumn();
            dgvConfigCuentasCol3 = new DataGridViewTextBoxColumn();
            grpConfigCuentas = new GroupBox();
            dgvProfER = new DataGridView();
            dgvProfERCol0 = new DataGridViewTextBoxColumn();
            dgvProfERCol1 = new DataGridViewTextBoxColumn();
            dgvProfERCol2 = new DataGridViewTextBoxColumn();
            dgvProfERCol3 = new DataGridViewTextBoxColumn();
            dgvProfBG = new DataGridView();
            dgvProfBGCol0 = new DataGridViewTextBoxColumn();
            dgvProfBGCol1 = new DataGridViewTextBoxColumn();
            dgvProfBGCol2 = new DataGridViewTextBoxColumn();
            dgvProfBGCol3 = new DataGridViewTextBoxColumn();
            dgvProfFE = new DataGridView();
            dgvProfFECol0 = new DataGridViewTextBoxColumn();
            dgvProfFECol1 = new DataGridViewTextBoxColumn();
            tabProforma = new TabControl();
            tabProformaPage1 = new TabPage();
            tabProformaPage2 = new TabPage();
            tabProformaPage3 = new TabPage();
            tabProformaPage4 = new TabPage();
            pnlHeader = new Panel();
            lblTitulo = new Label();
            lblDescripcion = new Label();
            label1 = new Label();
            cmbPeriodoProforma = new ComboBox();
            label2 = new Label();
            numAnios = new NumericUpDown();
            label3 = new Label();
            numCrecVentas = new NumericUpDown();
            label4 = new Label();
            numImpuestos = new NumericUpDown();
            label5 = new Label();
            numRetenidas = new NumericUpDown();
            btnGenerarProyeccion = new Button();
            grpParametrosProf = new GroupBox();
            btnGuardarProyeccion = new Button();
            btnExportarProformaExcel = new Button();
            grpAccionesProf = new GroupBox();
            pnlToolbar = new Panel();
            pnlBody = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvConfigCuentas).BeginInit();
            grpConfigCuentas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProfER).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProfBG).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProfFE).BeginInit();
            tabProforma.SuspendLayout();
            tabProformaPage1.SuspendLayout();
            tabProformaPage2.SuspendLayout();
            tabProformaPage3.SuspendLayout();
            tabProformaPage4.SuspendLayout();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numAnios).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCrecVentas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numImpuestos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numRetenidas).BeginInit();
            grpParametrosProf.SuspendLayout();
            grpAccionesProf.SuspendLayout();
            pnlToolbar.SuspendLayout();
            pnlBody.SuspendLayout();
            SuspendLayout();
            // 
            // dgvConfigCuentas
            // 
            dgvConfigCuentas.AllowUserToAddRows = false;
            dgvConfigCuentas.AllowUserToDeleteRows = false;
            dataGridViewCellStyle9.BackColor = Color.FromArgb(247, 249, 252);
            dgvConfigCuentas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            dgvConfigCuentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvConfigCuentas.BackgroundColor = Color.FromArgb(255, 255, 255);
            dgvConfigCuentas.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle10.BackColor = Color.FromArgb(24, 72, 140);
            dataGridViewCellStyle10.ForeColor = Color.FromArgb(255, 255, 255);
            dgvConfigCuentas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            dgvConfigCuentas.ColumnHeadersHeight = 32;
            dgvConfigCuentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvConfigCuentas.Columns.AddRange(new DataGridViewColumn[] { dgvConfigCuentasCol0, dgvConfigCuentasCol1, dgvConfigCuentasCol2, dgvConfigCuentasCol3 });
            dgvConfigCuentas.Dock = DockStyle.Fill;
            dgvConfigCuentas.EnableHeadersVisualStyles = false;
            dgvConfigCuentas.Location = new Point(8, 28);
            dgvConfigCuentas.Name = "dgvConfigCuentas";
            dgvConfigCuentas.ReadOnly = true;
            dgvConfigCuentas.RowHeadersVisible = false;
            dgvConfigCuentas.RowHeadersWidth = 51;
            dgvConfigCuentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvConfigCuentas.Size = new Size(1434, 497);
            dgvConfigCuentas.TabIndex = 0;
            dgvConfigCuentas.CellContentClick += dgvConfigCuentas_CellContentClick;
            // 
            // dgvConfigCuentasCol0
            // 
            dgvConfigCuentasCol0.HeaderText = "Cuenta";
            dgvConfigCuentasCol0.MinimumWidth = 6;
            dgvConfigCuentasCol0.Name = "dgvConfigCuentasCol0";
            dgvConfigCuentasCol0.ReadOnly = true;
            // 
            // dgvConfigCuentasCol1
            // 
            dgvConfigCuentasCol1.HeaderText = "Monto base";
            dgvConfigCuentasCol1.MinimumWidth = 6;
            dgvConfigCuentasCol1.Name = "dgvConfigCuentasCol1";
            dgvConfigCuentasCol1.ReadOnly = true;
            // 
            // dgvConfigCuentasCol2
            // 
            dgvConfigCuentasCol2.HeaderText = "Método de proyección";
            dgvConfigCuentasCol2.MinimumWidth = 6;
            dgvConfigCuentasCol2.Name = "dgvConfigCuentasCol2";
            dgvConfigCuentasCol2.ReadOnly = true;
            // 
            // dgvConfigCuentasCol3
            // 
            dgvConfigCuentasCol3.HeaderText = "% / Valor";
            dgvConfigCuentasCol3.MinimumWidth = 6;
            dgvConfigCuentasCol3.Name = "dgvConfigCuentasCol3";
            dgvConfigCuentasCol3.ReadOnly = true;
            // 
            // grpConfigCuentas
            // 
            grpConfigCuentas.Controls.Add(dgvConfigCuentas);
            grpConfigCuentas.Dock = DockStyle.Fill;
            grpConfigCuentas.Location = new Point(0, 0);
            grpConfigCuentas.Name = "grpConfigCuentas";
            grpConfigCuentas.Padding = new Padding(8, 6, 8, 8);
            grpConfigCuentas.Size = new Size(1450, 533);
            grpConfigCuentas.TabIndex = 0;
            grpConfigCuentas.TabStop = false;
            grpConfigCuentas.Text = "Seleccione un periodo base para configurar las cuentas";
            // 
            // dgvProfER
            // 
            dgvProfER.AllowUserToAddRows = false;
            dgvProfER.AllowUserToDeleteRows = false;
            dataGridViewCellStyle11.BackColor = Color.FromArgb(247, 249, 252);
            dgvProfER.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            dgvProfER.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProfER.BackgroundColor = Color.FromArgb(255, 255, 255);
            dgvProfER.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle12.BackColor = Color.FromArgb(24, 72, 140);
            dataGridViewCellStyle12.ForeColor = Color.FromArgb(255, 255, 255);
            dgvProfER.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            dgvProfER.ColumnHeadersHeight = 32;
            dgvProfER.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvProfER.Columns.AddRange(new DataGridViewColumn[] { dgvProfERCol0, dgvProfERCol1, dgvProfERCol2, dgvProfERCol3 });
            dgvProfER.Dock = DockStyle.Fill;
            dgvProfER.EnableHeadersVisualStyles = false;
            dgvProfER.Location = new Point(0, 0);
            dgvProfER.Name = "dgvProfER";
            dgvProfER.ReadOnly = true;
            dgvProfER.RowHeadersVisible = false;
            dgvProfER.RowHeadersWidth = 51;
            dgvProfER.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProfER.Size = new Size(1252, 534);
            dgvProfER.TabIndex = 0;
            // 
            // dgvProfERCol0
            // 
            dgvProfERCol0.HeaderText = "Cuenta";
            dgvProfERCol0.MinimumWidth = 6;
            dgvProfERCol0.Name = "dgvProfERCol0";
            dgvProfERCol0.ReadOnly = true;
            // 
            // dgvProfERCol1
            // 
            dgvProfERCol1.HeaderText = "Monto Proyectado";
            dgvProfERCol1.MinimumWidth = 6;
            dgvProfERCol1.Name = "dgvProfERCol1";
            dgvProfERCol1.ReadOnly = true;
            // 
            // dgvProfERCol2
            // 
            dgvProfERCol2.HeaderText = "% Ventas";
            dgvProfERCol2.MinimumWidth = 6;
            dgvProfERCol2.Name = "dgvProfERCol2";
            dgvProfERCol2.ReadOnly = true;
            // 
            // dgvProfERCol3
            // 
            dgvProfERCol3.HeaderText = "Notas";
            dgvProfERCol3.MinimumWidth = 6;
            dgvProfERCol3.Name = "dgvProfERCol3";
            dgvProfERCol3.ReadOnly = true;
            // 
            // dgvProfBG
            // 
            dgvProfBG.AllowUserToAddRows = false;
            dgvProfBG.AllowUserToDeleteRows = false;
            dataGridViewCellStyle13.BackColor = Color.FromArgb(247, 249, 252);
            dgvProfBG.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            dgvProfBG.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProfBG.BackgroundColor = Color.FromArgb(255, 255, 255);
            dgvProfBG.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle14.BackColor = Color.FromArgb(24, 72, 140);
            dataGridViewCellStyle14.ForeColor = Color.FromArgb(255, 255, 255);
            dgvProfBG.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            dgvProfBG.ColumnHeadersHeight = 32;
            dgvProfBG.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvProfBG.Columns.AddRange(new DataGridViewColumn[] { dgvProfBGCol0, dgvProfBGCol1, dgvProfBGCol2, dgvProfBGCol3 });
            dgvProfBG.Dock = DockStyle.Fill;
            dgvProfBG.EnableHeadersVisualStyles = false;
            dgvProfBG.Location = new Point(0, 0);
            dgvProfBG.Name = "dgvProfBG";
            dgvProfBG.ReadOnly = true;
            dgvProfBG.RowHeadersVisible = false;
            dgvProfBG.RowHeadersWidth = 51;
            dgvProfBG.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProfBG.Size = new Size(1252, 534);
            dgvProfBG.TabIndex = 0;
            // 
            // dgvProfBGCol0
            // 
            dgvProfBGCol0.HeaderText = "Cuenta";
            dgvProfBGCol0.MinimumWidth = 6;
            dgvProfBGCol0.Name = "dgvProfBGCol0";
            dgvProfBGCol0.ReadOnly = true;
            // 
            // dgvProfBGCol1
            // 
            dgvProfBGCol1.HeaderText = "Monto Proyectado";
            dgvProfBGCol1.MinimumWidth = 6;
            dgvProfBGCol1.Name = "dgvProfBGCol1";
            dgvProfBGCol1.ReadOnly = true;
            // 
            // dgvProfBGCol2
            // 
            dgvProfBGCol2.HeaderText = "% Ventas";
            dgvProfBGCol2.MinimumWidth = 6;
            dgvProfBGCol2.Name = "dgvProfBGCol2";
            dgvProfBGCol2.ReadOnly = true;
            // 
            // dgvProfBGCol3
            // 
            dgvProfBGCol3.HeaderText = "Notas";
            dgvProfBGCol3.MinimumWidth = 6;
            dgvProfBGCol3.Name = "dgvProfBGCol3";
            dgvProfBGCol3.ReadOnly = true;
            // 
            // dgvProfFE
            // 
            dgvProfFE.AllowUserToAddRows = false;
            dgvProfFE.AllowUserToDeleteRows = false;
            dataGridViewCellStyle15.BackColor = Color.FromArgb(247, 249, 252);
            dgvProfFE.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle15;
            dgvProfFE.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProfFE.BackgroundColor = Color.FromArgb(255, 255, 255);
            dgvProfFE.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle16.BackColor = Color.FromArgb(24, 72, 140);
            dataGridViewCellStyle16.ForeColor = Color.FromArgb(255, 255, 255);
            dgvProfFE.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            dgvProfFE.ColumnHeadersHeight = 32;
            dgvProfFE.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvProfFE.Columns.AddRange(new DataGridViewColumn[] { dgvProfFECol0, dgvProfFECol1 });
            dgvProfFE.Dock = DockStyle.Fill;
            dgvProfFE.EnableHeadersVisualStyles = false;
            dgvProfFE.Location = new Point(0, 0);
            dgvProfFE.Name = "dgvProfFE";
            dgvProfFE.ReadOnly = true;
            dgvProfFE.RowHeadersVisible = false;
            dgvProfFE.RowHeadersWidth = 51;
            dgvProfFE.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProfFE.Size = new Size(1252, 534);
            dgvProfFE.TabIndex = 0;
            // 
            // dgvProfFECol0
            // 
            dgvProfFECol0.HeaderText = "Concepto";
            dgvProfFECol0.MinimumWidth = 6;
            dgvProfFECol0.Name = "dgvProfFECol0";
            dgvProfFECol0.ReadOnly = true;
            // 
            // dgvProfFECol1
            // 
            dgvProfFECol1.HeaderText = "Monto";
            dgvProfFECol1.MinimumWidth = 6;
            dgvProfFECol1.Name = "dgvProfFECol1";
            dgvProfFECol1.ReadOnly = true;
            // 
            // tabProforma
            // 
            tabProforma.Controls.Add(tabProformaPage1);
            tabProforma.Controls.Add(tabProformaPage2);
            tabProforma.Controls.Add(tabProformaPage3);
            tabProforma.Controls.Add(tabProformaPage4);
            tabProforma.Dock = DockStyle.Fill;
            tabProforma.Location = new Point(10, 4);
            tabProforma.Name = "tabProforma";
            tabProforma.Padding = new Point(12, 5);
            tabProforma.SelectedIndex = 0;
            tabProforma.Size = new Size(1458, 571);
            tabProforma.TabIndex = 0;
            // 
            // tabProformaPage1
            // 
            tabProformaPage1.Controls.Add(grpConfigCuentas);
            tabProformaPage1.Location = new Point(4, 34);
            tabProformaPage1.Name = "tabProformaPage1";
            tabProformaPage1.Size = new Size(1450, 533);
            tabProformaPage1.TabIndex = 0;
            tabProformaPage1.Text = "Configuración de cuentas";
            tabProformaPage1.UseVisualStyleBackColor = true;
            // 
            // tabProformaPage2
            // 
            tabProformaPage2.Controls.Add(dgvProfER);
            tabProformaPage2.Location = new Point(4, 33);
            tabProformaPage2.Name = "tabProformaPage2";
            tabProformaPage2.Size = new Size(1252, 534);
            tabProformaPage2.TabIndex = 1;
            tabProformaPage2.Text = "Estado de Resultados";
            tabProformaPage2.UseVisualStyleBackColor = true;
            // 
            // tabProformaPage3
            // 
            tabProformaPage3.Controls.Add(dgvProfBG);
            tabProformaPage3.Location = new Point(4, 33);
            tabProformaPage3.Name = "tabProformaPage3";
            tabProformaPage3.Size = new Size(1252, 534);
            tabProformaPage3.TabIndex = 2;
            tabProformaPage3.Text = "Balance General";
            tabProformaPage3.UseVisualStyleBackColor = true;
            // 
            // tabProformaPage4
            // 
            tabProformaPage4.Controls.Add(dgvProfFE);
            tabProformaPage4.Location = new Point(4, 33);
            tabProformaPage4.Name = "tabProformaPage4";
            tabProformaPage4.Size = new Size(1252, 534);
            tabProformaPage4.TabIndex = 3;
            tabProformaPage4.Text = "Flujo de Efectivo";
            tabProformaPage4.UseVisualStyleBackColor = true;
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Controls.Add(lblDescripcion);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1478, 66);
            pnlHeader.TabIndex = 2;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(24, 72, 140);
            lblTitulo.Location = new Point(14, 8);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(379, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Estados Financieros Proforma";
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.ForeColor = Color.FromArgb(105, 105, 105);
            lblDescripcion.Location = new Point(16, 42);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(277, 21);
            lblDescripcion.TabIndex = 1;
            lblDescripcion.Text = "Proyección a partir de un periodo base";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.FromArgb(70, 80, 100);
            label1.Location = new Point(6, 22);
            label1.Name = "label1";
            label1.Size = new Size(214, 21);
            label1.TabIndex = 0;
            label1.Text = "Periodo base para proyección";
            // 
            // cmbPeriodoProforma
            // 
            cmbPeriodoProforma.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPeriodoProforma.FormattingEnabled = true;
            cmbPeriodoProforma.Items.AddRange(new object[] { "2023", "2024", "2025" });
            cmbPeriodoProforma.Location = new Point(12, 47);
            cmbPeriodoProforma.Name = "cmbPeriodoProforma";
            cmbPeriodoProforma.Size = new Size(170, 29);
            cmbPeriodoProforma.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.FromArgb(70, 80, 100);
            label2.Location = new Point(241, 24);
            label2.Name = "label2";
            label2.Size = new Size(127, 21);
            label2.TabIndex = 2;
            label2.Text = "Años a proyectar";
            // 
            // numAnios
            // 
            numAnios.Location = new Point(241, 47);
            numAnios.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numAnios.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numAnios.Name = "numAnios";
            numAnios.Size = new Size(100, 29);
            numAnios.TabIndex = 3;
            numAnios.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.FromArgb(70, 80, 100);
            label3.Location = new Point(383, 24);
            label3.Name = "label3";
            label3.Size = new Size(181, 21);
            label3.TabIndex = 4;
            label3.Text = "% Crecimiento de ventas";
            // 
            // numCrecVentas
            // 
            numCrecVentas.DecimalPlaces = 2;
            numCrecVentas.Location = new Point(383, 48);
            numCrecVentas.Maximum = new decimal(new int[] { 100000, 0, 0, 131072 });
            numCrecVentas.Minimum = new decimal(new int[] { 10000, 0, 0, -2147352576 });
            numCrecVentas.Name = "numCrecVentas";
            numCrecVentas.Size = new Size(140, 29);
            numCrecVentas.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.FromArgb(70, 80, 100);
            label4.Location = new Point(570, 24);
            label4.Name = "label4";
            label4.Size = new Size(99, 21);
            label4.TabIndex = 6;
            label4.Text = "% Impuestos";
            // 
            // numImpuestos
            // 
            numImpuestos.DecimalPlaces = 2;
            numImpuestos.Location = new Point(569, 48);
            numImpuestos.Name = "numImpuestos";
            numImpuestos.Size = new Size(100, 29);
            numImpuestos.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.FromArgb(70, 80, 100);
            label5.Location = new Point(693, 25);
            label5.Name = "label5";
            label5.Size = new Size(164, 21);
            label5.TabIndex = 8;
            label5.Text = "% Utilidades retenidas";
            // 
            // numRetenidas
            // 
            numRetenidas.DecimalPlaces = 2;
            numRetenidas.Location = new Point(693, 49);
            numRetenidas.Name = "numRetenidas";
            numRetenidas.Size = new Size(140, 29);
            numRetenidas.TabIndex = 9;
            // 
            // btnGenerarProyeccion
            // 
            btnGenerarProyeccion.BackColor = Color.FromArgb(24, 72, 140);
            btnGenerarProyeccion.Cursor = Cursors.Hand;
            btnGenerarProyeccion.FlatAppearance.BorderColor = Color.FromArgb(24, 72, 140);
            btnGenerarProyeccion.FlatStyle = FlatStyle.Flat;
            btnGenerarProyeccion.ForeColor = Color.FromArgb(255, 255, 255);
            btnGenerarProyeccion.Location = new Point(850, 49);
            btnGenerarProyeccion.Name = "btnGenerarProyeccion";
            btnGenerarProyeccion.Size = new Size(150, 30);
            btnGenerarProyeccion.TabIndex = 10;
            btnGenerarProyeccion.Text = "Generar Proyección";
            btnGenerarProyeccion.UseVisualStyleBackColor = false;
            // 
            // grpParametrosProf
            // 
            grpParametrosProf.Controls.Add(label1);
            grpParametrosProf.Controls.Add(cmbPeriodoProforma);
            grpParametrosProf.Controls.Add(label2);
            grpParametrosProf.Controls.Add(numAnios);
            grpParametrosProf.Controls.Add(label3);
            grpParametrosProf.Controls.Add(numCrecVentas);
            grpParametrosProf.Controls.Add(label4);
            grpParametrosProf.Controls.Add(numImpuestos);
            grpParametrosProf.Controls.Add(label5);
            grpParametrosProf.Controls.Add(numRetenidas);
            grpParametrosProf.Controls.Add(btnGenerarProyeccion);
            grpParametrosProf.Location = new Point(10, 6);
            grpParametrosProf.Name = "grpParametrosProf";
            grpParametrosProf.Size = new Size(1061, 97);
            grpParametrosProf.TabIndex = 0;
            grpParametrosProf.TabStop = false;
            grpParametrosProf.Text = "Parámetros";
            // 
            // btnGuardarProyeccion
            // 
            btnGuardarProyeccion.BackColor = Color.FromArgb(255, 255, 255);
            btnGuardarProyeccion.Cursor = Cursors.Hand;
            btnGuardarProyeccion.FlatAppearance.BorderColor = Color.FromArgb(24, 72, 140);
            btnGuardarProyeccion.FlatStyle = FlatStyle.Flat;
            btnGuardarProyeccion.ForeColor = Color.FromArgb(24, 72, 140);
            btnGuardarProyeccion.Location = new Point(10, 38);
            btnGuardarProyeccion.Name = "btnGuardarProyeccion";
            btnGuardarProyeccion.Size = new Size(140, 30);
            btnGuardarProyeccion.TabIndex = 0;
            btnGuardarProyeccion.Text = "Guardar Proyección";
            btnGuardarProyeccion.UseVisualStyleBackColor = false;
            // 
            // btnExportarProformaExcel
            // 
            btnExportarProformaExcel.BackColor = Color.FromArgb(255, 255, 255);
            btnExportarProformaExcel.Cursor = Cursors.Hand;
            btnExportarProformaExcel.FlatAppearance.BorderColor = Color.FromArgb(24, 72, 140);
            btnExportarProformaExcel.FlatStyle = FlatStyle.Flat;
            btnExportarProformaExcel.ForeColor = Color.FromArgb(24, 72, 140);
            btnExportarProformaExcel.Location = new Point(162, 38);
            btnExportarProformaExcel.Name = "btnExportarProformaExcel";
            btnExportarProformaExcel.Size = new Size(130, 30);
            btnExportarProformaExcel.TabIndex = 1;
            btnExportarProformaExcel.Text = "Exportar a Excel";
            btnExportarProformaExcel.UseVisualStyleBackColor = false;
            // 
            // grpAccionesProf
            // 
            grpAccionesProf.Controls.Add(btnGuardarProyeccion);
            grpAccionesProf.Controls.Add(btnExportarProformaExcel);
            grpAccionesProf.Location = new Point(1100, 6);
            grpAccionesProf.Name = "grpAccionesProf";
            grpAccionesProf.Size = new Size(302, 80);
            grpAccionesProf.TabIndex = 1;
            grpAccionesProf.TabStop = false;
            grpAccionesProf.Text = "Acciones";
            // 
            // pnlToolbar
            // 
            pnlToolbar.AutoScroll = true;
            pnlToolbar.Controls.Add(grpParametrosProf);
            pnlToolbar.Controls.Add(grpAccionesProf);
            pnlToolbar.Dock = DockStyle.Top;
            pnlToolbar.Location = new Point(0, 66);
            pnlToolbar.Name = "pnlToolbar";
            pnlToolbar.Size = new Size(1478, 109);
            pnlToolbar.TabIndex = 1;
            // 
            // pnlBody
            // 
            pnlBody.Controls.Add(tabProforma);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 175);
            pnlBody.Name = "pnlBody";
            pnlBody.Padding = new Padding(10, 4, 10, 10);
            pnlBody.Size = new Size(1478, 585);
            pnlBody.TabIndex = 0;
            // 
            // ProformaControl
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 246, 250);
            Controls.Add(pnlBody);
            Controls.Add(pnlToolbar);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9.5F);
            Name = "ProformaControl";
            Size = new Size(1478, 760);
            ((System.ComponentModel.ISupportInitialize)dgvConfigCuentas).EndInit();
            grpConfigCuentas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProfER).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProfBG).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProfFE).EndInit();
            tabProforma.ResumeLayout(false);
            tabProformaPage1.ResumeLayout(false);
            tabProformaPage2.ResumeLayout(false);
            tabProformaPage3.ResumeLayout(false);
            tabProformaPage4.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numAnios).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCrecVentas).EndInit();
            ((System.ComponentModel.ISupportInitialize)numImpuestos).EndInit();
            ((System.ComponentModel.ISupportInitialize)numRetenidas).EndInit();
            grpParametrosProf.ResumeLayout(false);
            grpParametrosProf.PerformLayout();
            grpAccionesProf.ResumeLayout(false);
            pnlToolbar.ResumeLayout(false);
            pnlBody.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvConfigCuentas;
        private System.Windows.Forms.DataGridViewCellStyle dgvConfigCuentasHdrStyle;
        private System.Windows.Forms.DataGridViewCellStyle dgvConfigCuentasAltStyle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvConfigCuentasCol0;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvConfigCuentasCol1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvConfigCuentasCol2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvConfigCuentasCol3;
        private System.Windows.Forms.GroupBox grpConfigCuentas;
        private System.Windows.Forms.DataGridView dgvProfER;
        private System.Windows.Forms.DataGridViewCellStyle dgvProfERHdrStyle;
        private System.Windows.Forms.DataGridViewCellStyle dgvProfERAltStyle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvProfERCol0;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvProfERCol1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvProfERCol2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvProfERCol3;
        private System.Windows.Forms.DataGridView dgvProfBG;
        private System.Windows.Forms.DataGridViewCellStyle dgvProfBGHdrStyle;
        private System.Windows.Forms.DataGridViewCellStyle dgvProfBGAltStyle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvProfBGCol0;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvProfBGCol1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvProfBGCol2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvProfBGCol3;
        private System.Windows.Forms.DataGridView dgvProfFE;
        private System.Windows.Forms.DataGridViewCellStyle dgvProfFEHdrStyle;
        private System.Windows.Forms.DataGridViewCellStyle dgvProfFEAltStyle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvProfFECol0;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvProfFECol1;
        private System.Windows.Forms.TabControl tabProforma;
        private System.Windows.Forms.TabPage tabProformaPage1;
        private System.Windows.Forms.TabPage tabProformaPage2;
        private System.Windows.Forms.TabPage tabProformaPage3;
        private System.Windows.Forms.TabPage tabProformaPage4;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPeriodoProforma;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numAnios;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numCrecVentas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numImpuestos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numRetenidas;
        private System.Windows.Forms.Button btnGenerarProyeccion;
        private System.Windows.Forms.GroupBox grpParametrosProf;
        private System.Windows.Forms.Button btnGuardarProyeccion;
        private System.Windows.Forms.Button btnExportarProformaExcel;
        private System.Windows.Forms.GroupBox grpAccionesProf;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Panel pnlBody;
    }
}
