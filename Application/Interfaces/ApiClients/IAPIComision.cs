

using ApplicationClean.DTOs;

namespace ApplicationClean.Interfaces.ApiClients
{
    public interface IAPIComision
    {
        Task<ComisionDTO> GetById(int id);
        Task<IEnumerable<ComisionDTO>> GetAll();

        Task Add(ComisionDTO comision);

        Task Delete(int id);

        Task Update(ComisionDTO comision);
    }
}
