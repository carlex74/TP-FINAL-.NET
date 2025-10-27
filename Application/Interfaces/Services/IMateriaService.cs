using ApplicationClean.DTOs;

namespace ApplicationClean.Interfaces.Services
{
    public interface IMateriaService
    {
        Task<MateriaDTO> GetByIdAsync(int id);
        Task<IEnumerable<MateriaDTO>> GetAllAsync();
        Task<MateriaDTO> AddAsync(MateriaDTO materiaDto);
        Task<MateriaDTO> UpdateAsync(MateriaDTO materiaDto);
        // A FUTURO: Se puede reactivar la funcionalidad de borrado.
        // Task<bool> DeleteAsync(int id);
        Task AssignPlanesAsync(int materiaId, List<int> planIds);
    }
}
