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

            if (await _repository.DescripcionExistsAsync(especialidadDTO.Descripcion))
            {
                throw new BusinessRuleException($"Ya existe una especialidad con la descripción '{especialidadDTO.Descripcion}'.");
            }

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

            if (await _repository.DescripcionExistsAsync(especialidadDTO.Descripcion, especialidadDTO.Id))
            {
                throw new BusinessRuleException($"La descripción '{especialidadDTO.Descripcion}' ya pertenece a otra especialidad.");
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
                throw new KeyNotFoundException($"No se encontró una especialidad con el ID {id} para eliminar.");
            }

            existingEspecialidad.SoftDelete();
            await _repository.UpdateAsync(existingEspecialidad);
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