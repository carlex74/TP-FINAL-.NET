using ApplicationClean.DTOs;

namespace ApplicationClean.Interfaces
{
    public interface IAPIAuthClients
    {
        Task<LoginResponseDTO> LoginAsync(string legajo, string clave);
    }
}