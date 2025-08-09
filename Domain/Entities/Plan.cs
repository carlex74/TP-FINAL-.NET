using System.Text.RegularExpressions;

namespace Domain.Entities
{
    public class Plan
    {
        public int Id { get; private set; }
        public string Descripcion { get; private set; }
        public int IdEspecialidad { get; private set; }

        public Plan(int id,string descripcion, int idEspecialidad)
        {
            SetId(id);
            SetDescripcion(descripcion);
            SetIdEspecialidad(idEspecialidad);
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

        public int getId() {

            return Id;

        }

    }
}
