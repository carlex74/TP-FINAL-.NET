using System.Text.RegularExpressions;

namespace Domain.Entities
{
    public class DocenteCurso
    {
        public enum TipoCargos //por ahora solo estos tipos de cargos, se pueden agregar más si es necesario
        {
            ProfesorTitular,
            ProfesorAdjunto,
            JefeDeTrabajosPracticos,
            AyudanteDeCatedra
        }
        public int IdCurso { get; private set; }
        public string LegajoDocente { get; private set; }
        public TipoCargos Cargo { get; private set; }
        public Usuario Docente {  get; private set; }
        public Curso Curso { get; private set; }

        public DocenteCurso(int idCurso, string legajoDocente, TipoCargos cargo)
        {
            SetIdCurso(idCurso);
            SetLegajoDocente(legajoDocente);
            SetCargo(cargo);
        }
        public void SetIdCurso(int idCurso)
        {
            if (idCurso <= 0)
                throw new ArgumentException("El ID del curso debe ser un número positivo.", nameof(idCurso));
            IdCurso = idCurso;
        }
        public void SetLegajoDocente(string legajoDocente)
        {
            if (string.IsNullOrWhiteSpace(legajoDocente))
                throw new ArgumentException("El legajo no puede ser nulo o vacío.", nameof(legajoDocente));
            LegajoDocente = legajoDocente;
        }
        public void SetCargo(TipoCargos cargo)
        {
            if (!Enum.IsDefined(typeof(TipoCargos), cargo))
                throw new ArgumentException("El tipo de cargo no es válido.", nameof(cargo));
            Cargo = cargo;
        }
    }
}
