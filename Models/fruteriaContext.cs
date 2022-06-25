using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Fruteria_Team.Models
{
    public partial class fruteriaContext : DbContext
    {
        public fruteriaContext()
        {
        }

        public fruteriaContext(DbContextOptions<fruteriaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comisiones> Comisiones { get; set; }
        public virtual DbSet<Estadocivil> Estadocivil { get; set; }
        public virtual DbSet<Grupos> Grupos { get; set; }
        public virtual DbSet<Poblacion> Poblacion { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<Vendedores> Vendedores { get; set; }
        public virtual DbSet<Ventas> Ventas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;database=fruteria;password=1234;user=root", x => x.ServerVersion("8.0.28-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comisiones>(entity =>
            {
                entity.HasKey(e => e.IdComision)
                    .HasName("PRIMARY");

                entity.ToTable("comisiones");

                entity.HasIndex(e => e.Idvendedor)
                    .HasName("fkComisionVendedor");

                entity.Property(e => e.IdComision).HasColumnName("idComision");

                entity.Property(e => e.Comision)
                    .HasColumnName("comision")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("date");

                entity.Property(e => e.Idvendedor).HasColumnName("idvendedor");

                entity.HasOne(d => d.IdvendedorNavigation)
                    .WithMany(p => p.Comisiones)
                    .HasForeignKey(d => d.Idvendedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkComisionVendedor");
            });

            modelBuilder.Entity<Estadocivil>(entity =>
            {
                entity.ToTable("estadocivil");

                entity.Property(e => e.EstadoCivil1)
                    .IsRequired()
                    .HasColumnName("Estado_Civil")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Grupos>(entity =>
            {
                entity.HasKey(e => e.IdGrupo)
                    .HasName("PRIMARY");

                entity.ToTable("grupos");

                entity.HasIndex(e => e.NombreGrupo)
                    .HasName("NombreGrupo");

                entity.Property(e => e.NombreGrupo)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<Poblacion>(entity =>
            {
                entity.ToTable("poblacion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Productos>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PRIMARY");

                entity.ToTable("productos");

                entity.HasIndex(e => e.IdGrupo)
                    .HasName("IdGrupo");

                entity.HasIndex(e => e.IdProducto)
                    .HasName("IdProducto");

                entity.Property(e => e.NomProducto)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Precio).HasColumnType("decimal(19,4)");

                entity.HasOne(d => d.IdGrupoNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdGrupo)
                    .HasConstraintName("fkProductosGrupos");
            });

            modelBuilder.Entity<Vendedores>(entity =>
            {
                entity.HasKey(e => e.IdVendedor)
                    .HasName("PRIMARY");

                entity.ToTable("vendedores");

                entity.HasIndex(e => e.EstalCivil)
                    .HasName("fk_estcivil_idx");

                entity.HasIndex(e => e.IdVendedor)
                    .HasName("IdVendedor");

                entity.HasIndex(e => e.Poblacion)
                    .HasName("fk_pob_idx");

                entity.Property(e => e.CodPostal)
                    .IsRequired()
                    .HasColumnType("varchar(5)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.FechaAlta).HasColumnType("datetime");

                entity.Property(e => e.FechaNac).HasColumnType("datetime");

                entity.Property(e => e.Nif)
                    .IsRequired()
                    .HasColumnName("NIF")
                    .HasColumnType("varchar(9)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.NombreVendedor)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Telefon)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.HasOne(d => d.EstalCivilNavigation)
                    .WithMany(p => p.Vendedores)
                    .HasForeignKey(d => d.EstalCivil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_estcivil");

                entity.HasOne(d => d.PoblacionNavigation)
                    .WithMany(p => p.Vendedores)
                    .HasForeignKey(d => d.Poblacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pob");
            });

            modelBuilder.Entity<Ventas>(entity =>
            {
                entity.HasKey(e => e.Idventa)
                    .HasName("PRIMARY");

                entity.ToTable("ventas");

                entity.HasIndex(e => e.CodProducto)
                    .HasName("fkVentasProducto_idx");

                entity.HasIndex(e => e.CodVendedor)
                    .HasName("VendedoresVentas");

                entity.Property(e => e.Idventa).HasColumnName("idventa");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Kilos).HasColumnType("double(15,2)");

                entity.HasOne(d => d.CodProductoNavigation)
                    .WithMany(p => p.Ventas)
                    .HasForeignKey(d => d.CodProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkVentasProducto");

                entity.HasOne(d => d.CodVendedorNavigation)
                    .WithMany(p => p.Ventas)
                    .HasForeignKey(d => d.CodVendedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkVentasVendedor");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
