using LABCC.BackEnd.Domain.Entities.Colecoes;
using LABCC.BackEnd.Domain.Enum;
using Microsoft.EntityFrameworkCore;

namespace LABCC.BackEnd.Infrastructure.DbMapping;

public class ColecoesDbMapping
{
    public void Build(ModelBuilder builder)
    {
        builder.Entity<Colecao>().HasKey(c => c.Id);

        builder
            .Entity<Colecao>()
            .Property(c => c.Id)
            .HasColumnOrder(0)
            .HasComment("Identificador da coleção")
            .IsConcurrencyToken(true)
            .IsRequired(true);

        builder
            .Entity<Colecao>()
            .Property(c => c.NomeDaColecao)
            .HasColumnOrder(1)
            .HasComment("É o nome da coleção.")
            .HasColumnType("varchar(30)")
            .HasMaxLength(30)
            .IsRequired(true);

        builder.Entity<Colecao>().HasIndex(c => c.NomeDaColecao).IsUnique();

        builder
            .Entity<Colecao>()
            .HasOne(c => c.Responsavel)
            .WithMany()
            .HasForeignKey(c => c.ResponsavelId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .Entity<Colecao>()
            .Property(c => c.ResponsavelId)
            .HasColumnOrder(2)
            .HasComment("É o Identificador do responsável da coleção")
            .IsRequired();

        builder
            .Entity<Colecao>()
            .Property(c => c.Marca)
            .HasColumnOrder(3)
            .HasComment("É a marca que para qual essa coleção será feita")
            .HasColumnType("varchar(30)")
            .HasMaxLength(30)
            .IsRequired(true);

        builder.Entity<Colecao>().HasOne(c => c.Estacao).WithMany().HasForeignKey(c => c.EstacaoId);

        builder
            .Entity<Colecao>()
            .Property(c => c.EstacaoId)
            .HasColumnOrder(4)
            .HasComment(
                "É o Identificador da estação da coleção: 1 - Primavera, 2 - Verão, 3 - Outono, 4 - Inverno"
            )
            .IsRequired();

        builder
            .Entity<Colecao>()
            .Property(c => c.AnoDeLancamento)
            .HasColumnOrder(5)
            .HasComment("É o ano de lançamento da coleção")
            .HasColumnType("int");

        builder
            .Entity<Colecao>()
            .Property(c => c.Orcamento)
            .HasColumnOrder(6)
            .HasComment("Orçamento da coleção em R$")
            .HasColumnType("money")
            .IsRequired();

        builder
            .Entity<Colecao>()
            .Property(c => c.AtualizadoEm)
            .HasColumnOrder(7)
            .HasComment("Momento em que a coleção foi atualizada")
            .HasColumnType("datetimeoffset")
            .ValueGeneratedOnAddOrUpdate()
            .HasDefaultValueSql("SYSUTCDATETIME()")
            .IsRequired();

        builder
            .Entity<Colecao>()
            .Property(c => c.CriadoEm)
            .HasColumnOrder(8)
            .HasComment("Momento em que a coleção foi atualizada")
            .HasColumnType("datetimeoffset")
            .ValueGeneratedOnAddOrUpdate()
            .HasDefaultValueSql("SYSUTCDATETIME()")
            .IsRequired();

        builder.Entity<Colecao>().HasOne(c => c.Status).WithMany().HasForeignKey(c => c.StatusId);

        builder
            .Entity<Colecao>()
            .Property(c => c.StatusId)
            .HasColumnOrder(10)
            .HasComment("Status da coleção: 0 - Inativo, 1 - Ativo");

        Seed(builder);
    }

    public void Seed(ModelBuilder modelBuilder)
    {
        var random = new Random();

        Colecao[] colecoes = new Colecao[]
        {
            new Colecao
            {
                Id = 1,
                NomeDaColecao = "LABFashion Coast",
                Marca = "Solstice Couture",
                EstacaoId = (byte)EstacoesEnum.VERÃO,
                ResponsavelId = (long)random.Next(1, 5),
                Orcamento = (decimal)random.Next(100000, 1000000),
                AnoDeLancamento = random.Next(2022, 2028)
            },
            new Colecao
            {
                Id = 2,
                NomeDaColecao = "Midnight Elegance",
                Marca = "Aurora Vogue",
                EstacaoId = (byte)EstacoesEnum.INVERNO,
                ResponsavelId = (long)random.Next(1, 5),
                Orcamento = (decimal)random.Next(100000, 1000000),
                AnoDeLancamento = random.Next(2022, 2028)
            },
            new Colecao
            {
                Id = 3,
                NomeDaColecao = "Mythical Glam",
                Marca = "Aphrodite Designs",
                EstacaoId = (byte)EstacoesEnum.PRIMAVERA,
                ResponsavelId = (long)random.Next(1, 5),
                Orcamento = (decimal)random.Next(100000, 1000000),
                AnoDeLancamento = random.Next(2022, 2028)
            },
            new Colecao
            {
                Id = 4,
                NomeDaColecao = "Celestial Chic",
                Marca = "Celestia Fashion House",
                EstacaoId = (byte)EstacoesEnum.OUTONO,
                ResponsavelId = (long)random.Next(1, 5),
                Orcamento = (decimal)random.Next(100000, 1000000),
                AnoDeLancamento = random.Next(2022, 2028)
            },
            new Colecao
            {
                Id = 5,
                NomeDaColecao = "Radiant Reflections",
                Marca = "Sterling Runway",
                EstacaoId = (byte)EstacoesEnum.VERÃO,
                ResponsavelId = (long)random.Next(1, 5),
                Orcamento = (decimal)random.Next(100000, 1000000),
                AnoDeLancamento = random.Next(2022, 2028)
            },
            new Colecao
            {
                Id = 6,
                NomeDaColecao = "Coastal Breeze",
                Marca = "Solstice Couture",
                EstacaoId = (byte)EstacoesEnum.VERÃO,
                ResponsavelId = (long)random.Next(1, 5),
                Orcamento = (decimal)random.Next(100000, 1000000),
                AnoDeLancamento = random.Next(2022, 2028)
            },
            new Colecao
            {
                Id = 7,
                NomeDaColecao = "Enchanted Forest",
                Marca = "Aurora Vogue",
                EstacaoId = (byte)EstacoesEnum.PRIMAVERA,
                ResponsavelId = (long)random.Next(1, 5),
                Orcamento = (decimal)random.Next(100000, 1000000),
                AnoDeLancamento = random.Next(2022, 2028)
            }
        };

        foreach (Colecao colecao in colecoes)
            modelBuilder.Entity<Colecao>().HasData(colecao);
    }
}
