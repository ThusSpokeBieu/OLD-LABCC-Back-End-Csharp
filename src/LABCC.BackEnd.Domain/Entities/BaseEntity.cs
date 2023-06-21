namespace LABCC.BackEnd.Domain.Entities;

internal abstract class BaseEntity
{
  public virtual long Id { get; set; }
  public virtual long UpdatedAt { get; set; }
  public virtual long CreatedAt { get; set; }
  public virtual bool IsActive { get; set; }

  public BaseEntity() {
    var now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

    UpdatedAt = now;
    CreatedAt = now;
    IsActive = true;

  }
}
