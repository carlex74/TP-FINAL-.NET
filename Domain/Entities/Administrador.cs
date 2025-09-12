namespace Domain.Entities
{
    public class Administrador : Usuario
    {
        protected Administrador() : base() { }

        public Administrador(string legajo, string claveHash, int idPersona)
            : base(legajo, claveHash, TipoUsuario.Administrador, idPersona)
        {
        }
    }
}