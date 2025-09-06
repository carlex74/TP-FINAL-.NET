using ApplicationClean.DTOs;
using ApplicationClean.Interfaces.ApiClients;
using System;
using System.Windows.Forms;

namespace WindowsForms
{
    // El enum FormMode se puede mantener, es muy útil
    public enum FormMode { Add, Update }

    public partial class EspecialidadDetalle : Form
    {
        private EspecialidadDTO especialidad;
        private FormMode mode;
        private readonly IAPIEspecialidadClients _especialidadClient;

        public EspecialidadDTO Especialidad
        {
            get { return especialidad; }
            set { especialidad = value; SetEspecialidad(); }
        }

        public FormMode Mode
        {
            get { return mode; }
            set { mode = value; SetFormMode(value); }
        }

        public EspecialidadDetalle(IAPIEspecialidadClients especialidadClient)
        {
            InitializeComponent();
            _especialidadClient = especialidadClient;
        }

        private async void aceptarButton_Click(object sender, EventArgs e)
        {
            if (!ValidateEspecialidad()) return;

            try
            {
                especialidad.Descripcion = descripcionTextBox.Text;
                if (Mode == FormMode.Update)
                {
                    especialidad.Id = int.Parse(idTextBox.Text);
                    await _especialidadClient.Update(especialidad);
                }
                else
                {
                    await _especialidadClient.Add(especialidad);
                }
                this.DialogResult = DialogResult.OK; // Indicamos que la operación fue exitosa
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void SetEspecialidad()
        {
            idTextBox.Text = especialidad.Id.ToString();
            descripcionTextBox.Text = especialidad.Descripcion;
        }

        private void SetFormMode(FormMode value)
        {
            mode = value;
            if (mode == FormMode.Add)
            {
                titleLabel.Text = "Nueva Especialidad";
                idLabel.Visible = false;
                idTextBox.Visible = false;
            }
            else if (mode == FormMode.Update)
            {
                titleLabel.Text = "Modificar Especialidad";
                idLabel.Visible = true;
                idTextBox.Visible = true;
            }
        }

        private bool ValidateEspecialidad()
        {
            errorProvider.SetError(descripcionTextBox, string.Empty);
            if (string.IsNullOrWhiteSpace(descripcionTextBox.Text))
            {
                errorProvider.SetError(descripcionTextBox, "La descripción es requerida.");
                return false;
            }
            return true;
        }
    }
}