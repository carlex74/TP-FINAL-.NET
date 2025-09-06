using System.Text.RegularExpressions;

namespace Domain.Entities
{
    public class Persona
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }
        public string Dni { get; private set; }
        public string Direccion { get; private set; }
        public string Telefono { get; private set; }
        public string Email { get; private set; }
        public DateTime FechaNacimiento { get; private set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }

        protected Persona()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public Persona(int id, string nombre, string apellido, string dni, DateTime fechaNacimiento, string direccion, string telefono, string email)
        {
            SetId(id);
            SetNombre(nombre);
            SetApellido(apellido);
            SetDni(dni);
            SetFechaNacimiento(fechaNacimiento);
            SetDireccion(direccion);
            SetTelefono(telefono);
            SetEmail(email);
        }

        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(id));
            Id = id;
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
        public void SetDni(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni)) 
                throw new ArgumentException("El DNI no puede ser nulo o vacío.", nameof(dni));
            Dni = dni;
        }
        public void SetFechaNacimiento(DateTime fechaNacimiento)
        {
            if (fechaNacimiento > DateTime.Now)
                throw new ArgumentException("La fecha de nacimiento no puede ser futura.", nameof(fechaNacimiento));
            FechaNacimiento = fechaNacimiento;
        }
        public void SetDireccion(string direccion)
        {
            Direccion = direccion;
        }
        public void SetTelefono(string telefono)
        {
            Telefono = telefono;
        }
        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("El email no tiene un formato válido.", nameof(email));
            Email = email.Trim();
        }
        /*
        private static bool EsEmailValido(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            const string pattern = @"^(([^<>()[\]\\.,;:\s@\""]+(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$";

            return Regex.IsMatch(email, pattern);
        }
        */
    }
}
