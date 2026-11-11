using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace LookScan
{
    partial class PresupuestoControl
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

        #region Código generado por el Diseñador de componentes

        private void InitializeComponent()
        {
            ChartArea chartArea1 = new ChartArea();
            Series series1 = new Series();
            this.pnlPrincipal = new Panel();
            this.pnlEncabezado = new Panel();
            this.lblMes = new Label();
            this.cmbMes = new ComboBox();
            this.lblAnio = new Label();
            this.numAnio = new NumericUpDown();
            this.grpRegistro = new GroupBox();
            this.lblTipo = new Label();
            this.cmbTipo = new ComboBox();
            this.lblCategoria = new Label();
            this.cmbCategoria = new ComboBox();
            this.lblDescripcion = new Label();
            this.txtDescripcion = new TextBox();
            this.lblMonto = new Label();
            this.txtMonto = new TextBox();
            this.btnAgregar = new Button();
            this.btnEliminar = new Button();
            this.btnLimpiar = new Button();
            this.grpMovimientos = new GroupBox();
            this.dgvMovimientos = new DataGridView();
            this.colTipo = new DataGridViewTextBoxColumn();
            this.colCategoria = new DataGridViewTextBoxColumn();
            this.colMonto = new DataGridViewTextBoxColumn();
            this.colFecha = new DataGridViewTextBoxColumn();
            this.grpResumen = new GroupBox();
            this.tlpResumen = new TableLayoutPanel();
            this.pnlIngresos = new Panel();
            this.lblTotalIngresosTitulo = new Label();
            this.lblTotalIngresos = new Label();
            this.pnlGastos = new Panel();
            this.lblTotalGastosTitulo = new Label();
            this.lblTotalGastos = new Label();
            this.pnlSaldo = new Panel();
            this.lblSaldoDisponibleTitulo = new Label();
            this.lblSaldoDisponible = new Label();
            this.pnlAhorro = new Panel();
            this.lblCapacidadAhorroTitulo = new Label();
            this.lblCapacidadAhorro = new Label();
            this.grpGrafico = new GroupBox();
            this.chartGastos = new Chart();
            this.pnlPrincipal.SuspendLayout();
            this.pnlEncabezado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAnio)).BeginInit();
            this.grpRegistro.SuspendLayout();
            this.grpMovimientos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).BeginInit();
            this.grpResumen.SuspendLayout();
            this.tlpResumen.SuspendLayout();
            this.pnlIngresos.SuspendLayout();
            this.pnlGastos.SuspendLayout();
            this.pnlSaldo.SuspendLayout();
            this.pnlAhorro.SuspendLayout();
            this.grpGrafico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartGastos)).BeginInit();
            this.SuspendLayout();

            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.AutoScroll = true;
            this.pnlPrincipal.BackColor = Color.FromArgb(18, 18, 18);
            this.pnlPrincipal.Controls.Add(this.pnlEncabezado);
            this.pnlPrincipal.Controls.Add(this.grpRegistro);
            this.pnlPrincipal.Controls.Add(this.grpMovimientos);
            this.pnlPrincipal.Controls.Add(this.grpResumen);
            this.pnlPrincipal.Controls.Add(this.grpGrafico);
            this.pnlPrincipal.Dock = DockStyle.Fill;
            this.pnlPrincipal.Location = new Point(0, 0);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Padding = new Padding(20, 15, 20, 20);
            this.pnlPrincipal.Size = new Size(1100, 920);
            this.pnlPrincipal.TabIndex = 0;

            // 
            // pnlEncabezado
            // 
            this.pnlEncabezado.Controls.Add(this.lblMes);
            this.pnlEncabezado.Controls.Add(this.cmbMes);
            this.pnlEncabezado.Controls.Add(this.lblAnio);
            this.pnlEncabezado.Controls.Add(this.numAnio);
            this.pnlEncabezado.Location = new Point(20, 15);
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.Size = new Size(650, 42);
            this.pnlEncabezado.TabIndex = 0;

            // lblMes
            this.lblMes.AutoSize = true;
            this.lblMes.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblMes.ForeColor = Color.FromArgb(230, 230, 230);
            this.lblMes.Location = new Point(4, 8);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new Size(49, 25);
            this.lblMes.Text = "Mes:";

            // cmbMes
            this.cmbMes.BackColor = Color.FromArgb(32, 32, 32);
            this.cmbMes.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbMes.FlatStyle = FlatStyle.Flat;
            this.cmbMes.Font = new Font("Segoe UI", 10.5F);
            this.cmbMes.ForeColor = Color.White;
            this.cmbMes.FormattingEnabled = true;
            this.cmbMes.Items.AddRange(new object[] {
                "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
                "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"
            });
            this.cmbMes.Location = new Point(60, 5);
            this.cmbMes.Name = "cmbMes";
            this.cmbMes.Size = new Size(180, 31);
            this.cmbMes.TabIndex = 1;

            // lblAnio
            this.lblAnio.AutoSize = true;
            this.lblAnio.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblAnio.ForeColor = Color.FromArgb(230, 230, 230);
            this.lblAnio.Location = new Point(270, 8);
            this.lblAnio.Name = "lblAnio";
            this.lblAnio.Size = new Size(50, 25);
            this.lblAnio.Text = "Año:";

            // numAnio
            this.numAnio.BackColor = Color.FromArgb(32, 32, 32);
            this.numAnio.BorderStyle = BorderStyle.FixedSingle;
            this.numAnio.Font = new Font("Segoe UI", 10.5F);
            this.numAnio.ForeColor = Color.White;
            this.numAnio.Location = new Point(325, 6);
            this.numAnio.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            this.numAnio.Minimum = new decimal(new int[] { 2000, 0, 0, 0 });
            this.numAnio.Name = "numAnio";
            this.numAnio.Size = new Size(110, 31);
            this.numAnio.TabIndex = 2;
            this.numAnio.Value = new decimal(new int[] { 2026, 0, 0, 0 });

            // 
            // grpRegistro
            // 
            this.grpRegistro.BackColor = Color.FromArgb(24, 24, 24);
            this.grpRegistro.Controls.Add(this.lblTipo);
            this.grpRegistro.Controls.Add(this.cmbTipo);
            this.grpRegistro.Controls.Add(this.lblCategoria);
            this.grpRegistro.Controls.Add(this.cmbCategoria);
            this.grpRegistro.Controls.Add(this.lblDescripcion);
            this.grpRegistro.Controls.Add(this.txtDescripcion);
            this.grpRegistro.Controls.Add(this.lblMonto);
            this.grpRegistro.Controls.Add(this.txtMonto);
            this.grpRegistro.Controls.Add(this.btnAgregar);
            this.grpRegistro.Controls.Add(this.btnEliminar);
            this.grpRegistro.Controls.Add(this.btnLimpiar);
            this.grpRegistro.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            this.grpRegistro.ForeColor = Color.FromArgb(220, 220, 220);
            this.grpRegistro.Location = new Point(20, 68);
            this.grpRegistro.Name = "grpRegistro";
            this.grpRegistro.Size = new Size(620, 225);
            this.grpRegistro.TabIndex = 1;
            this.grpRegistro.TabStop = false;
            this.grpRegistro.Text = "1. Registrar movimiento (GroupBox)";

            // lblTipo
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new Font("Segoe UI", 9F);
            this.lblTipo.ForeColor = Color.FromArgb(190, 190, 190);
            this.lblTipo.Location = new Point(18, 32);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new Size(117, 20);
            this.lblTipo.Text = "Tipo (ComboBox)";

            // cmbTipo
            this.cmbTipo.BackColor = Color.FromArgb(34, 34, 34);
            this.cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbTipo.FlatStyle = FlatStyle.Flat;
            this.cmbTipo.Font = new Font("Segoe UI", 9.5F);
            this.cmbTipo.ForeColor = Color.White;
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Items.AddRange(new object[] { "Ingreso", "Gasto" });
            this.cmbTipo.Location = new Point(18, 55);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new Size(270, 29);
            this.cmbTipo.TabIndex = 1;

            // lblCategoria
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = new Font("Segoe UI", 9F);
            this.lblCategoria.ForeColor = Color.FromArgb(190, 190, 190);
            this.lblCategoria.Location = new Point(315, 32);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new Size(152, 20);
            this.lblCategoria.Text = "Categoría (ComboBox)";

            // cmbCategoria
            this.cmbCategoria.BackColor = Color.FromArgb(34, 34, 34);
            this.cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCategoria.FlatStyle = FlatStyle.Flat;
            this.cmbCategoria.Font = new Font("Segoe UI", 9.5F);
            this.cmbCategoria.ForeColor = Color.White;
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new Point(315, 55);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new Size(285, 29);
            this.cmbCategoria.TabIndex = 2;

            // lblDescripcion
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new Font("Segoe UI", 9F);
            this.lblDescripcion.ForeColor = Color.FromArgb(190, 190, 190);
            this.lblDescripcion.Location = new Point(18, 97);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new Size(147, 20);
            this.lblDescripcion.Text = "Descripción (TextBox)";

            // txtDescripcion
            this.txtDescripcion.BackColor = Color.FromArgb(34, 34, 34);
            this.txtDescripcion.BorderStyle = BorderStyle.FixedSingle;
            this.txtDescripcion.Font = new Font("Segoe UI", 10F);
            this.txtDescripcion.ForeColor = Color.White;
            this.txtDescripcion.Location = new Point(18, 120);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new Size(270, 30);
            this.txtDescripcion.TabIndex = 3;

            // lblMonto
            this.lblMonto.AutoSize = true;
            this.lblMonto.Font = new Font("Segoe UI", 9F);
            this.lblMonto.ForeColor = Color.FromArgb(190, 190, 190);
            this.lblMonto.Location = new Point(315, 97);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new Size(137, 20);
            this.lblMonto.Text = "Monto C$ (TextBox)";

            // txtMonto
            this.txtMonto.BackColor = Color.FromArgb(34, 34, 34);
            this.txtMonto.BorderStyle = BorderStyle.FixedSingle;
            this.txtMonto.Font = new Font("Segoe UI", 10F);
            this.txtMonto.ForeColor = Color.White;
            this.txtMonto.Location = new Point(315, 120);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new Size(285, 30);
            this.txtMonto.TabIndex = 4;

            // btnAgregar
            this.btnAgregar.BackColor = Color.FromArgb(38, 38, 38);
            this.btnAgregar.FlatAppearance.BorderColor = Color.FromArgb(70, 70, 70);
            this.btnAgregar.FlatStyle = FlatStyle.Flat;
            this.btnAgregar.Font = new Font("Segoe UI", 9.5F);
            this.btnAgregar.ForeColor = Color.White;
            this.btnAgregar.Location = new Point(18, 168);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new Size(180, 38);
            this.btnAgregar.TabIndex = 5;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;

            // btnEliminar
            this.btnEliminar.BackColor = Color.FromArgb(38, 38, 38);
            this.btnEliminar.FlatAppearance.BorderColor = Color.FromArgb(70, 70, 70);
            this.btnEliminar.FlatStyle = FlatStyle.Flat;
            this.btnEliminar.Font = new Font("Segoe UI", 9.5F);
            this.btnEliminar.ForeColor = Color.White;
            this.btnEliminar.Location = new Point(220, 168);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new Size(180, 38);
            this.btnEliminar.TabIndex = 6;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;

            // btnLimpiar
            this.btnLimpiar.BackColor = Color.FromArgb(38, 38, 38);
            this.btnLimpiar.FlatAppearance.BorderColor = Color.FromArgb(70, 70, 70);
            this.btnLimpiar.FlatStyle = FlatStyle.Flat;
            this.btnLimpiar.Font = new Font("Segoe UI", 9.5F);
            this.btnLimpiar.ForeColor = Color.White;
            this.btnLimpiar.Location = new Point(420, 168);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new Size(180, 38);
            this.btnLimpiar.TabIndex = 7;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;

            // 
            // grpMovimientos
            // 
            this.grpMovimientos.BackColor = Color.FromArgb(24, 24, 24);
            this.grpMovimientos.Controls.Add(this.dgvMovimientos);
            this.grpMovimientos.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            this.grpMovimientos.ForeColor = Color.FromArgb(220, 220, 220);
            this.grpMovimientos.Location = new Point(20, 305);
            this.grpMovimientos.Name = "grpMovimientos";
            this.grpMovimientos.Padding = new Padding(12);
            this.grpMovimientos.Size = new Size(620, 195);
            this.grpMovimientos.TabIndex = 2;
            this.grpMovimientos.TabStop = false;
            this.grpMovimientos.Text = "2. Movimientos (DataGridView)";

            // dgvMovimientos
            this.dgvMovimientos.AllowUserToAddRows = false;
            this.dgvMovimientos.AllowUserToDeleteRows = false;
            this.dgvMovimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMovimientos.BackgroundColor = Color.FromArgb(28, 28, 28);
            this.dgvMovimientos.BorderStyle = BorderStyle.None;
            this.dgvMovimientos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.dgvMovimientos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(38, 38, 38);
            this.dgvMovimientos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvMovimientos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            this.dgvMovimientos.ColumnHeadersHeight = 32;
            this.dgvMovimientos.Columns.AddRange(new DataGridViewColumn[] {
                this.colTipo, this.colCategoria, this.colMonto, this.colFecha
            });
            this.dgvMovimientos.DefaultCellStyle.BackColor = Color.FromArgb(24, 24, 24);
            this.dgvMovimientos.DefaultCellStyle.ForeColor = Color.FromArgb(235, 235, 235);
            this.dgvMovimientos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(50, 65, 85);
            this.dgvMovimientos.DefaultCellStyle.SelectionForeColor = Color.White;
            this.dgvMovimientos.Dock = DockStyle.Fill;
            this.dgvMovimientos.EnableHeadersVisualStyles = false;
            this.dgvMovimientos.GridColor = Color.FromArgb(44, 44, 44);
            this.dgvMovimientos.Location = new Point(12, 35);
            this.dgvMovimientos.MultiSelect = false;
            this.dgvMovimientos.Name = "dgvMovimientos";
            this.dgvMovimientos.ReadOnly = true;
            this.dgvMovimientos.RowHeadersVisible = false;
            this.dgvMovimientos.RowTemplate.Height = 28;
            this.dgvMovimientos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvMovimientos.Size = new Size(596, 148);
            this.dgvMovimientos.TabIndex = 0;

            // colTipo
            this.colTipo.HeaderText = "Tipo";
            this.colTipo.Name = "colTipo";
            this.colTipo.ReadOnly = true;
            this.colTipo.FillWeight = 20F;

            // colCategoria
            this.colCategoria.HeaderText = "Categoría";
            this.colCategoria.Name = "colCategoria";
            this.colCategoria.ReadOnly = true;
            this.colCategoria.FillWeight = 30F;

            // colMonto
            this.colMonto.HeaderText = "Monto";
            this.colMonto.Name = "colMonto";
            this.colMonto.ReadOnly = true;
            this.colMonto.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.colMonto.FillWeight = 22F;

            // colFecha
            this.colFecha.HeaderText = "Fecha (Día/Mes/Año)";
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            this.colFecha.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.colFecha.FillWeight = 28F;

            // 
            // grpResumen
            // 
            this.grpResumen.BackColor = Color.FromArgb(24, 24, 24);
            this.grpResumen.Controls.Add(this.tlpResumen);
            this.grpResumen.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            this.grpResumen.ForeColor = Color.FromArgb(220, 220, 220);
            this.grpResumen.Location = new Point(20, 510);
            this.grpResumen.Name = "grpResumen";
            this.grpResumen.Padding = new Padding(12);
            this.grpResumen.Size = new Size(620, 175);
            this.grpResumen.TabIndex = 3;
            this.grpResumen.TabStop = false;
            this.grpResumen.Text = "3. Resumen (Labels)";

            // tlpResumen
            this.tlpResumen.ColumnCount = 2;
            this.tlpResumen.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.tlpResumen.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.tlpResumen.RowCount = 2;
            this.tlpResumen.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            this.tlpResumen.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            this.tlpResumen.Controls.Add(this.pnlIngresos, 0, 0);
            this.tlpResumen.Controls.Add(this.pnlGastos, 1, 0);
            this.tlpResumen.Controls.Add(this.pnlSaldo, 0, 1);
            this.tlpResumen.Controls.Add(this.pnlAhorro, 1, 1);
            this.tlpResumen.Dock = DockStyle.Fill;
            this.tlpResumen.Location = new Point(12, 35);
            this.tlpResumen.Name = "tlpResumen";
            this.tlpResumen.Size = new Size(596, 128);
            this.tlpResumen.TabIndex = 0;

            // pnlIngresos
            this.pnlIngresos.BackColor = Color.FromArgb(12, 45, 22);
            this.pnlIngresos.Controls.Add(this.lblTotalIngresosTitulo);
            this.pnlIngresos.Controls.Add(this.lblTotalIngresos);
            this.pnlIngresos.Dock = DockStyle.Fill;
            this.pnlIngresos.Margin = new Padding(4);
            this.pnlIngresos.Name = "pnlIngresos";
            this.pnlIngresos.Padding = new Padding(10, 6, 10, 6);
            this.pnlIngresos.Size = new Size(290, 56);
            this.pnlIngresos.TabIndex = 0;

            // lblTotalIngresosTitulo
            this.lblTotalIngresosTitulo.AutoSize = true;
            this.lblTotalIngresosTitulo.Font = new Font("Segoe UI", 9F);
            this.lblTotalIngresosTitulo.ForeColor = Color.FromArgb(70, 190, 110);
            this.lblTotalIngresosTitulo.Location = new Point(8, 6);
            this.lblTotalIngresosTitulo.Name = "lblTotalIngresosTitulo";
            this.lblTotalIngresosTitulo.Size = new Size(99, 20);
            this.lblTotalIngresosTitulo.Text = "Total ingresos";

            // lblTotalIngresos
            this.lblTotalIngresos.AutoSize = true;
            this.lblTotalIngresos.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            this.lblTotalIngresos.ForeColor = Color.FromArgb(50, 220, 110);
            this.lblTotalIngresos.Location = new Point(8, 27);
            this.lblTotalIngresos.Name = "lblTotalIngresos";
            this.lblTotalIngresos.Size = new Size(106, 28);
            this.lblTotalIngresos.Text = "C$ 15,000";

            // pnlGastos
            this.pnlGastos.BackColor = Color.FromArgb(55, 18, 22);
            this.pnlGastos.Controls.Add(this.lblTotalGastosTitulo);
            this.pnlGastos.Controls.Add(this.lblTotalGastos);
            this.pnlGastos.Dock = DockStyle.Fill;
            this.pnlGastos.Margin = new Padding(4);
            this.pnlGastos.Name = "pnlGastos";
            this.pnlGastos.Padding = new Padding(10, 6, 10, 6);
            this.pnlGastos.Size = new Size(290, 56);
            this.pnlGastos.TabIndex = 1;

            // lblTotalGastosTitulo
            this.lblTotalGastosTitulo.AutoSize = true;
            this.lblTotalGastosTitulo.Font = new Font("Segoe UI", 9F);
            this.lblTotalGastosTitulo.ForeColor = Color.FromArgb(235, 120, 120);
            this.lblTotalGastosTitulo.Location = new Point(8, 6);
            this.lblTotalGastosTitulo.Name = "lblTotalGastosTitulo";
            this.lblTotalGastosTitulo.Size = new Size(88, 20);
            this.lblTotalGastosTitulo.Text = "Total gastos";

            // lblTotalGastos
            this.lblTotalGastos.AutoSize = true;
            this.lblTotalGastos.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            this.lblTotalGastos.ForeColor = Color.FromArgb(255, 100, 110);
            this.lblTotalGastos.Location = new Point(8, 27);
            this.lblTotalGastos.Name = "lblTotalGastos";
            this.lblTotalGastos.Size = new Size(95, 28);
            this.lblTotalGastos.Text = "C$ 2,300";

            // pnlSaldo
            this.pnlSaldo.BackColor = Color.FromArgb(12, 38, 68);
            this.pnlSaldo.Controls.Add(this.lblSaldoDisponibleTitulo);
            this.pnlSaldo.Controls.Add(this.lblSaldoDisponible);
            this.pnlSaldo.Dock = DockStyle.Fill;
            this.pnlSaldo.Margin = new Padding(4);
            this.pnlSaldo.Name = "pnlSaldo";
            this.pnlSaldo.Padding = new Padding(10, 6, 10, 6);
            this.pnlSaldo.Size = new Size(290, 56);
            this.pnlSaldo.TabIndex = 2;

            // lblSaldoDisponibleTitulo
            this.lblSaldoDisponibleTitulo.AutoSize = true;
            this.lblSaldoDisponibleTitulo.Font = new Font("Segoe UI", 9F);
            this.lblSaldoDisponibleTitulo.ForeColor = Color.FromArgb(100, 165, 245);
            this.lblSaldoDisponibleTitulo.Location = new Point(8, 6);
            this.lblSaldoDisponibleTitulo.Name = "lblSaldoDisponibleTitulo";
            this.lblSaldoDisponibleTitulo.Size = new Size(119, 20);
            this.lblSaldoDisponibleTitulo.Text = "Saldo disponible";

            // lblSaldoDisponible
            this.lblSaldoDisponible.AutoSize = true;
            this.lblSaldoDisponible.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            this.lblSaldoDisponible.ForeColor = Color.FromArgb(90, 175, 255);
            this.lblSaldoDisponible.Location = new Point(8, 27);
            this.lblSaldoDisponible.Name = "lblSaldoDisponible";
            this.lblSaldoDisponible.Size = new Size(106, 28);
            this.lblSaldoDisponible.Text = "C$ 12,700";

            // pnlAhorro
            this.pnlAhorro.BackColor = Color.FromArgb(58, 28, 4);
            this.pnlAhorro.Controls.Add(this.lblCapacidadAhorroTitulo);
            this.pnlAhorro.Controls.Add(this.lblCapacidadAhorro);
            this.pnlAhorro.Dock = DockStyle.Fill;
            this.pnlAhorro.Margin = new Padding(4);
            this.pnlAhorro.Name = "pnlAhorro";
            this.pnlAhorro.Padding = new Padding(10, 6, 10, 6);
            this.pnlAhorro.Size = new Size(290, 56);
            this.pnlAhorro.TabIndex = 3;

            // lblCapacidadAhorroTitulo
            this.lblCapacidadAhorroTitulo.AutoSize = true;
            this.lblCapacidadAhorroTitulo.Font = new Font("Segoe UI", 9F);
            this.lblCapacidadAhorroTitulo.ForeColor = Color.FromArgb(235, 150, 60);
            this.lblCapacidadAhorroTitulo.Location = new Point(8, 6);
            this.lblCapacidadAhorroTitulo.Name = "lblCapacidadAhorroTitulo";
            this.lblCapacidadAhorroTitulo.Size = new Size(150, 20);
            this.lblCapacidadAhorroTitulo.Text = "Capacidad de ahorro";

            // lblCapacidadAhorro
            this.lblCapacidadAhorro.AutoSize = true;
            this.lblCapacidadAhorro.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            this.lblCapacidadAhorro.ForeColor = Color.FromArgb(250, 155, 45);
            this.lblCapacidadAhorro.Location = new Point(8, 27);
            this.lblCapacidadAhorro.Name = "lblCapacidadAhorro";
            this.lblCapacidadAhorro.Size = new Size(76, 28);
            this.lblCapacidadAhorro.Text = "84.7 %";

            // 
            // grpGrafico
            // 
            this.grpGrafico.BackColor = Color.FromArgb(24, 24, 24);
            this.grpGrafico.Controls.Add(this.chartGastos);
            this.grpGrafico.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            this.grpGrafico.ForeColor = Color.FromArgb(220, 220, 220);
            this.grpGrafico.Location = new Point(20, 695);
            this.grpGrafico.Name = "grpGrafico";
            this.grpGrafico.Padding = new Padding(12);
            this.grpGrafico.Size = new Size(620, 210);
            this.grpGrafico.TabIndex = 4;
            this.grpGrafico.TabStop = false;
            this.grpGrafico.Text = "4. Gastos por categoría (Chart)";

            // chartGastos
            this.chartGastos.BackColor = Color.FromArgb(24, 24, 24);
            chartArea1.BackColor = Color.FromArgb(24, 24, 24);
            chartArea1.AxisX.LabelStyle.ForeColor = Color.FromArgb(220, 220, 220);
            chartArea1.AxisX.LineColor = Color.FromArgb(60, 60, 60);
            chartArea1.AxisX.MajorGrid.LineColor = Color.FromArgb(35, 35, 35);
            chartArea1.AxisY.LabelStyle.ForeColor = Color.FromArgb(220, 220, 220);
            chartArea1.AxisY.LineColor = Color.FromArgb(60, 60, 60);
            chartArea1.AxisY.MajorGrid.LineColor = Color.FromArgb(35, 35, 35);
            chartArea1.AxisY.LabelStyle.Format = "{0}%";
            chartArea1.Name = "ChartArea1";
            this.chartGastos.ChartAreas.Add(chartArea1);
            this.chartGastos.Dock = DockStyle.Fill;
            this.chartGastos.Location = new Point(12, 35);
            this.chartGastos.Name = "chartGastos";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = SeriesChartType.Bar;
            series1.Color = Color.FromArgb(30, 136, 110);
            series1.Name = "Gastos";
            this.chartGastos.Series.Add(series1);
            this.chartGastos.Size = new Size(596, 163);
            this.chartGastos.TabIndex = 0;

            // 
            // PresupuestoControl
            // 
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(18, 18, 18);
            this.Controls.Add(this.pnlPrincipal);
            this.Font = new Font("Segoe UI", 9F);
            this.Name = "PresupuestoControl";
            this.Size = new Size(1100, 920);
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlEncabezado.ResumeLayout(false);
            this.pnlEncabezado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAnio)).EndInit();
            this.grpRegistro.ResumeLayout(false);
            this.grpRegistro.PerformLayout();
            this.grpMovimientos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).EndInit();
            this.grpResumen.ResumeLayout(false);
            this.tlpResumen.ResumeLayout(false);
            this.pnlIngresos.ResumeLayout(false);
            this.pnlIngresos.PerformLayout();
            this.pnlGastos.ResumeLayout(false);
            this.pnlGastos.PerformLayout();
            this.pnlSaldo.ResumeLayout(false);
            this.pnlSaldo.PerformLayout();
            this.pnlAhorro.ResumeLayout(false);
            this.pnlAhorro.PerformLayout();
            this.grpGrafico.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartGastos)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private Panel pnlPrincipal;
        private Panel pnlEncabezado;
        private Label lblMes;
        private ComboBox cmbMes;
        private Label lblAnio;
        private NumericUpDown numAnio;
        private GroupBox grpRegistro;
        private Label lblTipo;
        private ComboBox cmbTipo;
        private Label lblCategoria;
        private ComboBox cmbCategoria;
        private Label lblDescripcion;
        private TextBox txtDescripcion;
        private Label lblMonto;
        private TextBox txtMonto;
        private Button btnAgregar;
        private Button btnEliminar;
        private Button btnLimpiar;
        private GroupBox grpMovimientos;
        private DataGridView dgvMovimientos;
        private DataGridViewTextBoxColumn colTipo;
        private DataGridViewTextBoxColumn colCategoria;
        private DataGridViewTextBoxColumn colMonto;
        private DataGridViewTextBoxColumn colFecha;
        private GroupBox grpResumen;
        private TableLayoutPanel tlpResumen;
        private Panel pnlIngresos;
        private Label lblTotalIngresosTitulo;
        private Label lblTotalIngresos;
        private Panel pnlGastos;
        private Label lblTotalGastosTitulo;
        private Label lblTotalGastos;
        private Panel pnlSaldo;
        private Label lblSaldoDisponibleTitulo;
        private Label lblSaldoDisponible;
        private Panel pnlAhorro;
        private Label lblCapacidadAhorroTitulo;
        private Label lblCapacidadAhorro;
        private GroupBox grpGrafico;
        private Chart chartGastos;
    }
}
