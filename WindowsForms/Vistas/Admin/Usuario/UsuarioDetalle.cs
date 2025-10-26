using ApplicationClean.DTOs;
using ApplicationClean.Interfaces.ApiClients;
using static Domain.Entities.Usuario;

namespace WindowsForms
{
    public partial class UsuarioDetalle : Form
    {
        private UsuarioDTO usuario;
        private FormMode mode;
        private readonly IAPIUsuarioClients _usuarioClient;
        private readonly IAPIPersonaClients _personaClient;
        private readonly IAPIPlanClients _planClient;

        public UsuarioDTO Usuario
        {
            get { return usuario; }
            set { usuario = value; SetUsuarioUI(); }
        }

        public FormMode Mode
        {
            get { return mode; }
            set { mode = value; SetFormModeUI(value); }
        }

        public UsuarioDetalle(IAPIUsuarioClients usuarioClient, IAPIPersonaClients personaClient, IAPIPlanClients planClient)
        {
            InitializeComponent();
            _usuarioClient = usuarioClient;
            _personaClient = personaClient;
            _planClient = planClient;
        }

        private async void UsuarioDetalle_Load(object sender, EventArgs e)
        {
            await LoadPersonasAsync();
            await LoadPlanesAsync();
            LoadTiposUsuario();
            SetUsuarioUI();
        }

        private async Task LoadPersonasAsync()
        {
            try
            {
                var personas = await _personaClient.GetAll();
                var personasDisplay = personas.Select(p => new
                {
                    p.Id,
                    NombreCompleto = $"{p.Apellido}, {p.Nombre} ({p.Dni})"
                }).ToList();
                personaComboBox.DataSource = personasDisplay;
                personaComboBox.DisplayMember = "NombreCompleto";
                personaComboBox.ValueMember = "Id";
            }
            catch (Exception ex) { ErrorHandler.HandleError(ex); }
        }

        private async Task LoadPlanesAsync()
        {
            try
            {
                var planes = await _planClient.GetAll();
                planComboBox.DataSource = planes.ToList();
                planComboBox.DisplayMember = "DescripcionCompleta";
                planComboBox.ValueMember = "Id";
                planComboBox.SelectedItem = null;
            }
            catch (Exception ex) { ErrorHandler.HandleError(ex); }
        }

        private void LoadTiposUsuario()
        {
            tipoComboBox.DataSource = Enum.GetValues(typeof(TipoUsuario));
        }

        private async void aceptarButton_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            try
            {
                if (Mode == FormMode.Add)
                {
                    var dto = new CrearUsuarioDTO
                    {
                        Legajo = legajoTextBox.Text,
                        Clave = claveTextBox.Text,
                        Tipo = (TipoUsuario)tipoComboBox.SelectedValue,
                        IdPersona = (int)personaComboBox.SelectedValue,
                        IdPlan = (TipoUsuario)tipoComboBox.SelectedValue == TipoUsuario.Alumno
                                 ? (int?)planComboBox.SelectedValue
                                 : null
                    };
                    await _usuarioClient.Add(dto);
                }
                else
                {
                    var dto = new ActualizarUsuarioDTO
                    {
                        Tipo = (TipoUsuario)tipoComboBox.SelectedValue,
                        Habilitado = habilitadoCheckBox.Checked,
                        IdPlan = (TipoUsuario)tipoComboBox.SelectedValue == TipoUsuario.Alumno
                                 ? (int?)planComboBox.SelectedValue
                                 : null
                    };
                    await _usuarioClient.Update(legajoTextBox.Text, dto);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleError(ex);
            }
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void SetUsuarioUI()
        {
            if (usuario == null) return;
            legajoTextBox.Text = usuario.Legajo;
            tipoComboBox.SelectedItem = usuario.Tipo;
            if (usuario.IdPersona > 0)
            {
                personaComboBox.SelectedValue = usuario.IdPersona;
            }
            habilitadoCheckBox.Checked = usuario.Habilitado;

            tipoComboBox_SelectedIndexChanged(null, null);

            if (usuario.Tipo == TipoUsuario.Alumno && usuario.IdPlan.HasValue)
            {
                planComboBox.SelectedValue = usuario.IdPlan.Value;
            }
        }

        private void SetFormModeUI(FormMode value)
        {
            mode = value;
            if (mode == FormMode.Add)
            {
                titleLabel.Text = "Nuevo Usuario";
                habilitadoCheckBox.Visible = false;
                legajoTextBox.ReadOnly = false;
                personaComboBox.Enabled = true;
                tipoComboBox.Enabled = true;
            }
            else if (mode == FormMode.Update)
            {
                titleLabel.Text = "Modificar Usuario";
                legajoTextBox.ReadOnly = true;
                claveLabel.Visible = false;
                claveTextBox.Visible = false;
                personaComboBox.Enabled = false;
                tipoComboBox.Enabled = false;
                habilitadoCheckBox.Visible = true;
            }
        }

        private bool ValidateForm()
        {
            errorProvider.Clear();
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
            if ((TipoUsuario)tipoComboBox.SelectedValue == TipoUsuario.Alumno && planComboBox.SelectedValue == null)
            {
                errorProvider.SetError(planComboBox, "Debe seleccionar un plan para el alumno.");
                isValid = false;
            }
            return isValid;
        }

        private void tipoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tipoComboBox.SelectedItem is TipoUsuario tipoSeleccionado)
            {
                bool esAlumno = tipoSeleccionado == TipoUsuario.Alumno;
                planLabel.Visible = esAlumno;
                planComboBox.Visible = esAlumno;
            }
        }
    }
}