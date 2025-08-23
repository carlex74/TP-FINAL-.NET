using ApplicationClean.Services;
using Domain.Interfaces;
using Infrastructure.Persistance;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpLogging(o => { });

builder.Services.AddScoped<IEspecialidadRepository, EspecialidadMemoryRepository>();
builder.Services.AddScoped<EspecialidadServices>();
builder.Services.AddScoped<IPlanRepository,PlanMemoryRepository>();
builder.Services.AddScoped<PlanServices>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpLogging();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
