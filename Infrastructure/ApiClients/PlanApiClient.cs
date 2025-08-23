using System.Net.Http.Headers;
using System.Net.Http.Json;
using ApplicationClean.DTOs;
using ApplicationClean.Interfaces;


namespace Infrastructure.ApiClients
{
    public class PlanApiClient : IAPIPlanClients
    {
        private readonly HttpClient _client;

        public PlanApiClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<PlanDTO> GetById(int id)
        {
            PlanDTO plan = null;
            HttpResponseMessage response = await _client.GetAsync("planes/" + id);
            if (response.IsSuccessStatusCode)
            {
                plan = await response.Content.ReadAsAsync<PlanDTO>();
            }
            return plan;
        }


        public async Task<IEnumerable<PlanDTO>> GetAll()
        {
            IEnumerable<PlanDTO> planes = null;
            HttpResponseMessage response = await _client.GetAsync("planes");
            if (response.IsSuccessStatusCode)
            {
                planes = await response.Content.ReadAsAsync<IEnumerable<PlanDTO>>();
            }
            return planes;
        }


        public async Task Add(PlanDTO plan)
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync("planes", plan);
            response.EnsureSuccessStatusCode();
        }

        public async Task Delete(int id)
        {
            HttpResponseMessage response = await _client.DeleteAsync("planes/" + id);
            response.EnsureSuccessStatusCode();
        }

        
        public async Task Update(PlanDTO plan)
        {
            HttpResponseMessage response = await _client.PutAsJsonAsync("planes/" + plan.Id, plan);
            response.EnsureSuccessStatusCode();
        }
    }
}
