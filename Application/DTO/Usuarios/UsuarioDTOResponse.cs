using Gmess.SharperAnnotationsForDataType.Attributes;
using LABCC.BackEnd.Domain.Validators.DataTypeAttributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LABCC.BackEnd.Application.DTO.Usuarios;

public sealed class UsuarioDTOResponse
{
  [Required]
  [DefaultValue(12)]
  public long Identificador { get; set; }

  [Required(ErrorMessage = "{0} é obrigatório")]
  [EmailAddress(ErrorMessage = "Por favor, insira um {0} correto.")]
  [DefaultValue("johndoe@email.com")]
  public string Email { get; set; }

  [Required(ErrorMessage = "{0} é obrigatório.")]
  [DefaultValue("John Doe")]
  [Description("Nome da pessoa ou usuário.")]
  public string Nome { get; set; }

  [Required(ErrorMessage = "{0} é obrigatório, ")]
  [CpfOrCnpjDocument(ErrorMessage = "{0} deve ser um CPF ou CNPJ realmente válido (apenas números), formato 'XXXXXXXXXXX' ou 'XXXXXXXXXXXXXX'.")]
  [DefaultValue("36620375308")]
  public string CpfOuCnpj { get; set; }

  [Required(ErrorMessage = "{0} é Obrigatório")]
  [GeneroPortugues]
  [DefaultValue("Masculino")]
  public string Genero { get; set; }

  [Required(ErrorMessage = "Data de Nascimento é obrigatório")]
  [DefaultValue("1989-03-26")]
  public DateOnly DataDeNascimento { get; set; }

  [Required]
  [BrazilPhoneNumber(ErrorMessage = "O {0} deve ser um número brasileiro válido (apenas numeros): XXXXXXXXXXX ou XXXXXXXXXX")]
  [DefaultValue("61999005764")]
  public string Telefone { get; set; }


  [Required(ErrorMessage = "Tipo do Usuário é obrigatório")]
  [TipoDeUsuario]
  [DefaultValue("Criador")]
  public string TipoDeUsuario { get; set; }

  [Required(ErrorMessage = "Status do Usuário é obrigatório.")]
  [Status]
  [DefaultValue("Ativo")]
  public string StatusDoUsuario { get; set; }
}
