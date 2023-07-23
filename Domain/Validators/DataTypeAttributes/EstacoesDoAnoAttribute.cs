using Gmess.SharperAnnotationsForDataType.Attributes;
using LABCC.BackEnd.Domain.Enum;

namespace LABCC.BackEnd.Domain.Validators.DataTypeAttributes;

public class EstacoesDoAnoAttribute : StringInEnumAttribute
{
    public EstacoesDoAnoAttribute()
        : base(typeof(EstacoesEnum))
    {
        ErrorMessage =
            "{0} obrigatóriamente deve ser um dos valores corretos: 'Primavera', 'Verão', 'Outono' ou 'Inverno'.";
    }
}
