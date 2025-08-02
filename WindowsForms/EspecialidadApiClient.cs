using DTOs;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace WindowsForms
{
    public class EspecialidadApiClient
    {
        private static HttpClient client = new HttpClient();
        static EspecialidadApiClient()
        {
            client.BaseAddress = new Uri("http://localhost:5183/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public static async Task<EspecialidadDTO> GetAsync(int id)
        {
            EspecialidadDTO especialidad = null;
            HttpResponseMessage response = await client.GetAsync("especialidades/" + id);
            if (response.IsSuccessStatusCode)
            {
                especialidad = await response.Content.ReadAsAsync<EspecialidadDTO>();
            }
            return especialidad;
        }

        public static async Task<IEnumerable<EspecialidadDTO>> GetAllAsync()
        {
            IEnumerable<EspecialidadDTO> especialidades = null;
            HttpResponseMessage response = await client.GetAsync("especialidad");
            if (response.IsSuccessStatusCode)
            {
                especialidades = await response.Content.ReadAsAsync<IEnumerable<EspecialidadDTO>>();
            }
            return especialidades;
        }

        public async static Task AddAsync(EspecialidadDTO especialidad)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("especialidades", especialidad);
            response.EnsureSuccessStatusCode();
        }

        public static async Task DeleteAsync(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync("especialidades/" + id);
            response.EnsureSuccessStatusCode();
        }

        public static async Task UpdateAsync(EspecialidadDTO especialidad)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync("especialidades", especialidad);
            response.EnsureSuccessStatusCode();
        }
    }
}
