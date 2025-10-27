using System.Net.Http.Json;
using System.Text.Json;
using ApplicationClean.DTOs;
using ApplicationClean.Interfaces.ApiClients;

namespace Infrastructure.ApiClients
{
    public class PlanApiClient : IAPIPlanClients
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _jsonOptions;

        public PlanApiClient(HttpClient client, JsonSerializerOptions jsonOptions)
        {
            _client = client;
            _jsonOptions = jsonOptions;
        }

        public async Task<PlanDTO> GetById(int id)
        {
            return await _client.GetFromJsonAsync<PlanDTO>($"planes/{id}", _jsonOptions);
        }

        public async Task<IEnumerable<PlanDTO>> GetAll()
        {
            return await _client.GetFromJsonAsync<IEnumerable<PlanDTO>>("planes", _jsonOptions);
        }

        public async Task Add(CrearPlanDTO plan)
        {
            var response = await _client.PostAsJsonAsync("planes", plan, _jsonOptions);
            response.EnsureSuccessStatusCode();
        }

        /*
        A FUTURO: Implementación de la llamada al endpoint DELETE.
        public async Task Delete(int id)
        {
            var response = await _client.DeleteAsync($"planes/{id}");
            response.EnsureSuccessStatusCode();
        }
        */

        public async Task Update(PlanDTO plan)
        {
            var response = await _client.PutAsJsonAsync($"planes/{plan.Id}", plan, _jsonOptions);
            response.EnsureSuccessStatusCode();
        }
    }
}