using LABCC.BackEnd.Domain.Entities.Colecoes;
using LABCC.BackEnd.Domain.Entities.EntidadesBase;
using LABCC.BackEnd.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace LABCC.BackEnd.Domain.Entities.Modelos;

public sealed class Modelo : AggregateRoot<long>
{
    [Required]
    public string? NomeDoModelo { get; set; }

    [Required]
    public long? ColecaoId { get; set; }

    [Required]
    public Colecao? Colecao { get; set; }

    [Required]
    public byte TipoDeModeloId { get; set; }

    [Required]
    public TipoDeModelo? TipoDeModelo { get; set; }

    [Required]
    public byte? LayoutId { get; set; }

    [Required]
    public ModeloLayout? Layout { get; set; }
}
