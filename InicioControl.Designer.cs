using System;
using System.Drawing;
using System.Windows.Forms;

namespace LookScan
{
    partial class InicioControl
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
            pnlScroll = new Panel();
            tlpTarjetas = new TableLayoutPanel();
            grpTarjeta1 = new GroupBox();
            lblTarjeta1 = new Label();
            grpTarjeta2 = new GroupBox();
            lblTarjeta2 = new Label();
            grpTarjeta3 = new GroupBox();
            lblTarjeta3 = new Label();
            grpTarjeta4 = new GroupBox();
            lblTarjeta4 = new Label();
            grpTarjeta5 = new GroupBox();
            lblTarjeta5 = new Label();
            grpTarjeta6 = new GroupBox();
            lblTarjeta6 = new Label();
            grpTarjeta7 = new GroupBox();
            lblTarjeta7 = new Label();
            grpTarjeta8 = new GroupBox();
            lblTarjeta8 = new Label();
            grpTarjeta9 = new GroupBox();
            lblTarjeta9 = new Label();
            pnlHeader = new Panel();
            lblTitulo = new Label();
            lblDescripcion = new Label();
            btnIniciar = new Button();
            btnPortalEducativo = new Button();
            btnComingSoon = new Button();
            pnlToolbar = new Panel();
            pnlBody = new Panel();
            pnlScroll.SuspendLayout();
            tlpTarjetas.SuspendLayout();
            grpTarjeta1.SuspendLayout();
            grpTarjeta2.SuspendLayout();
            grpTarjeta3.SuspendLayout();
            grpTarjeta4.SuspendLayout();
            grpTarjeta5.SuspendLayout();
            grpTarjeta6.SuspendLayout();
            grpTarjeta7.SuspendLayout();
            grpTarjeta8.SuspendLayout();
            grpTarjeta9.SuspendLayout();
            pnlHeader.SuspendLayout();
            pnlToolbar.SuspendLayout();
            pnlBody.SuspendLayout();
            SuspendLayout();
            // 
            // pnlScroll
            // 
            pnlScroll.AutoScroll = true;
            pnlScroll.Controls.Add(tlpTarjetas);
            pnlScroll.Dock = DockStyle.Fill;
            pnlScroll.Location = new Point(10, 4);
            pnlScroll.Name = "pnlScroll";
            pnlScroll.Size = new Size(980, 458);
            pnlScroll.TabIndex = 0;
            // 
            // tlpTarjetas
            // 
            tlpTarjetas.ColumnCount = 2;
            tlpTarjetas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpTarjetas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpTarjetas.Controls.Add(grpTarjeta1, 0, 0);
            tlpTarjetas.Controls.Add(grpTarjeta2, 1, 0);
            tlpTarjetas.Controls.Add(grpTarjeta3, 0, 1);
            tlpTarjetas.Controls.Add(grpTarjeta4, 1, 1);
            tlpTarjetas.Controls.Add(grpTarjeta5, 0, 2);
            tlpTarjetas.Controls.Add(grpTarjeta6, 1, 2);
            tlpTarjetas.Controls.Add(grpTarjeta7, 0, 3);
            tlpTarjetas.Controls.Add(grpTarjeta8, 1, 3);
            tlpTarjetas.Controls.Add(grpTarjeta9, 0, 4);
            tlpTarjetas.Dock = DockStyle.Top;
            tlpTarjetas.Location = new Point(0, 0);
            tlpTarjetas.Name = "tlpTarjetas";
            tlpTarjetas.RowCount = 5;
            tlpTarjetas.RowStyles.Add(new RowStyle(SizeType.Absolute, 150F));
            tlpTarjetas.RowStyles.Add(new RowStyle(SizeType.Absolute, 150F));
            tlpTarjetas.RowStyles.Add(new RowStyle(SizeType.Absolute, 150F));
            tlpTarjetas.RowStyles.Add(new RowStyle(SizeType.Absolute, 150F));
            tlpTarjetas.RowStyles.Add(new RowStyle(SizeType.Absolute, 150F));
            tlpTarjetas.Size = new Size(959, 750);
            tlpTarjetas.TabIndex = 0;
            // 
            // grpTarjeta1
            // 
            grpTarjeta1.Controls.Add(lblTarjeta1);
            grpTarjeta1.Dock = DockStyle.Fill;
            grpTarjeta1.Location = new Point(3, 3);
            grpTarjeta1.Name = "grpTarjeta1";
            grpTarjeta1.Padding = new Padding(10, 6, 10, 6);
            grpTarjeta1.Size = new Size(473, 144);
            grpTarjeta1.TabIndex = 0;
            grpTarjeta1.TabStop = false;
            grpTarjeta1.Text = "Nuestra historia";
            // 
            // lblTarjeta1
            // 
            lblTarjeta1.Dock = DockStyle.Fill;
            lblTarjeta1.Location = new Point(10, 28);
            lblTarjeta1.Name = "lblTarjeta1";
            lblTarjeta1.Size = new Size(453, 110);
            lblTarjeta1.TabIndex = 0;
            // 
            // grpTarjeta2
            // 
            grpTarjeta2.Controls.Add(lblTarjeta2);
            grpTarjeta2.Dock = DockStyle.Fill;
            grpTarjeta2.Location = new Point(482, 3);
            grpTarjeta2.Name = "grpTarjeta2";
            grpTarjeta2.Padding = new Padding(10, 6, 10, 6);
            grpTarjeta2.Size = new Size(474, 144);
            grpTarjeta2.TabIndex = 1;
            grpTarjeta2.TabStop = false;
            grpTarjeta2.Text = "Propuesta de valor";
            // 
            // lblTarjeta2
            // 
            lblTarjeta2.Dock = DockStyle.Fill;
            lblTarjeta2.Location = new Point(10, 28);
            lblTarjeta2.Name = "lblTarjeta2";
            lblTarjeta2.Size = new Size(454, 110);
            lblTarjeta2.TabIndex = 0;
            // 
            // grpTarjeta3
            // 
            grpTarjeta3.Controls.Add(lblTarjeta3);
            grpTarjeta3.Dock = DockStyle.Fill;
            grpTarjeta3.Location = new Point(3, 153);
            grpTarjeta3.Name = "grpTarjeta3";
            grpTarjeta3.Padding = new Padding(10, 6, 10, 6);
            grpTarjeta3.Size = new Size(473, 144);
            grpTarjeta3.TabIndex = 2;
            grpTarjeta3.TabStop = false;
            grpTarjeta3.Text = "Misión";
            // 
            // lblTarjeta3
            // 
            lblTarjeta3.Dock = DockStyle.Fill;
            lblTarjeta3.Location = new Point(10, 28);
            lblTarjeta3.Name = "lblTarjeta3";
            lblTarjeta3.Size = new Size(453, 110);
            lblTarjeta3.TabIndex = 0;
            // 
            // grpTarjeta4
            // 
            grpTarjeta4.Controls.Add(lblTarjeta4);
            grpTarjeta4.Dock = DockStyle.Fill;
            grpTarjeta4.Location = new Point(482, 153);
            grpTarjeta4.Name = "grpTarjeta4";
            grpTarjeta4.Padding = new Padding(10, 6, 10, 6);
            grpTarjeta4.Size = new Size(474, 144);
            grpTarjeta4.TabIndex = 3;
            grpTarjeta4.TabStop = false;
            grpTarjeta4.Text = "Visión 2028";
            // 
            // lblTarjeta4
            // 
            lblTarjeta4.Dock = DockStyle.Fill;
            lblTarjeta4.Location = new Point(10, 28);
            lblTarjeta4.Name = "lblTarjeta4";
            lblTarjeta4.Size = new Size(454, 110);
            lblTarjeta4.TabIndex = 0;
            // 
            // grpTarjeta5
            // 
            grpTarjeta5.Controls.Add(lblTarjeta5);
            grpTarjeta5.Dock = DockStyle.Fill;
            grpTarjeta5.Location = new Point(3, 303);
            grpTarjeta5.Name = "grpTarjeta5";
            grpTarjeta5.Padding = new Padding(10, 6, 10, 6);
            grpTarjeta5.Size = new Size(473, 144);
            grpTarjeta5.TabIndex = 4;
            grpTarjeta5.TabStop = false;
            grpTarjeta5.Text = "Valores";
            // 
            // lblTarjeta5
            // 
            lblTarjeta5.Dock = DockStyle.Fill;
            lblTarjeta5.Location = new Point(10, 28);
            lblTarjeta5.Name = "lblTarjeta5";
            lblTarjeta5.Size = new Size(453, 110);
            lblTarjeta5.TabIndex = 0;
            // 
            // grpTarjeta6
            // 
            grpTarjeta6.Controls.Add(lblTarjeta6);
            grpTarjeta6.Dock = DockStyle.Fill;
            grpTarjeta6.Location = new Point(482, 303);
            grpTarjeta6.Name = "grpTarjeta6";
            grpTarjeta6.Padding = new Padding(10, 6, 10, 6);
            grpTarjeta6.Size = new Size(474, 144);
            grpTarjeta6.TabIndex = 5;
            grpTarjeta6.TabStop = false;
            grpTarjeta6.Text = "Objetivos";
            // 
            // lblTarjeta6
            // 
            lblTarjeta6.Dock = DockStyle.Fill;
            lblTarjeta6.Location = new Point(10, 28);
            lblTarjeta6.Name = "lblTarjeta6";
            lblTarjeta6.Size = new Size(454, 110);
            lblTarjeta6.TabIndex = 0;
            // 
            // grpTarjeta7
            // 
            grpTarjeta7.Controls.Add(lblTarjeta7);
            grpTarjeta7.Dock = DockStyle.Fill;
            grpTarjeta7.Location = new Point(3, 453);
            grpTarjeta7.Name = "grpTarjeta7";
            grpTarjeta7.Padding = new Padding(10, 6, 10, 6);
            grpTarjeta7.Size = new Size(473, 144);
            grpTarjeta7.TabIndex = 6;
            grpTarjeta7.TabStop = false;
            grpTarjeta7.Text = "Indicadores de éxito";
            // 
            // lblTarjeta7
            // 
            lblTarjeta7.Dock = DockStyle.Fill;
            lblTarjeta7.Location = new Point(10, 28);
            lblTarjeta7.Name = "lblTarjeta7";
            lblTarjeta7.Size = new Size(453, 110);
            lblTarjeta7.TabIndex = 0;
            // 
            // grpTarjeta8
            // 
            grpTarjeta8.Controls.Add(lblTarjeta8);
            grpTarjeta8.Dock = DockStyle.Fill;
            grpTarjeta8.Location = new Point(482, 453);
            grpTarjeta8.Name = "grpTarjeta8";
            grpTarjeta8.Padding = new Padding(10, 6, 10, 6);
            grpTarjeta8.Size = new Size(474, 144);
            grpTarjeta8.TabIndex = 7;
            grpTarjeta8.TabStop = false;
            grpTarjeta8.Text = "Política de datos y ética";
            // 
            // lblTarjeta8
            // 
            lblTarjeta8.Dock = DockStyle.Fill;
            lblTarjeta8.Location = new Point(10, 28);
            lblTarjeta8.Name = "lblTarjeta8";
            lblTarjeta8.Size = new Size(454, 110);
            lblTarjeta8.TabIndex = 0;
            // 
            // grpTarjeta9
            // 
            grpTarjeta9.Controls.Add(lblTarjeta9);
            grpTarjeta9.Dock = DockStyle.Fill;
            grpTarjeta9.Location = new Point(3, 603);
            grpTarjeta9.Name = "grpTarjeta9";
            grpTarjeta9.Padding = new Padding(10, 6, 10, 6);
            grpTarjeta9.Size = new Size(473, 144);
            grpTarjeta9.TabIndex = 8;
            grpTarjeta9.TabStop = false;
            grpTarjeta9.Text = "Conócenos";
            // 
            // lblTarjeta9
            // 
            lblTarjeta9.Dock = DockStyle.Fill;
            lblTarjeta9.Location = new Point(10, 28);
            lblTarjeta9.Name = "lblTarjeta9";
            lblTarjeta9.Size = new Size(453, 110);
            lblTarjeta9.TabIndex = 0;
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
            lblTitulo.Size = new Size(134, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "LookScan";
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.ForeColor = Color.FromArgb(105, 105, 105);
            lblDescripcion.Location = new Point(16, 42);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(181, 21);
            lblDescripcion.TabIndex = 1;
            lblDescripcion.Text = "Datos. Cálculo. Decisión. ";
            // 
            // btnIniciar
            // 
            btnIniciar.BackColor = Color.FromArgb(24, 72, 140);
            btnIniciar.Cursor = Cursors.Hand;
            btnIniciar.FlatAppearance.BorderColor = Color.FromArgb(24, 72, 140);
            btnIniciar.FlatStyle = FlatStyle.Flat;
            btnIniciar.ForeColor = Color.FromArgb(255, 255, 255);
            btnIniciar.Location = new Point(10, 24);
            btnIniciar.Name = "btnIniciar";
            btnIniciar.Size = new Size(190, 30);
            btnIniciar.TabIndex = 0;
            btnIniciar.Text = "INICIAR";
            btnIniciar.UseVisualStyleBackColor = false;
            btnIniciar.Click += btnIniciar_Click;
            // 
            // btnPortalEducativo
            // 
            btnPortalEducativo.BackColor = Color.FromArgb(255, 255, 255);
            btnPortalEducativo.Cursor = Cursors.Hand;
            btnPortalEducativo.FlatAppearance.BorderColor = Color.FromArgb(24, 72, 140);
            btnPortalEducativo.FlatStyle = FlatStyle.Flat;
            btnPortalEducativo.ForeColor = Color.FromArgb(24, 72, 140);
            btnPortalEducativo.Location = new Point(212, 24);
            btnPortalEducativo.Name = "btnPortalEducativo";
            btnPortalEducativo.Size = new Size(300, 30);
            btnPortalEducativo.TabIndex = 1;
            btnPortalEducativo.Text = "PORTAL EDUCATIVO";
            btnPortalEducativo.UseVisualStyleBackColor = false;
            btnPortalEducativo.Click += btnPortalEducativo_Click_1;
            // 
            // btnComingSoon
            // 
            btnComingSoon.BackColor = Color.FromArgb(255, 255, 255);
            btnComingSoon.Cursor = Cursors.Hand;
            btnComingSoon.FlatAppearance.BorderColor = Color.FromArgb(24, 72, 140);
            btnComingSoon.FlatStyle = FlatStyle.Flat;
            btnComingSoon.ForeColor = Color.FromArgb(24, 72, 140);
            btnComingSoon.Location = new Point(518, 24);
            btnComingSoon.Name = "btnComingSoon";
            btnComingSoon.Size = new Size(240, 30);
            btnComingSoon.TabIndex = 2;
            btnComingSoon.Text = "Coming Soon";
            btnComingSoon.UseVisualStyleBackColor = false;
            btnComingSoon.Click += btnComingSoon_Click;
            // 
            // pnlToolbar
            // 
            pnlToolbar.AutoScroll = true;
            pnlToolbar.Controls.Add(btnIniciar);
            pnlToolbar.Controls.Add(btnPortalEducativo);
            pnlToolbar.Controls.Add(btnComingSoon);
            pnlToolbar.Dock = DockStyle.Top;
            pnlToolbar.Location = new Point(0, 66);
            pnlToolbar.Name = "pnlToolbar";
            pnlToolbar.Size = new Size(1000, 62);
            pnlToolbar.TabIndex = 1;
            // 
            // pnlBody
            // 
            pnlBody.Controls.Add(pnlScroll);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 128);
            pnlBody.Name = "pnlBody";
            pnlBody.Padding = new Padding(10, 4, 10, 10);
            pnlBody.Size = new Size(1000, 472);
            pnlBody.TabIndex = 0;
            // 
            // InicioControl
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 246, 250);
            Controls.Add(pnlBody);
            Controls.Add(pnlToolbar);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9.5F);
            Name = "InicioControl";
            Size = new Size(1000, 600);
            pnlScroll.ResumeLayout(false);
            tlpTarjetas.ResumeLayout(false);
            grpTarjeta1.ResumeLayout(false);
            grpTarjeta2.ResumeLayout(false);
            grpTarjeta3.ResumeLayout(false);
            grpTarjeta4.ResumeLayout(false);
            grpTarjeta5.ResumeLayout(false);
            grpTarjeta6.ResumeLayout(false);
            grpTarjeta7.ResumeLayout(false);
            grpTarjeta8.ResumeLayout(false);
            grpTarjeta9.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlToolbar.ResumeLayout(false);
            pnlBody.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlScroll;
        private System.Windows.Forms.TableLayoutPanel tlpTarjetas;
        private System.Windows.Forms.GroupBox grpTarjeta1;
        private System.Windows.Forms.Label lblTarjeta1;
        private System.Windows.Forms.GroupBox grpTarjeta2;
        private System.Windows.Forms.Label lblTarjeta2;
        private System.Windows.Forms.GroupBox grpTarjeta3;
        private System.Windows.Forms.Label lblTarjeta3;
        private System.Windows.Forms.GroupBox grpTarjeta4;
        private System.Windows.Forms.Label lblTarjeta4;
        private System.Windows.Forms.GroupBox grpTarjeta5;
        private System.Windows.Forms.Label lblTarjeta5;
        private System.Windows.Forms.GroupBox grpTarjeta6;
        private System.Windows.Forms.Label lblTarjeta6;
        private System.Windows.Forms.GroupBox grpTarjeta7;
        private System.Windows.Forms.Label lblTarjeta7;
        private System.Windows.Forms.GroupBox grpTarjeta8;
        private System.Windows.Forms.Label lblTarjeta8;
        private System.Windows.Forms.GroupBox grpTarjeta9;
        private System.Windows.Forms.Label lblTarjeta9;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Button btnPortalEducativo;
        private System.Windows.Forms.Button btnComingSoon;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Panel pnlBody;
    }
}
