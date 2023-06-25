
using Gmess.SharperAnnotationsForDataType.Attributes;
using LABCC.BackEnd.Domain.Enum;

namespace LABCC.BackEnd.Domain.Validators.DataTypeAttributes;
public class StatusDoUsuarioAttribute : StringInEnumAttribute
{
  public StatusDoUsuarioAttribute() : base(typeof(StatusEnum))
  {
    ErrorMessage = "{0} deve ser: 'Ativo' ou 'Inativo'.";
  }
}
