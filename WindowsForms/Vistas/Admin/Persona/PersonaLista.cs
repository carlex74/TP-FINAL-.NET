using ApplicationClean.DTOs;
using ApplicationClean.Interfaces.ApiClients;

namespace WindowsForms
{
    public partial class PersonaLista : Form
    {
        private readonly IAPIPersonaClients _personaClient;

        public PersonaLista(IAPIPersonaClients personaClient)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            _personaClient = personaClient;
        }

        private void PersonaLista_Load(object sender, EventArgs e)
        {
            GetAllAndLoad();
        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            using (var personaDetalle = new PersonaDetalle(_personaClient))
            {
                personaDetalle.Mode = FormMode.Add;
                personaDetalle.Persona = new PersonaDTO();
                if (personaDetalle.ShowDialog() == DialogResult.OK)
                {
                    GetAllAndLoad();
                }
            }
        }

        private async void modificarButton_Click(object sender, EventArgs e)
        {
            if (personaDataGridView.SelectedRows.Count == 0) return;

            try
            {
                int id = SelectedItem().Id;
                PersonaDTO persona = await _personaClient.GetById(id);
                if (persona == null)
                {
                    MessageBox.Show("No se encontró la persona.", "Error");
                    GetAllAndLoad();
                    return;
                }

                using (var personaDetalle = new PersonaDetalle(_personaClient))
                {
                    personaDetalle.Mode = FormMode.Update;
                    personaDetalle.Persona = persona;
                    if (personaDetalle.ShowDialog() == DialogResult.OK)
                    {
                        GetAllAndLoad();
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleError(ex);
            }
        }

        /*
        A FUTURO: Funcionalidad de borrado.
        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            if (personaDataGridView.SelectedRows.Count == 0) return;

            try
            {
                var personaSeleccionada = SelectedItem();
                var result = MessageBox.Show($"¿Seguro que desea eliminar a {personaSeleccionada.Nombre} {personaSeleccionada.Apellido}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    await _personaClient.Delete(personaSeleccionada.Id);
                    GetAllAndLoad();
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleError(ex);
            }
        }
        */

        private async void GetAllAndLoad()
        {
            try
            {
                personaDataGridView.DataSource = null;
                personaDataGridView.DataSource = await _personaClient.GetAll();
                UpdateButtonsState();
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleError(ex);
            }
        }

        private PersonaDTO SelectedItem()
        {
            return (PersonaDTO)personaDataGridView.SelectedRows[0].DataBoundItem;
        }

        private void UpdateButtonsState()
        {
            bool hasRows = personaDataGridView.Rows.Count > 0;
            modificarButton.Enabled = hasRows;
            eliminarButton.Enabled = hasRows;
        }
    }
}