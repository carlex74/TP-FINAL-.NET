using ApplicationClean.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly TPIContext _context;
        public UsuarioRepository(TPIContext context) { _context = context; }

        public async Task<Usuario> GetByLegajoAsync(string legajo)
        {
            return await _context.Usuarios
                                 .Include(u => u.Persona)
                                 .FirstOrDefaultAsync(u => u.Legajo == legajo);
        }

        public async Task AddAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios
                                 .Include(u => u.Persona)
                                 .ToListAsync();
        }
    }
}