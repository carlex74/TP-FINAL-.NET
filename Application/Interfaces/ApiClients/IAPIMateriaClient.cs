

using ApplicationClean.DTOs;

namespace ApplicationClean.Interfaces.ApiClients
{
    public interface IAPIMateriaClient
    {
        Task<MateriaDTO> GetById(int id);
        Task<IEnumerable<MateriaDTO>> GetAll();
        Task<MateriaDTO> Add(MateriaDTO materia);
        Task Delete(int id);
        Task Update(MateriaDTO materia);
        Task AssignPlanes(int materiaId, List<int> planIds);
    }
}
