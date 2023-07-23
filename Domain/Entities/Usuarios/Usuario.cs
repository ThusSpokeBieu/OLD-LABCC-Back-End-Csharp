using LABCC.BackEnd.Domain.Entities.EntidadesBase;
using LABCC.BackEnd.Domain.ValueObjects;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;

namespace LABCC.BackEnd.Domain.Entities.Usuarios;

public sealed class Usuario : Pessoa, IUser<string>
{
    public override string Id { get; set; }
    
    [Required]
    [EmailAddress]
    [Description("E-mail do usuário")]  
    public string? UserName { get; set; }

    public string? Senha { get; set; }

    [Required]
    [Description("Tipo de Usuário, 1 - Administrador, 2 - Gerente, 3 - Criador, 4 - Outro")]
    public byte? TipoDeUsuarioId { get; set; }

    public TipoDeUsuario? TipoDeUsuario { get; set; }
}
