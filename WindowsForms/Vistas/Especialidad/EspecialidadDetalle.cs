using ApplicationClean.DTOs;
using ApplicationClean.Interfaces;
using System.Reflection.Emit;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsForms
{
    public enum FormMode
    {
        Add,
        Update
    }

    public partial class EspecialidadDetalle : Form
    {
        private EspecialidadDTO especialidad;
        private FormMode mode;
        private readonly IAPIEspecialidadClients _especialidadClient;

        public EspecialidadDTO Especialidad
        {
            get { return especialidad; }
            set
            {
                especialidad = value;
                this.SetEspecialidad();
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
        public EspecialidadDetalle(IAPIEspecialidadClients especialidadClient)
        {
            InitializeComponent();
            _especialidadClient = especialidadClient;
            Mode = FormMode.Add;
        }

        private async void aceptarButton_Click(object sender, EventArgs e)
        {
            if (this.ValidateEspecialidad())
            {
                try
                {
                    if (this.Especialidad == null)
                    {
                        this.Especialidad = new EspecialidadDTO();
                    }
                    this.Especialidad.Id = int.Parse(IdTextBox.Text);
                    this.Especialidad.Descripcion = DescripcionTextBox.Text;

                    //El Detalle se esta llevando la responsabilidad de llamar al servicio
                    //pero tal vez deberia ser solo una vista y que esta responsabilidad quede
                    //en la Lista o tal vez en un Presenter o Controler

                    if (this.Mode == FormMode.Update)
                    {
                        await _especialidadClient.Update(this.Especialidad);
                    }
                    else
                    {
                        await _especialidadClient.Add(this.Especialidad);
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

        private void SetEspecialidad()
        {
            this.IdTextBox.Text = this.Especialidad.Id.ToString();
            this.DescripcionTextBox.Text = this.Especialidad.Descripcion;
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

        private bool ValidateEspecialidad()
        {
            bool isValid = true;

            errorProvider.SetError(IdTextBox, string.Empty);
            errorProvider.SetError(DescripcionTextBox, string.Empty);

            if (this.DescripcionTextBox.Text == string.Empty)
            {
                isValid = false;
                errorProvider.SetError(DescripcionTextBox, "La Descripcion es Requerida");
            }
            return isValid;
        }
    }
}
