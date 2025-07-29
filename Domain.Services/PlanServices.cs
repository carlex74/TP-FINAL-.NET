using Domain.Model;
using Data;

namespace Domain.Services
{
    public class PlanServices
    {
        public void Add(Plan plan)
        {

            plan.SetId(GetNextId());

            PlanMemory.Planes.Add(plan);

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

        public Plan Get(int id)
        {
            return PlanMemory.Planes.Find(x => x.Id == id);
        }

        public IEnumerable<Plan> GetAll()
        {
            return PlanMemory.Planes.ToList();
        }

        public bool Update(Plan plan)
        {
            Plan? planToUpdate = PlanMemory.Planes.Find(p => p.Id == plan.Id);
            if (planToUpdate != null)
            {
                planToUpdate.SetDescripcion(plan.Descripcion);
                planToUpdate.SetIdEspecialidad(plan.IdEspecialidad);
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
