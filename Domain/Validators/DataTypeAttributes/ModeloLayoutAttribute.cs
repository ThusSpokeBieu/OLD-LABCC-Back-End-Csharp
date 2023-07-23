using Gmess.SharperAnnotationsForDataType.Attributes;
using LABCC.BackEnd.Domain.Enum;

namespace LABCC.BackEnd.Domain.Validators.DataTypeAttributes;

public class ModeloLayoutAttribute : StringInEnumAttribute
{
    public ModeloLayoutAttribute()
        : base(typeof(ModeloLayoutEnum))
    {
        ErrorMessage =
            "{0} obrigatóriamente deve ser um dos valores corretos: 'Bordado', 'Estampa' ou 'Liso'.";
    }
}
