using Domain.Services;
using Domain.Model;
using Microsoft.AspNetCore.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpLogging(o => { });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpLogging();
}

app.UseHttpsRedirection();

app.MapGet("/especialidades/{id}", (int id) =>
{
    EspecialidadServices especialidadServices = new EspecialidadServices();

    Especialidad especialidad = especialidadServices.Get(id);

    if (especialidad == null)
    {
        return Results.NotFound();
    }

    var dto = new DTOs.Especialidad
    {
        Id = especialidad.Id,
        Descripcion = especialidad.Descripcion
    };

    return Results.Ok(dto);
})
.WithName("GetEspecialidad")
.Produces<DTOs.Especialidad>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound)
.WithOpenApi();

app.MapGet("/especialidad", () =>
{
    EspecialidadServices especialidadServices = new EspecialidadServices();

    var especialidades = especialidadServices.GetAll();

    var dtos = especialidades.Select(especialidades => new DTOs.Especialidad
    {
        Id = especialidades.Id,
        Descripcion = especialidades.Descripcion
    }).ToList();

    return Results.Ok(dtos);
})
.WithName("GetAllEspecialidades")
.Produces<List<DTOs.Especialidad>>(StatusCodes.Status200OK)
.WithOpenApi();

app.MapPost("/especialidades", (DTOs.Especialidad dto) =>
{
    try
    {
        EspecialidadServices especialidadServices = new EspecialidadServices();

        Especialidad especialidad = new Especialidad(dto.Id, dto.Descripcion);

        especialidadServices.Add(especialidad);

        var dtoResultado = new DTOs.Especialidad
        {
            Id = especialidad.Id,
            Descripcion = especialidad.Descripcion
        };

        return Results.Created($"/especialidades/{dtoResultado.Id}", dtoResultado);
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(new { error = ex.Message });
    }
})
.WithName("AddEspecialidad")
.Produces<DTOs.Especialidad>(StatusCodes.Status201Created)
.Produces(StatusCodes.Status400BadRequest)
.WithOpenApi();

app.MapPut("/especialidades", (DTOs.Especialidad dto) =>
{
    try
    {
        EspecialidadServices especialidadServices = new EspecialidadServices();

        Especialidad especialidad = new Especialidad(dto.Id, dto.Descripcion);

        var found = especialidadServices.Update(especialidad);

        if (!found)
        {
            return Results.NotFound();
        }

        return Results.NoContent();
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(new { error = ex.Message });
    }
})
.WithName("UpdateEspecialidad")
.Produces(StatusCodes.Status404NotFound)
.Produces(StatusCodes.Status400BadRequest)
.WithOpenApi();

app.MapDelete("/especialidades/{id}", (int id) =>
{
    EspecialidadServices especialidadServices = new EspecialidadServices();

    var deleted = especialidadServices.Delete(id);

    if (!deleted)
    {
        return Results.NotFound();
    }

    return Results.NoContent();

})
.WithName("DeleteEspecialidad")
.Produces(StatusCodes.Status204NoContent)
.Produces(StatusCodes.Status404NotFound)
.WithOpenApi();

app.MapGet("/planes/{id}", (int id) =>
{
    PlanServices planServices = new PlanServices();

    Plan plan = planServices.Get(id);

    if (plan == null)
    {
        return Results.NotFound();
    }

    var dto = new DTOs.Plan
    {
        Id = plan.Id,
        Descripcion = plan.Descripcion,
        IdEspecialidad = plan.IdEspecialidad
    };

    return Results.Ok(dto);
})
.WithName("GetPlan")
.Produces<DTOs.Plan>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound)
.WithOpenApi();

app.MapGet("/plan", () =>
{
    PlanServices planServices = new PlanServices();

    var planes = planServices.GetAll();

    var dtos = planes.Select(planes => new DTOs.Plan
    {
        Id = planes.Id,
        Descripcion = planes.Descripcion,
        IdEspecialidad = planes.IdEspecialidad
    }).ToList();

    return Results.Ok(dtos);
})
.WithName("GetAllPlanes")
.Produces<List<DTOs.Plan>>(StatusCodes.Status200OK)
.WithOpenApi();

app.MapPost("/planes", (DTOs.Plan dto) =>
{
    try
    {
        PlanServices planServices = new PlanServices();

        Plan plan = new Plan(dto.Id, dto.Descripcion, dto.IdEspecialidad);

        planServices.Add(plan);

        var dtoResultado = new DTOs.Plan
        {
            Id = plan.Id,
            Descripcion = plan.Descripcion,
            IdEspecialidad = plan.IdEspecialidad
        };

        return Results.Created($"/planes/{dtoResultado.Id}", dtoResultado);
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(new { error = ex.Message });
    }
})
.WithName("AddPlan")
.Produces<DTOs.Plan>(StatusCodes.Status201Created)
.Produces(StatusCodes.Status400BadRequest)
.WithOpenApi();

app.MapPut("/planes", (DTOs.Plan dto) =>
{
    try
    {
        PlanServices planServices = new PlanServices();

        Plan plan = new Plan(dto.Id, dto.Descripcion, dto.IdEspecialidad);

        var found = planServices.Update(plan);

        if (!found)
        {
            return Results.NotFound();
        }

        return Results.NoContent();
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(new { error = ex.Message });
    }
})
.WithName("UpdatePlan")
.Produces(StatusCodes.Status404NotFound)
.Produces(StatusCodes.Status400BadRequest)
.WithOpenApi();

app.MapDelete("/plan/{id}", (int id) =>
{
    PlanServices planServices = new PlanServices();

    var deleted = planServices.Delete(id);

    if (!deleted)
    {
        return Results.NotFound();
    }

    return Results.NoContent();

})
.WithName("DeletePlan")
.Produces(StatusCodes.Status204NoContent)
.Produces(StatusCodes.Status404NotFound)
.WithOpenApi();

app.Run();
