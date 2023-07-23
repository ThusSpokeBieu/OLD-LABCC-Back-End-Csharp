using LABCC.BackEnd.Application.DTO.Usuarios;
using System.ComponentModel;

namespace LABCC.BackEnd.Application.DTO.Colecoes;

public sealed class ColecaoDTOResponseOnlyId
{

  [DefaultValue(1)]
  [Description("Identificador da coleção.")]
  public long Id { get; set; }

  [DefaultValue("Fashion Odyssey")]
  [Description("Nome da coleção, no máximo 30 caracteres.")]
  public string NomeDaColecao { get; set; }

  [DefaultValue(2)]
  [Description("Responsável pela coleção")]
  public long ResponsavelId { get; set; }

  [DefaultValue("Fashion Odyssey")]
  [Description("Nome da Marca da coleção, no máximo 30 caracteres.")]
  public string Marca { get; set; }

  [DefaultValue(620622)]
  [Description("Orçamento da coleção, em R$.")]
  public decimal Orcamento { get; set; }

  [DefaultValue(2025)]
  [Description("Ano de lançamento da coleção.")]
  public int AnoDeLancamento { get; set; }

  [DefaultValue("Primavera")]
  [Description("Estação do Ano em que a coleção será lançada, pode ser apenas: 'Primavera', 'Inverno', 'Verão', ou 'Outono'. ")]
  public string Estacao { get; set; }

  [Description("Estado da coleção no sistema, pode ser 'Ativo' ou 'Inativo'")]
  public string Status { get; set; }
}

