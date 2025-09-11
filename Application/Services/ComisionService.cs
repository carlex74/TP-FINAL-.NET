// Ubicación: Application/Services/ComisionService.cs

using ApplicationClean.DTOs;
using ApplicationClean.Interfaces.Repositories;
using ApplicationClean.Interfaces.Services;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationClean.Services
{
    public class ComisionService : IComisionService
    {
        private readonly IComisionRepository _repository;

        public ComisionService(IComisionRepository repository)
        {
            _repository = repository;
        }

        public async Task<ComisionDTO> AddAsync(ComisionDTO comisionDto)
        {
            var comision = new Comision(0, comisionDto.AnioEspecialidad, comisionDto.Descripcion);

            await _repository.AddAsync(comision);

            return MapToComisionDTO(comision);
        }

        public async Task<ComisionDTO> UpdateAsync(ComisionDTO comisionDto)
        {
            var comisionExistente = await _repository.GetByIdAsync(comisionDto.Nro);
            if (comisionExistente == null)
            {
                throw new KeyNotFoundException($"No se encontró una Comisión con el ID {comisionDto.Nro}.");
            }

            comisionExistente.SetAnioEspecialidad(comisionDto.AnioEspecialidad);
            comisionExistente.SetDescripcion(comisionDto.Descripcion);

            await _repository.UpdateAsync(comisionExistente);

            return MapToComisionDTO(comisionExistente);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var comision = await _repository.GetByIdAsync(id);
            if (comision == null) return false;

            await _repository.DeleteAsync(comision);
            return true;
        }

        public async Task<ComisionDTO> GetByIdAsync(int id)
        {
            var comision = await _repository.GetByIdAsync(id);
            return MapToComisionDTO(comision);
        }

        public async Task<IEnumerable<ComisionDTO>> GetAllAsync()
        {
            var comisiones = await _repository.GetAllAsync();
            return comisiones.Select(MapToComisionDTO);
        }

        private ComisionDTO MapToComisionDTO(Comision comision)
        {
            if (comision == null) return null;
            return new ComisionDTO
            {
                Nro = comision.Nro,
                AnioEspecialidad = comision.AnioEspecialidad,
                Descripcion = comision.Descripcion
            };
        }
    }
}