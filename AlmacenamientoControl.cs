using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LookScan
{
    public partial class AlmacenamientoControl : UserControl
    {
        private const int ColumnaCargar = 2;
        private const int ColumnaEliminar = 3;

        public AlmacenamientoControl()
        {
            InitializeComponent();
            if (Util.EnDiseno) return;

            btnGuardarProyecto.Click += (s, e) => GuardarProyecto();
            btnRefrescarLista.Click += (s, e) => RefrescarLista();
            dgvProyectos.CellContentClick += dgvProyectos_CellContentClick;

            txtNombreProyecto.Text = Repositorio.ProyectoActual ??
                                     Almacen.Empresa ??
                                     string.Empty;

            RefrescarLista();
        }

        //  Lista de proyectos 

        private void RefrescarLista()
        {
            dgvProyectos.Rows.Clear();

            List<ProyectoDto> proyectos;

            try
            {
                proyectos = Repositorio.Listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo leer la lista de proyectos: " + ex.Message,
                    "LookScan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (ProyectoDto proyecto in proyectos)
            {
                dgvProyectos.Rows.Add(
                    proyecto.Nombre,
                    Repositorio.FormatearFecha(proyecto.Modificado),
                    "Cargar",
                    "Eliminar");
            }

            if (proyectos.Count == 0)
                dgvProyectos.ClearSelection();
        }

        private void dgvProyectos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string nombre = dgvProyectos.Rows[e.RowIndex].Cells[0].Value as string;
            if (string.IsNullOrWhiteSpace(nombre)) return;

            if (e.ColumnIndex == ColumnaCargar)
                CargarProyecto(nombre);
            else if (e.ColumnIndex == ColumnaEliminar)
                EliminarProyecto(nombre);
        }

        // Acciones 

        private void GuardarProyecto()
        {
            string nombre = (txtNombreProyecto.Text ?? string.Empty).Trim();

            if (nombre.Length == 0)
            {
                nombre = string.IsNullOrWhiteSpace(Almacen.Empresa)
                    ? "Proyecto LookScan"
                    : Almacen.Empresa.Trim();
            }

            if (Repositorio.Existe(nombre))
            {
                DialogResult respuesta = MessageBox.Show(
                    "Ya existe un proyecto llamado «" + nombre + "».\n¿Desea actualizarlo con los datos actuales?",
                    "LookScan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta != DialogResult.Yes) return;
            }

            try
            {
                Repositorio.Guardar(nombre);
                txtNombreProyecto.Text = nombre;
                RefrescarLista();
                UtilUI.Aviso("Proyecto guardado: " + nombre);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar el proyecto: " + ex.Message,
                    "LookScan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CargarProyecto(string nombre)
        {
            try
            {
                if (!Repositorio.Cargar(nombre))
                {
                    UtilUI.Aviso("No se encontró el proyecto «" + nombre + "».");
                    RefrescarLista();
                    return;
                }

                txtNombreProyecto.Text = Repositorio.ProyectoActual ?? nombre;
                UtilUI.Aviso("Proyecto cargado: " + nombre);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar el proyecto: " + ex.Message,
                    "LookScan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void EliminarProyecto(string nombre)
        {
            DialogResult respuesta = MessageBox.Show(
                "¿Eliminar el proyecto «" + nombre + "»?\nEsta acción no se puede deshacer.",
                "LookScan", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (respuesta != DialogResult.Yes) return;

            try
            {
                if (!Repositorio.Eliminar(nombre))
                {
                    UtilUI.Aviso("No se encontró el proyecto «" + nombre + "».");
                }
                else if (Util.Igual(Repositorio.ProyectoActual, nombre) ||
                         Util.Igual(txtNombreProyecto.Text, nombre))
                {
                    txtNombreProyecto.Text = Almacen.Empresa ?? string.Empty;
                }

                RefrescarLista();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar el proyecto: " + ex.Message,
                    "LookScan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
