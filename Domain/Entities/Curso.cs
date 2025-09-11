using System.Text.RegularExpressions;

namespace Domain.Entities
{
    public class Curso
    {
        public int Id {  get; private set; }
        public int AnioCalendario { get; private set; }
        public int Cupo { get; private set; }
        public string Descripcion { get; private set; }
        public int IdComision { get; private set; }
        public int IdMateria { get; private set; }
        public Materia Materia { get; private set; }
        public Comision Comision { get; private set; }

        public ICollection<AlumnoInscripcion> Inscripciones { get; private set; }
        public ICollection<DocenteCurso> Docentes { get; private set; }

        public Curso(int id, int anioCalendario, int cupo, string descripcion, int idComision, int idMateria) 
        {
            SetId(id);
            SetAnioCalendario(anioCalendario);
            SetCupo(cupo);
            SetDescripcion(descripcion);
            SetIdComision(idComision);
            SetIdMateria(idMateria);
        }
        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(id));
            Id = id;
        }
        public void SetAnioCalendario(int anioCalendario)
        {
            if (anioCalendario <= 0)
                throw new ArgumentException("El año calendario debe ser un número positivo.", nameof(anioCalendario));
            AnioCalendario = anioCalendario;
        }
        public void SetCupo(int cupo)
        {
            if (cupo <= 0)
                throw new ArgumentException("El cupo debe ser un número positivo.", nameof(cupo));
            Cupo = cupo;
        }
        public void SetDescripcion(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
                throw new ArgumentException("La descripción no puede ser nula o vacía.", nameof(descripcion));
            Descripcion = descripcion;
        }
        public void SetIdComision(int idComision)
        {
            if (idComision <= 0)
                throw new ArgumentException("El ID de comisión debe ser un número positivo.", nameof(idComision));
            IdComision = idComision;
        }
        public void SetIdMateria(int idMateria)
        {
            if (idMateria <= 0)
                throw new ArgumentException("El ID de materia debe ser un número positivo.", nameof(idMateria));
            IdMateria = idMateria;
        }
    }
}
