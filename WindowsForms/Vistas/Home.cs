using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class Home : Form
    {
        private Form activeForm = null;
        private Panel currentButtonPanel; 

        private readonly EspecialidadLista _especialidadLista;
        private readonly PlanLista _planLista;
        private readonly PersonaLista _personaLista;
        private readonly UsuarioLista _usuarioLista;

        public Home(EspecialidadLista especialidadLista, PlanLista planLista, PersonaLista personaLista, UsuarioLista usuarioLista)
        {
            InitializeComponent();
            _especialidadLista = especialidadLista;
            _planLista = planLista;
            _personaLista = personaLista;
            _usuarioLista = usuarioLista;
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
                currentButtonPanel.BackColor = Color.FromArgb(17, 25, 37);
            }
        }

        private void cerrarSesionButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OpenChildForm(Form childForm, Panel buttonPanel)
        {
            ActivateButton(buttonPanel);

            if (activeForm != null)
            {
                activeForm.Hide();
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

        private void especialidadButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(_especialidadLista, especialidadPanel);
        }

        private void planButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(_planLista, planPanel);
        }

        private void personaButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(_personaLista, personaPanel);
        }

        private void usuarioButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(_usuarioLista, usuarioPanel);
        }
    }
}