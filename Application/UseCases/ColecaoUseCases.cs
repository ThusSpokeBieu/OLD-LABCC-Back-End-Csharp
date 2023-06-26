using AutoMapper;
using LABCC.BackEnd.Application.DTO.Colecoes;
using LABCC.BackEnd.Application.DTO.Usuarios;
using LABCC.BackEnd.Domain.Entities.Colecoes;
using LABCC.BackEnd.Domain.Entities.Colecoes.Params;
using LABCC.BackEnd.Domain.Entities.EntidadesBase.Interfaces;
using LABCC.BackEnd.Domain.Entities.Usuarios.Params;

namespace LABCC.BackEnd.Application.UseCases;

public class ColecaoUseCases
{

  private readonly ColecaoService Service;
  private readonly IMapper Mapper;

  public ColecaoUseCases(
    ColecaoService service,
    IMapper mapper)
  {
    Service = service;
    Mapper = mapper;
  }

  async public Task<ICollection<ColecaoDTOResponse>> GetAll()
  {
    try
    {
      var colecaoLista = await Service.SelectAll();
      return Mapper.Map<List<ColecaoDTOResponse>>(colecaoLista);

    }
    catch (Exception e)
    {
      throw new Exception(e.Message);
    }
  }

  async public Task<ICollection<ColecaoDTOResponse>> GetAll(ColecaoParams @params)
  {
    try
    {
      var colecaoLista = await Service.SelectAll(@params);
      return Mapper.Map<List<ColecaoDTOResponse>>(colecaoLista);

    }
    catch (Exception e)
    {
      throw new Exception(e.Message);
    }
  }

  async public Task<ColecaoDTOResponse> GetById(long id)
  {
    try
    {
      var colecao = await Service.SelectOneById(id);

      if (colecao == null) return null;

      return Mapper.Map<ColecaoDTOResponse>(colecao);
    }
    catch (Exception e)
    {
      throw new Exception(e.Message);
    }
  }

  async public Task<ColecaoDTOResponse> Create(ColecaoDTO newCollection)
  {
    try
    {
      var collection = Mapper.Map<Colecao>(newCollection);

      var persistedCollection = await Service.Add(collection);
      if (persistedCollection == null) return null;
      return Mapper.Map<ColecaoDTOResponse>(persistedCollection);
    }
    catch (Exception e)
    {
      throw new Exception($"{e.Message}");
    }
  }

  async public Task<ColecaoDTOResponse> FindFirstByParams(ColecaoParams param)
  {
    try
    {
      var colecao = await Service.FindFirstByParams(param);
      if (colecao == null) return null;
      return Mapper.Map<ColecaoDTOResponse>(colecao);
    }
    catch (Exception e)
    {
      throw new Exception($"{e.Message}");
    }
  }

  async public Task<ColecaoDTOResponse?> Update(long id, ColecaoParams @params)
  {
    try
    {
      await Service.Update(id, @params);
      var updatedCollection = await Service.SelectOneById(id);

      return Mapper.Map<ColecaoDTOResponse>(updatedCollection);
    }
    catch (Exception e)
    {
      throw new Exception($"{e.Message}");
    }
  }

  public async Task Delete(long id)
  {
    await Service.Delete(id);
  }
}
