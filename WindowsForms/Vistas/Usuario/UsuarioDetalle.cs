using ApplicationClean.DTOs;
using ApplicationClean.Interfaces;
using ApplicationClean.Interfaces.ApiClients;
using System;
using System.Linq;
using System.Windows.Forms;
using static Domain.Entities.Usuario;

namespace WindowsForms
{
    public partial class UsuarioDetalle : Form
    {
        private UsuarioDTO usuario;
        private FormMode mode;
        private readonly IAPIUsuarioClients _usuarioClient;
        private readonly IAPIPersonaClients _personaClient;

        public UsuarioDTO Usuario
        {
            get { return usuario; }
            set { usuario = value; SetUsuario(); }
        }

        public FormMode Mode
        {
            get { return mode; }
            set { mode = value; SetFormMode(value); }
        }

        public UsuarioDetalle(IAPIUsuarioClients usuarioClient, IAPIPersonaClients personaClient)
        {
            InitializeComponent();
            _usuarioClient = usuarioClient;
            _personaClient = personaClient;
        }

        private async void UsuarioDetalle_Load(object sender, EventArgs e)
        {
            await LoadPersonasAsync();
            LoadTiposUsuario();
            SetUsuario();
        }

        private async Task LoadPersonasAsync()
        {
            try
            {
                var personas = await _personaClient.GetAll();
                personaComboBox.DataSource = personas.ToList();
                personaComboBox.DisplayMember = "NombreCompleto"; // Asumiendo que PersonaDTO tiene esta propiedad
                personaComboBox.ValueMember = "Id";
            }
            catch (Exception ex) { MessageBox.Show($"Error al cargar personas: {ex.Message}"); }
        }

        private void LoadTiposUsuario()
        {
            // Cargamos el ComboBox con los valores del enum TipoUsuario
            tipoComboBox.DataSource = Enum.GetValues(typeof(TipoUsuario));
        }

        private async void aceptarButton_Click(object sender, EventArgs e)
        {
            if (!ValidateUsuario()) return;

            try
            {
                if (Mode == FormMode.Add)
                {
                    var dto = new CrearUsuarioDTO
                    {
                        Legajo = legajoTextBox.Text,
                        Clave = claveTextBox.Text,
                        Tipo = (TipoUsuario)tipoComboBox.SelectedValue,
                        IdPersona = (int)personaComboBox.SelectedValue
                    };
                    await _usuarioClient.Add(dto);
                }
                else // Mode == Update
                {
                    var dto = new ActualizarUsuarioDTO
                    {
                        Tipo = (TipoUsuario)tipoComboBox.SelectedValue,
                        Habilitado = habilitadoCheckBox.Checked
                    };
                    await _usuarioClient.Update(legajoTextBox.Text, dto);
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

        private void SetUsuario()
        {
            if (usuario == null) return;
            legajoTextBox.Text = usuario.Legajo;
            tipoComboBox.SelectedItem = usuario.Tipo;
            personaComboBox.SelectedValue = usuario.IdPersona;
            habilitadoCheckBox.Checked = usuario.Habilitado;
        }

        private void SetFormMode(FormMode value)
        {
            mode = value;
            if (mode == FormMode.Add)
            {
                titleLabel.Text = "Nuevo Usuario";
                habilitadoCheckBox.Visible = false; // No se puede setear al crear
                legajoTextBox.ReadOnly = false;
                personaComboBox.Enabled = true;
            }
            else if (mode == FormMode.Update)
            {
                titleLabel.Text = "Modificar Usuario";
                legajoTextBox.ReadOnly = true; // El legajo (PK) no se puede modificar
                claveLabel.Visible = false; // No se modifica la clave desde este form
                claveTextBox.Visible = false;
                personaComboBox.Enabled = false; // La persona asociada no se cambia
                habilitadoCheckBox.Visible = true;
            }
        }

        private bool ValidateUsuario()
        {
            // Resetear errores
            errorProvider.SetError(legajoTextBox, "");
            errorProvider.SetError(claveTextBox, "");
            errorProvider.SetError(tipoComboBox, "");
            errorProvider.SetError(personaComboBox, "");

            bool isValid = true;
            if (string.IsNullOrWhiteSpace(legajoTextBox.Text))
            {
                errorProvider.SetError(legajoTextBox, "El legajo es requerido.");
                isValid = false;
            }
            if (Mode == FormMode.Add && string.IsNullOrWhiteSpace(claveTextBox.Text))
            {
                errorProvider.SetError(claveTextBox, "La clave es requerida.");
                isValid = false;
            }
            if (tipoComboBox.SelectedValue == null)
            {
                errorProvider.SetError(tipoComboBox, "Debe seleccionar un tipo.");
                isValid = false;
            }
            if (personaComboBox.SelectedValue == null)
            {
                errorProvider.SetError(personaComboBox, "Debe seleccionar una persona.");
                isValid = false;
            }
            return isValid;
        }
    }
}