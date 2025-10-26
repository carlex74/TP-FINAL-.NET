using ApplicationClean.DTOs;
using ApplicationClean.Interfaces.Repositories;
using ApplicationClean.Interfaces.Services;
using AutoMapper;
using Domain.Entities;

namespace ApplicationClean.Services
{
    public class AlumnoInscripcionService : IAlumnoInscripcionService
    {

        private readonly IAlumnoInscripcionRepository _repository;
        private readonly ICursoRepository _cursoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public AlumnoInscripcionService(IAlumnoInscripcionRepository repository, ICursoRepository cursoRepository, IMapper mapper, IUsuarioRepository usuarioRepository)
        {
            _repository = repository;
            _cursoRepository = cursoRepository;
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<AlumnoInscripcionDTO> AddAsync(AlumnoInscripcionDTO inscripcionDto)
        {
            if (!await _cursoRepository.ExistsAsync(inscripcionDto.IdCurso))
                throw new BusinessRuleException($"El curso con ID {inscripcionDto.IdCurso} no es válido o no existe.");

            var alumno = await _usuarioRepository.GetByLegajoAsync(inscripcionDto.LegajoAlumno);
            if (alumno == null || !(alumno is Alumno))
                throw new BusinessRuleException($"El legajo {inscripcionDto.LegajoAlumno} no corresponde a un alumno válido.");

            var inscripcionExistente = await _repository.GetHistoricalByIdAsync(inscripcionDto.LegajoAlumno, inscripcionDto.IdCurso);

            if (inscripcionExistente != null)
            {

                if (!inscripcionExistente.IsDeleted)
                {

                    throw new BusinessRuleException("El alumno ya se encuentra inscrito en este curso.");
                }
                else
                {

                    inscripcionExistente.Restore();
                    await _repository.UpdateAsync(inscripcionExistente);


                    return _mapper.Map<AlumnoInscripcionDTO>(inscripcionExistente);
                }
            }
            else
            {
                var nuevaInscripcion = _mapper.Map<AlumnoInscripcion>(inscripcionDto);
                await _repository.AddAsync(nuevaInscripcion);

                return _mapper.Map<AlumnoInscripcionDTO>(nuevaInscripcion);
            }
        }

        public async Task<AlumnoInscripcionDTO> UpdateAsync(AlumnoInscripcionDTO inscripcionDto)
        {
            var existingInscripcion = await _repository.GetByIdAsync(inscripcionDto.LegajoAlumno, inscripcionDto.IdCurso);
            if (existingInscripcion == null)
            {
                throw new KeyNotFoundException($"No se encontró una inscripción para el alumno {inscripcionDto.LegajoAlumno} en el curso {inscripcionDto.IdCurso}.");
            }

            existingInscripcion.SetCondicion(inscripcionDto.Condicion);
            existingInscripcion.SetNota(inscripcionDto.Nota);

            await _repository.UpdateAsync(existingInscripcion);

            return inscripcionDto;
        }

        public async Task<AlumnoInscripcionDTO> GetByIdAsync(string legajo, int idCurso)
        {
            var inscripcion = await _repository.GetWithDetailsByIdAsync(legajo, idCurso);
            if (inscripcion == null) return null;

            return _mapper.Map<AlumnoInscripcionDTO>(inscripcion);
        }

        public async Task<IEnumerable<AlumnoInscripcionDTO>> GetAllAsync()
        {
            var inscripciones = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<AlumnoInscripcionDTO>>(inscripciones);
        }

        public async Task<bool> DeleteAsync(string legajo, int idCurso)
        {
            var inscripcion = await _repository.GetByIdAsync(legajo, idCurso);
            if (inscripcion == null)
            {
                throw new KeyNotFoundException($"No se encontró la inscripción a eliminar.");
            }

            inscripcion.SoftDelete();
            await _repository.UpdateAsync(inscripcion);
            return true;
        }

        public async Task<IEnumerable<AlumnoInscripcionDTO>> GetInscripcionesPorCursoAsync(int idCurso)
        {
            var inscripciones = await _repository.GetInscripcionesPorCursoAsync(idCurso);
            return _mapper.Map<IEnumerable<AlumnoInscripcionDTO>>(inscripciones);
        }
    }
}
