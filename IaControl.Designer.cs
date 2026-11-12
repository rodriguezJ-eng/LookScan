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
            this.txtResumenIa = new System.Windows.Forms.RichTextBox();
            this.grpResumenIa = new System.Windows.Forms.GroupBox();
            this.txtInterpretacion = new System.Windows.Forms.RichTextBox();
            this.grpInterpretacion = new System.Windows.Forms.GroupBox();
            this.tlpIa = new System.Windows.Forms.TableLayoutPanel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.btnPrepararResumen = new System.Windows.Forms.Button();
            this.btnGenerarInterpretacion = new System.Windows.Forms.Button();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.grpResumenIa.SuspendLayout();
            this.grpInterpretacion.SuspendLayout();
            this.tlpIa.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtResumenIa
            // 
            this.txtResumenIa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtResumenIa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResumenIa.Location = new System.Drawing.Point(8, 28);
            this.txtResumenIa.Name = "txtResumenIa";
            this.txtResumenIa.ReadOnly = true;
            this.txtResumenIa.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtResumenIa.Size = new System.Drawing.Size(468, 416);
            this.txtResumenIa.TabIndex = 0;
            this.txtResumenIa.Text = "";
            // 
            // grpResumenIa
            // 
            this.grpResumenIa.Controls.Add(this.txtResumenIa);
            this.grpResumenIa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpResumenIa.Location = new System.Drawing.Point(3, 3);
            this.grpResumenIa.Name = "grpResumenIa";
            this.grpResumenIa.Padding = new System.Windows.Forms.Padding(8, 6, 8, 8);
            this.grpResumenIa.Size = new System.Drawing.Size(484, 452);
            this.grpResumenIa.TabIndex = 0;
            this.grpResumenIa.TabStop = false;
            this.grpResumenIa.Text = "Resumen preparado";
            // 
            // txtInterpretacion
            // 
            this.txtInterpretacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtInterpretacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInterpretacion.Location = new System.Drawing.Point(8, 28);
            this.txtInterpretacion.Name = "txtInterpretacion";
            this.txtInterpretacion.ReadOnly = true;
            this.txtInterpretacion.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtInterpretacion.Size = new System.Drawing.Size(468, 416);
            this.txtInterpretacion.TabIndex = 0;
            this.txtInterpretacion.Text = "";
            // 
            // grpInterpretacion
            // 
            this.grpInterpretacion.Controls.Add(this.txtInterpretacion);
            this.grpInterpretacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpInterpretacion.Location = new System.Drawing.Point(493, 3);
            this.grpInterpretacion.Name = "grpInterpretacion";
            this.grpInterpretacion.Padding = new System.Windows.Forms.Padding(8, 6, 8, 8);
            this.grpInterpretacion.Size = new System.Drawing.Size(484, 452);
            this.grpInterpretacion.TabIndex = 1;
            this.grpInterpretacion.TabStop = false;
            this.grpInterpretacion.Text = "Interpretación";
            // 
            // tlpIa
            // 
            this.tlpIa.ColumnCount = 2;
            this.tlpIa.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpIa.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpIa.Controls.Add(this.grpResumenIa, 0, 0);
            this.tlpIa.Controls.Add(this.grpInterpretacion, 1, 0);
            this.tlpIa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpIa.Location = new System.Drawing.Point(10, 4);
            this.tlpIa.Name = "tlpIa";
            this.tlpIa.RowCount = 1;
            this.tlpIa.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpIa.Size = new System.Drawing.Size(980, 458);
            this.tlpIa.TabIndex = 0;
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
            this.lblTitulo.Size = new System.Drawing.Size(203, 37);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Intérprete local";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.lblDescripcion.Location = new System.Drawing.Point(16, 42);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(147, 21);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.Text = "Interpretación Local";
            // 
            // btnPrepararResumen
            // 
            this.btnPrepararResumen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnPrepararResumen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrepararResumen.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(72)))), ((int)(((byte)(140)))));
            this.btnPrepararResumen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrepararResumen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(72)))), ((int)(((byte)(140)))));
            this.btnPrepararResumen.Location = new System.Drawing.Point(10, 24);
            this.btnPrepararResumen.Name = "btnPrepararResumen";
            this.btnPrepararResumen.Size = new System.Drawing.Size(150, 30);
            this.btnPrepararResumen.TabIndex = 0;
            this.btnPrepararResumen.Text = "Preparar resumen";
            this.btnPrepararResumen.UseVisualStyleBackColor = false;
            // 
            // btnGenerarInterpretacion
            // 
            this.btnGenerarInterpretacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(72)))), ((int)(((byte)(140)))));
            this.btnGenerarInterpretacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerarInterpretacion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(72)))), ((int)(((byte)(140)))));
            this.btnGenerarInterpretacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarInterpretacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnGenerarInterpretacion.Location = new System.Drawing.Point(172, 24);
            this.btnGenerarInterpretacion.Name = "btnGenerarInterpretacion";
            this.btnGenerarInterpretacion.Size = new System.Drawing.Size(210, 30);
            this.btnGenerarInterpretacion.TabIndex = 1;
            this.btnGenerarInterpretacion.Text = "Generar interpretación (local)";
            this.btnGenerarInterpretacion.UseVisualStyleBackColor = false;
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.AutoScroll = true;
            this.pnlToolbar.Controls.Add(this.btnPrepararResumen);
            this.pnlToolbar.Controls.Add(this.btnGenerarInterpretacion);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(0, 66);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(1000, 62);
            this.pnlToolbar.TabIndex = 1;
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.tlpIa);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 128);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(10, 4, 10, 10);
            this.pnlBody.Size = new System.Drawing.Size(1000, 472);
            this.pnlBody.TabIndex = 0;
            // 
            // IaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "IaControl";
            this.Size = new System.Drawing.Size(1000, 600);
            this.grpResumenIa.ResumeLayout(false);
            this.grpInterpretacion.ResumeLayout(false);
            this.tlpIa.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlToolbar.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtResumenIa;
        private System.Windows.Forms.GroupBox grpResumenIa;
        private System.Windows.Forms.RichTextBox txtInterpretacion;
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
