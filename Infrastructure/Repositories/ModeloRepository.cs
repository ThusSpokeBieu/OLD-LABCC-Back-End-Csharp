using LABCC.BackEnd.Domain.Entities.Modelos;
using LABCC.BackEnd.Domain.Entities.Modelos.Interfaces;
using LABCC.BackEnd.Domain.Entities.Modelos.Params;
using LABCC.BackEnd.Domain.Enum;
using LABCC.BackEnd.Infrastructure.Context;
using LABCC.BackEnd.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace LABCC.BackEnd.Infrastructure.Repositories;

public class ModeloRepository : IModeloRepository
{

  private readonly MsSqlContext _db;

  public ModeloRepository(MsSqlContext db)
  {
    _db = db;
  }

  public IQueryable<Modelo> Select() => _db.Modelos
      .Include(m => m.TipoDeModelo)
      .Include(m => m.Layout)
      .Include(m => m.Colecao)
      .Include(m => m.Colecao.Estacao)
      .Include(m => m.Colecao.Status)
      .Include(m => m.Status);

  public async Task<Modelo?> Select(long id) => await Select()
    .FirstOrDefaultAsync(user => user.Id == id);

  public IQueryable<Modelo> Select(ModeloParams? @params)
  {
    IQueryable<Modelo> query = Select();

    if (@params == null) return query;

    if (@params.Id != null) query = query.Where(c => c.Id == @params.Id);

    if (!@params.NomeDoModelo.IsNullOrEmpty()) query = query
        .Where(m => m.NomeDoModelo.ToLower().Equals(@params.NomeDoModelo!.ToLower()));

    if (@params.ColecaoId.HasValue) query = query
        .Where(m => m.ColecaoId == @params.ColecaoId);

    if (!@params.Colecao.IsNullOrEmpty()) query = query
        .Where(m => m.Colecao.NomeDaColecao.ToLower().Equals(@params.Colecao!.ToLower()));

    if (!@params.Status.IsNullOrEmpty()) query = query
        .Where(m => m.Status.Value.ToLower().Equals(@params.Status!.ToLower()));

    if (@params.StatusId.HasValue) query = query
        .Where(m => m.StatusId == @params.StatusId);

    if (!@params.TipoDeModelo.IsNullOrEmpty()) query = query
    .Where(m => m.TipoDeModelo.Value.ToLower().Equals(@params.TipoDeModelo!.ToLower()));

    if (@params.TipoDeModeloId.HasValue) query = query
        .Where(m => m.TipoDeModeloId == @params.TipoDeModeloId);

    if (!@params.Layout.IsNullOrEmpty()) query = query
    .Where(m => m.Layout.Value.ToLower().Equals(@params.Layout!.ToLower()));

    if (@params.LayoutId.HasValue) query = query
        .Where(m => m.LayoutId == @params.LayoutId);

    return query;
  }

  async public Task Delete(long id)
  {
    var modelo = _db.Modelos.Find(id);

    if (modelo != null)
    {
      _db.Modelos.Remove(modelo);
      await _db.SaveChangesAsync();
    }
  }

  async public Task Insert(Modelo obj)
  {
    try
    {
      await _db.Modelos.AddAsync(obj);
      await _db.SaveChangesAsync();
    }
    catch (Exception ex)
    {
      if (ex.InnerException != null)
      {
        var innerExceptionMessage = ex.InnerException.Message;
        var innerExceptionStackTrace = ex.InnerException.StackTrace;
        Console.WriteLine($"Inner Exception Message: {innerExceptionMessage}");
        Console.WriteLine($"Inner Exception Stack Trace: {innerExceptionStackTrace}");
      }

      throw;
    }
  }

  async public Task Update(long id, ModeloParams @params)
  {
    Modelo? modelo = await Select(id) ?? throw new ArgumentException($"Modelo não foi encontrada pelo ID {id}");

    if (!@params.NomeDoModelo.IsNullOrEmpty())
      modelo.NomeDoModelo = @params.NomeDoModelo!;

    if (@params.ColecaoId.HasValue)
      modelo.ColecaoId = @params.ColecaoId!.Value;

    if (!@params.Status.IsNullOrEmpty())
      modelo.StatusId = (byte) (StatusEnum) StringEnumConverter
        .StringToEnum(@params.Status!, typeof(StatusEnum));

    if (!@params.TipoDeModelo.IsNullOrEmpty())
      modelo.TipoDeModeloId = (byte) (TipoDeModeloEnum) StringEnumConverter
        .StringToEnum(@params.TipoDeModelo!, typeof(TipoDeModeloEnum));

    if (!@params.Layout.IsNullOrEmpty())
      modelo.LayoutId = (byte)(ModeloLayoutEnum)StringEnumConverter
        .StringToEnum(@params.Layout!, typeof(ModeloLayoutEnum));

    await _db.SaveChangesAsync();
  }
}
