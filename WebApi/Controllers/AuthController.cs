using ApplicationClean.DTOs;
using ApplicationClean.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public AuthController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpPost("login")]
    [ProducesResponseType(typeof(UsuarioDTO), 200)]
    [ProducesResponseType(401)]
    public async Task<IActionResult> Login(LoginRequestDTO loginRequest)
    {
        var usuarioDto = await _usuarioService.LoginAsync(loginRequest);

        if (usuarioDto == null)
        {
            return Unauthorized("Legajo o contraseña incorrectos.");
        }

        return Ok(usuarioDto);
    }
}