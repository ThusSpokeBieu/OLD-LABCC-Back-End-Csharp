using LABCC.BackEnd.Domain.Entities.Usuarios;
using LABCC.BackEnd.Domain.Entities.Usuarios.Interfaces;
using LABCC.BackEnd.Domain.Entities.Usuarios.Params;
using LABCC.BackEnd.Domain.Enum;
using LABCC.BackEnd.Infrastructure.Context;
using LABCC.BackEnd.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text.RegularExpressions;

namespace LABCC.BackEnd.Infrastructure.Repositories;

public sealed class UsuarioRepository : IUsuarioRepository
{
  private readonly MsSqlContext _db;
  private readonly Regex NotNumeric = RegexConst.NotNumericalDigitRegex();

  public UsuarioRepository(MsSqlContext db)
  {
    _db = db;
  }

  public IQueryable<Usuario> Select() => _db.Usuarios
      .Include(u => u.Genero)
      .Include(u => u.Status)
      .Include(u => u.TipoDeUsuario);

  public async Task<Usuario?> Select(long id) => await _db.Usuarios.FindAsync(id);

  public IQueryable<Usuario> Select(UsuarioParams @params)
  {
    IQueryable<Usuario> query = _db.Usuarios
      .Include(u => u.Genero)
      .Include(u => u.Status)
      .Include(u => u.TipoDeUsuario);

    if(@params.Id.HasValue) query = query.Where(u => u.Id == @params.Id);
    
    if(!@params.Nome.IsNullOrEmpty()) query = query
        .Where(u => u.Nome.ToLower().Equals(@params.Nome!.ToLower()));

    if(!@params.Email.IsNullOrEmpty()) query = query
        .Where(u => u.Email.ToLower().Equals(@params.Email!.ToLower()));

    if (!@params.CpfOuCnpj.IsNullOrEmpty()) query = query
        .Where(u => u.CpfOuCnpj
          .Equals(NotNumeric.Replace(@params.CpfOuCnpj!, "")));

    if (!@params.Telefone.IsNullOrEmpty()) query = query
        .Where(u => u.Telefone
          .Equals(NotNumeric.Replace(@params.Telefone!, "")));

    if (!@params.Genero.IsNullOrEmpty()) query = query
        .Where(u => u.Genero.Value.ToLower().Equals(@params.Genero!.ToLower()));

    if (!@params.Status.IsNullOrEmpty()) query = query
        .Where(u => u.Status.Value.ToLower().Equals(@params.Status!.ToLower()));

    if (!@params.TipoDeUsuario.IsNullOrEmpty()) query = query
        .Where(u => u.TipoDeUsuario.Value
            .ToLower().Equals(@params.TipoDeUsuario!.ToLower()));

    if (@params.TipoDeUsuarioId.HasValue) query = query
        .Where(u => u.TipoDeUsuarioId == @params.TipoDeUsuarioId);

    if(@params.StatusId.HasValue) query = query
        .Where(u => u.StatusId == @params.StatusId);

    if(@params.GeneroId.HasValue) query = query
        .Where(u => u.GeneroId == @params.GeneroId);

    if (@params.DataDeNascimento.HasValue) query = query
        .Where(u => u.DataDeNascimento == new DateTime(
              @params.DataDeNascimento.Value.Year,
              @params.DataDeNascimento.Value.Month,
              @params.DataDeNascimento.Value.Day));

    return query;

  }

  async public Task Insert(Usuario obj)
  {
    try
    {
      await _db.Usuarios.AddAsync(obj);
      await _db.SaveChangesAsync();
    } catch (Exception ex) 
    {
      if(ex.InnerException != null)
      {
        var innerExceptionMessage = ex.InnerException.Message;
        var innerExceptionStackTrace = ex.InnerException.StackTrace;
        Console.WriteLine($"Inner Exception Message: {innerExceptionMessage}");
        Console.WriteLine($"Inner Exception Stack Trace: {innerExceptionStackTrace}");
      }

      throw;
    }
  }

  async public Task Update(long id, UsuarioParams @params)
  {
    Usuario? user = await _db.Usuarios.FindAsync(id) ?? throw new ArgumentException("Usuário não foi encontrado");
    
    if (!@params.Nome.IsNullOrEmpty()) 
      user.Nome = @params.Nome!;

    if (!@params.Email.IsNullOrEmpty())
      user.Email = @params.Email!;

    if (!@params.CpfOuCnpj.IsNullOrEmpty())
      user.CpfOuCnpj = NotNumeric.Replace(@params.CpfOuCnpj!, "");

    if (!@params.Telefone.IsNullOrEmpty())
      user.Telefone = NotNumeric.Replace(@params.Telefone!, "");

    if (!@params.Genero.IsNullOrEmpty())
      user.GeneroId = (byte) (GeneroEnum) StringEnumConverter
        .StringToEnum(@params.Genero!, typeof(GeneroEnum));

    if (!@params.Status.IsNullOrEmpty())
      user.StatusId = (byte) (StatusEnum) StringEnumConverter
        .StringToEnum(@params.Status!, typeof(StatusEnum));

    if (!@params.TipoDeUsuario.IsNullOrEmpty())
      user.TipoDeUsuarioId = (byte) (TipoDeUsuarioEnum) StringEnumConverter
        .StringToEnum(@params.TipoDeUsuario!, typeof(TipoDeUsuarioEnum));
    
    if (@params.DataDeNascimento.HasValue)
      user.DataDeNascimento = new DateTime(
              @params.DataDeNascimento.Value.Year,
              @params.DataDeNascimento.Value.Month,
              @params.DataDeNascimento.Value.Day);

    await _db.SaveChangesAsync();
  }

  async public Task Delete(long id)
  {
    Usuario? user = await _db.Usuarios.FirstOrDefaultAsync(user => user.Id == id) ?? throw new ArgumentException("User does not exist or is already inactive");
    _db.Usuarios.Remove(user);

    await _db.SaveChangesAsync();
  }

  async public Task Activate(long id)
  {
    Usuario? user = await _db.Usuarios
      .FirstOrDefaultAsync(user => user.Id == id) ?? throw new ArgumentException("User does not exist");

    if (user.StatusId == 1) 
      throw new ArgumentException($"The user: ${user.Nome}, id: ${user.Id} is already active.");

    user.StatusId = 1;

    await _db.SaveChangesAsync();
  }
}
