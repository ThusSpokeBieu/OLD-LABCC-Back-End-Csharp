
using Gmess.SharperAnnotationsForDataType.Attributes;
using LABCC.BackEnd.Domain.Enum;

namespace LABCC.BackEnd.Domain.Validators.DataTypeAttributes;
public class StatusDoUsuarioAttribute : StringInEnumAttribute
{
  public StatusDoUsuarioAttribute() : base(typeof(StatusDoUsuario))
  {
    ErrorMessage = "{0} deve ser: 'Ativo' ou 'Inativo'.";
  }
}
