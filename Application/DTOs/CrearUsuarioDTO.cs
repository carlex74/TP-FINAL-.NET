using static Domain.Entities.Usuario;

namespace ApplicationClean.DTOs
{
    public class CrearUsuarioDTO
    {
        public string Legajo { get; set; }
        public string Clave { get; set; }
        public TipoUsuario Tipo { get; set; }
        public int IdPersona { get; set; }
    }
}