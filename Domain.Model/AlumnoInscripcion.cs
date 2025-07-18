using System.Text.RegularExpressions;

namespace Domain.Model
{
    public class AlumnoInscripcion : BusinessEntity
    {
        public string Condicion { get; private set; }
        public int IdAlumno { get; private set; }
        public int IdCurso { get; private set; }
        public int Nota { get; private set; }

        public AlumnoInscripcion(string condicion, int idAlumno, int idCurso, int nota) : base()
        {
            SetCondicion(condicion);
            SetIdAlumno(idAlumno);
            SetIdCurso(idCurso);
            SetNota(nota);
        }
        public void SetCondicion(string condicion)
        {
            if (string.IsNullOrWhiteSpace(condicion))
                throw new ArgumentException("La condición no puede ser nula o vacía.", nameof(condicion));
            Condicion = condicion;
        }
        public void SetIdAlumno(int idAlumno)
        {
            if (idAlumno <= 0)
                throw new ArgumentException("El ID del alumno debe ser un número positivo.", nameof(idAlumno));
            IdAlumno = idAlumno;
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
