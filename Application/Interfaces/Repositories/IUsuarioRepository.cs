using Domain.Entities;

namespace ApplicationClean.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetByLegajoAsync(string legajo);
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task AddAsync(Usuario usuario);
        Task UpdateAsync(Usuario usuario);
        // A FUTURO: Se puede reactivar el borrado físico o lógico.
        //Task DeleteAsync(Usuario usuario);

        Task<bool> LegajoExistsAsync(string legajo);

        /*
        A FUTURO: Este método era para buscar usuarios borrados lógicamente.
        Task<Usuario> GetByLegajoIncludingDeletedAsync(string legajo);
        */
    }
}