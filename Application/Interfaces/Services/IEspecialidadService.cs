using ApplicationClean.DTOs;

namespace ApplicationClean.Interfaces.Services
{
    public interface IEspecialidadService
    {
        Task<EspecialidadDTO> AddAsync(EspecialidadDTO especialidadDTO);
        Task<EspecialidadDTO> UpdateAsync(EspecialidadDTO especialidadDTO);
        // A FUTURO: Se puede reactivar la funcionalidad de borrado.
        // Task<bool> DeleteAsync(int id);
        Task<EspecialidadDTO> GetByIdAsync(int id);
        Task<IEnumerable<EspecialidadDTO>> GetAllAsync();
    }
}
