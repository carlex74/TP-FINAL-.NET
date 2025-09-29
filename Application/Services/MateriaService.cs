using ApplicationClean.DTOs;
using ApplicationClean.Interfaces.Repositories;
using ApplicationClean.Interfaces.Services;
using AutoMapper;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationClean.Services
{
    public class MateriaService : IMateriaService
    {
        private readonly IMateriaRepository _materiaRepository;
        private readonly IPlanRepository _planRepository;
        private readonly IMapper _mapper;

        public MateriaService(IMateriaRepository materiaRepository, IPlanRepository planRepository, IMapper mapper)
        {
            _materiaRepository = materiaRepository;
            _planRepository = planRepository;
            _mapper = mapper;
        }

        public async Task<MateriaDTO> AddAsync(MateriaDTO materiaDto)
        {
            var nuevaMateria = _mapper.Map<Materia>(materiaDto);

            await _materiaRepository.AddAsync(nuevaMateria);

            return _mapper.Map<MateriaDTO>(nuevaMateria);
        }

        public async Task<MateriaDTO> UpdateAsync(MateriaDTO materiaDto)
        {
            var existingMateria = await _materiaRepository.GetByIdAsync(materiaDto.Id);
            if (existingMateria == null)
            {
                throw new KeyNotFoundException($"No se encontró una materia con el ID {materiaDto.Id}.");
            }

            existingMateria.SetNombre(materiaDto.Nombre);
            existingMateria.SetDescripcion(materiaDto.Descripcion);
            existingMateria.SetHsSemanales(materiaDto.HsSemanales);
            existingMateria.SetHsTotales(materiaDto.HsTotales);

            await _materiaRepository.UpdateAsync(existingMateria);
            return materiaDto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var materia = await _materiaRepository.GetByIdAsync(id);
            if (materia == null)
            {
                return false;
            }
            await _materiaRepository.DeleteAsync(materia);
            return true;
        }

        public async Task<MateriaDTO> GetByIdAsync(int id)
        {
            var materia = await _materiaRepository.GetByIdWithPlanesAsync(id);
            if (materia == null) return null;

            return _mapper.Map<MateriaDTO>(materia);
        }

        public async Task<IEnumerable<MateriaDTO>> GetAllAsync()
        {
            var materias = await _materiaRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<MateriaDTO>>(materias);
        }

        public async Task AssignPlanesAsync(int materiaId, List<int> planIds)
        {
            var materia = await _materiaRepository.GetByIdWithPlanesAsync(materiaId);
            if (materia == null)
            {
                throw new KeyNotFoundException($"No se encontró la materia con el ID {materiaId}.");
            }

            var todosLosPlanes = await _planRepository.GetAllAsync();
            var planesAAsignar = todosLosPlanes.Where(p => planIds.Contains(p.Id)).ToList();

            materia.Planes.Clear();
            foreach (var plan in planesAAsignar)
            {
                materia.Planes.Add(plan);
            }

            await _materiaRepository.UpdateAsync(materia);
        }
    }
}