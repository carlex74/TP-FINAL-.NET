using ApplicationClean.Interfaces;
using ApplicationClean.Interfaces.Repositories;
using ApplicationClean.Interfaces.Services;
using ApplicationClean.Services;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("MySqlConnection");
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;

        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddDbContext<TPIContext>(options =>
         //options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    options.UseMySql(
        builder.Configuration.GetConnectionString("MySqlConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MySqlConnection")),
        // ----> AÑADE ESTA LÍNEA <----
        b => b.MigrationsAssembly("Infrastructure")
    )

);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IEspecialidadRepository, EspecialidadRepository>();
builder.Services.AddScoped<IPlanRepository, PlanRepository>();
builder.Services.AddScoped<IPersonaRepository, PersonaRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IMateriaRepository, MateriaRepository>();
builder.Services.AddScoped<IComisionRepository, ComisionRepository>();
builder.Services.AddScoped<ICursoRepository, CursoRepository>();
builder.Services.AddScoped<IAlumnoInscripcionRepository, AlumnoInscripcionRepository>();
builder.Services.AddScoped<IDocenteCursoRepository,DocenteCursoRepository>();

builder.Services.AddScoped<IEspecialidadService, EspecialidadServices>();
builder.Services.AddScoped<IPlanService, PlanServices>();
builder.Services.AddScoped<IPersonaService, PersonaService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IMateriaService, MateriaService>();
builder.Services.AddScoped<IComisionService, ComisionService>();
builder.Services.AddScoped<ICursoService, CursoService>();
builder.Services.AddScoped<IAlumnoInscripcionService,AlumnoInscripcionService>();
builder.Services.AddScoped<IDocenteCursoService,DocenteCursoService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpLogging(o => { });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpLogging();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();