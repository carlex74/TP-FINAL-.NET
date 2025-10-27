using Domain.Entities;

namespace ApplicationClean.Interfaces.Repositories
{
    public interface IMateriaRepository
    {
        Task<Materia> GetByIdAsync(int id);
        Task<IEnumerable<Materia>> GetAllAsync();
        Task AddAsync(Materia materia);
        Task UpdateAsync(Materia materia);
        // A FUTURO: Se puede reactivar el borrado físico o lógico.
        //Task DeleteAsync(Materia materia);
        Task<Materia> GetByIdWithPlanesAsync(int id);
        Task<bool> NombreExistsAsync(string nombre, int? excludeId = null);
        Task<bool> ExistsAsync(int id);
    }
}
