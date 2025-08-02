using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using DTOs;

namespace WindowsForms
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
        /// <summary>
        /// Gets a plan by its ID.
        public static async Task<PlanDTO> GetAsync(int id)
            {
                PlanDTO plan = null;
                HttpResponseMessage response=await client.GetAsync("planes/" + id);

                if(response.IsSuccessStatusCode)
                {
                    plan = await response.Content.ReadAsAsync<PlanDTO>();
                }

                return plan;

            }

        public static async Task<IEnumerable<PlanDTO>> GetAllAsync()
        {
            IEnumerable<PlanDTO> planes = null;
            HttpResponseMessage response = await client.GetAsync("plan");
            if (response.IsSuccessStatusCode)
            {
                planes = await response.Content.ReadAsAsync<IEnumerable<PlanDTO>>();
            }
            return planes;
        }

        public static async Task AddAsync(PlanDTO plan)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("planes", plan);
            response.EnsureSuccessStatusCode();
        }

        public static async Task DeleteAsync(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync("plan/" + id);
            response.EnsureSuccessStatusCode();
        }

        public static async Task UpdateAsync(PlanDTO plan)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync("planes", plan);
            response.EnsureSuccessStatusCode();
        }
    }
}
