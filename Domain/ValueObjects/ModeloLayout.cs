using LABCC.BackEnd.Domain.Validators.DataTypeAttributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace LABCC.BackEnd.Domain.ValueObjects;

public class ModeloLayout : ValueObject
{
    [JsonIgnore]
    public byte Id { get; set; }

    [Required]
    [TipoDeModelo]
    [DefaultValue("Bermuda")]
    [JsonPropertyName("Layout")]
    public override string Value
    {
        get => base.Value;
        set => base.Value = value;
    }
}
