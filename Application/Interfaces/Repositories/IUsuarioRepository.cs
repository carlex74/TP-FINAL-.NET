using Domain.Entities;

namespace ApplicationClean.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetByLegajoAsync(string legajo);
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task AddAsync(Usuario usuario);
        Task UpdateAsync(Usuario usuario);
        Task DeleteAsync(Usuario usuario);

        Task<bool> LegajoExistsAsync(string legajo);

        Task<Usuario> GetByLegajoIncludingDeletedAsync(string legajo);
    }
}