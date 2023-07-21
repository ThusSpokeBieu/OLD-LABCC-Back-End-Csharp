using LABCC.BackEnd.Domain.Entities.EntidadesBase;
using LABCC.BackEnd.Domain.ValueObjects;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LABCC.BackEnd.Domain.Entities.Usuarios;

public sealed class Usuario : Pessoa
{
  [Required]
  [EmailAddress]
  [Description("E-mail do usuário")]
  public string Email { get; set; }

  [Required]
  [Description("Tipo de Usuário, 1 - Administrador, 2 - Gerente, 3 - Criador, 4 - Outro")]
  public byte TipoDeUsuarioId { get; set; }

  public TipoDeUsuario? TipoDeUsuario { get; set; }

}
