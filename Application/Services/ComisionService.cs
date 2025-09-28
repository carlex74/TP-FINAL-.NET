using ApplicationClean.DTOs;
using ApplicationClean.Interfaces.Repositories;
using ApplicationClean.Interfaces.Services;
using AutoMapper;
using Domain.Entities;


namespace ApplicationClean.Services
{
    public class ComisionService : IComisionService
    {
        private readonly IComisionRepository _comisionRepository;
        private readonly IPlanRepository _planRepository;
        private readonly IMapper _mapper;

        public ComisionService(
            IComisionRepository comisionRepository,
            IPlanRepository planRepository,
            IMapper mapper)
        {
            _comisionRepository = comisionRepository;
            _planRepository = planRepository;
            _mapper = mapper;
        }

        public async Task<ComisionDTO> AddAsync(ComisionDTO comisionDto)
        {
            var comision = _mapper.Map<Comision>(comisionDto);
            await _comisionRepository.AddAsync(comision);

            return _mapper.Map<ComisionDTO>(comision);
        }

        public async Task<ComisionDTO> UpdateAsync(ComisionDTO comisionDto)
        {
            var comisionExistente = await _comisionRepository.GetByIdAsync(comisionDto.Nro);
            if (comisionExistente == null)
            {
                throw new KeyNotFoundException($"No se encontró una Comisión con el ID {comisionDto.Nro}.");
            }

            _mapper.Map(comisionDto, comisionExistente);

            await _comisionRepository.UpdateAsync(comisionExistente);
           
            return comisionDto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var comision = await _comisionRepository.GetByIdAsync(id);
            if (comision == null)
            {
                return false;
            }
            await _comisionRepository.DeleteAsync(comision);
            return true;
        }

        public async Task<ComisionDTO> GetByIdAsync(int id)
        {
            var comision = await _comisionRepository.GetByIdAsync(id);
            if (comision == null) return null;

            return _mapper.Map<ComisionDTO>(comision);
        }

        public async Task<IEnumerable<ComisionDTO>> GetAllAsync()
        {
            var comisiones = await _comisionRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ComisionDTO>>(comisiones);
        }

        public async Task AssignPlanesAsync(int comisionId, List<int> planIds)
        {
            var comision = await _comisionRepository.GetByIdWithPlanesAsync(comisionId);
            if (comision == null)
            {
                throw new KeyNotFoundException($"No se encontró la comisión con el ID {comisionId}.");
            }

            var planesAAsignar = await _planRepository.GetByIdsAsync(planIds ?? new List<int>());
            
            comision.Planes.Clear();
            foreach (var plan in planesAAsignar)
            {
                comision.Planes.Add(plan);
            }

            await _comisionRepository.UpdateAsync(comision);
        }
    }
}