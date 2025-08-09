using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using Data;
using Domain.Interfaces;

namespace Application.Services
{
    public class EspecialidadService: IEspecialidadService
    {
        private IEspecialidadRepository _repository;

        public EspecialidadService(IEspecialidadRepository repository)
        {
            _repository = repository;
        }


        public EspecialidadDTO Add(EspecialidadDTO especialidadDTO)
        {
            if (_repository.GetById(especialidadDTO.Id) != null)
            {
                throw new Exception("Ya existe una especialidad con el mismo ID");
            }
            int id = GetNextId();
            Domain.Entities.Especialidad especialidad = new Domain.Entities.Especialidad(id, especialidadDTO.Descripcion);
            _repository.Add(especialidad);
            especialidadDTO.Id = especialidad.Id;
            especialidadDTO.Descripcion = especialidad.Descripcion;
            return especialidadDTO;
        }

        public EspecialidadDTO Update(EspecialidadDTO especialidadDTO)
        {
            var existingEspecialidad = _repository.GetById(especialidadDTO.Id);
            if (existingEspecialidad == null)
            {
                throw new Exception("No existe una especialidad con el ID proporcionado");
            }
            existingEspecialidad.SetDescripcion(especialidadDTO.Descripcion);
            _repository.Update(existingEspecialidad);
            return especialidadDTO;
        }

        public bool Delete(int id)
        {
            var existingEspecialidad = _repository.GetById(id);
            if (existingEspecialidad == null)
            {
                throw new Exception("No existe una especialidad con el ID proporcionado");
            }
            _repository.Delete(existingEspecialidad);
            return true;
        }


        public EspecialidadDTO GetById(int id)
        {
            var especialidad = _repository.GetById(id);
            if (especialidad == null)
            {
                throw new Exception("No existe una especialidad con el ID proporcionado");
            }
            return new EspecialidadDTO
            {
                Id = especialidad.Id,
                Descripcion = especialidad.Descripcion
            };
        }

        public IEnumerable<EspecialidadDTO> GetAll()
        {
            return _repository.GetAll().Select(e => new EspecialidadDTO
            {
                Id = e.Id,
                Descripcion = e.Descripcion
            });
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
