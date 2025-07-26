using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Domain.Model;
using Domain.Utils;

namespace Domain.Services
{
    public class EspecialidadServices
    {

        public void Add(Especialidad especialidad)
        {
            especialidad.SetId(IdGenerator.GetNextId(EspecialidadMemory.Especialidades));
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

        public List<Especialidad> GetAll()
        {
            return EspecialidadMemory.Especialidades;
        }

        public Especialidad? GetById(int id)
        {
            return EspecialidadMemory.Especialidades.Find(e => e.Id == id);
        }

        public bool Update(Especialidad especialidad)
        {
            Especialidad? existingEspecialidad = EspecialidadMemory.Especialidades.Find(e => e.Id == especialidad.Id);
            if (existingEspecialidad != null)
            {
                existingEspecialidad.SetDescripcion(especialidad.Descripcion);
                return true;
            }
            else
            {
                return false;
            }
        }   

    }
}
