using ApplicationClean.DTOs;

namespace ApplicationClean.Interfaces
{
    public interface IPlanService
    {

        Task<PlanDTO> AddAsync(PlanDTO plan);

        Task<PlanDTO> UpdateAsync(PlanDTO plan);

        Task<bool> DeleteAsync(int id);

        Task<PlanDTO> GetByIdAsync(int id);

        Task<IEnumerable<PlanDTO>> GetAllAsync();


    }
}
