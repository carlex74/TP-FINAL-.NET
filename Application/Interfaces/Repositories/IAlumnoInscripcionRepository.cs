using Domain.Entities;

namespace ApplicationClean.Interfaces.Repositories
{
    public interface IAlumnoInscripcionRepository
    {
        Task<AlumnoInscripcion> GetByIdAsync(string legajo, int idCurso);
        Task<IEnumerable<AlumnoInscripcion>> GetAllAsync();
        Task AddAsync(AlumnoInscripcion inscripcion);
        Task UpdateAsync(AlumnoInscripcion inscripcion);
        // A FUTURO: Se puede reactivar el borrado físico o lógico.
        //Task DeleteAsync(AlumnoInscripcion inscripcion);
        Task<IEnumerable<AlumnoInscripcion>> GetInscripcionesPorCursoAsync(int idCurso);
        Task<AlumnoInscripcion> GetWithDetailsByIdAsync(string legajo, int idCurso);
        /*
        A FUTURO: Este método era para buscar inscripciones borradas lógicamente para la re-inscripción.
        Task<AlumnoInscripcion> GetHistoricalByIdAsync(string legajo, int idCurso);
        */

    }
}
