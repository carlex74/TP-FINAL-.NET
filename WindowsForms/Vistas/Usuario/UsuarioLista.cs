using ApplicationClean.DTOs;
using ApplicationClean.Interfaces;
using ApplicationClean.Interfaces.ApiClients;
using System;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class UsuarioLista : Form
    {
        private readonly IAPIUsuarioClients _usuarioClient;
        private readonly IAPIPersonaClients _personaClient;
        private readonly IAPIPlanClients _planClient;

        public UsuarioLista(IAPIUsuarioClients usuarioClient, IAPIPersonaClients personaClient, IAPIPlanClients planClient)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            _usuarioClient = usuarioClient;
            _personaClient = personaClient;
            _planClient = planClient;
        }

        private void UsuarioLista_Load(object sender, EventArgs e)
        {
            ConfigureDataGridView();
            GetAllAndLoad();
        }

        private void ConfigureDataGridView()
        {
            usuarioDataGridView.AutoGenerateColumns = false;
            usuarioDataGridView.Columns.Clear();

            usuarioDataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Legajo", HeaderText = "Legajo", FillWeight = 80 });
            usuarioDataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IdPersona", HeaderText = "ID Persona", FillWeight = 50 });
            usuarioDataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PersonaNombreCompleto", HeaderText = "Nombre Completo", FillWeight = 150 });
            usuarioDataGridView.Columns.Add(new DataGridViewCheckBoxColumn { DataPropertyName = "Habilitado", HeaderText = "Habilitado", FillWeight = 50 });
            usuarioDataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Tipo", HeaderText = "Tipo", FillWeight = 70 });
            usuarioDataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IdPlan", HeaderText = "ID Plan", FillWeight = 50 });
            usuarioDataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PlanDescripcion", HeaderText = "Descripción Plan", FillWeight = 150 });
        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            using (var usuarioDetalle = new UsuarioDetalle(_usuarioClient, _personaClient, _planClient))
            {
                usuarioDetalle.Mode = FormMode.Add;
                usuarioDetalle.Usuario = new UsuarioDTO();
                if (usuarioDetalle.ShowDialog() == DialogResult.OK)
                {
                    GetAllAndLoad();
                }
            }
        }

        private async void modificarButton_Click(object sender, EventArgs e)
        {
            if (usuarioDataGridView.SelectedRows.Count == 0) return;

            try
            {
                string legajo = SelectedItem().Legajo;
                UsuarioDTO usuario = await _usuarioClient.GetByLegajo(legajo);
                if (usuario == null)
                {
                    MessageBox.Show("Error al cargar el usuario.", "Error");
                    GetAllAndLoad();
                    return;
                }

                using (var usuarioDetalle = new UsuarioDetalle(_usuarioClient, _personaClient, _planClient))
                {
                    usuarioDetalle.Mode = FormMode.Update;
                    usuarioDetalle.Usuario = usuario;
                    if (usuarioDetalle.ShowDialog() == DialogResult.OK)
                    {
                        GetAllAndLoad();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el usuario: {ex.Message}", "Error");
            }
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            if (usuarioDataGridView.SelectedRows.Count == 0) return;
            try
            {
                var usuarioSeleccionado = SelectedItem();
                var result = MessageBox.Show($"¿Seguro que desea eliminar el usuario con legajo {usuarioSeleccionado.Legajo}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    await _usuarioClient.Delete(usuarioSeleccionado.Legajo);
                    GetAllAndLoad();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el usuario: {ex.Message}", "Error");
            }
        }

        private async void GetAllAndLoad()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                usuarioDataGridView.DataSource = null;
                var usuarios = await _usuarioClient.GetAll();
                usuarioDataGridView.DataSource = usuarios;
                UpdateButtonsState();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la lista de usuarios: {ex.Message}", "Error");
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private UsuarioDTO SelectedItem()
        {
            if (usuarioDataGridView.SelectedRows.Count > 0)
            {
                return (UsuarioDTO)usuarioDataGridView.SelectedRows[0].DataBoundItem;
            }
            return null;
        }

        private void UpdateButtonsState()
        {
            bool hasRows = usuarioDataGridView.Rows.Count > 0;
            modificarButton.Enabled = hasRows;
            eliminarButton.Enabled = hasRows;
        }
    }
}