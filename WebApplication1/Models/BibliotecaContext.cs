using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

public partial class BibliotecaContext : DbContext
{
    public BibliotecaContext()
    {
    }

    public BibliotecaContext(DbContextOptions<BibliotecaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Libro> Libros { get; set; }

    public virtual DbSet<Personaje> Personajes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source= Obligatorio ;Initial Catalog= Biblioteca;Integrated Security=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.LibId).HasName("PK__Libros__4151D0F3DAC591AF");

            entity.Property(e => e.LibId).HasColumnName("Lib_Id");
            entity.Property(e => e.LibAutor)
                .HasMaxLength(255)
                .HasColumnName("Lib_Autor");
            entity.Property(e => e.LibGenero)
                .HasMaxLength(100)
                .HasColumnName("Lib_Genero");
            entity.Property(e => e.LibNombre)
                .HasMaxLength(255)
                .HasColumnName("Lib_Nombre");
            entity.Property(e => e.LibStatus)
                .HasMaxLength(50)
                .HasColumnName("Lib_Status");
            entity.Property(e => e.LibTipoProyecto)
                .HasMaxLength(100)
                .HasColumnName("Lib_TipoProyecto");
        });

        modelBuilder.Entity<Personaje>(entity =>
        {
            entity.HasKey(e => e.PerId).HasName("PK__Personaj__2705F94019513D8F");

            entity.Property(e => e.PerId).HasColumnName("Per_Id");
            entity.Property(e => e.PerApellido)
                .HasMaxLength(255)
                .HasColumnName("Per_Apellido");
            entity.Property(e => e.PerDescripcion).HasColumnName("Per_Descripcion");
            entity.Property(e => e.PerFechaNacimiento).HasColumnName("Per_FechaNacimiento");
            entity.Property(e => e.PerLibId).HasColumnName("Per_LibId");
            entity.Property(e => e.PerLugarNacimiento)
                .HasMaxLength(255)
                .HasColumnName("Per_LugarNacimiento");
            entity.Property(e => e.PerNombre)
                .HasMaxLength(255)
                .HasColumnName("Per_Nombre");
            entity.Property(e => e.PerRolId).HasColumnName("Per_RolId");
            entity.Property(e => e.PerStatus)
                .HasMaxLength(50)
                .HasColumnName("Per_Status");

            entity.HasOne(d => d.PerLib).WithMany(p => p.Personajes)
                .HasForeignKey(d => d.PerLibId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Personaje__Per_L__3B75D760");

            entity.HasOne(d => d.PerRol).WithMany(p => p.Personajes)
                .HasForeignKey(d => d.PerRolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Personaje__Per_R__3C69FB99");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RolId).HasName("PK__Roles__795EBD496C4C4B9A");

            entity.Property(e => e.RolId).HasColumnName("Rol_Id");
            entity.Property(e => e.RolDescripcion)
                .HasMaxLength(255)
                .HasColumnName("Rol_Descripcion");
            entity.Property(e => e.RolStatus)
                .HasMaxLength(50)
                .HasColumnName("Rol_Status");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
