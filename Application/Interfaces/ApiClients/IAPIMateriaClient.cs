using ApplicationClean.DTOs;

namespace ApplicationClean.Interfaces.ApiClients
{
    public interface IAPIMateriaClient
    {
        Task<MateriaDTO> GetById(int id);
        Task<IEnumerable<MateriaDTO>> GetAll();
        Task<MateriaDTO> Add(MateriaDTO materia);
        // A FUTURO: Se puede reactivar la llamada al endpoint de borrado.
        //Task Delete(int id);
        Task Update(MateriaDTO materia);
        Task AssignPlanes(int materiaId, List<int> planIds);
    }
}
