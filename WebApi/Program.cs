using Microsoft.EntityFrameworkCore;
using Infrastructure.Context;
using Domain.Interfaces;
using ApplicationClean.Interfaces; 
using Infrastructure.Repositories;
using ApplicationClean.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IEspecialidadRepository, EspecialidadRepository>();
builder.Services.AddScoped<IPlanRepository, PlanRepository>();
builder.Services.AddScoped<IEspecialidadService, EspecialidadServices>();
builder.Services.AddScoped<IPlanService, PlanServices>();

builder.Services.AddControllers();
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