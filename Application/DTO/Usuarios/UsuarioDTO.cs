using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Gmess.SharperAnnotationsForDataType.Attributes;
using LABCC.BackEnd.Domain.Validators.DataTypeAttributes;

namespace LABCC.BackEnd.Application.DTO.Usuarios;

public class UsuarioDTO 
{
  [Required(ErrorMessage = "{0} é obrigatório")]
  [EmailAddress(ErrorMessage = "Por favor, insira um {0} correto.")]
  [DefaultValue("johndoe@email.com")]
  [MaxLength(100, ErrorMessage = " {0} deve possuir no máximo 100 caracteres. ")]
  public string Email { get; set; }

  [Required(ErrorMessage = "{0} é obrigatório.")]
  [MaxLength(80, ErrorMessage = " {0} deve possuir no máximo 80 caracteres. ")]
  [DefaultValue("John Doe")]
  [Description("Nome da pessoa ou usuário.")]
  public string Nome { get; set; }

  [Required(ErrorMessage = "{0} é obrigatório, ")]
  [MaxLength(18, ErrorMessage = " {0} deve possuir no máximo 18 caracteres. ")]
  [CpfOrCnpjDocument(ErrorMessage = "{0} deve ser um CPF ou CNPJ REALMENTE VÁLIDO do formato: 'XXX.XXX.XXX-XX', 'XX.XXX.XXX/XXXX.XX' ou apenas númerico.")]
  [DefaultValue("366.203.753-08")]
  public string CpfOuCnpj { get; set; }

  [Required(ErrorMessage = "{0} é Obrigatório")]
  [MaxLength(10, ErrorMessage = " {0} deve possuir no máximo 10 caracteres. ")]
  [GeneroPortugues]
  [DefaultValue("Masculino")]
  public string Genero { get; set; }

  [Required(ErrorMessage = "Data de Nascimento é obrigatório")]
  [DefaultValue("1989-03-26")]
  public DateOnly DataDeNascimento { get; set; }

  [Required]
  [MaxLength(16, ErrorMessage = " {0} deve possuir no máximo 16 caracteres. ")]
  [BrazilPhoneNumber(ErrorMessage = "O {0} deve ser um número brasileiro válido: (XX) XXXXX-XXXX ou (XX) XXXX-XXXX")]
  [DefaultValue("(61) 99900-5764")]
  public string Telefone { get; set; }


  [Required(ErrorMessage = "Tipo do Usuário é obrigatório")]
  [TipoDeUsuario]
  [MaxLength(15, ErrorMessage = " {0} deve possuir no máximo 15 caracteres. ")]
  [DefaultValue("Criador")]
  public string TipoDeUsuario { get; set; }

  [Required(ErrorMessage = "Status do Usuário é obrigatório.")]
  [StatusDoUsuario]
  [MaxLength(10, ErrorMessage = " {0} deve possuir no máximo 10 caracteres. ")]
  [DefaultValue("Ativo")]
  public string StatusDoUsuario { get; set; }
}
