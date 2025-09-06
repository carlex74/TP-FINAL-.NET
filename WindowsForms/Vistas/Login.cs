using Infrastructure.ApiClients;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            // El botón de cancelar ahora es el botón 'X' personalizado
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;

            string legajo = txtLegajo.Text;
            string clave = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(legajo) || legajo == "Legajo" ||
                string.IsNullOrWhiteSpace(clave) || clave == "Contraseña")
            {
                MostrarError("Por favor, ingrese legajo y contraseña.");
                return;
            }

            try
            {
                // Bloqueamos la UI para dar feedback
                btnLogin.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                // --- LLAMADA ASÍNCRONA CORRECTA ---
                // 'await' pausa la ejecución de ESTE MÉTODO hasta que la API responda.
                var usuarioLogueado = await _authClient.LoginAsync(legajo, clave);

                if (usuarioLogueado != null)
                {
                    // ¡LOGIN EXITOSO!
                    // Guardamos el usuario en la sesión para que el resto de la app lo use.
                    UserSession.Login(usuarioLogueado);

                    // Establecemos el resultado en OK.
                    this.DialogResult = DialogResult.OK;

                    // Cerramos el formulario para que Program.cs continúe.
                    this.Close();
                }
                else
                {
                    // LOGIN FALLIDO
                    MostrarError("Legajo o contraseña incorrectos.");
                    // --- LA LÓGICA CLAVE ---
                    // NO cerramos el formulario. Simplemente mostramos el error
                    // y el usuario puede intentarlo de nuevo.
                }
            }
            catch (Exception ex)
            {
                // Error de conexión u otro problema
                MostrarError($"Error de conexión: {ex.Message}");
            }
            finally
            {
                // Siempre volvemos a habilitar la UI
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