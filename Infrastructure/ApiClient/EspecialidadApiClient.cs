using ApplicationClean.DTOs;
using ApplicationClean.Interfaces.ApiClients;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.ApiClients
{
    public class EspecialidadApiClient : IAPIEspecialidadClients
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _jsonOptions;

        public EspecialidadApiClient(HttpClient client, JsonSerializerOptions jsonOptions)
        {
            _client = client;
            _jsonOptions = jsonOptions;
        }

        public async Task<EspecialidadDTO> GetById(int id)
        {
            return await _client.GetFromJsonAsync<EspecialidadDTO>($"especialidades/{id}", _jsonOptions);
        }

        public async Task<IEnumerable<EspecialidadDTO>> GetAll()
        {
            return await _client.GetFromJsonAsync<IEnumerable<EspecialidadDTO>>("especialidades", _jsonOptions);
        }

        public async Task Add(EspecialidadDTO especialidad)
        {
            var response = await _client.PostAsJsonAsync("especialidades", especialidad, _jsonOptions);
            response.EnsureSuccessStatusCode();
        }

        public async Task Delete(int id)
        {
            var response = await _client.DeleteAsync($"especialidades/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task Update(EspecialidadDTO especialidad)
        {
            var response = await _client.PutAsJsonAsync($"especialidades/{especialidad.Id}", especialidad, _jsonOptions);
            response.EnsureSuccessStatusCode();
        }
    }
}