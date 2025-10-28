using Application.Interfaces.Repositories;

namespace Application.Interfaces.ApiClients
{
    public interface IAPIReportesClient
    {
        Task<IEnumerable<RendimientoCursoDto>> GetRendimientoCursoAsync(int cursoId);
        Task<IEnumerable<HistorialAlumnoDto>> GetHistorialAlumnoAsync(string legajo);
    }
}