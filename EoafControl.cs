using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LookScan
{
    public partial class EoafControl : UserControl
    {
        public EoafControl()
        {
            InitializeComponent();
            if (Util.EnDiseno) return;

            Almacen.DatosCambiaron += CargarCombosEoaf;
            Almacen.PeriodosCambiaron += CargarCombosEoaf;
            Almacen.ActivoCambio += CargarCombosEoaf;

            CargarCombosEoaf();
        }

        private void CargarCombosEoaf()
        {
            string baseAnterior = cmbPeriodoBaseEoaf.SelectedItem as string;
            string compAnterior = cmbPeriodoCompEoaf.SelectedItem as string;

            cmbPeriodoBaseEoaf.Items.Clear();
            cmbPeriodoCompEoaf.Items.Clear();

            // Se ofrecen primero los periodos con datos; si no hay, se muestran todos.
            var nombres = Almacen.Periodos
                .Where(p => p.TieneDatos)
                .Select(p => p.Nombre)
                .ToList();

            if (nombres.Count == 0) nombres = Almacen.Nombres.ToList();

            foreach (var nombre in nombres)
            {
                cmbPeriodoBaseEoaf.Items.Add(nombre);
                cmbPeriodoCompEoaf.Items.Add(nombre);
            }

            if (nombres.Count == 0) return;

            // Periodo comparado: el activo si tiene datos; si no, el último disponible.
            string comp = compAnterior;
            if (string.IsNullOrEmpty(comp) || !nombres.Any(n => Util.Igual(n, comp)))
            {
                comp = Almacen.Activo != null ? Almacen.Activo.Nombre : nombres[nombres.Count - 1];
            }

            int indiceComp = nombres.FindIndex(n => Util.Igual(n, comp));
            if (indiceComp < 0) indiceComp = nombres.Count - 1;

            // Periodo base: el anterior al comparado.
            string baseNombre = baseAnterior;
            if (string.IsNullOrEmpty(baseNombre) || !nombres.Any(n => Util.Igual(n, baseNombre)))
            {
                baseNombre = indiceComp > 0 ? nombres[indiceComp - 1] : nombres[0];
            }

            int indiceBase = nombres.FindIndex(n => Util.Igual(n, baseNombre));
            if (indiceBase < 0) indiceBase = indiceComp > 0 ? indiceComp - 1 : 0;

            cmbPeriodoBaseEoaf.SelectedIndex = indiceBase;
            cmbPeriodoCompEoaf.SelectedIndex = indiceComp;
        }

        private void btnCalcularEoaf_Click(object sender, EventArgs e)
        {
            string anioBaseStr = cmbPeriodoBaseEoaf.SelectedItem as string;
            string anioCompStr = cmbPeriodoCompEoaf.SelectedItem as string;

            var periodoBase = Almacen.Buscar(anioBaseStr);
            var periodoComp = Almacen.Buscar(anioCompStr);

            if (periodoBase == null || periodoComp == null)
            {
                MessageBox.Show("Debe seleccionar un período base y un período comparado válidos.", "LookScan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Util.Igual(periodoBase.Nombre, periodoComp.Nombre))
            {
                MessageBox.Show("Seleccione dos periodos distintos para comparar.", "LookScan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!periodoBase.TieneDatos || !periodoComp.TieneDatos)
            {
                MessageBox.Show("Uno de los periodos seleccionados no tiene cuentas. Capture datos o use «Cargar Demo».", "LookScan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dgvEoaf.Rows.Clear();

            // Encabezados siempre actualizados con los años elegidos.
            if (dgvEoaf.Columns.Count == 0)
            {
                dgvEoaf.Columns.Add("Cuenta", "Cuenta");
                dgvEoaf.Columns.Add("Clasif", "Clasif.");
                dgvEoaf.Columns.Add("Anio1", "Año 1");
                dgvEoaf.Columns.Add("Anio2", "Año 2");
                dgvEoaf.Columns.Add("Cambios", "Cambio");
                dgvEoaf.Columns.Add("Origen", "Origen");
                dgvEoaf.Columns.Add("Aplicacion", "Aplicación");
            }

            dgvEoaf.Columns[0].HeaderText = "Cuenta";
            dgvEoaf.Columns[1].HeaderText = "Clasif.";
            dgvEoaf.Columns[2].HeaderText = periodoBase.Nombre;
            dgvEoaf.Columns[3].HeaderText = periodoComp.Nombre;
            dgvEoaf.Columns[4].HeaderText = "Cambio";
            dgvEoaf.Columns[5].HeaderText = "Origen";
            dgvEoaf.Columns[6].HeaderText = "Aplicación";

            // Se comparan nombres normalizados (sin tildes, mayúsculas ni espacios repetidos).
            var montosBase = new Dictionary<string, decimal>(StringComparer.Ordinal);
            var montosComp = new Dictionary<string, decimal>(StringComparer.Ordinal);
            var representantes = new Dictionary<string, Cuenta>(StringComparer.Ordinal);

            foreach (Cuenta cuenta in periodoBase.BG)
            {
                string clave = Util.Clave(cuenta.Nombre);
                if (clave.Length == 0) continue;

                if (!montosBase.ContainsKey(clave)) montosBase[clave] = 0m;
                montosBase[clave] += cuenta.Monto;

                if (!representantes.ContainsKey(clave)) representantes[clave] = cuenta;
            }

            foreach (Cuenta cuenta in periodoComp.BG)
            {
                string clave = Util.Clave(cuenta.Nombre);
                if (clave.Length == 0) continue;

                if (!montosComp.ContainsKey(clave)) montosComp[clave] = 0m;
                montosComp[clave] += cuenta.Monto;

                if (!representantes.ContainsKey(clave)) representantes[clave] = cuenta;
            }

            var claves = montosBase.Keys
                .Union(montosComp.Keys)
                .OrderBy(k => Clasif.Orden(representantes[k].Clasificacion))
                .ThenBy(k => k)
                .ToList();

            decimal totalOrigen = 0m;
            decimal totalAplicacion = 0m;

            foreach (string clave in claves)
            {
                decimal monto1 = montosBase.ContainsKey(clave) ? montosBase[clave] : 0m;
                decimal monto2 = montosComp.ContainsKey(clave) ? montosComp[clave] : 0m;
                decimal cambio = monto2 - monto1;

                if (cambio == 0m) continue;

                Cuenta cuenta = representantes[clave];
                string clasificacion = cuenta.Clasificacion ?? string.Empty;

                decimal origen = 0m;
                decimal aplicacion = 0m;

                if (Clasif.EsActivo(clasificacion))
                {
                    // Aumento de activo = aplicación; disminución = origen.
                    if (cambio > 0m) aplicacion = cambio;
                    else origen = -cambio;
                }
                else if (Clasif.EsPasivo(clasificacion) || Clasif.EsPatrimonio(clasificacion))
                {
                    // Aumento de pasivo/patrimonio = origen; disminución = aplicación.
                    if (cambio > 0m) origen = cambio;
                    else aplicacion = -cambio;
                }

                totalOrigen += origen;
                totalAplicacion += aplicacion;

                dgvEoaf.Rows.Add(
                    cuenta.Nombre,
                    clasificacion,
                    Util.Monto(monto1),
                    Util.Monto(monto2),
                    Util.Monto(cambio),
                    origen > 0m ? Util.Monto(origen) : string.Empty,
                    aplicacion > 0m ? Util.Monto(aplicacion) : string.Empty);
            }

            int filaTotal = dgvEoaf.Rows.Add(
                "TOTALES",
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                Util.Monto(totalOrigen),
                Util.Monto(totalAplicacion));

            dgvEoaf.Rows[filaTotal].DefaultCellStyle.Font =
                new System.Drawing.Font(dgvEoaf.Font, System.Drawing.FontStyle.Bold);

            int filaDiferencia = dgvEoaf.Rows.Add(
                "DIFERENCIA (Origen - Aplicación)",
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                Util.Monto(totalOrigen - totalAplicacion),
                string.Empty);

            dgvEoaf.Rows[filaDiferencia].DefaultCellStyle.Font =
                new System.Drawing.Font(dgvEoaf.Font, System.Drawing.FontStyle.Bold);
        }
    }
}
