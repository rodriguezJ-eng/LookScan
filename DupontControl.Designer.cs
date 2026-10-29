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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dgvDupont = new DataGridView();
            dgvDupontCol0 = new DataGridViewTextBoxColumn();
            dgvDupontCol1 = new DataGridViewTextBoxColumn();
            grpDupont = new GroupBox();
            pnlHeader = new Panel();
            lblTitulo = new Label();
            lblDescripcion = new Label();
            label1 = new Label();
            cmbPeriodoDupont = new ComboBox();
            pnlToolbar = new Panel();
            pnlBody = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvDupont).BeginInit();
            grpDupont.SuspendLayout();
            pnlHeader.SuspendLayout();
            pnlToolbar.SuspendLayout();
            pnlBody.SuspendLayout();
            SuspendLayout();
            // 
            // dgvDupont
            // 
            dgvDupont.AllowUserToAddRows = false;
            dgvDupont.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(247, 249, 252);
            dgvDupont.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvDupont.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDupont.BackgroundColor = Color.FromArgb(255, 255, 255);
            dgvDupont.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(24, 72, 140);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(255, 255, 255);
            dgvDupont.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvDupont.ColumnHeadersHeight = 32;
            dgvDupont.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvDupont.Columns.AddRange(new DataGridViewColumn[] { dgvDupontCol0, dgvDupontCol1 });
            dgvDupont.Dock = DockStyle.Fill;
            dgvDupont.EnableHeadersVisualStyles = false;
            dgvDupont.Location = new Point(8, 28);
            dgvDupont.Name = "dgvDupont";
            dgvDupont.ReadOnly = true;
            dgvDupont.RowHeadersVisible = false;
            dgvDupont.RowHeadersWidth = 51;
            dgvDupont.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDupont.Size = new Size(964, 426);
            dgvDupont.TabIndex = 0;
            // 
            // dgvDupontCol0
            // 
            dgvDupontCol0.HeaderText = "Componente";
            dgvDupontCol0.MinimumWidth = 6;
            dgvDupontCol0.Name = "dgvDupontCol0";
            dgvDupontCol0.ReadOnly = true;
            // 
            // dgvDupontCol1
            // 
            dgvDupontCol1.HeaderText = "Valor";
            dgvDupontCol1.MinimumWidth = 6;
            dgvDupontCol1.Name = "dgvDupontCol1";
            dgvDupontCol1.ReadOnly = true;
            // 
            // grpDupont
            // 
            grpDupont.Controls.Add(dgvDupont);
            grpDupont.Dock = DockStyle.Fill;
            grpDupont.Location = new Point(10, 4);
            grpDupont.Name = "grpDupont";
            grpDupont.Padding = new Padding(8, 6, 8, 8);
            grpDupont.Size = new Size(980, 462);
            grpDupont.TabIndex = 0;
            grpDupont.TabStop = false;
            grpDupont.Text = "Componentes";
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Controls.Add(lblDescripcion);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1000, 66);
            pnlHeader.TabIndex = 2;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(24, 72, 140);
            lblTitulo.Location = new Point(14, 8);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(327, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Modelo DuPont (3 pasos)";
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.ForeColor = Color.FromArgb(105, 105, 105);
            lblDescripcion.Location = new Point(16, 42);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(482, 21);
            lblDescripcion.TabIndex = 1;
            lblDescripcion.Text = "ROE = Margen neto × Rotación de activos × Multiplicador de capital";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.FromArgb(70, 80, 100);
            label1.Location = new Point(10, 0);
            label1.Name = "label1";
            label1.Size = new Size(63, 21);
            label1.TabIndex = 0;
            label1.Text = "Periodo";
            // 
            // cmbPeriodoDupont
            // 
            cmbPeriodoDupont.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPeriodoDupont.FormattingEnabled = true;
            cmbPeriodoDupont.Items.AddRange(new object[] { "2023", "2024", "2025" });
            cmbPeriodoDupont.Location = new Point(10, 26);
            cmbPeriodoDupont.Name = "cmbPeriodoDupont";
            cmbPeriodoDupont.Size = new Size(110, 29);
            cmbPeriodoDupont.TabIndex = 1;
            // 
            // pnlToolbar
            // 
            pnlToolbar.AutoScroll = true;
            pnlToolbar.Controls.Add(label1);
            pnlToolbar.Controls.Add(cmbPeriodoDupont);
            pnlToolbar.Dock = DockStyle.Top;
            pnlToolbar.Location = new Point(0, 66);
            pnlToolbar.Name = "pnlToolbar";
            pnlToolbar.Size = new Size(1000, 58);
            pnlToolbar.TabIndex = 1;
            // 
            // pnlBody
            // 
            pnlBody.Controls.Add(grpDupont);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 124);
            pnlBody.Name = "pnlBody";
            pnlBody.Padding = new Padding(10, 4, 10, 10);
            pnlBody.Size = new Size(1000, 476);
            pnlBody.TabIndex = 0;
            // 
            // DupontControl
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 246, 250);
            Controls.Add(pnlBody);
            Controls.Add(pnlToolbar);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9.5F);
            Name = "DupontControl";
            Size = new Size(1000, 600);
            ((System.ComponentModel.ISupportInitialize)dgvDupont).EndInit();
            grpDupont.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlToolbar.ResumeLayout(false);
            pnlToolbar.PerformLayout();
            pnlBody.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDupont;
        private System.Windows.Forms.DataGridViewCellStyle dgvDupontHdrStyle;
        private System.Windows.Forms.DataGridViewCellStyle dgvDupontAltStyle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDupontCol0;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDupontCol1;
        private System.Windows.Forms.GroupBox grpDupont;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPeriodoDupont;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Panel pnlBody;
    }
}
