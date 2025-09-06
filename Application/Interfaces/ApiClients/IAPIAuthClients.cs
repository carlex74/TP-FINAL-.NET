using ApplicationClean.DTOs;
using System.Threading.Tasks;

namespace ApplicationClean.Interfaces
{
    public interface IAPIAuthClients
    {
        Task<UsuarioDTO> LoginAsync(string legajo, string clave);
    }
}