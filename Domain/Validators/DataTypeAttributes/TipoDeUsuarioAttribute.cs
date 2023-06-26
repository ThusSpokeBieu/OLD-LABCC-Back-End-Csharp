using Gmess.SharperAnnotationsForDataType.Attributes;
using LABCC.BackEnd.Domain.Enum;

namespace LABCC.BackEnd.Domain.Validators.DataTypeAttributes;
public class TipoDeUsuarioAttribute : StringInEnumAttribute
{
  public TipoDeUsuarioAttribute() : base (typeof(TipoDeUsuarioEnum))
  {
    ErrorMessage = " {0} precisa ter um dos valores corretos: 'Administrador', 'Gerente', 'Criador' ou 'Outro'";
  }
}
