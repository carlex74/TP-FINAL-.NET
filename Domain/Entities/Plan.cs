using Domain.Interfaces;

namespace Domain.Entities
{
    // A FUTURO: La interfaz ISoftDeletable podría volver a implementarse.
    public class Plan //: ISoftDeletable
    {
        public int Id { get; private set; }
        public string Descripcion { get; private set; }
        public int IdEspecialidad { get; private set; }

        /*
        A FUTURO: Propiedades para el borrado lógico.
        public bool IsDeleted { get; private set; }
        public DateTime? DeletedOnUtc { get; private set; }
        */

        public Especialidad Especialidad { get; private set; }
        public ICollection<Alumno> Alumnos { get; private set; }
        public ICollection<Comision> Comisiones { get; private set; }
        public ICollection<Materia> Materias { get; private set; }

        protected Plan()
        {
            Alumnos = new HashSet<Alumno>();
            Materias = new HashSet<Materia>();
            Comisiones = new HashSet<Comision>();
        }

        public Plan(int id, string descripcion, int idEspecialidad)
        {
            SetId(id);
            SetDescripcion(descripcion);
            SetIdEspecialidad(idEspecialidad);
            Materias = new HashSet<Materia>();
            Comisiones = new HashSet<Comision>();
        }
        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(id));
            Id = id;
        }

        public void SetDescripcion(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
                throw new ArgumentException("La descripción no puede ser nula o vacía.", nameof(descripcion));
            Descripcion = descripcion;
        }
        public void SetIdEspecialidad(int idEspecialidad)
        {
            if (idEspecialidad <= 0)
                throw new ArgumentException("El ID de especialidad debe ser un número positivo.", nameof(idEspecialidad));
            IdEspecialidad = idEspecialidad;
        }

        public int GetId()
        {
            return Id;
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
