using Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ReportesController : ControllerBase
{
    private readonly IReportesService _reportesService;

    public ReportesController(IReportesService reportesService)
    {
        _reportesService = reportesService;
    }

    [HttpGet("rendimiento/{cursoId}")]
    public async Task<IActionResult> GetRendimientoCurso(int cursoId)
    {
        var data = await _reportesService.GetRendimientoCursoAsync(cursoId);
        return Ok(data);
    }

    [HttpGet("historial/{legajo}")]
    public async Task<IActionResult> GetHistorialAlumno(string legajo)
    {
        var data = await _reportesService.GetHistorialAlumnoAsync(legajo);
        return Ok(data);
    }
}