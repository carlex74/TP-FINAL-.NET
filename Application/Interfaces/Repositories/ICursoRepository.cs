using Domain.Entities;

namespace ApplicationClean.Interfaces.Repositories
{
    public interface ICursoRepository
    {
        Task AddAsync(Curso curso);
        Task UpdateAsync(Curso curso);
        // A FUTURO: Se puede reactivar el borrado físico o lógico.
        //Task DeleteAsync(Curso curso);
        Task<Curso> GetByIdAsync(int id);
        Task<IEnumerable<Curso>> GetAllAsync();
        Task<bool> CursoExistsAsync(int idMateria, int idComision, int anioCalendario, int? excludeId = null);

        Task<bool> ExistsAsync(int id);
    }
}
