using System;
using System.Drawing;
using System.Windows.Forms;

namespace LookScan
{
    partial class EfeControl
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
            this.dgvEfe = new System.Windows.Forms.DataGridView();
            this.dgvEfeCol0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvEfeCol1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpEfe = new System.Windows.Forms.GroupBox();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPeriodoBaseEfe = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbPeriodoCompEfe = new System.Windows.Forms.ComboBox();
            this.rbMetodo1 = new System.Windows.Forms.RadioButton();
            this.rbMetodo2 = new System.Windows.Forms.RadioButton();
            this.rbMetodo = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCalcularEfe = new System.Windows.Forms.Button();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.pnlBody = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEfe)).BeginInit();
            this.grpEfe.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.rbMetodo.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvEfe
            // 
            this.dgvEfe.AllowUserToAddRows = false;
            this.dgvEfe.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.dgvEfe.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEfe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEfe.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvEfe.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(72)))), ((int)(((byte)(140)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvEfe.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEfe.ColumnHeadersHeight = 32;
            this.dgvEfe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvEfe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvEfeCol0,
            this.dgvEfeCol1});
            this.dgvEfe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEfe.EnableHeadersVisualStyles = false;
            this.dgvEfe.Location = new System.Drawing.Point(8, 28);
            this.dgvEfe.Name = "dgvEfe";
            this.dgvEfe.ReadOnly = true;
            this.dgvEfe.RowHeadersVisible = false;
            this.dgvEfe.RowHeadersWidth = 51;
            this.dgvEfe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEfe.Size = new System.Drawing.Size(964, 410);
            this.dgvEfe.TabIndex = 0;
            // 
            // dgvEfeCol0
            // 
            this.dgvEfeCol0.HeaderText = "Concepto";
            this.dgvEfeCol0.MinimumWidth = 6;
            this.dgvEfeCol0.Name = "dgvEfeCol0";
            this.dgvEfeCol0.ReadOnly = true;
            // 
            // dgvEfeCol1
            // 
            this.dgvEfeCol1.HeaderText = "Monto";
            this.dgvEfeCol1.MinimumWidth = 6;
            this.dgvEfeCol1.Name = "dgvEfeCol1";
            this.dgvEfeCol1.ReadOnly = true;
            // 
            // grpEfe
            // 
            this.grpEfe.Controls.Add(this.dgvEfe);
            this.grpEfe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpEfe.Location = new System.Drawing.Point(10, 4);
            this.grpEfe.Name = "grpEfe";
            this.grpEfe.Padding = new System.Windows.Forms.Padding(8, 6, 8, 8);
            this.grpEfe.Size = new System.Drawing.Size(980, 446);
            this.grpEfe.TabIndex = 0;
            this.grpEfe.TabStop = false;
            this.grpEfe.Text = "Resultado";
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
            this.lblTitulo.Size = new System.Drawing.Size(344, 37);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Estado de Flujo de Efectivo";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.lblDescripcion.Location = new System.Drawing.Point(16, 42);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(194, 21);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.Text = "Método indirecto o directo";
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
            // cmbPeriodoBaseEfe
            // 
            this.cmbPeriodoBaseEfe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPeriodoBaseEfe.FormattingEnabled = true;
            this.cmbPeriodoBaseEfe.Items.AddRange(new object[] {
            "2023",
            "2024",
            "2025"});
            this.cmbPeriodoBaseEfe.Location = new System.Drawing.Point(10, 26);
            this.cmbPeriodoBaseEfe.Name = "cmbPeriodoBaseEfe";
            this.cmbPeriodoBaseEfe.Size = new System.Drawing.Size(110, 29);
            this.cmbPeriodoBaseEfe.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(100)))));
            this.label2.Location = new System.Drawing.Point(132, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Periodo comparado";
            // 
            // cmbPeriodoCompEfe
            // 
            this.cmbPeriodoCompEfe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPeriodoCompEfe.FormattingEnabled = true;
            this.cmbPeriodoCompEfe.Items.AddRange(new object[] {
            "2023",
            "2024",
            "2025"});
            this.cmbPeriodoCompEfe.Location = new System.Drawing.Point(132, 26);
            this.cmbPeriodoCompEfe.Name = "cmbPeriodoCompEfe";
            this.cmbPeriodoCompEfe.Size = new System.Drawing.Size(110, 29);
            this.cmbPeriodoCompEfe.TabIndex = 3;
            // 
            // rbMetodo1
            // 
            this.rbMetodo1.AutoSize = true;
            this.rbMetodo1.Checked = true;
            this.rbMetodo1.Location = new System.Drawing.Point(4, 4);
            this.rbMetodo1.Name = "rbMetodo1";
            this.rbMetodo1.Size = new System.Drawing.Size(92, 25);
            this.rbMetodo1.TabIndex = 0;
            this.rbMetodo1.TabStop = true;
            this.rbMetodo1.Text = "Indirecto";
            // 
            // rbMetodo2
            // 
            this.rbMetodo2.AutoSize = true;
            this.rbMetodo2.Location = new System.Drawing.Point(110, 4);
            this.rbMetodo2.Name = "rbMetodo2";
            this.rbMetodo2.Size = new System.Drawing.Size(81, 25);
            this.rbMetodo2.TabIndex = 1;
            this.rbMetodo2.TabStop = true;
            this.rbMetodo2.Text = "Directo";
            // 
            // rbMetodo
            // 
            this.rbMetodo.Controls.Add(this.rbMetodo1);
            this.rbMetodo.Controls.Add(this.rbMetodo2);
            this.rbMetodo.Location = new System.Drawing.Point(284, 25);
            this.rbMetodo.Name = "rbMetodo";
            this.rbMetodo.Size = new System.Drawing.Size(200, 28);
            this.rbMetodo.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(100)))));
            this.label3.Location = new System.Drawing.Point(284, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Método";
            // 
            // btnCalcularEfe
            // 
            this.btnCalcularEfe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(72)))), ((int)(((byte)(140)))));
            this.btnCalcularEfe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCalcularEfe.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(72)))), ((int)(((byte)(140)))));
            this.btnCalcularEfe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalcularEfe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnCalcularEfe.Location = new System.Drawing.Point(518, 23);
            this.btnCalcularEfe.Name = "btnCalcularEfe";
            this.btnCalcularEfe.Size = new System.Drawing.Size(120, 30);
            this.btnCalcularEfe.TabIndex = 6;
            this.btnCalcularEfe.Text = "Calcular EFE";
            this.btnCalcularEfe.UseVisualStyleBackColor = false;
            this.btnCalcularEfe.Click += new System.EventHandler(this.btnCalcularEfe_Click);
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.AutoScroll = true;
            this.pnlToolbar.Controls.Add(this.label1);
            this.pnlToolbar.Controls.Add(this.cmbPeriodoBaseEfe);
            this.pnlToolbar.Controls.Add(this.label2);
            this.pnlToolbar.Controls.Add(this.cmbPeriodoCompEfe);
            this.pnlToolbar.Controls.Add(this.label3);
            this.pnlToolbar.Controls.Add(this.rbMetodo);
            this.pnlToolbar.Controls.Add(this.btnCalcularEfe);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(0, 66);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(1000, 74);
            this.pnlToolbar.TabIndex = 1;
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.grpEfe);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 140);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(10, 4, 10, 10);
            this.pnlBody.Size = new System.Drawing.Size(1000, 460);
            this.pnlBody.TabIndex = 0;
            // 
            // EfeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "EfeControl";
            this.Size = new System.Drawing.Size(1000, 600);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEfe)).EndInit();
            this.grpEfe.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.rbMetodo.ResumeLayout(false);
            this.rbMetodo.PerformLayout();
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEfe;
        private System.Windows.Forms.DataGridViewCellStyle dgvEfeHdrStyle;
        private System.Windows.Forms.DataGridViewCellStyle dgvEfeAltStyle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvEfeCol0;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvEfeCol1;
        private System.Windows.Forms.GroupBox grpEfe;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPeriodoBaseEfe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbPeriodoCompEfe;
        private System.Windows.Forms.RadioButton rbMetodo1;
        private System.Windows.Forms.RadioButton rbMetodo2;
        private System.Windows.Forms.Panel rbMetodo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCalcularEfe;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Panel pnlBody;
    }
}
