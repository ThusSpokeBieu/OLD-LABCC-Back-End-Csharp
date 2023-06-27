using LABCC.BackEnd.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace LABCC.BackEnd.Infrastructure.DbMapping.VO;

public class StatusDbMapping
{
    public void Build(ModelBuilder builder)
    {
        builder.Entity<Status>()
          .HasKey(s => s.Id);

        builder.Entity<Status>()
          .Property(s => s.Value)
          .HasColumnOrder(0)
          .HasComment("É o valor do status.")
          .HasColumnType("varchar(18)")
          .HasMaxLength(18)
          .IsRequired(true);

        builder.Entity<Status>()
          .HasIndex(s => s.Value)
          .IsUnique();

        Seed(builder);
    }

    public void Seed(ModelBuilder modelBuilder)
    {
        var allStatus = new Status[]
        {
          new Status
          {
            Id = 0,
            Value = "Inativo"
          },
          new Status
          {
            Id = 1,
            Value = "Ativo"
          }
        };

        foreach (var status in allStatus) modelBuilder.Entity<Status>().HasData(status);

    }
}
