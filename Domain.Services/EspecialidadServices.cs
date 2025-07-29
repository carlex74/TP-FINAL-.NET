using Data;
using Domain.Model;

namespace Domain.Services
{
    public class EspecialidadServices
    {

        public void Add(Especialidad especialidad)
        {

            especialidad.SetId(GetNextId());
            
            EspecialidadMemory.Especialidades.Add(especialidad);
        }


        public bool Delete(int id)
        {
            Especialidad? especialidadToDelete = EspecialidadMemory.Especialidades.Find(e => e.Id == id);
            if (especialidadToDelete != null)
            {
                EspecialidadMemory.Especialidades.Remove(especialidadToDelete);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Especialidad Get(int id)
        {
            return EspecialidadMemory.Especialidades.Find(e => e.Id == id);
        }

        public IEnumerable<Especialidad> GetAll()
        {
            return EspecialidadMemory.Especialidades.ToList();
        }

        public bool Update(Especialidad especialidad)
        {
            Especialidad? especialidadToUpdate = EspecialidadMemory.Especialidades.Find(e => e.Id == especialidad.Id);

            if (especialidadToUpdate != null)
            {
               especialidadToUpdate.SetDescripcion(especialidad.Descripcion);
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

            if (EspecialidadMemory.Especialidades.Count > 0)
            {
                nextId = EspecialidadMemory.Especialidades.Max(x => x.Id) + 1;
            }
            else
            {
                nextId = 1;
            }

            return nextId;
        }
    }
}
