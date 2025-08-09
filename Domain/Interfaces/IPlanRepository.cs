using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IPlanRepository
    {
        void Add(Plan plan);
        void Update(Plan plan);
        void Delete(Plan plan);
        Plan GetById(int id);
        IEnumerable<Plan> GetAll();

    }
}
