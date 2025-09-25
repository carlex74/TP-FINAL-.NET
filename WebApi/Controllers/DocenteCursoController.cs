using ApplicationClean.DTOs;
using ApplicationClean.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/docentecursos")]
public class DocenteCursoController : ControllerBase
{
    private readonly IDocenteCursoService _docenteCursoService;

    public DocenteCursoController(IDocenteCursoService docenteCursoService)
    {
        _docenteCursoService = docenteCursoService;
    }

    /// <summary>
    /// Obtiene todas las asignaciones de docentes a cursos.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<DocenteCursoDTO>), 200)]
    public async Task<IActionResult> GetAll()
    {
        var asignaciones = await _docenteCursoService.GetAllAsync();
        return Ok(asignaciones);
    }

    /// <summary>
    /// Obtiene una asignación específica por ID del curso y legajo del docente.
    /// </summary>
    [HttpGet("{idCurso}/{legajoDocente}", Name = "GetDocenteCursoById")]
    [ProducesResponseType(typeof(DocenteCursoDTO), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetById(int idCurso, string legajoDocente)
    {
        var asignacion = await _docenteCursoService.GetByIdAsync(idCurso, legajoDocente);
        if (asignacion == null)
        {
            return NotFound("La asignación especificada no fue encontrada.");
        }
        return Ok(asignacion);
    }

    /// <summary>
    /// Asigna un docente a un curso.
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(DocenteCursoDTO), 201)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Create(DocenteCursoDTO docenteCursoDto)
    {
        try
        {
            var nuevaAsignacion = await _docenteCursoService.AddAsync(docenteCursoDto);

            return CreatedAtRoute(
                "GetDocenteCursoById",
                new { idCurso = nuevaAsignacion.IdCurso, legajoDocente = nuevaAsignacion.LegajoDocente },
                nuevaAsignacion);
        }
        catch (System.Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Actualiza los detalles de una asignación existente (ej. el cargo del docente).
    /// </summary>
    [HttpPut("{idCurso}/{legajoDocente}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Update(int idCurso, string legajoDocente, DocenteCursoDTO docenteCursoDto)
    {
        if (idCurso != docenteCursoDto.IdCurso || legajoDocente != docenteCursoDto.LegajoDocente)
        {
            return BadRequest("Los identificadores de la ruta no coinciden con los del cuerpo de la solicitud.");
        }

        try
        {
            await _docenteCursoService.UpdateAsync(docenteCursoDto);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}