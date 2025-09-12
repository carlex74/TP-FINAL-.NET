using static Domain.Entities.Usuario;

namespace ApplicationClean.DTOs
{
    public class ActualizarUsuarioDTO
    {
        public TipoUsuario Tipo { get; set; }
        public bool Habilitado { get; set; }
        public int? IdPlan { get; set; }
    }
}