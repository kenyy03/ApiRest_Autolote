using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.DbModels
{
    public partial class DB_Context : DbContext
    {
        public DB_Context()
        {
        }

        public DB_Context(DbContextOptions<DB_Context> options)
            : base(options)
        {
        }

        public virtual DbSet<TAgente> TAgente { get; set; }
        public virtual DbSet<TAuto> TAuto { get; set; }
        public virtual DbSet<TBase> TBase { get; set; }
        public virtual DbSet<TCliente> TCliente { get; set; }
        public virtual DbSet<TMecanico> TMecanico { get; set; }
        public virtual DbSet<TOrden> TOrden { get; set; }
        public virtual DbSet<TReparacion> TReparacion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=KEN\\SQLEXPRESS;Database=Autolote; persist security info=True; Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TAgente>(entity =>
            {
                entity.HasKey(e => e.IdAgente);

                entity.ToTable("t_Agente");

                entity.Property(e => e.IdAgente).HasColumnName("idAgente");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdBase).HasColumnName("idBase");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroTelefono)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Salario).HasColumnType("numeric(18, 2)");

                entity.HasOne(d => d.IdBaseNavigation)
                    .WithMany(p => p.TAgente)
                    .HasForeignKey(d => d.IdBase)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__t_Agente__idBase__68487DD7");
            });

            modelBuilder.Entity<TAuto>(entity =>
            {
                entity.HasKey(e => e.IdAuto);

                entity.ToTable("t_Auto");

                entity.Property(e => e.IdAuto).HasColumnName("idAuto");

                entity.Property(e => e.Categoria)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdBase).HasColumnName("idBase");

                entity.Property(e => e.Marca)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Modelo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroRegistro)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrecioRenta).HasColumnType("numeric(18, 2)");

                entity.HasOne(d => d.IdBaseNavigation)
                    .WithMany(p => p.TAuto)
                    .HasForeignKey(d => d.IdBase)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__t_Auto__idBase__693CA210");
            });

            modelBuilder.Entity<TBase>(entity =>
            {
                entity.HasKey(e => e.IdBase);

                entity.ToTable("t_Base");

                entity.Property(e => e.IdBase).HasColumnName("idBase");

                entity.Property(e => e.Ciudad)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Departamento)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion).IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroTelefono)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TCliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente);

                entity.ToTable("t_Cliente");

                entity.Property(e => e.IdCliente)
                    .HasColumnName("idCliente")
                    .HasComment("Llave primaria de cliente.");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion).IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroTelefono)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TMecanico>(entity =>
            {
                entity.HasKey(e => e.IdMecanico);

                entity.ToTable("t_Mecanico");

                entity.Property(e => e.IdMecanico).HasColumnName("idMecanico");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaContratacion).HasColumnType("date");

                entity.Property(e => e.IdBase).HasColumnName("idBase");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroTelefono)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Salario).HasColumnType("numeric(18, 2)");

                entity.HasOne(d => d.IdBaseNavigation)
                    .WithMany(p => p.TMecanico)
                    .HasForeignKey(d => d.IdBase)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__t_Mecanic__idBas__6A30C649");
            });

            modelBuilder.Entity<TOrden>(entity =>
            {
                entity.HasKey(e => e.IdOrden);

                entity.ToTable("t_Orden");

                entity.Property(e => e.IdOrden).HasColumnName("idOrden");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.FechaCancelacion).HasColumnType("date");

                entity.Property(e => e.IdAuto).HasColumnName("idAuto");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.RentaFechaFin).HasColumnType("date");

                entity.Property(e => e.RentaFechaInicio).HasColumnType("date");

                entity.HasOne(d => d.IdAutoNavigation)
                    .WithMany(p => p.TOrden)
                    .HasForeignKey(d => d.IdAuto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__t_Orden__idAuto__6B24EA82");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.TOrden)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__t_Orden__idClien__6C190EBB");
            });

            modelBuilder.Entity<TReparacion>(entity =>
            {
                entity.HasKey(e => e.IdReparacion);

                entity.ToTable("t_Reparacion");

                entity.Property(e => e.IdReparacion).HasColumnName("idReparacion");

                entity.Property(e => e.Costo).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.IdAuto).HasColumnName("idAuto");

                entity.Property(e => e.IdMecanico).HasColumnName("idMecanico");

                entity.HasOne(d => d.IdAutoNavigation)
                    .WithMany(p => p.TReparacion)
                    .HasForeignKey(d => d.IdAuto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__t_Reparac__idAut__6D0D32F4");

                entity.HasOne(d => d.IdMecanicoNavigation)
                    .WithMany(p => p.TReparacion)
                    .HasForeignKey(d => d.IdMecanico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__t_Reparac__idMec__6E01572D");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
