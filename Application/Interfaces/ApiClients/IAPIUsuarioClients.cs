using ApplicationClean.DTOs;


namespace ApplicationClean.Interfaces.ApiClients
{
    public interface IAPIUsuarioClients
    {
        Task<IEnumerable<UsuarioDTO>> GetAll();
        Task<UsuarioDTO> GetByLegajo(string legajo);
        Task<UsuarioDTO> Add(CrearUsuarioDTO crearUsuarioDto);
        Task Update(string legajo, ActualizarUsuarioDTO actualizarUsuarioDto);
        Task Delete(string legajo);
    }
}