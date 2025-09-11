using System.Text.RegularExpressions;
using static Domain.Entities.Persona;

namespace Domain.Entities
{
    public class Usuario
    {
        public enum TipoUsuario
        {
            Alumno,
            Docente,
            Administrador
        }

        public string Legajo { get; private set; }
        public string ClaveHash { get; private set; }
        public TipoUsuario Tipo { get; private set; }
        public bool Habilitado { get; private set; }
        public int IdPersona { get; private set; }

        public ICollection<AlumnoInscripcion> AlumnoInscripcions { get; private set; }
        public ICollection<DocenteCurso> DocenteCursos { get; private set; }

        public virtual Persona Persona { get; set; }
        protected Usuario() { }

        public Usuario(string legajo, string claveHash, TipoUsuario tipo, int idPersona)
        {
            SetLegajo(legajo);
            SetClave(claveHash);
            SetTipo(tipo);
            SetIdPersona(idPersona);

            SetHabilitado(true);
        }

        public void SetLegajo(string legajo)
        {
            if (string.IsNullOrWhiteSpace(legajo))
                throw new ArgumentException("El legajo de usuario no puede ser nulo o vacío.", nameof(legajo));
            Legajo = legajo;
        }
        public void SetClave(string claveHash)
        {
            if (string.IsNullOrWhiteSpace(claveHash))
                throw new ArgumentException("La clave no puede ser nula o vacía.", nameof(claveHash));
            ClaveHash = claveHash;
        }
        public void SetTipo(TipoUsuario tipo)
        {
            if (!Enum.IsDefined(typeof(TipoUsuario), tipo))
                throw new ArgumentException("TipoPersona inválido.");
            Tipo = tipo;
        }
        public void SetIdPersona(int idPersona)
        {
            if (idPersona <= 0)
                throw new ArgumentException("El ID de persona es requerido y debe ser positivo.");
            IdPersona = idPersona;
        }
        public void SetHabilitado(bool habilitado)
        {
            Habilitado = habilitado;
        }
    }
}
