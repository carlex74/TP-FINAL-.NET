using System.Text.RegularExpressions;

namespace Domain.Model
{
    public class ModuloUsuario : BusinessEntity
    {
        public int IdModulo { get; private set; }
        public int IdUsuario { get; private set; }
        public bool PermiteAlta { get; private set; }
        public bool PermiteBaja { get; private set; }
        public bool PermiteConsulta { get; private set; }
        public bool PermiteModificacion { get; private set; }

        public ModuloUsuario(int idModulo, int idUsuario, bool permiteAlta, bool permiteBaja, bool permiteConsulta, bool permiteModificacion) : base()
        {
            SetIdModulo(idModulo);
            SetIdUsuario(idUsuario);
            SetPermiteAlta(permiteAlta);
            SetPermiteBaja(permiteBaja);
            SetPermiteConsulta(permiteConsulta);
            SetPermiteModificacion(permiteModificacion);
        }
        public void SetIdModulo(int idModulo)
        {
            if (idModulo <= 0)
                throw new ArgumentException("El ID del módulo debe ser un número positivo.", nameof(idModulo));
            IdModulo = idModulo;
        }
        public void SetIdUsuario(int idUsuario)
        {
            if (idUsuario <= 0)
                throw new ArgumentException("El ID del usuario debe ser un número positivo.", nameof(idUsuario));
            IdUsuario = idUsuario;
        }
        public void SetPermiteAlta(bool permiteAlta)
        {
            PermiteAlta = permiteAlta;
        }
        public void SetPermiteBaja(bool permiteBaja)
        {
            PermiteBaja = permiteBaja;
        }
        public void SetPermiteConsulta(bool permiteConsulta)
        {
            PermiteConsulta = permiteConsulta;
        }
        public void SetPermiteModificacion(bool permiteModificacion)
        {
            PermiteModificacion = permiteModificacion;
        }
    }
}
