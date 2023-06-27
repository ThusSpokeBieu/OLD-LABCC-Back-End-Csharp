using LABCC.BackEnd.Domain.Entities.EntidadesBase.Interfaces;
using LABCC.BackEnd.Domain.Validators.DataTypeAttributes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LABCC.BackEnd.Domain.Entities.Colecoes.Params;

public class ColecaoParams : IParams
{
  [JsonIgnore]
  public long? Id { get; set; }

  [MaxLength(30, ErrorMessage = " {0} deve possuir no máximo 30 caracteres. ")]
  [DefaultValue("Fashion Odyssey")]
  [Description("Nome da coleção, no máximo 30 caracteres.")]
  public string? NomeDaColecao { get; set; }

  [DefaultValue(1)]
  [Description("Id do responsável pela coleção")]
  public long? ResponsavelId { get; set; }

  [MaxLength(30, ErrorMessage = " {0} deve possuir no máximo 30 caracteres. ")]
  [DefaultValue("Fashion Odyssey")]
  [Description("Nome da Marca da coleção, no máximo 30 caracteres.")]
  public string? Marca { get; set; }

  [DefaultValue(620622)]
  [Description("Orçamento da coleção, em R$.")]
  public decimal? Orcamento { get; set; }

  [Description("Ano de lançamento da coleção")]
  [DefaultValue(2026)]
  public int? AnoDeLancamento { get; set; }

  [JsonIgnore]
  public byte? EstacaoId { get; set; }

  [EstacoesDoAno]
  [DefaultValue("Primavera")]
  [Description("Estação do Ano em que a coleção será lançada, pode ser apenas: 'Primavera', 'Inverno', 'Verão', ou 'Outono'. ")]
  public string? Estacao { get; set; }

  [JsonIgnore]
  public byte? StatusId { get; set; }

  [JsonIgnore]
  [Status]
  [MaxLength(10, ErrorMessage = " {0} deve possuir no máximo 10 caracteres. ")]
  [DefaultValue("Ativo")]
  public string? Status { get; set; }

}
