using Domain.Entities;

namespace ApplicationClean.Interfaces.Repositories
{
    public interface IEspecialidadRepository
    {
        Task AddAsync(Especialidad especialidad);
        Task UpdateAsync(Especialidad especialidad);
        Task DeleteAsync(Especialidad especialidad);

        Task<Especialidad> GetByIdAsync(int id);
        Task<IEnumerable<Especialidad>> GetAllAsync();
    }
}
