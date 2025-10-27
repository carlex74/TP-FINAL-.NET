using System.Net.Http.Json;
using ApplicationClean.DTOs;
using ApplicationClean.Interfaces.ApiClients;

namespace Infrastructure.ApiClients
{
    public class MateriaApiClient : IAPIMateriaClient
    {
        private readonly HttpClient _client;

        public MateriaApiClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<MateriaDTO> GetById(int id)
        {
            return await _client.GetFromJsonAsync<MateriaDTO>($"materias/{id}");
        }

        public async Task<IEnumerable<MateriaDTO>> GetAll()
        {
            return await _client.GetFromJsonAsync<IEnumerable<MateriaDTO>>("materias");
        }

        public async Task<MateriaDTO> Add(MateriaDTO materia)
        {
            var response = await _client.PostAsJsonAsync("materias", materia);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<MateriaDTO>();
        }

        public async Task Update(MateriaDTO materia)
        {
            var response = await _client.PutAsJsonAsync($"materias/{materia.Id}", materia);
            response.EnsureSuccessStatusCode();
        }

        /*
        A FUTURO: Implementación de la llamada al endpoint DELETE.
        public async Task Delete(int id)
        {
            var response = await _client.DeleteAsync($"materias/{id}");
            response.EnsureSuccessStatusCode();
        }
        */

        public async Task AssignPlanes(int materiaId, List<int> planIds)
        {
            var response = await _client.PutAsJsonAsync($"materias/{materiaId}/planes", planIds);
            response.EnsureSuccessStatusCode();
        }
    }
}