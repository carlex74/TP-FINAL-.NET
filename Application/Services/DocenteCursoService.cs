using ApplicationClean.DTOs;
using ApplicationClean.Interfaces.Repositories;
using ApplicationClean.Interfaces.Services;
using AutoMapper;
using Domain.Entities;

namespace ApplicationClean.Services
{
    public class DocenteCursoService : IDocenteCursoService
    {
        private readonly IDocenteCursoRepository _repository;
        private readonly ICursoRepository _cursoRepository;
        private readonly IUsuarioRepository _usuarioRepository; 
        private readonly IMapper _mapper; 

        public DocenteCursoService(
            IDocenteCursoRepository repository,
            ICursoRepository cursoRepository,
            IUsuarioRepository usuarioRepository,
            IMapper mapper)
        {
            _repository = repository;
            _cursoRepository = cursoRepository;
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }


        public async Task<DocenteCursoDTO> AddAsync(DocenteCursoDTO docenteCursoDto)
        {
            var curso = await _cursoRepository.GetByIdAsync(docenteCursoDto.IdCurso);
            if (curso == null)
                throw new KeyNotFoundException($"El curso con ID {docenteCursoDto.IdCurso} no existe.");

            var docente = await _usuarioRepository.GetByLegajoAsync(docenteCursoDto.LegajoDocente);
            if (docente == null)
                throw new KeyNotFoundException($"El docente con legajo {docenteCursoDto.LegajoDocente} no existe.");

            var asignacionExistente = await _repository.GetByIdAsync(docenteCursoDto.IdCurso, docenteCursoDto.LegajoDocente);
            if (asignacionExistente != null)
                throw new BusinessRuleException("El docente ya se encuentra asignado a este curso.");

            var nuevaAsignacion = _mapper.Map<DocenteCurso>(docenteCursoDto);

            await _repository.AddAsync(nuevaAsignacion);

            return _mapper.Map<DocenteCursoDTO>(nuevaAsignacion);
        }

        public async Task<DocenteCursoDTO> UpdateAsync(DocenteCursoDTO docenteCursoDto)
        {
            var existingAsignacion = await _repository.GetByIdAsync(docenteCursoDto.IdCurso, docenteCursoDto.LegajoDocente);
            if (existingAsignacion == null)
            {
                throw new KeyNotFoundException($"No se encontró una asignación para el docente {docenteCursoDto.LegajoDocente} en el curso {docenteCursoDto.IdCurso}.");
            }

            existingAsignacion.SetCargo(docenteCursoDto.Cargo);

            await _repository.UpdateAsync(existingAsignacion);

            return docenteCursoDto;
        }

        public async Task<DocenteCursoDTO> GetByIdAsync(int idCurso, string legajo)
        {
            var asignacion = await _repository.GetByIdAsync(idCurso, legajo);
            if (asignacion == null) return null;

        
            return _mapper.Map<DocenteCursoDTO>(asignacion);
        }

        public async Task<IEnumerable<DocenteCursoDTO>> GetAllAsync()
        {
            var asignaciones = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<DocenteCursoDTO>>(asignaciones);
        }

 
        public async Task DeleteAsync(int idCurso, string legajoDocente)
        {
            var asignacion = await _repository.GetByIdAsync(idCurso, legajoDocente);
            if (asignacion == null)
            {
                throw new KeyNotFoundException($"No se encontró la asignación a eliminar.");
            }
            await _repository.DeleteAsync(asignacion);
        }

    }
}
