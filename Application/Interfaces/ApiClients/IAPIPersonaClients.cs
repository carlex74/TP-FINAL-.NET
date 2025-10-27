using ApplicationClean.DTOs;


namespace ApplicationClean.Interfaces.ApiClients
{
    public interface IAPIPersonaClients
    {
        Task<IEnumerable<PersonaDTO>> GetAll();
        Task<PersonaDTO> GetById(int id);
        Task<PersonaDTO> Add(PersonaDTO personaDto);
        Task Update(PersonaDTO personaDto);
        // A FUTURO: Se puede reactivar la llamada al endpoint de borrado.
        //Task Delete(int id);
    }
}