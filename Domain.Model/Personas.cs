using System.Text.RegularExpressions;

namespace Domain.Model
{
    abstract class Personas : BusinessEntity
    {
        public enum TipoPersona
        {
            Alumno,
            Docente,
            Administrador
        }

        public string Nombre { get; private set; }
        public string Apellido { get; private set; }
        public DateTime FechaNacimiento { get; private set; }
        public string Direccion { get; private set; }
        public string Telefono { get; private set; }
        public string Email { get; private set; }
        public int Legajo { get; private set; }
        public int IdPlan { get; private set; }
        public TipoPersona Tipo { get; private set; }

        public Personas(string nombre, string apellido, DateTime fechaNacimiento, string direccion, string telefono, string email, int legajo, int idPlan, TipoPersona tipo) : base()
        {
            SetNombre(nombre);
            SetApellido(apellido);
            SetFechaNacimiento(fechaNacimiento);
            SetDireccion(direccion);
            SetTelefono(telefono);
            SetEmail(email);
            SetLegajo(legajo);
            SetIdPlan(idPlan);
            SetTipo(tipo);
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
        public void SetFechaNacimiento(DateTime fechaNacimiento)
        {
            if (fechaNacimiento > DateTime.Now)
                throw new ArgumentException("La fecha de nacimiento no puede ser futura.", nameof(fechaNacimiento));
            FechaNacimiento = fechaNacimiento;
        }
        public void SetDireccion(string direccion)
        {
            if (string.IsNullOrWhiteSpace(direccion))
                throw new ArgumentException("La dirección no puede ser nula o vacía.", nameof(direccion));
            Direccion = direccion;
        }
        public void SetTelefono(string telefono)
        {
            if (string.IsNullOrWhiteSpace(telefono))
                throw new ArgumentException("El teléfono no puede ser nulo o vacío.", nameof(telefono));
            Telefono = telefono;
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
        public void SetLegajo(int legajo)
        {
            if (legajo <= 0)
                throw new ArgumentException("El legajo debe ser un número positivo.", nameof(legajo));
            Legajo = legajo;
        }
        public void SetIdPlan(int idPlan)
        {
            if (idPlan <= 0)
                throw new ArgumentException("El ID del plan debe ser un número positivo.", nameof(idPlan));
            IdPlan = idPlan;
        }
        public void SetTipo(TipoPersona tipo)
        {
            if (!Enum.IsDefined(typeof(TipoPersona), tipo))
                throw new ArgumentException("TipoPersona inválido.");
            Tipo = tipo;
        }
    }
}
