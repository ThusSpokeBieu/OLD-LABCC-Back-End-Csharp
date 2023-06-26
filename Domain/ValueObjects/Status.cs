using LABCC.BackEnd.Domain.Validators.DataTypeAttributes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LABCC.BackEnd.Domain.ValueObjects;

public class Status : ValueObject
{
  [JsonIgnore]
  public byte Id { get; set; }

  [Required]
  [StatusDoUsuario]
  [DefaultValue("Ativo")]
  public override string Value { 
    get => base.Value; 
    set => base.Value = value; }
}
