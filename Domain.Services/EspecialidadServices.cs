using Data;
using Domain.Model;
using DTOs;

namespace Domain.Services
{
    public class EspecialidadServices
    {

        public EspecialidadDTO Add(EspecialidadDTO dto)
        {

            if (EspecialidadMemory.Especialidades.Any(e => e.Descripcion.Equals(dto.Descripcion, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException($"Ya existe una especialidad con la descripcion '{dto.Descripcion}'.");
            }
            var id = GetNextId();

            Especialidad especialidad = new Especialidad(id, dto.Descripcion);

            EspecialidadMemory.Especialidades.Add(especialidad);

            dto.Id = especialidad.Id;
            dto.Descripcion = especialidad.Descripcion;

            return dto;
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

        public EspecialidadDTO Get(int id)
        {
            Especialidad? especialidad = EspecialidadMemory.Especialidades.Find(e => e.Id == id);

            if (especialidad == null)
                return null;

            return new EspecialidadDTO
            {
                Id = especialidad.Id,
                Descripcion = especialidad.Descripcion
            };
        }

        public IEnumerable<EspecialidadDTO> GetAll()
        {
            return EspecialidadMemory.Especialidades.Select(especialidad => new EspecialidadDTO
            {
                Id = especialidad.Id,
                Descripcion = especialidad.Descripcion
            }).ToList();
        }

        public bool Update(EspecialidadDTO dto)
        {
            Especialidad? especialidadToUpdate = EspecialidadMemory.Especialidades.Find(e => e.Id == dto.Id);

            if (especialidadToUpdate != null)
            {
                if (EspecialidadMemory.Especialidades.Any(e => e.Id != dto.Id && e.Descripcion.Equals(dto.Descripcion, StringComparison.OrdinalIgnoreCase)))
                {
                    throw new ArgumentException($"Ya existe otra especialidad con la Descripcion '{dto.Descripcion}'.");
                }
               especialidadToUpdate.SetDescripcion(dto.Descripcion);

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
