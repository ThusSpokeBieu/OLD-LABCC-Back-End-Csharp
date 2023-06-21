using LABCC.BackEnd.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace LABCC.BackEnd.Domain.Entities.People;
public class Person : BaseEntity
{
  [Required]
  [StringLength(100)]
  public string Name { get; set; }

  [Required]
  public GenderEnum Gender { get; set; }

  [Required]
  public DateTime BirthDate { get; set; }

  [Required]
  public string Document { get; set; }

  [Required]
  public string Telephone { get; set; }
}
