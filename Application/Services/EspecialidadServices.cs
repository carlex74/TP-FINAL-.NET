using ApplicationClean.DTOs;
using ApplicationClean.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationClean.Services
{
    public class EspecialidadServices : IEspecialidadService
    {
        private readonly IEspecialidadRepository _repository;

        public EspecialidadServices(IEspecialidadRepository repository)
        {
            _repository = repository;
        }

        public async Task<EspecialidadDTO> AddAsync(EspecialidadDTO especialidadDTO)
        {
            var especialidad = new Especialidad(0, especialidadDTO.Descripcion);

            await _repository.AddAsync(especialidad);

            especialidadDTO.Id = especialidad.Id;
            return especialidadDTO;
        }

        public async Task<EspecialidadDTO> UpdateAsync(EspecialidadDTO especialidadDTO)
        {
            var existingEspecialidad = await _repository.GetByIdAsync(especialidadDTO.Id);

            if (existingEspecialidad == null)
            {
                throw new KeyNotFoundException($"No se encontró una especialidad con el ID {especialidadDTO.Id}.");
            }

            existingEspecialidad.SetDescripcion(especialidadDTO.Descripcion);
            await _repository.UpdateAsync(existingEspecialidad);

            return especialidadDTO;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existingEspecialidad = await _repository.GetByIdAsync(id);
            if (existingEspecialidad == null)
            {
                return false;
            }

            await _repository.DeleteAsync(existingEspecialidad);
            return true;
        }

        public async Task<EspecialidadDTO> GetByIdAsync(int id)
        {
            var especialidad = await _repository.GetByIdAsync(id);

            if (especialidad == null) return null;

            return new EspecialidadDTO
            {
                Id = especialidad.Id,
                Descripcion = especialidad.Descripcion
            };
        }

        public async Task<IEnumerable<EspecialidadDTO>> GetAllAsync()
        {
            var especialidades = await _repository.GetAllAsync();

            return especialidades.Select(e => new EspecialidadDTO
            {
                Id = e.Id,
                Descripcion = e.Descripcion
            });
        }
    }
}