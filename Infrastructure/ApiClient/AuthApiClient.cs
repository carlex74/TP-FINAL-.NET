using ApplicationClean.DTOs;
using ApplicationClean.Interfaces;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Infrastructure.ApiClients
{
    public class AuthApiClient : IAPIAuthClients
    {
        private readonly HttpClient _client;

        public AuthApiClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<UsuarioDTO> LoginAsync(string legajo, string clave)
        {
            var loginRequest = new LoginRequestDTO { Legajo = legajo, Clave = clave };

            HttpResponseMessage response = await _client.PostAsJsonAsync("auth/login", loginRequest);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<UsuarioDTO>();
            }
            return null;
        }
    }
}