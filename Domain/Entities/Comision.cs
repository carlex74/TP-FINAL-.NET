using System.Text.RegularExpressions;

namespace Domain.Entities
{
    public class Comision : BusinessEntity
    {
        public int AnioEspecialidad { get; private set; }
        public string Descripcion { get; private set; }
        public int IdPlan { get; private set; }

        public Comision(int anioEspecialidad, string descripcion, int idPlan) : base()
        {
            SetAnioEspecialidad(anioEspecialidad);
            SetDescripcion(descripcion);
            SetIdPlan(idPlan);
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
        public void SetIdPlan(int idPlan)
        {
            if (idPlan <= 0)
                throw new ArgumentException("El ID del plan debe ser un número positivo.", nameof(idPlan));
            IdPlan = idPlan;
        }
    }
}
