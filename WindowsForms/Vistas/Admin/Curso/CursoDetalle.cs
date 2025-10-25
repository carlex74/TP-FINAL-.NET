using ApplicationClean.DTOs;
using ApplicationClean.Interfaces.ApiClients;
using System;
using System.Linq;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class CursoDetalle : Form
    {
        private CursoDTO curso;
        private FormMode mode;
        private readonly IAPICursoClient _cursoClient;
        private readonly IAPIMateriaClient _materiaClient;
        private readonly IAPIComisionClient _comisionClient;

        public CursoDTO Curso
        {
            get { return curso; }
            set { curso = value; SetCurso(); }
        }

        public FormMode Mode
        {
            get { return mode; }
            set { mode = value; SetFormMode(value); }
        }

        public CursoDetalle(IAPICursoClient cursoClient, IAPIMateriaClient materiaClient, IAPIComisionClient comisionClient)
        {
            InitializeComponent();
            _cursoClient = cursoClient;
            _materiaClient = materiaClient;
            _comisionClient = comisionClient;
        }

        private async void CursoDetalle_Load(object sender, EventArgs e)
        {
            await LoadMateriasAsync();
            await LoadComisionesAsync();
            SetCurso();
        }

        private async Task LoadMateriasAsync()
        {
            try
            {
                var materias = await _materiaClient.GetAll();
                materiaComboBox.DataSource = materias.ToList();
                materiaComboBox.DisplayMember = "Nombre";
                materiaComboBox.ValueMember = "Id";
            }
            catch (Exception ex) { ErrorHandler.HandleError(ex); }
        }

        private async Task LoadComisionesAsync()
        {
            try
            {
                var comisiones = await _comisionClient.GetAll();
                comisionComboBox.DataSource = comisiones.ToList();
                comisionComboBox.DisplayMember = "Descripcion";
                comisionComboBox.ValueMember = "nro";
            }
            catch (Exception ex) { ErrorHandler.HandleError(ex); }
        }

        private async void aceptarButton_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            try
            {
                curso.AnioCalendario = int.Parse(anioTextBox.Text);
                curso.Cupo = int.Parse(cupoTextBox.Text);
                curso.Descripcion = descripcionTextBox.Text;
                curso.IdMateria = (int)materiaComboBox.SelectedValue;
                curso.IdComision = (int)comisionComboBox.SelectedValue;

                if (Mode == FormMode.Update)
                {
                    curso.Id = int.Parse(idTextBox.Text);
                    await _cursoClient.Update(curso);
                }
                else
                {
                    await _cursoClient.Add(curso);
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

        private void SetCurso()
        {
            if (curso == null) return;
            idTextBox.Text = curso.Id.ToString();
            anioTextBox.Text = curso.AnioCalendario.ToString();
            cupoTextBox.Text = curso.Cupo.ToString();
            descripcionTextBox.Text = curso.Descripcion;
            if (curso.IdMateria > 0)
            {
                materiaComboBox.SelectedValue = curso.IdMateria;
            }
            if (curso.IdComision > 0)
            {
                comisionComboBox.SelectedValue = curso.IdComision;
            }
        }

        private void SetFormMode(FormMode value)
        {
            mode = value;
            if (mode == FormMode.Add)
            {
                titleLabel.Text = "Nuevo Curso";
                idLabel.Visible = false;
                idTextBox.Visible = false;
                if (anioTextBox.Text == "0") anioTextBox.Text = "";
                if (cupoTextBox.Text == "0") cupoTextBox.Text = "";
            }
            else if (mode == FormMode.Update)
            {
                titleLabel.Text = "Modificar Curso";
                idLabel.Visible = true;
                idTextBox.Visible = true;
            }
        }

        private bool ValidateForm()
        {
            errorProvider.Clear();
            bool isValid = true;

            if (!int.TryParse(anioTextBox.Text, out _) || int.Parse(anioTextBox.Text) <= 2000)
            {
                errorProvider.SetError(anioTextBox, "Debe ser un año válido (mayor a 2000).");
                isValid = false;
            }
            if (!int.TryParse(cupoTextBox.Text, out _) || int.Parse(cupoTextBox.Text) <= 0)
            {
                errorProvider.SetError(cupoTextBox, "Debe ser un número positivo.");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(descripcionTextBox.Text))
            {
                errorProvider.SetError(descripcionTextBox, "La descripción es requerida.");
                isValid = false;
            }
            if (materiaComboBox.SelectedValue == null)
            {
                errorProvider.SetError(materiaComboBox, "Debe seleccionar una materia.");
                isValid = false;
            }
            if (comisionComboBox.SelectedValue == null)
            {
                errorProvider.SetError(comisionComboBox, "Debe seleccionar una comisión.");
                isValid = false;
            }
            return isValid;
        }
    }
}