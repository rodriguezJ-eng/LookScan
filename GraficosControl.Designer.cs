using System;
using System.Drawing;
using System.Windows.Forms;

namespace LookScan
{
    partial class GraficosControl
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
            tlpGraficos = new TableLayoutPanel();
            grpGrafico1 = new GroupBox();
            pnlGrafico1 = new Panel();
            lblAreaGrafico1 = new Label();
            pnlOpciones1 = new Panel();
            label1 = new Label();
            cmbTipoGrafico1 = new ComboBox();
            label2 = new Label();
            cmbEstiloGrafico1 = new ComboBox();
            grpGrafico2 = new GroupBox();
            pnlGrafico2 = new Panel();
            lblAreaGrafico2 = new Label();
            pnlOpciones2 = new Panel();
            label3 = new Label();
            cmbTipoGrafico2 = new ComboBox();
            label4 = new Label();
            cmbEstiloGrafico2 = new ComboBox();
            grpGrafico3 = new GroupBox();
            pnlGrafico3 = new Panel();
            lblAreaGrafico3 = new Label();
            pnlOpciones3 = new Panel();
            label5 = new Label();
            cmbTipoGrafico3 = new ComboBox();
            label6 = new Label();
            cmbEstiloGrafico3 = new ComboBox();
            grpGrafico4 = new GroupBox();
            pnlGrafico4 = new Panel();
            lblAreaGrafico4 = new Label();
            pnlOpciones4 = new Panel();
            label7 = new Label();
            cmbTipoGrafico4 = new ComboBox();
            label8 = new Label();
            cmbEstiloGrafico4 = new ComboBox();
            grpGrafico5 = new GroupBox();
            pnlGrafico5 = new Panel();
            lblAreaGrafico5 = new Label();
            pnlOpciones5 = new Panel();
            label9 = new Label();
            cmbTipoGrafico5 = new ComboBox();
            label10 = new Label();
            cmbEstiloGrafico5 = new ComboBox();
            grpGrafico6 = new GroupBox();
            pnlGrafico6 = new Panel();
            lblAreaGrafico6 = new Label();
            pnlOpciones6 = new Panel();
            label11 = new Label();
            cmbTipoGrafico6 = new ComboBox();
            label12 = new Label();
            cmbEstiloGrafico6 = new ComboBox();
            pnlHeader = new Panel();
            lblTitulo = new Label();
            lblDescripcion = new Label();
            label13 = new Label();
            cmbPeriodoBaseGraf = new ComboBox();
            label14 = new Label();
            cmbPeriodoCompGraf = new ComboBox();
            label15 = new Label();
            cmbTopN = new ComboBox();
            label16 = new Label();
            cmbOrdenarPor = new ComboBox();
            label17 = new Label();
            cmbMostrar = new ComboBox();
            btnActualizarTodos = new Button();
            grpFiltros = new GroupBox();
            pnlToolbar = new Panel();
            pnlBody = new Panel();
            pnlScroll.SuspendLayout();
            tlpGraficos.SuspendLayout();
            grpGrafico1.SuspendLayout();
            pnlGrafico1.SuspendLayout();
            pnlOpciones1.SuspendLayout();
            grpGrafico2.SuspendLayout();
            pnlGrafico2.SuspendLayout();
            pnlOpciones2.SuspendLayout();
            grpGrafico3.SuspendLayout();
            pnlGrafico3.SuspendLayout();
            pnlOpciones3.SuspendLayout();
            grpGrafico4.SuspendLayout();
            pnlGrafico4.SuspendLayout();
            pnlOpciones4.SuspendLayout();
            grpGrafico5.SuspendLayout();
            pnlGrafico5.SuspendLayout();
            pnlOpciones5.SuspendLayout();
            grpGrafico6.SuspendLayout();
            pnlGrafico6.SuspendLayout();
            pnlOpciones6.SuspendLayout();
            pnlHeader.SuspendLayout();
            grpFiltros.SuspendLayout();
            pnlToolbar.SuspendLayout();
            pnlBody.SuspendLayout();
            SuspendLayout();
            // 
            // pnlScroll
            // 
            pnlScroll.AutoScroll = true;
            pnlScroll.Controls.Add(tlpGraficos);
            pnlScroll.Dock = DockStyle.Fill;
            pnlScroll.Location = new Point(10, 4);
            pnlScroll.Name = "pnlScroll";
            pnlScroll.Size = new Size(1235, 426);
            pnlScroll.TabIndex = 0;
            // 
            // tlpGraficos
            // 
            tlpGraficos.ColumnCount = 2;
            tlpGraficos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpGraficos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpGraficos.Controls.Add(grpGrafico1, 0, 0);
            tlpGraficos.Controls.Add(grpGrafico2, 1, 0);
            tlpGraficos.Controls.Add(grpGrafico3, 0, 1);
            tlpGraficos.Controls.Add(grpGrafico4, 1, 1);
            tlpGraficos.Controls.Add(grpGrafico5, 0, 2);
            tlpGraficos.Controls.Add(grpGrafico6, 1, 2);
            tlpGraficos.Dock = DockStyle.Top;
            tlpGraficos.Location = new Point(0, 0);
            tlpGraficos.Name = "tlpGraficos";
            tlpGraficos.RowCount = 3;
            tlpGraficos.RowStyles.Add(new RowStyle(SizeType.Absolute, 340F));
            tlpGraficos.RowStyles.Add(new RowStyle(SizeType.Absolute, 340F));
            tlpGraficos.RowStyles.Add(new RowStyle(SizeType.Absolute, 340F));
            tlpGraficos.Size = new Size(1214, 1020);
            tlpGraficos.TabIndex = 0;
            // 
            // grpGrafico1
            // 
            grpGrafico1.Controls.Add(pnlGrafico1);
            grpGrafico1.Controls.Add(pnlOpciones1);
            grpGrafico1.Dock = DockStyle.Fill;
            grpGrafico1.Location = new Point(3, 3);
            grpGrafico1.Name = "grpGrafico1";
            grpGrafico1.Padding = new Padding(8, 6, 8, 8);
            grpGrafico1.Size = new Size(601, 334);
            grpGrafico1.TabIndex = 0;
            grpGrafico1.TabStop = false;
            grpGrafico1.Text = "1. Análisis horizontal y vertical (BG / ER)";
            // 
            // pnlGrafico1
            // 
            pnlGrafico1.BackColor = Color.FromArgb(255, 255, 255);
            pnlGrafico1.BorderStyle = BorderStyle.FixedSingle;
            pnlGrafico1.Controls.Add(lblAreaGrafico1);
            pnlGrafico1.Dock = DockStyle.Fill;
            pnlGrafico1.Location = new Point(8, 84);
            pnlGrafico1.Name = "pnlGrafico1";
            pnlGrafico1.Size = new Size(585, 242);
            pnlGrafico1.TabIndex = 0;
            // 
            // lblAreaGrafico1
            // 
            lblAreaGrafico1.Dock = DockStyle.Fill;
            lblAreaGrafico1.ForeColor = Color.FromArgb(192, 192, 192);
            lblAreaGrafico1.Location = new Point(0, 0);
            lblAreaGrafico1.Name = "lblAreaGrafico1";
            lblAreaGrafico1.Size = new Size(583, 240);
            lblAreaGrafico1.TabIndex = 0;
            lblAreaGrafico1.Text = "Área del gráfico";
            lblAreaGrafico1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlOpciones1
            // 
            pnlOpciones1.Controls.Add(label1);
            pnlOpciones1.Controls.Add(cmbTipoGrafico1);
            pnlOpciones1.Controls.Add(label2);
            pnlOpciones1.Controls.Add(cmbEstiloGrafico1);
            pnlOpciones1.Dock = DockStyle.Top;
            pnlOpciones1.Location = new Point(8, 28);
            pnlOpciones1.Name = "pnlOpciones1";
            pnlOpciones1.Size = new Size(585, 56);
            pnlOpciones1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.FromArgb(70, 80, 100);
            label1.Location = new Point(4, 4);
            label1.Name = "label1";
            label1.Size = new Size(40, 21);
            label1.TabIndex = 0;
            label1.Text = "Tipo";
            // 
            // cmbTipoGrafico1
            // 
            cmbTipoGrafico1.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoGrafico1.FormattingEnabled = true;
            cmbTipoGrafico1.Items.AddRange(new object[] { "Barras", "Líneas", "Araña", "Pastel", "Polar" });
            cmbTipoGrafico1.Location = new Point(4, 22);
            cmbTipoGrafico1.Name = "cmbTipoGrafico1";
            cmbTipoGrafico1.Size = new Size(110, 29);
            cmbTipoGrafico1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.FromArgb(70, 80, 100);
            label2.Location = new Point(130, 4);
            label2.Name = "label2";
            label2.Size = new Size(47, 21);
            label2.TabIndex = 2;
            label2.Text = "Estilo";
            // 
            // cmbEstiloGrafico1
            // 
            cmbEstiloGrafico1.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstiloGrafico1.FormattingEnabled = true;
            cmbEstiloGrafico1.Items.AddRange(new object[] { "Clásico", "Pastel", "Alto contraste" });
            cmbEstiloGrafico1.Location = new Point(130, 22);
            cmbEstiloGrafico1.Name = "cmbEstiloGrafico1";
            cmbEstiloGrafico1.Size = new Size(130, 29);
            cmbEstiloGrafico1.TabIndex = 3;
            // 
            // grpGrafico2
            // 
            grpGrafico2.Controls.Add(pnlGrafico2);
            grpGrafico2.Controls.Add(pnlOpciones2);
            grpGrafico2.Dock = DockStyle.Fill;
            grpGrafico2.Location = new Point(610, 3);
            grpGrafico2.Name = "grpGrafico2";
            grpGrafico2.Padding = new Padding(8, 6, 8, 8);
            grpGrafico2.Size = new Size(601, 334);
            grpGrafico2.TabIndex = 1;
            grpGrafico2.TabStop = false;
            grpGrafico2.Text = "2. Razones financieras (comparado)";
            // 
            // pnlGrafico2
            // 
            pnlGrafico2.BackColor = Color.FromArgb(255, 255, 255);
            pnlGrafico2.BorderStyle = BorderStyle.FixedSingle;
            pnlGrafico2.Controls.Add(lblAreaGrafico2);
            pnlGrafico2.Dock = DockStyle.Fill;
            pnlGrafico2.Location = new Point(8, 84);
            pnlGrafico2.Name = "pnlGrafico2";
            pnlGrafico2.Size = new Size(585, 242);
            pnlGrafico2.TabIndex = 0;
            // 
            // lblAreaGrafico2
            // 
            lblAreaGrafico2.Dock = DockStyle.Fill;
            lblAreaGrafico2.ForeColor = Color.FromArgb(192, 192, 192);
            lblAreaGrafico2.Location = new Point(0, 0);
            lblAreaGrafico2.Name = "lblAreaGrafico2";
            lblAreaGrafico2.Size = new Size(583, 240);
            lblAreaGrafico2.TabIndex = 0;
            lblAreaGrafico2.Text = "Área del gráfico";
            lblAreaGrafico2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlOpciones2
            // 
            pnlOpciones2.Controls.Add(label3);
            pnlOpciones2.Controls.Add(cmbTipoGrafico2);
            pnlOpciones2.Controls.Add(label4);
            pnlOpciones2.Controls.Add(cmbEstiloGrafico2);
            pnlOpciones2.Dock = DockStyle.Top;
            pnlOpciones2.Location = new Point(8, 28);
            pnlOpciones2.Name = "pnlOpciones2";
            pnlOpciones2.Size = new Size(585, 56);
            pnlOpciones2.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.FromArgb(70, 80, 100);
            label3.Location = new Point(4, 4);
            label3.Name = "label3";
            label3.Size = new Size(40, 21);
            label3.TabIndex = 0;
            label3.Text = "Tipo";
            // 
            // cmbTipoGrafico2
            // 
            cmbTipoGrafico2.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoGrafico2.FormattingEnabled = true;
            cmbTipoGrafico2.Items.AddRange(new object[] { "Araña", "Barras", "Líneas", "Polar", "Pastel" });
            cmbTipoGrafico2.Location = new Point(4, 22);
            cmbTipoGrafico2.Name = "cmbTipoGrafico2";
            cmbTipoGrafico2.Size = new Size(110, 29);
            cmbTipoGrafico2.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.FromArgb(70, 80, 100);
            label4.Location = new Point(130, 4);
            label4.Name = "label4";
            label4.Size = new Size(47, 21);
            label4.TabIndex = 2;
            label4.Text = "Estilo";
            // 
            // cmbEstiloGrafico2
            // 
            cmbEstiloGrafico2.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstiloGrafico2.FormattingEnabled = true;
            cmbEstiloGrafico2.Items.AddRange(new object[] { "Clásico", "Pastel", "Alto contraste" });
            cmbEstiloGrafico2.Location = new Point(130, 22);
            cmbEstiloGrafico2.Name = "cmbEstiloGrafico2";
            cmbEstiloGrafico2.Size = new Size(130, 29);
            cmbEstiloGrafico2.TabIndex = 3;
            // 
            // grpGrafico3
            // 
            grpGrafico3.Controls.Add(pnlGrafico3);
            grpGrafico3.Controls.Add(pnlOpciones3);
            grpGrafico3.Dock = DockStyle.Fill;
            grpGrafico3.Location = new Point(3, 343);
            grpGrafico3.Name = "grpGrafico3";
            grpGrafico3.Padding = new Padding(8, 6, 8, 8);
            grpGrafico3.Size = new Size(601, 334);
            grpGrafico3.TabIndex = 2;
            grpGrafico3.TabStop = false;
            grpGrafico3.Text = "3. Capital Neto de Trabajo (CNT) y CNO";
            // 
            // pnlGrafico3
            // 
            pnlGrafico3.BackColor = Color.FromArgb(255, 255, 255);
            pnlGrafico3.BorderStyle = BorderStyle.FixedSingle;
            pnlGrafico3.Controls.Add(lblAreaGrafico3);
            pnlGrafico3.Dock = DockStyle.Fill;
            pnlGrafico3.Location = new Point(8, 84);
            pnlGrafico3.Name = "pnlGrafico3";
            pnlGrafico3.Size = new Size(585, 242);
            pnlGrafico3.TabIndex = 0;
            // 
            // lblAreaGrafico3
            // 
            lblAreaGrafico3.Dock = DockStyle.Fill;
            lblAreaGrafico3.ForeColor = Color.FromArgb(192, 192, 192);
            lblAreaGrafico3.Location = new Point(0, 0);
            lblAreaGrafico3.Name = "lblAreaGrafico3";
            lblAreaGrafico3.Size = new Size(583, 240);
            lblAreaGrafico3.TabIndex = 0;
            lblAreaGrafico3.Text = "Área del gráfico";
            lblAreaGrafico3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlOpciones3
            // 
            pnlOpciones3.Controls.Add(label5);
            pnlOpciones3.Controls.Add(cmbTipoGrafico3);
            pnlOpciones3.Controls.Add(label6);
            pnlOpciones3.Controls.Add(cmbEstiloGrafico3);
            pnlOpciones3.Dock = DockStyle.Top;
            pnlOpciones3.Location = new Point(8, 28);
            pnlOpciones3.Name = "pnlOpciones3";
            pnlOpciones3.Size = new Size(585, 56);
            pnlOpciones3.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.FromArgb(70, 80, 100);
            label5.Location = new Point(4, 4);
            label5.Name = "label5";
            label5.Size = new Size(40, 21);
            label5.TabIndex = 0;
            label5.Text = "Tipo";
            // 
            // cmbTipoGrafico3
            // 
            cmbTipoGrafico3.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoGrafico3.FormattingEnabled = true;
            cmbTipoGrafico3.Items.AddRange(new object[] { "Barras", "Líneas", "Araña", "Polar", "Pastel" });
            cmbTipoGrafico3.Location = new Point(4, 22);
            cmbTipoGrafico3.Name = "cmbTipoGrafico3";
            cmbTipoGrafico3.Size = new Size(110, 29);
            cmbTipoGrafico3.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.FromArgb(70, 80, 100);
            label6.Location = new Point(130, 4);
            label6.Name = "label6";
            label6.Size = new Size(47, 21);
            label6.TabIndex = 2;
            label6.Text = "Estilo";
            // 
            // cmbEstiloGrafico3
            // 
            cmbEstiloGrafico3.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstiloGrafico3.FormattingEnabled = true;
            cmbEstiloGrafico3.Items.AddRange(new object[] { "Clásico", "Pastel", "Alto contraste" });
            cmbEstiloGrafico3.Location = new Point(130, 22);
            cmbEstiloGrafico3.Name = "cmbEstiloGrafico3";
            cmbEstiloGrafico3.Size = new Size(130, 29);
            cmbEstiloGrafico3.TabIndex = 3;
            // 
            // grpGrafico4
            // 
            grpGrafico4.Controls.Add(pnlGrafico4);
            grpGrafico4.Controls.Add(pnlOpciones4);
            grpGrafico4.Dock = DockStyle.Fill;
            grpGrafico4.Location = new Point(610, 343);
            grpGrafico4.Name = "grpGrafico4";
            grpGrafico4.Padding = new Padding(8, 6, 8, 8);
            grpGrafico4.Size = new Size(601, 334);
            grpGrafico4.TabIndex = 3;
            grpGrafico4.TabStop = false;
            grpGrafico4.Text = "4. EOAF (Origen y Aplicación de Fondos)";
            // 
            // pnlGrafico4
            // 
            pnlGrafico4.BackColor = Color.FromArgb(255, 255, 255);
            pnlGrafico4.BorderStyle = BorderStyle.FixedSingle;
            pnlGrafico4.Controls.Add(lblAreaGrafico4);
            pnlGrafico4.Dock = DockStyle.Fill;
            pnlGrafico4.Location = new Point(8, 84);
            pnlGrafico4.Name = "pnlGrafico4";
            pnlGrafico4.Size = new Size(585, 242);
            pnlGrafico4.TabIndex = 0;
            // 
            // lblAreaGrafico4
            // 
            lblAreaGrafico4.Dock = DockStyle.Fill;
            lblAreaGrafico4.ForeColor = Color.FromArgb(192, 192, 192);
            lblAreaGrafico4.Location = new Point(0, 0);
            lblAreaGrafico4.Name = "lblAreaGrafico4";
            lblAreaGrafico4.Size = new Size(583, 240);
            lblAreaGrafico4.TabIndex = 0;
            lblAreaGrafico4.Text = "Área del gráfico";
            lblAreaGrafico4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlOpciones4
            // 
            pnlOpciones4.Controls.Add(label7);
            pnlOpciones4.Controls.Add(cmbTipoGrafico4);
            pnlOpciones4.Controls.Add(label8);
            pnlOpciones4.Controls.Add(cmbEstiloGrafico4);
            pnlOpciones4.Dock = DockStyle.Top;
            pnlOpciones4.Location = new Point(8, 28);
            pnlOpciones4.Name = "pnlOpciones4";
            pnlOpciones4.Size = new Size(585, 56);
            pnlOpciones4.TabIndex = 1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = Color.FromArgb(70, 80, 100);
            label7.Location = new Point(4, 4);
            label7.Name = "label7";
            label7.Size = new Size(40, 21);
            label7.TabIndex = 0;
            label7.Text = "Tipo";
            // 
            // cmbTipoGrafico4
            // 
            cmbTipoGrafico4.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoGrafico4.FormattingEnabled = true;
            cmbTipoGrafico4.Items.AddRange(new object[] { "Barras", "Pastel", "Dona", "Polar", "Líneas" });
            cmbTipoGrafico4.Location = new Point(4, 22);
            cmbTipoGrafico4.Name = "cmbTipoGrafico4";
            cmbTipoGrafico4.Size = new Size(110, 29);
            cmbTipoGrafico4.TabIndex = 1;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = Color.FromArgb(70, 80, 100);
            label8.Location = new Point(130, 4);
            label8.Name = "label8";
            label8.Size = new Size(47, 21);
            label8.TabIndex = 2;
            label8.Text = "Estilo";
            // 
            // cmbEstiloGrafico4
            // 
            cmbEstiloGrafico4.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstiloGrafico4.FormattingEnabled = true;
            cmbEstiloGrafico4.Items.AddRange(new object[] { "Clásico", "Pastel", "Alto contraste" });
            cmbEstiloGrafico4.Location = new Point(130, 22);
            cmbEstiloGrafico4.Name = "cmbEstiloGrafico4";
            cmbEstiloGrafico4.Size = new Size(130, 29);
            cmbEstiloGrafico4.TabIndex = 3;
            // 
            // grpGrafico5
            // 
            grpGrafico5.Controls.Add(pnlGrafico5);
            grpGrafico5.Controls.Add(pnlOpciones5);
            grpGrafico5.Dock = DockStyle.Fill;
            grpGrafico5.Location = new Point(3, 683);
            grpGrafico5.Name = "grpGrafico5";
            grpGrafico5.Padding = new Padding(8, 6, 8, 8);
            grpGrafico5.Size = new Size(601, 334);
            grpGrafico5.TabIndex = 4;
            grpGrafico5.TabStop = false;
            grpGrafico5.Text = "5. Estado de Flujo de Efectivo";
            // 
            // pnlGrafico5
            // 
            pnlGrafico5.BackColor = Color.FromArgb(255, 255, 255);
            pnlGrafico5.BorderStyle = BorderStyle.FixedSingle;
            pnlGrafico5.Controls.Add(lblAreaGrafico5);
            pnlGrafico5.Dock = DockStyle.Fill;
            pnlGrafico5.Location = new Point(8, 84);
            pnlGrafico5.Name = "pnlGrafico5";
            pnlGrafico5.Size = new Size(585, 242);
            pnlGrafico5.TabIndex = 0;
            // 
            // lblAreaGrafico5
            // 
            lblAreaGrafico5.Dock = DockStyle.Fill;
            lblAreaGrafico5.ForeColor = Color.FromArgb(192, 192, 192);
            lblAreaGrafico5.Location = new Point(0, 0);
            lblAreaGrafico5.Name = "lblAreaGrafico5";
            lblAreaGrafico5.Size = new Size(583, 240);
            lblAreaGrafico5.TabIndex = 0;
            lblAreaGrafico5.Text = "Área del gráfico";
            lblAreaGrafico5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlOpciones5
            // 
            pnlOpciones5.Controls.Add(label9);
            pnlOpciones5.Controls.Add(cmbTipoGrafico5);
            pnlOpciones5.Controls.Add(label10);
            pnlOpciones5.Controls.Add(cmbEstiloGrafico5);
            pnlOpciones5.Dock = DockStyle.Top;
            pnlOpciones5.Location = new Point(8, 28);
            pnlOpciones5.Name = "pnlOpciones5";
            pnlOpciones5.Size = new Size(585, 56);
            pnlOpciones5.TabIndex = 1;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.ForeColor = Color.FromArgb(70, 80, 100);
            label9.Location = new Point(4, 4);
            label9.Name = "label9";
            label9.Size = new Size(40, 21);
            label9.TabIndex = 0;
            label9.Text = "Tipo";
            // 
            // cmbTipoGrafico5
            // 
            cmbTipoGrafico5.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoGrafico5.FormattingEnabled = true;
            cmbTipoGrafico5.Items.AddRange(new object[] { "Barras", "Líneas", "Pastel", "Dona", "Polar" });
            cmbTipoGrafico5.Location = new Point(4, 22);
            cmbTipoGrafico5.Name = "cmbTipoGrafico5";
            cmbTipoGrafico5.Size = new Size(110, 29);
            cmbTipoGrafico5.TabIndex = 1;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.ForeColor = Color.FromArgb(70, 80, 100);
            label10.Location = new Point(130, 4);
            label10.Name = "label10";
            label10.Size = new Size(47, 21);
            label10.TabIndex = 2;
            label10.Text = "Estilo";
            // 
            // cmbEstiloGrafico5
            // 
            cmbEstiloGrafico5.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstiloGrafico5.FormattingEnabled = true;
            cmbEstiloGrafico5.Items.AddRange(new object[] { "Clásico", "Pastel", "Alto contraste" });
            cmbEstiloGrafico5.Location = new Point(130, 22);
            cmbEstiloGrafico5.Name = "cmbEstiloGrafico5";
            cmbEstiloGrafico5.Size = new Size(130, 29);
            cmbEstiloGrafico5.TabIndex = 3;
            // 
            // grpGrafico6
            // 
            grpGrafico6.Controls.Add(pnlGrafico6);
            grpGrafico6.Controls.Add(pnlOpciones6);
            grpGrafico6.Dock = DockStyle.Fill;
            grpGrafico6.Location = new Point(610, 683);
            grpGrafico6.Name = "grpGrafico6";
            grpGrafico6.Padding = new Padding(8, 6, 8, 8);
            grpGrafico6.Size = new Size(601, 334);
            grpGrafico6.TabIndex = 5;
            grpGrafico6.TabStop = false;
            grpGrafico6.Text = "6. Modelo DuPont (comparado)";
            // 
            // pnlGrafico6
            // 
            pnlGrafico6.BackColor = Color.FromArgb(255, 255, 255);
            pnlGrafico6.BorderStyle = BorderStyle.FixedSingle;
            pnlGrafico6.Controls.Add(lblAreaGrafico6);
            pnlGrafico6.Dock = DockStyle.Fill;
            pnlGrafico6.Location = new Point(8, 84);
            pnlGrafico6.Name = "pnlGrafico6";
            pnlGrafico6.Size = new Size(585, 242);
            pnlGrafico6.TabIndex = 0;
            // 
            // lblAreaGrafico6
            // 
            lblAreaGrafico6.Dock = DockStyle.Fill;
            lblAreaGrafico6.ForeColor = Color.FromArgb(192, 192, 192);
            lblAreaGrafico6.Location = new Point(0, 0);
            lblAreaGrafico6.Name = "lblAreaGrafico6";
            lblAreaGrafico6.Size = new Size(583, 240);
            lblAreaGrafico6.TabIndex = 0;
            lblAreaGrafico6.Text = "Área del gráfico";
            lblAreaGrafico6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlOpciones6
            // 
            pnlOpciones6.Controls.Add(label11);
            pnlOpciones6.Controls.Add(cmbTipoGrafico6);
            pnlOpciones6.Controls.Add(label12);
            pnlOpciones6.Controls.Add(cmbEstiloGrafico6);
            pnlOpciones6.Dock = DockStyle.Top;
            pnlOpciones6.Location = new Point(8, 28);
            pnlOpciones6.Name = "pnlOpciones6";
            pnlOpciones6.Size = new Size(585, 56);
            pnlOpciones6.TabIndex = 1;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.ForeColor = Color.FromArgb(70, 80, 100);
            label11.Location = new Point(4, 4);
            label11.Name = "label11";
            label11.Size = new Size(40, 21);
            label11.TabIndex = 0;
            label11.Text = "Tipo";
            // 
            // cmbTipoGrafico6
            // 
            cmbTipoGrafico6.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoGrafico6.FormattingEnabled = true;
            cmbTipoGrafico6.Items.AddRange(new object[] { "Barras", "Líneas", "Araña", "Polar", "Pastel" });
            cmbTipoGrafico6.Location = new Point(4, 22);
            cmbTipoGrafico6.Name = "cmbTipoGrafico6";
            cmbTipoGrafico6.Size = new Size(110, 29);
            cmbTipoGrafico6.TabIndex = 1;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.ForeColor = Color.FromArgb(70, 80, 100);
            label12.Location = new Point(130, 4);
            label12.Name = "label12";
            label12.Size = new Size(47, 21);
            label12.TabIndex = 2;
            label12.Text = "Estilo";
            // 
            // cmbEstiloGrafico6
            // 
            cmbEstiloGrafico6.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstiloGrafico6.FormattingEnabled = true;
            cmbEstiloGrafico6.Items.AddRange(new object[] { "Clásico", "Pastel", "Alto contraste" });
            cmbEstiloGrafico6.Location = new Point(130, 22);
            cmbEstiloGrafico6.Name = "cmbEstiloGrafico6";
            cmbEstiloGrafico6.Size = new Size(130, 29);
            cmbEstiloGrafico6.TabIndex = 3;
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Controls.Add(lblDescripcion);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1255, 66);
            pnlHeader.TabIndex = 2;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(24, 72, 140);
            lblTitulo.Location = new Point(14, 8);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(287, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gráficos por categoría";
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.ForeColor = Color.FromArgb(105, 105, 105);
            lblDescripcion.Location = new Point(16, 42);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(306, 21);
            lblDescripcion.TabIndex = 1;
            lblDescripcion.Text = "Seis paneles de visualización configurables";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.ForeColor = Color.FromArgb(70, 80, 100);
            label13.Location = new Point(10, 16);
            label13.Name = "label13";
            label13.Size = new Size(99, 21);
            label13.TabIndex = 0;
            label13.Text = "Periodo base";
            // 
            // cmbPeriodoBaseGraf
            // 
            cmbPeriodoBaseGraf.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPeriodoBaseGraf.FormattingEnabled = true;
            cmbPeriodoBaseGraf.Items.AddRange(new object[] { "2023", "2024", "2025" });
            cmbPeriodoBaseGraf.Location = new Point(10, 40);
            cmbPeriodoBaseGraf.Name = "cmbPeriodoBaseGraf";
            cmbPeriodoBaseGraf.Size = new Size(100, 29);
            cmbPeriodoBaseGraf.TabIndex = 1;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.ForeColor = Color.FromArgb(70, 80, 100);
            label14.Location = new Point(125, 16);
            label14.Name = "label14";
            label14.Size = new Size(146, 21);
            label14.TabIndex = 2;
            label14.Text = "Periodo comparado";
            // 
            // cmbPeriodoCompGraf
            // 
            cmbPeriodoCompGraf.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPeriodoCompGraf.FormattingEnabled = true;
            cmbPeriodoCompGraf.Items.AddRange(new object[] { "2023", "2024", "2025" });
            cmbPeriodoCompGraf.Location = new Point(125, 40);
            cmbPeriodoCompGraf.Name = "cmbPeriodoCompGraf";
            cmbPeriodoCompGraf.Size = new Size(110, 29);
            cmbPeriodoCompGraf.TabIndex = 3;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.ForeColor = Color.FromArgb(70, 80, 100);
            label15.Location = new Point(291, 14);
            label15.Name = "label15";
            label15.Size = new Size(50, 21);
            label15.TabIndex = 4;
            label15.Text = "Top N";
            // 
            // cmbTopN
            // 
            cmbTopN.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTopN.FormattingEnabled = true;
            cmbTopN.Items.AddRange(new object[] { "5", "10", "15", "20" });
            cmbTopN.Location = new Point(291, 38);
            cmbTopN.Name = "cmbTopN";
            cmbTopN.Size = new Size(60, 29);
            cmbTopN.TabIndex = 5;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.ForeColor = Color.FromArgb(70, 80, 100);
            label16.Location = new Point(370, 14);
            label16.Name = "label16";
            label16.Size = new Size(96, 21);
            label16.TabIndex = 6;
            label16.Text = "Ordenar por";
            // 
            // cmbOrdenarPor
            // 
            cmbOrdenarPor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOrdenarPor.FormattingEnabled = true;
            cmbOrdenarPor.Items.AddRange(new object[] { "Variación absoluta", "Variación porcentual", "Valor" });
            cmbOrdenarPor.Location = new Point(370, 38);
            cmbOrdenarPor.Name = "cmbOrdenarPor";
            cmbOrdenarPor.Size = new Size(160, 29);
            cmbOrdenarPor.TabIndex = 7;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.ForeColor = Color.FromArgb(70, 80, 100);
            label17.Location = new Point(548, 14);
            label17.Name = "label17";
            label17.Size = new Size(65, 21);
            label17.TabIndex = 8;
            label17.Text = "Mostrar";
            // 
            // cmbMostrar
            // 
            cmbMostrar.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMostrar.FormattingEnabled = true;
            cmbMostrar.Items.AddRange(new object[] { "Monto", "Porcentaje" });
            cmbMostrar.Location = new Point(548, 38);
            cmbMostrar.Name = "cmbMostrar";
            cmbMostrar.Size = new Size(100, 29);
            cmbMostrar.TabIndex = 9;
            // 
            // btnActualizarTodos
            // 
            btnActualizarTodos.BackColor = Color.FromArgb(24, 72, 140);
            btnActualizarTodos.Cursor = Cursors.Hand;
            btnActualizarTodos.FlatAppearance.BorderColor = Color.FromArgb(24, 72, 140);
            btnActualizarTodos.FlatStyle = FlatStyle.Flat;
            btnActualizarTodos.ForeColor = Color.FromArgb(255, 255, 255);
            btnActualizarTodos.Location = new Point(665, 38);
            btnActualizarTodos.Name = "btnActualizarTodos";
            btnActualizarTodos.Size = new Size(130, 30);
            btnActualizarTodos.TabIndex = 10;
            btnActualizarTodos.Text = "Actualizar todos";
            btnActualizarTodos.UseVisualStyleBackColor = false;
            // 
            // grpFiltros
            // 
            grpFiltros.Controls.Add(label13);
            grpFiltros.Controls.Add(cmbPeriodoBaseGraf);
            grpFiltros.Controls.Add(label14);
            grpFiltros.Controls.Add(cmbPeriodoCompGraf);
            grpFiltros.Controls.Add(label15);
            grpFiltros.Controls.Add(cmbTopN);
            grpFiltros.Controls.Add(label16);
            grpFiltros.Controls.Add(cmbOrdenarPor);
            grpFiltros.Controls.Add(label17);
            grpFiltros.Controls.Add(cmbMostrar);
            grpFiltros.Controls.Add(btnActualizarTodos);
            grpFiltros.Location = new Point(10, 6);
            grpFiltros.Name = "grpFiltros";
            grpFiltros.Size = new Size(825, 80);
            grpFiltros.TabIndex = 0;
            grpFiltros.TabStop = false;
            grpFiltros.Text = "Filtros";
            // 
            // pnlToolbar
            // 
            pnlToolbar.AutoScroll = true;
            pnlToolbar.Controls.Add(grpFiltros);
            pnlToolbar.Dock = DockStyle.Top;
            pnlToolbar.Location = new Point(0, 66);
            pnlToolbar.Name = "pnlToolbar";
            pnlToolbar.Size = new Size(1255, 94);
            pnlToolbar.TabIndex = 1;
            // 
            // pnlBody
            // 
            pnlBody.Controls.Add(pnlScroll);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 160);
            pnlBody.Name = "pnlBody";
            pnlBody.Padding = new Padding(10, 4, 10, 10);
            pnlBody.Size = new Size(1255, 440);
            pnlBody.TabIndex = 0;
            // 
            // GraficosControl
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 246, 250);
            Controls.Add(pnlBody);
            Controls.Add(pnlToolbar);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9.5F);
            Name = "GraficosControl";
            Size = new Size(1255, 600);
            pnlScroll.ResumeLayout(false);
            tlpGraficos.ResumeLayout(false);
            grpGrafico1.ResumeLayout(false);
            pnlGrafico1.ResumeLayout(false);
            pnlOpciones1.ResumeLayout(false);
            pnlOpciones1.PerformLayout();
            grpGrafico2.ResumeLayout(false);
            pnlGrafico2.ResumeLayout(false);
            pnlOpciones2.ResumeLayout(false);
            pnlOpciones2.PerformLayout();
            grpGrafico3.ResumeLayout(false);
            pnlGrafico3.ResumeLayout(false);
            pnlOpciones3.ResumeLayout(false);
            pnlOpciones3.PerformLayout();
            grpGrafico4.ResumeLayout(false);
            pnlGrafico4.ResumeLayout(false);
            pnlOpciones4.ResumeLayout(false);
            pnlOpciones4.PerformLayout();
            grpGrafico5.ResumeLayout(false);
            pnlGrafico5.ResumeLayout(false);
            pnlOpciones5.ResumeLayout(false);
            pnlOpciones5.PerformLayout();
            grpGrafico6.ResumeLayout(false);
            pnlGrafico6.ResumeLayout(false);
            pnlOpciones6.ResumeLayout(false);
            pnlOpciones6.PerformLayout();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            grpFiltros.ResumeLayout(false);
            grpFiltros.PerformLayout();
            pnlToolbar.ResumeLayout(false);
            pnlBody.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlScroll;
        private System.Windows.Forms.TableLayoutPanel tlpGraficos;
        private System.Windows.Forms.GroupBox grpGrafico1;
        private System.Windows.Forms.Panel pnlGrafico1;
        private System.Windows.Forms.Label lblAreaGrafico1;
        private System.Windows.Forms.Panel pnlOpciones1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTipoGrafico1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbEstiloGrafico1;
        private System.Windows.Forms.GroupBox grpGrafico2;
        private System.Windows.Forms.Panel pnlGrafico2;
        private System.Windows.Forms.Label lblAreaGrafico2;
        private System.Windows.Forms.Panel pnlOpciones2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbTipoGrafico2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbEstiloGrafico2;
        private System.Windows.Forms.GroupBox grpGrafico3;
        private System.Windows.Forms.Panel pnlGrafico3;
        private System.Windows.Forms.Label lblAreaGrafico3;
        private System.Windows.Forms.Panel pnlOpciones3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbTipoGrafico3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbEstiloGrafico3;
        private System.Windows.Forms.GroupBox grpGrafico4;
        private System.Windows.Forms.Panel pnlGrafico4;
        private System.Windows.Forms.Label lblAreaGrafico4;
        private System.Windows.Forms.Panel pnlOpciones4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbTipoGrafico4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbEstiloGrafico4;
        private System.Windows.Forms.GroupBox grpGrafico5;
        private System.Windows.Forms.Panel pnlGrafico5;
        private System.Windows.Forms.Label lblAreaGrafico5;
        private System.Windows.Forms.Panel pnlOpciones5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbTipoGrafico5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbEstiloGrafico5;
        private System.Windows.Forms.GroupBox grpGrafico6;
        private System.Windows.Forms.Panel pnlGrafico6;
        private System.Windows.Forms.Label lblAreaGrafico6;
        private System.Windows.Forms.Panel pnlOpciones6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbTipoGrafico6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbEstiloGrafico6;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbPeriodoBaseGraf;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbPeriodoCompGraf;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cmbTopN;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbOrdenarPor;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cmbMostrar;
        private System.Windows.Forms.Button btnActualizarTodos;
        private System.Windows.Forms.GroupBox grpFiltros;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Panel pnlBody;
    }
}
