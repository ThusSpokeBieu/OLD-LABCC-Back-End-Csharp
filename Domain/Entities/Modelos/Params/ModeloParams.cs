using LABCC.BackEnd.Domain.Entities.EntidadesBase.Interfaces;
using LABCC.BackEnd.Domain.Validators.DataTypeAttributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace LABCC.BackEnd.Domain.Entities.Modelos.Params;

public class ModeloParams : IParams
{
    [JsonIgnore]
    public long? Id { get; set; }

    [Required(ErrorMessage = "{0} é obrigatório.")]
    [MaxLength(50, ErrorMessage = " {0} deve possuir no máximo 50 caracteres. ")]
    [DefaultValue("Camiseta Muito Bacana")]
    [Description("Nome do modelo, no máximo 50 caracteres.")]
    public string? NomeDoModelo { get; set; }

    [Required(ErrorMessage = "{0} é obrigatório.")]
    [DefaultValue(2)]
    [Description("Identificador da coleção do modelo")]
    public long? ColecaoId { get; set; }

    [JsonIgnore]
    public string? Colecao { get; set; }

    [JsonIgnore]
    public byte? TipoDeModeloId { get; set; }

    [TipoDeModelo]
    [Required(ErrorMessage = "{0} é obrigatório.")]
    [MaxLength(20, ErrorMessage = " {0} deve possuir no máximo 20 caracteres. ")]
    [DefaultValue("Camisa")]
    [Description(
        "Tipo do modelo, opções disponíveis: 'Bermuda', 'Biquini', 'Bolsa', 'Boné', 'Calça', 'Calçados', 'Camisa', 'Chapéu' ou 'Saia'."
    )]
    public string? TipoDeModelo { get; set; }

    [JsonIgnore]
    public byte? LayoutId { get; set; }

    [ModeloLayout]
    [Required(ErrorMessage = "{0} é obrigatório.")]
    [MaxLength(20, ErrorMessage = " {0} deve possuir no máximo 20 caracteres. ")]
    [DefaultValue("Bordado")]
    [Description("Bordado do modelo, opções válidas: 'Bordado', 'Estampa' ou 'Liso'.")]
    public string? Layout { get; set; }

    [JsonIgnore]
    public byte? StatusId { get; set; }

    [Status]
    [Required(ErrorMessage = "{0} é obrigatório.")]
    [MaxLength(10, ErrorMessage = " {0} deve possuir no máximo 10 caracteres. ")]
    [DefaultValue("Ativo")]
    [Description("Estado da coleção no sistema, pode ser 'Ativo' ou 'Inativo'")]
    public string? Status { get; set; }
}
