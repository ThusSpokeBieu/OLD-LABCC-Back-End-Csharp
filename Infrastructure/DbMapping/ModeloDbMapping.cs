using LABCC.BackEnd.Domain.Entities.Colecoes;
using LABCC.BackEnd.Domain.Entities.Modelos;
using LABCC.BackEnd.Domain.Enum;
using Microsoft.EntityFrameworkCore;

namespace LABCC.BackEnd.Infrastructure.DbMapping;

public class ModeloDbMapping
{
  public void Build(ModelBuilder builder)
  {

    builder.Entity<Modelo>()
      .HasKey(m => m.Id);

    builder.Entity<Modelo>()
      .Property(m => m.Id)
      .HasColumnOrder(0)
      .HasComment("Identificador do modelo")
      .IsConcurrencyToken(true)
      .IsRequired(true);

    builder.Entity<Modelo>()
      .Property(m => m.NomeDoModelo)
      .HasColumnOrder(1)
      .HasComment("É o nome do modelo.")
      .HasColumnType("varchar(50)")
      .HasMaxLength(50)
      .IsRequired(true);

    builder.Entity<Modelo>()
      .HasIndex(m => m.NomeDoModelo)
      .IsUnique();

    builder.Entity<Modelo>()
      .HasOne(m => m.Colecao)
      .WithMany()
      .HasForeignKey(m => m.ColecaoId);

    builder.Entity<Modelo>()
      .HasOne(m => m.Layout)
      .WithMany()
      .HasForeignKey(m => m.LayoutId);

    builder.Entity<Modelo>()
      .HasOne(m => m.TipoDeModelo)
      .WithMany()
      .HasForeignKey(m => m.TipoDeModeloId);

    builder.Entity<Modelo>()
      .Property(m => m.AtualizadoEm)
      .HasComment("Momento em que a coleção foi atualizada")
      .HasColumnType("datetimeoffset")
      .ValueGeneratedOnAddOrUpdate()
      .HasDefaultValueSql("SYSUTCDATETIME()")
      .IsRequired();

    builder.Entity<Modelo>()
      .Property(m => m.CriadoEm)
      .HasComment("Momento em que a coleção foi atualizada")
      .HasColumnType("datetimeoffset")
      .ValueGeneratedOnAddOrUpdate()
      .HasDefaultValueSql("SYSUTCDATETIME()")
      .IsRequired();

    builder.Entity<Modelo>()
      .HasOne(m => m.Status)
      .WithMany()
      .HasForeignKey(c => c.StatusId)
      .OnDelete(DeleteBehavior.NoAction);

    builder.Entity<Modelo>()
      .Property(m => m.StatusId)
      .HasComment("Status do Modeole: 0 - Inativo, 1 - Ativo");

    Seed(builder);
  }

  public void Seed(ModelBuilder modelBuilder)
  {
    var random = new Random();

    Modelo[] modelos = new Modelo[]
    {
        new Modelo
        {
            Id = 1,
            NomeDoModelo = "Jeans Skinny",
            ColecaoId = 1,
            LayoutId = (byte)ModeloLayoutEnum.ESTAMPA,
            TipoDeModeloId = (byte)TipoDeModeloEnum.BERMUDA,
            StatusId = (byte)StatusEnum.ATIVO
        },
        new Modelo
        {
            Id = 2,
            NomeDoModelo = "Biquíni Tropical",
            ColecaoId = 1,
            LayoutId = (byte)ModeloLayoutEnum.BORDADO,
            TipoDeModeloId = (byte)TipoDeModeloEnum.BIQUINI,
            StatusId = (byte)StatusEnum.ATIVO
        },
        new Modelo
        {
            Id = 3,
            NomeDoModelo = "Bolsa Tote Elegante",
            ColecaoId = 2,
            LayoutId = (byte)ModeloLayoutEnum.LISO,
            TipoDeModeloId = (byte)TipoDeModeloEnum.BOLSA,
            StatusId = (byte)StatusEnum.ATIVO
        },
        new Modelo
        {
            Id = 4,
            NomeDoModelo = "Boné Esportivo",
            ColecaoId = 3,
            LayoutId = (byte)ModeloLayoutEnum.ESTAMPA,
            TipoDeModeloId = (byte)TipoDeModeloEnum.BONÉ,
            StatusId = (byte)StatusEnum.ATIVO
        },
        new Modelo
        {
            Id = 5,
            NomeDoModelo = "Calça Jeans Bootcut",
            ColecaoId = 2,
            LayoutId = (byte)ModeloLayoutEnum.BORDADO,
            TipoDeModeloId = (byte)TipoDeModeloEnum.CALÇA,
            StatusId = (byte)StatusEnum.ATIVO
        },
        new Modelo
        {
            Id = 6,
            NomeDoModelo = "Tênis Esportivo",
            ColecaoId = 5,
            LayoutId = (byte)ModeloLayoutEnum.LISO,
            TipoDeModeloId = (byte)TipoDeModeloEnum.CALÇADOS,
            StatusId = (byte)StatusEnum.ATIVO
        },
        new Modelo
        {
            Id = 7,
            NomeDoModelo = "Camisa Social Listrada",
            ColecaoId = 6,
            LayoutId = (byte)ModeloLayoutEnum.ESTAMPA,
            TipoDeModeloId = (byte)TipoDeModeloEnum.CAMISA,
            StatusId = (byte)StatusEnum.ATIVO
        },
        new Modelo
        {
            Id = 8,
            NomeDoModelo = "Chapéu de Palha",
            ColecaoId = 4,
            LayoutId = (byte)ModeloLayoutEnum.BORDADO,
            TipoDeModeloId = (byte)TipoDeModeloEnum.CHAPÉU,
            StatusId = (byte)StatusEnum.ATIVO
        },
        new Modelo
        {
            Id = 9,
            NomeDoModelo = "Saia Midi Floral",
            ColecaoId = 3,
            LayoutId = (byte)ModeloLayoutEnum.LISO,
            TipoDeModeloId = (byte)TipoDeModeloEnum.SAIA,
            StatusId = (byte)StatusEnum.ATIVO
        },
        new Modelo
        {
            Id = 10,
            NomeDoModelo = "Vestido Longo Elegante",
            ColecaoId = 2,
            LayoutId = (byte)ModeloLayoutEnum.ESTAMPA,
            TipoDeModeloId = (byte)TipoDeModeloEnum.SAIA,
            StatusId = (byte)StatusEnum.ATIVO
        }
    };

    foreach (var modelo in modelos) modelBuilder.Entity<Modelo>().HasData(modelo);
  }
}