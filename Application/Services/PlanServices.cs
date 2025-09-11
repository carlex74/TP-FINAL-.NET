using ApplicationClean.DTOs;
using ApplicationClean.Interfaces.Repositories;
using ApplicationClean.Interfaces.Services;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationClean.Services
{
    public class PlanServices : IPlanService
    {
        private readonly IPlanRepository _planRepository;
        private readonly IEspecialidadRepository _especialidadRepository;

        public PlanServices(IPlanRepository planRepository, IEspecialidadRepository especialidadRepository, IMateriaRepository materiaRepository)
        {
            _planRepository = planRepository;
            _especialidadRepository = especialidadRepository;
        }

        public async Task<PlanDTO> AddAsync(PlanDTO planDTO)
        {
            var especialidad = await _especialidadRepository.GetByIdAsync(planDTO.IdEspecialidad);
            if (especialidad == null)
            {
                throw new KeyNotFoundException($"No existe una especialidad con el ID {planDTO.IdEspecialidad}. No se puede crear el plan.");
            }

            var plan = new Plan(0, planDTO.Descripcion, planDTO.IdEspecialidad);
            await _planRepository.AddAsync(plan);

            planDTO.Id = plan.Id;
            return planDTO;
        }

        public async Task<PlanDTO> UpdateAsync(PlanDTO planDTO)
        {
            var existingPlan = await _planRepository.GetByIdAsync(planDTO.Id);
            if (existingPlan == null)
            {
                throw new KeyNotFoundException($"No se encontró un plan con el ID {planDTO.Id}.");
            }

            if (existingPlan.IdEspecialidad != planDTO.IdEspecialidad)
            {
                var nuevaEspecialidad = await _especialidadRepository.GetByIdAsync(planDTO.IdEspecialidad);
                if (nuevaEspecialidad == null)
                {
                    throw new KeyNotFoundException($"No existe la nueva especialidad con ID {planDTO.IdEspecialidad}.");
                }
            }

            existingPlan.SetDescripcion(planDTO.Descripcion);
            existingPlan.SetIdEspecialidad(planDTO.IdEspecialidad);

            await _planRepository.UpdateAsync(existingPlan);
            return planDTO;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var plan = await _planRepository.GetByIdAsync(id);
            if (plan == null)
            {
                return false;
            }
            await _planRepository.DeleteAsync(plan);
            return true;
        }

        public async Task<PlanDTO> GetByIdAsync(int id)
        {
            var plan = await _planRepository.GetByIdAsync(id);
            return MapToPlanDTO(plan);
        }

        public async Task<IEnumerable<PlanDTO>> GetAllAsync()
        {
            var planes = await _planRepository.GetAllAsync();
            return planes.Select(MapToPlanDTO);
        }

        private PlanDTO MapToPlanDTO(Plan plan)
        {
            if (plan == null) return null;
            return new PlanDTO
            {
                Id = plan.Id,
                Descripcion = plan.Descripcion,
                IdEspecialidad = plan.IdEspecialidad,
                EspecialidadDescripcion = plan.Especialidad?.Descripcion ?? "N/A"
            };
        }
    }
}