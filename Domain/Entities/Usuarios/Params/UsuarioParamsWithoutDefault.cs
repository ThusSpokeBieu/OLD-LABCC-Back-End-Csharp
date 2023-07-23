using Gmess.SharperAnnotationsForDataType.Attributes;
using LABCC.BackEnd.Domain.Validators.DataTypeAttributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.Json.Serialization;
using LABCC.BackEnd.Domain.Entities.EntidadesBase.Interfaces;

namespace LABCC.BackEnd.Domain.Entities.Usuarios.Params;

public class UsuarioParamsWithoutDefault : IParams
{
    [JsonIgnore]
    public long? Id { get; set; }

    [MaxLength(80, ErrorMessage = " {0} deve possuir no máximo 80 caracteres. ")]
    [Description("Nome da pessoa ou usuário.")]
    public string? Nome { get; set; }

    [EmailAddress(ErrorMessage = "Por favor, insira um {0} correto.")]
    [MaxLength(100, ErrorMessage = " {0} deve possuir no máximo 100 caracteres. ")]
    public string? Email { get; set; }

    [JsonIgnore]
    public byte? TipoDeUsuarioId { get; set; }

    [TipoDeUsuario]
    [MaxLength(15, ErrorMessage = " {0} deve possuir no máximo 15 caracteres. ")]
    public string? TipoDeUsuario { get; set; }

    [MaxLength(18, ErrorMessage = " {0} deve possuir no máximo 18 caracteres. ")]
    [CpfOrCnpjDocument(
        ErrorMessage = "{0} deve ser um CPF ou CNPJ válido do formato: 'XXX.XXX.XXX-XX' ou 'XX.XXX.XXX/XXXX.XX'."
    )]
    public string? CpfOuCnpj { get; set; }

    [JsonIgnore]
    public byte? GeneroId { get; set; }

    [MaxLength(10, ErrorMessage = " {0} deve possuir no máximo 10 caracteres. ")]
    [GeneroPortugues]
    public string? Genero { get; set; }

    public DateOnly? DataDeNascimento { get; set; }

    [MaxLength(16, ErrorMessage = " {0} deve possuir no máximo 16 caracteres. ")]
    [BrazilPhoneNumber(
        ErrorMessage = "O {0} deve ser um número brasileiro válido: (XX) XXXXX-XXXX ou (XX) XXXX-XXXX"
    )]
    public string? Telefone { get; set; }

    [JsonIgnore]
    public byte? StatusId { get; set; }

    [JsonIgnore]
    [Status]
    [MaxLength(10, ErrorMessage = " {0} deve possuir no máximo 10 caracteres. ")]
    public string? Status { get; set; }
}
