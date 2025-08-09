using Data;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Persistance
{
    public class PlanMemoryRepository:IPlanRepository
    {
        public void add(Plan plan)
        {
            PlanMemory.Planes.Add(plan);
        }

        public void update(Plan plan)
        {
         
            PlanMemory.Planes.Remove(plan);
            PlanMemory.Planes.Add(plan);
        }

        public void delete(Plan plan)
        {
            PlanMemory.Planes.Remove(plan);
        }

        public Plan getById(int id)
        {
            return PlanMemory.Planes.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Plan> getAll()
        {
            return PlanMemory.Planes;
        }

    }
}
