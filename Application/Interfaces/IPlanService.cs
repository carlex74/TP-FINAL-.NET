using ApplicationClean.DTOs;

namespace ApplicationClean.Interfaces
{
    public interface IPlanService
    {
        
        PlanDTO Add(PlanDTO plan);

        PlanDTO Update(PlanDTO plan);

        bool Delete(int id);

        PlanDTO GetById(int id);

        IEnumerable<PlanDTO> GetAll();


    }
}
