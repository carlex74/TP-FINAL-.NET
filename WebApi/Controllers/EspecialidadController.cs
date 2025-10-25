using ApplicationClean.DTOs;
using ApplicationClean.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class EspecialidadesController : ControllerBase
{
    private readonly IEspecialidadService _especialidadService;

    public EspecialidadesController(IEspecialidadService especialidadService)
    {
        _especialidadService = especialidadService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<EspecialidadDTO>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync()
    {
        var dtos = await _especialidadService.GetAllAsync();
        return Ok(dtos);
    }

    [HttpGet("{id}", Name = "GetEspecialidadById")]
    [ProducesResponseType(typeof(EspecialidadDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var dto = await _especialidadService.GetByIdAsync(id);
        if (dto == null)
        {
            return NotFound();
        }
        return Ok(dto);
    }

    [HttpPost]
    [ProducesResponseType(typeof(EspecialidadDTO), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateAsync(EspecialidadDTO dto)
    {
        var especialidadDTO = await _especialidadService.AddAsync(dto);

        return CreatedAtRoute("GetEspecialidadById", new { id = especialidadDTO.Id }, especialidadDTO);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateAsync(int id, EspecialidadDTO dto)
    {
        if (id != dto.Id)
        {
            return BadRequest("El ID de la ruta no coincide con el ID del cuerpo de la solicitud.");
        }

        await _especialidadService.UpdateAsync(dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _especialidadService.DeleteAsync(id);
        return NoContent();
    }
}