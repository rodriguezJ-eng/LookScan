using System;
using System.Drawing;
using System.Windows.Forms;

namespace LookScan
{
    partial class DatosControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvBalance = new System.Windows.Forms.DataGridView();
            this.dgvBalanceCol0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvBalanceCol1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvBalanceCol2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvBalanceCol3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvBalanceCol4 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.grpBalance = new System.Windows.Forms.GroupBox();
            this.dgvResultados = new System.Windows.Forms.DataGridView();
            this.dgvResultadosCol0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvResultadosCol1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvResultadosCol2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvResultadosCol3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvResultadosCol4 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.grpResultados = new System.Windows.Forms.GroupBox();
            this.tlpDatos = new System.Windows.Forms.TableLayoutPanel();
            this.pnlHeaderDatos = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTipoEstado = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombreCuenta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numMonto = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbClasificacion = new System.Windows.Forms.ComboBox();
            this.rbOperativa1 = new System.Windows.Forms.RadioButton();
            this.rbOperativa2 = new System.Windows.Forms.RadioButton();
            this.rbOperativa = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.grpAgregarCuenta = new System.Windows.Forms.GroupBox();
            this.btnExportarJson = new System.Windows.Forms.Button();
            this.btnImportarJson = new System.Windows.Forms.Button();
            this.btnCargarDemo = new System.Windows.Forms.Button();
            this.grpAccionesDatos = new System.Windows.Forms.GroupBox();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.pnlBody = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBalance)).BeginInit();
            this.grpBalance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).BeginInit();
            this.grpResultados.SuspendLayout();
            this.tlpDatos.SuspendLayout();
            this.pnlHeaderDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMonto)).BeginInit();
            this.rbOperativa.SuspendLayout();
            this.grpAgregarCuenta.SuspendLayout();
            this.grpAccionesDatos.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvBalance
            // 
            this.dgvBalance.AllowUserToAddRows = false;
            this.dgvBalance.AllowUserToDeleteRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.dgvBalance.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvBalance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBalance.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvBalance.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(72)))), ((int)(((byte)(140)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvBalance.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvBalance.ColumnHeadersHeight = 32;
            this.dgvBalance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBalance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvBalanceCol0,
            this.dgvBalanceCol1,
            this.dgvBalanceCol2,
            this.dgvBalanceCol3,
            this.dgvBalanceCol4});
            this.dgvBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBalance.EnableHeadersVisualStyles = false;
            this.dgvBalance.Location = new System.Drawing.Point(8, 28);
            this.dgvBalance.Name = "dgvBalance";
            this.dgvBalance.ReadOnly = true;
            this.dgvBalance.RowHeadersVisible = false;
            this.dgvBalance.RowHeadersWidth = 51;
            this.dgvBalance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBalance.Size = new System.Drawing.Size(643, 355);
            this.dgvBalance.TabIndex = 0;
            this.dgvBalance.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBalance_CellDoubleClick);
            // 
            // dgvBalanceCol0
            // 
            this.dgvBalanceCol0.HeaderText = "Cuenta";
            this.dgvBalanceCol0.MinimumWidth = 6;
            this.dgvBalanceCol0.Name = "dgvBalanceCol0";
            this.dgvBalanceCol0.ReadOnly = true;
            // 
            // dgvBalanceCol1
            // 
            this.dgvBalanceCol1.HeaderText = "Clasif.";
            this.dgvBalanceCol1.MinimumWidth = 6;
            this.dgvBalanceCol1.Name = "dgvBalanceCol1";
            this.dgvBalanceCol1.ReadOnly = true;
            // 
            // dgvBalanceCol2
            // 
            this.dgvBalanceCol2.HeaderText = "Oper.";
            this.dgvBalanceCol2.MinimumWidth = 6;
            this.dgvBalanceCol2.Name = "dgvBalanceCol2";
            this.dgvBalanceCol2.ReadOnly = true;
            // 
            // dgvBalanceCol3
            // 
            this.dgvBalanceCol3.HeaderText = "Monto";
            this.dgvBalanceCol3.MinimumWidth = 6;
            this.dgvBalanceCol3.Name = "dgvBalanceCol3";
            this.dgvBalanceCol3.ReadOnly = true;
            // 
            // dgvBalanceCol4
            // 
            this.dgvBalanceCol4.FillWeight = 40F;
            this.dgvBalanceCol4.HeaderText = "";
            this.dgvBalanceCol4.MinimumWidth = 6;
            this.dgvBalanceCol4.Name = "dgvBalanceCol4";
            this.dgvBalanceCol4.ReadOnly = true;
            this.dgvBalanceCol4.Text = "Eliminar";
            this.dgvBalanceCol4.UseColumnTextForButtonValue = true;
            // 
            // grpBalance
            // 
            this.grpBalance.Controls.Add(this.dgvBalance);
            this.grpBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBalance.Location = new System.Drawing.Point(3, 3);
            this.grpBalance.Name = "grpBalance";
            this.grpBalance.Padding = new System.Windows.Forms.Padding(8, 6, 8, 8);
            this.grpBalance.Size = new System.Drawing.Size(659, 391);
            this.grpBalance.TabIndex = 0;
            this.grpBalance.TabStop = false;
            this.grpBalance.Text = "Balance General (Periodo activo)";
            // 
            // dgvResultados
            // 
            this.dgvResultados.AllowUserToAddRows = false;
            this.dgvResultados.AllowUserToDeleteRows = false;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.dgvResultados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvResultados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResultados.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvResultados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(72)))), ((int)(((byte)(140)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvResultados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvResultados.ColumnHeadersHeight = 32;
            this.dgvResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvResultados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvResultadosCol0,
            this.dgvResultadosCol1,
            this.dgvResultadosCol2,
            this.dgvResultadosCol3,
            this.dgvResultadosCol4});
            this.dgvResultados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResultados.EnableHeadersVisualStyles = false;
            this.dgvResultados.Location = new System.Drawing.Point(8, 28);
            this.dgvResultados.Name = "dgvResultados";
            this.dgvResultados.ReadOnly = true;
            this.dgvResultados.RowHeadersVisible = false;
            this.dgvResultados.RowHeadersWidth = 51;
            this.dgvResultados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResultados.Size = new System.Drawing.Size(644, 355);
            this.dgvResultados.TabIndex = 0;
            // 
            // dgvResultadosCol0
            // 
            this.dgvResultadosCol0.HeaderText = "Cuenta";
            this.dgvResultadosCol0.MinimumWidth = 6;
            this.dgvResultadosCol0.Name = "dgvResultadosCol0";
            this.dgvResultadosCol0.ReadOnly = true;
            // 
            // dgvResultadosCol1
            // 
            this.dgvResultadosCol1.HeaderText = "Clasif.";
            this.dgvResultadosCol1.MinimumWidth = 6;
            this.dgvResultadosCol1.Name = "dgvResultadosCol1";
            this.dgvResultadosCol1.ReadOnly = true;
            // 
            // dgvResultadosCol2
            // 
            this.dgvResultadosCol2.HeaderText = "Oper.";
            this.dgvResultadosCol2.MinimumWidth = 6;
            this.dgvResultadosCol2.Name = "dgvResultadosCol2";
            this.dgvResultadosCol2.ReadOnly = true;
            // 
            // dgvResultadosCol3
            // 
            this.dgvResultadosCol3.HeaderText = "Monto";
            this.dgvResultadosCol3.MinimumWidth = 6;
            this.dgvResultadosCol3.Name = "dgvResultadosCol3";
            this.dgvResultadosCol3.ReadOnly = true;
            // 
            // dgvResultadosCol4
            // 
            this.dgvResultadosCol4.FillWeight = 40F;
            this.dgvResultadosCol4.HeaderText = "";
            this.dgvResultadosCol4.MinimumWidth = 6;
            this.dgvResultadosCol4.Name = "dgvResultadosCol4";
            this.dgvResultadosCol4.ReadOnly = true;
            this.dgvResultadosCol4.Text = "Eliminar";
            this.dgvResultadosCol4.UseColumnTextForButtonValue = true;
            // 
            // grpResultados
            // 
            this.grpResultados.Controls.Add(this.dgvResultados);
            this.grpResultados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpResultados.Location = new System.Drawing.Point(668, 3);
            this.grpResultados.Name = "grpResultados";
            this.grpResultados.Padding = new System.Windows.Forms.Padding(8, 6, 8, 8);
            this.grpResultados.Size = new System.Drawing.Size(660, 391);
            this.grpResultados.TabIndex = 1;
            this.grpResultados.TabStop = false;
            this.grpResultados.Text = "Estado de Resultados (Periodo activo)";
            // 
            // tlpDatos
            // 
            this.tlpDatos.ColumnCount = 2;
            this.tlpDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDatos.Controls.Add(this.grpBalance, 0, 0);
            this.tlpDatos.Controls.Add(this.grpResultados, 1, 0);
            this.tlpDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDatos.Location = new System.Drawing.Point(10, 4);
            this.tlpDatos.Name = "tlpDatos";
            this.tlpDatos.RowCount = 1;
            this.tlpDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDatos.Size = new System.Drawing.Size(1331, 397);
            this.tlpDatos.TabIndex = 0;
            // 
            // pnlHeaderDatos
            // 
            this.pnlHeaderDatos.Controls.Add(this.lblTitulo);
            this.pnlHeaderDatos.Controls.Add(this.lblDescripcion);
            this.pnlHeaderDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeaderDatos.Location = new System.Drawing.Point(0, 0);
            this.pnlHeaderDatos.Name = "pnlHeaderDatos";
            this.pnlHeaderDatos.Size = new System.Drawing.Size(1351, 66);
            this.pnlHeaderDatos.TabIndex = 2;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(72)))), ((int)(((byte)(140)))));
            this.lblTitulo.Location = new System.Drawing.Point(14, 8);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(88, 37);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Datos";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.lblDescripcion.Location = new System.Drawing.Point(16, 42);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(532, 21);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.Text = "Captura de cuentas del Balance General y Estado de Resultados por periodo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(100)))));
            this.label1.Location = new System.Drawing.Point(10, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo de estado";
            // 
            // cmbTipoEstado
            // 
            this.cmbTipoEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoEstado.FormattingEnabled = true;
            this.cmbTipoEstado.Items.AddRange(new object[] {
            "BG",
            "ER"});
            this.cmbTipoEstado.Location = new System.Drawing.Point(10, 40);
            this.cmbTipoEstado.Name = "cmbTipoEstado";
            this.cmbTipoEstado.Size = new System.Drawing.Size(90, 29);
            this.cmbTipoEstado.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(100)))));
            this.label2.Location = new System.Drawing.Point(117, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre de cuenta";
            // 
            // txtNombreCuenta
            // 
            this.txtNombreCuenta.Location = new System.Drawing.Point(117, 40);
            this.txtNombreCuenta.Name = "txtNombreCuenta";
            this.txtNombreCuenta.Size = new System.Drawing.Size(200, 29);
            this.txtNombreCuenta.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(100)))));
            this.label3.Location = new System.Drawing.Point(329, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Monto";
            // 
            // numMonto
            // 
            this.numMonto.DecimalPlaces = 2;
            this.numMonto.Location = new System.Drawing.Point(329, 40);
            this.numMonto.Maximum = new decimal(new int[] {
            276447132,
            23283,
            0,
            131072});
            this.numMonto.Minimum = new decimal(new int[] {
            276447132,
            23283,
            0,
            -2147352576});
            this.numMonto.Name = "numMonto";
            this.numMonto.Size = new System.Drawing.Size(130, 29);
            this.numMonto.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(100)))));
            this.label4.Location = new System.Drawing.Point(471, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "Clasificación";
            // 
            // cmbClasificacion
            // 
            this.cmbClasificacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClasificacion.FormattingEnabled = true;
            this.cmbClasificacion.Items.AddRange(new object[] {
            "Activo corriente",
            "Activo no corriente",
            "Pasivo corriente",
            "Pasivo no corriente",
            "Patrimonio",
            "Ventas",
            "Costo de ventas",
            "Gastos operativos",
            "Gastos Financieros",
            "Otros ingresos",
            "Impuestos"});
            this.cmbClasificacion.Location = new System.Drawing.Point(471, 40);
            this.cmbClasificacion.Name = "cmbClasificacion";
            this.cmbClasificacion.Size = new System.Drawing.Size(170, 29);
            this.cmbClasificacion.TabIndex = 7;
            // 
            // rbOperativa1
            // 
            this.rbOperativa1.AutoSize = true;
            this.rbOperativa1.Checked = true;
            this.rbOperativa1.Location = new System.Drawing.Point(4, 4);
            this.rbOperativa1.Name = "rbOperativa1";
            this.rbOperativa1.Size = new System.Drawing.Size(44, 25);
            this.rbOperativa1.TabIndex = 0;
            this.rbOperativa1.TabStop = true;
            this.rbOperativa1.Text = "Sí";
            // 
            // rbOperativa2
            // 
            this.rbOperativa2.AutoSize = true;
            this.rbOperativa2.Location = new System.Drawing.Point(54, 2);
            this.rbOperativa2.Name = "rbOperativa2";
            this.rbOperativa2.Size = new System.Drawing.Size(52, 25);
            this.rbOperativa2.TabIndex = 1;
            this.rbOperativa2.TabStop = true;
            this.rbOperativa2.Text = "No";
            // 
            // rbOperativa
            // 
            this.rbOperativa.Controls.Add(this.rbOperativa1);
            this.rbOperativa.Controls.Add(this.rbOperativa2);
            this.rbOperativa.Location = new System.Drawing.Point(653, 38);
            this.rbOperativa.Name = "rbOperativa";
            this.rbOperativa.Size = new System.Drawing.Size(104, 28);
            this.rbOperativa.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(100)))));
            this.label5.Location = new System.Drawing.Point(653, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 21);
            this.label5.TabIndex = 8;
            this.label5.Text = "¿Operativa?";
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(72)))), ((int)(((byte)(140)))));
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(72)))), ((int)(((byte)(140)))));
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnAgregar.Location = new System.Drawing.Point(769, 38);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(100, 30);
            this.btnAgregar.TabIndex = 10;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // grpAgregarCuenta
            // 
            this.grpAgregarCuenta.Controls.Add(this.label1);
            this.grpAgregarCuenta.Controls.Add(this.cmbTipoEstado);
            this.grpAgregarCuenta.Controls.Add(this.label2);
            this.grpAgregarCuenta.Controls.Add(this.txtNombreCuenta);
            this.grpAgregarCuenta.Controls.Add(this.label3);
            this.grpAgregarCuenta.Controls.Add(this.numMonto);
            this.grpAgregarCuenta.Controls.Add(this.label4);
            this.grpAgregarCuenta.Controls.Add(this.cmbClasificacion);
            this.grpAgregarCuenta.Controls.Add(this.label5);
            this.grpAgregarCuenta.Controls.Add(this.rbOperativa);
            this.grpAgregarCuenta.Controls.Add(this.btnAgregar);
            this.grpAgregarCuenta.Location = new System.Drawing.Point(10, 6);
            this.grpAgregarCuenta.Name = "grpAgregarCuenta";
            this.grpAgregarCuenta.Size = new System.Drawing.Size(879, 91);
            this.grpAgregarCuenta.TabIndex = 0;
            this.grpAgregarCuenta.TabStop = false;
            this.grpAgregarCuenta.Text = "Agregar cuenta";
            // 
            // btnExportarJson
            // 
            this.btnExportarJson.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnExportarJson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportarJson.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(72)))), ((int)(((byte)(140)))));
            this.btnExportarJson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarJson.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(72)))), ((int)(((byte)(140)))));
            this.btnExportarJson.Location = new System.Drawing.Point(10, 38);
            this.btnExportarJson.Name = "btnExportarJson";
            this.btnExportarJson.Size = new System.Drawing.Size(120, 30);
            this.btnExportarJson.TabIndex = 0;
            this.btnExportarJson.Text = "Exportar JSON";
            this.btnExportarJson.UseVisualStyleBackColor = false;
            // 
            // btnImportarJson
            // 
            this.btnImportarJson.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnImportarJson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImportarJson.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(72)))), ((int)(((byte)(140)))));
            this.btnImportarJson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportarJson.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(72)))), ((int)(((byte)(140)))));
            this.btnImportarJson.Location = new System.Drawing.Point(142, 38);
            this.btnImportarJson.Name = "btnImportarJson";
            this.btnImportarJson.Size = new System.Drawing.Size(120, 30);
            this.btnImportarJson.TabIndex = 1;
            this.btnImportarJson.Text = "Importar JSON";
            this.btnImportarJson.UseVisualStyleBackColor = false;
            // 
            // btnCargarDemo
            // 
            this.btnCargarDemo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnCargarDemo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCargarDemo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(72)))), ((int)(((byte)(140)))));
            this.btnCargarDemo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargarDemo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(72)))), ((int)(((byte)(140)))));
            this.btnCargarDemo.Location = new System.Drawing.Point(274, 38);
            this.btnCargarDemo.Name = "btnCargarDemo";
            this.btnCargarDemo.Size = new System.Drawing.Size(120, 30);
            this.btnCargarDemo.TabIndex = 2;
            this.btnCargarDemo.Text = "Cargar Demo";
            this.btnCargarDemo.UseVisualStyleBackColor = false;
            // 
            // grpAccionesDatos
            // 
            this.grpAccionesDatos.Controls.Add(this.btnExportarJson);
            this.grpAccionesDatos.Controls.Add(this.btnImportarJson);
            this.grpAccionesDatos.Controls.Add(this.btnCargarDemo);
            this.grpAccionesDatos.Location = new System.Drawing.Point(901, 6);
            this.grpAccionesDatos.Name = "grpAccionesDatos";
            this.grpAccionesDatos.Size = new System.Drawing.Size(404, 80);
            this.grpAccionesDatos.TabIndex = 1;
            this.grpAccionesDatos.TabStop = false;
            this.grpAccionesDatos.Text = "Acciones de datos";
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.AutoScroll = true;
            this.pnlToolbar.Controls.Add(this.grpAgregarCuenta);
            this.pnlToolbar.Controls.Add(this.grpAccionesDatos);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(0, 66);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(1351, 123);
            this.pnlToolbar.TabIndex = 1;
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.tlpDatos);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 189);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(10, 4, 10, 10);
            this.pnlBody.Size = new System.Drawing.Size(1351, 411);
            this.pnlBody.TabIndex = 0;
            // 
            // DatosControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.pnlHeaderDatos);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "DatosControl";
            this.Size = new System.Drawing.Size(1351, 600);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBalance)).EndInit();
            this.grpBalance.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).EndInit();
            this.grpResultados.ResumeLayout(false);
            this.tlpDatos.ResumeLayout(false);
            this.pnlHeaderDatos.ResumeLayout(false);
            this.pnlHeaderDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMonto)).EndInit();
            this.rbOperativa.ResumeLayout(false);
            this.rbOperativa.PerformLayout();
            this.grpAgregarCuenta.ResumeLayout(false);
            this.grpAgregarCuenta.PerformLayout();
            this.grpAccionesDatos.ResumeLayout(false);
            this.pnlToolbar.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBalance;
        private System.Windows.Forms.DataGridViewCellStyle dgvBalanceHdrStyle;
        private System.Windows.Forms.DataGridViewCellStyle dgvBalanceAltStyle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvBalanceCol0;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvBalanceCol1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvBalanceCol2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvBalanceCol3;
        private System.Windows.Forms.DataGridViewButtonColumn dgvBalanceCol4;
        private System.Windows.Forms.GroupBox grpBalance;
        private System.Windows.Forms.DataGridView dgvResultados;
        private System.Windows.Forms.DataGridViewCellStyle dgvResultadosHdrStyle;
        private System.Windows.Forms.DataGridViewCellStyle dgvResultadosAltStyle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvResultadosCol0;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvResultadosCol1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvResultadosCol2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvResultadosCol3;
        private System.Windows.Forms.DataGridViewButtonColumn dgvResultadosCol4;
        private System.Windows.Forms.GroupBox grpResultados;
        private System.Windows.Forms.TableLayoutPanel tlpDatos;
        private System.Windows.Forms.Panel pnlHeaderDatos;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTipoEstado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombreCuenta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numMonto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbClasificacion;
        private System.Windows.Forms.RadioButton rbOperativa1;
        private System.Windows.Forms.RadioButton rbOperativa2;
        private System.Windows.Forms.Panel rbOperativa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.GroupBox grpAgregarCuenta;
        private System.Windows.Forms.Button btnExportarJson;
        private System.Windows.Forms.Button btnImportarJson;
        private System.Windows.Forms.Button btnCargarDemo;
        private System.Windows.Forms.GroupBox grpAccionesDatos;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Panel pnlBody;
    }
}
