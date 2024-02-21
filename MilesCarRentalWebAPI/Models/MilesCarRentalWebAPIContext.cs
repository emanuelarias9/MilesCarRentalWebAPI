using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MilesCarRentalWebAPI.Models
{
    public partial class MilesCarRentalWebAPIContext : DbContext
    {
        public MilesCarRentalWebAPIContext()
        {
        }

        public MilesCarRentalWebAPIContext(DbContextOptions<MilesCarRentalWebAPIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TipoVehiculo> TipoVehiculos { get; set; } = null!;
        public virtual DbSet<Vehiculo> Vehiculos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoVehiculo>(entity =>
            {
                entity.ToTable("TipoVehiculo");

                entity.Property(e => e.TipoVehiculoNombre).IsUnicode(false);
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.ToTable("Vehiculo");

                entity.Property(e => e.LocalidadDevolucion).IsUnicode(false);

                entity.Property(e => e.LocalidadRecogida).IsUnicode(false);

                entity.Property(e => e.VehiculoNombre).IsUnicode(false);

                entity.Property(e => e.VehiculoPrecio).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.TipoVehiculo)
                    .WithMany(p => p.Vehiculos)
                    .HasForeignKey(d => d.TipoVehiculoId)
                    .HasConstraintName("FK_Vehiculo_TipoVehiculo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
