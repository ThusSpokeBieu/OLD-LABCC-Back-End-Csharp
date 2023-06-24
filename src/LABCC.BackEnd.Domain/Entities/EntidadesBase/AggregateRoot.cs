using LABCC.BackEnd.Domain.ValueObjects;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LABCC.BackEnd.Domain.Entities.EntidadesBase;

public abstract class AggregateRoot : Entidade
{
  [Key]
  [Description("Id do usuário")]
  public virtual long Id { get; set; }

  [Required]
  [Description("Momento em que a entidade foi atualizada.")]
  public virtual DateTimeOffset AtualizadoEm { get; set; }

  [Required]
  [Description("Momento em que a entidade foi criada.")]
  public virtual DateTimeOffset CriadoEm { get; set; }

  [Description("Flag indicando se a entidade está ativa: 0 - Inativo, 1 - Ativo.")]
  public virtual byte StatusId { get; set; }

  public virtual Status Status { get; set; }

}
