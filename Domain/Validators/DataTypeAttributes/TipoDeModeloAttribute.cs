using Gmess.SharperAnnotationsForDataType.Attributes;
using LABCC.BackEnd.Domain.Enum;

namespace LABCC.BackEnd.Domain.Validators.DataTypeAttributes;

public class TipoDeModeloAttribute : StringInEnumAttribute
{
    public TipoDeModeloAttribute()
        : base(typeof(TipoDeModeloEnum))
    {
        ErrorMessage =
            "{0} obrigatoriamente deve ser um dos valores corretos: 'Bermuda', 'Biquini', 'Bolsa', 'Boné', 'Calça', 'Calçados', 'Camisa', 'Chapéu' ou 'Saia'.";
    }
}
