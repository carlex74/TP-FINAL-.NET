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
            if (await _materiaRepository.GetByIdAsync(cursoDto.IdMateria) == null)
                throw new KeyNotFoundException($"La materia con ID {cursoDto.IdMateria} no existe.");
            if (await _comisionRepository.GetByIdAsync(cursoDto.IdComision) == null)
                throw new KeyNotFoundException($"La comisión con ID {cursoDto.IdComision} no existe.");

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
            if (curso == null) return false;

            await _cursoRepository.DeleteAsync(curso);
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