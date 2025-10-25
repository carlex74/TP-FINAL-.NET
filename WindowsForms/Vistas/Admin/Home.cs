using Microsoft.Extensions.DependencyInjection;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class Home : Form
    {
        private Form activeForm = null;
        private Panel currentButtonPanel;
        private readonly IServiceProvider _serviceProvider;

        public Home(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;

            var currentUser = UserSession.GetCurrentUser();
            if (currentUser != null)
            {
                userInfoLabel.Text = $"Usuario: {currentUser.Legajo}";
            }
        }

        private void ActivateButton(Panel buttonPanel)
        {
            if (buttonPanel != null)
            {
                if (currentButtonPanel != buttonPanel)
                {
                    DisableButton();
                    currentButtonPanel = buttonPanel;
                    currentButtonPanel.BackColor = Color.FromArgb(0, 122, 204);
                }
            }
        }

        private void DisableButton()
        {
            if (currentButtonPanel != null)
            {
                currentButtonPanel.BackColor = Color.FromArgb(60, 80, 110);
            }
        }

        private void cerrarSesionButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OpenChildForm(Form childForm, Panel buttonPanel)
        {
            if (buttonPanel != null) ActivateButton(buttonPanel);
            else DisableButton();

            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(childForm);
            mainPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            welcomeLabel.Visible = false;
        }

        private void especialidadButton_Click(object sender, EventArgs e) => OpenChildForm(_serviceProvider.GetRequiredService<EspecialidadLista>(), especialidadPanel);
        private void planButton_Click(object sender, EventArgs e) => OpenChildForm(_serviceProvider.GetRequiredService<PlanLista>(), planPanel);
        private void personaButton_Click(object sender, EventArgs e) => OpenChildForm(_serviceProvider.GetRequiredService<PersonaLista>(), personaPanel);
        private void usuarioButton_Click(object sender, EventArgs e) => OpenChildForm(_serviceProvider.GetRequiredService<UsuarioLista>(), usuarioPanel);
        private void materiaButton_Click(object sender, EventArgs e) => OpenChildForm(_serviceProvider.GetRequiredService<MateriaLista>(), materiaPanel);
        private void comisionButton_Click(object sender, EventArgs e) => OpenChildForm(_serviceProvider.GetRequiredService<ComisionLista>(), comisionPanel);
        private void cursoButton_Click(object sender, EventArgs e) => OpenChildForm(_serviceProvider.GetRequiredService<CursoLista>(), cursoPanel);
        private void asignacionesButton_Click(object sender, EventArgs e) => OpenChildForm(_serviceProvider.GetRequiredService<DocenteCursoLista>(), asignacionesPanel);

        private void rendimientoPorCursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var reporteForm = _serviceProvider.GetRequiredService<ReporteRendimientoForm>();
            OpenChildForm(reporteForm, null);
        }

        private void historialAcadémicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var reporteForm = _serviceProvider.GetRequiredService<ReporteHistorialForm>();
            OpenChildForm(reporteForm, null);
        }
    }
}