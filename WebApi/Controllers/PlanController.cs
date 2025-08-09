using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Http.HttpResults;


namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlanController
    {
        private readonly IPlanService _planService;

        public PlanController(IPlanService planService)
        {
            _planService = planService;
        }

        [HttpPost]
        public IActionResult AddPlan(Application.DTOs.PlanDTO planDTO)
        {
            try
            {
                var addedPlan = _planService.add(planDTO);
                return Ok(addedPlan);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
