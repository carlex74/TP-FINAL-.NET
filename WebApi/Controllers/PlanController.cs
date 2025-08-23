using ApplicationClean.DTOs;
using ApplicationClean.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PlanesController : ControllerBase
{
    private readonly PlanServices _planServices;

    public PlanesController(PlanServices planServices)
    {
        _planServices = planServices;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<PlanDTO>), StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        var dtos = _planServices.GetAll();
        return Ok(dtos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(PlanDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(int id)
    {
        var dto = _planServices.GetById(id);
        if (dto == null)
        {
            return NotFound();
        }
        return Ok(dto);
    }

    [HttpPost]
    [ProducesResponseType(typeof(PlanDTO), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Create(PlanDTO dto)
    {
        try
        {
            var planDTO = _planServices.Add(dto);
            return CreatedAtAction(nameof(GetById), new { id = planDTO.Id }, planDTO);
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
    public IActionResult Update(int id, PlanDTO dto)
    {
        if (id != dto.Id)
        {
            return BadRequest("El ID de la ruta no coincide con el ID del cuerpo de la solicitud.");
        }

        try
        {
            _planServices.Update(dto);
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
        var deleted = _planServices.Delete(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}
