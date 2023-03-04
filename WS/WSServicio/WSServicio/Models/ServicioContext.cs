using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WSServicio.Models;

public partial class ServicioContext : DbContext
{
    public ServicioContext()
    {
    }

    public ServicioContext(DbContextOptions<ServicioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Detalle> Detalles { get; set; }

    public virtual DbSet<Equipo> Equipos { get; set; }

    public virtual DbSet<Orden> Ordens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\JT;Database=Servicio;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.ToTable("cliente");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Empresa)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("empresa");
            entity.Property(e => e.Nombre)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono).HasColumnName("telefono");
        });

        modelBuilder.Entity<Detalle>(entity =>
        {
            entity.ToTable("detalle");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cables).HasColumnName("cables");
            entity.Property(e => e.Cantidad)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("cantidad");
            entity.Property(e => e.Diagnostico)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("diagnostico");
            entity.Property(e => e.Estado)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.Falla)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("falla");
            entity.Property(e => e.FechaEntrega)
                .HasColumnType("datetime")
                .HasColumnName("fechaEntrega");
            entity.Property(e => e.IdEquipo).HasColumnName("id_equipo");
            entity.Property(e => e.IdOrden).HasColumnName("id_orden");
            entity.Property(e => e.Notas)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("notas");
            entity.Property(e => e.QuienEntrega)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("quienEntrega");
            entity.Property(e => e.Reparacion)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("reparacion");
            entity.Property(e => e.Tecnico)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("tecnico");

            entity.HasOne(d => d.IdEquipoNavigation).WithMany(p => p.Detalles)
                .HasForeignKey(d => d.IdEquipo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_detalle_equipo");

            entity.HasOne(d => d.IdOrdenNavigation).WithMany(p => p.Detalles)
                .HasForeignKey(d => d.IdOrden)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_detalle_orden");
        });

        modelBuilder.Entity<Equipo>(entity =>
        {
            entity.ToTable("equipo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.Modelo)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("modelo");
            entity.Property(e => e.Serial)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("serial");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Equipos)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_equipo_cliente");
        });

        modelBuilder.Entity<Orden>(entity =>
        {
            entity.ToTable("orden");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.FechaEntrega)
                .HasColumnType("datetime")
                .HasColumnName("fechaEntrega");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.QuienEntrega)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("quienEntrega");
            entity.Property(e => e.QuienRecibe)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("quienRecibe");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("total");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Ordens)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_orden_cliente");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
