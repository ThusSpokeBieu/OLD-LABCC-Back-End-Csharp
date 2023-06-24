using Microsoft.EntityFrameworkCore;
using LABCC.BackEnd.Domain.Enum;
using LABCC.BackEnd.Domain.Entities.Usuarios;

namespace LABCC.BackEnd.Infrastructure.Context;

public class MsSqlContext : DbContext
{
  public MsSqlContext(DbContextOptions<MsSqlContext> options) : base(options)
  {

  }
    
  public DbSet<Usuario> Usuarios { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.Entity<Usuario>().ToTable("Entidade.Usuarios");

    SeedUsers(modelBuilder);
  }

  private void SeedUsers (ModelBuilder modelBuilder)
  {
    var usuarios = new Usuario[]
    {
      new Usuario
      {
        Id = 1,
        Nome = "Lucas Diego Santos",
        CpfOuCnpj = "278.656.291-09",
        DataDeNascimento = new DateTime(2000, 03, 26),
        Genero = GeneroEnum.MASCULINO,
        Email = "lucas_diego@gimail.com",
        TipoDeUsuario = TipoDeUsuarioEnum.ADMINISTRADOR,
        Telefone = "(63) 99729-3374",
        StatusDoUsuario = StatusDoUsuario.Ativo
      },
      new Usuario
      {
        Id = 2,
        Nome = "Marcos Mateus Anthony Campos",
        CpfOuCnpj = "121.682.363-48",
        DataDeNascimento = new DateTime(2001, 05, 06),
        Genero = GeneroEnum.MASCULINO,
        Email = "marcos.mateus.campos@doublesp.com.br",
        TipoDeUsuario = TipoDeUsuarioEnum.OUTRO,
        Telefone = "(75) 99404-5248",
        StatusDoUsuario = StatusDoUsuario.Ativo
      },
      new Usuario
      {
        Id = 3,
        Nome = "Mirella Beatriz Lima",
        CpfOuCnpj = "493.617.515-30",
        DataDeNascimento = new DateTime(1954, 05, 08),
        Genero = GeneroEnum.FEMININO,
        Email = "mirella_beatriz_lima@engeseg.com.br",
        TipoDeUsuario = TipoDeUsuarioEnum.ADMINISTRADOR,
        Telefone = "(62) 98420-9876",
        StatusDoUsuario = StatusDoUsuario.Ativo
      },
      new Usuario
      {
        Id = 4,
        Nome = "Antonio Carlos Eduardo Dias",
        CpfOuCnpj = "864.306.046-16",
        DataDeNascimento = new DateTime(1996, 01, 03),
        Genero = GeneroEnum.OUTRO,
        Email = "antonio_carlos_dias@lukin4.com.br",
        TipoDeUsuario = TipoDeUsuarioEnum.GERENTE,
        Telefone = "(65) 99579-0748",
        StatusDoUsuario = StatusDoUsuario.Inativo
      },
      new Usuario
      {
        Id = 5,
        Nome = "Kamilly Antônia Almeida",
        CpfOuCnpj = "945.981.184-15",
        DataDeNascimento = new DateTime(1998, 05, 23),
        Genero = GeneroEnum.FEMININO,
        Email = "kamilly.antonia.almeida@onset.com.br",
        TipoDeUsuario = TipoDeUsuarioEnum.CRIADOR,
        Telefone = "(93) 98644-1270",
        StatusDoUsuario = StatusDoUsuario.Ativo
      }
    };
    foreach (Usuario usuario in usuarios) modelBuilder.Entity<Usuario>().HasData(usuario);
  }
}
