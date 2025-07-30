using Data;
using Domain.Model;
using DTOs;

namespace Domain.Services
{
    public class PlanServices
    {
        public PlanDTO Add(PlanDTO dto)
        {

            if (PlanMemory.Planes.Any(p => p.Descripcion.Equals(dto.Descripcion, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException($"Ya existe un plan con la descripcion '{dto.Descripcion}'.");
            }
            var id = GetNextId();

            Plan plan = new Plan(id, dto.Descripcion, dto.IdEspecialidad);

            PlanMemory.Planes.Add(plan);

            dto.Id = plan.Id;
            dto.Descripcion = plan.Descripcion;
            dto.IdEspecialidad = plan.IdEspecialidad;

            return dto;
        }

        public bool Delete(int id)
        {
            Plan? planToDelete = PlanMemory.Planes.Find(p => p.Id == id);
            if (planToDelete != null)
            {
                PlanMemory.Planes.Remove(planToDelete);
                return true;
            }
            else
            {
                return false;
            }
        }

        public PlanDTO Get(int id)
        {
            Plan? plan = PlanMemory.Planes.Find(p => p.Id == id);

            if (plan == null)
                return null;

            return new PlanDTO
            {
                Id = plan.Id,
                Descripcion = plan.Descripcion,
                IdEspecialidad = plan.IdEspecialidad
            };
        }

        public IEnumerable<PlanDTO> GetAll()
        {
            return PlanMemory.Planes.Select(plan => new PlanDTO
            {
                Id = plan.Id,
                Descripcion = plan.Descripcion,
                IdEspecialidad = plan.IdEspecialidad
            }).ToList();
        }

        public bool Update(PlanDTO dto)
        {
            Plan? planToUpdate = PlanMemory.Planes.Find(p => p.Id == dto.Id);

            if (planToUpdate != null)
            {
                if (PlanMemory.Planes.Any(p => p.Id != dto.Id && p.Descripcion.Equals(dto.Descripcion, StringComparison.OrdinalIgnoreCase)))
                {
                    throw new ArgumentException($"Ya existe otro plan con la Descripcion '{dto.Descripcion}'.");
                }
                planToUpdate.SetDescripcion(dto.Descripcion);

                return true;
            }
            else
            {
                return false;
            }
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

