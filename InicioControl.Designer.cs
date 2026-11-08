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
            this.pnlScroll = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.btnPortalEducativo = new System.Windows.Forms.Button();
            this.btnComingSoon = new System.Windows.Forms.Button();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.grpTarjeta6 = new System.Windows.Forms.GroupBox();
            this.lblObjetivos = new System.Windows.Forms.Label();
            this.grpTarjeta5 = new System.Windows.Forms.GroupBox();
            this.lblValores = new System.Windows.Forms.Label();
            this.grpTarjeta4 = new System.Windows.Forms.GroupBox();
            this.lblVision = new System.Windows.Forms.Label();
            this.grpTarjeta3 = new System.Windows.Forms.GroupBox();
            this.lblMision = new System.Windows.Forms.Label();
            this.grpTarjeta2 = new System.Windows.Forms.GroupBox();
            this.lblPorqueLookScan = new System.Windows.Forms.Label();
            this.grpTarjeta1 = new System.Windows.Forms.GroupBox();
            this.lblHistoria = new System.Windows.Forms.Label();
            this.tlpTarjetas = new System.Windows.Forms.TableLayoutPanel();
            this.pnlScroll.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.grpTarjeta6.SuspendLayout();
            this.grpTarjeta5.SuspendLayout();
            this.grpTarjeta4.SuspendLayout();
            this.grpTarjeta3.SuspendLayout();
            this.grpTarjeta2.SuspendLayout();
            this.grpTarjeta1.SuspendLayout();
            this.tlpTarjetas.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlScroll
            // 
            this.pnlScroll.AutoScroll = true;
            this.pnlScroll.Controls.Add(this.tlpTarjetas);
            this.pnlScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScroll.Location = new System.Drawing.Point(10, 4);
            this.pnlScroll.Name = "pnlScroll";
            this.pnlScroll.Size = new System.Drawing.Size(980, 458);
            this.pnlScroll.TabIndex = 0;
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
            this.lblTitulo.Size = new System.Drawing.Size(134, 37);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "LookScan";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.lblDescripcion.Location = new System.Drawing.Point(16, 42);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(181, 21);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.Text = "Datos. Cálculo. Decisión. ";
            // 
            // btnIniciar
            // 
            this.btnIniciar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(72)))), ((int)(((byte)(140)))));
            this.btnIniciar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIniciar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(72)))), ((int)(((byte)(140)))));
            this.btnIniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnIniciar.Location = new System.Drawing.Point(10, 24);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(190, 30);
            this.btnIniciar.TabIndex = 0;
            this.btnIniciar.Text = "INICIAR";
            this.btnIniciar.UseVisualStyleBackColor = false;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click_1);
            // 
            // btnPortalEducativo
            // 
            this.btnPortalEducativo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnPortalEducativo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPortalEducativo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(72)))), ((int)(((byte)(140)))));
            this.btnPortalEducativo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPortalEducativo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(72)))), ((int)(((byte)(140)))));
            this.btnPortalEducativo.Location = new System.Drawing.Point(212, 24);
            this.btnPortalEducativo.Name = "btnPortalEducativo";
            this.btnPortalEducativo.Size = new System.Drawing.Size(300, 30);
            this.btnPortalEducativo.TabIndex = 1;
            this.btnPortalEducativo.Text = "PORTAL EDUCATIVO";
            this.btnPortalEducativo.UseVisualStyleBackColor = false;
            this.btnPortalEducativo.Click += new System.EventHandler(this.btnPortalEducativo_Click);
            // 
            // btnComingSoon
            // 
            this.btnComingSoon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnComingSoon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnComingSoon.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(72)))), ((int)(((byte)(140)))));
            this.btnComingSoon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComingSoon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(72)))), ((int)(((byte)(140)))));
            this.btnComingSoon.Location = new System.Drawing.Point(518, 24);
            this.btnComingSoon.Name = "btnComingSoon";
            this.btnComingSoon.Size = new System.Drawing.Size(240, 30);
            this.btnComingSoon.TabIndex = 2;
            this.btnComingSoon.Text = "Coming Soon";
            this.btnComingSoon.UseVisualStyleBackColor = false;
            this.btnComingSoon.Click += new System.EventHandler(this.btnComingSoon_Click_1);
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.AutoScroll = true;
            this.pnlToolbar.Controls.Add(this.btnIniciar);
            this.pnlToolbar.Controls.Add(this.btnPortalEducativo);
            this.pnlToolbar.Controls.Add(this.btnComingSoon);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(0, 66);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(1000, 62);
            this.pnlToolbar.TabIndex = 1;
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.pnlScroll);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 128);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(10, 4, 10, 10);
            this.pnlBody.Size = new System.Drawing.Size(1000, 472);
            this.pnlBody.TabIndex = 0;
            // 
            // grpTarjeta6
            // 
            this.grpTarjeta6.Controls.Add(this.lblObjetivos);
            this.grpTarjeta6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTarjeta6.Location = new System.Drawing.Point(491, 303);
            this.grpTarjeta6.Name = "grpTarjeta6";
            this.grpTarjeta6.Padding = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.grpTarjeta6.Size = new System.Drawing.Size(486, 144);
            this.grpTarjeta6.TabIndex = 5;
            this.grpTarjeta6.TabStop = false;
            this.grpTarjeta6.Text = "Objetivos";
            // 
            // lblObjetivos
            // 
            this.lblObjetivos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblObjetivos.Location = new System.Drawing.Point(10, 28);
            this.lblObjetivos.Name = "lblObjetivos";
            this.lblObjetivos.Size = new System.Drawing.Size(466, 110);
            this.lblObjetivos.TabIndex = 0;
            // 
            // grpTarjeta5
            // 
            this.grpTarjeta5.Controls.Add(this.lblValores);
            this.grpTarjeta5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTarjeta5.Location = new System.Drawing.Point(3, 303);
            this.grpTarjeta5.Name = "grpTarjeta5";
            this.grpTarjeta5.Padding = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.grpTarjeta5.Size = new System.Drawing.Size(482, 144);
            this.grpTarjeta5.TabIndex = 4;
            this.grpTarjeta5.TabStop = false;
            this.grpTarjeta5.Text = "Valores";
            // 
            // lblValores
            // 
            this.lblValores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblValores.Location = new System.Drawing.Point(10, 28);
            this.lblValores.Name = "lblValores";
            this.lblValores.Size = new System.Drawing.Size(462, 110);
            this.lblValores.TabIndex = 0;
            // 
            // grpTarjeta4
            // 
            this.grpTarjeta4.Controls.Add(this.lblVision);
            this.grpTarjeta4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTarjeta4.Location = new System.Drawing.Point(491, 153);
            this.grpTarjeta4.Name = "grpTarjeta4";
            this.grpTarjeta4.Padding = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.grpTarjeta4.Size = new System.Drawing.Size(486, 144);
            this.grpTarjeta4.TabIndex = 3;
            this.grpTarjeta4.TabStop = false;
            this.grpTarjeta4.Text = "Visión ";
            // 
            // lblVision
            // 
            this.lblVision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVision.Location = new System.Drawing.Point(10, 28);
            this.lblVision.Name = "lblVision";
            this.lblVision.Size = new System.Drawing.Size(466, 110);
            this.lblVision.TabIndex = 0;
            // 
            // grpTarjeta3
            // 
            this.grpTarjeta3.Controls.Add(this.lblMision);
            this.grpTarjeta3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTarjeta3.Location = new System.Drawing.Point(3, 153);
            this.grpTarjeta3.Name = "grpTarjeta3";
            this.grpTarjeta3.Padding = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.grpTarjeta3.Size = new System.Drawing.Size(482, 144);
            this.grpTarjeta3.TabIndex = 2;
            this.grpTarjeta3.TabStop = false;
            this.grpTarjeta3.Text = "Misión";
            // 
            // lblMision
            // 
            this.lblMision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMision.Location = new System.Drawing.Point(10, 28);
            this.lblMision.Name = "lblMision";
            this.lblMision.Size = new System.Drawing.Size(462, 110);
            this.lblMision.TabIndex = 0;
            // 
            // grpTarjeta2
            // 
            this.grpTarjeta2.Controls.Add(this.lblPorqueLookScan);
            this.grpTarjeta2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTarjeta2.Location = new System.Drawing.Point(491, 3);
            this.grpTarjeta2.Name = "grpTarjeta2";
            this.grpTarjeta2.Padding = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.grpTarjeta2.Size = new System.Drawing.Size(486, 144);
            this.grpTarjeta2.TabIndex = 1;
            this.grpTarjeta2.TabStop = false;
            this.grpTarjeta2.Text = "¿Por qué LookScan?";
            // 
            // lblPorqueLookScan
            // 
            this.lblPorqueLookScan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPorqueLookScan.Location = new System.Drawing.Point(10, 28);
            this.lblPorqueLookScan.Name = "lblPorqueLookScan";
            this.lblPorqueLookScan.Size = new System.Drawing.Size(466, 110);
            this.lblPorqueLookScan.TabIndex = 0;
            // 
            // grpTarjeta1
            // 
            this.grpTarjeta1.Controls.Add(this.lblHistoria);
            this.grpTarjeta1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTarjeta1.Location = new System.Drawing.Point(3, 3);
            this.grpTarjeta1.Name = "grpTarjeta1";
            this.grpTarjeta1.Padding = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.grpTarjeta1.Size = new System.Drawing.Size(482, 144);
            this.grpTarjeta1.TabIndex = 0;
            this.grpTarjeta1.TabStop = false;
            this.grpTarjeta1.Text = "Nuestra historia";
            // 
            // lblHistoria
            // 
            this.lblHistoria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHistoria.Location = new System.Drawing.Point(10, 28);
            this.lblHistoria.Name = "lblHistoria";
            this.lblHistoria.Size = new System.Drawing.Size(462, 110);
            this.lblHistoria.TabIndex = 0;
            // 
            // tlpTarjetas
            // 
            this.tlpTarjetas.AutoSize = true;
            this.tlpTarjetas.ColumnCount = 2;
            this.tlpTarjetas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.84359F));
            this.tlpTarjetas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.15641F));
            this.tlpTarjetas.Controls.Add(this.grpTarjeta1, 0, 0);
            this.tlpTarjetas.Controls.Add(this.grpTarjeta2, 1, 0);
            this.tlpTarjetas.Controls.Add(this.grpTarjeta3, 0, 1);
            this.tlpTarjetas.Controls.Add(this.grpTarjeta4, 1, 1);
            this.tlpTarjetas.Controls.Add(this.grpTarjeta5, 0, 2);
            this.tlpTarjetas.Controls.Add(this.grpTarjeta6, 1, 2);
            this.tlpTarjetas.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpTarjetas.Location = new System.Drawing.Point(0, 0);
            this.tlpTarjetas.Name = "tlpTarjetas";
            this.tlpTarjetas.RowCount = 3;
            this.tlpTarjetas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpTarjetas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpTarjetas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpTarjetas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpTarjetas.Size = new System.Drawing.Size(980, 450);
            this.tlpTarjetas.TabIndex = 0;
            // 
            // InicioControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "InicioControl";
            this.Size = new System.Drawing.Size(1000, 600);
            this.pnlScroll.ResumeLayout(false);
            this.pnlScroll.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlToolbar.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.grpTarjeta6.ResumeLayout(false);
            this.grpTarjeta5.ResumeLayout(false);
            this.grpTarjeta4.ResumeLayout(false);
            this.grpTarjeta3.ResumeLayout(false);
            this.grpTarjeta2.ResumeLayout(false);
            this.grpTarjeta1.ResumeLayout(false);
            this.tlpTarjetas.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlScroll;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Button btnPortalEducativo;
        private System.Windows.Forms.Button btnComingSoon;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Panel pnlBody;
        private TableLayoutPanel tlpTarjetas;
        private GroupBox grpTarjeta1;
        private Label lblHistoria;
        private GroupBox grpTarjeta2;
        private Label lblPorqueLookScan;
        private GroupBox grpTarjeta3;
        private Label lblMision;
        private GroupBox grpTarjeta4;
        private Label lblVision;
        private GroupBox grpTarjeta5;
        private Label lblValores;
        private GroupBox grpTarjeta6;
        private Label lblObjetivos;
    }
}
