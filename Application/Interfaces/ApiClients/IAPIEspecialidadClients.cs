using ApplicationClean.DTOs;

namespace ApplicationClean.Interfaces.ApiClients
{
    public interface IAPIEspecialidadClients
    {
        Task<EspecialidadDTO> GetById(int id);

        Task<IEnumerable<EspecialidadDTO>> GetAll();

        Task Add(EspecialidadDTO especialidad);

        // A FUTURO: Se puede reactivar la llamada al endpoint de borrado.
        //Task Delete(int id);

        Task Update(EspecialidadDTO especialidad);
    }
}
