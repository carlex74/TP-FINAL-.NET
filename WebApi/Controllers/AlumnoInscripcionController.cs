using ApplicationClean.DTOs;
using ApplicationClean.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class AlumnoInscripcionController : ControllerBase
{
    private readonly IAlumnoInscripcionService _inscripcionService;

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

            return CreatedAtRoute(
                "GetInscripcionById",
                new { legajoAlumno = nuevaInscripcion.LegajoAlumno, idCurso = nuevaInscripcion.IdCurso },
                nuevaInscripcion);
        }
        catch (System.Exception ex)
        {
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
        if (legajoAlumno != inscripcionDto.LegajoAlumno || idCurso != inscripcionDto.IdCurso)
        {
            return BadRequest("Los identificadores de la ruta no coinciden con los del objeto.");
        }

        try
        {
            await _inscripcionService.UpdateAsync(inscripcionDto);
            return NoContent();
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

    /// <summary>
    /// Elimina (anula) una inscripción existente.
    /// </summary>
    [HttpDelete("{legajoAlumno}/{idCurso}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Delete(string legajoAlumno, int idCurso)
    {
        try
        {
            var success = await _inscripcionService.DeleteAsync(legajoAlumno, idCurso);
            if (!success)
            {
                return NotFound("No se encontró la inscripción para anular.");
            }
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}