using Application.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.ApiClients
{
    public interface IAPIReportesClient
    {
        Task<IEnumerable<RendimientoCursoDto>> GetRendimientoCursoAsync(int cursoId);
        Task<IEnumerable<HistorialAlumnoDto>> GetHistorialAlumnoAsync(string legajo);
    }
}