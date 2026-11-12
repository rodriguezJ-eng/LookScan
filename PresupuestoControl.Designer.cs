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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.pnlEncabezado = new System.Windows.Forms.Panel();
            this.lblMes = new System.Windows.Forms.Label();
            this.cmbMes = new System.Windows.Forms.ComboBox();
            this.lblAnio = new System.Windows.Forms.Label();
            this.numAnio = new System.Windows.Forms.NumericUpDown();
            this.grpRegistro = new System.Windows.Forms.GroupBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblMonto = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnEditarMovimiento = new System.Windows.Forms.Button();
            this.btnCargarDemo = new System.Windows.Forms.Button();
            this.grpMovimientos = new System.Windows.Forms.GroupBox();
            this.dgvMovimientos = new System.Windows.Forms.DataGridView();
            this.colTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpResumen = new System.Windows.Forms.GroupBox();
            this.tlpResumen = new System.Windows.Forms.TableLayoutPanel();
            this.pnlIngresos = new System.Windows.Forms.Panel();
            this.lblTotalIngresosTitulo = new System.Windows.Forms.Label();
            this.lblTotalIngresos = new System.Windows.Forms.Label();
            this.pnlGastos = new System.Windows.Forms.Panel();
            this.lblTotalGastosTitulo = new System.Windows.Forms.Label();
            this.lblTotalGastos = new System.Windows.Forms.Label();
            this.pnlSaldo = new System.Windows.Forms.Panel();
            this.lblSaldoDisponibleTitulo = new System.Windows.Forms.Label();
            this.lblSaldoDisponible = new System.Windows.Forms.Label();
            this.pnlAhorro = new System.Windows.Forms.Panel();
            this.lblCapacidadAhorroTitulo = new System.Windows.Forms.Label();
            this.lblCapacidadAhorro = new System.Windows.Forms.Label();
            this.grpGrafico = new System.Windows.Forms.GroupBox();
            this.chartGastos = new System.Windows.Forms.DataVisualization.Charting.Chart();
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
            this.pnlPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.pnlPrincipal.Controls.Add(this.pnlEncabezado);
            this.pnlPrincipal.Controls.Add(this.grpRegistro);
            this.pnlPrincipal.Controls.Add(this.grpMovimientos);
            this.pnlPrincipal.Controls.Add(this.grpResumen);
            this.pnlPrincipal.Controls.Add(this.grpGrafico);
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipal.Location = new System.Drawing.Point(0, 0);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Padding = new System.Windows.Forms.Padding(20, 15, 20, 20);
            this.pnlPrincipal.Size = new System.Drawing.Size(1100, 920);
            this.pnlPrincipal.TabIndex = 0;
            // 
            // pnlEncabezado
            // 
            this.pnlEncabezado.Controls.Add(this.lblMes);
            this.pnlEncabezado.Controls.Add(this.cmbMes);
            this.pnlEncabezado.Controls.Add(this.lblAnio);
            this.pnlEncabezado.Controls.Add(this.numAnio);
            this.pnlEncabezado.Controls.Add(this.btnCargarDemo);
            this.pnlEncabezado.Location = new System.Drawing.Point(20, 15);
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.Size = new System.Drawing.Size(1000, 42);
            this.pnlEncabezado.TabIndex = 0;
            // 
            // lblMes
            // 
            this.lblMes.AutoSize = true;
            this.lblMes.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblMes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblMes.Location = new System.Drawing.Point(4, 8);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(51, 25);
            this.lblMes.TabIndex = 0;
            this.lblMes.Text = "Mes:";
            // 
            // cmbMes
            // 
            this.cmbMes.BackColor = System.Drawing.Color.White;
            this.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMes.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.cmbMes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.cmbMes.FormattingEnabled = true;
            this.cmbMes.Items.AddRange(new object[] {
            "Enero",
            "Febrero",
            "Marzo",
            "Abril",
            "Mayo",
            "Junio",
            "Julio",
            "Agosto",
            "Septiembre",
            "Octubre",
            "Noviembre",
            "Diciembre"});
            this.cmbMes.Location = new System.Drawing.Point(60, 5);
            this.cmbMes.Name = "cmbMes";
            this.cmbMes.Size = new System.Drawing.Size(180, 31);
            this.cmbMes.TabIndex = 1;
            // 
            // lblAnio
            // 
            this.lblAnio.AutoSize = true;
            this.lblAnio.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblAnio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblAnio.Location = new System.Drawing.Point(270, 8);
            this.lblAnio.Name = "lblAnio";
            this.lblAnio.Size = new System.Drawing.Size(50, 25);
            this.lblAnio.TabIndex = 2;
            this.lblAnio.Text = "Año:";
            // 
            // numAnio
            // 
            this.numAnio.BackColor = System.Drawing.Color.White;
            this.numAnio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numAnio.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.numAnio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.numAnio.Location = new System.Drawing.Point(325, 6);
            this.numAnio.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.numAnio.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numAnio.Name = "numAnio";
            this.numAnio.Size = new System.Drawing.Size(110, 31);
            this.numAnio.TabIndex = 2;
            this.numAnio.Value = new decimal(new int[] {
            2026,
            0,
            0,
            0});
            // 
            // grpRegistro
            // 
            this.grpRegistro.BackColor = System.Drawing.Color.White;
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
            this.grpRegistro.Controls.Add(this.btnEditarMovimiento);
            this.grpRegistro.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.grpRegistro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.grpRegistro.Location = new System.Drawing.Point(20, 68);
            this.grpRegistro.Name = "grpRegistro";
            this.grpRegistro.Size = new System.Drawing.Size(1000, 225);
            this.grpRegistro.TabIndex = 1;
            this.grpRegistro.TabStop = false;
            this.grpRegistro.Text = "1. Registrar movimiento";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTipo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(95)))));
            this.lblTipo.Location = new System.Drawing.Point(18, 32);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(39, 20);
            this.lblTipo.TabIndex = 0;
            this.lblTipo.Text = "Tipo";
            // 
            // cmbTipo
            // 
            this.cmbTipo.BackColor = System.Drawing.Color.White;
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTipo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbTipo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Items.AddRange(new object[] {
            "Ingreso",
            "Gasto",
            "Ahorro",
            "Reserva"});
            this.cmbTipo.Location = new System.Drawing.Point(18, 55);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(270, 29);
            this.cmbTipo.TabIndex = 1;
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCategoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(95)))));
            this.lblCategoria.Location = new System.Drawing.Point(315, 32);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(74, 20);
            this.lblCategoria.TabIndex = 2;
            this.lblCategoria.Text = "Categoría";
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.BackColor = System.Drawing.Color.White;
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCategoria.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbCategoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(315, 55);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(285, 29);
            this.cmbCategoria.TabIndex = 2;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(95)))));
            this.lblDescripcion.Location = new System.Drawing.Point(18, 97);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(87, 20);
            this.lblDescripcion.TabIndex = 3;
            this.lblDescripcion.Text = "Descripción";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BackColor = System.Drawing.Color.White;
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescripcion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDescripcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.txtDescripcion.Location = new System.Drawing.Point(18, 120);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(270, 30);
            this.txtDescripcion.TabIndex = 3;
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMonto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(95)))));
            this.lblMonto.Location = new System.Drawing.Point(315, 97);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(74, 20);
            this.lblMonto.TabIndex = 4;
            this.lblMonto.Text = "Monto C$";
            // 
            // txtMonto
            // 
            this.txtMonto.BackColor = System.Drawing.Color.White;
            this.txtMonto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMonto.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMonto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.txtMonto.Location = new System.Drawing.Point(315, 120);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(285, 30);
            this.txtMonto.TabIndex = 4;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(72)))), ((int)(((byte)(140)))));
            this.btnAgregar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(18, 168);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(180, 38);
            this.btnAgregar.TabIndex = 5;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(72)))), ((int)(((byte)(140)))));
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(220, 168);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(180, 38);
            this.btnEliminar.TabIndex = 6;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(72)))), ((int)(((byte)(140)))));
            this.btnLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(420, 168);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(180, 38);
            this.btnLimpiar.TabIndex = 7;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            // 
            // btnEditarMovimiento
            // 
            this.btnEditarMovimiento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(72)))), ((int)(((byte)(140)))));
            this.btnEditarMovimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarMovimiento.ForeColor = System.Drawing.Color.White;
            this.btnEditarMovimiento.Location = new System.Drawing.Point(815, 115);
            this.btnEditarMovimiento.Name = "btnEditarMovimiento";
            this.btnEditarMovimiento.Size = new System.Drawing.Size(160, 38);
            this.btnEditarMovimiento.TabIndex = 8;
            this.btnEditarMovimiento.Text = "Editar seleccionado";
            this.btnEditarMovimiento.UseVisualStyleBackColor = false;
            // 
            // btnCargarDemo
            // 
            this.btnCargarDemo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(72)))), ((int)(((byte)(140)))));
            this.btnCargarDemo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargarDemo.ForeColor = System.Drawing.Color.White;
            this.btnCargarDemo.Location = new System.Drawing.Point(470, 4);
            this.btnCargarDemo.Name = "btnCargarDemo";
            this.btnCargarDemo.Size = new System.Drawing.Size(210, 34);
            this.btnCargarDemo.TabIndex = 3;
            this.btnCargarDemo.Text = "Cargar demo de agosto 2026";
            this.btnCargarDemo.UseVisualStyleBackColor = false;
            // 
            // grpMovimientos
            // 
            this.grpMovimientos.BackColor = System.Drawing.Color.White;
            this.grpMovimientos.Controls.Add(this.dgvMovimientos);
            this.grpMovimientos.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.grpMovimientos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.grpMovimientos.Location = new System.Drawing.Point(20, 305);
            this.grpMovimientos.Name = "grpMovimientos";
            this.grpMovimientos.Padding = new System.Windows.Forms.Padding(12);
            this.grpMovimientos.Size = new System.Drawing.Size(1000, 195);
            this.grpMovimientos.TabIndex = 2;
            this.grpMovimientos.TabStop = false;
            this.grpMovimientos.Text = "2. Movimientos";
            // 
            // dgvMovimientos
            // 
            this.dgvMovimientos.AllowUserToAddRows = false;
            this.dgvMovimientos.AllowUserToDeleteRows = false;
            this.dgvMovimientos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMovimientos.BackgroundColor = System.Drawing.Color.White;
            this.dgvMovimientos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMovimientos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(72)))), ((int)(((byte)(140)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(72)))), ((int)(((byte)(140)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMovimientos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMovimientos.ColumnHeadersHeight = 32;
            this.dgvMovimientos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTipo,
            this.colCategoria,
            this.colMonto,
            this.colFecha});
            this.dgvMovimientos.Columns.Add(this.colDescripcion);
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(55)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMovimientos.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMovimientos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMovimientos.EnableHeadersVisualStyles = false;
            this.dgvMovimientos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.dgvMovimientos.Location = new System.Drawing.Point(12, 35);
            this.dgvMovimientos.MultiSelect = false;
            this.dgvMovimientos.Name = "dgvMovimientos";
            this.dgvMovimientos.ReadOnly = true;
            this.dgvMovimientos.RowHeadersVisible = false;
            this.dgvMovimientos.RowHeadersWidth = 51;
            this.dgvMovimientos.RowTemplate.Height = 28;
            this.dgvMovimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMovimientos.Size = new System.Drawing.Size(976, 148);
            this.dgvMovimientos.TabIndex = 0;
            // 
            // colTipo
            // 
            this.colTipo.FillWeight = 20F;
            this.colTipo.HeaderText = "Tipo";
            this.colTipo.MinimumWidth = 6;
            this.colTipo.Name = "colTipo";
            this.colTipo.ReadOnly = true;
            // 
            // colCategoria
            // 
            this.colCategoria.FillWeight = 30F;
            this.colCategoria.HeaderText = "Categoría";
            this.colCategoria.MinimumWidth = 6;
            this.colCategoria.Name = "colCategoria";
            this.colCategoria.ReadOnly = true;
            // 
            // colMonto
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colMonto.DefaultCellStyle = dataGridViewCellStyle2;
            this.colMonto.FillWeight = 22F;
            this.colMonto.HeaderText = "Monto";
            this.colMonto.MinimumWidth = 6;
            this.colMonto.Name = "colMonto";
            this.colMonto.ReadOnly = true;
            // 
            // colFecha
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colFecha.DefaultCellStyle = dataGridViewCellStyle3;
            this.colFecha.FillWeight = 28F;
            this.colFecha.HeaderText = "Fecha (Día/Mes/Año)";
            this.colFecha.MinimumWidth = 6;
            this.colFecha.Name = "colFecha";
            // 
            // colDescripcion
            // 
            this.colDescripcion.HeaderText = "Descripción";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.ReadOnly = true;
            this.colFecha.ReadOnly = true;
            // 
            // grpResumen
            // 
            this.grpResumen.BackColor = System.Drawing.Color.White;
            this.grpResumen.Controls.Add(this.tlpResumen);
            this.grpResumen.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.grpResumen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.grpResumen.Location = new System.Drawing.Point(20, 510);
            this.grpResumen.Name = "grpResumen";
            this.grpResumen.Padding = new System.Windows.Forms.Padding(12);
            this.grpResumen.Size = new System.Drawing.Size(1000, 175);
            this.grpResumen.TabIndex = 3;
            this.grpResumen.TabStop = false;
            this.grpResumen.Text = "3. Resumen";
            // 
            // tlpResumen
            // 
            this.tlpResumen.ColumnCount = 2;
            this.tlpResumen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpResumen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpResumen.Controls.Add(this.pnlIngresos, 0, 0);
            this.tlpResumen.Controls.Add(this.pnlGastos, 1, 0);
            this.tlpResumen.Controls.Add(this.pnlSaldo, 0, 1);
            this.tlpResumen.Controls.Add(this.pnlAhorro, 1, 1);
            this.tlpResumen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpResumen.Location = new System.Drawing.Point(12, 35);
            this.tlpResumen.Name = "tlpResumen";
            this.tlpResumen.RowCount = 2;
            this.tlpResumen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpResumen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpResumen.Size = new System.Drawing.Size(976, 128);
            this.tlpResumen.TabIndex = 0;
            // 
            // pnlIngresos
            // 
            this.pnlIngresos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(247)))), ((int)(((byte)(232)))));
            this.pnlIngresos.Controls.Add(this.lblTotalIngresosTitulo);
            this.pnlIngresos.Controls.Add(this.lblTotalIngresos);
            this.pnlIngresos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlIngresos.Location = new System.Drawing.Point(4, 4);
            this.pnlIngresos.Margin = new System.Windows.Forms.Padding(4);
            this.pnlIngresos.Name = "pnlIngresos";
            this.pnlIngresos.Padding = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.pnlIngresos.Size = new System.Drawing.Size(480, 56);
            this.pnlIngresos.TabIndex = 0;
            // 
            // lblTotalIngresosTitulo
            // 
            this.lblTotalIngresosTitulo.AutoSize = true;
            this.lblTotalIngresosTitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalIngresosTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(190)))), ((int)(((byte)(110)))));
            this.lblTotalIngresosTitulo.Location = new System.Drawing.Point(8, 6);
            this.lblTotalIngresosTitulo.Name = "lblTotalIngresosTitulo";
            this.lblTotalIngresosTitulo.Size = new System.Drawing.Size(101, 20);
            this.lblTotalIngresosTitulo.TabIndex = 0;
            this.lblTotalIngresosTitulo.Text = "Total ingresos";
            // 
            // lblTotalIngresos
            // 
            this.lblTotalIngresos.AutoSize = true;
            this.lblTotalIngresos.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalIngresos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(220)))), ((int)(((byte)(110)))));
            this.lblTotalIngresos.Location = new System.Drawing.Point(8, 27);
            this.lblTotalIngresos.Name = "lblTotalIngresos";
            this.lblTotalIngresos.Size = new System.Drawing.Size(98, 28);
            this.lblTotalIngresos.TabIndex = 1;
            this.lblTotalIngresos.Text = "C$ 15,000";
            // 
            // pnlGastos
            // 
            this.pnlGastos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(229)))), ((int)(((byte)(234)))));
            this.pnlGastos.Controls.Add(this.lblTotalGastosTitulo);
            this.pnlGastos.Controls.Add(this.lblTotalGastos);
            this.pnlGastos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGastos.Location = new System.Drawing.Point(492, 4);
            this.pnlGastos.Margin = new System.Windows.Forms.Padding(4);
            this.pnlGastos.Name = "pnlGastos";
            this.pnlGastos.Padding = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.pnlGastos.Size = new System.Drawing.Size(480, 56);
            this.pnlGastos.TabIndex = 1;
            // 
            // lblTotalGastosTitulo
            // 
            this.lblTotalGastosTitulo.AutoSize = true;
            this.lblTotalGastosTitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalGastosTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.lblTotalGastosTitulo.Location = new System.Drawing.Point(8, 6);
            this.lblTotalGastosTitulo.Name = "lblTotalGastosTitulo";
            this.lblTotalGastosTitulo.Size = new System.Drawing.Size(89, 20);
            this.lblTotalGastosTitulo.TabIndex = 0;
            this.lblTotalGastosTitulo.Text = "Total gastos";
            // 
            // lblTotalGastos
            // 
            this.lblTotalGastos.AutoSize = true;
            this.lblTotalGastos.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalGastos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(100)))), ((int)(((byte)(110)))));
            this.lblTotalGastos.Location = new System.Drawing.Point(8, 27);
            this.lblTotalGastos.Name = "lblTotalGastos";
            this.lblTotalGastos.Size = new System.Drawing.Size(90, 28);
            this.lblTotalGastos.TabIndex = 1;
            this.lblTotalGastos.Text = "C$ 2,300";
            // 
            // pnlSaldo
            // 
            this.pnlSaldo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.pnlSaldo.Controls.Add(this.lblSaldoDisponibleTitulo);
            this.pnlSaldo.Controls.Add(this.lblSaldoDisponible);
            this.pnlSaldo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSaldo.Location = new System.Drawing.Point(4, 68);
            this.pnlSaldo.Margin = new System.Windows.Forms.Padding(4);
            this.pnlSaldo.Name = "pnlSaldo";
            this.pnlSaldo.Padding = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.pnlSaldo.Size = new System.Drawing.Size(480, 56);
            this.pnlSaldo.TabIndex = 2;
            // 
            // lblSaldoDisponibleTitulo
            // 
            this.lblSaldoDisponibleTitulo.AutoSize = true;
            this.lblSaldoDisponibleTitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSaldoDisponibleTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(165)))), ((int)(((byte)(245)))));
            this.lblSaldoDisponibleTitulo.Location = new System.Drawing.Point(8, 6);
            this.lblSaldoDisponibleTitulo.Name = "lblSaldoDisponibleTitulo";
            this.lblSaldoDisponibleTitulo.Size = new System.Drawing.Size(121, 20);
            this.lblSaldoDisponibleTitulo.TabIndex = 0;
            this.lblSaldoDisponibleTitulo.Text = "Saldo disponible";
            // 
            // lblSaldoDisponible
            // 
            this.lblSaldoDisponible.AutoSize = true;
            this.lblSaldoDisponible.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblSaldoDisponible.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(175)))), ((int)(((byte)(255)))));
            this.lblSaldoDisponible.Location = new System.Drawing.Point(8, 27);
            this.lblSaldoDisponible.Name = "lblSaldoDisponible";
            this.lblSaldoDisponible.Size = new System.Drawing.Size(98, 28);
            this.lblSaldoDisponible.TabIndex = 1;
            this.lblSaldoDisponible.Text = "C$ 12,700";
            // 
            // pnlAhorro
            // 
            this.pnlAhorro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(218)))));
            this.pnlAhorro.Controls.Add(this.lblCapacidadAhorroTitulo);
            this.pnlAhorro.Controls.Add(this.lblCapacidadAhorro);
            this.pnlAhorro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAhorro.Location = new System.Drawing.Point(492, 68);
            this.pnlAhorro.Margin = new System.Windows.Forms.Padding(4);
            this.pnlAhorro.Name = "pnlAhorro";
            this.pnlAhorro.Padding = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.pnlAhorro.Size = new System.Drawing.Size(480, 56);
            this.pnlAhorro.TabIndex = 3;
            // 
            // lblCapacidadAhorroTitulo
            // 
            this.lblCapacidadAhorroTitulo.AutoSize = true;
            this.lblCapacidadAhorroTitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCapacidadAhorroTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(150)))), ((int)(((byte)(60)))));
            this.lblCapacidadAhorroTitulo.Location = new System.Drawing.Point(8, 6);
            this.lblCapacidadAhorroTitulo.Name = "lblCapacidadAhorroTitulo";
            this.lblCapacidadAhorroTitulo.Size = new System.Drawing.Size(149, 20);
            this.lblCapacidadAhorroTitulo.TabIndex = 0;
            this.lblCapacidadAhorroTitulo.Text = "Capacidad de ahorro";
            // 
            // lblCapacidadAhorro
            // 
            this.lblCapacidadAhorro.AutoSize = true;
            this.lblCapacidadAhorro.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblCapacidadAhorro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(155)))), ((int)(((byte)(45)))));
            this.lblCapacidadAhorro.Location = new System.Drawing.Point(8, 27);
            this.lblCapacidadAhorro.Name = "lblCapacidadAhorro";
            this.lblCapacidadAhorro.Size = new System.Drawing.Size(74, 28);
            this.lblCapacidadAhorro.TabIndex = 1;
            this.lblCapacidadAhorro.Text = "84.7 %";
            // 
            // grpGrafico
            // 
            this.grpGrafico.BackColor = System.Drawing.Color.White;
            this.grpGrafico.Controls.Add(this.chartGastos);
            this.grpGrafico.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.grpGrafico.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.grpGrafico.Location = new System.Drawing.Point(20, 695);
            this.grpGrafico.Name = "grpGrafico";
            this.grpGrafico.Padding = new System.Windows.Forms.Padding(12);
            this.grpGrafico.Size = new System.Drawing.Size(1000, 210);
            this.grpGrafico.TabIndex = 4;
            this.grpGrafico.TabStop = false;
            this.grpGrafico.Text = "4. Gastos por categoría";
            // 
            // chartGastos
            // 
            this.chartGastos.BackColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            chartArea1.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            chartArea1.AxisY.LabelStyle.Format = "{0}%";
            chartArea1.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            chartArea1.BackColor = System.Drawing.Color.White;
            chartArea1.Name = "ChartArea1";
            this.chartGastos.ChartAreas.Add(chartArea1);
            this.chartGastos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartGastos.Location = new System.Drawing.Point(12, 35);
            this.chartGastos.Name = "chartGastos";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(110)))));
            series1.Name = "Gastos";
            this.chartGastos.Series.Add(series1);
            this.chartGastos.Size = new System.Drawing.Size(976, 163);
            this.chartGastos.TabIndex = 0;
            // 
            // PresupuestoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.pnlPrincipal);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "PresupuestoControl";
            this.Size = new System.Drawing.Size(1100, 920);
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
        private Button btnEditarMovimiento;
        private Button btnCargarDemo;
        private GroupBox grpMovimientos;
        private DataGridView dgvMovimientos;
        private DataGridViewTextBoxColumn colTipo;
        private DataGridViewTextBoxColumn colCategoria;
        private DataGridViewTextBoxColumn colMonto;
        private DataGridViewTextBoxColumn colFecha;
        private DataGridViewTextBoxColumn colDescripcion;
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
