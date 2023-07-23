using LABCC.BackEnd.Domain.Entities.Usuarios;
using LABCC.BackEnd.Domain.Enum;
using LABCC.BackEnd.Utils;
using Microsoft.EntityFrameworkCore;

namespace LABCC.BackEnd.Infrastructure.DbMapping;

public class UsuariosDbMapping
{
    public void Build(ModelBuilder builder)
    {
        builder.Entity<Usuario>().HasKey(u => u.Id);

        builder
            .Entity<Usuario>()
            .Property(u => u.Id)
            .HasColumnOrder(0)
            .HasComment("Identificador do usuário")
            .IsConcurrencyToken(true)
            .IsRequired(true);

        builder
            .Entity<Usuario>()
            .Property(u => u.CpfOuCnpj)
            .HasColumnOrder(1)
            .HasComment("É o documento do usuário (CPF ou CNPJ), apenas digitos numéricos.")
            .HasColumnType("varchar(18)")
            .HasMaxLength(18)
            .IsRequired(true)
            .HasConversion(
                value => RegexConst.NotNumericalDigitRegex().Replace(value!, ""),
                value => value
            );

        builder
            .Entity<Usuario>()
            .Property(u => u.UserName)
            .HasColumnOrder(2)
            .HasComment("UserName do usuário")
            .HasMaxLength(100)
            .HasColumnType("nvarchar(100)")
            .IsRequired();

        builder
            .Entity<Usuario>()
            .Property(u => u.Nome)
            .HasColumnOrder(3)
            .HasComment("Nome do usuário")
            .HasMaxLength(100)
            .HasColumnType("nvarchar(100)")
            .IsRequired();

        builder
            .Entity<Usuario>()
            .Property(u => u.DataDeNascimento)
            .HasColumnOrder(4)
            .HasComment("Data de Nascimento do usuário")
            .HasColumnType("date")
            .IsRequired();

        builder
            .Entity<Usuario>()
            .Property(u => u.Telefone)
            .HasColumnOrder(5)
            .HasComment("Telefone do usuário")
            .HasColumnType("varchar(15)")
            .HasMaxLength(15)
            .IsRequired()
            .HasConversion(
                value => RegexConst.NotNumericalDigitRegex().Replace(value!, ""),
                value => value
            );

        builder.Entity<Usuario>().HasOne(u => u.Genero).WithMany().HasForeignKey(u => u.GeneroId);

        builder
            .Entity<Usuario>()
            .Property(u => u.GeneroId)
            .HasColumnOrder(6)
            .HasComment("Gênero do usuário: 1 - Masculino, 2 - Feminino, 3 - Outro");

        builder
            .Entity<Usuario>()
            .HasOne(u => u.TipoDeUsuario)
            .WithMany()
            .HasForeignKey(u => u.TipoDeUsuarioId);

        builder
            .Entity<Usuario>()
            .Property(u => u.TipoDeUsuarioId)
            .HasColumnOrder(7)
            .HasComment("Tipo do usuário: 1 - Administrador, 2 - Gerente, 3 - Criador, 4 - Outro");

        builder
            .Entity<Usuario>()
            .Property(u => u.AtualizadoEm)
            .HasColumnOrder(8)
            .HasComment("Momento em que o usuário foi atualizado")
            .HasColumnType("datetimeoffset")
            .ValueGeneratedOnAddOrUpdate()
            .HasDefaultValueSql("SYSUTCDATETIME()")
            .IsRequired();

        builder
            .Entity<Usuario>()
            .Property(u => u.CriadoEm)
            .HasColumnOrder(9)
            .HasComment("Momento em que o usuário foi criado")
            .HasColumnType("datetimeoffset")
            .ValueGeneratedOnAddOrUpdate()
            .HasDefaultValueSql("SYSUTCDATETIME()")
            .IsRequired();

        builder.Entity<Usuario>().HasOne(u => u.Status).WithMany().HasForeignKey(u => u.StatusId);

        builder
            .Entity<Usuario>()
            .Property(u => u.StatusId)
            .HasColumnOrder(10)
            .HasComment("Status do usuário: 0 - Inativo, 1 - Ativo");

        builder.Entity<Usuario>().HasIndex(u => u.CpfOuCnpj).IsUnique();

        builder.Entity<Usuario>().HasIndex(u => u.UserName);

        builder.Entity<Usuario>().HasIndex(u => u.Nome);

        Seed(builder);
    }

    public void Seed(ModelBuilder modelBuilder)
    {
        var usuarios = new Usuario[]
        {
            new Usuario
            {
                Nome = "Lucas Diego Santos",
                CpfOuCnpj = "278.656.291-09",
                DataDeNascimento = new DateTime(2000, 03, 26),
                GeneroId = (byte)GeneroEnum.MASCULINO,
                UserName = "lucas_diego@gimail.com",
                TipoDeUsuarioId = (byte)TipoDeUsuarioEnum.ADMINISTRADOR,
                Telefone = "(63) 99729-3374",
                StatusId = (byte)StatusEnum.ATIVO
            },
            new Usuario
            {
                Nome = "Marcos Mateus Anthony Campos",
                CpfOuCnpj = "121.682.363-48",
                DataDeNascimento = new DateTime(2001, 05, 06),
                GeneroId = (byte)GeneroEnum.MASCULINO,
                UserName = "marcos.mateus.campos@doublesp.com.br",
                TipoDeUsuarioId = (byte)TipoDeUsuarioEnum.OUTRO,
                Telefone = "(75) 99404-5248",
                StatusId = (byte)StatusEnum.ATIVO
            },
            new Usuario
            {
                Nome = "Mirella Beatriz Lima",
                CpfOuCnpj = "493.617.515-30",
                DataDeNascimento = new DateTime(1954, 05, 08),
                GeneroId = (byte)GeneroEnum.FEMININO,
                UserName = "mirella_beatriz_lima@engeseg.com.br",
                TipoDeUsuarioId = (byte)TipoDeUsuarioEnum.ADMINISTRADOR,
                Telefone = "(62) 98420-9876",
                StatusId = (byte)StatusEnum.ATIVO
            },
            new Usuario
            {
                Nome = "Antonio Carlos Eduardo Dias",
                CpfOuCnpj = "864.306.046-16",
                DataDeNascimento = new DateTime(1996, 01, 03),
                GeneroId = (byte)GeneroEnum.OUTRO,
                UserName = "antonio_carlos_dias@lukin4.com.br",
                TipoDeUsuarioId = (byte)TipoDeUsuarioEnum.GERENTE,
                Telefone = "(65) 99579-0748",
                StatusId = (byte)StatusEnum.INATIVO
            },
            new Usuario
            {
                Nome = "Kamilly Antônia Almeida",
                CpfOuCnpj = "945.981.184-15",
                DataDeNascimento = new DateTime(1998, 05, 23),
                GeneroId = (byte)GeneroEnum.FEMININO,
                UserName = "kamilly.antonia.almeida@onset.com.br",
                TipoDeUsuarioId = (byte)TipoDeUsuarioEnum.CRIADOR,
                Telefone = "(93) 98644-1270",
                StatusId = (byte)StatusEnum.ATIVO
            }
        };
        foreach (Usuario usuario in usuarios)
            modelBuilder.Entity<Usuario>().HasData(usuario);
    }
}
