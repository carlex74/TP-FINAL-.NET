using ApplicationClean.DTOs;

namespace ApplicationClean.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<UsuarioDTO> LoginAsync(LoginRequestDTO loginRequest);
        Task<UsuarioDTO> CreateUsuarioAsync(CrearUsuarioDTO crearUsuarioDto);
        Task<UsuarioDTO> GetByLegajoAsync(string legajo);
        Task<IEnumerable<UsuarioDTO>> GetAllAsync();
        Task<UsuarioDTO> UpdateAsync(string legajo, ActualizarUsuarioDTO actualizarUsuarioDto);
        // A FUTURO: Se puede reactivar la funcionalidad de borrado.
        // Task<bool> DeleteAsync(int id);
    }
}