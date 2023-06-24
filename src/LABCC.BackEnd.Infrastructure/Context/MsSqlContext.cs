using Microsoft.EntityFrameworkCore;
using LABCC.BackEnd.Domain.Entities.Usuarios;
using LABCC.BackEnd.Domain.ValueObjects;
using LABCC.BackEnd.Infrastructure.DbMapping;

namespace LABCC.BackEnd.Infrastructure.Context;

public class MsSqlContext : DbContext
{
  public MsSqlContext(DbContextOptions<MsSqlContext> options) : base(options)
  {

  }

  public DbSet<Usuario> Usuarios { get; set; }
  public DbSet<Status> Status { get; set; }
  public DbSet<Genero> Generos { get; set; }
  public DbSet<TipoDeUsuario> TiposDeUsuarios { get; set; }

  public readonly GeneroDbMapping generoMapping = new();
  public readonly StatusDbMapping statusMapping = new();
  public readonly TipoDeUsuarioDbMapping tipoDeUsuarioMapping = new();
  public readonly UsuariosDbMapping usuariosMapping = new();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.HasDefaultSchema("Entity");
    modelBuilder.Entity<Status>().ToTable("Status", "VO");
    modelBuilder.Entity<Genero>().ToTable("Generos", "VO");
    modelBuilder.Entity<TipoDeUsuario>().ToTable("TiposDeUsuario", "VO");

    modelBuilder.Entity<Usuario>().ToTable("Usuarios");

    generoMapping.Build(modelBuilder);
    statusMapping.Build(modelBuilder);
    tipoDeUsuarioMapping.Build(modelBuilder);

    usuariosMapping.Build(modelBuilder);
  }

}
