using Domain.Entities;

namespace ApplicationClean.Interfaces.Repositories
{
    public interface IDocenteCursoRepository
    {
        Task AddAsync(DocenteCurso docenteCurso);
        Task UpdateAsync(DocenteCurso docenteCurso);
        Task DeleteAsync(DocenteCurso docenteCurso);

        Task<DocenteCurso> GetByIdAsync(int idCurso, string legajoDocente);
        Task<IEnumerable<DocenteCurso>> GetAllAsync();
    }
}
