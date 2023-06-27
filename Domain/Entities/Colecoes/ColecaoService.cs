using LABCC.BackEnd.Domain.Entities.Colecoes.Interfaces;
using LABCC.BackEnd.Domain.Entities.Colecoes.Params;
using LABCC.BackEnd.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LABCC.BackEnd.Domain.Entities.Colecoes;

public class ColecaoService : IColecaoService
{
  private readonly ColecaoRepository Repo;

  public ColecaoService(ColecaoRepository repo)
  {
    Repo = repo;
  }

  public async Task<Colecao> Add(Colecao novaColecao)
  {
    
    await Repo.Insert(novaColecao);

    var queryParam = new ColecaoParams { NomeDaColecao = novaColecao.NomeDaColecao };
    var created = await Repo.Select(queryParam).FirstOrDefaultAsync();

    return created;
  }

  public async Task Delete(long id)
  {
    var colecao = await Repo.Select(id);

    if (colecao == null) 
      throw new BadHttpRequestException($"A coleção de id {id} não existe para ser deletada", 400);

    if (colecao.StatusId != 0)
      throw new BadHttpRequestException($"A coleção de id {id} não está inativa. Apenas coleções inativas podem ser deletadas", 400);

    await Repo.Delete(id);
  }

  public async Task<IList<Colecao>> SelectAll()
  {
    return await Repo.Select().ToListAsync();
  }

  public async Task<IList<Colecao>> SelectAll(ColecaoParams @params)
  {
    return await Repo.Select(@params).ToListAsync();
  }

  public async Task<Colecao?> SelectOneById(long id)
  {
    return await Repo.Select(id);
  }

  public async Task<Colecao?> FindFirstByParams(ColecaoParams @params)
  {
    return await Repo.Select(@params).FirstOrDefaultAsync();
  }

  public async Task<Colecao?> Update(long id, ColecaoParams param)
  {
    await Repo.Update(id, param);
    return await Repo.Select(id);
  }
}
