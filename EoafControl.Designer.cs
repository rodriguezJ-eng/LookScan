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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dgvEoaf = new DataGridView();
            dgvEoafCol0 = new DataGridViewTextBoxColumn();
            dgvEoafCol1 = new DataGridViewTextBoxColumn();
            dgvEoafCol2 = new DataGridViewTextBoxColumn();
            dgvEoafCol3 = new DataGridViewTextBoxColumn();
            dgvEoafCol4 = new DataGridViewTextBoxColumn();
            dgvEoafCol5 = new DataGridViewTextBoxColumn();
            dgvEoafCol6 = new DataGridViewTextBoxColumn();
            grpEoaf = new GroupBox();
            pnlHeader = new Panel();
            lblTitulo = new Label();
            lblDescripcion = new Label();
            label1 = new Label();
            cmbPeriodoBaseEoaf = new ComboBox();
            label2 = new Label();
            cmbPeriodoCompEoaf = new ComboBox();
            btnCalcularEoaf = new Button();
            pnlToolbar = new Panel();
            pnlBody = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvEoaf).BeginInit();
            grpEoaf.SuspendLayout();
            pnlHeader.SuspendLayout();
            pnlToolbar.SuspendLayout();
            pnlBody.SuspendLayout();
            SuspendLayout();
            // 
            // dgvEoaf
            // 
            dgvEoaf.AllowUserToAddRows = false;
            dgvEoaf.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(247, 249, 252);
            dgvEoaf.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvEoaf.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEoaf.BackgroundColor = Color.FromArgb(255, 255, 255);
            dgvEoaf.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(24, 72, 140);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(255, 255, 255);
            dgvEoaf.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvEoaf.ColumnHeadersHeight = 32;
            dgvEoaf.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvEoaf.Columns.AddRange(new DataGridViewColumn[] { dgvEoafCol0, dgvEoafCol1, dgvEoafCol2, dgvEoafCol3, dgvEoafCol4, dgvEoafCol5, dgvEoafCol6 });
            dgvEoaf.Dock = DockStyle.Fill;
            dgvEoaf.EnableHeadersVisualStyles = false;
            dgvEoaf.Location = new Point(8, 28);
            dgvEoaf.Name = "dgvEoaf";
            dgvEoaf.ReadOnly = true;
            dgvEoaf.RowHeadersVisible = false;
            dgvEoaf.RowHeadersWidth = 51;
            dgvEoaf.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEoaf.Size = new Size(964, 422);
            dgvEoaf.TabIndex = 0;
            // 
            // dgvEoafCol0
            // 
            dgvEoafCol0.HeaderText = "Cuenta";
            dgvEoafCol0.MinimumWidth = 6;
            dgvEoafCol0.Name = "dgvEoafCol0";
            dgvEoafCol0.ReadOnly = true;
            // 
            // dgvEoafCol1
            // 
            dgvEoafCol1.HeaderText = "Clasif.";
            dgvEoafCol1.MinimumWidth = 6;
            dgvEoafCol1.Name = "dgvEoafCol1";
            dgvEoafCol1.ReadOnly = true;
            // 
            // dgvEoafCol2
            // 
            dgvEoafCol2.HeaderText = "Año 1";
            dgvEoafCol2.MinimumWidth = 6;
            dgvEoafCol2.Name = "dgvEoafCol2";
            dgvEoafCol2.ReadOnly = true;
            // 
            // dgvEoafCol3
            // 
            dgvEoafCol3.HeaderText = "Año 2";
            dgvEoafCol3.MinimumWidth = 6;
            dgvEoafCol3.Name = "dgvEoafCol3";
            dgvEoafCol3.ReadOnly = true;
            // 
            // dgvEoafCol4
            // 
            dgvEoafCol4.HeaderText = "Cambios";
            dgvEoafCol4.MinimumWidth = 6;
            dgvEoafCol4.Name = "dgvEoafCol4";
            dgvEoafCol4.ReadOnly = true;
            // 
            // dgvEoafCol5
            // 
            dgvEoafCol5.HeaderText = "Origen";
            dgvEoafCol5.MinimumWidth = 6;
            dgvEoafCol5.Name = "dgvEoafCol5";
            dgvEoafCol5.ReadOnly = true;
            // 
            // dgvEoafCol6
            // 
            dgvEoafCol6.HeaderText = "Aplicación";
            dgvEoafCol6.MinimumWidth = 6;
            dgvEoafCol6.Name = "dgvEoafCol6";
            dgvEoafCol6.ReadOnly = true;
            // 
            // grpEoaf
            // 
            grpEoaf.Controls.Add(dgvEoaf);
            grpEoaf.Dock = DockStyle.Fill;
            grpEoaf.Location = new Point(10, 4);
            grpEoaf.Name = "grpEoaf";
            grpEoaf.Padding = new Padding(8, 6, 8, 8);
            grpEoaf.Size = new Size(980, 458);
            grpEoaf.TabIndex = 0;
            grpEoaf.TabStop = false;
            grpEoaf.Text = "Resultado EOAF";
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
            lblTitulo.Size = new Size(83, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "EOAF";
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.ForeColor = Color.FromArgb(105, 105, 105);
            lblDescripcion.Location = new Point(16, 42);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(292, 21);
            lblDescripcion.TabIndex = 1;
            lblDescripcion.Text = "Estado de Origen y Aplicación de Fondos";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.FromArgb(70, 80, 100);
            label1.Location = new Point(10, 3);
            label1.Name = "label1";
            label1.Size = new Size(99, 21);
            label1.TabIndex = 0;
            label1.Text = "Periodo base";
            // 
            // cmbPeriodoBaseEoaf
            // 
            cmbPeriodoBaseEoaf.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPeriodoBaseEoaf.FormattingEnabled = true;
            cmbPeriodoBaseEoaf.Items.AddRange(new object[] { "2023", "2024", "2025" });
            cmbPeriodoBaseEoaf.Location = new Point(10, 27);
            cmbPeriodoBaseEoaf.Name = "cmbPeriodoBaseEoaf";
            cmbPeriodoBaseEoaf.Size = new Size(110, 29);
            cmbPeriodoBaseEoaf.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.FromArgb(70, 80, 100);
            label2.Location = new Point(144, 6);
            label2.Name = "label2";
            label2.Size = new Size(146, 21);
            label2.TabIndex = 2;
            label2.Text = "Periodo comparado";
            // 
            // cmbPeriodoCompEoaf
            // 
            cmbPeriodoCompEoaf.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPeriodoCompEoaf.FormattingEnabled = true;
            cmbPeriodoCompEoaf.Items.AddRange(new object[] { "2023", "2024", "2025" });
            cmbPeriodoCompEoaf.Location = new Point(144, 27);
            cmbPeriodoCompEoaf.Name = "cmbPeriodoCompEoaf";
            cmbPeriodoCompEoaf.Size = new Size(110, 29);
            cmbPeriodoCompEoaf.TabIndex = 3;
            // 
            // btnCalcularEoaf
            // 
            btnCalcularEoaf.BackColor = Color.FromArgb(24, 72, 140);
            btnCalcularEoaf.Cursor = Cursors.Hand;
            btnCalcularEoaf.FlatAppearance.BorderColor = Color.FromArgb(24, 72, 140);
            btnCalcularEoaf.FlatStyle = FlatStyle.Flat;
            btnCalcularEoaf.ForeColor = Color.FromArgb(255, 255, 255);
            btnCalcularEoaf.Location = new Point(306, 24);
            btnCalcularEoaf.Name = "btnCalcularEoaf";
            btnCalcularEoaf.Size = new Size(120, 30);
            btnCalcularEoaf.TabIndex = 4;
            btnCalcularEoaf.Text = "Calcular EOAF";
            btnCalcularEoaf.UseVisualStyleBackColor = false;
            // 
            // pnlToolbar
            // 
            pnlToolbar.AutoScroll = true;
            pnlToolbar.Controls.Add(label1);
            pnlToolbar.Controls.Add(cmbPeriodoBaseEoaf);
            pnlToolbar.Controls.Add(label2);
            pnlToolbar.Controls.Add(cmbPeriodoCompEoaf);
            pnlToolbar.Controls.Add(btnCalcularEoaf);
            pnlToolbar.Dock = DockStyle.Top;
            pnlToolbar.Location = new Point(0, 66);
            pnlToolbar.Name = "pnlToolbar";
            pnlToolbar.Size = new Size(1000, 62);
            pnlToolbar.TabIndex = 1;
            // 
            // pnlBody
            // 
            pnlBody.Controls.Add(grpEoaf);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 128);
            pnlBody.Name = "pnlBody";
            pnlBody.Padding = new Padding(10, 4, 10, 10);
            pnlBody.Size = new Size(1000, 472);
            pnlBody.TabIndex = 0;
            // 
            // EoafControl
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 246, 250);
            Controls.Add(pnlBody);
            Controls.Add(pnlToolbar);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9.5F);
            Name = "EoafControl";
            Size = new Size(1000, 600);
            ((System.ComponentModel.ISupportInitialize)dgvEoaf).EndInit();
            grpEoaf.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlToolbar.ResumeLayout(false);
            pnlToolbar.PerformLayout();
            pnlBody.ResumeLayout(false);
            ResumeLayout(false);
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
