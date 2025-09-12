namespace Domain.Entities
{
    public class Docente : Usuario
    {
        protected Docente() : base() { }

        public Docente(string legajo, string claveHash, int idPersona)
            : base(legajo, claveHash, TipoUsuario.Docente, idPersona)
        {
        }
    }
}