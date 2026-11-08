using System;
using System.Windows.Forms;
using System.Linq;

namespace LookScan
{
    public partial class EoafControl : UserControl
    {
        public EoafControl()
        {
            InitializeComponent();
            CargarCombosEoaf();
        }
        private void CargarCombosEoaf()
        {
            cmbPeriodoBaseEoaf.Items.Clear();
            cmbPeriodoCompEoaf.Items.Clear();

            foreach (var nombre in Almacen.Nombres)
            {
                cmbPeriodoBaseEoaf.Items.Add(nombre);
                cmbPeriodoCompEoaf.Items.Add(nombre);
            }

            // Aseguramos que arranquen vacíos sin selección por defecto
            cmbPeriodoBaseEoaf.SelectedIndex = -1;
            cmbPeriodoBaseEoaf.Text = string.Empty;

            cmbPeriodoCompEoaf.SelectedIndex = -1;
            cmbPeriodoCompEoaf.Text = string.Empty;
        }
        private void btnCalcularEoaf_Click(object sender, EventArgs e)
        {

            // 1. Obtener los años seleccionados en los ComboBox
            string anioBaseStr = cmbPeriodoBaseEoaf.Text;
            string anioCompStr = cmbPeriodoCompEoaf.Text;

            var periodoBase = Almacen.Periodos.FirstOrDefault(p => p.Nombre == anioBaseStr);
            var periodoComp = Almacen.Periodos.FirstOrDefault(p => p.Nombre == anioCompStr);

            if (periodoBase == null || periodoComp == null)
            {
                MessageBox.Show("Debe seleccionar un período base y un período comparado válidos.", "LookScan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           
            dgvEoaf.Rows.Clear();
            if (dgvEoaf.Columns.Count == 0)
            {
                dgvEoaf.Columns.Add("Cuenta", "Cuenta");
                dgvEoaf.Columns.Add("Clasif", "Clasif.");
                dgvEoaf.Columns.Add("Anio1", anioBaseStr);
                dgvEoaf.Columns.Add("Anio2", anioCompStr);
                dgvEoaf.Columns.Add("Cambios", "Cambio");
                dgvEoaf.Columns.Add("Origen", "Origen");
                dgvEoaf.Columns.Add("Aplicacion", "Aplicación");
            }

         
            var cuentasBgBase = periodoBase.Cuentas.Where(c => c.Tipo == TipoEstado.BG);
            var cuentasBgComp = periodoComp.Cuentas.Where(c => c.Tipo == TipoEstado.BG);

            var nombresCuentas = cuentasBgBase
                .Select(c => c.Nombre)
                .Union(cuentasBgComp.Select(c => c.Nombre))
                .Distinct();

            decimal totalOrigen = 0m;
            decimal totalAplicacion = 0m;

            foreach (var nombreCuenta in nombresCuentas)
            {
                var ctaBase = cuentasBgBase.FirstOrDefault(c => c.Nombre.Equals(nombreCuenta, StringComparison.OrdinalIgnoreCase));
                var ctaComp = cuentasBgComp.FirstOrDefault(c => c.Nombre.Equals(nombreCuenta, StringComparison.OrdinalIgnoreCase));

                decimal monto1 = ctaBase != null ? ctaBase.Monto : 0m;
                decimal monto2 = ctaComp != null ? ctaComp.Monto : 0m;
                string clasif = ctaBase != null ? ctaBase.Clasificacion : (ctaComp != null ? ctaComp.Clasificacion : "");

               
                decimal cambio = monto2 - monto1;
                decimal origen = 0m;
                decimal aplicacion = 0m;

            
                string tipoClasif = clasif != null ? clasif.ToLower().Trim() : "";

                if (tipoClasif.Contains("activo"))
                {
                    // Aumento de activo = Aplicación; Disminución de activo = Origen
                    if (cambio > 0)
                        aplicacion = cambio;
                    else if (cambio < 0)
                        origen = Math.Abs(cambio);
                }
                else if (tipoClasif.Contains("pasivo") || tipoClasif.Contains("patrimonio"))
                {
                    // Aumento de pasivo/patrimonio = Origen; Disminución = Aplicación
                    if (cambio > 0)
                        origen = cambio;
                    else if (cambio < 0)
                        aplicacion = Math.Abs(cambio);
                }

                totalOrigen += origen;
                totalAplicacion += aplicacion;

              
                dgvEoaf.Rows.Add(
                    nombreCuenta,
                    clasif,
                    monto1.ToString("N2"),
                    monto2.ToString("N2"),
                    cambio.ToString("N2"),
                    origen > 0 ? origen.ToString("N2") : "",
                    aplicacion > 0 ? aplicacion.ToString("N2") : ""
                );
            }

       
            int rowIndex = dgvEoaf.Rows.Add(
                "TOTALES",
                "",
                "",
                "",
                "",
                totalOrigen.ToString("N2"),
                totalAplicacion.ToString("N2")
            );

         
            dgvEoaf.Rows[rowIndex].DefaultCellStyle.Font = new System.Drawing.Font(dgvEoaf.Font, System.Drawing.FontStyle.Bold);
        }
}
}