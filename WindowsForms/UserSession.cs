using ApplicationClean.DTOs;
using static Domain.Entities.Usuario;

namespace WindowsForms
{
    // Una clase estática simple para mantener el estado de la sesión globalmente.
    public static class UserSession
    {
        private static UsuarioDTO _currentUser;

        public static void Login(UsuarioDTO user)
        {
            _currentUser = user;
        }

        public static void Logout()
        {
            _currentUser = null;
        }

        public static UsuarioDTO GetCurrentUser()
        {
            return _currentUser;
        }

        public static bool IsLoggedIn => _currentUser != null;

        // Propiedad para acceder fácilmente al rol del usuario actual
        public static TipoUsuario? UserRole => _currentUser?.Tipo;
    }
}