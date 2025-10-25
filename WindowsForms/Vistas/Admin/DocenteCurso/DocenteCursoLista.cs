using ApplicationClean.DTOs;
using ApplicationClean.Interfaces.ApiClients;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Domain.Entities.Usuario;

namespace WindowsForms
{
    public partial class DocenteCursoLista : Form
    {
        private readonly IAPIDocenteCursoClient _docenteCursoClient;
        private readonly IAPIUsuarioClients _usuarioClient;
        private readonly IAPICursoClient _cursoClient;

        public DocenteCursoLista(IAPIDocenteCursoClient docenteCursoClient, IAPIUsuarioClients usuarioClient, IAPICursoClient cursoClient)
        {
            InitializeComponent();
            _docenteCursoClient = docenteCursoClient;
            _usuarioClient = usuarioClient;
            _cursoClient = cursoClient;
        }

        private async void DocenteCursoLista_Load(object sender, EventArgs e)
        {
            await GetAllAndLoad();
        }

        private async Task GetAllAndLoad()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                docenteCursoDataGridView.DataSource = null;
                var asignaciones = await _docenteCursoClient.GetAllAsync();

                docenteCursoDataGridView.DataSource = asignaciones.ToList();

                UpdateButtonsState();
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private async void agregarButton_Click(object sender, EventArgs e)
        {
            using (var detalleForm = new DocenteCursoDetalle(_docenteCursoClient, _usuarioClient, _cursoClient))
            {
                detalleForm.Mode = FormMode.Add;
                if (detalleForm.ShowDialog() == DialogResult.OK)
                {
                    await GetAllAndLoad();
                }
            }
        }

        private async void modificarButton_Click(object sender, EventArgs e)
        {
            if (docenteCursoDataGridView.SelectedRows.Count == 0) return;

            var seleccion = SelectedItem();
            var asignacion = await _docenteCursoClient.GetByIdAsync(seleccion.IdCurso, seleccion.LegajoDocente);

            using (var detalleForm = new DocenteCursoDetalle(_docenteCursoClient, _usuarioClient, _cursoClient))
            {
                detalleForm.Asignacion = asignacion;
                detalleForm.Mode = FormMode.Update;
                if (detalleForm.ShowDialog() == DialogResult.OK)
                {
                    await GetAllAndLoad();
                }
            }
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            if (docenteCursoDataGridView.SelectedRows.Count == 0) return;
            var seleccion = SelectedItem();
            var confirmacion = MessageBox.Show($"¿Está seguro de que desea quitar al docente con legajo {seleccion.LegajoDocente} del curso ID {seleccion.IdCurso}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    await _docenteCursoClient.DeleteAsync(seleccion.IdCurso, seleccion.LegajoDocente);
                    await GetAllAndLoad();
                }
                catch (Exception ex)
                {
                    ErrorHandler.HandleError(ex);
                }
            }
        }

        private DocenteCursoDTO SelectedItem() => (DocenteCursoDTO)docenteCursoDataGridView.SelectedRows[0].DataBoundItem;

        private void UpdateButtonsState()
        {
            bool hasRows = docenteCursoDataGridView.Rows.Count > 0;
            modificarButton.Enabled = hasRows;
            eliminarButton.Enabled = hasRows;
        }
    }
}