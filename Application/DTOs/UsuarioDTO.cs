using static Domain.Entities.Usuario;

namespace ApplicationClean.DTOs
{
    public class UsuarioDTO
    {
        public string Legajo { get; set; }
        public TipoUsuario Tipo { get; set; }
        public bool Habilitado { get; set; }
        public int IdPersona { get; set; }
        public string ClaveHash { get; set; }
        public int? IdPlan { get; set; }
        public string? PlanDescripcion { get; set; }
        public string? PersonaNombreCompleto { get; set; }
    }
}