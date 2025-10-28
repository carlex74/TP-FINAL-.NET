using Application.Interfaces.Repositories;
using Application.Interfaces.Services;

namespace Application.Services
{
    public class ReportesService : IReportesService
    {
        private readonly IReportesRepository _reportesRepository;

        public ReportesService(IReportesRepository reportesRepository)
        {
            _reportesRepository = reportesRepository;
        }

        public async Task<IEnumerable<RendimientoCursoDto>> GetRendimientoCursoAsync(int cursoId)
        {
            return await _reportesRepository.GetRendimientoCursoAsync(cursoId);
        }

        public async Task<IEnumerable<HistorialAlumnoDto>> GetHistorialAlumnoAsync(string legajo)
        {
            return await _reportesRepository.GetHistorialAlumnoAsync(legajo);
        }
    }
}