using ApplicationClean.DTOs;


namespace ApplicationClean.Interfaces.ApiClients
{
    public interface IAPIPersonaClients
    {
        Task<IEnumerable<PersonaDTO>> GetAll();
        Task<PersonaDTO> GetById(int id);
        Task<PersonaDTO> Add(PersonaDTO personaDto);
        Task Update(PersonaDTO personaDto);
        Task Delete(int id);
    }
}