using System;
using System.Drawing;
using System.Windows.Forms;

namespace LookScan
{
    partial class AlmacenamientoControl
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
            this.dgvProyectos = new System.Windows.Forms.DataGridView();
            this.dgvProyectosHdrStyle = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvProyectosAltStyle = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvProyectosCol0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvProyectosCol1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvProyectosCol2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dgvProyectosCol3 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.grpProyectos = new System.Windows.Forms.GroupBox();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombreProyecto = new System.Windows.Forms.TextBox();
            this.btnGuardarProyecto = new System.Windows.Forms.Button();
            this.btnRefrescarLista = new System.Windows.Forms.Button();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.pnlBody = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProyectos)).BeginInit();
            this.grpProyectos.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvProyectos
            // 
            this.dgvProyectos.AllowUserToAddRows = false;
            this.dgvProyectos.AllowUserToDeleteRows = false;
            this.dgvProyectos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProyectos.BackgroundColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.dgvProyectos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProyectos.ColumnHeadersHeight = 32;
            this.dgvProyectos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvProyectos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProyectos.EnableHeadersVisualStyles = false;
            this.dgvProyectos.ReadOnly = true;
            this.dgvProyectos.RowHeadersVisible = false;
            this.dgvProyectos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProyectos.ColumnHeadersDefaultCellStyle = this.dgvProyectosHdrStyle;
            this.dgvProyectos.AlternatingRowsDefaultCellStyle = this.dgvProyectosAltStyle;
            this.dgvProyectos.Name = "dgvProyectos";
            this.dgvProyectos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.dgvProyectosCol0,
                this.dgvProyectosCol1,
                this.dgvProyectosCol2,
                this.dgvProyectosCol3});
            // 
            // dgvProyectosHdrStyle
            // 
            this.dgvProyectosHdrStyle.BackColor = System.Drawing.Color.FromArgb(24, 72, 140);
            this.dgvProyectosHdrStyle.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            // 
            // dgvProyectosAltStyle
            // 
            this.dgvProyectosAltStyle.BackColor = System.Drawing.Color.FromArgb(247, 249, 252);
            // 
            // dgvProyectosCol0
            // 
            this.dgvProyectosCol0.HeaderText = "Proyecto";
            this.dgvProyectosCol0.Name = "dgvProyectosCol0";
            // 
            // dgvProyectosCol1
            // 
            this.dgvProyectosCol1.HeaderText = "Última modificación";
            this.dgvProyectosCol1.Name = "dgvProyectosCol1";
            // 
            // dgvProyectosCol2
            // 
            this.dgvProyectosCol2.FillWeight = 40F;
            this.dgvProyectosCol2.HeaderText = "";
            this.dgvProyectosCol2.Text = "Cargar";
            this.dgvProyectosCol2.UseColumnTextForButtonValue = true;
            this.dgvProyectosCol2.Name = "dgvProyectosCol2";
            // 
            // dgvProyectosCol3
            // 
            this.dgvProyectosCol3.FillWeight = 40F;
            this.dgvProyectosCol3.HeaderText = "";
            this.dgvProyectosCol3.Text = "Eliminar";
            this.dgvProyectosCol3.UseColumnTextForButtonValue = true;
            this.dgvProyectosCol3.Name = "dgvProyectosCol3";
            // 
            // grpProyectos
            // 
            this.grpProyectos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpProyectos.Padding = new System.Windows.Forms.Padding(8, 6, 8, 8);
            this.grpProyectos.TabStop = false;
            this.grpProyectos.Text = "Proyectos";
            this.grpProyectos.Name = "grpProyectos";
            this.grpProyectos.Controls.Add(this.dgvProyectos);
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
            this.lblTitulo.Text = "Almacenamiento local";
            this.lblTitulo.Name = "lblTitulo";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(105, 105, 105);
            this.lblDescripcion.Location = new System.Drawing.Point(16, 42);
            this.lblDescripcion.Text = "Proyectos guardados en este equipo";
            this.lblDescripcion.Name = "lblDescripcion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 6);
            this.label1.Text = "Nombre del proyecto";
            this.label1.ForeColor = System.Drawing.Color.FromArgb(70, 80, 100);
            this.label1.Name = "label1";
            // 
            // txtNombreProyecto
            // 
            this.txtNombreProyecto.Location = new System.Drawing.Point(10, 26);
            this.txtNombreProyecto.Size = new System.Drawing.Size(280, 23);
            this.txtNombreProyecto.Name = "txtNombreProyecto";
            // 
            // btnGuardarProyecto
            // 
            this.btnGuardarProyecto.BackColor = System.Drawing.Color.FromArgb(24, 72, 140);
            this.btnGuardarProyecto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarProyecto.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(24, 72, 140);
            this.btnGuardarProyecto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarProyecto.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.btnGuardarProyecto.Location = new System.Drawing.Point(302, 24);
            this.btnGuardarProyecto.Size = new System.Drawing.Size(150, 30);
            this.btnGuardarProyecto.Text = "Guardar/Actualizar";
            this.btnGuardarProyecto.UseVisualStyleBackColor = false;
            this.btnGuardarProyecto.Name = "btnGuardarProyecto";
            // 
            // btnRefrescarLista
            // 
            this.btnRefrescarLista.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.btnRefrescarLista.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefrescarLista.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(24, 72, 140);
            this.btnRefrescarLista.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefrescarLista.ForeColor = System.Drawing.Color.FromArgb(24, 72, 140);
            this.btnRefrescarLista.Location = new System.Drawing.Point(464, 24);
            this.btnRefrescarLista.Size = new System.Drawing.Size(130, 30);
            this.btnRefrescarLista.Text = "Refrescar lista";
            this.btnRefrescarLista.UseVisualStyleBackColor = false;
            this.btnRefrescarLista.Name = "btnRefrescarLista";
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.AutoScroll = true;
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Size = new System.Drawing.Size(1000, 62);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Controls.Add(this.label1);
            this.pnlToolbar.Controls.Add(this.txtNombreProyecto);
            this.pnlToolbar.Controls.Add(this.btnGuardarProyecto);
            this.pnlToolbar.Controls.Add(this.btnRefrescarLista);
            // 
            // pnlBody
            // 
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Padding = new System.Windows.Forms.Padding(10, 4, 10, 10);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Controls.Add(this.grpProyectos);
            // 
            // AlmacenamientoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(244, 246, 250);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Size = new System.Drawing.Size(1000, 600);
            this.Name = "AlmacenamientoControl";
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.pnlHeader);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProyectos)).EndInit();
            this.pnlBody.ResumeLayout(false);
            this.pnlToolbar.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.grpProyectos.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProyectos;
        private System.Windows.Forms.DataGridViewCellStyle dgvProyectosHdrStyle;
        private System.Windows.Forms.DataGridViewCellStyle dgvProyectosAltStyle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvProyectosCol0;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvProyectosCol1;
        private System.Windows.Forms.DataGridViewButtonColumn dgvProyectosCol2;
        private System.Windows.Forms.DataGridViewButtonColumn dgvProyectosCol3;
        private System.Windows.Forms.GroupBox grpProyectos;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombreProyecto;
        private System.Windows.Forms.Button btnGuardarProyecto;
        private System.Windows.Forms.Button btnRefrescarLista;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Panel pnlBody;
    }
}
