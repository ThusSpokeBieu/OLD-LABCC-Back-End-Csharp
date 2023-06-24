using Gmess.SharperAnnotationsForDataType.Attributes;
using LABCC.BackEnd.Domain.Validators.DataTypeAttributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LABCC.BackEnd.Application.DTO.Usuarios;

public class UsuarioDTOResponse
{

  [Required(ErrorMessage = "{0} é obrigatório")]
  [EmailAddress(ErrorMessage = "Por favor, insira um {0} correto.")]
  [DefaultValue("johndoe@email.com")]
  public string Email { get; set; }

  [Required(ErrorMessage = "{0} é obrigatório.")]
  [DefaultValue("John Doe")]
  [Description("Nome da pessoa ou usuário.")]
  public string Nome { get; set; }

  [Required(ErrorMessage = "{0} é obrigatório, ")]
  [CpfOrCnpjDocument(ErrorMessage = "{0} deve ser um CPF ou CNPJ válido do formato: 'XXX.XXX.XXX-XX' ou 'XX.XXX.XXX/XXXX.XX'.")]
  [DefaultValue("366.203.753-08")]
  public string CpfOuCnpj { get; set; }

  [Required(ErrorMessage = "{0} é Obrigatório")]
  [GeneroPortugues]
  [DefaultValue("Male")]
  public string Genero { get; set; }

  [Required(ErrorMessage = "Data de Nascimento é obrigatório")]
  [DefaultValue("1989-03-26")]
  public DateOnly DataDeNascimento { get; set; }

  [Required]
  [BrazilPhoneNumber(ErrorMessage = "O {0} deve ser um número brasileiro válido: (XX) XXXXX-XXXX ou (XX) XXXX-XXXX")]
  [DefaultValue("(61) 99900-5764")]
  public string Telefone { get; set; }


  [Required(ErrorMessage = "Tipo do Usuário é obrigatório")]
  [TipoDeUsuario]
  [DefaultValue("Criador")]
  public string UserType { get; set; }

  [Required(ErrorMessage = "Status do Usuário é obrigatório.")]
  [StatusDoUsuario]
  [DefaultValue("Ativo")]
  public string StatusDoUsuario { get; set; }
}
