using Application.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IReportesService
    {
        Task<IEnumerable<RendimientoCursoDto>> GetRendimientoCursoAsync(int cursoId);
        Task<IEnumerable<HistorialAlumnoDto>> GetHistorialAlumnoAsync(string legajo);
    }
}