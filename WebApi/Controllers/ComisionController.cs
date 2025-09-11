using ApplicationClean.DTOs;
using ApplicationClean.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class ComisionesController : ControllerBase
{
    private readonly IComisionService _comisionService;

    public ComisionesController(IComisionService comisionService)
    {
        _comisionService = comisionService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var comisiones = await _comisionService.GetAllAsync();
        return Ok(comisiones);
    }

    [HttpGet("{id}", Name = "GetComisionById")]
    public async Task<IActionResult> GetById(int id)
    {
        var comision = await _comisionService.GetByIdAsync(id);
        if (comision == null) return NotFound();
        return Ok(comision);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ComisionDTO comisionDto)
    {
        try
        {
            var nuevaComision = await _comisionService.AddAsync(comisionDto);
            return CreatedAtRoute("GetComisionById", new { id = nuevaComision.Nro }, nuevaComision);
        }
        catch (System.Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ComisionDTO comisionDto)
    {
        if (id != comisionDto.Nro) return BadRequest("ID de la ruta no coincide con el ID del objeto.");

        try
        {
            await _comisionService.UpdateAsync(comisionDto);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _comisionService.DeleteAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }

    [HttpPut("{id}/planes")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AssignPlanes(int id, [FromBody] List<int> planIds)
    {
        try
        {
            await _comisionService.AssignPlanesAsync(id, planIds);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}