using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IPlanRepository
    {
        Task AddAsync(Plan plan);
        Task UpdateAsync(Plan plan);
        Task DeleteAsync(Plan plan);
        Task<Plan> GetByIdAsync(int id);
        Task<IEnumerable<Plan>> GetAllAsync();

    }
}
