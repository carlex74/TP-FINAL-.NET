using ApplicationClean.DTOs;
using ApplicationClean.Interfaces.Repositories;
using ApplicationClean.Interfaces.Services;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationClean.Services
{
    public class ComisionService : IComisionService
    {
        private readonly IComisionRepository _comisionRepository;
        private readonly IPlanRepository _planRepository;

        public ComisionService(IComisionRepository comisionRepository, IPlanRepository planRepository)
        {
            _comisionRepository = comisionRepository;
            _planRepository = planRepository;
        }

        public async Task<ComisionDTO> AddAsync(ComisionDTO comisionDto)
        {
            var comision = new Comision(0, comisionDto.AnioEspecialidad, comisionDto.Descripcion);
            await _comisionRepository.AddAsync(comision);

            var comisionCreada = await _comisionRepository.GetByIdAsync(comision.Nro);
            return MapToComisionDTO(comisionCreada);
        }

        public async Task<ComisionDTO> UpdateAsync(ComisionDTO comisionDto)
        {
            var comisionExistente = await _comisionRepository.GetByIdAsync(comisionDto.Nro);
            if (comisionExistente == null)
            {
                throw new KeyNotFoundException($"No se encontró una Comisión con el ID {comisionDto.Nro}.");
            }

            comisionExistente.SetAnioEspecialidad(comisionDto.AnioEspecialidad);
            comisionExistente.SetDescripcion(comisionDto.Descripcion);
            await _comisionRepository.UpdateAsync(comisionExistente);

            var comisionActualizada = await _comisionRepository.GetByIdAsync(comisionDto.Nro);
            return MapToComisionDTO(comisionActualizada);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var comision = await _comisionRepository.GetByIdAsync(id);
            if (comision == null) return false;
            await _comisionRepository.DeleteAsync(comision);
            return true;
        }

        public async Task<ComisionDTO> GetByIdAsync(int id)
        {
            var comision = await _comisionRepository.GetByIdAsync(id);
            return MapToComisionDTO(comision);
        }

        public async Task<IEnumerable<ComisionDTO>> GetAllAsync()
        {
            var comisiones = await _comisionRepository.GetAllAsync();
            return comisiones.Select(MapToComisionDTO);
        }

        public async Task AssignPlanesAsync(int comisionId, List<int> planIds)
        {
            var comision = await _comisionRepository.GetByIdWithPlanesAsync(comisionId);
            if (comision == null)
            {
                throw new KeyNotFoundException($"No se encontró la comisión con el ID {comisionId}.");
            }

            var planesAAsignar = new List<Plan>();
            if (planIds != null && planIds.Any())
            {
                var todosLosPlanes = await _planRepository.GetAllAsync();
                planesAAsignar = todosLosPlanes.Where(p => planIds.Contains(p.Id)).ToList();
            }

            comision.Planes.Clear();
            foreach (var plan in planesAAsignar)
            {
                comision.Planes.Add(plan);
            }

            await _comisionRepository.UpdateAsync(comision);
        }

        private ComisionDTO MapToComisionDTO(Comision comision)
        {
            if (comision == null) return null;
            return new ComisionDTO
            {
                Nro = comision.Nro,
                AnioEspecialidad = comision.AnioEspecialidad,
                Descripcion = comision.Descripcion,
                Planes = comision.Planes?.Select(p => new PlanDTO
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