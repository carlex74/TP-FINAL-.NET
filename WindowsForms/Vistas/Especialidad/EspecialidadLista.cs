using ApplicationClean.DTOs;
using ApplicationClean.Interfaces;

namespace WindowsForms
{
    public partial class EspecialidadLista : Form
    {
        private readonly IAPIEspecialidadClients _especialidadClient;

        public EspecialidadLista(IAPIEspecialidadClients especialidadClient)
        {
            InitializeComponent();

            _especialidadClient = especialidadClient;

        }

        private void Especialidad_Load(object sender, EventArgs e)
        {
            this.GetAllAndLoad();
        }

        private void agregarButton_Click(object sender, EventArgs e)
        {

            EspecialidadDetalle especialidadDetalle = new EspecialidadDetalle(_especialidadClient);

            EspecialidadDTO especialidadNuevo = new EspecialidadDTO();

            especialidadDetalle.Mode = FormMode.Add;
            especialidadDetalle.Especialidad = especialidadNuevo;

            especialidadDetalle.ShowDialog();

            this.GetAllAndLoad();
        }

        private async void modificarButton_Click(object sender, EventArgs e)
        {
            try
            {
                EspecialidadDetalle especialidadDetalle = new EspecialidadDetalle(_especialidadClient);

                int id = this.SelectedItem().Id;

                EspecialidadDTO especialidad = await _especialidadClient.GetById(id);

                especialidadDetalle.Mode = FormMode.Update;
                especialidadDetalle.Especialidad = especialidad;

                especialidadDetalle.ShowDialog();

                this.GetAllAndLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar especialidad para modificar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            try
            {
                int id = this.SelectedItem().Id;

                var result = MessageBox.Show($"¿Está seguro que desea eliminar la especialidad con Id {id}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    await _especialidadClient.Delete(id);
                    this.GetAllAndLoad();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar especialidad: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void GetAllAndLoad()
        {
            try
            {
                this.especialidadesDataGridView.DataSource = null;
                this.especialidadesDataGridView.DataSource = await _especialidadClient.GetAll();

                if (this.especialidadesDataGridView.Rows.Count > 0)
                {
                    this.especialidadesDataGridView.Rows[0].Selected = true;
                    this.eliminarButton.Enabled = true;
                    this.modificarButton.Enabled = true;
                }
                else
                {
                    this.eliminarButton.Enabled = false;
                    this.modificarButton.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la lista de especialidades: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.eliminarButton.Enabled = false;
                this.modificarButton.Enabled = false;
            }
        }

        private EspecialidadDTO SelectedItem()
        {
            EspecialidadDTO especialidad;

            especialidad = (EspecialidadDTO)especialidadesDataGridView.SelectedRows[0].DataBoundItem;

            return especialidad;
        }
    }
}
