using System.Net.Http.Headers;
using System.Net.Http.Json;
using Application.DTOs;
using Application.Interfaces;


namespace Infrastructure.ApiClients
{
    public class PlanApiClient
    {
        private static HttpClient client = new HttpClient();

        static PlanApiClient()
        {
            client.BaseAddress = new Uri("http://localhost:5183/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<PlanDTO> GetById(int id)
        {
            PlanDTO plan = null;
            HttpResponseMessage response = await client.GetAsync("planes/" + id);
            if (response.IsSuccessStatusCode)
            {
                plan = await response.Content.ReadAsAsync<PlanDTO>();
            }
            return plan;
        }


        public static async Task<IEnumerable<PlanDTO>> GetAll()
        {
            IEnumerable<PlanDTO> planes = null;
            HttpResponseMessage response = await client.GetAsync("planes");
            if (response.IsSuccessStatusCode)
            {
                planes = await response.Content.ReadAsAsync<IEnumerable<PlanDTO>>();
            }
            return planes;
        }


        public static async Task Add(PlanDTO plan)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("planes", plan);
            response.EnsureSuccessStatusCode();
        }

        public static async Task Delete(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync("planes/" + id);
            response.EnsureSuccessStatusCode();
        }

        
        public static async Task Update(PlanDTO plan)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync("planes/" + plan.Id, plan);
            response.EnsureSuccessStatusCode();
        }


    }

}
