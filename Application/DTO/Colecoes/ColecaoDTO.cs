using LABCC.BackEnd.Domain.Validators.DataTypeAttributes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LABCC.BackEnd.Application.DTO.Colecoes;

public sealed class ColecaoDTO
{
  [Required(ErrorMessage = "{0} é obrigatório.")]
  [MaxLength(30, ErrorMessage = " {0} deve possuir no máximo 30 caracteres. ")]
  [DefaultValue("Fashion Odyssey")]
  [Description("Nome da coleção, no máximo 30 caracteres.")]
  public string NomeDaColecao { get; set; }

  [Required(ErrorMessage = "{0} é obrigatório.")]
  [DefaultValue(2)]
  [Description("Id do responsável pela coleção")]
  public long ResponsavelId { get; set; }

  [Required(ErrorMessage = "{0} é obrigatório.")]
  [MaxLength(30, ErrorMessage = " {0} deve possuir no máximo 30 caracteres. ")]
  [DefaultValue("Fashion Odyssey")]
  [Description("Nome da Marca da coleção, no máximo 30 caracteres.")]
  public string Marca { get; set; }

  [Required(ErrorMessage = "{0} é obrigatório.")]
  [DefaultValue(620622)]
  [Description("Orçamento da coleção, em R$.")]
  public decimal Orcamento { get; set; }

  [Required(ErrorMessage = "{0} é obrigatório.")]
  [Description("Ano de lançamento da coleção")]
  [DefaultValue(2026)]
  public int AnoDeLancamento { get; set; }

  [Required(ErrorMessage = "{0} é obrigatório.")]
  [EstacoesDoAno]
  [DefaultValue("Primavera")]
  [Description("Estação do Ano em que a coleção será lançada, pode ser apenas: 'Primavera', 'Inverno', 'Verão', ou 'Outono'. ")]
  public string Estacao { get; set; }

  [Required(ErrorMessage = "{0} é obrigatório.")]
  [Status]
  [MaxLength(10, ErrorMessage = " {0} deve possuir no máximo 10 caracteres. ")]
  [DefaultValue("Ativo")]
  [Description("Estado da coleção no sistema, pode ser 'Ativo' ou 'Inativo'")]
  public string Status { get; set; }
}
