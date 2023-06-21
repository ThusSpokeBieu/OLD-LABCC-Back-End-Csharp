using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LABCC.BackEnd.Domain.Entities;

public abstract class BaseEntity
{
  [Key]
  public virtual long Id { get; set; }

  [Required]
  public virtual long UpdatedAt { get; set; }

  [Required]
  public virtual long CreatedAt { get; set; }

  [DefaultValue(true)]
  public virtual bool IsActive { get; set; }

  public BaseEntity() {
    var now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

    UpdatedAt = now;
    CreatedAt = now;
    IsActive = true;

  }
}
