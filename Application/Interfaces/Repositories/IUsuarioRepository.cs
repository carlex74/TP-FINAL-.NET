using Domain.Entities;
using System.Threading.Tasks;

namespace ApplicationClean.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetByLegajoAsync(string legajo);
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task AddAsync(Usuario usuario);
        Task UpdateAsync(Usuario usuario);
        Task DeleteAsync(Usuario usuario);
    }
}