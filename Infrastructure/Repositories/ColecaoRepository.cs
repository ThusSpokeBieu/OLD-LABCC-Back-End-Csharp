using LABCC.BackEnd.Domain.Entities.Colecoes;
using LABCC.BackEnd.Domain.Entities.Colecoes.Interfaces;
using LABCC.BackEnd.Domain.Entities.Colecoes.Params;
using LABCC.BackEnd.Domain.Enum;
using LABCC.BackEnd.Infrastructure.Context;
using LABCC.BackEnd.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace LABCC.BackEnd.Infrastructure.Repositories;

public sealed class ColecaoRepository : IColecaoRepository
{
    private readonly MsSqlContext _db;

    public ColecaoRepository(MsSqlContext db)
    {
        _db = db;
    }

    public IQueryable<Colecao> Select() =>
        _db.Colecoes
            .Include(c => c.Estacao)
            .Include(c => c.Responsavel)
            .Include(c => c.Responsavel!.Genero)
            .Include(c => c.Responsavel!.Status)
            .Include(c => c.Responsavel!.TipoDeUsuario)
            .Include(c => c.Status);

    public async Task<Colecao?> Select(long id) =>
        await Select().FirstOrDefaultAsync(user => user.Id == id);

    public IQueryable<Colecao> Select(ColecaoParams? @params)
    {
        IQueryable<Colecao> query = Select();

        if (@params == null)
            return query;

        if (@params.Id != null)
            query = query.Where(c => c.Id == @params.Id);

        if (!@params.NomeDaColecao.IsNullOrEmpty())
            query = query.Where(
                c => c.NomeDaColecao.ToLower().Equals(@params.NomeDaColecao!.ToLower())
            );

        if (!@params.Marca.IsNullOrEmpty())
            query = query.Where(c => c.Marca.ToLower().Equals(@params.Marca!.ToLower()));

        if (@params.ResponsavelId.HasValue)
            query = query.Where(c => c.ResponsavelId == @params.ResponsavelId);

        if (!@params.Status.IsNullOrEmpty())
            query = query.Where(c => c.Status!.Value.ToLower().Equals(@params.Status!.ToLower()));

        if (@params.StatusId.HasValue)
            query = query.Where(c => c.StatusId == @params.StatusId);

        if (!@params.Estacao.IsNullOrEmpty())
            query = query.Where(c => c.Estacao.Value.ToLower().Equals(@params.Estacao!.ToLower()));

        if (@params.AnoDeLancamento.HasValue)
            query = query.Where(c => c.AnoDeLancamento == @params.AnoDeLancamento);

        return query;
    }

    public async Task Delete(long id)
    {
        var colecao = _db.Colecoes.Find(id);

        if (colecao != null)
        {
            _db.Colecoes.Remove(colecao);
            await _db.SaveChangesAsync();
        }
    }

    public async Task Insert(Colecao obj)
    {
        try
        {
            await _db.Colecoes.AddAsync(obj);
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

    public async Task Update(long id, ColecaoParams @params)
    {
        Colecao? colecao =
            await Select(id) ?? throw new ArgumentException("Coleção não foi encontrada pelo ID");

        if (!@params.NomeDaColecao.IsNullOrEmpty())
            colecao.NomeDaColecao = @params.NomeDaColecao!;

        if (!@params.Marca.IsNullOrEmpty())
            colecao.Marca = @params.Marca!;

        if (@params.ResponsavelId.HasValue)
            colecao.ResponsavelId = @params.ResponsavelId.Value;

        if (!@params.Status.IsNullOrEmpty())
            colecao.StatusId = (byte)
                (StatusEnum)StringEnumConverter.StringToEnum(@params.Status!, typeof(StatusEnum));

        if (!@params.Estacao.IsNullOrEmpty())
            colecao.EstacaoId = (byte)
                (EstacoesEnum)
                    StringEnumConverter.StringToEnum(@params.Estacao!, typeof(EstacoesEnum));

        if (@params.AnoDeLancamento.HasValue)
            colecao.AnoDeLancamento = @params.AnoDeLancamento!.Value;

        if (@params.Orcamento.HasValue)
            colecao.Orcamento = @params.Orcamento!.Value;

        await _db.SaveChangesAsync();
    }
}
