using LABCC.BackEnd.Domain.Enum;
using LABCC.BackEnd.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace LABCC.BackEnd.Infrastructure.DbMapping.VO;

public class EstacoesDbMapping
{
    public void Build(ModelBuilder builder)
    {
        builder.Entity<EstacoesDoAno>().HasKey(e => e.Id);

        builder
            .Entity<EstacoesDoAno>()
            .Property(e => e.Value)
            .HasColumnOrder(2)
            .HasComment("É o nome da estação.")
            .HasColumnType("varchar(18)")
            .HasMaxLength(18)
            .IsRequired(true);

        builder
            .Entity<EstacoesDoAno>()
            .Property(e => e.EnglishValue)
            .HasColumnOrder(3)
            .HasComment("É a tradução em inglês para a estação.")
            .HasColumnType("varchar(18)")
            .IsRequired(true);

        builder.Entity<EstacoesDoAno>().HasIndex(e => e.Value).IsUnique();

        builder.Entity<EstacoesDoAno>().HasIndex(e => e.EnglishValue).IsUnique();

        Seed(builder);
    }

    public void Seed(ModelBuilder modelBuilder)
    {
        var estacoes = new EstacoesDoAno[]
        {
            new EstacoesDoAno
            {
                Id = (byte)EstacoesEnum.PRIMAVERA,
                Value = "Primavera",
                EnglishValue = "Spring"
            },
            new EstacoesDoAno
            {
                Id = (byte)EstacoesEnum.VERÃO,
                Value = "Verão",
                EnglishValue = "Summer"
            },
            new EstacoesDoAno
            {
                Id = (byte)EstacoesEnum.OUTONO,
                Value = "Outono",
                EnglishValue = "Autumn"
            },
            new EstacoesDoAno
            {
                Id = (byte)EstacoesEnum.INVERNO,
                Value = "Inverno",
                EnglishValue = "Winter"
            }
        };

        foreach (var estacao in estacoes)
            modelBuilder.Entity<EstacoesDoAno>().HasData(estacao);
    }
}
