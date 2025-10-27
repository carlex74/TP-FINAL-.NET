using ApplicationClean.DTOs;

namespace ApplicationClean.Interfaces.ApiClients
{
    public interface IAPIPlanClients
    {
        Task<PlanDTO> GetById(int id);
        Task<IEnumerable<PlanDTO>> GetAll();
        Task Add(CrearPlanDTO plan);
        // A FUTURO: Se puede reactivar la llamada al endpoint de borrado.
        //Task Delete(int id);
        Task Update(PlanDTO plan);
    }
}
