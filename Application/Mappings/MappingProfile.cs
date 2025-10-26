using ApplicationClean.DTOs;
using AutoMapper;
using Domain.Entities;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Mapeo de Entidad a DTO
        CreateMap<AlumnoInscripcion, AlumnoInscripcionDTO>();
        CreateMap<DocenteCurso, DocenteCursoDTO>();
        CreateMap<Comision, ComisionDTO>();
        CreateMap<Curso, CursoDTO>();
        CreateMap<Especialidad, EspecialidadDTO>();
        CreateMap<Plan, PlanDTO>()
        .ForMember(dest => dest.EspecialidadDescripcion,
               opt => opt.MapFrom(src => src.Especialidad.Descripcion));
        CreateMap<Materia, MateriaDTO>();
        CreateMap<Persona, PersonaDTO>();

        // Mapeo de DTO a Entidad (para el AddAsync)
        CreateMap<AlumnoInscripcionDTO, AlumnoInscripcion>();
        CreateMap<DocenteCursoDTO, DocenteCurso>();
        CreateMap<ComisionDTO, Comision>();
        CreateMap<CursoDTO, Curso>();
        CreateMap<EspecialidadDTO, Especialidad>();
        CreateMap<PlanDTO, Plan>();
        CreateMap<CrearPlanDTO, Plan>();
        CreateMap<MateriaDTO, Materia>();
        CreateMap<PersonaDTO, Persona>();
    }
}