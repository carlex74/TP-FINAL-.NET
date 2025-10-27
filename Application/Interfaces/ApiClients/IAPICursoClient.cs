using ApplicationClean.DTOs;

namespace ApplicationClean.Interfaces.ApiClients
{
    public interface IAPICursoClient
    {
        Task<CursoDTO> GetById(int id);
        Task<IEnumerable<CursoDTO>> GetAll();

        Task Add(CursoDTO curso);

        // A FUTURO: Se puede reactivar la llamada al endpoint de borrado.
        //Task Delete(int id);

        Task Update(CursoDTO curso);
    }
}
