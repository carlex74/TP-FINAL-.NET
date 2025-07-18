using System.Text.RegularExpressions;

namespace Domain.Model
{
    public class Usuario : BusinessEntity
    {
        public string NombreUsuario { get; private set; }
        public string Clave { get; private set; }
        public string Email { get; private set; }
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }
        public bool Habilitado { get; private set; }

        public Usuario(string nombreUsuario, string clave, string email, string nombre, string apellido, bool habilitado) : base()
        {
            SetNombreUsuario(nombreUsuario);
            SetClave(clave);
            SetEmail(email);
            SetNombre(nombre);
            SetApellido(apellido);
            SetHabilitado(habilitado);
        }

        public void SetNombreUsuario(string nombreUsuario)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario))
                throw new ArgumentException("El nombre de usuario no puede ser nulo o vacío.", nameof(nombreUsuario));
            NombreUsuario = nombreUsuario;
        }
        public void SetClave(string clave)
        {
            if (string.IsNullOrWhiteSpace(clave))
                throw new ArgumentException("La clave no puede ser nula o vacía.", nameof(clave));
            Clave = clave;
        }
        public void SetEmail(string email)
        {
            if (!EsEmailValido(email))
                throw new ArgumentException("El email no tiene un formato válido.", nameof(email));
            Email = email;
        }
        private static bool EsEmailValido(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
        public void SetNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre no puede ser nulo o vacío.", nameof(nombre));
            Nombre = nombre;
        }
        public void SetApellido(string apellido)
        {
            if (string.IsNullOrWhiteSpace(apellido))
                throw new ArgumentException("El apellido no puede ser nulo o vacío.", nameof(apellido));
            Apellido = apellido;
        }
        public void SetHabilitado(bool habilitado)
        {
            Habilitado = habilitado;
        }
    }
}
