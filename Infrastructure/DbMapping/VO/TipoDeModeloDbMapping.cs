using LABCC.BackEnd.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace LABCC.BackEnd.Infrastructure.DbMapping.VO;

public class TipoDeModeloDbMapping
{
    public void Build(ModelBuilder builder)
    {
        builder.Entity<TipoDeModelo>().HasKey(t => t.Id);

        builder
            .Entity<TipoDeModelo>()
            .Property(t => t.Value)
            .HasColumnOrder(1)
            .HasComment("É o valor do tipo de modelo.")
            .HasColumnType("varchar(18)")
            .HasMaxLength(18)
            .IsRequired(true);

        builder.Entity<TipoDeModelo>().HasIndex(s => s.Value).IsUnique();

        Seed(builder);
    }

    public void Seed(ModelBuilder modelBuilder)
    {
        var tipos = new TipoDeModelo[]
        {
            new TipoDeModelo { Id = 1, Value = "Bermuda" },
            new TipoDeModelo { Id = 2, Value = "Biquini" },
            new TipoDeModelo { Id = 3, Value = "Bolsa" },
            new TipoDeModelo { Id = 4, Value = "Boné" },
            new TipoDeModelo { Id = 5, Value = "Calça" },
            new TipoDeModelo { Id = 6, Value = "Calçados" },
            new TipoDeModelo { Id = 7, Value = "Camisa" },
            new TipoDeModelo { Id = 8, Value = "Chapéu" },
            new TipoDeModelo { Id = 9, Value = "Saia" }
        };

        foreach (var tipo in tipos)
            modelBuilder.Entity<TipoDeModelo>().HasData(tipo);
    }
}
