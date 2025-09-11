using ApplicationClean.DTOs;
using ApplicationClean.Interfaces.ApiClients;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Infrastructure.ApiClients
{
    public class CursoApiClient : IAPICursoClient
    {
        private readonly HttpClient _client;

        public CursoApiClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<CursoDTO> GetById(int id)
        {
            return await _client.GetFromJsonAsync<CursoDTO>($"cursos/{id}");
        }

        public async Task<IEnumerable<CursoDTO>> GetAll()
        {
            return await _client.GetFromJsonAsync<IEnumerable<CursoDTO>>("cursos");
        }

        public async Task Add(CursoDTO curso)
        {
            var response = await _client.PostAsJsonAsync("cursos", curso);
            response.EnsureSuccessStatusCode();
        }

        public async Task Update(CursoDTO curso)
        {
            // Asumiendo que CursoDTO tendrá una propiedad Id
            var response = await _client.PutAsJsonAsync($"cursos/{curso.Id}", curso);
            response.EnsureSuccessStatusCode();
        }

        public async Task Delete(int id)
        {
            var response = await _client.DeleteAsync($"cursos/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}