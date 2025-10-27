using ApplicationClean.DTOs;
using ApplicationClean.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuariosController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(UsuarioDTO), 201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Create(CrearUsuarioDTO crearUsuarioDto)
    {
        var nuevoUsuario = await _usuarioService.CreateUsuarioAsync(crearUsuarioDto);
        return StatusCode(201, nuevoUsuario);
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<UsuarioDTO>), 200)]
    public async Task<IActionResult> GetAll()
    {
        var usuarios = await _usuarioService.GetAllAsync();
        return Ok(usuarios);
    }

    [HttpGet("{legajo}", Name = "GetUsuarioByLegajo")]
    [ProducesResponseType(typeof(UsuarioDTO), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetByLegajo(string legajo)
    {
        var usuario = await _usuarioService.GetByLegajoAsync(legajo);
        if (usuario == null)
        {
            return NotFound();
        }
        return Ok(usuario);
    }

    [HttpPut("{legajo}")]
    [ProducesResponseType(typeof(UsuarioDTO), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Update(string legajo, ActualizarUsuarioDTO dto)
    {
        var usuarioActualizado = await _usuarioService.UpdateAsync(legajo, dto);
        return Ok(usuarioActualizado);
    }

    /*
    A FUTURO: El endpoint de borrado puede ser reactivado.
    [HttpDelete("{legajo}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Delete(string legajo)
    {
        await _usuarioService.DeleteAsync(legajo);
        return NoContent();
    }
    */
}