using Domain.Model;
using Data;
using Domain.Utils;


namespace Domain.Services
{
    public class PlanServices
    {
        public void Add(Plan plan)
        {

            plan.SetId(IdGenerator.GetNextId(PlanMemory.Planes));

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

        public Plan? GetById(int id)
        {
            return PlanMemory.Planes.Find(p => p.Id == id);
        }

        public List<Plan> GetAll()
        {
            return PlanMemory.Planes;
        }

        public bool Update(Plan plan)
        {
            Plan? existingPlan = PlanMemory.Planes.Find(p => p.Id == plan.Id);
            if (existingPlan != null)
            {
                existingPlan.SetDescripcion(plan.Descripcion);
                existingPlan.SetIdEspecialidad(plan.IdEspecialidad);
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
