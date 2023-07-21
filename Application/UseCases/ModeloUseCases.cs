using AutoMapper;
using LABCC.BackEnd.Application.DTO;
using LABCC.BackEnd.Application.DTO.Modelos;
using LABCC.BackEnd.Application.UseCases.Interfaces;
using LABCC.BackEnd.Domain.Entities.Modelos;
using LABCC.BackEnd.Domain.Entities.Modelos.Interfaces;
using LABCC.BackEnd.Domain.Entities.Modelos.Params;

namespace LABCC.BackEnd.Application.UseCases;

public sealed class ModeloUseCases : IModeloUseCases
{ 
  private readonly IModeloService Service;
  private readonly IMapper Mapper;

  public ModeloUseCases(
    IModeloService service,
    IMapper mapper)
  {
    Service = service;
    Mapper = mapper;
  }

  async public Task<ICollection<ModeloDTOResponse>> GetAll()
  {
    try
    {
      var ModeloLista = await Service.SelectAll();
      return Mapper.Map<List<ModeloDTOResponse>>(ModeloLista);

    }
    catch (Exception e)
    {
      throw new Exception(e.Message);
    }
  }

  async public Task<ICollection<ModeloDTOResponse>> GetAll(ModeloParams @params)
  {
    try
    {
      var modeloLista = await Service.SelectAll(@params);
      return Mapper.Map<List<ModeloDTOResponse>>(modeloLista);

    }
    catch (Exception e)
    {
      throw new Exception(e.Message);
    }
  }

  async public Task<ModeloDTOResponse> GetById(long id)
  {
    try
    {
      var modelo = await Service.SelectOneById(id);

      if (modelo == null) return null;

      return Mapper.Map<ModeloDTOResponse>(modelo);
    }
    catch (Exception e)
    {
      throw new Exception(e.Message);
    }
  }

  async public Task<ModeloDTOResponse> Create(ModeloDTO newCollection)
  {
    try
    {
      var collection = Mapper.Map<Modelo>(newCollection);

      var persistedCollection = await Service.Add(collection);
      if (persistedCollection == null) return null;
      return Mapper.Map<ModeloDTOResponse>(persistedCollection);
    }
    catch (Exception e)
    {
      throw new Exception($"{e.Message}");
    }
  }

  async public Task<ModeloDTOResponse> FindFirstByParams(ModeloParams param)
  {
    try
    {
      var modelo = await Service.FindFirstByParams(param);
      if (modelo == null) return null;
      return Mapper.Map<ModeloDTOResponse>(modelo);
    }
    catch (Exception e)
    {
      throw new Exception($"{e.Message}");
    }
  }

  async public Task<ModeloDTOResponse?> Update(long id, ModeloParams @params)
  {
    try
    {
      await Service.Update(id, @params);
      var modeloAtualizado = await Service.SelectOneById(id);

      return Mapper.Map<ModeloDTOResponse>(modeloAtualizado);
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
