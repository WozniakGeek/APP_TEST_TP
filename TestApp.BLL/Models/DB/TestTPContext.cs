using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TestAppTP.Models.DB
{
    public partial class TestTPContext : DbContext
    {
        public TestTPContext()
        {
        }

        public TestTPContext(DbContextOptions<TestTPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EstudiantePromedio> EstudiantePromedio { get; set; }
        public virtual DbSet<NotasEstudiante> NotasEstudiante { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=192.168.146.21;Database=TestTP;Trusted_Connection=False;User ID=rgaona;Password=XRxotASy1RF3SQ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<EstudiantePromedio>(entity =>
            {
                entity.Property(e => e.PromedioNotas).IsUnicode(false);
            });

            modelBuilder.Entity<NotasEstudiante>(entity =>
            {
                entity.Property(e => e.Apellidos).IsUnicode(false);

                entity.Property(e => e.Documento).IsUnicode(false);

                entity.Property(e => e.Nombres).IsUnicode(false);

                entity.Property(e => e.Nota1).IsUnicode(false);

                entity.Property(e => e.Nota2).IsUnicode(false);

                entity.Property(e => e.Nota3).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
