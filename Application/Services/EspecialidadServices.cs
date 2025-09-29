using ApplicationClean.DTOs;
using ApplicationClean.Interfaces.Repositories;
using ApplicationClean.Interfaces.Services;
using Domain.Entities;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationClean.Services
{
    public class EspecialidadServices : IEspecialidadService
    {
        private readonly IEspecialidadRepository _repository;
        private readonly IMapper _mapper;

        public EspecialidadServices(IEspecialidadRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<EspecialidadDTO> AddAsync(EspecialidadDTO especialidadDTO)
        {
            var nuevaEspecialidad = _mapper.Map<Especialidad>(especialidadDTO);

            await _repository.AddAsync(nuevaEspecialidad);

            return _mapper.Map<EspecialidadDTO>(nuevaEspecialidad);
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

            return _mapper.Map<EspecialidadDTO>(especialidad);
        }

        public async Task<IEnumerable<EspecialidadDTO>> GetAllAsync()
        {
            var especialidades = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<EspecialidadDTO>>(especialidades);
        }
    }
}