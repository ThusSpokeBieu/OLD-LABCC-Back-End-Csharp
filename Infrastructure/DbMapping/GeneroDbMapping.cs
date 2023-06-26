using LABCC.BackEnd.Domain.Enum;
using LABCC.BackEnd.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace LABCC.BackEnd.Infrastructure.DbMapping;

public class GeneroDbMapping
{
  public void Build(ModelBuilder builder)
  {
    builder.Entity<Genero>()
      .HasKey(g => g.Id);

    builder.Entity<Genero>()
      .Property(g => g.Value)
      .HasColumnOrder(2)
      .HasComment("É o nome do gênero.")
      .HasColumnType("varchar(18)")
      .HasMaxLength(18)
      .IsRequired(true);

    builder.Entity<Genero>()
      .Property(g => g.Letter)
      .HasColumnOrder(1)
      .HasComment("É a letra que representa o gênero.")
      .HasColumnType("char")
      .IsRequired(true);

    builder.Entity<Genero>()
      .HasIndex(g => g.Value)
      .IsUnique();

    builder.Entity<Genero>()
      .HasIndex(g => g.Letter)
      .IsUnique();

    Seed(builder);

  }
  public void Seed(ModelBuilder modelBuilder)
  {
    var generos = new Genero[]
    {
      new Genero
      {
        Id = (byte) GeneroEnum.MASCULINO,
        Letter = 'M',
        Value = "Masculino"
      },
      new Genero
      {
        Id = (byte) GeneroEnum.FEMININO,
        Letter = 'F',
        Value = "Feminino",
      },
      new Genero
      {
        Id = (byte) GeneroEnum.OUTRO,
        Letter = 'O',
        Value = "Outro"
      }
    };

    foreach (var genero in generos) modelBuilder.Entity<Genero>().HasData(genero);

  }
}