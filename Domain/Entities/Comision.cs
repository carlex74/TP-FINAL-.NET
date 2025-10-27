using Domain.Interfaces;

namespace Domain.Entities
{
    // A FUTURO: La interfaz ISoftDeletable podría volver a implementarse.
    public class Comision //: ISoftDeletable
    {
        public int Nro { get; private set; }
        public int AnioEspecialidad { get; private set; }
        public string Descripcion { get; private set; }

        /*
        A FUTURO: Propiedades para el borrado lógico.
        public bool IsDeleted { get; private set; }
        public DateTime? DeletedOnUtc { get; private set; }
        */

        public ICollection<Plan> Planes { get; private set; }
        protected Comision()
        {
            Planes = new HashSet<Plan>();
        }

        public Comision(int nro, int anioEspecialidad, string descripcion)
        {
            SetNro(nro);
            SetAnioEspecialidad(anioEspecialidad);
            SetDescripcion(descripcion);
            Planes = new HashSet<Plan>();
        }
        public void SetNro(int nro)
        {
            if (nro < 0)
                throw new ArgumentException("El Nro debe ser mayor que 0.", nameof(nro));
            Nro = nro;
        }
        public void SetAnioEspecialidad(int anioEspecialidad)
        {
            if (anioEspecialidad <= 0)
                throw new ArgumentException("El año de especialidad debe ser un número positivo.", nameof(anioEspecialidad));
            AnioEspecialidad = anioEspecialidad;
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
