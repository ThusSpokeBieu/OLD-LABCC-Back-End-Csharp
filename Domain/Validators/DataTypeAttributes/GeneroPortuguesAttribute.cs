using Gmess.SharperAnnotationsForDataType.Attributes;
using LABCC.BackEnd.Domain.Enum;

namespace LABCC.BackEnd.Domain.Validators.DataTypeAttributes;

public class GeneroPortuguesAttribute : StringInEnumAttribute
{
    public GeneroPortuguesAttribute()
        : base(typeof(GeneroEnum))
    {
        ErrorMessage =
            "{0} obrigatóriamente deve ser um dos valores corretos: 'Masculino', 'Feminino', ou 'Outro'.";
    }
}
