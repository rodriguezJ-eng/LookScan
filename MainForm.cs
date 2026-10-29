using System;
using System.Windows.Forms;

namespace LookScan
{
    public partial class MainForm : Form
    {
        bool _sincronizando;

        public MainForm()
        {
            InitializeComponent();
            ucInicio.IniciarClick += (s, e) => tabControl.SelectedIndex = 1;
            if (Util.EnDiseno) return;

            txtEmpresa.TextChanged += (s, e) => Almacen.Empresa = txtEmpresa.Text.Trim();
            btnAnadirPeriodo.Click += (s, e) => AnadirPeriodo();
            cmbPeriodoActivo.SelectedIndexChanged += (s, e) =>
            {
                if (_sincronizando) return;
                var p = Almacen.Buscar(cmbPeriodoActivo.SelectedItem as string);
                if (p != null) Almacen.Activo = p;
            };
            Almacen.PeriodosCambiaron += SincronizarCombo;
            Almacen.ActivoCambio += SincronizarCombo;
            SincronizarCombo();
        }

        // Refleja en el combo "Periodo activo" la lista y el periodo activo del almacén.
        void SincronizarCombo()
        {
            _sincronizando = true;
            try
            {
                cmbPeriodoActivo.BeginUpdate();
                cmbPeriodoActivo.Items.Clear();
                foreach (var n in Almacen.Nombres) cmbPeriodoActivo.Items.Add(n);
                cmbPeriodoActivo.SelectedItem = Almacen.Activo?.Nombre;
                cmbPeriodoActivo.EndUpdate();
            }
            finally { _sincronizando = false; }
        }

        void AnadirPeriodo()
        {
            string nombre = ((int)numAnio.Value).ToString();
            var existente = Almacen.Buscar(nombre);
            if (existente != null)
            {
                Almacen.Activo = existente;
                UtilUI.Aviso("El periodo " + nombre + " ya existe; quedó como periodo activo.");
                return;
            }
            Almacen.AgregarPeriodo(nombre);
        }
    }
}
