using Microsoft.EntityFrameworkCore;
using escuela.Domain;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Project.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Padre> Padres { get; set; }
        public DbSet<Escuela> Escuelas { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumno>()
                .HasOne(a => a.Padre)
                .WithMany(p => p.HijosComoPadre)
                .HasForeignKey(a => a.PadreId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Alumno>()
                .HasOne(a => a.Madre)
                .WithMany(p => p.HijosComoMadre)
                .HasForeignKey(a => a.MadreId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Alumno>()
                .HasOne(a => a.Escuela)
                .WithMany(e => e.Alumnos)
                .HasForeignKey(a => a.EscuelaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}