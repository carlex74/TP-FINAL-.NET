using ApplicationClean.DTOs;
using ApplicationClean.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// Asumo que tienes estos DTOs y Servicios definidos en otros lugares.
// using Application.DTOs;
// using Application.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class AlumnoInscripcionController : ControllerBase
{
    private readonly IAlumnoInscripcionService _inscripcionService;

    // Inyectamos el servicio correspondiente para la lógica de inscripciones.
    public AlumnoInscripcionController(IAlumnoInscripcionService inscripcionService)
    {
        _inscripcionService = inscripcionService;
    }

    /// <summary>
    /// Obtiene todas las inscripciones de alumnos a cursos.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<AlumnoInscripcionDTO>), 200)]
    public async Task<IActionResult> GetAll()
    {
        var inscripciones = await _inscripcionService.GetAllAsync();
        return Ok(inscripciones);
    }

    /// <summary>
    /// Obtiene una inscripción específica por el legajo del alumno y el ID del curso.
    /// </summary>
    [HttpGet("{legajoAlumno}/{idCurso}", Name = "GetInscripcionById")]
    [ProducesResponseType(typeof(AlumnoInscripcionDTO), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetById(string legajoAlumno, int idCurso)
    {
        var inscripcion = await _inscripcionService.GetByIdAsync(legajoAlumno, idCurso);
        if (inscripcion == null)
        {
            return NotFound("No se encontró la inscripción para el alumno y curso especificados.");
        }
        return Ok(inscripcion);
    }

    /// <summary>
    /// Crea una nueva inscripción de un alumno a un curso.
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(AlumnoInscripcionDTO), 201)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Create(AlumnoInscripcionDTO inscripcionDto)
    {
        try
        {
            var nuevaInscripcion = await _inscripcionService.AddAsync(inscripcionDto);

            // Usamos CreatedAtRoute para devolver un 201 y la URL del nuevo recurso.
            // Los parámetros de la ruta deben coincidir con los de GetById.
            return CreatedAtRoute(
                "GetInscripcionById",
                new { legajoAlumno = nuevaInscripcion.LegajoAlumno, idCurso = nuevaInscripcion.IdCurso },
                nuevaInscripcion);
        }
        catch (System.Exception ex)
        {
            // Capturamos excepciones específicas (ej. alumno ya inscrito) si es necesario.
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Actualiza una inscripción existente (ej. para cambiar la condición o la nota).
    /// </summary>
    [HttpPut("{legajoAlumno}/{idCurso}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Update(string legajoAlumno, int idCurso, AlumnoInscripcionDTO inscripcionDto)
    {
        // Validamos que los identificadores de la ruta coincidan con los del cuerpo del request.
        if (legajoAlumno != inscripcionDto.LegajoAlumno || idCurso != inscripcionDto.IdCurso)
        {
            return BadRequest("Los identificadores de la ruta no coinciden con los del objeto.");
        }

        try
        {
            await _inscripcionService.UpdateAsync(inscripcionDto);
            return NoContent(); // 204 No Content es la respuesta estándar para un PUT exitoso.
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (System.Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}