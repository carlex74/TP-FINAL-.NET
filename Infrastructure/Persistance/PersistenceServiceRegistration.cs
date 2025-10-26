using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence
{

    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            string? provider = configuration["DatabaseProvider"];

            services.AddDbContext<TPIContext>(options =>
            {
                switch (provider?.ToLower())
                {
                    case "sqlserver":
                        options.UseSqlServer(
                            configuration.GetConnectionString("SqlServerConnection"),
                            b => b.MigrationsAssembly(typeof(TPIContext).Assembly.FullName));
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

            return services;
        }
    }
}