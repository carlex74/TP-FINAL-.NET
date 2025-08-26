using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace Infrastructure.Context
{
    public class TpConterxt : DbContext
    {
        public DbSet<Plan> plan { get; set; }
        public DbSet<Especialidad> especialidad { get; set; }

        internal TpConterxt()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory()) // Ensure System.IO is included
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                string connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString); // This requires the Microsoft.EntityFrameworkCore.SqlServer package
            }
        }
    }
}
