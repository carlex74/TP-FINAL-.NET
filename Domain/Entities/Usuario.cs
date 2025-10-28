namespace Domain.Entities
{
    // A FUTURO: La interfaz ISoftDeletable podría volver a implementarse.
    public abstract class Usuario //: ISoftDeletable
    {
        public enum TipoUsuario
        {
            Alumno,
            Docente,
            Administrador
        }

        public string Legajo { get; private set; }
        public string ClaveHash { get; private set; }
        public TipoUsuario Tipo { get; protected set; }
        public bool Habilitado { get; private set; }
        public int IdPersona { get; private set; }

        /*
        A FUTURO: Propiedades para el borrado lógico.
        public bool IsDeleted { get; private set; }
        public DateTime? DeletedOnUtc { get; private set; }
        */


        public ICollection<AlumnoInscripcion> AlumnoInscripcions { get; private set; }
        public ICollection<DocenteCurso> DocenteCursos { get; private set; }
        public Persona Persona { get; set; }

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

        /*
        A FUTURO: Métodos para gestionar el borrado lógico.
        public void SoftDelete()
        {
            IsDeleted = true;
            DeletedOnUtc = DateTime.UtcNow;
        }

        public void Restore()
        {
            IsDeleted = false;
            DeletedOnUtc = null;
        }
        */
    }
}
