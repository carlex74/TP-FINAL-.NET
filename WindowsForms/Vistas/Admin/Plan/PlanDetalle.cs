using ApplicationClean.DTOs;
using ApplicationClean.Interfaces.ApiClients;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class PlanDetalle : Form
    {
        private PlanDTO plan;
        private FormMode mode;
        private readonly IAPIPlanClients _planClient;
        private readonly IAPIEspecialidadClients _especialidadClient;

        public PlanDTO Plan
        {
            get { return plan; }
            set { plan = value; SetPlan(); }
        }

        public FormMode Mode
        {
            get { return mode; }
            set { mode = value; SetFormMode(value); }
        }

        public PlanDetalle(IAPIPlanClients planClient, IAPIEspecialidadClients especialidadClient)
        {
            InitializeComponent();
            _planClient = planClient;
            _especialidadClient = especialidadClient;
        }

        private async void PlanDetalle_Load(object sender, EventArgs e)
        {
            await LoadEspecialidadesAsync();
            SetPlan();
        }

        private async Task LoadEspecialidadesAsync()
        {
            try
            {
                var especialidades = await _especialidadClient.GetAll();
                especialidadComboBox.DataSource = especialidades;
                especialidadComboBox.DisplayMember = "Descripcion";
                especialidadComboBox.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar especialidades: {ex.Message}", "Error");
            }
        }

        private async void aceptarButton_Click(object sender, EventArgs e)
        {
            if (!ValidatePlan()) return;

            try
            {
                plan.Descripcion = descripcionTextBox.Text;
                plan.IdEspecialidad = (int)especialidadComboBox.SelectedValue;

                if (Mode == FormMode.Update)
                {
                    plan.Id = int.Parse(idTextBox.Text);
                    await _planClient.Update(plan);
                }
                else
                {
                    await _planClient.Add(plan);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void SetPlan()
        {
            if (plan == null) return;
            idTextBox.Text = plan.Id.ToString();
            descripcionTextBox.Text = plan.Descripcion;
            if (plan.IdEspecialidad > 0)
            {
                especialidadComboBox.SelectedValue = plan.IdEspecialidad;
            }
        }

        private void SetFormMode(FormMode value)
        {
            mode = value;
            if (mode == FormMode.Add)
            {
                titleLabel.Text = "Nuevo Plan";
                idLabel.Visible = false;
                idTextBox.Visible = false;
            }
            else if (mode == FormMode.Update)
            {
                titleLabel.Text = "Modificar Plan";
                idLabel.Visible = true;
                idTextBox.Visible = true;
            }
        }

        private bool ValidatePlan()
        {
            errorProvider.SetError(descripcionTextBox, string.Empty);
            errorProvider.SetError(especialidadComboBox, string.Empty);

            bool isValid = true;
            if (string.IsNullOrWhiteSpace(descripcionTextBox.Text))
            {
                errorProvider.SetError(descripcionTextBox, "La descripción es requerida.");
                isValid = false;
            }
            if (especialidadComboBox.SelectedValue == null)
            {
                errorProvider.SetError(especialidadComboBox, "Debe seleccionar una especialidad.");
                isValid = false;
            }
            return isValid;
        }
    }
}