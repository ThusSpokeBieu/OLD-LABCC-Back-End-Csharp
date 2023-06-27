using LABCC.BackEnd.Infrastructure.Repositories;
using LABCC.BackEnd.Domain.Entities.Modelos.Params;
using Microsoft.EntityFrameworkCore;

namespace LABCC.BackEnd.Domain.Entities.Modelos;

public class ModeloService
{
  private readonly ModeloRepository Repo;

  public ModeloService(ModeloRepository repo)
  {
    Repo = repo;
  }

  public async Task<Modelo> Add(Modelo novoModelo)
  {

    await Repo.Insert(novoModelo);

    var queryParam = new ModeloParams { NomeDoModelo = novoModelo.NomeDoModelo };
    var created = await Repo.Select(queryParam).FirstOrDefaultAsync();

    return created;
  }

  public async Task Delete(long id)
  {
    var modelo = await Repo.Select(id);

    if (modelo == null)
      throw new BadHttpRequestException($"O modelo de id {id} não existe para ser deletada", 400);

    if (modelo.StatusId != 0)
      throw new BadHttpRequestException($"O modelo de id {id} não está inativa. Apenas coleções inativas podem ser deletadas", 400);

    await Repo.Delete(id);
  }

  public async Task<IList<Modelo>> SelectAll()
  {
    return await Repo.Select().ToListAsync();
  }

  public async Task<IList<Modelo>> SelectAll(ModeloParams @params)
  {
    return await Repo.Select(@params).ToListAsync();
  }

  public async Task<Modelo?> SelectOneById(long id)
  {
    return await Repo.Select(id);
  }

  public async Task<Modelo?> FindFirstByParams(ModeloParams @params)
  {
    return await Repo.Select(@params).FirstOrDefaultAsync();
  }

  public async Task<Modelo?> Update(long id, ModeloParams param)
  {
    await Repo.Update(id, param);
    return await Repo.Select(id);
  }
}
