using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ApplicationClean.DTOs;
using ApplicationClean.Interfaces.ApiClients;

namespace Infrastructure.ApiClient
{
    // using Application.DTOs; // Asegúrate de tener la referencia al DTO

    // La clase implementa la interfaz que definiste.
    public class AlumnoInscripcionApiClient : IAlumnoInscripcionClients
    {
        private readonly HttpClient _client;

        // El HttpClient se inyecta, configurado por IHttpClientFactory en Program.cs de tu WinForms.
        public AlumnoInscripcionApiClient(HttpClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Obtiene todas las inscripciones de alumnos a cursos.
        /// </summary>
        public async Task<IEnumerable<AlumnoInscripcionDTO>> GetAll()
        {
            // La ruta base para el recurso de inscripciones.
            // Debe coincidir con la ruta del AlumnoInscripcionController.
            return await _client.GetFromJsonAsync<IEnumerable<AlumnoInscripcionDTO>>("api/AlumnoInscripcion");
        }

        /// <summary>
        /// Obtiene una inscripción específica por el legajo del alumno y el ID del curso.
        /// </summary>
        public async Task<AlumnoInscripcionDTO> GetById(string legajo, int idCurso)
        {
            // Construimos la URL para la clave compuesta, coincidiendo con la ruta del controlador:
            // [HttpGet("{legajoAlumno}/{idCurso}")]
            // Nota: Asegúrate de que los nombres de los parámetros coincidan.
            // Si tu controlador usa 'legajoAlumno', la ruta aquí debería ser consistente.
            return await _client.GetFromJsonAsync<AlumnoInscripcionDTO>($"api/AlumnoInscripcion/{legajo}/{idCurso}");
        }

        /// <summary>
        /// Crea una nueva inscripción.
        /// </summary>
        public async Task Add(AlumnoInscripcionDTO inscripcion)
        {
            var response = await _client.PostAsJsonAsync("api/AlumnoInscripcion", inscripcion);
            response.EnsureSuccessStatusCode(); // Lanza una excepción si la respuesta no es 2xx.
        }

        /// <summary>
        /// Actualiza una inscripción existente.
        /// </summary>
        public async Task Update(AlumnoInscripcionDTO inscripcion)
        {
            // Para el PUT, la URL también necesita la clave compuesta.
            // La obtenemos del propio DTO que se está enviando.
            // Asumo que tu DTO tiene las propiedades LegajoAlumno e IdCurso.
            var response = await _client.PutAsJsonAsync(
                $"api/AlumnoInscripcion/{inscripcion.LegajoAlumno}/{inscripcion.IdCurso}",
                inscripcion);
            response.EnsureSuccessStatusCode();
        }

        // NOTA: Tu interfaz no incluye un método Delete. Si lo necesitaras en el futuro,
        // se vería así y deberías añadirlo primero a la interfaz IAlumnoInscripcionClients.
        /*
        public async Task Delete(string legajo, int idCurso)
        {
            var response = await _client.DeleteAsync($"api/AlumnoInscripcion/{legajo}/{idCurso}");
            response.EnsureSuccessStatusCode();
        }
        */
    }
}
