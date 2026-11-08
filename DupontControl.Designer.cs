using System;
using System.Drawing;
using System.Windows.Forms;

namespace LookScan
{
    partial class DupontControl
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
            this.dgvDupont = new System.Windows.Forms.DataGridView();
            this.grpDupont = new System.Windows.Forms.GroupBox();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPeriodoDupont = new System.Windows.Forms.ComboBox();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.dgvDupontCol0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDupontCol1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDupont)).BeginInit();
            this.grpDupont.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDupont
            // 
            this.dgvDupont.AllowUserToAddRows = false;
            this.dgvDupont.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.dgvDupont.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDupont.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDupont.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvDupont.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(72)))), ((int)(((byte)(140)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvDupont.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDupont.ColumnHeadersHeight = 32;
            this.dgvDupont.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDupont.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvDupontCol0,
            this.dgvDupontCol1,
            this.Column1});
            this.dgvDupont.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDupont.EnableHeadersVisualStyles = false;
            this.dgvDupont.Location = new System.Drawing.Point(8, 28);
            this.dgvDupont.Name = "dgvDupont";
            this.dgvDupont.ReadOnly = true;
            this.dgvDupont.RowHeadersVisible = false;
            this.dgvDupont.RowHeadersWidth = 51;
            this.dgvDupont.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDupont.Size = new System.Drawing.Size(964, 426);
            this.dgvDupont.TabIndex = 0;
            // 
            // grpDupont
            // 
            this.grpDupont.Controls.Add(this.dgvDupont);
            this.grpDupont.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDupont.Location = new System.Drawing.Point(10, 4);
            this.grpDupont.Name = "grpDupont";
            this.grpDupont.Padding = new System.Windows.Forms.Padding(8, 6, 8, 8);
            this.grpDupont.Size = new System.Drawing.Size(980, 462);
            this.grpDupont.TabIndex = 0;
            this.grpDupont.TabStop = false;
            this.grpDupont.Text = "Componentes";
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
            this.lblTitulo.Size = new System.Drawing.Size(327, 37);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Modelo DuPont (3 pasos)";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.lblDescripcion.Location = new System.Drawing.Point(16, 42);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(482, 21);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.Text = "ROE = Margen neto × Rotación de activos × Multiplicador de capital";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(100)))));
            this.label1.Location = new System.Drawing.Point(10, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Periodo";
            // 
            // cmbPeriodoDupont
            // 
            this.cmbPeriodoDupont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPeriodoDupont.FormattingEnabled = true;
            this.cmbPeriodoDupont.Items.AddRange(new object[] {
            "2023",
            "2024",
            "2025"});
            this.cmbPeriodoDupont.Location = new System.Drawing.Point(10, 26);
            this.cmbPeriodoDupont.Name = "cmbPeriodoDupont";
            this.cmbPeriodoDupont.Size = new System.Drawing.Size(110, 29);
            this.cmbPeriodoDupont.TabIndex = 1;
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.AutoScroll = true;
            this.pnlToolbar.Controls.Add(this.label1);
            this.pnlToolbar.Controls.Add(this.cmbPeriodoDupont);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(0, 66);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(1000, 58);
            this.pnlToolbar.TabIndex = 1;
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.grpDupont);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 124);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(10, 4, 10, 10);
            this.pnlBody.Size = new System.Drawing.Size(1000, 476);
            this.pnlBody.TabIndex = 0;
            // 
            // dgvDupontCol0
            // 
            this.dgvDupontCol0.HeaderText = "Componente";
            this.dgvDupontCol0.MinimumWidth = 6;
            this.dgvDupontCol0.Name = "dgvDupontCol0";
            this.dgvDupontCol0.ReadOnly = true;
            // 
            // dgvDupontCol1
            // 
            this.dgvDupontCol1.HeaderText = "Valor";
            this.dgvDupontCol1.MinimumWidth = 6;
            this.dgvDupontCol1.Name = "dgvDupontCol1";
            this.dgvDupontCol1.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Interpretacion";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // DupontControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "DupontControl";
            this.Size = new System.Drawing.Size(1000, 600);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDupont)).EndInit();
            this.grpDupont.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDupont;
        private System.Windows.Forms.DataGridViewCellStyle dgvDupontHdrStyle;
        private System.Windows.Forms.DataGridViewCellStyle dgvDupontAltStyle;
        private System.Windows.Forms.GroupBox grpDupont;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPeriodoDupont;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Panel pnlBody;
        private DataGridViewTextBoxColumn dgvDupontCol0;
        private DataGridViewTextBoxColumn dgvDupontCol1;
        private DataGridViewTextBoxColumn Column1;
    }
}
