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

        public PlanDTO Add(PlanDTO planDTO) 
        {

            if(_planRepository.GetById(planDTO.Id) != null)
            {
                throw new Exception("Ya existe un plan con el mismo ID");
            }

            int id = GetNextId();

            Plan plan = new Plan(id, planDTO.Descripcion, planDTO.IdEspecialidad);

            _planRepository.Add(plan);

            planDTO.Id = plan.Id;
            planDTO.Descripcion = plan.Descripcion;
            planDTO.IdEspecialidad = plan.IdEspecialidad;
            return planDTO;
        }


        public PlanDTO GetById(int id)
        {
            Plan plan = _planRepository.GetById(id);
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

        public IEnumerable<PlanDTO> GetAll()
        {
            return _planRepository.GetAll().Select(plan => new PlanDTO
            {
                Id = plan.Id,
                Descripcion = plan.Descripcion,
                IdEspecialidad = plan.IdEspecialidad
            });
        }


        public PlanDTO Update(PlanDTO planDTO)
        {
            Plan existingPlan = _planRepository.GetById(planDTO.Id);
            if (existingPlan == null)
            {
                throw new Exception("No existe un plan con el ID especificado");
            }else if (existingPlan.Descripcion.Equals(planDTO.Descripcion, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception($"Ya existe un plan con la descripcion '{planDTO.Descripcion}'.");
            }


            existingPlan.SetDescripcion(planDTO.Descripcion);
            existingPlan.SetIdEspecialidad(planDTO.IdEspecialidad);
            _planRepository.Update(existingPlan);
            return new PlanDTO
            {
                Id = existingPlan.Id,
                Descripcion = existingPlan.Descripcion,
                IdEspecialidad = existingPlan.IdEspecialidad
            };
        }

        public bool Delete(int id)
        {
            Plan plan = _planRepository.GetById(id);
            if (plan == null)
            {
                throw new Exception("No existe un plan con el ID especificado");

                return false;
            }
            _planRepository.Delete(plan);


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
