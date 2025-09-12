namespace Domain.Entities
{
    public class Alumno : Usuario
    {
        public int? IdPlan { get; private set; }
        public Plan? Plan { get; private set; }

        protected Alumno() : base() { }

        public Alumno(string legajo, string claveHash, int idPersona, int? idPlan)
            : base(legajo, claveHash, TipoUsuario.Alumno, idPersona)
        {
            SetIdPlan(idPlan);
        }

        public void SetIdPlan(int? idPlan)
        {
            if (idPlan.HasValue && idPlan.Value <= 0)
                throw new ArgumentException("El ID de plan debe ser un número positivo.");
            IdPlan = idPlan;
        }
    }
}