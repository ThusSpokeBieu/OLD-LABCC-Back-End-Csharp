namespace LABCC.BackEnd.Domain.Params;

public class UsuarioParams : IParams
{
    public long? Id { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public byte? TipoDeUsuarioId { get; set; }
    public string? TipoDeUsuario { get; set; }
    public string? CpfOuCnpj { get; set; }
    public byte? GeneroId { get; set; }
    public string? Genero { get; set; }
    public DateOnly? DataDeNascimento { get; set; }
    public string? Telefone { get; set; }
    public byte? StatusId { get; set; }
    public string? Status { get; set; }
}
