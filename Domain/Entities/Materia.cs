using System.Text.RegularExpressions;

namespace Domain.Entities
{
    public class Materia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; private set; }
        public int HsSemanales { get; private set; }
        public int HsTotales { get; private set; }

        public ICollection<Plan> Planes { get; private set; }

        public Materia(int id, string nombre, string descripcion, int hsSemanales, int hsTotales)
        {
            SetId(id);
            SetNombre(nombre);
            SetDescripcion(descripcion);
            SetHsSemanales(hsSemanales);
            SetHsTotales(hsTotales);
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
        public void SetNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre no puede ser nul o vací0.", nameof(nombre));
            Nombre = nombre;
        }
        public void SetHsSemanales(int hsSemanales)
        {
            if (hsSemanales <= 0)
                throw new ArgumentException("Las horas semanales deben ser un número positivo.", nameof(hsSemanales));
            HsSemanales = hsSemanales;
        }
        public void SetHsTotales(int hsTotales)
        {
            if (hsTotales <= 0)
                throw new ArgumentException("Las horas totales deben ser un número positivo.", nameof(hsTotales));
            HsTotales = hsTotales;
        }
    }
}
