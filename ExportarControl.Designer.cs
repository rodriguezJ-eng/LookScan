using System;
using System.Drawing;
using System.Windows.Forms;

namespace LookScan
{
    partial class ExportarControl
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
            this.tlpExportar = new System.Windows.Forms.TableLayoutPanel();
            this.grpExportar1 = new System.Windows.Forms.GroupBox();
            this.lblExportar1 = new System.Windows.Forms.Label();
            this.btnDescargarJson = new System.Windows.Forms.Button();
            this.grpExportar2 = new System.Windows.Forms.GroupBox();
            this.lblExportar2 = new System.Windows.Forms.Label();
            this.btnExportarExcel = new System.Windows.Forms.Button();
            this.grpExportar3 = new System.Windows.Forms.GroupBox();
            this.lblExportar3 = new System.Windows.Forms.Label();
            this.btnExportarPdf = new System.Windows.Forms.Button();
            this.grpExportar4 = new System.Windows.Forms.GroupBox();
            this.lblExportar4 = new System.Windows.Forms.Label();
            this.btnExportarHtml = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.tlpExportar.SuspendLayout();
            this.grpExportar1.SuspendLayout();
            this.grpExportar2.SuspendLayout();
            this.grpExportar3.SuspendLayout();
            this.grpExportar4.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpExportar
            // 
            this.tlpExportar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpExportar.Name = "tlpExportar";
            this.tlpExportar.ColumnCount = 2;
            this.tlpExportar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpExportar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpExportar.RowCount = 2;
            this.tlpExportar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpExportar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpExportar.Controls.Add(this.grpExportar1, 0, 0);
            this.tlpExportar.Controls.Add(this.grpExportar2, 1, 0);
            this.tlpExportar.Controls.Add(this.grpExportar3, 0, 1);
            this.tlpExportar.Controls.Add(this.grpExportar4, 1, 1);
            // 
            // grpExportar1
            // 
            this.grpExportar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpExportar1.Padding = new System.Windows.Forms.Padding(10);
            this.grpExportar1.TabStop = false;
            this.grpExportar1.Text = "Exportar como JSON";
            this.grpExportar1.Name = "grpExportar1";
            this.grpExportar1.Controls.Add(this.lblExportar1);
            this.grpExportar1.Controls.Add(this.btnDescargarJson);
            // 
            // lblExportar1
            // 
            this.lblExportar1.Location = new System.Drawing.Point(14, 30);
            this.lblExportar1.Size = new System.Drawing.Size(380, 50);
            this.lblExportar1.Text = "Formato técnico con todos los datos para importar en otros sistemas.";
            this.lblExportar1.Name = "lblExportar1";
            // 
            // btnDescargarJson
            // 
            this.btnDescargarJson.BackColor = System.Drawing.Color.FromArgb(24, 72, 140);
            this.btnDescargarJson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDescargarJson.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(24, 72, 140);
            this.btnDescargarJson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDescargarJson.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.btnDescargarJson.Location = new System.Drawing.Point(14, 90);
            this.btnDescargarJson.Size = new System.Drawing.Size(170, 30);
            this.btnDescargarJson.Text = "Descargar JSON";
            this.btnDescargarJson.UseVisualStyleBackColor = false;
            this.btnDescargarJson.Name = "btnDescargarJson";
            // 
            // grpExportar2
            // 
            this.grpExportar2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpExportar2.Padding = new System.Windows.Forms.Padding(10);
            this.grpExportar2.TabStop = false;
            this.grpExportar2.Text = "Exportar a Excel";
            this.grpExportar2.Name = "grpExportar2";
            this.grpExportar2.Controls.Add(this.lblExportar2);
            this.grpExportar2.Controls.Add(this.btnExportarExcel);
            // 
            // lblExportar2
            // 
            this.lblExportar2.Location = new System.Drawing.Point(14, 30);
            this.lblExportar2.Size = new System.Drawing.Size(380, 50);
            this.lblExportar2.Text = "Archivo Excel con hojas para cada sección de análisis.";
            this.lblExportar2.Name = "lblExportar2";
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.BackColor = System.Drawing.Color.FromArgb(24, 72, 140);
            this.btnExportarExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportarExcel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(24, 72, 140);
            this.btnExportarExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarExcel.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.btnExportarExcel.Location = new System.Drawing.Point(14, 90);
            this.btnExportarExcel.Size = new System.Drawing.Size(170, 30);
            this.btnExportarExcel.Text = "Exportar a Excel";
            this.btnExportarExcel.UseVisualStyleBackColor = false;
            this.btnExportarExcel.Name = "btnExportarExcel";
            // 
            // grpExportar3
            // 
            this.grpExportar3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpExportar3.Padding = new System.Windows.Forms.Padding(10);
            this.grpExportar3.TabStop = false;
            this.grpExportar3.Text = "Generar PDF";
            this.grpExportar3.Name = "grpExportar3";
            this.grpExportar3.Controls.Add(this.lblExportar3);
            this.grpExportar3.Controls.Add(this.btnExportarPdf);
            // 
            // lblExportar3
            // 
            this.lblExportar3.Location = new System.Drawing.Point(14, 30);
            this.lblExportar3.Size = new System.Drawing.Size(380, 50);
            this.lblExportar3.Text = "Documento PDF con formato para impresión.";
            this.lblExportar3.Name = "lblExportar3";
            // 
            // btnExportarPdf
            // 
            this.btnExportarPdf.BackColor = System.Drawing.Color.FromArgb(24, 72, 140);
            this.btnExportarPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportarPdf.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(24, 72, 140);
            this.btnExportarPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarPdf.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.btnExportarPdf.Location = new System.Drawing.Point(14, 90);
            this.btnExportarPdf.Size = new System.Drawing.Size(170, 30);
            this.btnExportarPdf.Text = "Exportar a PDF";
            this.btnExportarPdf.UseVisualStyleBackColor = false;
            this.btnExportarPdf.Name = "btnExportarPdf";
            // 
            // grpExportar4
            // 
            this.grpExportar4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpExportar4.Padding = new System.Windows.Forms.Padding(10);
            this.grpExportar4.TabStop = false;
            this.grpExportar4.Text = "Vista previa HTML";
            this.grpExportar4.Name = "grpExportar4";
            this.grpExportar4.Controls.Add(this.lblExportar4);
            this.grpExportar4.Controls.Add(this.btnExportarHtml);
            // 
            // lblExportar4
            // 
            this.lblExportar4.Location = new System.Drawing.Point(14, 30);
            this.lblExportar4.Size = new System.Drawing.Size(380, 50);
            this.lblExportar4.Text = "Visualiza el informe completo en el navegador.";
            this.lblExportar4.Name = "lblExportar4";
            // 
            // btnExportarHtml
            // 
            this.btnExportarHtml.BackColor = System.Drawing.Color.FromArgb(24, 72, 140);
            this.btnExportarHtml.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportarHtml.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(24, 72, 140);
            this.btnExportarHtml.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarHtml.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.btnExportarHtml.Location = new System.Drawing.Point(14, 90);
            this.btnExportarHtml.Size = new System.Drawing.Size(170, 30);
            this.btnExportarHtml.Text = "Exportar a HTML";
            this.btnExportarHtml.UseVisualStyleBackColor = false;
            this.btnExportarHtml.Name = "btnExportarHtml";
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
            this.lblTitulo.Text = "Exportar datos completos";
            this.lblTitulo.Name = "lblTitulo";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(105, 105, 105);
            this.lblDescripcion.Location = new System.Drawing.Point(16, 42);
            this.lblDescripcion.Text = "Orden: DATOS, ANÁLISIS, RAZONES, EOAF, EFE, DuPont, GRÁFICOS, PROFORMA";
            this.lblDescripcion.Name = "lblDescripcion";
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.AutoScroll = true;
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Size = new System.Drawing.Size(1000, 14);
            this.pnlToolbar.Name = "pnlToolbar";
            // 
            // pnlBody
            // 
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Padding = new System.Windows.Forms.Padding(10, 4, 10, 10);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Controls.Add(this.tlpExportar);
            // 
            // ExportarControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(244, 246, 250);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Size = new System.Drawing.Size(1000, 600);
            this.Name = "ExportarControl";
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.pnlHeader);
            this.pnlBody.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.grpExportar4.ResumeLayout(false);
            this.grpExportar3.ResumeLayout(false);
            this.grpExportar2.ResumeLayout(false);
            this.grpExportar1.ResumeLayout(false);
            this.tlpExportar.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpExportar;
        private System.Windows.Forms.GroupBox grpExportar1;
        private System.Windows.Forms.Label lblExportar1;
        private System.Windows.Forms.Button btnDescargarJson;
        private System.Windows.Forms.GroupBox grpExportar2;
        private System.Windows.Forms.Label lblExportar2;
        private System.Windows.Forms.Button btnExportarExcel;
        private System.Windows.Forms.GroupBox grpExportar3;
        private System.Windows.Forms.Label lblExportar3;
        private System.Windows.Forms.Button btnExportarPdf;
        private System.Windows.Forms.GroupBox grpExportar4;
        private System.Windows.Forms.Label lblExportar4;
        private System.Windows.Forms.Button btnExportarHtml;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Panel pnlBody;
    }
}
