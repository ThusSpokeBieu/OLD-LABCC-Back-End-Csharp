using LABCC.BackEnd.Domain.Enum;
using LABCC.BackEnd.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace LABCC.BackEnd.Infrastructure.DbMapping;

public class TipoDeUsuarioDbMapping
{
  public void Build(ModelBuilder builder)
  {
    builder.Entity<TipoDeUsuario>()
      .HasKey(t => t.Id);

    builder.Entity<TipoDeUsuario>()
      .Property(t => t.Sigla)
      .HasColumnOrder(1)
      .HasComment("É a sigla que representa o tipo de usuário.")
      .HasColumnType("varchar(18)")
      .IsRequired(true);

    builder.Entity<TipoDeUsuario>()
      .Property(t => t.Value)
      .HasColumnOrder(2)
      .HasComment("É o nome do tipo de usuário.")
      .HasColumnType("varchar(18)")
      .HasMaxLength(18)
      .IsRequired(true);

    builder.Entity<TipoDeUsuario>()
      .HasIndex(t => t.Value)
      .IsUnique();

    builder.Entity<TipoDeUsuario>()
      .HasIndex(t => t.Sigla)
      .IsUnique();

    Seed(builder);
  }

  public void Seed(ModelBuilder modelBuilder)
  {
    var tiposDeUsuarios = new TipoDeUsuario[]
    {
      new TipoDeUsuario
      {
        Id = (byte) TipoDeUsuarioEnum.ADMINISTRADOR,
        Sigla = "ADM",
        Value = "Administrador"
      },
      new TipoDeUsuario
      {
        Id = (byte) TipoDeUsuarioEnum.GERENTE,
        Sigla = "GRT",
        Value = "Gerente",
      },
      new TipoDeUsuario
      {
        Id = (byte) TipoDeUsuarioEnum.CRIADOR,
        Sigla = "CRD",
        Value = "Criador"
      },
      new TipoDeUsuario
      {
        Id = (byte) TipoDeUsuarioEnum.OUTRO,
        Sigla = "OTR",
        Value = "Outro"
      }
    };

    foreach (var tipoDeUsuario in tiposDeUsuarios) modelBuilder.Entity<TipoDeUsuario>()
        .HasData(tipoDeUsuario);

  }
}