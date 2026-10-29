using System;
using System.Drawing;
using System.Windows.Forms;

namespace LookScan
{
    partial class ValoracionControl
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
            this.dgvDcf = new System.Windows.Forms.DataGridView();
            this.dgvDcfHdrStyle = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDcfAltStyle = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDcfCol0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDcfCol1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpDcf = new System.Windows.Forms.GroupBox();
            this.dgvPe = new System.Windows.Forms.DataGridView();
            this.dgvPeHdrStyle = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvPeAltStyle = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvPeCol0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPeCol1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpPe = new System.Windows.Forms.GroupBox();
            this.tlpVal = new System.Windows.Forms.TableLayoutPanel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPeriodoVal = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numAcciones = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numTasa = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numCrecimiento = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numPE = new System.Windows.Forms.NumericUpDown();
            this.btnCalcularVal = new System.Windows.Forms.Button();
            this.grpParametrosVal = new System.Windows.Forms.GroupBox();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.pnlBody = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDcf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPe)).BeginInit();
            this.grpDcf.SuspendLayout();
            this.grpPe.SuspendLayout();
            this.tlpVal.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.grpParametrosVal.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDcf
            // 
            this.dgvDcf.AllowUserToAddRows = false;
            this.dgvDcf.AllowUserToDeleteRows = false;
            this.dgvDcf.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDcf.BackgroundColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.dgvDcf.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDcf.ColumnHeadersHeight = 32;
            this.dgvDcf.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDcf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDcf.EnableHeadersVisualStyles = false;
            this.dgvDcf.ReadOnly = true;
            this.dgvDcf.RowHeadersVisible = false;
            this.dgvDcf.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDcf.ColumnHeadersDefaultCellStyle = this.dgvDcfHdrStyle;
            this.dgvDcf.AlternatingRowsDefaultCellStyle = this.dgvDcfAltStyle;
            this.dgvDcf.Name = "dgvDcf";
            this.dgvDcf.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.dgvDcfCol0,
                this.dgvDcfCol1});
            // 
            // dgvDcfHdrStyle
            // 
            this.dgvDcfHdrStyle.BackColor = System.Drawing.Color.FromArgb(24, 72, 140);
            this.dgvDcfHdrStyle.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            // 
            // dgvDcfAltStyle
            // 
            this.dgvDcfAltStyle.BackColor = System.Drawing.Color.FromArgb(247, 249, 252);
            // 
            // dgvDcfCol0
            // 
            this.dgvDcfCol0.HeaderText = "Concepto";
            this.dgvDcfCol0.Name = "dgvDcfCol0";
            // 
            // dgvDcfCol1
            // 
            this.dgvDcfCol1.HeaderText = "Valor";
            this.dgvDcfCol1.Name = "dgvDcfCol1";
            // 
            // grpDcf
            // 
            this.grpDcf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDcf.Padding = new System.Windows.Forms.Padding(8, 6, 8, 8);
            this.grpDcf.TabStop = false;
            this.grpDcf.Text = "Valoración por DCF";
            this.grpDcf.Name = "grpDcf";
            this.grpDcf.Controls.Add(this.dgvDcf);
            // 
            // dgvPe
            // 
            this.dgvPe.AllowUserToAddRows = false;
            this.dgvPe.AllowUserToDeleteRows = false;
            this.dgvPe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPe.BackgroundColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.dgvPe.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPe.ColumnHeadersHeight = 32;
            this.dgvPe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPe.EnableHeadersVisualStyles = false;
            this.dgvPe.ReadOnly = true;
            this.dgvPe.RowHeadersVisible = false;
            this.dgvPe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPe.ColumnHeadersDefaultCellStyle = this.dgvPeHdrStyle;
            this.dgvPe.AlternatingRowsDefaultCellStyle = this.dgvPeAltStyle;
            this.dgvPe.Name = "dgvPe";
            this.dgvPe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.dgvPeCol0,
                this.dgvPeCol1});
            // 
            // dgvPeHdrStyle
            // 
            this.dgvPeHdrStyle.BackColor = System.Drawing.Color.FromArgb(24, 72, 140);
            this.dgvPeHdrStyle.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            // 
            // dgvPeAltStyle
            // 
            this.dgvPeAltStyle.BackColor = System.Drawing.Color.FromArgb(247, 249, 252);
            // 
            // dgvPeCol0
            // 
            this.dgvPeCol0.HeaderText = "Concepto";
            this.dgvPeCol0.Name = "dgvPeCol0";
            // 
            // dgvPeCol1
            // 
            this.dgvPeCol1.HeaderText = "Valor";
            this.dgvPeCol1.Name = "dgvPeCol1";
            // 
            // grpPe
            // 
            this.grpPe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPe.Padding = new System.Windows.Forms.Padding(8, 6, 8, 8);
            this.grpPe.TabStop = false;
            this.grpPe.Text = "Valoración por múltiplo P/E";
            this.grpPe.Name = "grpPe";
            this.grpPe.Controls.Add(this.dgvPe);
            // 
            // tlpVal
            // 
            this.tlpVal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpVal.Name = "tlpVal";
            this.tlpVal.ColumnCount = 2;
            this.tlpVal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0F));
            this.tlpVal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0F));
            this.tlpVal.RowCount = 1;
            this.tlpVal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpVal.Controls.Add(this.grpDcf, 0, 0);
            this.tlpVal.Controls.Add(this.grpPe, 1, 0);
            // 
            // pnlHeader
            // 
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Size = new System.Drawing.Size(1000, 66);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Controls.Add(this.lblDescripcion);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(24, 72, 140);
            this.lblTitulo.Location = new System.Drawing.Point(14, 8);
            this.lblTitulo.Text = "Valoración de la empresa";
            this.lblTitulo.Name = "lblTitulo";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(105, 105, 105);
            this.lblDescripcion.Location = new System.Drawing.Point(16, 42);
            this.lblDescripcion.Text = "Flujo descontado (DCF) y múltiplo P/E";
            this.lblDescripcion.Name = "lblDescripcion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 20);
            this.label1.Text = "Periodo";
            this.label1.ForeColor = System.Drawing.Color.FromArgb(70, 80, 100);
            this.label1.Name = "label1";
            // 
            // cmbPeriodoVal
            // 
            this.cmbPeriodoVal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPeriodoVal.FormattingEnabled = true;
            this.cmbPeriodoVal.Items.AddRange(new object[] { "2023", "2024", "2025" });
            this.cmbPeriodoVal.Location = new System.Drawing.Point(10, 40);
            this.cmbPeriodoVal.Size = new System.Drawing.Size(100, 23);
            this.cmbPeriodoVal.SelectedIndex = 0;
            this.cmbPeriodoVal.Name = "cmbPeriodoVal";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(122, 20);
            this.label2.Text = "N° de acciones";
            this.label2.ForeColor = System.Drawing.Color.FromArgb(70, 80, 100);
            this.label2.Name = "label2";
            // 
            // numAcciones
            // 
            this.numAcciones.DecimalPlaces = 0;
            this.numAcciones.Location = new System.Drawing.Point(122, 40);
            this.numAcciones.Size = new System.Drawing.Size(130, 23);
            this.numAcciones.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.numAcciones.Maximum = new decimal(new int[] { -727379969, 232, 0, 0 });
            this.numAcciones.Value = new decimal(new int[] { 0, 0, 0, 0 });
            this.numAcciones.Name = "numAcciones";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(264, 20);
            this.label3.Text = "Tasa de descuento (%)";
            this.label3.ForeColor = System.Drawing.Color.FromArgb(70, 80, 100);
            this.label3.Name = "label3";
            // 
            // numTasa
            // 
            this.numTasa.DecimalPlaces = 2;
            this.numTasa.Location = new System.Drawing.Point(264, 40);
            this.numTasa.Size = new System.Drawing.Size(130, 23);
            this.numTasa.Minimum = new decimal(new int[] { 0, 0, 0, 131072 });
            this.numTasa.Maximum = new decimal(new int[] { 10000, 0, 0, 131072 });
            this.numTasa.Value = new decimal(new int[] { 0, 0, 0, 131072 });
            this.numTasa.Name = "numTasa";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(416, 20);
            this.label4.Text = "Crecimiento a largo plazo (%)";
            this.label4.ForeColor = System.Drawing.Color.FromArgb(70, 80, 100);
            this.label4.Name = "label4";
            // 
            // numCrecimiento
            // 
            this.numCrecimiento.DecimalPlaces = 2;
            this.numCrecimiento.Location = new System.Drawing.Point(416, 40);
            this.numCrecimiento.Size = new System.Drawing.Size(160, 23);
            this.numCrecimiento.Minimum = new decimal(new int[] { 10000, 0, 0, -2147352576 });
            this.numCrecimiento.Maximum = new decimal(new int[] { 10000, 0, 0, 131072 });
            this.numCrecimiento.Value = new decimal(new int[] { 0, 0, 0, 131072 });
            this.numCrecimiento.Name = "numCrecimiento";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(619, 20);
            this.label5.Text = "Múltiplo P/E";
            this.label5.ForeColor = System.Drawing.Color.FromArgb(70, 80, 100);
            this.label5.Name = "label5";
            // 
            // numPE
            // 
            this.numPE.DecimalPlaces = 2;
            this.numPE.Location = new System.Drawing.Point(619, 40);
            this.numPE.Size = new System.Drawing.Size(100, 23);
            this.numPE.Minimum = new decimal(new int[] { 0, 0, 0, 131072 });
            this.numPE.Maximum = new decimal(new int[] { 100000, 0, 0, 131072 });
            this.numPE.Value = new decimal(new int[] { 0, 0, 0, 131072 });
            this.numPE.Name = "numPE";
            // 
            // btnCalcularVal
            // 
            this.btnCalcularVal.BackColor = System.Drawing.Color.FromArgb(24, 72, 140);
            this.btnCalcularVal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCalcularVal.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(24, 72, 140);
            this.btnCalcularVal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalcularVal.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.btnCalcularVal.Location = new System.Drawing.Point(731, 38);
            this.btnCalcularVal.Size = new System.Drawing.Size(150, 30);
            this.btnCalcularVal.Text = "Calcular valoración";
            this.btnCalcularVal.UseVisualStyleBackColor = false;
            this.btnCalcularVal.Name = "btnCalcularVal";
            // 
            // grpParametrosVal
            // 
            this.grpParametrosVal.Location = new System.Drawing.Point(10, 6);
            this.grpParametrosVal.Size = new System.Drawing.Size(891, 80);
            this.grpParametrosVal.TabStop = false;
            this.grpParametrosVal.Text = "Parámetros";
            this.grpParametrosVal.Name = "grpParametrosVal";
            this.grpParametrosVal.Controls.Add(this.label1);
            this.grpParametrosVal.Controls.Add(this.cmbPeriodoVal);
            this.grpParametrosVal.Controls.Add(this.label2);
            this.grpParametrosVal.Controls.Add(this.numAcciones);
            this.grpParametrosVal.Controls.Add(this.label3);
            this.grpParametrosVal.Controls.Add(this.numTasa);
            this.grpParametrosVal.Controls.Add(this.label4);
            this.grpParametrosVal.Controls.Add(this.numCrecimiento);
            this.grpParametrosVal.Controls.Add(this.label5);
            this.grpParametrosVal.Controls.Add(this.numPE);
            this.grpParametrosVal.Controls.Add(this.btnCalcularVal);
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.AutoScroll = true;
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Size = new System.Drawing.Size(1000, 94);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Controls.Add(this.grpParametrosVal);
            // 
            // pnlBody
            // 
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Padding = new System.Windows.Forms.Padding(10, 4, 10, 10);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Controls.Add(this.tlpVal);
            // 
            // ValoracionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(244, 246, 250);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Size = new System.Drawing.Size(1000, 600);
            this.Name = "ValoracionControl";
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.pnlHeader);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDcf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPe)).EndInit();
            this.pnlBody.ResumeLayout(false);
            this.pnlToolbar.ResumeLayout(false);
            this.grpParametrosVal.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.tlpVal.ResumeLayout(false);
            this.grpPe.ResumeLayout(false);
            this.grpDcf.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDcf;
        private System.Windows.Forms.DataGridViewCellStyle dgvDcfHdrStyle;
        private System.Windows.Forms.DataGridViewCellStyle dgvDcfAltStyle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDcfCol0;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDcfCol1;
        private System.Windows.Forms.GroupBox grpDcf;
        private System.Windows.Forms.DataGridView dgvPe;
        private System.Windows.Forms.DataGridViewCellStyle dgvPeHdrStyle;
        private System.Windows.Forms.DataGridViewCellStyle dgvPeAltStyle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPeCol0;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPeCol1;
        private System.Windows.Forms.GroupBox grpPe;
        private System.Windows.Forms.TableLayoutPanel tlpVal;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPeriodoVal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numAcciones;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numTasa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numCrecimiento;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numPE;
        private System.Windows.Forms.Button btnCalcularVal;
        private System.Windows.Forms.GroupBox grpParametrosVal;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Panel pnlBody;
    }
}
