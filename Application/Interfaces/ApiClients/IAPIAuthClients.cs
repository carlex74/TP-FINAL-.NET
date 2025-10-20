using ApplicationClean.DTOs;
using System.Threading.Tasks;

namespace ApplicationClean.Interfaces
{
    public interface IAPIAuthClients
    {
        Task<LoginResponseDTO> LoginAsync(string legajo, string clave);
    }
}