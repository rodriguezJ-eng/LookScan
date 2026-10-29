using System;
using System.Drawing;
using System.Windows.Forms;

namespace LookScan
{
    partial class RazonesControl
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            dgvRazones = new DataGridView();
            dgvRazonesCol0 = new DataGridViewTextBoxColumn();
            dgvRazonesCol1 = new DataGridViewTextBoxColumn();
            dgvRazonesCol2 = new DataGridViewTextBoxColumn();
            dgvRazonesCol3 = new DataGridViewTextBoxColumn();
            grpRazones = new GroupBox();
            dgvCnt = new DataGridView();
            dgvCntCol0 = new DataGridViewTextBoxColumn();
            dgvCntCol1 = new DataGridViewTextBoxColumn();
            grpCnt = new GroupBox();
            dgvCno = new DataGridView();
            dgvCnoCol0 = new DataGridViewTextBoxColumn();
            dgvCnoCol1 = new DataGridViewTextBoxColumn();
            grpCno = new GroupBox();
            tlpCnt = new TableLayoutPanel();
            tabRazones = new TabControl();
            tabRazonesPage1 = new TabPage();
            tabRazonesPage2 = new TabPage();
            pnlHeader = new Panel();
            lblTitulo = new Label();
            lblDescripcion = new Label();
            label1 = new Label();
            cmbPeriodoRazones = new ComboBox();
            label2 = new Label();
            cmbGrupoRazones = new ComboBox();
            pnlToolbar = new Panel();
            pnlBody = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvRazones).BeginInit();
            grpRazones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCnt).BeginInit();
            grpCnt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCno).BeginInit();
            grpCno.SuspendLayout();
            tlpCnt.SuspendLayout();
            tabRazones.SuspendLayout();
            tabRazonesPage1.SuspendLayout();
            tabRazonesPage2.SuspendLayout();
            pnlHeader.SuspendLayout();
            pnlToolbar.SuspendLayout();
            pnlBody.SuspendLayout();
            SuspendLayout();
            // 
            // dgvRazones
            // 
            dgvRazones.AllowUserToAddRows = false;
            dgvRazones.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(247, 249, 252);
            dgvRazones.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvRazones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRazones.BackgroundColor = Color.FromArgb(255, 255, 255);
            dgvRazones.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(24, 72, 140);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(255, 255, 255);
            dgvRazones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvRazones.ColumnHeadersHeight = 32;
            dgvRazones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvRazones.Columns.AddRange(new DataGridViewColumn[] { dgvRazonesCol0, dgvRazonesCol1, dgvRazonesCol2, dgvRazonesCol3 });
            dgvRazones.Dock = DockStyle.Fill;
            dgvRazones.EnableHeadersVisualStyles = false;
            dgvRazones.Location = new Point(8, 28);
            dgvRazones.Name = "dgvRazones";
            dgvRazones.ReadOnly = true;
            dgvRazones.RowHeadersVisible = false;
            dgvRazones.RowHeadersWidth = 51;
            dgvRazones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRazones.Size = new Size(956, 388);
            dgvRazones.TabIndex = 0;
            // 
            // dgvRazonesCol0
            // 
            dgvRazonesCol0.HeaderText = "Nombre de la razón";
            dgvRazonesCol0.MinimumWidth = 6;
            dgvRazonesCol0.Name = "dgvRazonesCol0";
            dgvRazonesCol0.ReadOnly = true;
            // 
            // dgvRazonesCol1
            // 
            dgvRazonesCol1.HeaderText = "Grupo";
            dgvRazonesCol1.MinimumWidth = 6;
            dgvRazonesCol1.Name = "dgvRazonesCol1";
            dgvRazonesCol1.ReadOnly = true;
            // 
            // dgvRazonesCol2
            // 
            dgvRazonesCol2.HeaderText = "Valor";
            dgvRazonesCol2.MinimumWidth = 6;
            dgvRazonesCol2.Name = "dgvRazonesCol2";
            dgvRazonesCol2.ReadOnly = true;
            // 
            // dgvRazonesCol3
            // 
            dgvRazonesCol3.HeaderText = "Interpretación";
            dgvRazonesCol3.MinimumWidth = 6;
            dgvRazonesCol3.Name = "dgvRazonesCol3";
            dgvRazonesCol3.ReadOnly = true;
            // 
            // grpRazones
            // 
            grpRazones.Controls.Add(dgvRazones);
            grpRazones.Dock = DockStyle.Fill;
            grpRazones.Location = new Point(0, 0);
            grpRazones.Name = "grpRazones";
            grpRazones.Padding = new Padding(8, 6, 8, 8);
            grpRazones.Size = new Size(972, 424);
            grpRazones.TabIndex = 0;
            grpRazones.TabStop = false;
            grpRazones.Text = "Razones";
            // 
            // dgvCnt
            // 
            dgvCnt.AllowUserToAddRows = false;
            dgvCnt.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(247, 249, 252);
            dgvCnt.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvCnt.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCnt.BackgroundColor = Color.FromArgb(255, 255, 255);
            dgvCnt.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(24, 72, 140);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(255, 255, 255);
            dgvCnt.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvCnt.ColumnHeadersHeight = 32;
            dgvCnt.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvCnt.Columns.AddRange(new DataGridViewColumn[] { dgvCntCol0, dgvCntCol1 });
            dgvCnt.Dock = DockStyle.Fill;
            dgvCnt.EnableHeadersVisualStyles = false;
            dgvCnt.Location = new Point(8, 28);
            dgvCnt.Name = "dgvCnt";
            dgvCnt.ReadOnly = true;
            dgvCnt.RowHeadersVisible = false;
            dgvCnt.RowHeadersWidth = 51;
            dgvCnt.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCnt.Size = new Size(464, 382);
            dgvCnt.TabIndex = 0;
            // 
            // dgvCntCol0
            // 
            dgvCntCol0.HeaderText = "Concepto";
            dgvCntCol0.MinimumWidth = 6;
            dgvCntCol0.Name = "dgvCntCol0";
            dgvCntCol0.ReadOnly = true;
            // 
            // dgvCntCol1
            // 
            dgvCntCol1.HeaderText = "Valor";
            dgvCntCol1.MinimumWidth = 6;
            dgvCntCol1.Name = "dgvCntCol1";
            dgvCntCol1.ReadOnly = true;
            // 
            // grpCnt
            // 
            grpCnt.Controls.Add(dgvCnt);
            grpCnt.Dock = DockStyle.Fill;
            grpCnt.Location = new Point(3, 3);
            grpCnt.Name = "grpCnt";
            grpCnt.Padding = new Padding(8, 6, 8, 8);
            grpCnt.Size = new Size(480, 418);
            grpCnt.TabIndex = 0;
            grpCnt.TabStop = false;
            grpCnt.Text = "Capital Neto de Trabajo (CNT)";
            // 
            // dgvCno
            // 
            dgvCno.AllowUserToAddRows = false;
            dgvCno.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(247, 249, 252);
            dgvCno.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            dgvCno.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCno.BackgroundColor = Color.FromArgb(255, 255, 255);
            dgvCno.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(24, 72, 140);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(255, 255, 255);
            dgvCno.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dgvCno.ColumnHeadersHeight = 32;
            dgvCno.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvCno.Columns.AddRange(new DataGridViewColumn[] { dgvCnoCol0, dgvCnoCol1 });
            dgvCno.Dock = DockStyle.Fill;
            dgvCno.EnableHeadersVisualStyles = false;
            dgvCno.Location = new Point(8, 28);
            dgvCno.Name = "dgvCno";
            dgvCno.ReadOnly = true;
            dgvCno.RowHeadersVisible = false;
            dgvCno.RowHeadersWidth = 51;
            dgvCno.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCno.Size = new Size(464, 382);
            dgvCno.TabIndex = 0;
            // 
            // dgvCnoCol0
            // 
            dgvCnoCol0.HeaderText = "Concepto";
            dgvCnoCol0.MinimumWidth = 6;
            dgvCnoCol0.Name = "dgvCnoCol0";
            dgvCnoCol0.ReadOnly = true;
            // 
            // dgvCnoCol1
            // 
            dgvCnoCol1.HeaderText = "Valor";
            dgvCnoCol1.MinimumWidth = 6;
            dgvCnoCol1.Name = "dgvCnoCol1";
            dgvCnoCol1.ReadOnly = true;
            // 
            // grpCno
            // 
            grpCno.Controls.Add(dgvCno);
            grpCno.Dock = DockStyle.Fill;
            grpCno.Location = new Point(489, 3);
            grpCno.Name = "grpCno";
            grpCno.Padding = new Padding(8, 6, 8, 8);
            grpCno.Size = new Size(480, 418);
            grpCno.TabIndex = 1;
            grpCno.TabStop = false;
            grpCno.Text = "Capital Neto de Trabajo Operativo (CNO)";
            // 
            // tlpCnt
            // 
            tlpCnt.ColumnCount = 2;
            tlpCnt.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpCnt.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpCnt.Controls.Add(grpCnt, 0, 0);
            tlpCnt.Controls.Add(grpCno, 1, 0);
            tlpCnt.Dock = DockStyle.Fill;
            tlpCnt.Location = new Point(0, 0);
            tlpCnt.Name = "tlpCnt";
            tlpCnt.RowCount = 1;
            tlpCnt.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpCnt.Size = new Size(972, 424);
            tlpCnt.TabIndex = 0;
            // 
            // tabRazones
            // 
            tabRazones.Controls.Add(tabRazonesPage1);
            tabRazones.Controls.Add(tabRazonesPage2);
            tabRazones.Dock = DockStyle.Fill;
            tabRazones.Location = new Point(10, 4);
            tabRazones.Name = "tabRazones";
            tabRazones.Padding = new Point(12, 5);
            tabRazones.SelectedIndex = 0;
            tabRazones.Size = new Size(980, 462);
            tabRazones.TabIndex = 0;
            // 
            // tabRazonesPage1
            // 
            tabRazonesPage1.Controls.Add(grpRazones);
            tabRazonesPage1.Location = new Point(4, 34);
            tabRazonesPage1.Name = "tabRazonesPage1";
            tabRazonesPage1.Size = new Size(972, 424);
            tabRazonesPage1.TabIndex = 0;
            tabRazonesPage1.Text = "Razones financieras";
            tabRazonesPage1.UseVisualStyleBackColor = true;
            // 
            // tabRazonesPage2
            // 
            tabRazonesPage2.Controls.Add(tlpCnt);
            tabRazonesPage2.Location = new Point(4, 34);
            tabRazonesPage2.Name = "tabRazonesPage2";
            tabRazonesPage2.Size = new Size(972, 424);
            tabRazonesPage2.TabIndex = 1;
            tabRazonesPage2.Text = "CNT y CNO";
            tabRazonesPage2.UseVisualStyleBackColor = true;
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
            lblTitulo.Size = new Size(258, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Razones financieras";
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.ForeColor = Color.FromArgb(105, 105, 105);
            lblDescripcion.Location = new Point(16, 42);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(443, 21);
            lblDescripcion.TabIndex = 1;
            lblDescripcion.Text = "Liquidez, actividad, endeudamiento y rentabilidad · CNT y CNO";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.FromArgb(70, 80, 100);
            label1.Location = new Point(10, 6);
            label1.Name = "label1";
            label1.Size = new Size(63, 21);
            label1.TabIndex = 0;
            label1.Text = "Periodo";
            // 
            // cmbPeriodoRazones
            // 
            cmbPeriodoRazones.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPeriodoRazones.FormattingEnabled = true;
            cmbPeriodoRazones.Items.AddRange(new object[] { "2023", "2024", "2025" });
            cmbPeriodoRazones.Location = new Point(10, 26);
            cmbPeriodoRazones.Name = "cmbPeriodoRazones";
            cmbPeriodoRazones.Size = new Size(110, 29);
            cmbPeriodoRazones.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.FromArgb(70, 80, 100);
            label2.Location = new Point(132, 6);
            label2.Name = "label2";
            label2.Size = new Size(54, 21);
            label2.TabIndex = 2;
            label2.Text = "Grupo";
            // 
            // cmbGrupoRazones
            // 
            cmbGrupoRazones.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGrupoRazones.FormattingEnabled = true;
            cmbGrupoRazones.Items.AddRange(new object[] { "Todas", "Liquidez", "Actividad", "Endeudamiento", "Rentabilidad", "Mercado" });
            cmbGrupoRazones.Location = new Point(132, 26);
            cmbGrupoRazones.Name = "cmbGrupoRazones";
            cmbGrupoRazones.Size = new Size(170, 29);
            cmbGrupoRazones.TabIndex = 3;
            // 
            // pnlToolbar
            // 
            pnlToolbar.AutoScroll = true;
            pnlToolbar.Controls.Add(label1);
            pnlToolbar.Controls.Add(cmbPeriodoRazones);
            pnlToolbar.Controls.Add(label2);
            pnlToolbar.Controls.Add(cmbGrupoRazones);
            pnlToolbar.Dock = DockStyle.Top;
            pnlToolbar.Location = new Point(0, 66);
            pnlToolbar.Name = "pnlToolbar";
            pnlToolbar.Size = new Size(1000, 58);
            pnlToolbar.TabIndex = 1;
            // 
            // pnlBody
            // 
            pnlBody.Controls.Add(tabRazones);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 124);
            pnlBody.Name = "pnlBody";
            pnlBody.Padding = new Padding(10, 4, 10, 10);
            pnlBody.Size = new Size(1000, 476);
            pnlBody.TabIndex = 0;
            // 
            // RazonesControl
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 246, 250);
            Controls.Add(pnlBody);
            Controls.Add(pnlToolbar);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9.5F);
            Name = "RazonesControl";
            Size = new Size(1000, 600);
            ((System.ComponentModel.ISupportInitialize)dgvRazones).EndInit();
            grpRazones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCnt).EndInit();
            grpCnt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCno).EndInit();
            grpCno.ResumeLayout(false);
            tlpCnt.ResumeLayout(false);
            tabRazones.ResumeLayout(false);
            tabRazonesPage1.ResumeLayout(false);
            tabRazonesPage2.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlToolbar.ResumeLayout(false);
            pnlToolbar.PerformLayout();
            pnlBody.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRazones;
        private System.Windows.Forms.DataGridViewCellStyle dgvRazonesHdrStyle;
        private System.Windows.Forms.DataGridViewCellStyle dgvRazonesAltStyle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvRazonesCol0;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvRazonesCol1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvRazonesCol2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvRazonesCol3;
        private System.Windows.Forms.GroupBox grpRazones;
        private System.Windows.Forms.DataGridView dgvCnt;
        private System.Windows.Forms.DataGridViewCellStyle dgvCntHdrStyle;
        private System.Windows.Forms.DataGridViewCellStyle dgvCntAltStyle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCntCol0;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCntCol1;
        private System.Windows.Forms.GroupBox grpCnt;
        private System.Windows.Forms.DataGridView dgvCno;
        private System.Windows.Forms.DataGridViewCellStyle dgvCnoHdrStyle;
        private System.Windows.Forms.DataGridViewCellStyle dgvCnoAltStyle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCnoCol0;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCnoCol1;
        private System.Windows.Forms.GroupBox grpCno;
        private System.Windows.Forms.TableLayoutPanel tlpCnt;
        private System.Windows.Forms.TabControl tabRazones;
        private System.Windows.Forms.TabPage tabRazonesPage1;
        private System.Windows.Forms.TabPage tabRazonesPage2;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPeriodoRazones;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbGrupoRazones;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Panel pnlBody;
    }
}
