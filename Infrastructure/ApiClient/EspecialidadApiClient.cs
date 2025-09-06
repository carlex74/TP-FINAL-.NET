using System.Net.Http.Headers;
using System.Net.Http.Json;
using ApplicationClean.DTOs;
using ApplicationClean.Interfaces.ApiClients;


namespace Infrastructure.ApiClients
{
    public class EspecialidadApiClient : IAPIEspecialidadClients
    {
        private readonly HttpClient _client;

        public EspecialidadApiClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<EspecialidadDTO> GetById(int id)
        {
            EspecialidadDTO especialidad = null;
            HttpResponseMessage response = await _client.GetAsync("especialidades/" + id);
            if (response.IsSuccessStatusCode)
            {
                especialidad = await response.Content.ReadAsAsync<EspecialidadDTO>();
            }
            return especialidad;
        }


        public async Task<IEnumerable<EspecialidadDTO>> GetAll()
        {
            IEnumerable<EspecialidadDTO> especialidades = null;
            HttpResponseMessage response = await _client.GetAsync("especialidades");
            if (response.IsSuccessStatusCode)
            {
                especialidades = await response.Content.ReadAsAsync<IEnumerable<EspecialidadDTO>>();
            }
            return especialidades;
        }


        public async Task Add(EspecialidadDTO especialidad)
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync("especialidades", especialidad);
            response.EnsureSuccessStatusCode();
        }

        public async Task Delete(int id)
        {
            HttpResponseMessage response = await _client.DeleteAsync("especialidades/" + id);
            response.EnsureSuccessStatusCode();
        }


        public async Task Update(EspecialidadDTO especialidad)
        {
            HttpResponseMessage response = await _client.PutAsJsonAsync("especialidades/" + especialidad.Id, especialidad);
            response.EnsureSuccessStatusCode();
        }
    }
}

