using Domain.Entities;

namespace ApplicationClean.Interfaces.Repositories
{
    public interface IComisionRepository
    {
        Task AddAsync(Comision comision);
        Task UpdateAsync(Comision comision);
        Task DeleteAsync(Comision comision);
        Task<Comision> GetByIdAsync(int id);
        Task<IEnumerable<Comision>> GetAllAsync();
        Task<Comision> GetByIdWithPlanesAsync(int id);
        Task<bool> DescripcionExistsAsync(string descripcion, int? excludeId = null);

        Task<bool> ExistsAsync(int id);
    }
}
