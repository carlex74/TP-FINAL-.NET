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
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _cursoRepository;
        private readonly IMateriaRepository _materiaRepository;
        private readonly IComisionRepository _comisionRepository;
        private readonly IMapper _mapper;

        public CursoService(ICursoRepository cursoRepository, IMateriaRepository materiaRepository, IMapper mapper, IComisionRepository comisionRepository)
        {
            _cursoRepository = cursoRepository;
            _materiaRepository = materiaRepository;
            _mapper = mapper;
            _comisionRepository = comisionRepository;
        }

        public async Task<CursoDTO> AddAsync(CursoDTO cursoDto)
        {
            if (!await _materiaRepository.ExistsAsync(cursoDto.IdMateria))
                throw new BusinessRuleException($"La materia con ID {cursoDto.IdMateria} no es válida o no existe.");
            if (!await _comisionRepository.ExistsAsync(cursoDto.IdComision))
                throw new BusinessRuleException($"La comisión con ID {cursoDto.IdComision} no es válida o no existe.");

            if (await _cursoRepository.CursoExistsAsync(cursoDto.IdMateria, cursoDto.IdComision, cursoDto.AnioCalendario))
            {
                throw new BusinessRuleException("Ya existe un curso para esa materia y comisión en el año especificado.");
            }

            var nuevoCurso = _mapper.Map<Curso>(cursoDto);

            await _cursoRepository.AddAsync(nuevoCurso);

            return _mapper.Map<CursoDTO>(nuevoCurso);
        }

        public async Task<CursoDTO> UpdateAsync(CursoDTO cursoDto)
        {
            var existingCurso = await _cursoRepository.GetByIdAsync(cursoDto.Id);
            if (existingCurso == null)
            {
                throw new KeyNotFoundException($"No se encontró un curso con el ID {cursoDto.Id}.");
            }

            if (!await _materiaRepository.ExistsAsync(cursoDto.IdMateria))
                throw new BusinessRuleException($"La nueva materia con ID {cursoDto.IdMateria} no es válida o no existe.");
            if (!await _comisionRepository.ExistsAsync(cursoDto.IdComision))
                throw new BusinessRuleException($"La nueva comisión con ID {cursoDto.IdComision} no es válida o no existe.");

            if (await _cursoRepository.CursoExistsAsync(cursoDto.IdMateria, cursoDto.IdComision, cursoDto.AnioCalendario, cursoDto.Id))
            {
                throw new BusinessRuleException("La combinación de materia, comisión y año ya pertenece a otro curso.");
            }

            existingCurso.SetAnioCalendario(cursoDto.AnioCalendario);
            existingCurso.SetCupo(cursoDto.Cupo);
            existingCurso.SetDescripcion(cursoDto.Descripcion);
            existingCurso.SetIdComision(cursoDto.IdComision);
            existingCurso.SetIdMateria(cursoDto.IdMateria);

            await _cursoRepository.UpdateAsync(existingCurso);
            return cursoDto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var curso = await _cursoRepository.GetByIdAsync(id);
            if (curso == null)
            {
                throw new KeyNotFoundException($"No se encontró un curso con el ID {id} para eliminar.");
            }

            curso.SoftDelete();
            await _cursoRepository.UpdateAsync(curso);
            return true;
        }

        public async Task<CursoDTO> GetByIdAsync(int id)
        {
            var curso = await _cursoRepository.GetByIdAsync(id);
            if (curso == null) return null;

            return _mapper.Map<CursoDTO>(curso);
        }

        public async Task<IEnumerable<CursoDTO>> GetAllAsync()
        {
            var cursos = await _cursoRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CursoDTO>>(cursos);
        }
    }
}