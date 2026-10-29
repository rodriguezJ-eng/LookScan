using System;
using System.Linq;
using System.Windows.Forms;

namespace LookScan
{
    public partial class RazonesControl : UserControl
    {
        public RazonesControl()
        {
            InitializeComponent();
            if (Util.EnDiseno) return;

            cmbPeriodoRazones.SelectedIndexChanged += (s, e) => Recalcular();
            cmbGrupoRazones.SelectedIndexChanged += (s, e) => Recalcular();
            dgvRazones.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvRazones.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            UtilUI.AlinearDerecha(dgvRazones, 2);
            UtilUI.AlinearDerecha(dgvCnt, 1);
            UtilUI.AlinearDerecha(dgvCno, 1);

            Almacen.PeriodosCambiaron += () => UtilUI.LlenarCombo(cmbPeriodoRazones, Almacen.Nombres, true);
            Almacen.DatosCambiaron += Recalcular;

            UtilUI.LlenarCombo(cmbPeriodoRazones, Almacen.Nombres, true, false);
            Recalcular();
        }

        void Recalcular()
        {
            dgvRazones.Rows.Clear();
            dgvCnt.Rows.Clear();
            dgvCno.Rows.Clear();
            var p = Almacen.Buscar(cmbPeriodoRazones.SelectedItem as string);
            if (p == null || !p.TieneDatos) return;

            string grupo = cmbGrupoRazones.SelectedItem as string ?? "Todas";
            foreach (var r in Calculos.Razones(p).Where(x => grupo == "Todas" || Util.Igual(x.Grupo, grupo)))
                dgvRazones.Rows.Add(r.Nombre, r.Grupo, r.ValorTexto, r.Interpretacion);

            foreach (var kv in Calculos.Cnt(p)) dgvCnt.Rows.Add(kv.Key, kv.Value);
            foreach (var kv in Calculos.Cno(p)) dgvCno.Rows.Add(kv.Key, kv.Value);
        }
    }
}
