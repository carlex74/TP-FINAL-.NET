using ApplicationClean.DTOs;

namespace ApplicationClean.Interfaces.ApiClients
{
    public interface IAlumnoInscripcionClients
    {
        Task<AlumnoInscripcionDTO> GetById(string legajo, int idCurso);

        Task<IEnumerable<AlumnoInscripcionDTO>> GetAll();

        Task Add(AlumnoInscripcionDTO inscripcion);

        Task Update(AlumnoInscripcionDTO inscripcion);

        // A FUTURO: Se puede reactivar la llamada al endpoint de borrado.
        //Task Delete(string legajo, int idCurso);
    }
}
