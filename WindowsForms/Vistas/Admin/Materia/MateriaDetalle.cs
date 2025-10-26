using ApplicationClean.DTOs;
using ApplicationClean.Interfaces.ApiClients;

namespace WindowsForms
{
    public partial class MateriaDetalle : Form
    {
        public MateriaDTO Materia { get; set; }
        public FormMode Mode { get; set; }

        private readonly IAPIMateriaClient _materiaClient;
        private readonly IAPIPlanClients _planClient;

        private List<int> _planesSeleccionadosIds;

        public MateriaDetalle(IAPIMateriaClient materiaClient, IAPIPlanClients planClient)
        {
            InitializeComponent();
            _materiaClient = materiaClient;
            _planClient = planClient;
        }

        private async void MateriaDetalle_Load(object sender, EventArgs e)
        {
            if (Mode == FormMode.Update && Materia != null && Materia.Id > 0)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    Materia = await _materiaClient.GetById(Materia.Id);
                }
                catch (Exception ex)
                {
                    ErrorHandler.HandleError(ex);
                    this.Close();
                    return;
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }

            if (Materia == null) Materia = new MateriaDTO();

            _planesSeleccionadosIds = Materia.Planes?.Select(p => p.Id).ToList() ?? new List<int>();

            SetFormMode();
            SetMateriaUI();
        }

        private async void aceptarButton_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            this.Cursor = Cursors.WaitCursor;
            aceptarButton.Enabled = false;

            try
            {
                Materia.Nombre = nombreTextBox.Text;
                Materia.Descripcion = descripcionTextBox.Text;
                Materia.HsSemanales = int.Parse(hsSemanalesTextBox.Text);
                Materia.HsTotales = int.Parse(hsTotalesTextBox.Text);

                if (Mode == FormMode.Add)
                {
                    var materiaCreada = await _materiaClient.Add(Materia);

                    if (_planesSeleccionadosIds.Any())
                    {
                        await _materiaClient.AssignPlanes(materiaCreada.Id, _planesSeleccionadosIds);
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    await _materiaClient.Update(Materia);
                    await _materiaClient.AssignPlanes(Materia.Id, _planesSeleccionadosIds);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                aceptarButton.Enabled = true;
            }
        }

        private async void btnAsignarPlanes_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                var todosLosPlanes = (await _planClient.GetAll()).ToList();
                this.Cursor = Cursors.Default;

                using (var asignacionForm = new PlanAsignacion(todosLosPlanes, _planesSeleccionadosIds))
                {
                    if (asignacionForm.ShowDialog() == DialogResult.OK)
                    {
                        _planesSeleccionadosIds = asignacionForm.PlanesSeleccionadosIds;
                        var planesSeleccionados = todosLosPlanes.Where(p => _planesSeleccionadosIds.Contains(p.Id));
                        planesAsignadosTextBox.Text = planesSeleccionados.Any()
                            ? string.Join(Environment.NewLine, planesSeleccionados.Select(p => p.DescripcionCompleta))
                            : "Ninguno";
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleError(ex);
            }
        }

        private void SetMateriaUI()
        {
            idTextBox.Text = Materia.Id.ToString();
            nombreTextBox.Text = Materia.Nombre;
            descripcionTextBox.Text = Materia.Descripcion;
            hsSemanalesTextBox.Text = Materia.HsSemanales == 0 ? "" : Materia.HsSemanales.ToString();
            hsTotalesTextBox.Text = Materia.HsTotales == 0 ? "" : Materia.HsTotales.ToString();

            if (Materia.Planes != null && Materia.Planes.Any())
            {
                planesAsignadosTextBox.Text = string.Join(Environment.NewLine, Materia.Planes.Select(p => p.DescripcionCompleta));
            }
            else
            {
                planesAsignadosTextBox.Text = "Ninguno";
            }
        }

        private void SetFormMode()
        {
            if (Mode == FormMode.Add)
            {
                titleLabel.Text = "Nueva Materia";
                idLabel.Visible = false;
                idTextBox.Visible = false;
            }
            else
            {
                titleLabel.Text = "Modificar Materia";
                idLabel.Visible = true;
                idTextBox.Visible = true;
            }
            btnAsignarPlanes.Enabled = true;
        }

        private bool ValidateForm()
        {
            errorProvider.Clear();
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(nombreTextBox.Text))
            {
                errorProvider.SetError(nombreTextBox, "El nombre es requerido.");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(descripcionTextBox.Text))
            {
                errorProvider.SetError(descripcionTextBox, "La descripción es requerida.");
                isValid = false;
            }
            if (!int.TryParse(hsSemanalesTextBox.Text, out _) || int.Parse(hsSemanalesTextBox.Text) <= 0)
            {
                errorProvider.SetError(hsSemanalesTextBox, "Debe ser un número positivo.");
                isValid = false;
            }
            if (!int.TryParse(hsTotalesTextBox.Text, out _) || int.Parse(hsTotalesTextBox.Text) <= 0)
            {
                errorProvider.SetError(hsTotalesTextBox, "Debe ser un número positivo.");
                isValid = false;
            }

            return isValid;
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}