using ApplicationClean.DTOs;
using ApplicationClean.Interfaces.ApiClients;
using System.Text.Json;
using System.Net.Http;

namespace WindowsForms
{
    public partial class PersonaDetalle : Form
    {
        private PersonaDTO persona;
        private FormMode mode;
        private readonly IAPIPersonaClients _personaClient;

        public PersonaDTO Persona
        {
            get { return persona; }
            set { persona = value; SetPersona(); }
        }

        public FormMode Mode
        {
            get { return mode; }
            set { mode = value; SetFormMode(value); }
        }

        public PersonaDetalle(IAPIPersonaClients personaClient)
        {
            InitializeComponent();
            _personaClient = personaClient;
        }

        private async void aceptarButton_Click(object sender, EventArgs e)
        {
            if (!ValidatePersona()) return;

            aceptarButton.Enabled = false;
            this.Cursor = Cursors.WaitCursor;

            try
            {
                persona.Nombre = nombreTextBox.Text;
                persona.Apellido = apellidoTextBox.Text;
                persona.Dni = dniTextBox.Text;
                persona.Email = emailTextBox.Text;
                persona.Telefono = telefonoTextBox.Text;
                persona.Direccion = direccionTextBox.Text;
                persona.FechaNacimiento = fechaNacimientoPicker.Value;

                if (Mode == FormMode.Update)
                {
                    persona.Id = int.Parse(idTextBox.Text);
                    await _personaClient.Update(persona);
                }
                else
                {
                    await _personaClient.Add(persona);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (HttpRequestException httpEx)
            {
                if (httpEx.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    string errorMessage = "Los datos ingresados no son válidos.";
                    try
                    {
                        var apiError = JsonSerializer.Deserialize<ApiError>(httpEx.Message, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                        errorMessage = apiError.Message;
                    }
                    catch { }

                    if (errorMessage.ToLower().Contains("email"))
                    {
                        errorProvider.SetError(emailTextBox, errorMessage);
                    }
                    else if (errorMessage.ToLower().Contains("dni"))
                    {
                        errorProvider.SetError(dniTextBox, errorMessage);
                    }
                    else
                    {
                        MessageBox.Show(errorMessage, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    ErrorHandler.HandleError(httpEx);
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleError(ex);
            }
            finally
            {
                aceptarButton.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void SetPersona()
        {
            if (persona == null) return;
            idTextBox.Text = persona.Id.ToString();
            nombreTextBox.Text = persona.Nombre;
            apellidoTextBox.Text = persona.Apellido;
            dniTextBox.Text = persona.Dni;
            emailTextBox.Text = persona.Email;
            telefonoTextBox.Text = persona.Telefono;
            direccionTextBox.Text = persona.Direccion;

            if (persona.FechaNacimiento > fechaNacimientoPicker.MinDate && persona.FechaNacimiento < fechaNacimientoPicker.MaxDate)
            {
                fechaNacimientoPicker.Value = persona.FechaNacimiento;
            }
        }

        private void SetFormMode(FormMode value)
        {
            mode = value;
            if (mode == FormMode.Add)
            {
                titleLabel.Text = "Nueva Persona";
                idLabel.Visible = false;
                idTextBox.Visible = false;
            }
            else if (mode == FormMode.Update)
            {
                titleLabel.Text = "Modificar Persona";
                idLabel.Visible = true;
                idTextBox.Visible = true;
            }
        }

        private bool ValidatePersona()
        {
            errorProvider.SetError(nombreTextBox, string.Empty);
            errorProvider.SetError(apellidoTextBox, string.Empty);
            errorProvider.SetError(dniTextBox, string.Empty);
            errorProvider.SetError(emailTextBox, string.Empty);

            bool isValid = true;

            if (string.IsNullOrWhiteSpace(nombreTextBox.Text))
            {
                errorProvider.SetError(nombreTextBox, "El nombre es requerido.");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(apellidoTextBox.Text))
            {
                errorProvider.SetError(apellidoTextBox, "El apellido es requerido.");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(dniTextBox.Text))
            {
                errorProvider.SetError(dniTextBox, "El DNI es requerido.");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(emailTextBox.Text))
            {
                errorProvider.SetError(emailTextBox, "El email es requerido.");
                isValid = false;
            }

            return isValid;
        }
    }
}