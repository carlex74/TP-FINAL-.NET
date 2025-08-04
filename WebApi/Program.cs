using Domain.Services;
using Domain.Model;
using DTOs;

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

    EspecialidadDTO dto = especialidadServices.Get(id);

    if (dto == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(dto);
})
.WithName("GetEspecialidad")
.WithTags("Especialidades")
.Produces<EspecialidadDTO>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound)
.WithOpenApi();

app.MapGet("/especialidad", () =>
{
    EspecialidadServices especialidadServices = new EspecialidadServices();

    var dtos = especialidadServices.GetAll();

    return Results.Ok(dtos);
})
.WithName("GetAllEspecialidades")
.WithTags("Especialidades")
.Produces<List<EspecialidadDTO>>(StatusCodes.Status200OK)
.WithOpenApi();

app.MapPost("/especialidades", (EspecialidadDTO dto) =>
{
    try
    {
        EspecialidadServices especialidadServices = new EspecialidadServices();

        EspecialidadDTO especialidadDTO = especialidadServices.Add(dto);

        return Results.Created($"/especialidades/{especialidadDTO.Id}", especialidadDTO);
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(new { error = ex.Message });
    }
})
.WithName("AddEspecialidad")
.WithTags("Especialidades")
.Produces<EspecialidadDTO>(StatusCodes.Status201Created)
.Produces(StatusCodes.Status400BadRequest)
.WithOpenApi();

app.MapPut("/especialidades", (EspecialidadDTO dto) =>
{
    try
    {
        EspecialidadServices especialidadServices = new EspecialidadServices();

        var found = especialidadServices.Update(dto);

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
.WithTags("Especialidades")
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
.WithTags("Especialidades")
.Produces(StatusCodes.Status204NoContent)
.Produces(StatusCodes.Status404NotFound)
.WithOpenApi();

app.MapGet("/planes/{id}", (int id) =>
{
    PlanServices planServices = new PlanServices();

    PlanDTO dto = planServices.Get(id);

    if (dto == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(dto);
})
.WithName("GetPlan")
.WithTags("Planes")
.Produces<PlanDTO>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound)
.WithOpenApi();

app.MapGet("/plan", () =>
{
    PlanServices planServices = new PlanServices();

    var dtos = planServices.GetAll();

    return Results.Ok(dtos);
})
.WithName("GetAllPlanes")
.WithTags("Planes")
.Produces<List<PlanDTO>>(StatusCodes.Status200OK)
.WithOpenApi();

app.MapPost("/planes", (PlanDTO dto) =>
{
    try
    {
        PlanServices planServices = new PlanServices();

        PlanDTO planDTO = planServices.Add(dto);

        return Results.Created($"/planes/{planDTO.Id}", planDTO);
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(new { error = ex.Message });
    }
})
.WithName("AddPlan")
.WithTags("Planes")
.Produces<PlanDTO>(StatusCodes.Status201Created)
.Produces(StatusCodes.Status400BadRequest)
.WithOpenApi();

app.MapPut("/planes", (PlanDTO dto) =>
{
    try
    {
        PlanServices planServices = new PlanServices();

        var found = planServices.Update(dto);

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
.WithTags("Planes")
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
.WithTags("Planes")
.Produces(StatusCodes.Status204NoContent)
.Produces(StatusCodes.Status404NotFound)
.WithOpenApi();

app.Run();
