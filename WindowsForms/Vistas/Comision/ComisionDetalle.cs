using ApplicationClean.DTOs;
using ApplicationClean.Interfaces.ApiClients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsForms.Vistas.Materia;

namespace WindowsForms.Vistas.Comision
{
    public partial class ComisionDetalle : Form
    {
        private ComisionDTO comision;
        private FormMode mode;
        private readonly IAPIComisionClient _comisionClient;
        private readonly IAPIPlanClients _planClient;
        private List<int> _planesSeleccionadosIds;

        public ComisionDTO Comision { get { return comision; } set { comision = value; } }
        public FormMode Mode { get { return mode; } set { mode = value; } }

        public ComisionDetalle(IAPIComisionClient comisionClient, IAPIPlanClients planClient)
        {
            InitializeComponent();
            _comisionClient = comisionClient;
            _planClient = planClient;
        }

        private async void ComisionDetalle_Load(object sender, EventArgs e)
        {
            if (Mode == FormMode.Update && Comision != null && Comision.Nro > 0)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    Comision = await _comisionClient.GetById(Comision.Nro);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar la comisión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }
                finally { this.Cursor = Cursors.Default; }
            }

            if (Comision == null) Comision = new ComisionDTO();

            _planesSeleccionadosIds = Comision.Planes?.Select(p => p.Id).ToList() ?? new List<int>();

            SetFormMode();
            SetComisionUI();
        }

        private async void aceptarButton_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            this.Cursor = Cursors.WaitCursor;
            aceptarButton.Enabled = false;

            try
            {
                comision.Descripcion = descripcionTextBox.Text;
                comision.AnioEspecialidad = int.Parse(anioTextBox.Text);

                if (Mode == FormMode.Update)
                {
                    await _comisionClient.Update(comision);
                    await _comisionClient.AssignPlanes(comision.Nro, _planesSeleccionadosIds);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else 
                {
                    var comisionCreada = await _comisionClient.Add(comision);
                    if (_planesSeleccionadosIds.Any())
                    {
                        await _comisionClient.AssignPlanes(comisionCreada.Nro, _planesSeleccionadosIds);
                    }

                    MessageBox.Show("Comisión creada con éxito. Ahora puede seguir editando.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Comision = await _comisionClient.GetById(comisionCreada.Nro);
                    this.Mode = FormMode.Update;
                    _planesSeleccionadosIds = this.Comision.Planes?.Select(p => p.Id).ToList() ?? new List<int>();

                    SetFormMode();
                    SetComisionUI();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                var todosLosPlanes = (await _planClient.GetAll()).ToList();
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
                MessageBox.Show($"Error al abrir asignación de planes: {ex.Message}");
            }
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void SetComisionUI()
        {
            idTextBox.Text = comision.Nro.ToString();
            descripcionTextBox.Text = comision.Descripcion;
            anioTextBox.Text = comision.AnioEspecialidad.ToString();

            if (comision.Planes != null && comision.Planes.Any())
            {
                planesAsignadosTextBox.Text = string.Join(Environment.NewLine, comision.Planes.Select(p => p.DescripcionCompleta));
            }
            else
            {
                planesAsignadosTextBox.Text = "Ninguno";
            }
        }

        private void SetFormMode()
        {
            if (mode == FormMode.Add)
            {
                titleLabel.Text = "Nueva Comisión";
                idLabel.Visible = false;
                idTextBox.Visible = false;
                if (anioTextBox.Text == "0") anioTextBox.Text = "";
                btnAsignarPlanes.Enabled = true;
            }
            else if (mode == FormMode.Update)
            {
                titleLabel.Text = "Modificar Comisión";
                idLabel.Visible = true;
                idTextBox.Visible = true;
                btnAsignarPlanes.Enabled = true;
            }
        }

        private bool ValidateForm()
        {
            errorProvider.Clear();
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(descripcionTextBox.Text))
            {
                errorProvider.SetError(descripcionTextBox, "La descripción es requerida.");
                isValid = false;
            }
            if (!int.TryParse(anioTextBox.Text, out _) || int.Parse(anioTextBox.Text) <= 0)
            {
                errorProvider.SetError(anioTextBox, "Debe ser un número positivo.");
                isValid = false;
            }
            return isValid;
        }
    }
}