using Application.DTOs;
using Domain.Interfaces;
using Domain.Entities;
using Application.Interfaces;
using Data;


namespace Application.Services
{
    public class PlanServices:IPlanService
    {
        private readonly IPlanRepository _planRepository;

        public PlanServices(IPlanRepository planRepository)
        {
            _planRepository = planRepository;
        }

        public PlanDTO add(PlanDTO planDTO) 
        {

            if(_planRepository.getById(planDTO.Id) != null)
            {
                throw new Exception("Ya existe un plan con el mismo ID");
            }

            int id = GetNextId();

            Plan plan = new Plan(id, planDTO.Descripcion, planDTO.IdEspecialidad);

            _planRepository.add(plan);

            planDTO.Id = plan.Id;
            planDTO.Descripcion = plan.Descripcion;
            planDTO.IdEspecialidad = plan.IdEspecialidad;
            return planDTO;
        }


        public PlanDTO getById(int id)
        {
            Plan plan = _planRepository.getById(id);
            if (plan == null)
            {
                throw new Exception("No existe un plan con el ID especificado");
            }
            return new PlanDTO
            {
                Id = plan.Id,
                Descripcion = plan.Descripcion,
                IdEspecialidad = plan.IdEspecialidad
            };
        }

        public IEnumerable<PlanDTO> getAll()
        {
            return _planRepository.getAll().Select(plan => new PlanDTO
            {
                Id = plan.Id,
                Descripcion = plan.Descripcion,
                IdEspecialidad = plan.IdEspecialidad
            });
        }


        public PlanDTO update(PlanDTO planDTO)
        {
            Plan existingPlan = _planRepository.getById(planDTO.Id);
            if (existingPlan == null)
            {
                throw new Exception("No existe un plan con el ID especificado");
            }else if (existingPlan.Descripcion.Equals(planDTO.Descripcion, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception($"Ya existe un plan con la descripcion '{planDTO.Descripcion}'.");
            }


            existingPlan.SetDescripcion(planDTO.Descripcion);
            existingPlan.SetIdEspecialidad(planDTO.IdEspecialidad);
            _planRepository.update(existingPlan);
            return new PlanDTO
            {
                Id = existingPlan.Id,
                Descripcion = existingPlan.Descripcion,
                IdEspecialidad = existingPlan.IdEspecialidad
            };
        }

        public bool delete(int id)
        {
            Plan plan = _planRepository.getById(id);
            if (plan == null)
            {
                throw new Exception("No existe un plan con el ID especificado");

                return false;
            }
            _planRepository.delete(plan);


            return true;
        }

        private static int GetNextId()
        {
            int nextId;

            if (PlanMemory.Planes.Count > 0)
            {
                nextId = PlanMemory.Planes.Max(x => x.Id) + 1;
            }
            else
            {
                nextId = 1;
            }

            return nextId;
        }

    }
}
