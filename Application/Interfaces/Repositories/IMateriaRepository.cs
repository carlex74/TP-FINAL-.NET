using Domain.Entities;

namespace ApplicationClean.Interfaces.Repositories
{
    public interface IMateriaRepository
    {
        Task<Materia> GetByIdAsync(int id);
        Task<IEnumerable<Materia>> GetAllAsync();
        Task AddAsync(Materia materia);
        Task UpdateAsync(Materia materia);
        Task DeleteAsync(Materia materia);
        Task<Materia> GetByIdWithPlanesAsync(int id);
        Task<bool> NombreExistsAsync(string nombre, int? excludeId = null);
        Task<bool> ExistsAsync(int id);
    }
}
