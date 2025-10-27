using Domain.Interfaces;

namespace Domain.Entities
{
    // A FUTURO: La interfaz ISoftDeletable podría volver a implementarse.
    public class Especialidad //: ISoftDeletable
    {
        public int Id { get; private set; }
        public string Descripcion { get; private set; }

        /*
        A FUTURO: Propiedades para el borrado lógico.
        public bool IsDeleted { get; private set; }
        public DateTime? DeletedOnUtc { get; private set; }
        */


        public virtual ICollection<Plan> Planes { get; set; }

        protected Especialidad()
        {
            Planes = new HashSet<Plan>();
        }

        public Especialidad(int id, string descripcion)
        {
            SetId(id);
            SetDescripcion(descripcion);
            Planes = new HashSet<Plan>();
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
