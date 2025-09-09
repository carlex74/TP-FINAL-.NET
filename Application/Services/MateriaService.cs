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
        private readonly IMateriaRepository _materiaRepository;

        public MateriaService(IMateriaRepository materiaRepository)
        {
            _materiaRepository = materiaRepository;
        }

        public async Task<MateriaDTO> AddAsync(MateriaDTO materiaDTO)
        {
            var materia = new Materia(0, materiaDTO.Nombre, materiaDTO.Descripcion, materiaDTO.HsSemanales, materiaDTO.HsTotales);
            await _materiaRepository.AddAsync(materia);

            materiaDTO.Id = materia.Id;
            return materiaDTO;
        }

        public async Task<MateriaDTO> UpdateAsync(MateriaDTO materiaDTO)
        {
            var existingMateria = await _materiaRepository.GetByIdAsync(materiaDTO.Id);
            if (existingMateria == null)
            {
                throw new KeyNotFoundException($"No se encontró un materia con el ID {materiaDTO.Id}.");
            }

            existingMateria.SetNombre(materiaDTO.Nombre);
            existingMateria.SetDescripcion(materiaDTO.Descripcion);
            existingMateria.SetHsSemanales(materiaDTO.HsSemanales);
            existingMateria.SetHsTotales(materiaDTO.HsTotales);

            await _materiaRepository.UpdateAsync(existingMateria);
            return materiaDTO;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var materia = await _materiaRepository.GetByIdAsync(id);
            if (materia == null)
            {
                return false;
            }
            await _materiaRepository.DeleteAsync(materia);
            return true;
        }

        public async Task<MateriaDTO> GetByIdAsync(int id)
        {
            var materia = await _materiaRepository.GetByIdAsync(id);
            if (materia == null) return null;

            return new MateriaDTO
            {
                Id = materia.Id,
                Nombre = materia.Nombre,
                Descripcion = materia.Descripcion,
                HsSemanales = materia.HsSemanales,
                HsTotales = materia.HsTotales,
            };
        }

        public async Task<IEnumerable<MateriaDTO>> GetAllAsync()
        {
            var materiaes = await _materiaRepository.GetAllAsync();
            return materiaes.Select(materia => new MateriaDTO
            {
                Id = materia.Id,
                Nombre = materia.Nombre,
                Descripcion = materia.Descripcion,
                HsSemanales = materia.HsSemanales,
                HsTotales = materia.HsTotales,
            });
        }
    }
}