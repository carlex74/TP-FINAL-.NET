using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json; 
using System.Threading.Tasks;
using ApplicationClean.DTOs;

namespace Infrastructure.ApiClient
{
    public class DocenteCursoApiClient : IAPIDocenteCursoClient
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _jsonOptions;

        public DocenteCursoApiClient(HttpClient client, JsonSerializerOptions jsonOptions)
        {
            _client = client;
            _jsonOptions = jsonOptions;
        }

        public async Task<IEnumerable<DocenteCursoDTO>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<IEnumerable<DocenteCursoDTO>>("docentecursos", _jsonOptions);
        }

        public async Task<DocenteCursoDTO> GetByIdAsync(int idCurso, string legajoDocente)
        {
            return await _client.GetFromJsonAsync<DocenteCursoDTO>($"docentecursos/{idCurso}/{legajoDocente}", _jsonOptions);
        }

        public async Task AddAsync(DocenteCursoDTO docenteCurso)
        {
            var response = await _client.PostAsJsonAsync("docentecursos", docenteCurso, _jsonOptions);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateAsync(DocenteCursoDTO docenteCurso)
        {
            var response = await _client.PutAsJsonAsync(
                $"docentecursos/{docenteCurso.IdCurso}/{docenteCurso.LegajoDocente}",
                docenteCurso, _jsonOptions);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int idCurso, string legajoDocente)
        {
            var response = await _client.DeleteAsync($"docentecursos/{idCurso}/{legajoDocente}");
            response.EnsureSuccessStatusCode();
        }
    }
}