using LABCC.BackEnd.Domain.Validators.DataTypeAttributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace LABCC.BackEnd.Domain.ValueObjects;

public class TipoDeModelo : ValueObject
{
  [JsonIgnore]
  public byte Id { get; set; }

  [Required]
  [TipoDeModelo]
  [DefaultValue("Bermuda")]
  [JsonPropertyName("TipoDeModelo")]
  public override string Value
  {
    get => base.Value;
    set => base.Value = value;
  }
}