using Domain.Entities;

namespace ApplicationClean.Interfaces.Repositories
{
    public interface IEspecialidadRepository
    {
        Task AddAsync(Especialidad especialidad);
        Task UpdateAsync(Especialidad especialidad);
        // A FUTURO: Se puede reactivar el borrado físico o lógico.
        //Task DeleteAsync(Especialidad especialidad);
        Task<Especialidad> GetByIdAsync(int id);
        Task<IEnumerable<Especialidad>> GetAllAsync();

        Task<bool> DescripcionExistsAsync(string descripcion, int? excludeId = null);

        Task<bool> ExistsAsync(int id);

    }
}
