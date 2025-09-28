using ApplicationClean.DTOs;
using ApplicationClean.Interfaces.ApiClients;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.ApiClient
{
    public class AlumnoInscripcionApiClient : IAlumnoInscripcionClients
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _jsonOptions;

        public AlumnoInscripcionApiClient(HttpClient client, JsonSerializerOptions jsonOptions)
        {
            _client = client;
            _jsonOptions = jsonOptions;
        }

        public async Task<IEnumerable<AlumnoInscripcionDTO>> GetAll()
        {
            return await _client.GetFromJsonAsync<IEnumerable<AlumnoInscripcionDTO>>("AlumnoInscripcion", _jsonOptions);
        }

        public async Task<AlumnoInscripcionDTO> GetById(string legajo, int idCurso)
        {
            return await _client.GetFromJsonAsync<AlumnoInscripcionDTO>($"AlumnoInscripcion/{legajo}/{idCurso}", _jsonOptions);
        }

        public async Task Add(AlumnoInscripcionDTO inscripcion)
        {
            var response = await _client.PostAsJsonAsync("AlumnoInscripcion", inscripcion, _jsonOptions);
            response.EnsureSuccessStatusCode();
        }

        public async Task Update(AlumnoInscripcionDTO inscripcion)
        {
            var response = await _client.PutAsJsonAsync(
                $"AlumnoInscripcion/{inscripcion.LegajoAlumno}/{inscripcion.IdCurso}",
                inscripcion, _jsonOptions);
            response.EnsureSuccessStatusCode();
        }

        public async Task Delete(string legajo, int idCurso)
        {
            var response = await _client.DeleteAsync($"AlumnoInscripcion/{legajo}/{idCurso}");
            response.EnsureSuccessStatusCode();
        }

    }
}
