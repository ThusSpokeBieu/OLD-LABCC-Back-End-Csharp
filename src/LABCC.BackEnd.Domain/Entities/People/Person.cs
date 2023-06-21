using LABCC.BackEnd.Domain.Enum;

namespace LABCC.BackEnd.Domain.Entities.People;
internal class Person : BaseEntity
{
  public string Name { get; set; }
  public GenderEnum Gender { get; set; }
  public DateOnly BirthDate { get; set; }
  public string Document { get; set; }
  public string Telephone { get; set; }
}
