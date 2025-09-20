using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json; // Esencial para los métodos de extensión como GetFromJsonAsync
using System.Threading.Tasks;
using ApplicationClean.DTOs;

namespace Infrastructure.ApiClient
{


    // using Application.DTOs;

    public class DocenteCursoApiClient :IAPIDocenteCursoClient
    {
        private readonly HttpClient _client;

        // El HttpClient se inyecta, configurado por IHttpClientFactory en Program.cs
        public DocenteCursoApiClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<DocenteCursoDTO>> GetAllAsync()
        {
            // La ruta base para todas las operaciones de este recurso.
            // Debe coincidir con la ruta del controlador: [Route("api/docentes-cursos")]
            return await _client.GetFromJsonAsync<IEnumerable<DocenteCursoDTO>>("api/docentes-cursos");
        }

        public async Task<DocenteCursoDTO> GetByIdAsync(int idCurso, string legajoDocente)
        {
            // Construimos la URL para la clave compuesta, siguiendo el estándar REST.
            // Esto debe coincidir con: [HttpGet("{idCurso}/{legajoDocente}")]
            return await _client.GetFromJsonAsync<DocenteCursoDTO>($"api/docentes-cursos/{idCurso}/{legajoDocente}");
        }

        public async Task AddAsync(DocenteCursoDTO docenteCurso)
        {
            var response = await _client.PostAsJsonAsync("api/docentes-cursos", docenteCurso);
            response.EnsureSuccessStatusCode(); // Lanza una excepción si la respuesta no es 2xx
        }

        public async Task UpdateAsync(DocenteCursoDTO docenteCurso)
        {
            // Para el PUT, la URL también necesita la clave compuesta.
            // La obtenemos del propio DTO que se está enviando.
            var response = await _client.PutAsJsonAsync(
                $"api/docentes-cursos/{docenteCurso.IdCurso}/{docenteCurso.LegajoDocente}",
                docenteCurso);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int idCurso, string legajoDocente)
        {
            // El DELETE usa la misma estructura de URL que el GET by ID.
            var response = await _client.DeleteAsync($"api/docentes-cursos/{idCurso}/{legajoDocente}");
            response.EnsureSuccessStatusCode();
        }
    }
}
