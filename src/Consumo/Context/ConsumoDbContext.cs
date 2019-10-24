using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Consumo.Context
{
    public partial class ConsumoDbContext : DbContext
    {
        public ConsumoDbContext()
        {
        }

        public ConsumoDbContext(DbContextOptions<ConsumoDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Electrodomestico> Electrodomestico { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=win2012-01;database=electro;user=root;password=Lujho12");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Electrodomestico>(entity =>
            {
                entity.HasKey(e => e.IdElectrodomestico);

                entity.ToTable("electrodomestico", "electro");

                entity.HasIndex(e => e.DniUsuario)
                    .HasName("fk_Electrodomestico_Usuario_idx");

                entity.Property(e => e.IdElectrodomestico)
                    .HasColumnName("idElectrodomestico")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DniUsuario)
                    .HasColumnName("dniUsuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.PotenciaKw).HasColumnName("potenciaKW");

                entity.HasOne(d => d.DniUsuarioNavigation)
                    .WithMany(p => p.Electrodomestico)
                    .HasForeignKey(d => d.DniUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Electrodomestico_Usuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Dni);

                entity.ToTable("usuario", "electro");

                entity.Property(e => e.Dni)
                    .HasColumnName("dni")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasColumnName("apellido")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });
        }
    }
}
