using System.ComponentModel.DataAnnotations;

namespace LABCC.BackEnd.Domain.ValueObjects;

public class  TipoDeUsuario : ValueObject
{
  public byte Id { get; set; }

  [Required]
  public string Sigla { get; set; }
}

