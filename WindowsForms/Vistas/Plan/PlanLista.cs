using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApplicationClean.Interfaces;
using ApplicationClean.DTOs;

namespace WindowsForms.Vistas
{
    public partial class PlanLista : Form
    {
        private readonly IAPIPlanClients _planClient;
        public PlanLista(IAPIPlanClients planClient)
        {
            InitializeComponent();
            _planClient = planClient;
        }

        private void Plan_Load(object sender, EventArgs e)
        {
            this.GetAllAndLoad();
        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            PlanDetalle planDetalle = new PlanDetalle(_planClient);

            PlanDTO planNuevo = new PlanDTO();

            planDetalle.Mode = FormMode.Add;
            planDetalle.Plan = planNuevo;

            planDetalle.ShowDialog();

            this.GetAllAndLoad();
        }

        private async void modificarButton_Click(object sender, EventArgs e)
        {
            try
            {
                PlanDetalle planDetalle = new PlanDetalle(_planClient);

                int id = this.SelectedItem().Id;

                PlanDTO plan = await _planClient.GetById(id);

                planDetalle.Mode = FormMode.Update;
                planDetalle.Plan = plan;

                planDetalle.ShowDialog();

                this.GetAllAndLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar plan para modificar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            try
            {
                int id = this.SelectedItem().Id;

                var result = MessageBox.Show($"¿Está seguro que desea eliminar el plan con Id {id}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    await _planClient.Delete(id);
                    this.GetAllAndLoad();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar plan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void GetAllAndLoad()
        {
            try
            {
                this.planesDataGridView.DataSource = null;
                this.planesDataGridView.DataSource = await _planClient.GetAll();

                if (this.planesDataGridView.Rows.Count > 0)
                {
                    this.planesDataGridView.Rows[0].Selected = true;
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
                MessageBox.Show($"Error al cargar la lista de planes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.eliminarButton.Enabled = false;
                this.modificarButton.Enabled = false;
            }
        }

        private PlanDTO SelectedItem()
        {
            PlanDTO plan;

            plan = (PlanDTO)planesDataGridView.SelectedRows[0].DataBoundItem;

            return plan;
        }

        private void planesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
