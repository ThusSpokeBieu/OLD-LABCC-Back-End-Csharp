using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LABCC.BackEnd.Domain.Entities.EntidadesBase;

public abstract class EntidadeBase
{
  [Key]
  [Description("Id do usuário")]
  public virtual long Id { get; set; }

  [Required]
  [Description("Momento em que a entidade foi atualizada.")]
  public virtual long AtualizadoEm { get; set; }

  [Required]
  [Description("Momento em que a entidade foi criada.")]
  public virtual long CriadoEm { get; set; }

  [DefaultValue(false)]
  [Description("Flag indicando se a entidade foi deletada.")]
  public virtual bool Deletado { get; set; }

  public EntidadeBase()
  {
    var now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

    AtualizadoEm = now;
    CriadoEm = now;
    Deletado = false;
  }
}
