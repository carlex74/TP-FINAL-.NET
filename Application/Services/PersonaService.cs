using ApplicationClean.DTOs;
using ApplicationClean.Interfaces;
using ApplicationClean.Interfaces.Repositories;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationClean.Services
{
    public class PersonaService : IPersonaService
    {
        private readonly IPersonaRepository _personaRepository;

        public PersonaService(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
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

            var persona = new Persona(
                0,
                personaDto.Nombre,
                personaDto.Apellido,
                personaDto.Dni,
                personaDto.FechaNacimiento,
                personaDto.Email,
                personaDto.Direccion,
                personaDto.Telefono

            );

            await _personaRepository.AddAsync(persona);

            personaDto.Id = persona.Id;
            return personaDto;
        }

        public async Task<PersonaDTO> UpdateAsync(PersonaDTO personaDto)
        {
            var existingPersona = await _personaRepository.GetByIdAsync(personaDto.Id);
            if (existingPersona == null)
            {
                throw new KeyNotFoundException($"No se encontró una persona con el ID {personaDto.Id}.");
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
            if (persona == null) return false;

            await _personaRepository.DeleteAsync(persona);
            return true;
        }

        public async Task<PersonaDTO> GetByIdAsync(int id)
        {
            var persona = await _personaRepository.GetByIdAsync(id);
            if (persona == null) return null;

            return new PersonaDTO
            {
                Id = persona.Id,
                Nombre = persona.Nombre,
                Apellido = persona.Apellido,
                Dni = persona.Dni,
                Email = persona.Email,
                FechaNacimiento = persona.FechaNacimiento,
                Direccion = persona.Direccion,
                Telefono = persona.Telefono
            };
        }

        public async Task<IEnumerable<PersonaDTO>> GetAllAsync()
        {
            var personas = await _personaRepository.GetAllAsync();
            return personas.Select(p => new PersonaDTO
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Apellido = p.Apellido,
                Dni = p.Dni,
                Email = p.Email,
                FechaNacimiento = p.FechaNacimiento,
                Direccion = p.Direccion,
                Telefono = p.Telefono
            });
        }
    }
}