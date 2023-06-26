using LABCC.BackEnd.Domain.Entities.EntidadesBase;
using LABCC.BackEnd.Domain.ValueObjects;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LABCC.BackEnd.Domain.Entities.Pessoas;
public class Pessoa : AggregateRoot
{
  [Required]
  [Description("Nome da pessoa ou usuário.")]
  public string Nome { get; set; }

  [Required]
  [Description("Gênero da pessoa ou usuário: 1 - Masculino, 2 - Feminino, 3 - Outro")]
  public byte GeneroId { get; set; }

  public Genero? Genero { get; set; }
  
  [Required]
  [Description("Data de nascimento do usuário, é um DateTime de formato: YYYY-mm-DD")]
  public DateTime DataDeNascimento { get; set; }

  [Required]
  [Description("Documentos do usuário, CPF ou CNPJ. Formatos: 'XXX.XXX.XXX-XX' ou 'XX.XXX.XXX/XXXX.XX', ou apenas numeros.")]
  public string CpfOuCnpj { get; set; }

  [Required]
  [Description("Telefone do usuário, deve conter o seguinte formato de um número brasileiro: (XX) XXXXX-XXXX, ou apenas numeros")]
  public string Telefone { get; set; }
}
