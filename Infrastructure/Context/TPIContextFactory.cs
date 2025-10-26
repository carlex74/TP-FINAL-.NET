using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Context
{
    // Esta clase le dice a las herramientas de EF Core cómo crear el DbContext
    // en tiempo de diseño (ej. cuando se ejecutan migraciones).
    public class TPIContextFactory : IDesignTimeDbContextFactory<TPIContext>
    {
        public TPIContext CreateDbContext(string[] args)
        {
            // Creamos un IConfigurationBuilder para leer la configuración.
            // Esto es necesario porque no estamos en el contexto de ejecución de la API,
            // por lo que no podemos depender del 'builder.Configuration' del Program.cs.
            IConfigurationRoot configuration = new ConfigurationBuilder()
                // Le decimos que busque el appsettings.json en el directorio base del proyecto Infrastructure.
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<TPIContext>();

            // Obtenemos la cadena de conexión desde nuestro appsettings.json local.
            var connectionString = configuration.GetConnectionString("MySqlConnection");

            // Configuramos el DbContext para que use MySQL con la cadena de conexión obtenida.
            optionsBuilder.UseMySql(
                connectionString,
                ServerVersion.AutoDetect(connectionString),
                b => b.MigrationsAssembly("Infrastructure")
            );

            return new TPIContext(optionsBuilder.Options);
        }
    }
}