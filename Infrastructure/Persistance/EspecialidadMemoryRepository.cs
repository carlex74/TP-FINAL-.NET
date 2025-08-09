using Data;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Persistance
{
    public class EspecialidadMemoryRepository : IEspecialidadRepository
    {
        public void Add(Especialidad especialidad)
        {
            EspecialidadMemory.Especialidades.Add(especialidad);
        }

        public void Update(Especialidad especialidad)
        {

            EspecialidadMemory.Especialidades.Remove(especialidad);
            EspecialidadMemory.Especialidades.Add(especialidad);
        }

        public void Delete(Especialidad especialidad)
        {
            EspecialidadMemory.Especialidades.Remove(especialidad);
        }

        public Especialidad GetById(int id)
        {
            return EspecialidadMemory.Especialidades.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Especialidad> GetAll()
        {
            return EspecialidadMemory.Especialidades;
        }

    }
}
