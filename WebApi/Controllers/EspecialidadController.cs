using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Application.DTOs; 

[ApiController]
[Route("api/[controller]")]
public class EspecialidadesController : ControllerBase
{
    private readonly EspecialidadServices _especialidadServices;

    public EspecialidadesController(EspecialidadServices especialidadServices)
    {
        _especialidadServices = especialidadServices;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<EspecialidadDTO>), StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        var dtos = _especialidadServices.GetAll();
        return Ok(dtos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(EspecialidadDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(int id)
    {
        var dto = _especialidadServices.GetById(id);
        if (dto == null)
        {
            return NotFound();
        }
        return Ok(dto);
    }

    [HttpPost]
    [ProducesResponseType(typeof(EspecialidadDTO), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Create(EspecialidadDTO dto)
    {
        try
        {
            var especialidadDTO = _especialidadServices.Add(dto);
            return CreatedAtAction(nameof(GetById), new { id = especialidadDTO.Id }, especialidadDTO);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Update(int id, EspecialidadDTO dto)
    {
        if (id != dto.Id)
        {
            return BadRequest("El ID de la ruta no coincide con el ID del cuerpo de la solicitud.");
        }

        try
        {
            _especialidadServices.Update(dto);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(new { error = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(int id)
    {
        var deleted = _especialidadServices.Delete(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}