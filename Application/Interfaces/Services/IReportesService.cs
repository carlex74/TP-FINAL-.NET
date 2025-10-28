using Application.Interfaces.Repositories;

namespace Application.Interfaces.Services
{
    public interface IReportesService
    {
        Task<IEnumerable<RendimientoCursoDto>> GetRendimientoCursoAsync(int cursoId);
        Task<IEnumerable<HistorialAlumnoDto>> GetHistorialAlumnoAsync(string legajo);
    }
}