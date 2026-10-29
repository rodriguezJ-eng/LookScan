using System;
using System.Drawing;
using System.Windows.Forms;

namespace LookScan
{
    partial class ReportesControl
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
            this.txtReporte = new System.Windows.Forms.TextBox();
            this.grpVistaReporte = new System.Windows.Forms.GroupBox();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.btnDescargarTxt = new System.Windows.Forms.Button();
            this.btnDescargarJsonRep = new System.Windows.Forms.Button();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.grpVistaReporte.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtReporte
            // 
            this.txtReporte.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.txtReporte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReporte.Multiline = true;
            this.txtReporte.ReadOnly = true;
            this.txtReporte.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReporte.Name = "txtReporte";
            // 
            // grpVistaReporte
            // 
            this.grpVistaReporte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpVistaReporte.Padding = new System.Windows.Forms.Padding(8, 6, 8, 8);
            this.grpVistaReporte.TabStop = false;
            this.grpVistaReporte.Text = "Vista previa del reporte";
            this.grpVistaReporte.Name = "grpVistaReporte";
            this.grpVistaReporte.Controls.Add(this.txtReporte);
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
            this.lblTitulo.Text = "Reportes";
            this.lblTitulo.Name = "lblTitulo";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(105, 105, 105);
            this.lblDescripcion.Location = new System.Drawing.Point(16, 42);
            this.lblDescripcion.Text = "Descarga de resumen y datos";
            this.lblDescripcion.Name = "lblDescripcion";
            // 
            // btnDescargarTxt
            // 
            this.btnDescargarTxt.BackColor = System.Drawing.Color.FromArgb(24, 72, 140);
            this.btnDescargarTxt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDescargarTxt.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(24, 72, 140);
            this.btnDescargarTxt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDescargarTxt.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.btnDescargarTxt.Location = new System.Drawing.Point(10, 24);
            this.btnDescargarTxt.Size = new System.Drawing.Size(190, 30);
            this.btnDescargarTxt.Text = "Descargar Resumen (.txt)";
            this.btnDescargarTxt.UseVisualStyleBackColor = false;
            this.btnDescargarTxt.Name = "btnDescargarTxt";
            // 
            // btnDescargarJsonRep
            // 
            this.btnDescargarJsonRep.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.btnDescargarJsonRep.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDescargarJsonRep.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(24, 72, 140);
            this.btnDescargarJsonRep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDescargarJsonRep.ForeColor = System.Drawing.Color.FromArgb(24, 72, 140);
            this.btnDescargarJsonRep.Location = new System.Drawing.Point(212, 24);
            this.btnDescargarJsonRep.Size = new System.Drawing.Size(190, 30);
            this.btnDescargarJsonRep.Text = "Descargar Datos (.json)";
            this.btnDescargarJsonRep.UseVisualStyleBackColor = false;
            this.btnDescargarJsonRep.Name = "btnDescargarJsonRep";
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.AutoScroll = true;
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Size = new System.Drawing.Size(1000, 62);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Controls.Add(this.btnDescargarTxt);
            this.pnlToolbar.Controls.Add(this.btnDescargarJsonRep);
            // 
            // pnlBody
            // 
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Padding = new System.Windows.Forms.Padding(10, 4, 10, 10);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Controls.Add(this.grpVistaReporte);
            // 
            // ReportesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(244, 246, 250);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Size = new System.Drawing.Size(1000, 600);
            this.Name = "ReportesControl";
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.pnlHeader);
            this.pnlBody.ResumeLayout(false);
            this.pnlToolbar.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.grpVistaReporte.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TextBox txtReporte;
        private System.Windows.Forms.GroupBox grpVistaReporte;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Button btnDescargarTxt;
        private System.Windows.Forms.Button btnDescargarJsonRep;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Panel pnlBody;
    }
}
