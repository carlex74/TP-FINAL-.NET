using ApplicationClean.DTOs;

namespace ApplicationClean.Interfaces.Services
{
    public interface IAlumnoInscripcionService
    {
        Task<AlumnoInscripcionDTO> AddAsync(AlumnoInscripcionDTO inscripcion);
        Task<AlumnoInscripcionDTO> UpdateAsync(AlumnoInscripcionDTO inscripcion);
        Task<AlumnoInscripcionDTO> GetByIdAsync(string legajo, int idCurso);
        Task<IEnumerable<AlumnoInscripcionDTO>> GetAllAsync();
        Task<bool> DeleteAsync(string legajo, int idCurso);
        Task<IEnumerable<AlumnoInscripcionDTO>> GetInscripcionesPorCursoAsync(int idCurso);
    }
}
