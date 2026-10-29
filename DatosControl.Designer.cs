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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            dgvBalance = new DataGridView();
            dgvBalanceCol0 = new DataGridViewTextBoxColumn();
            dgvBalanceCol1 = new DataGridViewTextBoxColumn();
            dgvBalanceCol2 = new DataGridViewTextBoxColumn();
            dgvBalanceCol3 = new DataGridViewTextBoxColumn();
            dgvBalanceCol4 = new DataGridViewButtonColumn();
            grpBalance = new GroupBox();
            dgvResultados = new DataGridView();
            dgvResultadosCol0 = new DataGridViewTextBoxColumn();
            dgvResultadosCol1 = new DataGridViewTextBoxColumn();
            dgvResultadosCol2 = new DataGridViewTextBoxColumn();
            dgvResultadosCol3 = new DataGridViewTextBoxColumn();
            dgvResultadosCol4 = new DataGridViewButtonColumn();
            grpResultados = new GroupBox();
            tlpDatos = new TableLayoutPanel();
            pnlHeader = new Panel();
            lblTitulo = new Label();
            lblDescripcion = new Label();
            label1 = new Label();
            cmbTipoEstado = new ComboBox();
            label2 = new Label();
            txtNombreCuenta = new TextBox();
            label3 = new Label();
            numMonto = new NumericUpDown();
            label4 = new Label();
            cmbClasificacion = new ComboBox();
            rbOperativa1 = new RadioButton();
            rbOperativa2 = new RadioButton();
            rbOperativa = new Panel();
            label5 = new Label();
            btnAgregar = new Button();
            grpAgregarCuenta = new GroupBox();
            btnExportarJson = new Button();
            btnImportarJson = new Button();
            btnCargarDemo = new Button();
            grpAccionesDatos = new GroupBox();
            pnlToolbar = new Panel();
            pnlBody = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvBalance).BeginInit();
            grpBalance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResultados).BeginInit();
            grpResultados.SuspendLayout();
            tlpDatos.SuspendLayout();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numMonto).BeginInit();
            rbOperativa.SuspendLayout();
            grpAgregarCuenta.SuspendLayout();
            grpAccionesDatos.SuspendLayout();
            pnlToolbar.SuspendLayout();
            pnlBody.SuspendLayout();
            SuspendLayout();
            // 
            // dgvBalance
            // 
            dgvBalance.AllowUserToAddRows = false;
            dgvBalance.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(247, 249, 252);
            dgvBalance.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            dgvBalance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBalance.BackgroundColor = Color.FromArgb(255, 255, 255);
            dgvBalance.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(24, 72, 140);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(255, 255, 255);
            dgvBalance.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dgvBalance.ColumnHeadersHeight = 32;
            dgvBalance.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvBalance.Columns.AddRange(new DataGridViewColumn[] { dgvBalanceCol0, dgvBalanceCol1, dgvBalanceCol2, dgvBalanceCol3, dgvBalanceCol4 });
            dgvBalance.Dock = DockStyle.Fill;
            dgvBalance.EnableHeadersVisualStyles = false;
            dgvBalance.Location = new Point(8, 28);
            dgvBalance.Name = "dgvBalance";
            dgvBalance.ReadOnly = true;
            dgvBalance.RowHeadersVisible = false;
            dgvBalance.RowHeadersWidth = 51;
            dgvBalance.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBalance.Size = new Size(643, 355);
            dgvBalance.TabIndex = 0;
            // 
            // dgvBalanceCol0
            // 
            dgvBalanceCol0.HeaderText = "Cuenta";
            dgvBalanceCol0.MinimumWidth = 6;
            dgvBalanceCol0.Name = "dgvBalanceCol0";
            dgvBalanceCol0.ReadOnly = true;
            // 
            // dgvBalanceCol1
            // 
            dgvBalanceCol1.HeaderText = "Clasif.";
            dgvBalanceCol1.MinimumWidth = 6;
            dgvBalanceCol1.Name = "dgvBalanceCol1";
            dgvBalanceCol1.ReadOnly = true;
            // 
            // dgvBalanceCol2
            // 
            dgvBalanceCol2.HeaderText = "Oper.";
            dgvBalanceCol2.MinimumWidth = 6;
            dgvBalanceCol2.Name = "dgvBalanceCol2";
            dgvBalanceCol2.ReadOnly = true;
            // 
            // dgvBalanceCol3
            // 
            dgvBalanceCol3.HeaderText = "Monto";
            dgvBalanceCol3.MinimumWidth = 6;
            dgvBalanceCol3.Name = "dgvBalanceCol3";
            dgvBalanceCol3.ReadOnly = true;
            // 
            // dgvBalanceCol4
            // 
            dgvBalanceCol4.FillWeight = 40F;
            dgvBalanceCol4.HeaderText = "";
            dgvBalanceCol4.MinimumWidth = 6;
            dgvBalanceCol4.Name = "dgvBalanceCol4";
            dgvBalanceCol4.ReadOnly = true;
            dgvBalanceCol4.Text = "Eliminar";
            dgvBalanceCol4.UseColumnTextForButtonValue = true;
            // 
            // grpBalance
            // 
            grpBalance.Controls.Add(dgvBalance);
            grpBalance.Dock = DockStyle.Fill;
            grpBalance.Location = new Point(3, 3);
            grpBalance.Name = "grpBalance";
            grpBalance.Padding = new Padding(8, 6, 8, 8);
            grpBalance.Size = new Size(659, 391);
            grpBalance.TabIndex = 0;
            grpBalance.TabStop = false;
            grpBalance.Text = "Balance General (Periodo activo)";
            // 
            // dgvResultados
            // 
            dgvResultados.AllowUserToAddRows = false;
            dgvResultados.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = Color.FromArgb(247, 249, 252);
            dgvResultados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            dgvResultados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResultados.BackgroundColor = Color.FromArgb(255, 255, 255);
            dgvResultados.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle8.BackColor = Color.FromArgb(24, 72, 140);
            dataGridViewCellStyle8.ForeColor = Color.FromArgb(255, 255, 255);
            dgvResultados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            dgvResultados.ColumnHeadersHeight = 32;
            dgvResultados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvResultados.Columns.AddRange(new DataGridViewColumn[] { dgvResultadosCol0, dgvResultadosCol1, dgvResultadosCol2, dgvResultadosCol3, dgvResultadosCol4 });
            dgvResultados.Dock = DockStyle.Fill;
            dgvResultados.EnableHeadersVisualStyles = false;
            dgvResultados.Location = new Point(8, 28);
            dgvResultados.Name = "dgvResultados";
            dgvResultados.ReadOnly = true;
            dgvResultados.RowHeadersVisible = false;
            dgvResultados.RowHeadersWidth = 51;
            dgvResultados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResultados.Size = new Size(644, 355);
            dgvResultados.TabIndex = 0;
            // 
            // dgvResultadosCol0
            // 
            dgvResultadosCol0.HeaderText = "Cuenta";
            dgvResultadosCol0.MinimumWidth = 6;
            dgvResultadosCol0.Name = "dgvResultadosCol0";
            dgvResultadosCol0.ReadOnly = true;
            // 
            // dgvResultadosCol1
            // 
            dgvResultadosCol1.HeaderText = "Clasif.";
            dgvResultadosCol1.MinimumWidth = 6;
            dgvResultadosCol1.Name = "dgvResultadosCol1";
            dgvResultadosCol1.ReadOnly = true;
            // 
            // dgvResultadosCol2
            // 
            dgvResultadosCol2.HeaderText = "Oper.";
            dgvResultadosCol2.MinimumWidth = 6;
            dgvResultadosCol2.Name = "dgvResultadosCol2";
            dgvResultadosCol2.ReadOnly = true;
            // 
            // dgvResultadosCol3
            // 
            dgvResultadosCol3.HeaderText = "Monto";
            dgvResultadosCol3.MinimumWidth = 6;
            dgvResultadosCol3.Name = "dgvResultadosCol3";
            dgvResultadosCol3.ReadOnly = true;
            // 
            // dgvResultadosCol4
            // 
            dgvResultadosCol4.FillWeight = 40F;
            dgvResultadosCol4.HeaderText = "";
            dgvResultadosCol4.MinimumWidth = 6;
            dgvResultadosCol4.Name = "dgvResultadosCol4";
            dgvResultadosCol4.ReadOnly = true;
            dgvResultadosCol4.Text = "Eliminar";
            dgvResultadosCol4.UseColumnTextForButtonValue = true;
            // 
            // grpResultados
            // 
            grpResultados.Controls.Add(dgvResultados);
            grpResultados.Dock = DockStyle.Fill;
            grpResultados.Location = new Point(668, 3);
            grpResultados.Name = "grpResultados";
            grpResultados.Padding = new Padding(8, 6, 8, 8);
            grpResultados.Size = new Size(660, 391);
            grpResultados.TabIndex = 1;
            grpResultados.TabStop = false;
            grpResultados.Text = "Estado de Resultados (Periodo activo)";
            // 
            // tlpDatos
            // 
            tlpDatos.ColumnCount = 2;
            tlpDatos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpDatos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpDatos.Controls.Add(grpBalance, 0, 0);
            tlpDatos.Controls.Add(grpResultados, 1, 0);
            tlpDatos.Dock = DockStyle.Fill;
            tlpDatos.Location = new Point(10, 4);
            tlpDatos.Name = "tlpDatos";
            tlpDatos.RowCount = 1;
            tlpDatos.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpDatos.Size = new Size(1331, 397);
            tlpDatos.TabIndex = 0;
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Controls.Add(lblDescripcion);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1351, 66);
            pnlHeader.TabIndex = 2;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(24, 72, 140);
            lblTitulo.Location = new Point(14, 8);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(88, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Datos";
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.ForeColor = Color.FromArgb(105, 105, 105);
            lblDescripcion.Location = new Point(16, 42);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(532, 21);
            lblDescripcion.TabIndex = 1;
            lblDescripcion.Text = "Captura de cuentas del Balance General y Estado de Resultados por periodo";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.FromArgb(70, 80, 100);
            label1.Location = new Point(10, 20);
            label1.Name = "label1";
            label1.Size = new Size(111, 21);
            label1.TabIndex = 0;
            label1.Text = "Tipo de estado";
            // 
            // cmbTipoEstado
            // 
            cmbTipoEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoEstado.FormattingEnabled = true;
            cmbTipoEstado.Items.AddRange(new object[] { "BG", "ER" });
            cmbTipoEstado.Location = new Point(10, 40);
            cmbTipoEstado.Name = "cmbTipoEstado";
            cmbTipoEstado.Size = new Size(90, 29);
            cmbTipoEstado.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.FromArgb(70, 80, 100);
            label2.Location = new Point(117, 20);
            label2.Name = "label2";
            label2.Size = new Size(139, 21);
            label2.TabIndex = 2;
            label2.Text = "Nombre de cuenta";
            // 
            // txtNombreCuenta
            // 
            txtNombreCuenta.Location = new Point(117, 40);
            txtNombreCuenta.Name = "txtNombreCuenta";
            txtNombreCuenta.Size = new Size(200, 29);
            txtNombreCuenta.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.FromArgb(70, 80, 100);
            label3.Location = new Point(329, 16);
            label3.Name = "label3";
            label3.Size = new Size(56, 21);
            label3.TabIndex = 4;
            label3.Text = "Monto";
            // 
            // numMonto
            // 
            numMonto.DecimalPlaces = 2;
            numMonto.Location = new Point(329, 40);
            numMonto.Maximum = new decimal(new int[] { 276447132, 23283, 0, 131072 });
            numMonto.Minimum = new decimal(new int[] { 276447132, 23283, 0, -2147352576 });
            numMonto.Name = "numMonto";
            numMonto.Size = new Size(130, 29);
            numMonto.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.FromArgb(70, 80, 100);
            label4.Location = new Point(471, 16);
            label4.Name = "label4";
            label4.Size = new Size(96, 21);
            label4.TabIndex = 6;
            label4.Text = "Clasificación";
            // 
            // cmbClasificacion
            // 
            cmbClasificacion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClasificacion.FormattingEnabled = true;
            cmbClasificacion.Items.AddRange(new object[] { "Activo corriente", "Activo no corriente", "Pasivo corriente", "Pasivo no corriente", "Patrimonio", "Ventas", "Costo de ventas", "Gastos operativos", "Otros ingresos/gastos", "Impuestos" });
            cmbClasificacion.Location = new Point(471, 40);
            cmbClasificacion.Name = "cmbClasificacion";
            cmbClasificacion.Size = new Size(170, 29);
            cmbClasificacion.TabIndex = 7;
            // 
            // rbOperativa1
            // 
            rbOperativa1.AutoSize = true;
            rbOperativa1.Checked = true;
            rbOperativa1.Location = new Point(4, 4);
            rbOperativa1.Name = "rbOperativa1";
            rbOperativa1.Size = new Size(44, 25);
            rbOperativa1.TabIndex = 0;
            rbOperativa1.TabStop = true;
            rbOperativa1.Text = "Sí";
            // 
            // rbOperativa2
            // 
            rbOperativa2.AutoSize = true;
            rbOperativa2.Location = new Point(54, 2);
            rbOperativa2.Name = "rbOperativa2";
            rbOperativa2.Size = new Size(52, 25);
            rbOperativa2.TabIndex = 1;
            rbOperativa2.TabStop = true;
            rbOperativa2.Text = "No";
            // 
            // rbOperativa
            // 
            rbOperativa.Controls.Add(rbOperativa1);
            rbOperativa.Controls.Add(rbOperativa2);
            rbOperativa.Location = new Point(653, 38);
            rbOperativa.Name = "rbOperativa";
            rbOperativa.Size = new Size(104, 28);
            rbOperativa.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.FromArgb(70, 80, 100);
            label5.Location = new Point(653, 14);
            label5.Name = "label5";
            label5.Size = new Size(92, 21);
            label5.TabIndex = 8;
            label5.Text = "¿Operativa?";
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.FromArgb(24, 72, 140);
            btnAgregar.Cursor = Cursors.Hand;
            btnAgregar.FlatAppearance.BorderColor = Color.FromArgb(24, 72, 140);
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.ForeColor = Color.FromArgb(255, 255, 255);
            btnAgregar.Location = new Point(769, 38);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(100, 30);
            btnAgregar.TabIndex = 10;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            // 
            // grpAgregarCuenta
            // 
            grpAgregarCuenta.Controls.Add(label1);
            grpAgregarCuenta.Controls.Add(cmbTipoEstado);
            grpAgregarCuenta.Controls.Add(label2);
            grpAgregarCuenta.Controls.Add(txtNombreCuenta);
            grpAgregarCuenta.Controls.Add(label3);
            grpAgregarCuenta.Controls.Add(numMonto);
            grpAgregarCuenta.Controls.Add(label4);
            grpAgregarCuenta.Controls.Add(cmbClasificacion);
            grpAgregarCuenta.Controls.Add(label5);
            grpAgregarCuenta.Controls.Add(rbOperativa);
            grpAgregarCuenta.Controls.Add(btnAgregar);
            grpAgregarCuenta.Location = new Point(10, 6);
            grpAgregarCuenta.Name = "grpAgregarCuenta";
            grpAgregarCuenta.Size = new Size(879, 91);
            grpAgregarCuenta.TabIndex = 0;
            grpAgregarCuenta.TabStop = false;
            grpAgregarCuenta.Text = "Agregar cuenta";
            // 
            // btnExportarJson
            // 
            btnExportarJson.BackColor = Color.FromArgb(255, 255, 255);
            btnExportarJson.Cursor = Cursors.Hand;
            btnExportarJson.FlatAppearance.BorderColor = Color.FromArgb(24, 72, 140);
            btnExportarJson.FlatStyle = FlatStyle.Flat;
            btnExportarJson.ForeColor = Color.FromArgb(24, 72, 140);
            btnExportarJson.Location = new Point(10, 38);
            btnExportarJson.Name = "btnExportarJson";
            btnExportarJson.Size = new Size(120, 30);
            btnExportarJson.TabIndex = 0;
            btnExportarJson.Text = "Exportar JSON";
            btnExportarJson.UseVisualStyleBackColor = false;
            // 
            // btnImportarJson
            // 
            btnImportarJson.BackColor = Color.FromArgb(255, 255, 255);
            btnImportarJson.Cursor = Cursors.Hand;
            btnImportarJson.FlatAppearance.BorderColor = Color.FromArgb(24, 72, 140);
            btnImportarJson.FlatStyle = FlatStyle.Flat;
            btnImportarJson.ForeColor = Color.FromArgb(24, 72, 140);
            btnImportarJson.Location = new Point(142, 38);
            btnImportarJson.Name = "btnImportarJson";
            btnImportarJson.Size = new Size(120, 30);
            btnImportarJson.TabIndex = 1;
            btnImportarJson.Text = "Importar JSON";
            btnImportarJson.UseVisualStyleBackColor = false;
            // 
            // btnCargarDemo
            // 
            btnCargarDemo.BackColor = Color.FromArgb(255, 255, 255);
            btnCargarDemo.Cursor = Cursors.Hand;
            btnCargarDemo.FlatAppearance.BorderColor = Color.FromArgb(24, 72, 140);
            btnCargarDemo.FlatStyle = FlatStyle.Flat;
            btnCargarDemo.ForeColor = Color.FromArgb(24, 72, 140);
            btnCargarDemo.Location = new Point(274, 38);
            btnCargarDemo.Name = "btnCargarDemo";
            btnCargarDemo.Size = new Size(120, 30);
            btnCargarDemo.TabIndex = 2;
            btnCargarDemo.Text = "Cargar Demo";
            btnCargarDemo.UseVisualStyleBackColor = false;
            // 
            // grpAccionesDatos
            // 
            grpAccionesDatos.Controls.Add(btnExportarJson);
            grpAccionesDatos.Controls.Add(btnImportarJson);
            grpAccionesDatos.Controls.Add(btnCargarDemo);
            grpAccionesDatos.Location = new Point(901, 6);
            grpAccionesDatos.Name = "grpAccionesDatos";
            grpAccionesDatos.Size = new Size(404, 80);
            grpAccionesDatos.TabIndex = 1;
            grpAccionesDatos.TabStop = false;
            grpAccionesDatos.Text = "Acciones de datos";
            // 
            // pnlToolbar
            // 
            pnlToolbar.AutoScroll = true;
            pnlToolbar.Controls.Add(grpAgregarCuenta);
            pnlToolbar.Controls.Add(grpAccionesDatos);
            pnlToolbar.Dock = DockStyle.Top;
            pnlToolbar.Location = new Point(0, 66);
            pnlToolbar.Name = "pnlToolbar";
            pnlToolbar.Size = new Size(1351, 123);
            pnlToolbar.TabIndex = 1;
            // 
            // pnlBody
            // 
            pnlBody.Controls.Add(tlpDatos);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 189);
            pnlBody.Name = "pnlBody";
            pnlBody.Padding = new Padding(10, 4, 10, 10);
            pnlBody.Size = new Size(1351, 411);
            pnlBody.TabIndex = 0;
            // 
            // DatosControl
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 246, 250);
            Controls.Add(pnlBody);
            Controls.Add(pnlToolbar);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9.5F);
            Name = "DatosControl";
            Size = new Size(1351, 600);
            ((System.ComponentModel.ISupportInitialize)dgvBalance).EndInit();
            grpBalance.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvResultados).EndInit();
            grpResultados.ResumeLayout(false);
            tlpDatos.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numMonto).EndInit();
            rbOperativa.ResumeLayout(false);
            rbOperativa.PerformLayout();
            grpAgregarCuenta.ResumeLayout(false);
            grpAgregarCuenta.PerformLayout();
            grpAccionesDatos.ResumeLayout(false);
            pnlToolbar.ResumeLayout(false);
            pnlBody.ResumeLayout(false);
            ResumeLayout(false);
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
        private System.Windows.Forms.Panel pnlHeader;
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
