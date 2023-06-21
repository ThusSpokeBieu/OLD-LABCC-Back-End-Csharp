using Microsoft.EntityFrameworkCore;
using LABCC.BackEnd.Domain.Entities.Users;

namespace LABCC.BackEnd.Infrastructure.Context;

public class MsSqlContext : DbContext
{
  public MsSqlContext(DbContextOptions<MsSqlContext> options) : base(options)
  {

  }
    
  public DbSet<User> Users { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.Entity<User>().ToTable("users");
  }
}
