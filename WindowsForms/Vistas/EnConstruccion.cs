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
            // Personalizamos el mensaje de bienvenida con el nombre del usuario logueado.
            var currentUser = UserSession.GetCurrentUser();
            if (currentUser != null)
            {
                // Mostramos un saludo más personal en el título
                titleLabel.Text = $"Bienvenido usuario {currentUser.Legajo}";
            }
        }

        private void cerrarSesionButton_Click(object sender, EventArgs e)
        {
            // Simplemente cerramos este formulario.
            // El bucle en Program.cs se encargará de limpiar la sesión y mostrar el login de nuevo.
            this.Close();
        }
    }
}