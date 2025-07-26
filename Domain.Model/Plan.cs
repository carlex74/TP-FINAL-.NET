using System.Text.RegularExpressions;

namespace Domain.Model
{
    public class Plan: BusinessEntity
    {
        public int Id { get; private set; }
        public string Descripcion { get; private set; }
        public int IdEspecialidad { get; private set; }

        public Plan(int id,string descripcion, int idEspecialidad) : base()
        {
            Id = id;
            SetDescripcion(descripcion);
            SetIdEspecialidad(idEspecialidad);
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
