
using ApplicationClean.DTOs;
using ApplicationClean.Interfaces.Repositories;
using ApplicationClean.Interfaces.Services;
using AutoMapper;
using Domain.Entities;

namespace ApplicationClean.Services
{
    public class AlumnoInscripcionService: IAlumnoInscripcionService
    {

        private readonly IAlumnoInscripcionRepository _repository;
        private readonly ICursoRepository _cursoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper; // <-- NUEVA DEPENDENCIA para AutoMapper

        public AlumnoInscripcionService(IAlumnoInscripcionRepository repository, ICursoRepository cursoRepository,IMapper mapper, IUsuarioRepository usuarioRepository)
        {
            _repository = repository;
            _cursoRepository = cursoRepository;
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<AlumnoInscripcionDTO> AddAsync(AlumnoInscripcionDTO inscripcionDto)
        {
            // --- 1. VALIDACIÓN ROBUSTA (REGLAS DE NEGOCIO) ---
            var curso = await _cursoRepository.GetByIdAsync(inscripcionDto.IdCurso);
            if (curso == null)
                throw new KeyNotFoundException($"El curso con ID {inscripcionDto.IdCurso} no existe.");

            var alumno = await _usuarioRepository.GetByLegajoAsync(inscripcionDto.LegajoAlumno);
            if (alumno == null)
                throw new KeyNotFoundException($"El alumno con legajo {inscripcionDto.LegajoAlumno} no existe.");

            var inscripcionExistente = await _repository.GetByIdAsync(inscripcionDto.LegajoAlumno, inscripcionDto.IdCurso);
            if (inscripcionExistente != null)
                throw new BusinessRuleException("El alumno ya se encuentra inscrito en este curso.");

            // Aquí irían más reglas de negocio (cupo, correlativas, etc.)

            // --- 2. CREACIÓN DE LA ENTIDAD Y PERSISTENCIA ---
            // Usamos AutoMapper para crear la entidad a partir del DTO.
            var nuevaInscripcion = _mapper.Map<AlumnoInscripcion>(inscripcionDto);

            await _repository.AddAsync(nuevaInscripcion);

            // --- 3. RETORNO COHERENTE ---
            // Mapeamos la entidad recién creada (que podría tener valores generados) de vuelta a un DTO.
            return _mapper.Map<AlumnoInscripcionDTO>(nuevaInscripcion);
        }

        public async Task UpdateAsync(AlumnoInscripcionDTO inscripcionDto)
        {
            var existingInscripcion = await _repository.GetByIdAsync(inscripcionDto.LegajoAlumno, inscripcionDto.IdCurso);
            if (existingInscripcion == null)
            {
                throw new KeyNotFoundException($"No se encontró una inscripción para el alumno {inscripcionDto.LegajoAlumno} en el curso {inscripcionDto.IdCurso}.");
            }

            // Dejamos que la entidad de dominio maneje su actualización de estado
            existingInscripcion.SetCondicion(inscripcionDto.Condicion);
            existingInscripcion.SetNota(inscripcionDto.Nota);

            await _repository.UpdateAsync(existingInscripcion);
            // No se devuelve nada, el controlador retornará 204 No Content.
        }

        public async Task<AlumnoInscripcionDTO> GetByIdAsync(string legajo, int idCurso)
        {
            var inscripcion = await _repository.GetByIdAsync(legajo, idCurso);
            if (inscripcion == null) return null;

            // --- 4. MAPEO EFICIENTE ---
            return _mapper.Map<AlumnoInscripcionDTO>(inscripcion);
        }

        public async Task<IEnumerable<AlumnoInscripcionDTO>> GetAllAsync()
        {
            var inscripciones = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<AlumnoInscripcionDTO>>(inscripciones);
        }

    }
}
