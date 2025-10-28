using System.Net.Http.Json;
using Application.Interfaces.ApiClients;
using Application.Interfaces.Repositories;

namespace Infrastructure.ApiClients
{
    public class ReportesApiClient : IAPIReportesClient
    {
        private readonly HttpClient _client;

        public ReportesApiClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<RendimientoCursoDto>> GetRendimientoCursoAsync(int cursoId)
        {
            return await _client.GetFromJsonAsync<IEnumerable<RendimientoCursoDto>>($"reportes/rendimiento/{cursoId}");
        }

        public async Task<IEnumerable<HistorialAlumnoDto>> GetHistorialAlumnoAsync(string legajo)
        {
            return await _client.GetFromJsonAsync<IEnumerable<HistorialAlumnoDto>>($"reportes/historial/{legajo}");
        }
    }
}