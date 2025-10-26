using System.Net.Http.Json;
using ApplicationClean.DTOs;
using ApplicationClean.Interfaces.ApiClients;

namespace Infrastructure.ApiClients
{
    public class ComisionApiClient : IAPIComisionClient
    {
        private readonly HttpClient _client;

        public ComisionApiClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<ComisionDTO> GetById(int id)
        {
            return await _client.GetFromJsonAsync<ComisionDTO>($"comisiones/{id}");
        }

        public async Task<IEnumerable<ComisionDTO>> GetAll()
        {
            return await _client.GetFromJsonAsync<IEnumerable<ComisionDTO>>("comisiones");
        }

        public async Task<ComisionDTO> Add(ComisionDTO comision)
        {
            var response = await _client.PostAsJsonAsync("comisiones", comision);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ComisionDTO>();
        }

        public async Task Update(ComisionDTO comision)
        {
            var response = await _client.PutAsJsonAsync($"comisiones/{comision.Nro}", comision);
            response.EnsureSuccessStatusCode();
        }

        public async Task Delete(int id)
        {
            var response = await _client.DeleteAsync($"comisiones/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task AssignPlanes(int comisionId, List<int> planIds)
        {
            var response = await _client.PutAsJsonAsync($"comisiones/{comisionId}/planes", planIds);
            response.EnsureSuccessStatusCode();
        }
    }
}