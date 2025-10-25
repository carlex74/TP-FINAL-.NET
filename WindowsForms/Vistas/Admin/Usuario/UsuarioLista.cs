using ApplicationClean.DTOs;
using ApplicationClean.Interfaces;
using ApplicationClean.Interfaces.ApiClients;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Domain.Entities.Usuario;

namespace WindowsForms
{
    public partial class UsuarioLista : Form
    {
        private readonly IAPIUsuarioClients _usuarioClient;
        private readonly IAPIPersonaClients _personaClient;
        private readonly IAPIPlanClients _planClient;

        private List<UsuarioDTO> _todosLosUsuarios;

        public UsuarioLista(IAPIUsuarioClients usuarioClient, IAPIPersonaClients personaClient, IAPIPlanClients planClient)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            _usuarioClient = usuarioClient;
            _personaClient = personaClient;
            _planClient = planClient;
        }

        private async void UsuarioLista_Load(object sender, EventArgs e)
        {
            ConfigureDataGridView();
            CargarComboFiltroTipo();
            await CargarDatosIniciales();
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

        private void CargarComboFiltroTipo()
        {
            var tipos = new[] { new { Text = "Todos", Value = (TipoUsuario?)null } }
                .Concat(Enum.GetValues(typeof(TipoUsuario))
                    .Cast<TipoUsuario>()
                    .Select(t => new { Text = t.ToString(), Value = (TipoUsuario?)t }))
                .ToList();

            cmbFiltroTipo.DataSource = tipos;
            cmbFiltroTipo.DisplayMember = "Text";
            cmbFiltroTipo.ValueMember = "Value";
        }


        private async Task CargarDatosIniciales()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                _todosLosUsuarios = (await _usuarioClient.GetAll()).ToList();
                AplicarFiltros(null, null);
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

        private void AplicarFiltros(object sender, EventArgs e)
        {
            if (_todosLosUsuarios == null) return;

            IEnumerable<UsuarioDTO> usuariosFiltrados = _todosLosUsuarios;

            if (!string.IsNullOrWhiteSpace(txtFiltroLegajo.Text))
            {
                usuariosFiltrados = usuariosFiltrados.Where(u => u.Legajo.Contains(txtFiltroLegajo.Text.Trim()));
            }

            if (cmbFiltroTipo.SelectedValue != null)
            {
                var tipoSeleccionado = (TipoUsuario)cmbFiltroTipo.SelectedValue;
                usuariosFiltrados = usuariosFiltrados.Where(u => u.Tipo == tipoSeleccionado);
            }

            usuarioDataGridView.DataSource = usuariosFiltrados.ToList();
            UpdateButtonsState();
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            txtFiltroLegajo.Clear();
            cmbFiltroTipo.SelectedIndex = 0;
            AplicarFiltros(null, null);
        }

        private async void agregarButton_Click(object sender, EventArgs e)
        {
            using (var usuarioDetalle = new UsuarioDetalle(_usuarioClient, _personaClient, _planClient))
            {
                usuarioDetalle.Mode = FormMode.Add;
                usuarioDetalle.Usuario = new UsuarioDTO();
                if (usuarioDetalle.ShowDialog() == DialogResult.OK)
                {
                    await CargarDatosIniciales();
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
                    await CargarDatosIniciales();
                    return;
                }

                using (var usuarioDetalle = new UsuarioDetalle(_usuarioClient, _personaClient, _planClient))
                {
                    usuarioDetalle.Mode = FormMode.Update;
                    usuarioDetalle.Usuario = usuario;
                    if (usuarioDetalle.ShowDialog() == DialogResult.OK)
                    {
                        await CargarDatosIniciales();
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleError(ex);
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
                    await CargarDatosIniciales();
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleError(ex);
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
            bool hasSelection = usuarioDataGridView.SelectedRows.Count > 0;
            modificarButton.Enabled = hasSelection;
            eliminarButton.Enabled = hasSelection;
        }
    }
}