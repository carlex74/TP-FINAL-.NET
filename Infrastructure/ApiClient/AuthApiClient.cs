using System.Net.Http.Json;
using System.Text.Json;
using ApplicationClean.DTOs;
using ApplicationClean.Interfaces;

namespace Infrastructure.ApiClients
{
    public class AuthApiClient : IAPIAuthClients
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _jsonOptions;

        public AuthApiClient(HttpClient client, JsonSerializerOptions jsonOptions)
        {
            _client = client;
            _jsonOptions = jsonOptions;
        }

        public async Task<LoginResponseDTO> LoginAsync(string legajo, string clave)
        {
            var loginRequest = new LoginRequestDTO { Legajo = legajo, Clave = clave };

            HttpResponseMessage response = await _client.PostAsJsonAsync("auth/login", loginRequest);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<LoginResponseDTO>(_jsonOptions);
            }
            return null;
        }
    }
}