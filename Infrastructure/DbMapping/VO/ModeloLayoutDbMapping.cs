using LABCC.BackEnd.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace LABCC.BackEnd.Infrastructure.DbMapping.VO;

public class ModeloLayoutDbMapping
{
  public void Build(ModelBuilder builder)
  {
    builder.Entity<ModeloLayout>()
      .HasKey(l => l.Id);

    builder.Entity<ModeloLayout>()
      .Property(l => l.Value)
      .HasColumnOrder(1)
      .HasComment("É o valor do modelo de Layout.")
      .HasColumnType("varchar(18)")
      .HasMaxLength(18)
      .IsRequired(true);

    builder.Entity<ModeloLayout>()
      .HasIndex(s => s.Value)
      .IsUnique();

    Seed(builder);
  }

  public void Seed(ModelBuilder modelBuilder)
  {
    var layouts = new ModeloLayout[]
    {
           new ModeloLayout
          {
            Id = 1,
            Value = "Bordado"
          },
          new ModeloLayout
          {
            Id = 2,
            Value = "Estampa"
          },
          new ModeloLayout
          {
            Id = 3,
            Value = "Liso"
          }
    };

    foreach (var layout in layouts) modelBuilder.Entity<ModeloLayout>().HasData(layout);

  }
}
