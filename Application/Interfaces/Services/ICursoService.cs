using ApplicationClean.DTOs;

namespace ApplicationClean.Interfaces.Services
{
    public interface ICursoService
    {
        Task<CursoDTO> AddAsync(CursoDTO cursoDTO);
        Task<CursoDTO> UpdateAsync(CursoDTO cursoDTO);
        // A FUTURO: Se puede reactivar la funcionalidad de borrado.
        // Task<bool> DeleteAsync(int id);
        Task<CursoDTO> GetByIdAsync(int id);
        Task<IEnumerable<CursoDTO>> GetAllAsync();
    }
}
