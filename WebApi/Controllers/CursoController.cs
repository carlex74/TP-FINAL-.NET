using ApplicationClean.DTOs;
using ApplicationClean.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class CursosController : ControllerBase
{
    private readonly ICursoService _cursoService;

    public CursosController(ICursoService cursoService)
    {
        _cursoService = cursoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var cursoes = await _cursoService.GetAllAsync();
        return Ok(cursoes);
    }

    [HttpGet("{id}", Name = "GetCursoById")]
    public async Task<IActionResult> GetById(int id)
    {
        var curso = await _cursoService.GetByIdAsync(id);
        if (curso == null) return NotFound();
        return Ok(curso);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CursoDTO cursoDto)
    {
        try
        {
            var nuevaCurso = await _cursoService.AddAsync(cursoDto);
            return CreatedAtRoute("GetCursoById", new { id = nuevaCurso.Id }, nuevaCurso);
        }
        catch (System.Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CursoDTO cursoDto)
    {
        if (id != cursoDto.Id) return BadRequest("ID de la ruta no coincide con el ID del objeto.");

        try
        {
            await _cursoService.UpdateAsync(cursoDto);
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
        var deleted = await _cursoService.DeleteAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}