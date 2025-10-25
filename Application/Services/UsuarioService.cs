using ApplicationClean.DTOs;
using BCrypt.Net;
using System.Threading.Tasks;
using Domain.Entities;
using ApplicationClean.Interfaces.Repositories;
using ApplicationClean.Interfaces.Services;
using static Domain.Entities.Usuario;

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
            var usuario = await _usuarioRepository.GetByLegajoIncludingDeletedAsync(loginRequest.Legajo);
            if (usuario == null || !usuario.Habilitado) return null;
            if (!BCrypt.Net.BCrypt.Verify(loginRequest.Clave, usuario.ClaveHash)) return null;
            return MapToUsuarioDTO(usuario);
        }

        public async Task<UsuarioDTO> CreateUsuarioAsync(CrearUsuarioDTO crearUsuarioDto)
        {
            if (await _usuarioRepository.LegajoExistsAsync(crearUsuarioDto.Legajo))
            {
                throw new BusinessRuleException("El legajo ya está registrado.");
            }
            if (!await _personaRepository.ExistsAsync(crearUsuarioDto.IdPersona))
            {
                throw new KeyNotFoundException($"No se encontró una persona con el ID {crearUsuarioDto.IdPersona}.");
            }
            var persona = await _personaRepository.GetByIdAsync(crearUsuarioDto.IdPersona);
            if (persona == null)
            {
                throw new KeyNotFoundException($"No se encontró una persona con el ID {crearUsuarioDto.IdPersona}.");
            }

            string claveHash = BCrypt.Net.BCrypt.HashPassword(crearUsuarioDto.Clave);
            Usuario nuevoUsuario;

            switch (crearUsuarioDto.Tipo)
            {
                case TipoUsuario.Alumno:
                    nuevoUsuario = new Alumno(crearUsuarioDto.Legajo, claveHash, crearUsuarioDto.IdPersona, crearUsuarioDto.IdPlan);
                    break;
                case TipoUsuario.Docente:
                    nuevoUsuario = new Docente(crearUsuarioDto.Legajo, claveHash, crearUsuarioDto.IdPersona);
                    break;
                case TipoUsuario.Administrador:
                    nuevoUsuario = new Administrador(crearUsuarioDto.Legajo, claveHash, crearUsuarioDto.IdPersona);
                    break;
                default:
                    throw new ArgumentException("Tipo de usuario no válido.");
            }

            await _usuarioRepository.AddAsync(nuevoUsuario);
            var usuarioParaMapear = await _usuarioRepository.GetByLegajoAsync(nuevoUsuario.Legajo);
            return MapToUsuarioDTO(usuarioParaMapear);
        }

        public async Task<UsuarioDTO> GetByLegajoAsync(string legajo)
        {
            var usuario = await _usuarioRepository.GetByLegajoAsync(legajo);
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

            if (usuario.Tipo != actualizarUsuarioDto.Tipo)
            {
                throw new InvalidOperationException("No se puede cambiar el tipo de un usuario existente.");
            }

            usuario.SetHabilitado(actualizarUsuarioDto.Habilitado);

            if (usuario is Alumno alumno)
            {
                alumno.SetIdPlan(actualizarUsuarioDto.IdPlan);
            }

            await _usuarioRepository.UpdateAsync(usuario);
            return MapToUsuarioDTO(usuario);
        }

        public async Task<bool> DeleteAsync(string legajo)
        {
            var usuario = await _usuarioRepository.GetByLegajoAsync(legajo);
            if (usuario == null)
            {
                throw new KeyNotFoundException($"No se encontró un usuario con el legajo {legajo} para eliminar.");
            }

            usuario.SoftDelete(); 
            await _usuarioRepository.DeleteAsync(usuario);
            return true;
        }

        private UsuarioDTO MapToUsuarioDTO(Usuario usuario)
        {
            if (usuario == null) return null;

            var dto = new UsuarioDTO
            {
                Legajo = usuario.Legajo,
                Tipo = usuario.Tipo,
                Habilitado = usuario.Habilitado,
                IdPersona = usuario.IdPersona,
                ClaveHash = usuario.ClaveHash,
                PersonaNombreCompleto = usuario.Persona?.Nombre + " " + usuario.Persona?.Apellido
            };

            if (usuario is Alumno alumno)
            {
                dto.IdPlan = alumno.IdPlan;
                dto.PlanDescripcion = alumno.Plan?.Especialidad?.Descripcion != null ?
                                      $"{alumno.Plan.Descripcion} ({alumno.Plan.Especialidad.Descripcion})" :
                                      alumno.Plan?.Descripcion;
            }

            return dto;
        }
    }
}