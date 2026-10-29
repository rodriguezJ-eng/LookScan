using System;
using System.Drawing;
using System.Windows.Forms;

namespace LookScan
{
    partial class ResumenGlobalControl
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
            this.txtResumenGlobal = new System.Windows.Forms.TextBox();
            this.grpResumenGlobal = new System.Windows.Forms.GroupBox();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.btnGenerarResumenGlobal = new System.Windows.Forms.Button();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.grpResumenGlobal.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtResumenGlobal
            // 
            this.txtResumenGlobal.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.txtResumenGlobal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResumenGlobal.Multiline = true;
            this.txtResumenGlobal.ReadOnly = true;
            this.txtResumenGlobal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResumenGlobal.Name = "txtResumenGlobal";
            // 
            // grpResumenGlobal
            // 
            this.grpResumenGlobal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpResumenGlobal.Padding = new System.Windows.Forms.Padding(8, 6, 8, 8);
            this.grpResumenGlobal.TabStop = false;
            this.grpResumenGlobal.Text = "Resumen Global (IA por periodos y grupos)";
            this.grpResumenGlobal.Name = "grpResumenGlobal";
            this.grpResumenGlobal.Controls.Add(this.txtResumenGlobal);
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
            this.lblTitulo.Text = "Resumen Global";
            this.lblTitulo.Name = "lblTitulo";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(105, 105, 105);
            this.lblDescripcion.Location = new System.Drawing.Point(16, 42);
            this.lblDescripcion.Text = "IA por periodos y grupos de razones";
            this.lblDescripcion.Name = "lblDescripcion";
            // 
            // btnGenerarResumenGlobal
            // 
            this.btnGenerarResumenGlobal.BackColor = System.Drawing.Color.FromArgb(24, 72, 140);
            this.btnGenerarResumenGlobal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerarResumenGlobal.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(24, 72, 140);
            this.btnGenerarResumenGlobal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarResumenGlobal.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.btnGenerarResumenGlobal.Location = new System.Drawing.Point(10, 24);
            this.btnGenerarResumenGlobal.Size = new System.Drawing.Size(190, 30);
            this.btnGenerarResumenGlobal.Text = "Generar Resumen Global";
            this.btnGenerarResumenGlobal.UseVisualStyleBackColor = false;
            this.btnGenerarResumenGlobal.Name = "btnGenerarResumenGlobal";
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.AutoScroll = true;
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Size = new System.Drawing.Size(1000, 62);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Controls.Add(this.btnGenerarResumenGlobal);
            // 
            // pnlBody
            // 
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Padding = new System.Windows.Forms.Padding(10, 4, 10, 10);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Controls.Add(this.grpResumenGlobal);
            // 
            // ResumenGlobalControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(244, 246, 250);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Size = new System.Drawing.Size(1000, 600);
            this.Name = "ResumenGlobalControl";
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.pnlHeader);
            this.pnlBody.ResumeLayout(false);
            this.pnlToolbar.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.grpResumenGlobal.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TextBox txtResumenGlobal;
        private System.Windows.Forms.GroupBox grpResumenGlobal;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Button btnGenerarResumenGlobal;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Panel pnlBody;
    }
}
