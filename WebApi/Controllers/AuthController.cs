using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ApplicationClean.DTOs;
using ApplicationClean.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;
    private readonly IConfiguration _configuration;

    public AuthController(IUsuarioService usuarioService, IConfiguration configuration)
    {
        _usuarioService = usuarioService;
        _configuration = configuration;
    }

    [HttpPost("login")]
    [ProducesResponseType(typeof(LoginResponseDTO), 200)]
    [ProducesResponseType(401)]
    public async Task<IActionResult> Login(LoginRequestDTO loginRequest)
    {
        var usuarioDto = await _usuarioService.LoginAsync(loginRequest);

        if (usuarioDto == null)
        {
            return Unauthorized("Legajo o contraseña incorrectos.");
        }
        var token = GenerateJwtToken(usuarioDto);

        var response = new LoginResponseDTO
        {
            Token = token,
            Usuario = usuarioDto
        };

        return Ok(response);
    }

    private string GenerateJwtToken(UsuarioDTO usuario)
    {
        // Esta es la línea clave. Le decimos al manejador que no reemplace los nombres de los claims.
        var tokenHandler = new JwtSecurityTokenHandler { OutboundClaimTypeMap = new Dictionary<string, string>() };

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
        new Claim(JwtRegisteredClaimNames.Sub, usuario.Legajo),
        new Claim("nombreCompleto", usuario.PersonaNombreCompleto ?? string.Empty),
        new Claim(ClaimTypes.Role, usuario.Tipo.ToString()), // Ahora esto se escribirá como la URL larga
        new Claim("planId", usuario.IdPlan?.ToString() ?? string.Empty),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(8),
            Issuer = _configuration["Jwt:Issuer"],
            Audience = _configuration["Jwt:Audience"],
            SigningCredentials = credentials
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}