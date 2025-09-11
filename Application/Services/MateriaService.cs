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
        private readonly IMateriaRepository _repository;

        public MateriaService(IMateriaRepository repository)
        {
            _repository = repository;
        }

        public async Task<MateriaDTO> AddAsync(MateriaDTO materiaDto)
        {
            var materia = new Materia(0, materiaDto.Nombre, materiaDto.Descripcion, materiaDto.HsSemanales, materiaDto.HsTotales);

            await _repository.AddAsync(materia);

            materiaDto.Id = materia.Id;
            return materiaDto;
        }

        public async Task<MateriaDTO> UpdateAsync(MateriaDTO materiaDto)
        {
            var existingMateria = await _repository.GetByIdAsync(materiaDto.Id);
            if (existingMateria == null)
            {
                throw new KeyNotFoundException($"No se encontró una materia con el ID {materiaDto.Id}.");
            }

            existingMateria.SetNombre(materiaDto.Nombre);
            existingMateria.SetDescripcion(materiaDto.Descripcion);
            existingMateria.SetHsSemanales(materiaDto.HsSemanales);
            existingMateria.SetHsTotales(materiaDto.HsTotales);

            await _repository.UpdateAsync(existingMateria);
            return materiaDto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var materia = await _repository.GetByIdAsync(id);
            if (materia == null)
            {
                return false;
            }
            await _repository.DeleteAsync(materia);
            return true;
        }

        public async Task<MateriaDTO> GetByIdAsync(int id)
        {
            var materia = await _repository.GetByIdAsync(id);
            if (materia == null) return null;

            return new MateriaDTO
            {
                Id = materia.Id,
                Nombre = materia.Nombre,
                Descripcion = materia.Descripcion,
                HsSemanales = materia.HsSemanales,
                HsTotales = materia.HsTotales
            };
        }

        public async Task<IEnumerable<MateriaDTO>> GetAllAsync()
        {
            var materias = await _repository.GetAllAsync();
            return materias.Select(m => new MateriaDTO
            {
                Id = m.Id,
                Nombre = m.Nombre,
                Descripcion = m.Descripcion,
                HsSemanales = m.HsSemanales,
                HsTotales = m.HsTotales
            });
        }
    }
}