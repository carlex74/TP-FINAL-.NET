
using ApplicationClean.DTOs;
using ApplicationClean.Interfaces.Repositories;
using ApplicationClean.Interfaces.Services;
using Domain.Entities;

namespace ApplicationClean.Services
{
    public class AlumnoInscripcionService: IAlumnoInscripcionService
    {

        private readonly IAlumnoInscripcionRepository _repository;
        private readonly ICursoRepository _cursoRepository;

        public AlumnoInscripcionService(IAlumnoInscripcionRepository repository, ICursoRepository cursoRepository)
        {
            _repository = repository;
            _cursoRepository = cursoRepository;
        }

        public async Task<AlumnoInscripcionDTO> AddAsync(AlumnoInscripcionDTO inscripcion)
        {
            var curso = await _cursoRepository.GetByIdAsync(inscripcion.IdCurso);
            var newInscripcion = new AlumnoInscripcion(inscripcion.Condicion, inscripcion.LegajoAlumno, curso.Id, inscripcion.Nota);

            await _repository.AddAsync(newInscripcion);

            return inscripcion;
        }

        public async Task<AlumnoInscripcionDTO> UpdateAsync(AlumnoInscripcionDTO inscripcionDto)
        {
            var existingInscripcion = await _repository.GetByIdAsync(inscripcionDto.LegajoAlumno,inscripcionDto.IdCurso);
            if (existingInscripcion == null)
            {
                throw new KeyNotFoundException($"No se encontró una inscripcion para ese curso");
            }

            existingInscripcion.SetCondicion(inscripcionDto.Condicion);
            existingInscripcion.SetNota(inscripcionDto.Nota);

            await _repository.UpdateAsync(existingInscripcion);
            return inscripcionDto;
        }

        public async Task<AlumnoInscripcionDTO> GetByIdAsync(string legajo, int idCurso)
        {
            var inscripcion = await _repository.GetByIdAsync(legajo,idCurso);
            if (inscripcion == null) return null;

            return new AlumnoInscripcionDTO
            {
                LegajoAlumno = inscripcion.LegajoAlumno,
                IdCurso = inscripcion.IdCurso,
                Condicion = inscripcion.Condicion,
                Nota = inscripcion.Nota
            };
        }

        public async Task<IEnumerable<AlumnoInscripcionDTO>> GetAllAsync()
        {
            var inscripcion = await _repository.GetAllAsync();
            return inscripcion.Select(m => new AlumnoInscripcionDTO
            {
                LegajoAlumno = m.LegajoAlumno,
                IdCurso = m.IdCurso,
                Condicion = m.Condicion,
                Nota = m.Nota
            });
        }

    }
}
