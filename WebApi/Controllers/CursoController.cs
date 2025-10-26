using ApplicationClean.DTOs;
using ApplicationClean.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
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
        var nuevoCurso = await _cursoService.AddAsync(cursoDto);
        return CreatedAtRoute("GetCursoById", new { id = nuevoCurso.Id }, nuevoCurso);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CursoDTO cursoDto)
    {
        if (id != cursoDto.Id) return BadRequest("ID de la ruta no coincide con el ID del objeto.");

        await _cursoService.UpdateAsync(cursoDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _cursoService.DeleteAsync(id);
        return NoContent();
    }
}