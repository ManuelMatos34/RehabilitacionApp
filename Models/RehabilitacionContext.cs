using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FisioTerapias.Models;

public partial class RehabilitacionContext : DbContext
{
    public RehabilitacionContext()
    {
    }

    public RehabilitacionContext(DbContextOptions<RehabilitacionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Especialidade> Especialidades { get; set; }

    public virtual DbSet<EstadoPaciente> EstadoPacientes { get; set; }

    public virtual DbSet<EstadoTerapia> EstadoTerapias { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Seguimiento> Seguimientos { get; set; }

    public virtual DbSet<Terapia> Terapias { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=Rehabilitacion;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__Empleado__CE6D8B9EA16831E9");

            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Cedula)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEspecialidadNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdEspecialidad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmpleadosEspecialidad");
        });

        modelBuilder.Entity<Especialidade>(entity =>
        {
            entity.HasKey(e => e.IdEspecialidad).HasName("PK__Especial__693FA0AF103EE524");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EstadoPaciente>(entity =>
        {
            entity.HasKey(e => e.IdEstadoPaciente).HasName("PK__EstadoPa__7C2B10DFDF4CA628");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EstadoTerapia>(entity =>
        {
            entity.HasKey(e => e.IdEstadoTerapia).HasName("PK__EstadoTe__4705E646644FB399");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.IdPaciente).HasName("PK__Paciente__C93DB49B603D26B0");

            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Cedula)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.Dirección)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Roles__2A49584CDC040FA4");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Seguimiento>(entity =>
        {
            entity.HasKey(e => e.IdSeguimiento).HasName("PK__Seguimie__5643F60F22990F0A");

            entity.HasIndex(e => new { e.FechaSeguimiento, e.IdTerapia }, "IDX_Seguimiento_1").IsUnique();

            entity.Property(e => e.Observaciones)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.Sensacion)
                .HasMaxLength(2000)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEstadoPacienteNavigation).WithMany(p => p.Seguimientos)
                .HasForeignKey(d => d.IdEstadoPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Seguimientos_EstadoPacientes");

            entity.HasOne(d => d.IdTerapiaNavigation).WithMany(p => p.Seguimientos)
                .HasForeignKey(d => d.IdTerapia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Seguimientos_Terapias");
        });

        modelBuilder.Entity<Terapia>(entity =>
        {
            entity.HasKey(e => e.IdTerapia).HasName("PK__Terapias__EC02E57CCAFB678A");

            entity.Property(e => e.Diagnostico)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Historial)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.NecesidadDelPaciente)
                .HasMaxLength(300)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Terapia)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Terapias_Empleados");

            entity.HasOne(d => d.IdEstadoTerapiaNavigation).WithMany(p => p.Terapia)
                .HasForeignKey(d => d.IdEstadoTerapia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Terapias_EstadoTerapia");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.Terapia)
                .HasForeignKey(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Terapias_Pacientes");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__5B65BF974CFEA110");

            entity.Property(e => e.Clave)
                .HasMaxLength(18)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Usuario1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Usuario");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuarios_Empleados");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuarios_Roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
