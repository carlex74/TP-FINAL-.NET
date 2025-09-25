using System;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class EnConstruccionForm : Form
    {
        public EnConstruccionForm()
        {
            InitializeComponent();
        }

        private void EnConstruccionForm_Load(object sender, EventArgs e)
        {
            var currentUser = UserSession.GetCurrentUser();
            if (currentUser != null)
            {
                titleLabel.Text = $"Bienvenido usuario {currentUser.Legajo}";
            }
        }

        private void cerrarSesionButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}