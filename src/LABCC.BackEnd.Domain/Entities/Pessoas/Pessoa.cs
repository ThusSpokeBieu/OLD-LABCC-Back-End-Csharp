using LABCC.BackEnd.Domain.Entities.EntidadesBase;
using LABCC.BackEnd.Domain.Enum;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LABCC.BackEnd.Domain.Entities.Pessoas;
public class Pessoa : EntidadeBase
{
  [Required]
  [StringLength(100)]
  [ConcurrencyCheck]
  [Description("Nome da pessoa ou usuário.")]
  public string Nome { get; set; }

  [Required]
  [ConcurrencyCheck]
  [Description("Gênero da pessoa ou usuário: 1 - Masculino, 2 - Feminino, 3 - Outro")]
  public GeneroEnum Genero { get; set; }
  
  [Required]
  [ConcurrencyCheck]
  [Description("Data de nascimento do usuário, é um DateTime de formato: YYYY-mm-DD")]
  public DateTime DataDeNascimento { get; set; }

  [Required]
  [ConcurrencyCheck]
  [Description("Documentos do usuário, CPF ou CNPJ. Formatos: 'XXX.XXX.XXX-XX' ou 'XX.XXX.XXX/XXXX.XX', ou apenas numeros.")]
  public string CpfOuCnpj { get; set; }

  [Required]
  [ConcurrencyCheck]
  [Description("Telefone do usuário, deve conter o seguinte formato de um número brasileiro: (XX) XXXXX-XXXX, ou apenas numeros")]
  public string Telefone { get; set; }
}
