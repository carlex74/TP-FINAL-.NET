using System.Text.RegularExpressions;

namespace Domain.Entities
{
    public class Materia : BusinessEntity
    {
        public string Descripcion { get; private set; }
        public int HsSemanales { get; private set; }
        public int HsTotales { get; private set; }
        public int IdPlan { get; private set; }

        public Materia(string descripcion, int hsSemanales, int hsTotales, int idPlan) : base()
        {
            SetDescripcion(descripcion);
            SetHsSemanales(hsSemanales);
            SetHsTotales(hsTotales);
            SetIdPlan(idPlan);
        }
        public void SetDescripcion(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
                throw new ArgumentException("La descripción no puede ser nula o vacía.", nameof(descripcion));
            Descripcion = descripcion;
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
        public void SetIdPlan(int idPlan)
        {
            if (idPlan <= 0)
                throw new ArgumentException("El ID del plan debe ser un número positivo.", nameof(idPlan));
            IdPlan = idPlan;
        }
    }
}
