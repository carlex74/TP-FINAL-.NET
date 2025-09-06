using ApplicationClean.DTOs;
using ApplicationClean.Interfaces.ApiClients;
using System;
using System.Windows.Forms;
using WindowsForms;

namespace WindowsForms
{
    public partial class PlanLista : Form
    {
        private readonly IAPIPlanClients _planClient;
        // Necesitamos el cliente de especialidades para pasárselo al formulario de detalle
        private readonly IAPIEspecialidadClients _especialidadClient;

        public PlanLista(IAPIPlanClients planClient, IAPIEspecialidadClients especialidadClient)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            _planClient = planClient;
            _especialidadClient = especialidadClient;
        }

        private void PlanLista_Load(object sender, EventArgs e)
        {
            GetAllAndLoad();
        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            using (var planDetalle = new PlanDetalle(_planClient, _especialidadClient))
            {
                planDetalle.Mode = FormMode.Add;
                planDetalle.Plan = new PlanDTO();
                if (planDetalle.ShowDialog() == DialogResult.OK)
                {
                    GetAllAndLoad();
                }
            }
        }

        private async void modificarButton_Click(object sender, EventArgs e)
        {
            if (planDataGridView.SelectedRows.Count == 0) return;

            try
            {
                int id = SelectedItem().Id;
                PlanDTO plan = await _planClient.GetById(id);
                if (plan == null) { /* ... manejo de error ... */ return; }

                using (var planDetalle = new PlanDetalle(_planClient, _especialidadClient))
                {
                    planDetalle.Mode = FormMode.Update;
                    planDetalle.Plan = plan;
                    if (planDetalle.ShowDialog() == DialogResult.OK)
                    {
                        GetAllAndLoad();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar plan: {ex.Message}", "Error");
            }
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            if (planDataGridView.SelectedRows.Count == 0) return;

            try
            {
                int id = SelectedItem().Id;
                var result = MessageBox.Show($"¿Seguro que desea eliminar el plan con Id {id}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    await _planClient.Delete(id);
                    GetAllAndLoad();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar plan: {ex.Message}", "Error");
            }
        }

        private async void GetAllAndLoad()
        {
            try
            {
                planDataGridView.DataSource = null;
                planDataGridView.DataSource = await _planClient.GetAll();
                UpdateButtonsState();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la lista: {ex.Message}", "Error");
            }
        }

        private PlanDTO SelectedItem()
        {
            return (PlanDTO)planDataGridView.SelectedRows[0].DataBoundItem;
        }

        private void UpdateButtonsState()
        {
            bool hasRows = planDataGridView.Rows.Count > 0;
            modificarButton.Enabled = hasRows;
            eliminarButton.Enabled = hasRows;
        }
    }
}