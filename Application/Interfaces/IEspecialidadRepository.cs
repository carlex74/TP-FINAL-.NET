using Domain.Entities;

namespace Domain.Interfaces
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
