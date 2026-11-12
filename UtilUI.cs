using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LookScan
{
    public static class UtilUI
    {
        public static void Aviso(string mensaje)
        {
            MessageBox.Show(mensaje, "LookScan", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Presenta resúmenes extensos con jerarquía visual sin alterar su contenido.
        public static void MostrarTextoEstructurado(RichTextBox destino, string texto)
        {
            if (destino == null) return;
            destino.Clear();
            destino.BackColor = Color.White;
            destino.ForeColor = Color.FromArgb(45, 55, 72);
            destino.BorderStyle = BorderStyle.FixedSingle;
            destino.Font = new Font("Segoe UI", 10F);

            string[] lineas = (texto ?? string.Empty).Replace("\r", string.Empty).Split('\n');
            foreach (string lineaOriginal in lineas)
            {
                string linea = lineaOriginal.TrimEnd();
                bool encabezado = linea.Length > 0 &&
                    (linea == linea.ToUpperInvariant() || (linea.EndsWith(":") && !linea.StartsWith("-")));
                destino.SelectionFont = new Font("Segoe UI", encabezado ? 11F : 10F,
                    encabezado ? FontStyle.Bold : FontStyle.Regular);
                destino.SelectionColor = encabezado ? Color.FromArgb(24, 72, 140) : Color.FromArgb(45, 55, 72);
                destino.AppendText(linea + Environment.NewLine);
                if (encabezado) destino.AppendText(Environment.NewLine);
            }
            destino.SelectionStart = 0;
            destino.SelectionLength = 0;
        }

        public static void AlinearDerecha(DataGridView grid, params int[] columnas)
        {
            if (grid == null || columnas == null) return;

            foreach (int indice in columnas)
            {
                if (indice >= 0 && indice < grid.Columns.Count)
                {
                    grid.Columns[indice].DefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleRight;
                }
            }
        }

        public static void AgregarFila(DataGridView grid, bool total, params object[] valores)
        {
            if (grid == null) return;

            int indice = grid.Rows.Add(valores ?? new object[0]);
            if (!total) return;

            DataGridViewRow fila = grid.Rows[indice];
            fila.DefaultCellStyle.Font = new Font(grid.Font, FontStyle.Bold);
            fila.DefaultCellStyle.BackColor = Color.FromArgb(235, 240, 248);
        }

        public static void LlenarCombo(ComboBox combo, IEnumerable<string> nombres,
                                       bool seleccionarUltimo, bool conservarSeleccion = false)
        {
            if (combo == null) return;

            string anterior = combo.SelectedItem as string;
            List<string> lista = (nombres ?? Enumerable.Empty<string>())
                .Where(n => !string.IsNullOrEmpty(n))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();

            combo.BeginUpdate();
            try
            {
                combo.Items.Clear();
                foreach (string nombre in lista) combo.Items.Add(nombre);

                int indice = -1;

                if (conservarSeleccion && anterior != null)
                {
                    for (int i = 0; i < lista.Count; i++)
                    {
                        if (Util.Igual(lista[i], anterior))
                        {
                            indice = i;
                            break;
                        }
                    }
                }

                if (indice < 0 && lista.Count > 0)
                    indice = seleccionarUltimo ? lista.Count - 1 : 0;

                combo.SelectedIndex = indice;
            }
            finally
            {
                combo.EndUpdate();
            }
        }
    }
}
