using Domain.Entities;

namespace ApplicationClean.Interfaces.Repositories
{
    public interface IDocenteCursoRepository
    {
        Task AddAsync(DocenteCurso docenteCurso);
        Task UpdateAsync(DocenteCurso docenteCurso);
        // A FUTURO: Se puede reactivar el borrado físico o lógico.
        //Task DeleteAsync(DocenteCurso docenteCurso);

        Task<DocenteCurso> GetByIdAsync(int idCurso, string legajoDocente);
        Task<IEnumerable<DocenteCurso>> GetAllAsync();
    }
}
