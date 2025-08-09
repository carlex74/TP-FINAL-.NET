using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IPlanRepository
    {
        void add(Plan plan);
        void update(Plan plan);
        void delete(Plan plan);
        Plan getById(int id);
        IEnumerable<Plan> getAll();

    }
}
