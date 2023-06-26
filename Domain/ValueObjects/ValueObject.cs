using System.ComponentModel.DataAnnotations;

namespace LABCC.BackEnd.Domain.ValueObjects;

public abstract class ValueObject
{
  [Required]
  public virtual string Value { get; set; }
}
