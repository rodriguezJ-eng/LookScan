using System;
using System.Drawing;
using System.Windows.Forms;

namespace LookScan
{
    partial class EoafControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvEoaf = new System.Windows.Forms.DataGridView();
            this.dgvEoafCol0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvEoafCol1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvEoafCol2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvEoafCol3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvEoafCol4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvEoafCol5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvEoafCol6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpEoaf = new System.Windows.Forms.GroupBox();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPeriodoBaseEoaf = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbPeriodoCompEoaf = new System.Windows.Forms.ComboBox();
            this.btnCalcularEoaf = new System.Windows.Forms.Button();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.pnlBody = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEoaf)).BeginInit();
            this.grpEoaf.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvEoaf
            // 
            this.dgvEoaf.AllowUserToAddRows = false;
            this.dgvEoaf.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.dgvEoaf.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEoaf.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEoaf.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvEoaf.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(72)))), ((int)(((byte)(140)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvEoaf.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEoaf.ColumnHeadersHeight = 32;
            this.dgvEoaf.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvEoaf.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvEoafCol0,
            this.dgvEoafCol1,
            this.dgvEoafCol2,
            this.dgvEoafCol3,
            this.dgvEoafCol4,
            this.dgvEoafCol5,
            this.dgvEoafCol6});
            this.dgvEoaf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEoaf.EnableHeadersVisualStyles = false;
            this.dgvEoaf.Location = new System.Drawing.Point(8, 28);
            this.dgvEoaf.Name = "dgvEoaf";
            this.dgvEoaf.ReadOnly = true;
            this.dgvEoaf.RowHeadersVisible = false;
            this.dgvEoaf.RowHeadersWidth = 51;
            this.dgvEoaf.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEoaf.Size = new System.Drawing.Size(964, 422);
            this.dgvEoaf.TabIndex = 0;
            // 
            // dgvEoafCol0
            // 
            this.dgvEoafCol0.HeaderText = "Cuenta";
            this.dgvEoafCol0.MinimumWidth = 6;
            this.dgvEoafCol0.Name = "dgvEoafCol0";
            this.dgvEoafCol0.ReadOnly = true;
            // 
            // dgvEoafCol1
            // 
            this.dgvEoafCol1.HeaderText = "Clasif.";
            this.dgvEoafCol1.MinimumWidth = 6;
            this.dgvEoafCol1.Name = "dgvEoafCol1";
            this.dgvEoafCol1.ReadOnly = true;
            // 
            // dgvEoafCol2
            // 
            this.dgvEoafCol2.HeaderText = "Año 1";
            this.dgvEoafCol2.MinimumWidth = 6;
            this.dgvEoafCol2.Name = "dgvEoafCol2";
            this.dgvEoafCol2.ReadOnly = true;
            // 
            // dgvEoafCol3
            // 
            this.dgvEoafCol3.HeaderText = "Año 2";
            this.dgvEoafCol3.MinimumWidth = 6;
            this.dgvEoafCol3.Name = "dgvEoafCol3";
            this.dgvEoafCol3.ReadOnly = true;
            // 
            // dgvEoafCol4
            // 
            this.dgvEoafCol4.HeaderText = "Cambios";
            this.dgvEoafCol4.MinimumWidth = 6;
            this.dgvEoafCol4.Name = "dgvEoafCol4";
            this.dgvEoafCol4.ReadOnly = true;
            // 
            // dgvEoafCol5
            // 
            this.dgvEoafCol5.HeaderText = "Origen";
            this.dgvEoafCol5.MinimumWidth = 6;
            this.dgvEoafCol5.Name = "dgvEoafCol5";
            this.dgvEoafCol5.ReadOnly = true;
            // 
            // dgvEoafCol6
            // 
            this.dgvEoafCol6.HeaderText = "Aplicación";
            this.dgvEoafCol6.MinimumWidth = 6;
            this.dgvEoafCol6.Name = "dgvEoafCol6";
            this.dgvEoafCol6.ReadOnly = true;
            // 
            // grpEoaf
            // 
            this.grpEoaf.Controls.Add(this.dgvEoaf);
            this.grpEoaf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpEoaf.Location = new System.Drawing.Point(10, 4);
            this.grpEoaf.Name = "grpEoaf";
            this.grpEoaf.Padding = new System.Windows.Forms.Padding(8, 6, 8, 8);
            this.grpEoaf.Size = new System.Drawing.Size(980, 458);
            this.grpEoaf.TabIndex = 0;
            this.grpEoaf.TabStop = false;
            this.grpEoaf.Text = "Resultado EOAF";
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Controls.Add(this.lblDescripcion);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1000, 66);
            this.pnlHeader.TabIndex = 2;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(72)))), ((int)(((byte)(140)))));
            this.lblTitulo.Location = new System.Drawing.Point(14, 8);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(83, 37);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "EOAF";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.lblDescripcion.Location = new System.Drawing.Point(16, 42);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(292, 21);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.Text = "Estado de Origen y Aplicación de Fondos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(100)))));
            this.label1.Location = new System.Drawing.Point(10, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Periodo base";
            // 
            // cmbPeriodoBaseEoaf
            // 
            this.cmbPeriodoBaseEoaf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPeriodoBaseEoaf.FormattingEnabled = true;
            this.cmbPeriodoBaseEoaf.Items.AddRange(new object[] {
            "2023",
            "2024",
            "2025"});
            this.cmbPeriodoBaseEoaf.Location = new System.Drawing.Point(10, 27);
            this.cmbPeriodoBaseEoaf.Name = "cmbPeriodoBaseEoaf";
            this.cmbPeriodoBaseEoaf.Size = new System.Drawing.Size(110, 29);
            this.cmbPeriodoBaseEoaf.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(100)))));
            this.label2.Location = new System.Drawing.Point(144, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Periodo comparado";
            // 
            // cmbPeriodoCompEoaf
            // 
            this.cmbPeriodoCompEoaf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPeriodoCompEoaf.FormattingEnabled = true;
            this.cmbPeriodoCompEoaf.Items.AddRange(new object[] {
            "2023",
            "2024",
            "2025"});
            this.cmbPeriodoCompEoaf.Location = new System.Drawing.Point(144, 27);
            this.cmbPeriodoCompEoaf.Name = "cmbPeriodoCompEoaf";
            this.cmbPeriodoCompEoaf.Size = new System.Drawing.Size(110, 29);
            this.cmbPeriodoCompEoaf.TabIndex = 3;
            // 
            // btnCalcularEoaf
            // 
            this.btnCalcularEoaf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(72)))), ((int)(((byte)(140)))));
            this.btnCalcularEoaf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCalcularEoaf.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(72)))), ((int)(((byte)(140)))));
            this.btnCalcularEoaf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalcularEoaf.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnCalcularEoaf.Location = new System.Drawing.Point(306, 24);
            this.btnCalcularEoaf.Name = "btnCalcularEoaf";
            this.btnCalcularEoaf.Size = new System.Drawing.Size(120, 30);
            this.btnCalcularEoaf.TabIndex = 4;
            this.btnCalcularEoaf.Text = "Calcular EOAF";
            this.btnCalcularEoaf.UseVisualStyleBackColor = false;
            this.btnCalcularEoaf.Click += new System.EventHandler(this.btnCalcularEoaf_Click);
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.AutoScroll = true;
            this.pnlToolbar.Controls.Add(this.label1);
            this.pnlToolbar.Controls.Add(this.cmbPeriodoBaseEoaf);
            this.pnlToolbar.Controls.Add(this.label2);
            this.pnlToolbar.Controls.Add(this.cmbPeriodoCompEoaf);
            this.pnlToolbar.Controls.Add(this.btnCalcularEoaf);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(0, 66);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(1000, 62);
            this.pnlToolbar.TabIndex = 1;
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.grpEoaf);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 128);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(10, 4, 10, 10);
            this.pnlBody.Size = new System.Drawing.Size(1000, 472);
            this.pnlBody.TabIndex = 0;
            // 
            // EoafControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "EoafControl";
            this.Size = new System.Drawing.Size(1000, 600);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEoaf)).EndInit();
            this.grpEoaf.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEoaf;
        private System.Windows.Forms.DataGridViewCellStyle dgvEoafHdrStyle;
        private System.Windows.Forms.DataGridViewCellStyle dgvEoafAltStyle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvEoafCol0;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvEoafCol1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvEoafCol2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvEoafCol3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvEoafCol4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvEoafCol5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvEoafCol6;
        private System.Windows.Forms.GroupBox grpEoaf;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPeriodoBaseEoaf;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbPeriodoCompEoaf;
        private System.Windows.Forms.Button btnCalcularEoaf;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Panel pnlBody;
    }
}
