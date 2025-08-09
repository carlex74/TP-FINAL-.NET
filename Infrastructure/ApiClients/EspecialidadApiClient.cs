using System.Net.Http.Headers;
using System.Net.Http.Json;
using Application.DTOs;
using Application.Interfaces;


namespace Infrastructure.ApiClients
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

        public static async Task<EspecialidadDTO> GetById(int id)
        {
            EspecialidadDTO especialidad = null;
            HttpResponseMessage response = await client.GetAsync("especialidades/" + id);
            if (response.IsSuccessStatusCode)
            {
                especialidad = await response.Content.ReadAsAsync<EspecialidadDTO>();
            }
            return especialidad;
        }


        public static async Task<IEnumerable<EspecialidadDTO>> GetAll()
        {
            IEnumerable<EspecialidadDTO> especialidades = null;
            HttpResponseMessage response = await client.GetAsync("especialidades");
            if (response.IsSuccessStatusCode)
            {
                especialidades = await response.Content.ReadAsAsync<IEnumerable<EspecialidadDTO>>();
            }
            return especialidades;
        }


        public static async Task Add(EspecialidadDTO especialidad)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("especialidades", especialidad);
            response.EnsureSuccessStatusCode();
        }

        public static async Task Delete(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync("especialidades/" + id);
            response.EnsureSuccessStatusCode();
        }


        public static async Task Update(EspecialidadDTO especialidad)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync("especialidades/" + especialidad.Id, especialidad);
            response.EnsureSuccessStatusCode();
        }
    }
}

