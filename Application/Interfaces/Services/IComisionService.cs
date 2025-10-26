using ApplicationClean.DTOs;

namespace ApplicationClean.Interfaces.Services
{
    public interface IComisionService
    {
        Task<ComisionDTO> AddAsync(ComisionDTO comisionDTO);
        Task<ComisionDTO> UpdateAsync(ComisionDTO comisionDTO);
        Task<bool> DeleteAsync(int id);
        Task<ComisionDTO> GetByIdAsync(int id);
        Task<IEnumerable<ComisionDTO>> GetAllAsync();
        Task AssignPlanesAsync(int comisionId, List<int> planIds);
    }
}
