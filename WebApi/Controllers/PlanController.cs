using ApplicationClean.DTOs;
using ApplicationClean.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class PlanesController : ControllerBase
{
    private readonly IPlanService _planService;

    public PlanesController(IPlanService planService)
    {
        _planService = planService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<PlanDTO>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync()
    {
        var dtos = await _planService.GetAllAsync();
        return Ok(dtos);
    }

    [HttpGet("{id}", Name = "GetPlanById")]
    [ProducesResponseType(typeof(PlanDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var dto = await _planService.GetByIdAsync(id);
        if (dto == null)
        {
            return NotFound();
        }
        return Ok(dto);
    }

    [HttpPost]
    [ProducesResponseType(typeof(PlanDTO), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateAsync([FromBody] CrearPlanDTO dto)
    {
        var planDTO = await _planService.AddAsync(dto);
        return CreatedAtRoute("GetPlanById", new { id = planDTO.Id }, planDTO);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateAsync(int id, PlanDTO dto)
    {
        if (id != dto.Id)
        {
            return BadRequest("El ID de la ruta no coincide con el ID del cuerpo de la solicitud.");
        }

        await _planService.UpdateAsync(dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _planService.DeleteAsync(id);
        return NoContent();
    }
}