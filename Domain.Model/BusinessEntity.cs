using System.Text.RegularExpressions;

namespace Domain.Model
{
    public abstract class BusinessEntity
    {
        public enum Estado
        {
            Activo,
            Inactivo
        }
        public int Id { get; private set; }
        public Estado Estados { get; private set; }

        protected BusinessEntity() 
        {
            Estados = Estado.Activo;
        }
        public void SetId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser un número positivo.", nameof(id));
            Id = id;
        }
        public void SetEstado(Estado estado)
        {
            if (!Enum.IsDefined(typeof(Estado), estado))
                throw new ArgumentException("El estado no es válido.", nameof(estado));
            Estados = estado;
        }
    }
}
