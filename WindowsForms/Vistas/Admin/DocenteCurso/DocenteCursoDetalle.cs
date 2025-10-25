using ApplicationClean.DTOs;
using ApplicationClean.Interfaces.ApiClients;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Domain.Entities.DocenteCurso;
using static Domain.Entities.Usuario;

namespace WindowsForms
{
    public partial class DocenteCursoDetalle : Form
    {
        public DocenteCursoDTO Asignacion { get; set; }
        public FormMode Mode { get; set; }

        private readonly IAPIDocenteCursoClient _docenteCursoClient;
        private readonly IAPIUsuarioClients _usuarioClient;
        private readonly IAPICursoClient _cursoClient;

        public DocenteCursoDetalle(IAPIDocenteCursoClient dcClient, IAPIUsuarioClients uClient, IAPICursoClient cClient)
        {
            InitializeComponent();
            _docenteCursoClient = dcClient;
            _usuarioClient = uClient;
            _cursoClient = cClient;
        }

        private async void DocenteCursoDetalle_Load(object sender, EventArgs e)
        {
            await LoadCombos();

            if (Mode == FormMode.Update)
            {
                titleLabel.Text = "Modificar Asignación";
                docenteComboBox.SelectedValue = Asignacion.LegajoDocente;
                cursoComboBox.SelectedValue = Asignacion.IdCurso;
                cargoComboBox.SelectedItem = Asignacion.Cargo;
                docenteComboBox.Enabled = false;
                cursoComboBox.Enabled = false;
            }
            else
            {
                titleLabel.Text = "Nueva Asignación";
                Asignacion = new DocenteCursoDTO();
            }
        }

        private async Task LoadCombos()
        {
            try
            {
                var usuarios = await _usuarioClient.GetAll();
                var docentes = usuarios.Where(u => u.Tipo == TipoUsuario.Docente).ToList();
                docenteComboBox.DataSource = docentes;
                docenteComboBox.DisplayMember = "PersonaNombreCompleto";
                docenteComboBox.ValueMember = "Legajo";

                var cursos = await _cursoClient.GetAll();
                cursoComboBox.DataSource = cursos.ToList();
                cursoComboBox.DisplayMember = "Descripcion";
                cursoComboBox.ValueMember = "Id";

                cargoComboBox.DataSource = Enum.GetValues(typeof(TipoCargos));
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleError(ex);
            }
        }

        private async void aceptarButton_Click(object sender, EventArgs e)
        {
            if (docenteComboBox.SelectedValue == null || cursoComboBox.SelectedValue == null || cargoComboBox.SelectedValue == null)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Validación");
                return;
            }

            Asignacion.LegajoDocente = docenteComboBox.SelectedValue.ToString();
            Asignacion.IdCurso = (int)cursoComboBox.SelectedValue;
            Asignacion.Cargo = (TipoCargos)cargoComboBox.SelectedValue;

            try
            {
                if (Mode == FormMode.Add)
                {
                    await _docenteCursoClient.AddAsync(Asignacion);
                }
                else
                {
                    await _docenteCursoClient.UpdateAsync(Asignacion);
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
    }
}