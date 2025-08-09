using Application.DTOs;

namespace Application.Interfaces
{
    public interface IPlanService
    {
        
        PlanDTO add(PlanDTO plan);

        PlanDTO update(PlanDTO plan);

        bool delete(int id);

        PlanDTO getById(int id);

        IEnumerable<PlanDTO> getAll();


    }
}
