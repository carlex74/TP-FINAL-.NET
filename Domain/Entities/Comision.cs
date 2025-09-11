using System.Text.RegularExpressions;

namespace Domain.Entities
{
    public class Comision
    {
        public int Nro { get; private set; }
        public int AnioEspecialidad { get; private set; }
        public string Descripcion { get; private set; }
        public ICollection<Plan> Planes { get; private set; }

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
    }
}
