using System.Text.RegularExpressions;

namespace Domain.Model
{
    public class Curso : BusinessEntity
    {
        public int AnioCalendario { get; private set; }
        public int Cupo { get; private set; }
        public string Descripcion { get; private set; }
        public int IdComision { get; private set; }
        public int IdMateria { get; private set; }

        public Curso(int anioCalendario, int cupo, string descripcion, int idComision, int idMateria) : base()
        {
            SetAnioCalendario(anioCalendario);
            SetCupo(cupo);
            SetDescripcion(descripcion);
            SetIdComision(idComision);
            SetIdMateria(idMateria);
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
