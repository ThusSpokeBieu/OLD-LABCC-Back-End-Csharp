using LABCC.BackEnd.Domain.Entities.People;
using LABCC.BackEnd.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace LABCC.BackEnd.Domain.Entities.Users;
public class User : Person
{
  [Required]
  [StringLength(100)]
  [EmailAddress]
  public string Email { get; set; }

  [Required]
  public UserTypeEnum UserType {  get; set; }
}
