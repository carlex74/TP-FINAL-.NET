using ApplicationClean.DTOs;

namespace ApplicationClean.Interfaces.ApiClients
{
    public interface IAPIComisionClient
    {
        Task<ComisionDTO> GetById(int id);
        Task<IEnumerable<ComisionDTO>> GetAll();
        Task<ComisionDTO> Add(ComisionDTO comision);
        // A FUTURO: Se puede reactivar la llamada al endpoint de borrado.
        //Task Delete(int id);
        Task Update(ComisionDTO comision);
        Task AssignPlanes(int comisionId, List<int> planIds);
    }
}
