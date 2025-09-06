using ApplicationClean.DTOs;
using System.Threading.Tasks;

namespace ApplicationClean.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<UsuarioDTO> LoginAsync(LoginRequestDTO loginRequest);
        Task<UsuarioDTO> CreateUsuarioAsync(CrearUsuarioDTO crearUsuarioDto);
        Task<UsuarioDTO> GetByLegajoAsync(string legajo);
        Task<IEnumerable<UsuarioDTO>> GetAllAsync();
        Task<UsuarioDTO> UpdateAsync(string legajo, ActualizarUsuarioDTO actualizarUsuarioDto);
        Task<bool> DeleteAsync(string legajo);
    }
}