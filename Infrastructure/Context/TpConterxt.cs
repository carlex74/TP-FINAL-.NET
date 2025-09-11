using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class TPIContext : DbContext
    {
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Plan> Planes { get; set; }
        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Comision> Comisiones { get; set; }
        public DbSet<Curso> Cursos { get; set; }

        public TPIContext(DbContextOptions<TPIContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Nombre).IsRequired().HasMaxLength(50);
                entity.Property(p => p.Apellido).IsRequired().HasMaxLength(50);
                entity.Property(p => p.Dni).IsRequired().HasMaxLength(20);
                entity.HasIndex(p => p.Dni).IsUnique();
                entity.HasIndex(p => p.Email).IsUnique();
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(u => u.Legajo);
                entity.Property(u => u.ClaveHash).IsRequired();
                entity.Property(u => u.Tipo)
                      .HasConversion<string>()
                      .HasMaxLength(50);

                entity.HasOne(u => u.Persona)
                      .WithMany(p => p.Usuarios)
                      .HasForeignKey(u => u.IdPersona);
            });

            modelBuilder.Entity<Especialidad>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Descripcion).IsRequired().HasMaxLength(255);
            });

            modelBuilder.Entity<Plan>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Descripcion).IsRequired().HasMaxLength(255);

                entity.HasOne(p => p.Especialidad)
                      .WithMany(e => e.Planes)
                      .HasForeignKey(p => p.IdEspecialidad);
            });

            modelBuilder.Entity<Materia>(entity =>
            {
                entity.HasKey(m => m.Id);
                entity.Property(m => m.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(m => m.Descripcion).HasMaxLength(255);

                entity.HasMany(m => m.Planes)
                      .WithMany(p => p.Materias);
            });

            modelBuilder.Entity<Comision>(entity =>
            {
                entity.HasKey(c => c.Nro);
                entity.Property(c => c.Descripcion).IsRequired().HasMaxLength(100);

                entity.HasMany(c => c.Planes)
                      .WithMany(p => p.Comisiones);
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Descripcion).HasMaxLength(255);

                entity.HasOne(c => c.Materia)
                      .WithMany()
                      .HasForeignKey(c => c.IdMateria);

                entity.HasOne(c => c.Comision)
                      .WithMany()
                      .HasForeignKey(c => c.IdComision);
            });
        }
    }
}