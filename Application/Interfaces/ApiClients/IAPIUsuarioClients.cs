using ApplicationClean.DTOs;


namespace ApplicationClean.Interfaces.ApiClients
{
    public interface IAPIUsuarioClients
    {
        Task<IEnumerable<UsuarioDTO>> GetAll();
        Task<UsuarioDTO> GetByLegajo(string legajo);
        Task<UsuarioDTO> Add(CrearUsuarioDTO crearUsuarioDto);
        Task Update(string legajo, ActualizarUsuarioDTO actualizarUsuarioDto);
        // A FUTURO: Se puede reactivar la llamada al endpoint de borrado.
        //Task Delete(string legajo);
    }
}