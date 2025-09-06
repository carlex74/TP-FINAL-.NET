using ApplicationClean.DTOs;
using ApplicationClean.Interfaces;
using ApplicationClean.Interfaces.ApiClients;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.ApiClients
{
    public class UsuarioApiClient : IAPIUsuarioClients
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public UsuarioApiClient(HttpClient httpClient, JsonSerializerOptions jsonOptions)
        {
            _httpClient = httpClient;
            _jsonOptions = jsonOptions;
        }

        public async Task<IEnumerable<UsuarioDTO>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<UsuarioDTO>>("usuarios", _jsonOptions);
        }

        public async Task<UsuarioDTO> GetByLegajo(string legajo)
        {
            return await _httpClient.GetFromJsonAsync<UsuarioDTO>($"usuarios/{legajo}", _jsonOptions);
        }

        public async Task<UsuarioDTO> Add(CrearUsuarioDTO crearUsuarioDto)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("usuarios", crearUsuarioDto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<UsuarioDTO>(_jsonOptions);
        }

        public async Task Update(string legajo, ActualizarUsuarioDTO actualizarUsuarioDto)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"usuarios/{legajo}", actualizarUsuarioDto);
            response.EnsureSuccessStatusCode();
        }

        public async Task Delete(string legajo)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"usuarios/{legajo}");
            response.EnsureSuccessStatusCode();
        }
    }
}