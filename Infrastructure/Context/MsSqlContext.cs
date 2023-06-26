using Microsoft.EntityFrameworkCore;
using LABCC.BackEnd.Domain.Entities.Usuarios;
using LABCC.BackEnd.Domain.ValueObjects;
using LABCC.BackEnd.Infrastructure.DbMapping;
using LABCC.BackEnd.Infrastructure.DbMapping.VO;
using LABCC.BackEnd.Domain.Entities.Colecoes;

namespace LABCC.BackEnd.Infrastructure.Context;

public class MsSqlContext : DbContext
{
  public MsSqlContext(DbContextOptions<MsSqlContext> options) : base(options)
  {

  }

  #region DB SETS
  public DbSet<Usuario> Usuarios { get; set; }
  public DbSet<Colecao> Colecoes { get; set; }

  public DbSet<Status> Status { get; set; }
  public DbSet<Genero> Generos { get; set; }
  public DbSet<TipoDeUsuario> TiposDeUsuarios { get; set; }
  #endregion

  #region MAPPINGS
  public readonly GeneroDbMapping generoMapping = new();
  public readonly StatusDbMapping statusMapping = new();
  public readonly TipoDeUsuarioDbMapping tipoDeUsuarioMapping = new();
  private readonly EstacoesDbMapping estacoesMapping = new();
  public readonly UsuariosDbMapping usuariosMapping = new();
  public readonly ColecoesDbMapping colecoesMapping = new();
  #endregion

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.HasDefaultSchema("Entity");

    #region VO Table Creation
    modelBuilder.Entity<Status>().ToTable("Status", "VO");
    modelBuilder.Entity<Genero>().ToTable("Generos", "VO");
    modelBuilder.Entity<TipoDeUsuario>().ToTable("TiposDeUsuario", "VO");
    modelBuilder.Entity<EstacoesDoAno>().ToTable("EstaçõesDoAno", "VO");
    #endregion

    #region Entity Table Creation
    modelBuilder.Entity<Usuario>().ToTable("Usuarios");
    modelBuilder.Entity<Colecao>().ToTable("Coleções");
    #endregion

    #region VO Mapping
    generoMapping.Build(modelBuilder);
    statusMapping.Build(modelBuilder);
    tipoDeUsuarioMapping.Build(modelBuilder);
    estacoesMapping.Build(modelBuilder);
    #endregion

    #region Entity Mapping
    usuariosMapping.Build(modelBuilder);
    colecoesMapping.Build(modelBuilder);
    #endregion
  }

}
