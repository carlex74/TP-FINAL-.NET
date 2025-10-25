using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Domain.Interfaces;

namespace Infrastructure.Context
{
    public class TPIContext : DbContext
    {
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Docente> Docentes { get; set; }
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Plan> Planes { get; set; }
        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Comision> Comisiones { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<AlumnoInscripcion> Inscripciones { get; set; }
        public DbSet<DocenteCurso> DocentesCurso { get; set; }

        public TPIContext(DbContextOptions<TPIContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            #region Global Query Filters for Soft Delete

            // Itera sobre todos los tipos de entidad descubiertos en el DbContext.
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // Comprueba si la entidad implementa la interfaz ISoftDeletable
                // Y ademas, comprueba que sea una clase base (no una clase derivada).
                if (typeof(ISoftDeletable).IsAssignableFrom(entityType.ClrType) && entityType.BaseType == null)
                {
                    // Aplica el filtro global de borrado logico.
                    entityType.AddSoftDeleteQueryFilter();
                }
            }

            #endregion

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

                entity.Property(u => u.Tipo)
                      .HasConversion<string>()
                      .HasMaxLength(50);

                entity.HasDiscriminator(u => u.Tipo)
                      .HasValue<Alumno>(Usuario.TipoUsuario.Alumno)
                      .HasValue<Docente>(Usuario.TipoUsuario.Docente)
                      .HasValue<Administrador>(Usuario.TipoUsuario.Administrador);

                entity.Property(u => u.ClaveHash).IsRequired();

                entity.HasOne(u => u.Persona)
                      .WithMany(p => p.Usuarios)
                      .HasForeignKey(u => u.IdPersona);
            });

            modelBuilder.Entity<Alumno>(entity =>
            {
                entity.HasOne(a => a.Plan)
                      .WithMany(p => p.Alumnos)
                      .HasForeignKey(a => a.IdPlan);
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
            modelBuilder.Entity<AlumnoInscripcion>(entity =>
            {
                entity.HasKey(c => new { c.IdCurso, c.LegajoAlumno });

                entity.Property(c => c.Condicion).HasMaxLength(255);
                entity.Property(c => c.Nota);

                entity.HasOne(c => c.Alumno)
                    .WithMany(a=>a.AlumnoInscripcions)
                    .HasForeignKey(c => c.LegajoAlumno);

                entity.HasOne(c => c.Curso)
                    .WithMany(a => a.Inscripciones)
                    .HasForeignKey(c => c.IdCurso);

            });

            modelBuilder.Entity<DocenteCurso>(entity =>
            {
                entity.HasKey(c => new { c.IdCurso, c.LegajoDocente });

                entity.Property(c => c.Cargo).HasMaxLength(255);
  

                entity.HasOne(c => c.Docente)
                    .WithMany(a => a.DocenteCursos)
                    .HasForeignKey(c => c.LegajoDocente);

                entity.HasOne(c => c.Curso)
                    .WithMany(a => a.Docentes)
                    .HasForeignKey(c => c.IdCurso);

            });

        }
    }

    public static class SoftDeleteQueryFilterExtensions
    {
        public static void AddSoftDeleteQueryFilter(
            this Microsoft.EntityFrameworkCore.Metadata.IMutableEntityType entityData)
        {
            var methodToCall = typeof(SoftDeleteQueryFilterExtensions)
                .GetMethod(nameof(GetSoftDeleteFilter),
                           System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)
                .MakeGenericMethod(entityData.ClrType);
            var filter = methodToCall.Invoke(null, new object[] { });
            entityData.SetQueryFilter((LambdaExpression)filter);
        }

        private static LambdaExpression GetSoftDeleteFilter<TEntity>()
            where TEntity : class, ISoftDeletable
        {
            Expression<Func<TEntity, bool>> filter = x => !x.IsDeleted;
            return filter;
        }
    }
}