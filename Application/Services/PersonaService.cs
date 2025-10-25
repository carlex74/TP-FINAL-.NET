using ApplicationClean.DTOs;
using ApplicationClean.Interfaces;
using ApplicationClean.Interfaces.Repositories;
using Domain.Entities;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationClean.Services
{
    public class PersonaService : IPersonaService
    {
        private readonly IPersonaRepository _personaRepository;
        private readonly IMapper _mapper;

        public PersonaService(IPersonaRepository personaRepository, IMapper mapper)
        {
            _personaRepository = personaRepository;
            _mapper = mapper;
        }

        public async Task<PersonaDTO> AddAsync(PersonaDTO personaDto)
        {
            if (await _personaRepository.GetByDniAsync(personaDto.Dni) != null)
            {
                throw new ArgumentException("Ya existe una persona con el mismo DNI.");
            }
            if (await _personaRepository.GetByEmailAsync(personaDto.Email) != null)
            {
                throw new ArgumentException("Ya existe una persona con el mismo Email.");
            }

            var nuevaPersona = _mapper.Map<Persona>(personaDto);

            await _personaRepository.AddAsync(nuevaPersona);

            return _mapper.Map<PersonaDTO>(nuevaPersona);
        }

        public async Task<PersonaDTO> UpdateAsync(PersonaDTO personaDto)
        {
            var existingPersona = await _personaRepository.GetByIdAsync(personaDto.Id);
            if (existingPersona == null)
            {
                throw new KeyNotFoundException($"No se encontró una persona con el ID {personaDto.Id}.");
            }

            // Validar unicidad de DNI y Email incluso en personas soft-deleted
            if (await _personaRepository.DniExistsAsync(personaDto.Dni, personaDto.Id))
            {
                throw new BusinessRuleException("El DNI ingresado ya pertenece a otra persona.");
            }
            if (await _personaRepository.EmailExistsAsync(personaDto.Email, personaDto.Id))
            {
                throw new BusinessRuleException("El Email ingresado ya pertenece a otra persona.");
            }

            existingPersona.SetNombre(personaDto.Nombre);
            existingPersona.SetApellido(personaDto.Apellido);
            existingPersona.SetDni(personaDto.Dni);
            existingPersona.SetEmail(personaDto.Email);
            existingPersona.SetDireccion(personaDto.Direccion);
            existingPersona.SetTelefono(personaDto.Telefono);
            existingPersona.SetFechaNacimiento(personaDto.FechaNacimiento);

            await _personaRepository.UpdateAsync(existingPersona);

            return personaDto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var persona = await _personaRepository.GetByIdAsync(id);
            if (persona == null)
            {
                throw new KeyNotFoundException($"No se encontró una persona con el ID {id} para eliminar.");
            }


            persona.SoftDelete();
            await _personaRepository.UpdateAsync(persona);
            return true;
        }

        public async Task<PersonaDTO> GetByIdAsync(int id)
        {
            var persona = await _personaRepository.GetByIdAsync(id);
            if (persona == null) return null;

            return _mapper.Map<PersonaDTO>(persona);
        }

        public async Task<IEnumerable<PersonaDTO>> GetAllAsync()
        {
            var personas = await _personaRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PersonaDTO>>(personas);
        }
    }
}