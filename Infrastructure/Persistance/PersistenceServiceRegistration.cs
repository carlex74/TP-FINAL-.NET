using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
// Importa tus contextos y repositorios
using Infrastructure.Context;
// using Infrastructure.Repositories;
// using Application.Interfaces;

namespace Infrastructure.Persistence
{
    // Una clase estática para contener nuestro método de extensión
    public static class PersistenceServiceRegistration
    {
        // El método de extensión para IServiceCollection
        public static IServiceCollection AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // --- 1. LÓGICA DEL DBCONTEXT (LA FÁBRICA QUE QUERÍAS) ---
            string? provider = configuration["DatabaseProvider"];

            services.AddDbContext<TPIContext>(options =>
            {
                switch (provider?.ToLower())
                {
                    case "sqlserver":
                        options.UseSqlServer(
                            configuration.GetConnectionString("SqlServerConnection"),
                            b => b.MigrationsAssembly(typeof(TPIContext).Assembly.FullName)); // Forma más robusta de obtener el assembly
                        break;

                    case "mysql":
                        var connectionString = configuration.GetConnectionString("MySqlConnection");
                        options.UseMySql(
                            connectionString,
                            ServerVersion.AutoDetect(connectionString),
                            b => b.MigrationsAssembly(typeof(TPIContext).Assembly.FullName));
                        break;

                    default:
                        throw new InvalidOperationException($"Proveedor de base de datos no soportado: '{provider}'");
                }
            });

            // --- 2. REGISTRO DE REPOSITORIOS ---
            // Este es el lugar perfecto para registrar también todos tus repositorios.
            // Mantiene toda la configuración de la capa de persistencia en un solo lugar.
            /*
            services.AddScoped<IAlumnoInscripcionRepository, AlumnoInscripcionRepository>();
            services.AddScoped<IDocenteCursoRepository, DocenteCursoRepository>();
            services.AddScoped<ICursoRepository, CursoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            */
            // etc...

            return services;
        }
    }
}