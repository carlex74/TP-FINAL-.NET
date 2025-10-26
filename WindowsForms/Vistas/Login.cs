using System.Runtime.InteropServices;
using ApplicationClean.Interfaces;

namespace WindowsForms
{
    public partial class LoginForm : Form
    {
        private readonly IAPIAuthClients _authClient;

        public LoginForm(IAPIAuthClients authClient)
        {
            InitializeComponent();
            _authClient = authClient;

            SetPlaceholder(txtLegajo, "Legajo");
            SetPlaceholder(txtPassword, "Contraseña", isPassword: true);

            txtLegajo.Enter += (s, e) => RemovePlaceholder(txtLegajo, "Legajo");
            txtLegajo.Leave += (s, e) => SetPlaceholder(txtLegajo, "Legajo");

            txtPassword.Enter += (s, e) => RemovePlaceholder(txtPassword, "Contraseña", isPassword: true);
            txtPassword.Leave += (s, e) => SetPlaceholder(txtPassword, "Contraseña", isPassword: true);

            this.ActiveControl = lblTitle;
        }

        #region Funcionalidad para mover el formulario sin bordes
        // Este bloque de código permite que el usuario pueda arrastrar la ventana
        // haciendo clic en el panel del encabezado (pnlHeader).

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion
        private void SetPlaceholder(TextBox textBox, string placeholder, bool isPassword = false)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = placeholder;
                textBox.ForeColor = Color.Gray;
                if (isPassword)
                {
                    textBox.UseSystemPasswordChar = false;
                }
            }
        }
        private void RemovePlaceholder(TextBox textBox, string placeholder, bool isPassword = false)
        {
            if (textBox.Text == placeholder)
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black;
                if (isPassword)
                {
                    textBox.UseSystemPasswordChar = true;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;

            string legajo = txtLegajo.Text.Trim();
            string clave = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(legajo) || string.IsNullOrWhiteSpace(clave))
            {
                MostrarError("Por favor, ingrese legajo y contraseña.");
                return;
            }

            try
            {
                btnLogin.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                var loginResponse = await _authClient.LoginAsync(legajo, clave);

                if (loginResponse != null && loginResponse.Usuario != null)
                {
                    var usuarioLogueado = loginResponse.Usuario;

                    UserSession.Login(usuarioLogueado, loginResponse.Token);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MostrarError("Legajo o contraseña incorrectos.");
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleError(ex);
            }
            finally
            {
                btnLogin.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }

        private void MostrarError(string mensaje)
        {
            lblError.Text = "      " + mensaje;
            lblError.Visible = true;
        }
    }
}