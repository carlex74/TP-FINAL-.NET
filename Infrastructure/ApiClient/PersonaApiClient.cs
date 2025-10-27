using System.Net.Http.Json;
using System.Text.Json;
using ApplicationClean.DTOs;
using ApplicationClean.Interfaces.ApiClients;

namespace Infrastructure.ApiClients
{
    public class PersonaApiClient : IAPIPersonaClients
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public PersonaApiClient(HttpClient httpClient, JsonSerializerOptions jsonOptions)
        {
            _httpClient = httpClient;
            _jsonOptions = jsonOptions;
        }

        public async Task<IEnumerable<PersonaDTO>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<PersonaDTO>>("personas", _jsonOptions);
        }

        public async Task<PersonaDTO> GetById(int id)
        {
            return await _httpClient.GetFromJsonAsync<PersonaDTO>($"personas/{id}", _jsonOptions);
        }

        public async Task<PersonaDTO> Add(PersonaDTO personaDto)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("personas", personaDto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<PersonaDTO>(_jsonOptions);
        }

        public async Task Update(PersonaDTO personaDto)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"personas/{personaDto.Id}", personaDto);
            response.EnsureSuccessStatusCode();
        }

        /*
        A FUTURO: Implementación de la llamada al endpoint DELETE.
        public async Task Delete(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"personas/{id}");
            response.EnsureSuccessStatusCode();
        }
        */
    }
}