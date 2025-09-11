namespace Domain.Entities
{
    public class AlumnoInscripcion
    {
        public string Condicion { get; private set; }
        public string LegajoAlumno { get; private set; }
        public int IdCurso { get; private set; }
        public int Nota { get; private set; }
        public Usuario Alumno { get; private set; }
        public Curso Curso { get; private set; }

        public AlumnoInscripcion(string condicion, int LegajoAlumno, int idCurso, int nota) : base()
        {
            SetCondicion(condicion);
            SetIdAlumno(LegajoAlumno);
            SetIdCurso(idCurso);
            SetNota(nota);
        }

        public AlumnoInscripcion(string condicion, string legajoAlumno, int idCurso, int nota)
        {
            Condicion = condicion;
            LegajoAlumno = legajoAlumno;
            IdCurso = idCurso;
            Nota = nota;
        }

        public void SetCondicion(string condicion)
        {
            if (string.IsNullOrWhiteSpace(condicion))
                throw new ArgumentException("La condición no puede ser nula o vacía.", nameof(condicion));
            Condicion = condicion;
        }
        public void SetIdAlumno(int legajoAlumno)
        {
            if (legajoAlumno <= 0)
                throw new ArgumentException("El ID del alumno debe ser un número positivo.", nameof(legajoAlumno));
            LegajoAlumno = LegajoAlumno;
        }
        public void SetIdCurso(int idCurso)
        {
            if (idCurso <= 0)
                throw new ArgumentException("El ID del curso debe ser un número positivo.", nameof(idCurso));
            IdCurso = idCurso;
        }
        public void SetNota(int nota)
        {
            if (nota < 0 || nota > 10)
                throw new ArgumentException("La nota debe estar entre 0 y 10.", nameof(nota));
            Nota = nota;
        }
    }
}
