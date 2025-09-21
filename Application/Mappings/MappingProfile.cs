using AutoMapper;
using Domain.Entities;
using ApplicationClean.DTOs;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Mapeo de Entidad a DTO
        CreateMap<AlumnoInscripcion, AlumnoInscripcionDTO>();
        CreateMap<DocenteCurso,DocenteCursoDTO>();
        // Mapeo de DTO a Entidad (para el AddAsync)
        CreateMap<AlumnoInscripcionDTO, AlumnoInscripcion>();
        CreateMap<DocenteCursoDTO, DocenteCurso>();
    }
}