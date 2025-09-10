

using Domain.Entities;

namespace ApplicationClean.Interfaces.Repositories
{
    public interface IComisionRepository
    {
        Task<Comision> AddAsync(Comision comision);
        Task<Comision> UpdateAsync(Comision comision);
        Task DeleteAsync(Comision comision);

        Task<Comision> GetByIdAsync(int id);
        Task<IEnumerable<Comision>> GetAllAsync();
    }
}
