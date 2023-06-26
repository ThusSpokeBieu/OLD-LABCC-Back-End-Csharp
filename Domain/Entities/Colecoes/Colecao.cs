using LABCC.BackEnd.Domain.Entities.EntidadesBase;
using LABCC.BackEnd.Domain.Entities.Usuarios;
using LABCC.BackEnd.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace LABCC.BackEnd.Domain.Entities.Colecoes;

public class Colecao : AggregateRoot
{
  [Required]
  public string NomeDaColecao { get; set; }

  [Required]

  public long ResponsavelId { get; set; }

  public Usuario? Responsavel { get; set; }

  [Required]

  public string Marca { get; set; }

  [Required]

  public decimal Orcamento { get; set; }

  [Required]

  public int AnoDeLancamento { get; set; }

  [Required]
  public byte EstacaoId { get; set; }

  [Required]
  public EstacoesDoAno Estacao { get; set; }


}