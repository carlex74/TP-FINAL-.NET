using ApplicationClean.DTOs;
using ApplicationClean.Interfaces.Repositories;
using ApplicationClean.Interfaces.Services;
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

        public MateriaService(IMateriaRepository materiaRepository, IPlanRepository planRepository)
        {
            _materiaRepository = materiaRepository;
            _planRepository = planRepository;
        }

        public async Task<MateriaDTO> AddAsync(MateriaDTO materiaDto)
        {
            var materia = new Materia(0, materiaDto.Nombre, materiaDto.Descripcion, materiaDto.HsSemanales, materiaDto.HsTotales);

            await _materiaRepository.AddAsync(materia);

            return MapToMateriaDTO(materia);
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
            return MapToMateriaDTO(materia);
        }

        public async Task<IEnumerable<MateriaDTO>> GetAllAsync()
        {
            var materias = await _materiaRepository.GetAllAsync();
            return materias.Select(MapToMateriaDTO);
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

        private MateriaDTO MapToMateriaDTO(Materia materia)
        {
            if (materia == null) return null;
            return new MateriaDTO
            {
                Id = materia.Id,
                Nombre = materia.Nombre,
                Descripcion = materia.Descripcion,
                HsSemanales = materia.HsSemanales,
                HsTotales = materia.HsTotales,
                Planes = materia.Planes?.Select(p => new PlanDTO
                {
                    Id = p.Id,
                    Descripcion = p.Descripcion,
                    IdEspecialidad = p.IdEspecialidad,
                    EspecialidadDescripcion = p.Especialidad?.Descripcion ?? "N/A"
                }).ToList() ?? new List<PlanDTO>()
            };
        }
    }
}