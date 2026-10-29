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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dgvEfe = new DataGridView();
            dgvEfeCol0 = new DataGridViewTextBoxColumn();
            dgvEfeCol1 = new DataGridViewTextBoxColumn();
            grpEfe = new GroupBox();
            pnlHeader = new Panel();
            lblTitulo = new Label();
            lblDescripcion = new Label();
            label1 = new Label();
            cmbPeriodoBaseEfe = new ComboBox();
            label2 = new Label();
            cmbPeriodoCompEfe = new ComboBox();
            rbMetodo1 = new RadioButton();
            rbMetodo2 = new RadioButton();
            rbMetodo = new Panel();
            label3 = new Label();
            btnCalcularEfe = new Button();
            pnlToolbar = new Panel();
            pnlBody = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvEfe).BeginInit();
            grpEfe.SuspendLayout();
            pnlHeader.SuspendLayout();
            rbMetodo.SuspendLayout();
            pnlToolbar.SuspendLayout();
            pnlBody.SuspendLayout();
            SuspendLayout();
            // 
            // dgvEfe
            // 
            dgvEfe.AllowUserToAddRows = false;
            dgvEfe.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(247, 249, 252);
            dgvEfe.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvEfe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEfe.BackgroundColor = Color.FromArgb(255, 255, 255);
            dgvEfe.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(24, 72, 140);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(255, 255, 255);
            dgvEfe.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvEfe.ColumnHeadersHeight = 32;
            dgvEfe.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvEfe.Columns.AddRange(new DataGridViewColumn[] { dgvEfeCol0, dgvEfeCol1 });
            dgvEfe.Dock = DockStyle.Fill;
            dgvEfe.EnableHeadersVisualStyles = false;
            dgvEfe.Location = new Point(8, 28);
            dgvEfe.Name = "dgvEfe";
            dgvEfe.ReadOnly = true;
            dgvEfe.RowHeadersVisible = false;
            dgvEfe.RowHeadersWidth = 51;
            dgvEfe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEfe.Size = new Size(964, 410);
            dgvEfe.TabIndex = 0;
            // 
            // dgvEfeCol0
            // 
            dgvEfeCol0.HeaderText = "Concepto";
            dgvEfeCol0.MinimumWidth = 6;
            dgvEfeCol0.Name = "dgvEfeCol0";
            dgvEfeCol0.ReadOnly = true;
            // 
            // dgvEfeCol1
            // 
            dgvEfeCol1.HeaderText = "Monto";
            dgvEfeCol1.MinimumWidth = 6;
            dgvEfeCol1.Name = "dgvEfeCol1";
            dgvEfeCol1.ReadOnly = true;
            // 
            // grpEfe
            // 
            grpEfe.Controls.Add(dgvEfe);
            grpEfe.Dock = DockStyle.Fill;
            grpEfe.Location = new Point(10, 4);
            grpEfe.Name = "grpEfe";
            grpEfe.Padding = new Padding(8, 6, 8, 8);
            grpEfe.Size = new Size(980, 446);
            grpEfe.TabIndex = 0;
            grpEfe.TabStop = false;
            grpEfe.Text = "Resultado";
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
            lblTitulo.Size = new Size(344, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Estado de Flujo de Efectivo";
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.ForeColor = Color.FromArgb(105, 105, 105);
            lblDescripcion.Location = new Point(16, 42);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(194, 21);
            lblDescripcion.TabIndex = 1;
            lblDescripcion.Text = "Método indirecto o directo";
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
            // cmbPeriodoBaseEfe
            // 
            cmbPeriodoBaseEfe.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPeriodoBaseEfe.FormattingEnabled = true;
            cmbPeriodoBaseEfe.Items.AddRange(new object[] { "2023", "2024", "2025" });
            cmbPeriodoBaseEfe.Location = new Point(10, 26);
            cmbPeriodoBaseEfe.Name = "cmbPeriodoBaseEfe";
            cmbPeriodoBaseEfe.Size = new Size(110, 29);
            cmbPeriodoBaseEfe.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.FromArgb(70, 80, 100);
            label2.Location = new Point(132, 3);
            label2.Name = "label2";
            label2.Size = new Size(146, 21);
            label2.TabIndex = 2;
            label2.Text = "Periodo comparado";
            // 
            // cmbPeriodoCompEfe
            // 
            cmbPeriodoCompEfe.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPeriodoCompEfe.FormattingEnabled = true;
            cmbPeriodoCompEfe.Items.AddRange(new object[] { "2023", "2024", "2025" });
            cmbPeriodoCompEfe.Location = new Point(132, 26);
            cmbPeriodoCompEfe.Name = "cmbPeriodoCompEfe";
            cmbPeriodoCompEfe.Size = new Size(110, 29);
            cmbPeriodoCompEfe.TabIndex = 3;
            // 
            // rbMetodo1
            // 
            rbMetodo1.AutoSize = true;
            rbMetodo1.Checked = true;
            rbMetodo1.Location = new Point(4, 4);
            rbMetodo1.Name = "rbMetodo1";
            rbMetodo1.Size = new Size(92, 25);
            rbMetodo1.TabIndex = 0;
            rbMetodo1.TabStop = true;
            rbMetodo1.Text = "Indirecto";
            // 
            // rbMetodo2
            // 
            rbMetodo2.AutoSize = true;
            rbMetodo2.Location = new Point(110, 4);
            rbMetodo2.Name = "rbMetodo2";
            rbMetodo2.Size = new Size(81, 25);
            rbMetodo2.TabIndex = 1;
            rbMetodo2.TabStop = true;
            rbMetodo2.Text = "Directo";
            // 
            // rbMetodo
            // 
            rbMetodo.Controls.Add(rbMetodo1);
            rbMetodo.Controls.Add(rbMetodo2);
            rbMetodo.Location = new Point(284, 25);
            rbMetodo.Name = "rbMetodo";
            rbMetodo.Size = new Size(200, 28);
            rbMetodo.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.FromArgb(70, 80, 100);
            label3.Location = new Point(284, 3);
            label3.Name = "label3";
            label3.Size = new Size(64, 21);
            label3.TabIndex = 4;
            label3.Text = "Método";
            // 
            // btnCalcularEfe
            // 
            btnCalcularEfe.BackColor = Color.FromArgb(24, 72, 140);
            btnCalcularEfe.Cursor = Cursors.Hand;
            btnCalcularEfe.FlatAppearance.BorderColor = Color.FromArgb(24, 72, 140);
            btnCalcularEfe.FlatStyle = FlatStyle.Flat;
            btnCalcularEfe.ForeColor = Color.FromArgb(255, 255, 255);
            btnCalcularEfe.Location = new Point(518, 23);
            btnCalcularEfe.Name = "btnCalcularEfe";
            btnCalcularEfe.Size = new Size(120, 30);
            btnCalcularEfe.TabIndex = 6;
            btnCalcularEfe.Text = "Calcular EFE";
            btnCalcularEfe.UseVisualStyleBackColor = false;
            // 
            // pnlToolbar
            // 
            pnlToolbar.AutoScroll = true;
            pnlToolbar.Controls.Add(label1);
            pnlToolbar.Controls.Add(cmbPeriodoBaseEfe);
            pnlToolbar.Controls.Add(label2);
            pnlToolbar.Controls.Add(cmbPeriodoCompEfe);
            pnlToolbar.Controls.Add(label3);
            pnlToolbar.Controls.Add(rbMetodo);
            pnlToolbar.Controls.Add(btnCalcularEfe);
            pnlToolbar.Dock = DockStyle.Top;
            pnlToolbar.Location = new Point(0, 66);
            pnlToolbar.Name = "pnlToolbar";
            pnlToolbar.Size = new Size(1000, 74);
            pnlToolbar.TabIndex = 1;
            // 
            // pnlBody
            // 
            pnlBody.Controls.Add(grpEfe);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 140);
            pnlBody.Name = "pnlBody";
            pnlBody.Padding = new Padding(10, 4, 10, 10);
            pnlBody.Size = new Size(1000, 460);
            pnlBody.TabIndex = 0;
            // 
            // EfeControl
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 246, 250);
            Controls.Add(pnlBody);
            Controls.Add(pnlToolbar);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9.5F);
            Name = "EfeControl";
            Size = new Size(1000, 600);
            ((System.ComponentModel.ISupportInitialize)dgvEfe).EndInit();
            grpEfe.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            rbMetodo.ResumeLayout(false);
            rbMetodo.PerformLayout();
            pnlToolbar.ResumeLayout(false);
            pnlToolbar.PerformLayout();
            pnlBody.ResumeLayout(false);
            ResumeLayout(false);
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
