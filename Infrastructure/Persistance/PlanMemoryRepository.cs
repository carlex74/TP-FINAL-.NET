using Data;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Persistance
{
    public class PlanMemoryRepository:IPlanRepository
    {
        public void Add(Plan plan)
        {
            PlanMemory.Planes.Add(plan);
        }

        public void Update(Plan plan)
        {
         
            PlanMemory.Planes.Remove(plan);
            PlanMemory.Planes.Add(plan);
        }

        public void Delete(Plan plan)
        {
            PlanMemory.Planes.Remove(plan);
        }

        public Plan GetById(int id)
        {
            return PlanMemory.Planes.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Plan> GetAll()
        {
            return PlanMemory.Planes;
        }

    }
}
