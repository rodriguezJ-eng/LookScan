using System;
using System.Drawing;
using System.Windows.Forms;

namespace LookScan
{
    partial class IaControl
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
            txtResumenIa = new TextBox();
            grpResumenIa = new GroupBox();
            txtInterpretacion = new TextBox();
            grpInterpretacion = new GroupBox();
            tlpIa = new TableLayoutPanel();
            pnlHeader = new Panel();
            lblTitulo = new Label();
            lblDescripcion = new Label();
            btnPrepararResumen = new Button();
            btnGenerarInterpretacion = new Button();
            pnlToolbar = new Panel();
            pnlBody = new Panel();
            grpResumenIa.SuspendLayout();
            grpInterpretacion.SuspendLayout();
            tlpIa.SuspendLayout();
            pnlHeader.SuspendLayout();
            pnlToolbar.SuspendLayout();
            pnlBody.SuspendLayout();
            SuspendLayout();
            // 
            // txtResumenIa
            // 
            txtResumenIa.BackColor = Color.FromArgb(255, 255, 255);
            txtResumenIa.Dock = DockStyle.Fill;
            txtResumenIa.Location = new Point(8, 28);
            txtResumenIa.Multiline = true;
            txtResumenIa.Name = "txtResumenIa";
            txtResumenIa.ReadOnly = true;
            txtResumenIa.ScrollBars = ScrollBars.Vertical;
            txtResumenIa.Size = new Size(468, 416);
            txtResumenIa.TabIndex = 0;
            // 
            // grpResumenIa
            // 
            grpResumenIa.Controls.Add(txtResumenIa);
            grpResumenIa.Dock = DockStyle.Fill;
            grpResumenIa.Location = new Point(3, 3);
            grpResumenIa.Name = "grpResumenIa";
            grpResumenIa.Padding = new Padding(8, 6, 8, 8);
            grpResumenIa.Size = new Size(484, 452);
            grpResumenIa.TabIndex = 0;
            grpResumenIa.TabStop = false;
            grpResumenIa.Text = "Resumen preparado";
            // 
            // txtInterpretacion
            // 
            txtInterpretacion.BackColor = Color.FromArgb(255, 255, 255);
            txtInterpretacion.Dock = DockStyle.Fill;
            txtInterpretacion.Location = new Point(8, 28);
            txtInterpretacion.Multiline = true;
            txtInterpretacion.Name = "txtInterpretacion";
            txtInterpretacion.ReadOnly = true;
            txtInterpretacion.ScrollBars = ScrollBars.Vertical;
            txtInterpretacion.Size = new Size(468, 416);
            txtInterpretacion.TabIndex = 0;
            // 
            // grpInterpretacion
            // 
            grpInterpretacion.Controls.Add(txtInterpretacion);
            grpInterpretacion.Dock = DockStyle.Fill;
            grpInterpretacion.Location = new Point(493, 3);
            grpInterpretacion.Name = "grpInterpretacion";
            grpInterpretacion.Padding = new Padding(8, 6, 8, 8);
            grpInterpretacion.Size = new Size(484, 452);
            grpInterpretacion.TabIndex = 1;
            grpInterpretacion.TabStop = false;
            grpInterpretacion.Text = "Interpretación";
            // 
            // tlpIa
            // 
            tlpIa.ColumnCount = 2;
            tlpIa.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpIa.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpIa.Controls.Add(grpResumenIa, 0, 0);
            tlpIa.Controls.Add(grpInterpretacion, 1, 0);
            tlpIa.Dock = DockStyle.Fill;
            tlpIa.Location = new Point(10, 4);
            tlpIa.Name = "tlpIa";
            tlpIa.RowCount = 1;
            tlpIa.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpIa.Size = new Size(980, 458);
            tlpIa.TabIndex = 0;
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
            lblTitulo.Size = new Size(251, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "IA local (heurística)";
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.ForeColor = Color.FromArgb(105, 105, 105);
            lblDescripcion.Location = new Point(16, 42);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(339, 21);
            lblDescripcion.TabIndex = 1;
            lblDescripcion.Text = "Interpretación automática sin servicios externos";
            // 
            // btnPrepararResumen
            // 
            btnPrepararResumen.BackColor = Color.FromArgb(255, 255, 255);
            btnPrepararResumen.Cursor = Cursors.Hand;
            btnPrepararResumen.FlatAppearance.BorderColor = Color.FromArgb(24, 72, 140);
            btnPrepararResumen.FlatStyle = FlatStyle.Flat;
            btnPrepararResumen.ForeColor = Color.FromArgb(24, 72, 140);
            btnPrepararResumen.Location = new Point(10, 24);
            btnPrepararResumen.Name = "btnPrepararResumen";
            btnPrepararResumen.Size = new Size(150, 30);
            btnPrepararResumen.TabIndex = 0;
            btnPrepararResumen.Text = "Preparar resumen";
            btnPrepararResumen.UseVisualStyleBackColor = false;
            // 
            // btnGenerarInterpretacion
            // 
            btnGenerarInterpretacion.BackColor = Color.FromArgb(24, 72, 140);
            btnGenerarInterpretacion.Cursor = Cursors.Hand;
            btnGenerarInterpretacion.FlatAppearance.BorderColor = Color.FromArgb(24, 72, 140);
            btnGenerarInterpretacion.FlatStyle = FlatStyle.Flat;
            btnGenerarInterpretacion.ForeColor = Color.FromArgb(255, 255, 255);
            btnGenerarInterpretacion.Location = new Point(172, 24);
            btnGenerarInterpretacion.Name = "btnGenerarInterpretacion";
            btnGenerarInterpretacion.Size = new Size(210, 30);
            btnGenerarInterpretacion.TabIndex = 1;
            btnGenerarInterpretacion.Text = "Generar interpretación (local)";
            btnGenerarInterpretacion.UseVisualStyleBackColor = false;
            // 
            // pnlToolbar
            // 
            pnlToolbar.AutoScroll = true;
            pnlToolbar.Controls.Add(btnPrepararResumen);
            pnlToolbar.Controls.Add(btnGenerarInterpretacion);
            pnlToolbar.Dock = DockStyle.Top;
            pnlToolbar.Location = new Point(0, 66);
            pnlToolbar.Name = "pnlToolbar";
            pnlToolbar.Size = new Size(1000, 62);
            pnlToolbar.TabIndex = 1;
            // 
            // pnlBody
            // 
            pnlBody.Controls.Add(tlpIa);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 128);
            pnlBody.Name = "pnlBody";
            pnlBody.Padding = new Padding(10, 4, 10, 10);
            pnlBody.Size = new Size(1000, 472);
            pnlBody.TabIndex = 0;
            pnlBody.Paint += pnlBody_Paint;
            // 
            // IaControl
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 246, 250);
            Controls.Add(pnlBody);
            Controls.Add(pnlToolbar);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9.5F);
            Name = "IaControl";
            Size = new Size(1000, 600);
            grpResumenIa.ResumeLayout(false);
            grpResumenIa.PerformLayout();
            grpInterpretacion.ResumeLayout(false);
            grpInterpretacion.PerformLayout();
            tlpIa.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlToolbar.ResumeLayout(false);
            pnlBody.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TextBox txtResumenIa;
        private System.Windows.Forms.GroupBox grpResumenIa;
        private System.Windows.Forms.TextBox txtInterpretacion;
        private System.Windows.Forms.GroupBox grpInterpretacion;
        private System.Windows.Forms.TableLayoutPanel tlpIa;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Button btnPrepararResumen;
        private System.Windows.Forms.Button btnGenerarInterpretacion;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Panel pnlBody;
    }
}
