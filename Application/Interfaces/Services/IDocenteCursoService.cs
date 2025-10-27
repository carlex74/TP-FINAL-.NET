using ApplicationClean.DTOs;

namespace ApplicationClean.Interfaces.Services
{
    public interface IDocenteCursoService
    {
        Task<DocenteCursoDTO> AddAsync(DocenteCursoDTO docenteCursoDTO);
        Task<DocenteCursoDTO> UpdateAsync(DocenteCursoDTO docenteCursoDTO);
        Task<DocenteCursoDTO> GetByIdAsync(int idCurso, string legajoDocente);
        Task<IEnumerable<DocenteCursoDTO>> GetAllAsync();
        // A FUTURO: Se puede reactivar la funcionalidad de borrado.
        // Task<bool> DeleteAsync(int idCurso, string legajoDocente);
    }
}
