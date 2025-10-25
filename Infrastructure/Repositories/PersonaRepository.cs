using ApplicationClean.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly TPIContext _context;
        public PersonaRepository(TPIContext context) { _context = context; }

        public async Task<Persona> GetByIdAsync(int id)
        {
            return await _context.Personas.FindAsync(id);
        }

        public async Task<IEnumerable<Persona>> GetAllAsync()
        {
            return await _context.Personas.ToListAsync();
        }

        public async Task AddAsync(Persona persona)
        {
            await _context.Personas.AddAsync(persona);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Persona persona)
        {
            _context.Personas.Update(persona);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Persona persona)
        {
            _context.Personas.Remove(persona);
            await _context.SaveChangesAsync();
        }

        public async Task<Persona> GetByEmailAsync(string email)
        {
            return await _context.Personas.FirstOrDefaultAsync(p => p.Email == email);
        }

        public async Task<Persona> GetByDniAsync(string dni)
        {
            return await _context.Personas.FirstOrDefaultAsync(p => p.Dni == dni);
        }


        public async Task<bool> DniExistsAsync(string dni, int? excludeId = null)
        {
            var query = _context.Personas.IgnoreQueryFilters(); // Ignora el filtro de borrado lógico
            if (excludeId.HasValue)
            {
                query = query.Where(p => p.Id != excludeId.Value);
            }
            return await query.AnyAsync(p => p.Dni == dni);
        }

        public async Task<bool> EmailExistsAsync(string email, int? excludeId = null)
        {
            var query = _context.Personas.IgnoreQueryFilters(); // Ignora el filtro de borrado lógico
            if (excludeId.HasValue)
            {
                query = query.Where(p => p.Id != excludeId.Value);
            }
            return await query.AnyAsync(p => p.Email == email);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            //La consulta respetará el filtro global.
            return await _context.Personas
                                 .AnyAsync(p => p.Id == id);
        }
    }
}