using System;
using System.Drawing;
using System.Windows.Forms;

namespace LookScan
{
    partial class InventarioControl
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
            this.pnlPrincipal = new Panel();
            this.grpDatosProducto = new GroupBox();
            this.lblCodigo = new Label();
            this.txtCodigo = new TextBox();
            this.lblProducto = new Label();
            this.txtProducto = new TextBox();
            this.lblExistenciaInicial = new Label();
            this.txtExistenciaInicial = new TextBox();
            this.lblCostoUnitario = new Label();
            this.txtCostoUnitario = new TextBox();
            this.lblStockMinimo = new Label();
            this.txtStockMinimo = new TextBox();
            this.btnGuardarProducto = new Button();
            this.btnEditarProducto = new Button();
            this.btnCargarDemo = new Button();
            this.grpRegistrarMov = new GroupBox();
            this.lblMovProducto = new Label();
            this.cmbProductoMov = new ComboBox();
            this.lblMovTipo = new Label();
            this.cmbTipoMov = new ComboBox();
            this.lblMovCantidad = new Label();
            this.txtCantidadMov = new TextBox();
            this.btnRegistrarMov = new Button();
            this.btnLimpiarMov = new Button();
            this.grpExistencias = new GroupBox();
            this.dgvExistencias = new DataGridView();
            this.colInvProducto = new DataGridViewTextBoxColumn();
            this.colInvInic = new DataGridViewTextBoxColumn();
            this.colInvEnt = new DataGridViewTextBoxColumn();
            this.colInvSal = new DataGridViewTextBoxColumn();
            this.colInvFinal = new DataGridViewTextBoxColumn();
            this.colInvValor = new DataGridViewTextBoxColumn();
            this.lblNotaRojo = new Label();
            this.grpResumenAlerta = new GroupBox();
            this.tlpResumenInv = new TableLayoutPanel();
            this.pnlValorTotal = new Panel();
            this.lblValorTotalTitulo = new Label();
            this.lblValorTotal = new Label();
            this.pnlReponer = new Panel();
            this.lblProductosReponerTitulo = new Label();
            this.lblProductosReponer = new Label();
            this.pnlAlertaBanner = new Panel();
            this.lblAlertaReposicion = new Label();
            this.pnlPrincipal.SuspendLayout();
            this.grpDatosProducto.SuspendLayout();
            this.grpRegistrarMov.SuspendLayout();
            this.grpExistencias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExistencias)).BeginInit();
            this.grpResumenAlerta.SuspendLayout();
            this.tlpResumenInv.SuspendLayout();
            this.pnlValorTotal.SuspendLayout();
            this.pnlReponer.SuspendLayout();
            this.pnlAlertaBanner.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.AutoScroll = true;
            this.pnlPrincipal.BackColor = Color.FromArgb(244, 246, 250);
            this.pnlPrincipal.Controls.Add(this.grpDatosProducto);
            this.pnlPrincipal.Controls.Add(this.grpRegistrarMov);
            this.pnlPrincipal.Controls.Add(this.grpExistencias);
            this.pnlPrincipal.Controls.Add(this.grpResumenAlerta);
            this.pnlPrincipal.Dock = DockStyle.Fill;
            this.pnlPrincipal.Location = new Point(0, 0);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Padding = new Padding(20, 15, 20, 20);
            this.pnlPrincipal.Size = new Size(1100, 920);
            this.pnlPrincipal.TabIndex = 0;

            // 
            // grpDatosProducto
            // 
            this.grpDatosProducto.BackColor = Color.White;
            this.grpDatosProducto.Controls.Add(this.lblCodigo);
            this.grpDatosProducto.Controls.Add(this.txtCodigo);
            this.grpDatosProducto.Controls.Add(this.lblProducto);
            this.grpDatosProducto.Controls.Add(this.txtProducto);
            this.grpDatosProducto.Controls.Add(this.lblExistenciaInicial);
            this.grpDatosProducto.Controls.Add(this.txtExistenciaInicial);
            this.grpDatosProducto.Controls.Add(this.lblCostoUnitario);
            this.grpDatosProducto.Controls.Add(this.txtCostoUnitario);
            this.grpDatosProducto.Controls.Add(this.lblStockMinimo);
            this.grpDatosProducto.Controls.Add(this.txtStockMinimo);
            this.grpDatosProducto.Controls.Add(this.btnGuardarProducto);
            this.grpDatosProducto.Controls.Add(this.btnEditarProducto);
            this.grpDatosProducto.Controls.Add(this.btnCargarDemo);
            this.grpDatosProducto.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            this.grpDatosProducto.ForeColor = Color.FromArgb(45, 55, 72);
            this.grpDatosProducto.Location = new Point(20, 15);
            this.grpDatosProducto.Name = "grpDatosProducto";
            this.grpDatosProducto.Size = new Size(1000, 215);
            this.grpDatosProducto.TabIndex = 0;
            this.grpDatosProducto.TabStop = false;
            this.grpDatosProducto.Text = "1. Datos del producto";

            // lblCodigo
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new Font("Segoe UI", 9F);
            this.lblCodigo.ForeColor = Color.FromArgb(70, 80, 95);
            this.lblCodigo.Location = new Point(18, 28);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new Size(119, 20);
            this.lblCodigo.Text = "Código";

            // txtCodigo
            this.txtCodigo.BackColor = Color.White;
            this.txtCodigo.BorderStyle = BorderStyle.FixedSingle;
            this.txtCodigo.Font = new Font("Segoe UI", 10F);
            this.txtCodigo.ForeColor = Color.FromArgb(35, 45, 60);
            this.txtCodigo.Location = new Point(18, 50);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new Size(270, 30);
            this.txtCodigo.TabIndex = 1;

            // lblProducto
            this.lblProducto.AutoSize = true;
            this.lblProducto.Font = new Font("Segoe UI", 9F);
            this.lblProducto.ForeColor = Color.FromArgb(70, 80, 95);
            this.lblProducto.Location = new Point(315, 28);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new Size(130, 20);
            this.lblProducto.Text = "Producto";

            // txtProducto
            this.txtProducto.BackColor = Color.White;
            this.txtProducto.BorderStyle = BorderStyle.FixedSingle;
            this.txtProducto.Font = new Font("Segoe UI", 10F);
            this.txtProducto.ForeColor = Color.FromArgb(35, 45, 60);
            this.txtProducto.Location = new Point(315, 50);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new Size(285, 30);
            this.txtProducto.TabIndex = 2;

            // lblExistenciaInicial
            this.lblExistenciaInicial.AutoSize = true;
            this.lblExistenciaInicial.Font = new Font("Segoe UI", 9F);
            this.lblExistenciaInicial.ForeColor = Color.FromArgb(70, 80, 95);
            this.lblExistenciaInicial.Location = new Point(18, 90);
            this.lblExistenciaInicial.Name = "lblExistenciaInicial";
            this.lblExistenciaInicial.Size = new Size(116, 20);
            this.lblExistenciaInicial.Text = "Existencia inicial";

            // txtExistenciaInicial
            this.txtExistenciaInicial.BackColor = Color.White;
            this.txtExistenciaInicial.BorderStyle = BorderStyle.FixedSingle;
            this.txtExistenciaInicial.Font = new Font("Segoe UI", 10F);
            this.txtExistenciaInicial.ForeColor = Color.FromArgb(35, 45, 60);
            this.txtExistenciaInicial.Location = new Point(18, 112);
            this.txtExistenciaInicial.Name = "txtExistenciaInicial";
            this.txtExistenciaInicial.Size = new Size(270, 30);
            this.txtExistenciaInicial.TabIndex = 3;

            // lblCostoUnitario
            this.lblCostoUnitario.AutoSize = true;
            this.lblCostoUnitario.Font = new Font("Segoe UI", 9F);
            this.lblCostoUnitario.ForeColor = Color.FromArgb(70, 80, 95);
            this.lblCostoUnitario.Location = new Point(315, 90);
            this.lblCostoUnitario.Name = "lblCostoUnitario";
            this.lblCostoUnitario.Size = new Size(122, 20);
            this.lblCostoUnitario.Text = "Costo unitario C$";

            // txtCostoUnitario
            this.txtCostoUnitario.BackColor = Color.White;
            this.txtCostoUnitario.BorderStyle = BorderStyle.FixedSingle;
            this.txtCostoUnitario.Font = new Font("Segoe UI", 10F);
            this.txtCostoUnitario.ForeColor = Color.FromArgb(35, 45, 60);
            this.txtCostoUnitario.Location = new Point(315, 112);
            this.txtCostoUnitario.Name = "txtCostoUnitario";
            this.txtCostoUnitario.Size = new Size(285, 30);
            this.txtCostoUnitario.TabIndex = 4;

            // lblStockMinimo
            this.lblStockMinimo.AutoSize = true;
            this.lblStockMinimo.Font = new Font("Segoe UI", 9F);
            this.lblStockMinimo.ForeColor = Color.FromArgb(70, 80, 95);
            this.lblStockMinimo.Location = new Point(18, 150);
            this.lblStockMinimo.Name = "lblStockMinimo";
            this.lblStockMinimo.Size = new Size(99, 20);
            this.lblStockMinimo.Text = "Stock mínimo";

            // txtStockMinimo
            this.txtStockMinimo.BackColor = Color.White;
            this.txtStockMinimo.BorderStyle = BorderStyle.FixedSingle;
            this.txtStockMinimo.Font = new Font("Segoe UI", 10F);
            this.txtStockMinimo.ForeColor = Color.FromArgb(35, 45, 60);
            this.txtStockMinimo.Location = new Point(18, 172);
            this.txtStockMinimo.Name = "txtStockMinimo";
            this.txtStockMinimo.Size = new Size(270, 30);
            this.txtStockMinimo.TabIndex = 5;

            // btnGuardarProducto
            this.btnGuardarProducto.BackColor = Color.FromArgb(24, 72, 140);
            this.btnGuardarProducto.FlatAppearance.BorderColor = Color.FromArgb(70, 70, 70);
            this.btnGuardarProducto.FlatStyle = FlatStyle.Flat;
            this.btnGuardarProducto.Font = new Font("Segoe UI", 9.5F);
            this.btnGuardarProducto.ForeColor = Color.White;
            this.btnGuardarProducto.Location = new Point(315, 168);
            this.btnGuardarProducto.Name = "btnGuardarProducto";
            this.btnGuardarProducto.Size = new Size(285, 36);
            this.btnGuardarProducto.TabIndex = 6;
            this.btnGuardarProducto.Text = "Guardar producto";
            this.btnGuardarProducto.UseVisualStyleBackColor = false;
            // 
            // btnEditarProducto
            // 
            this.btnEditarProducto.BackColor = Color.FromArgb(24, 72, 140);
            this.btnEditarProducto.FlatStyle = FlatStyle.Flat;
            this.btnEditarProducto.ForeColor = Color.White;
            this.btnEditarProducto.Location = new Point(650, 120);
            this.btnEditarProducto.Name = "btnEditarProducto";
            this.btnEditarProducto.Size = new Size(180, 36);
            this.btnEditarProducto.TabIndex = 7;
            this.btnEditarProducto.Text = "Editar seleccionado";
            this.btnEditarProducto.UseVisualStyleBackColor = false;
            // 
            // btnCargarDemo
            // 
            this.btnCargarDemo.BackColor = Color.FromArgb(24, 72, 140);
            this.btnCargarDemo.FlatStyle = FlatStyle.Flat;
            this.btnCargarDemo.ForeColor = Color.White;
            this.btnCargarDemo.Location = new Point(650, 168);
            this.btnCargarDemo.Name = "btnCargarDemo";
            this.btnCargarDemo.Size = new Size(180, 36);
            this.btnCargarDemo.TabIndex = 8;
            this.btnCargarDemo.Text = "Cargar demo";
            this.btnCargarDemo.UseVisualStyleBackColor = false;

            // 
            // grpRegistrarMov
            // 
            this.grpRegistrarMov.BackColor = Color.White;
            this.grpRegistrarMov.Controls.Add(this.lblMovProducto);
            this.grpRegistrarMov.Controls.Add(this.cmbProductoMov);
            this.grpRegistrarMov.Controls.Add(this.lblMovTipo);
            this.grpRegistrarMov.Controls.Add(this.cmbTipoMov);
            this.grpRegistrarMov.Controls.Add(this.lblMovCantidad);
            this.grpRegistrarMov.Controls.Add(this.txtCantidadMov);
            this.grpRegistrarMov.Controls.Add(this.btnRegistrarMov);
            this.grpRegistrarMov.Controls.Add(this.btnLimpiarMov);
            this.grpRegistrarMov.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            this.grpRegistrarMov.ForeColor = Color.FromArgb(45, 55, 72);
            this.grpRegistrarMov.Location = new Point(20, 240);
            this.grpRegistrarMov.Name = "grpRegistrarMov";
            this.grpRegistrarMov.Size = new Size(1000, 160);
            this.grpRegistrarMov.TabIndex = 1;
            this.grpRegistrarMov.TabStop = false;
            this.grpRegistrarMov.Text = "2. Registrar movimiento";

            // lblMovProducto
            this.lblMovProducto.AutoSize = true;
            this.lblMovProducto.Font = new Font("Segoe UI", 9F);
            this.lblMovProducto.ForeColor = Color.FromArgb(70, 80, 95);
            this.lblMovProducto.Location = new Point(18, 28);
            this.lblMovProducto.Name = "lblMovProducto";
            this.lblMovProducto.Size = new Size(69, 20);
            this.lblMovProducto.Text = "Producto";

            // cmbProductoMov
            this.cmbProductoMov.BackColor = Color.White;
            this.cmbProductoMov.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbProductoMov.FlatStyle = FlatStyle.Flat;
            this.cmbProductoMov.Font = new Font("Segoe UI", 9.5F);
            this.cmbProductoMov.ForeColor = Color.FromArgb(35, 45, 60);
            this.cmbProductoMov.FormattingEnabled = true;
            this.cmbProductoMov.Location = new Point(18, 52);
            this.cmbProductoMov.Name = "cmbProductoMov";
            this.cmbProductoMov.Size = new Size(185, 29);
            this.cmbProductoMov.TabIndex = 1;

            // lblMovTipo
            this.lblMovTipo.AutoSize = true;
            this.lblMovTipo.Font = new Font("Segoe UI", 9F);
            this.lblMovTipo.ForeColor = Color.FromArgb(70, 80, 95);
            this.lblMovTipo.Location = new Point(220, 28);
            this.lblMovTipo.Name = "lblMovTipo";
            this.lblMovTipo.Size = new Size(39, 20);
            this.lblMovTipo.Text = "Tipo";

            // cmbTipoMov
            this.cmbTipoMov.BackColor = Color.White;
            this.cmbTipoMov.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbTipoMov.FlatStyle = FlatStyle.Flat;
            this.cmbTipoMov.Font = new Font("Segoe UI", 9.5F);
            this.cmbTipoMov.ForeColor = Color.FromArgb(35, 45, 60);
            this.cmbTipoMov.FormattingEnabled = true;
            this.cmbTipoMov.Items.AddRange(new object[] { "Salida", "Entrada" });
            this.cmbTipoMov.Location = new Point(220, 52);
            this.cmbTipoMov.Name = "cmbTipoMov";
            this.cmbTipoMov.Size = new Size(180, 29);
            this.cmbTipoMov.TabIndex = 2;

            // lblMovCantidad
            this.lblMovCantidad.AutoSize = true;
            this.lblMovCantidad.Font = new Font("Segoe UI", 9F);
            this.lblMovCantidad.ForeColor = Color.FromArgb(70, 80, 95);
            this.lblMovCantidad.Location = new Point(420, 28);
            this.lblMovCantidad.Name = "lblMovCantidad";
            this.lblMovCantidad.Size = new Size(69, 20);
            this.lblMovCantidad.Text = "Cantidad";

            // txtCantidadMov
            this.txtCantidadMov.BackColor = Color.White;
            this.txtCantidadMov.BorderStyle = BorderStyle.FixedSingle;
            this.txtCantidadMov.Font = new Font("Segoe UI", 10F);
            this.txtCantidadMov.ForeColor = Color.FromArgb(35, 45, 60);
            this.txtCantidadMov.Location = new Point(420, 52);
            this.txtCantidadMov.Name = "txtCantidadMov";
            this.txtCantidadMov.Size = new Size(180, 30);
            this.txtCantidadMov.TabIndex = 3;

            // btnRegistrarMov
            this.btnRegistrarMov.BackColor = Color.FromArgb(24, 72, 140);
            this.btnRegistrarMov.FlatAppearance.BorderColor = Color.FromArgb(70, 70, 70);
            this.btnRegistrarMov.FlatStyle = FlatStyle.Flat;
            this.btnRegistrarMov.Font = new Font("Segoe UI", 9.5F);
            this.btnRegistrarMov.ForeColor = Color.White;
            this.btnRegistrarMov.Location = new Point(18, 102);
            this.btnRegistrarMov.Name = "btnRegistrarMov";
            this.btnRegistrarMov.Size = new Size(270, 38);
            this.btnRegistrarMov.TabIndex = 4;
            this.btnRegistrarMov.Text = "Registrar";
            this.btnRegistrarMov.UseVisualStyleBackColor = false;

            // btnLimpiarMov
            this.btnLimpiarMov.BackColor = Color.FromArgb(24, 72, 140);
            this.btnLimpiarMov.FlatAppearance.BorderColor = Color.FromArgb(70, 70, 70);
            this.btnLimpiarMov.FlatStyle = FlatStyle.Flat;
            this.btnLimpiarMov.Font = new Font("Segoe UI", 9.5F);
            this.btnLimpiarMov.ForeColor = Color.White;
            this.btnLimpiarMov.Location = new Point(315, 102);
            this.btnLimpiarMov.Name = "btnLimpiarMov";
            this.btnLimpiarMov.Size = new Size(285, 38);
            this.btnLimpiarMov.TabIndex = 5;
            this.btnLimpiarMov.Text = "Limpiar";
            this.btnLimpiarMov.UseVisualStyleBackColor = false;

            // 
            // grpExistencias
            // 
            this.grpExistencias.BackColor = Color.White;
            this.grpExistencias.Controls.Add(this.dgvExistencias);
            this.grpExistencias.Controls.Add(this.lblNotaRojo);
            this.grpExistencias.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            this.grpExistencias.ForeColor = Color.FromArgb(45, 55, 72);
            this.grpExistencias.Location = new Point(20, 410);
            this.grpExistencias.Name = "grpExistencias";
            this.grpExistencias.Padding = new Padding(12);
            this.grpExistencias.Size = new Size(1000, 225);
            this.grpExistencias.TabIndex = 2;
            this.grpExistencias.TabStop = false;
            this.grpExistencias.Text = "3. Existencias";

            // dgvExistencias
            this.dgvExistencias.AllowUserToAddRows = false;
            this.dgvExistencias.AllowUserToDeleteRows = false;
            this.dgvExistencias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvExistencias.BackgroundColor = Color.White;
            this.dgvExistencias.BorderStyle = BorderStyle.None;
            this.dgvExistencias.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.dgvExistencias.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(24, 72, 140);
            this.dgvExistencias.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvExistencias.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            this.dgvExistencias.ColumnHeadersHeight = 32;
            this.dgvExistencias.Columns.AddRange(new DataGridViewColumn[] {
                this.colInvProducto, this.colInvInic, this.colInvEnt, this.colInvSal, this.colInvFinal, this.colInvValor
            });
            this.dgvExistencias.DefaultCellStyle.BackColor = Color.White;
            this.dgvExistencias.DefaultCellStyle.ForeColor = Color.FromArgb(35, 45, 60);
            this.dgvExistencias.DefaultCellStyle.SelectionBackColor = Color.FromArgb(225, 238, 255);
            this.dgvExistencias.DefaultCellStyle.SelectionForeColor = Color.FromArgb(20, 55, 100);
            this.dgvExistencias.Dock = DockStyle.Fill;
            this.dgvExistencias.EnableHeadersVisualStyles = false;
            this.dgvExistencias.GridColor = Color.FromArgb(44, 44, 44);
            this.dgvExistencias.Location = new Point(12, 35);
            this.dgvExistencias.MultiSelect = false;
            this.dgvExistencias.Name = "dgvExistencias";
            this.dgvExistencias.ReadOnly = true;
            this.dgvExistencias.RowHeadersVisible = false;
            this.dgvExistencias.RowTemplate.Height = 28;
            this.dgvExistencias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvExistencias.Size = new Size(596, 150);
            this.dgvExistencias.TabIndex = 0;

            // colInvProducto
            this.colInvProducto.HeaderText = "Producto";
            this.colInvProducto.Name = "colInvProducto";
            this.colInvProducto.ReadOnly = true;
            this.colInvProducto.FillWeight = 26F;

            // colInvInic
            this.colInvInic.HeaderText = "Inic.";
            this.colInvInic.Name = "colInvInic";
            this.colInvInic.ReadOnly = true;
            this.colInvInic.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.colInvInic.FillWeight = 14F;

            // colInvEnt
            this.colInvEnt.HeaderText = "Ent.";
            this.colInvEnt.Name = "colInvEnt";
            this.colInvEnt.ReadOnly = true;
            this.colInvEnt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.colInvEnt.FillWeight = 14F;

            // colInvSal
            this.colInvSal.HeaderText = "Sal.";
            this.colInvSal.Name = "colInvSal";
            this.colInvSal.ReadOnly = true;
            this.colInvSal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.colInvSal.FillWeight = 14F;

            // colInvFinal
            this.colInvFinal.HeaderText = "Final";
            this.colInvFinal.Name = "colInvFinal";
            this.colInvFinal.ReadOnly = true;
            this.colInvFinal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.colInvFinal.FillWeight = 14F;

            // colInvValor
            this.colInvValor.HeaderText = "Valor C$";
            this.colInvValor.Name = "colInvValor";
            this.colInvValor.ReadOnly = true;
            this.colInvValor.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.colInvValor.FillWeight = 18F;

            // lblNotaRojo
            this.lblNotaRojo.Dock = DockStyle.Bottom;
            this.lblNotaRojo.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            this.lblNotaRojo.ForeColor = Color.FromArgb(180, 180, 180);
            this.lblNotaRojo.Location = new Point(12, 185);
            this.lblNotaRojo.Name = "lblNotaRojo";
            this.lblNotaRojo.Size = new Size(596, 28);
            this.lblNotaRojo.Text = "Fila en rojo: existencia final menor o igual al stock mínimo.";
            this.lblNotaRojo.TextAlign = ContentAlignment.MiddleLeft;

            // 
            // grpResumenAlerta
            // 
            this.grpResumenAlerta.BackColor = Color.White;
            this.grpResumenAlerta.Controls.Add(this.tlpResumenInv);
            this.grpResumenAlerta.Controls.Add(this.pnlAlertaBanner);
            this.grpResumenAlerta.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            this.grpResumenAlerta.ForeColor = Color.FromArgb(45, 55, 72);
            this.grpResumenAlerta.Location = new Point(20, 645);
            this.grpResumenAlerta.Name = "grpResumenAlerta";
            this.grpResumenAlerta.Padding = new Padding(12);
            this.grpResumenAlerta.Size = new Size(1000, 175);
            this.grpResumenAlerta.TabIndex = 3;
            this.grpResumenAlerta.TabStop = false;
            this.grpResumenAlerta.Text = "4. Resumen y alerta";

            // tlpResumenInv
            this.tlpResumenInv.ColumnCount = 2;
            this.tlpResumenInv.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.tlpResumenInv.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.tlpResumenInv.Controls.Add(this.pnlValorTotal, 0, 0);
            this.tlpResumenInv.Controls.Add(this.pnlReponer, 1, 0);
            this.tlpResumenInv.Dock = DockStyle.Top;
            this.tlpResumenInv.Location = new Point(12, 35);
            this.tlpResumenInv.Name = "tlpResumenInv";
            this.tlpResumenInv.RowCount = 1;
            this.tlpResumenInv.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.tlpResumenInv.Size = new Size(596, 68);
            this.tlpResumenInv.TabIndex = 0;

            // pnlValorTotal
            this.pnlValorTotal.BackColor = Color.FromArgb(226, 240, 255);
            this.pnlValorTotal.Controls.Add(this.lblValorTotalTitulo);
            this.pnlValorTotal.Controls.Add(this.lblValorTotal);
            this.pnlValorTotal.Dock = DockStyle.Fill;
            this.pnlValorTotal.Margin = new Padding(4);
            this.pnlValorTotal.Name = "pnlValorTotal";
            this.pnlValorTotal.Padding = new Padding(10, 6, 10, 6);
            this.pnlValorTotal.Size = new Size(290, 60);
            this.pnlValorTotal.TabIndex = 0;

            // lblValorTotalTitulo
            this.lblValorTotalTitulo.AutoSize = true;
            this.lblValorTotalTitulo.Font = new Font("Segoe UI", 9F);
            this.lblValorTotalTitulo.ForeColor = Color.FromArgb(100, 165, 245);
            this.lblValorTotalTitulo.Location = new Point(8, 6);
            this.lblValorTotalTitulo.Name = "lblValorTotalTitulo";
            this.lblValorTotalTitulo.Size = new Size(158, 20);
            this.lblValorTotalTitulo.Text = "Valor total inventario";

            // lblValorTotal
            this.lblValorTotal.AutoSize = true;
            this.lblValorTotal.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            this.lblValorTotal.ForeColor = Color.FromArgb(90, 175, 255);
            this.lblValorTotal.Location = new Point(8, 28);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new Size(103, 30);
            this.lblValorTotal.Text = "C$ 3,890";

            // pnlReponer
            this.pnlReponer.BackColor = Color.FromArgb(255, 242, 218);
            this.pnlReponer.Controls.Add(this.lblProductosReponerTitulo);
            this.pnlReponer.Controls.Add(this.lblProductosReponer);
            this.pnlReponer.Dock = DockStyle.Fill;
            this.pnlReponer.Margin = new Padding(4);
            this.pnlReponer.Name = "pnlReponer";
            this.pnlReponer.Padding = new Padding(10, 6, 10, 6);
            this.pnlReponer.Size = new Size(290, 60);
            this.pnlReponer.TabIndex = 1;

            // lblProductosReponerTitulo
            this.lblProductosReponerTitulo.AutoSize = true;
            this.lblProductosReponerTitulo.Font = new Font("Segoe UI", 9F);
            this.lblProductosReponerTitulo.ForeColor = Color.FromArgb(235, 150, 60);
            this.lblProductosReponerTitulo.Location = new Point(8, 6);
            this.lblProductosReponerTitulo.Name = "lblProductosReponerTitulo";
            this.lblProductosReponerTitulo.Size = new Size(147, 20);
            this.lblProductosReponerTitulo.Text = "Productos a reponer";

            // lblProductosReponer
            this.lblProductosReponer.AutoSize = true;
            this.lblProductosReponer.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            this.lblProductosReponer.ForeColor = Color.FromArgb(250, 155, 45);
            this.lblProductosReponer.Location = new Point(8, 28);
            this.lblProductosReponer.Name = "lblProductosReponer";
            this.lblProductosReponer.Size = new Size(22, 30);
            this.lblProductosReponer.Text = "1";

            // pnlAlertaBanner
            this.pnlAlertaBanner.BackColor = Color.FromArgb(255, 232, 232);
            this.pnlAlertaBanner.Controls.Add(this.lblAlertaReposicion);
            this.pnlAlertaBanner.Dock = DockStyle.Bottom;
            this.pnlAlertaBanner.Location = new Point(12, 115);
            this.pnlAlertaBanner.Name = "pnlAlertaBanner";
            this.pnlAlertaBanner.Padding = new Padding(10);
            this.pnlAlertaBanner.Size = new Size(596, 48);
            this.pnlAlertaBanner.TabIndex = 1;

            // lblAlertaReposicion
            this.lblAlertaReposicion.Dock = DockStyle.Fill;
            this.lblAlertaReposicion.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            this.lblAlertaReposicion.ForeColor = Color.FromArgb(160, 65, 75);
            this.lblAlertaReposicion.Location = new Point(10, 10);
            this.lblAlertaReposicion.Name = "lblAlertaReposicion";
            this.lblAlertaReposicion.Size = new Size(576, 28);
            this.lblAlertaReposicion.Text = "⚠ Reponer: Arroz 1 lb (40 de 40 mínimo)";
            this.lblAlertaReposicion.TextAlign = ContentAlignment.MiddleLeft;

            // 
            // InventarioControl
            // 
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(244, 246, 250);
            this.Controls.Add(this.pnlPrincipal);
            this.Font = new Font("Segoe UI", 9F);
            this.Name = "InventarioControl";
            this.Size = new Size(1100, 920);
            this.pnlPrincipal.ResumeLayout(false);
            this.grpDatosProducto.ResumeLayout(false);
            this.grpDatosProducto.PerformLayout();
            this.grpRegistrarMov.ResumeLayout(false);
            this.grpRegistrarMov.PerformLayout();
            this.grpExistencias.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExistencias)).EndInit();
            this.grpResumenAlerta.ResumeLayout(false);
            this.tlpResumenInv.ResumeLayout(false);
            this.pnlValorTotal.ResumeLayout(false);
            this.pnlValorTotal.PerformLayout();
            this.pnlReponer.ResumeLayout(false);
            this.pnlReponer.PerformLayout();
            this.pnlAlertaBanner.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private Panel pnlPrincipal;
        private GroupBox grpDatosProducto;
        private Label lblCodigo;
        private TextBox txtCodigo;
        private Label lblProducto;
        private TextBox txtProducto;
        private Label lblExistenciaInicial;
        private TextBox txtExistenciaInicial;
        private Label lblCostoUnitario;
        private TextBox txtCostoUnitario;
        private Label lblStockMinimo;
        private TextBox txtStockMinimo;
        private Button btnGuardarProducto;
        private Button btnEditarProducto;
        private Button btnCargarDemo;
        private GroupBox grpRegistrarMov;
        private Label lblMovProducto;
        private ComboBox cmbProductoMov;
        private Label lblMovTipo;
        private ComboBox cmbTipoMov;
        private Label lblMovCantidad;
        private TextBox txtCantidadMov;
        private Button btnRegistrarMov;
        private Button btnLimpiarMov;
        private GroupBox grpExistencias;
        private DataGridView dgvExistencias;
        private DataGridViewTextBoxColumn colInvProducto;
        private DataGridViewTextBoxColumn colInvInic;
        private DataGridViewTextBoxColumn colInvEnt;
        private DataGridViewTextBoxColumn colInvSal;
        private DataGridViewTextBoxColumn colInvFinal;
        private DataGridViewTextBoxColumn colInvValor;
        private Label lblNotaRojo;
        private GroupBox grpResumenAlerta;
        private TableLayoutPanel tlpResumenInv;
        private Panel pnlValorTotal;
        private Label lblValorTotalTitulo;
        private Label lblValorTotal;
        private Panel pnlReponer;
        private Label lblProductosReponerTitulo;
        private Label lblProductosReponer;
        private Panel pnlAlertaBanner;
        private Label lblAlertaReposicion;
    }
}
