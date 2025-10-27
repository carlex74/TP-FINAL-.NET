using ApplicationClean.DTOs;

namespace ApplicationClean.Interfaces
{
    public interface IPersonaService
    {
        Task<PersonaDTO> GetByIdAsync(int id);
        Task<IEnumerable<PersonaDTO>> GetAllAsync();
        Task<PersonaDTO> AddAsync(PersonaDTO personaDto);
        Task<PersonaDTO> UpdateAsync(PersonaDTO personaDto);
        // A FUTURO: Se puede reactivar la funcionalidad de borrado.
        // Task<bool> DeleteAsync(int id);
    }
}