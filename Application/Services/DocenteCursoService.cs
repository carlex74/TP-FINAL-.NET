using ApplicationClean.DTOs;
using ApplicationClean.Interfaces.Repositories;
using ApplicationClean.Interfaces.Services;
using Domain.Entities;

namespace ApplicationClean.Services
{
    public class DocenteCursoService: IDocenteCursoService
    {
        private readonly IDocenteCursoRepository _repository;
        private readonly ICursoRepository _cursoRepository;

        public DocenteCursoService(IDocenteCursoRepository repository, ICursoRepository cursoRepository)
        {
            _repository = repository;
            _cursoRepository = cursoRepository;
        }


        public async Task<DocenteCursoDTO> AddAsync(DocenteCursoDTO docenteCurso)
        {
            var curso = await _cursoRepository.GetByIdAsync(docenteCurso.IdCurso);
            var newDocenteCurso = new DocenteCurso(curso.Id, docenteCurso.LegajoDocente, docenteCurso.Cargo);

            await _repository.AddAsync(newDocenteCurso);

            return docenteCurso;
        }

        public async Task<DocenteCursoDTO> UpdateAsync(DocenteCursoDTO docenteCursoDTO)
        {
            var existingDocenteCurso = await _repository.GetByIdAsync(docenteCursoDTO.IdCurso, docenteCursoDTO.LegajoDocente);
            if (existingDocenteCurso == null)
            {
                throw new KeyNotFoundException($"No se encontró una doncenteCurso para ese curso");
            }

            existingDocenteCurso.SetCargo(docenteCursoDTO.Cargo);
      

            await _repository.UpdateAsync(existingDocenteCurso);
            return docenteCursoDTO;
        }

        public async Task<DocenteCursoDTO> GetByIdAsync(int idCurso, string legajo)
        {
            var docenteCurso = await _repository.GetByIdAsync(idCurso,legajo);
            if (docenteCurso == null) return null;

            return new DocenteCursoDTO
            {
                IdCurso = idCurso,
                LegajoDocente = legajo,
                Cargo = docenteCurso.Cargo
            };
        }

        public async Task<IEnumerable<DocenteCursoDTO>> GetAllAsync()
        {
            var doncenteCurso = await _repository.GetAllAsync();
            return doncenteCurso.Select(m => new DocenteCursoDTO
            {
                IdCurso = m.IdCurso,
                LegajoDocente = m.LegajoDocente,
                Cargo = m.Cargo
            });
        }

    }
}
