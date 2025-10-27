using Domain.Entities;

namespace ApplicationClean.Interfaces.Repositories
{
    public interface IPlanRepository
    {
        Task AddAsync(Plan plan);
        Task UpdateAsync(Plan plan);
        // A FUTURO: Se puede reactivar el borrado físico o lógico.
        //Task DeleteAsync(Plan plan);
        Task<Plan> GetByIdAsync(int id);
        Task<List<Plan>> GetByIdsAsync(IEnumerable<int> ids);
        Task<IEnumerable<Plan>> GetAllAsync();
        Task<bool> DescripcionExistsAsync(string descripcion, int? excludeId = null);

    }
}
