using ApplicationClean.DTOs;
using BCrypt.Net;
using System.Threading.Tasks;
using Domain.Entities;
using ApplicationClean.Interfaces.Repositories;
using ApplicationClean.Interfaces.Services;

namespace ApplicationClean.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IPersonaRepository _personaRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository, IPersonaRepository personaRepository)
        {
            _usuarioRepository = usuarioRepository;
            _personaRepository = personaRepository;
        }

        public async Task<UsuarioDTO> LoginAsync(LoginRequestDTO loginRequest)
        {
            var usuario = await _usuarioRepository.GetByLegajoAsync(loginRequest.Legajo);

            if (usuario == null || !usuario.Habilitado)
            {
                return null;
            }

            if (!BCrypt.Net.BCrypt.Verify(loginRequest.Clave, usuario.ClaveHash))
            {
                return null;
            }

            return new UsuarioDTO
            {
                Legajo = usuario.Legajo,
                Tipo = usuario.Tipo,
                Habilitado = usuario.Habilitado,
                IdPersona = usuario.IdPersona,
                ClaveHash = usuario.ClaveHash
            };
        }

        public async Task<UsuarioDTO> CreateUsuarioAsync(CrearUsuarioDTO crearUsuarioDto)
        {
            if (await _usuarioRepository.GetByLegajoAsync(crearUsuarioDto.Legajo) != null)
            {
                throw new ArgumentException("El legajo ya está registrado.");
            }
            var persona = await _personaRepository.GetByIdAsync(crearUsuarioDto.IdPersona);
            if (persona == null)
            {
                throw new KeyNotFoundException($"No se encontró una persona con el ID {crearUsuarioDto.IdPersona}.");
            }

            string claveHash = BCrypt.Net.BCrypt.HashPassword(crearUsuarioDto.Clave);

            var nuevoUsuario = new Usuario(
                crearUsuarioDto.Legajo,
                claveHash,
                crearUsuarioDto.Tipo,
                crearUsuarioDto.IdPersona
            );

            await _usuarioRepository.AddAsync(nuevoUsuario);

            return new UsuarioDTO
            {
                Legajo = nuevoUsuario.Legajo,
                Tipo = nuevoUsuario.Tipo,
                Habilitado = nuevoUsuario.Habilitado,
                IdPersona = nuevoUsuario.IdPersona,
            };
        }

        public async Task<UsuarioDTO> GetByLegajoAsync(string legajo)
        {
            var usuario = await _usuarioRepository.GetByLegajoAsync(legajo);
            if (usuario == null) return null;

            return MapToUsuarioDTO(usuario);
        }

        public async Task<IEnumerable<UsuarioDTO>> GetAllAsync()
        {
            var usuarios = await _usuarioRepository.GetAllAsync();
            return usuarios.Select(MapToUsuarioDTO);
        }

        public async Task<UsuarioDTO> UpdateAsync(string legajo, ActualizarUsuarioDTO actualizarUsuarioDto)
        {
            var usuario = await _usuarioRepository.GetByLegajoAsync(legajo);
            if (usuario == null)
            {
                throw new KeyNotFoundException($"No se encontró un usuario con el legajo {legajo}.");
            }

            usuario.SetTipo(actualizarUsuarioDto.Tipo);
            usuario.SetHabilitado(actualizarUsuarioDto.Habilitado);

            await _usuarioRepository.UpdateAsync(usuario);

            return MapToUsuarioDTO(usuario);
        }

        public async Task<bool> DeleteAsync(string legajo)
        {
            var usuario = await _usuarioRepository.GetByLegajoAsync(legajo);
            if (usuario == null)
            {
                return false;
            }

            await _usuarioRepository.DeleteAsync(usuario);
            return true;
        }

        private UsuarioDTO MapToUsuarioDTO(Usuario usuario)
        {
            if (usuario == null) return null;

            return new UsuarioDTO
            {
                Legajo = usuario.Legajo,
                Tipo = usuario.Tipo,
                Habilitado = usuario.Habilitado,
                IdPersona = usuario.IdPersona,
                ClaveHash = usuario.ClaveHash
            };
        }
    }
}