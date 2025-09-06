using ApplicationClean.DTOs;
using ApplicationClean.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class PersonasController : ControllerBase
{
    private readonly IPersonaService _personaService;

    public PersonasController(IPersonaService personaService)
    {
        _personaService = personaService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<PersonaDTO>), 200)]
    public async Task<IActionResult> GetAll()
    {
        var personas = await _personaService.GetAllAsync();
        return Ok(personas);
    }

    [HttpGet("{id}", Name = "GetPersonaById")]
    [ProducesResponseType(typeof(PersonaDTO), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetById(int id)
    {
        var persona = await _personaService.GetByIdAsync(id);
        if (persona == null)
        {
            return NotFound();
        }
        return Ok(persona);
    }

    [HttpPost]
    [ProducesResponseType(typeof(PersonaDTO), 201)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Create(PersonaDTO personaDto)
    {
        try
        {
            var nuevaPersona = await _personaService.AddAsync(personaDto);
            return CreatedAtRoute("GetPersonaById", new { id = nuevaPersona.Id }, nuevaPersona);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Update(int id, [FromBody] PersonaDTO personaDto)
    {
        if (id != personaDto.Id)
        {
            return BadRequest("El ID de la ruta no coincide con el ID del objeto.");
        }

        try
        {
            await _personaService.UpdateAsync(personaDto);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _personaService.DeleteAsync(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}