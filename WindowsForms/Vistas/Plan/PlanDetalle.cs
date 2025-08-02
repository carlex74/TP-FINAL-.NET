using DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms.Vistas
{
    public partial class PlanDetalle : Form
    {
        private PlanDTO plan;
        private FormMode mode;

        public PlanDTO Plan
        {
            get { return plan; }
            set
            {
                plan = value;
                this.SetPlan();
            }
        }
        public FormMode Mode
        {
            get
            {
                return mode;
            }
            set
            {
                SetFormMode(value);
            }
        }
        public PlanDetalle()
        {
            InitializeComponent();
            Mode = FormMode.Add;
        }

        private async void aceptarButton_Click(object sender, EventArgs e)
        {
            if (this.ValidatePlan())
            {
                try
                {
                    if (this.Plan == null)
                    {
                        this.Plan = new PlanDTO();
                    }
                    this.Plan.Id = int.Parse(IdTextBox.Text);
                    this.Plan.Descripcion = DescripcionTextBox.Text;
                    this.Plan.IdEspecialidad = int.Parse(IdEspecialidadTextBox.Text);

                    //El Detalle se esta llevando la responsabilidad de llamar al servicio
                    //pero tal vez deberia ser solo una vista y que esta responsabilidad quede
                    //en la Lista o tal vez en un Presenter o Controler

                    if (this.Mode == FormMode.Update)
                    {
                        await PlanApiClient.UpdateAsync(this.Plan);
                    }
                    else
                    {
                        await PlanApiClient.AddAsync(this.Plan);
                    }
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetPlan()
        {
            this.IdTextBox.Text = this.Plan.Id.ToString();
            this.DescripcionTextBox.Text = this.Plan.Descripcion;
            this.IdEspecialidadTextBox.Text = this.Plan.IdEspecialidad.ToString();
        }

        private void SetFormMode(FormMode value)
        {
            mode = value;

            if (Mode == FormMode.Add)
            {
                IdLabel.Visible = false;
                IdTextBox.Visible = false;
            }

            if (Mode == FormMode.Update)
            {
                IdLabel.Visible = true;
                IdTextBox.Visible = true;
            }
        }

        private bool ValidatePlan()
        {
            bool isValid = true;

            errorProvider.SetError(IdTextBox, string.Empty);
            errorProvider.SetError(DescripcionTextBox, string.Empty);
            errorProvider.SetError(IdEspecialidadTextBox, string.Empty);

            if (this.DescripcionTextBox.Text == string.Empty)
            {
                isValid = false;
                errorProvider.SetError(DescripcionTextBox, "La Descripcion es Requerida");
            }

            if (this.IdEspecialidadTextBox.Text == string.Empty)
            {
                isValid = false;
                errorProvider.SetError(IdEspecialidadTextBox, "El Id Especialidad es Requerido");
            }

            return isValid;
        }
    }
}
