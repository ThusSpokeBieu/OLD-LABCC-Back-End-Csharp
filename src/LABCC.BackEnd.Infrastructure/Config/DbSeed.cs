using LABCC.BackEnd.Domain.Entities.Users;
using LABCC.BackEnd.Domain.Enum;
using LABCC.BackEnd.Infrastructure.Context;

namespace LABCC.BackEnd.Infrastructure.Config;

public static class DbSeed
{
  public static void Initialize(MsSqlContext context)
  {
    if (context.Users.Any())
    {
      return;
    }

    var now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

    var users = new User[]
    {
      new User
      {
        Name = "Lucas Diego Santos",
        Document = "278.656.291-09",
        BirthDate = new DateTime(2000, 03, 26),
        Gender = GenderEnum.MALE,
        Email = "marcio_lima@gimail.com",
        UserType = UserTypeEnum.ADMIN,
        Telephone = "(63) 99729-3374",
        
      },
      new User
      {

        Name = "Marcos Mateus Anthony Campos",
        Document = "121.682.363-48",
        BirthDate = new DateTime(2001, 05, 06),
        Gender = GenderEnum.MALE,
        Email = "marcos.mateus.campos@doublesp.com.br",
        UserType = UserTypeEnum.OTHER,
        Telephone = "(75) 99404-5248"
      },
      new User
      {
        Name = "Mirella Beatriz Lima",
        Document = "493.617.515-30",
        BirthDate = new DateTime(1954, 05, 08),
        Gender = GenderEnum.FEMALE,
        Email = "mirella_beatriz_lima@engeseg.com.br",
        UserType = UserTypeEnum.ADMIN,
        Telephone = "(62) 98420-9876"
      },
      new User
      {
        Name = "Antonio Carlos Eduardo Dias",
        Document = "864.306.046-16",
        BirthDate = new DateTime(1996, 01, 03),
        Gender = GenderEnum.OTHER,
        Email = "antonio_carlos_dias@lukin4.com.br",
        UserType = UserTypeEnum.MANAGER,
        Telephone = "(65) 99579-0748"
      },
      new User
      {
        Name = "Kamilly Antônia Almeida",
        Document = "945.981.184-15",
        BirthDate = new DateTime(1998, 05, 23),
        Gender = GenderEnum.FEMALE,
        Email = "kamilly.antonia.almeida@onset.com.br",
        UserType = UserTypeEnum.CREATOR,
        Telephone = "(93) 98644-1270"
      }
    };

    context.Users.AddRange(users);
    context.SaveChanges();
  }
}
