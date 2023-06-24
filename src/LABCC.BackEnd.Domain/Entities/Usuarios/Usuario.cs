using LABCC.BackEnd.Domain.Entities.Pessoas;
using LABCC.BackEnd.Domain.Enum;
using LABCC.BackEnd.Domain.Validators.DataTypeAttributes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LABCC.BackEnd.Domain.Entities.Usuarios;

[Table("Entidade.Usuarios")]
public class Usuario : Pessoa
{
  [Required]
  [StringLength(100)]
  [EmailAddress]
  [ConcurrencyCheck]
  [Description("E-mail do usuário")]
  public string Email { get; set; }

  [Required]
  [ConcurrencyCheck]
  [EnumDataType(typeof(TipoDeUsuarioEnum))]
  [Description("Tipo de Usuário, 1 - Administrador, 2 - Gerente, 3 - Criador, 4 - Outro")]
  public TipoDeUsuarioEnum TipoDeUsuario { get; set; }

  [Required]
  [ConcurrencyCheck]
  [EnumDataType(typeof(StatusDoUsuario))]
  [Description("Status do usuário: 0 - Inativo, 1 - Ativo")]
  public StatusDoUsuario StatusDoUsuario { get; set; }
}
