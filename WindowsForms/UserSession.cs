using ApplicationClean.DTOs;
using static Domain.Entities.Usuario;

namespace WindowsForms
{
    public static class UserSession
    {
        private static UsuarioDTO _currentUser;
        public static string Token { get; private set; }

        public static void Login(UsuarioDTO user, string token)
        {
            _currentUser = user;
            Token = token;
        }

        public static void Logout()
        {
            _currentUser = null;
            Token = null;
        }

        public static UsuarioDTO GetCurrentUser()
        {
            return _currentUser;
        }

        public static bool IsLoggedIn => _currentUser != null && !string.IsNullOrEmpty(Token);

        public static TipoUsuario? UserRole => _currentUser?.Tipo;
    }
}