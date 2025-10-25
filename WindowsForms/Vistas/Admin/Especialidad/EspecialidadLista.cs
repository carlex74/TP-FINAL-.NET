using ApplicationClean.DTOs;
using ApplicationClean.Interfaces.ApiClients;
using System;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class EspecialidadLista : Form
    {
        private readonly IAPIEspecialidadClients _especialidadClient;

        public EspecialidadLista(IAPIEspecialidadClients especialidadClient)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            _especialidadClient = especialidadClient;
        }

        private void Especialidad_Load(object sender, EventArgs e)
        {
            GetAllAndLoad();
        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            using (var especialidadDetalle = new EspecialidadDetalle(_especialidadClient))
            {
                especialidadDetalle.Mode = FormMode.Add;
                especialidadDetalle.Especialidad = new EspecialidadDTO();

                if (especialidadDetalle.ShowDialog() == DialogResult.OK)
                {
                    GetAllAndLoad();
                }
            }
        }

        private async void modificarButton_Click(object sender, EventArgs e)
        {
            if (especialidadDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione una especialidad para modificar.", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                int id = SelectedItem().Id;
                EspecialidadDTO especialidad = await _especialidadClient.GetById(id);
                if (especialidad == null)
                {
                    MessageBox.Show("No se encontró la especialidad seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    GetAllAndLoad(); 
                    return;
                }

                using (var especialidadDetalle = new EspecialidadDetalle(_especialidadClient))
                {
                    especialidadDetalle.Mode = FormMode.Update;
                    especialidadDetalle.Especialidad = especialidad;
                    if (especialidadDetalle.ShowDialog() == DialogResult.OK)
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

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            if (especialidadDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione una especialidad para eliminar.", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                int id = SelectedItem().Id;
                var result = MessageBox.Show($"¿Está seguro que desea eliminar la especialidad con Id {id}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    await _especialidadClient.Delete(id);
                    GetAllAndLoad();
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleError(ex);
            }
        }

        private async void GetAllAndLoad()
        {
            try
            {
                especialidadDataGridView.DataSource = null;
                especialidadDataGridView.DataSource = await _especialidadClient.GetAll();
                UpdateButtonsState();
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleError(ex);
            }
        }

        private EspecialidadDTO SelectedItem()
        {
            if (especialidadDataGridView.SelectedRows.Count > 0)
            {
                return (EspecialidadDTO)especialidadDataGridView.SelectedRows[0].DataBoundItem;
            }
            return null;
        }

        private void UpdateButtonsState()
        {
            bool hasRows = especialidadDataGridView.Rows.Count > 0;
            modificarButton.Enabled = hasRows;
            eliminarButton.Enabled = hasRows;
        }
    }
}