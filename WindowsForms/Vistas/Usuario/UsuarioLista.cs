using ApplicationClean.DTOs;
using ApplicationClean.Interfaces;
using ApplicationClean.Interfaces.ApiClients;
using System;
using System.Windows.Forms;
using WindowsForms;

namespace WindowsForms
{
    public partial class UsuarioLista : Form
    {
        private readonly IAPIUsuarioClients _usuarioClient;
        private readonly IAPIPersonaClients _personaClient;

        public UsuarioLista(IAPIUsuarioClients usuarioClient, IAPIPersonaClients personaClient)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            _usuarioClient = usuarioClient;
            _personaClient = personaClient;
        }

        private void UsuarioLista_Load(object sender, EventArgs e)
        {
            GetAllAndLoad();
        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            using (var usuarioDetalle = new UsuarioDetalle(_usuarioClient, _personaClient))
            {
                usuarioDetalle.Mode = FormMode.Add;
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
                if (usuario == null) { /* ... manejo de error ... */ return; }

                using (var usuarioDetalle = new UsuarioDetalle(_usuarioClient, _personaClient))
                {
                    usuarioDetalle.Mode = FormMode.Update;
                    usuarioDetalle.Usuario = usuario;
                    if (usuarioDetalle.ShowDialog() == DialogResult.OK)
                    {
                        GetAllAndLoad();
                    }
                }
            }
            catch (Exception ex) { /* ... manejo de error ... */ }
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
            catch (Exception ex) { /* ... manejo de error ... */ }
        }

        private async void GetAllAndLoad()
        {
            try
            {
                usuarioDataGridView.DataSource = null;
                usuarioDataGridView.DataSource = await _usuarioClient.GetAll();
                UpdateButtonsState();
            }
            catch (Exception ex) { /* ... manejo de error ... */ }
        }

        private UsuarioDTO SelectedItem()
        {
            return (UsuarioDTO)usuarioDataGridView.SelectedRows[0].DataBoundItem;
        }

        private void UpdateButtonsState()
        {
            bool hasRows = usuarioDataGridView.Rows.Count > 0;
            modificarButton.Enabled = hasRows;
            eliminarButton.Enabled = hasRows;
        }
    }
}