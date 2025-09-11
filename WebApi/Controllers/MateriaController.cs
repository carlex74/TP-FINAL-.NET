using ApplicationClean.DTOs;
using ApplicationClean.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class MateriasController : ControllerBase
{
    private readonly IMateriaService _materiaService;

    public MateriasController(IMateriaService materiaService)
    {
        _materiaService = materiaService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var materiaes = await _materiaService.GetAllAsync();
        return Ok(materiaes);
    }

    [HttpGet("{id}", Name = "GetMateriaById")]
    public async Task<IActionResult> GetById(int id)
    {
        var materia = await _materiaService.GetByIdAsync(id);
        if (materia == null) return NotFound();
        return Ok(materia);
    }

    [HttpPost]
    public async Task<IActionResult> Create(MateriaDTO materiaDto)
    {
        try
        {
            var nuevaMateria = await _materiaService.AddAsync(materiaDto);
            return CreatedAtRoute("GetMateriaById", new { id = nuevaMateria.Id }, nuevaMateria);
        }
        catch (System.Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, MateriaDTO materiaDto)
    {
        if (id != materiaDto.Id) return BadRequest("ID de la ruta no coincide con el ID del objeto.");

        try
        {
            await _materiaService.UpdateAsync(materiaDto);
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
        var deleted = await _materiaService.DeleteAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}