using AutoMapper;
using LABCC.BackEnd.Application.DTO.Usuarios;
using LABCC.BackEnd.Domain.Entities.Usuarios;
using LABCC.BackEnd.Domain.Entities.Usuarios.Interfaces;
using LABCC.BackEnd.Domain.Params;

namespace LABCC.BackEnd.Application.UseCases;

  public class UsuarioUseCases
  {

    private readonly IUsuarioService Service;
    private readonly IMapper Mapper;

    public UsuarioUseCases(
      IUsuarioService service, 
      IMapper mapper)
    {
      Service = service;
      Mapper = mapper;
    }

  async public Task<ICollection<UsuarioDTOResponse>> GetAll(UsuarioParamsWithoutDefault? param)
    {
      try
      {
        var mappedParam = Mapper.Map<UsuarioParams>(param);
        var usuarioLista = await Service.SelectAllByQueryParams(mappedParam);
        return Mapper.Map<List<UsuarioDTOResponse>>(usuarioLista);

      } catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

  async public Task<UsuarioDTOResponse> GetById(long id)
  {
    try
    {
      var usuario = await Service.SelectOneById(id);

      if (usuario == null) return null;

      return Mapper.Map<UsuarioDTOResponse>(usuario);
    } catch (Exception e)
    {
      throw new Exception(e.Message);
    }
  }

  async public Task<UsuarioDTOResponse> CreateUser(UsuarioDTO newUser)
  {
    try
    {
      var user = Mapper.Map<Usuario>(newUser);
    
      var persistedUser = await Service.Add(user);
      if (persistedUser == null) return null;
      return Mapper.Map<UsuarioDTOResponse>(persistedUser);
    } catch(Exception e)
    {
      throw new Exception($"{e.Message}");
    }
  }

  async public Task<UsuarioDTOResponse> FindFirstByParam(UsuarioParams param)
  {
    try
    {
      var user = await Service.SelectOneByQueryParams(param);
      if (user == null) return null;
      return Mapper.Map<UsuarioDTOResponse>(user);
    }
    catch (Exception e)
    {
      throw new Exception($"{e.Message}");
    }
  }

  async public Task<UsuarioDTOResponse> Update(long id, UsuarioParams param)
  {
    try
    {
      await Service.Update(id, param);
      var updatedUser = await Service.SelectOneById(id);
      return Mapper.Map<UsuarioDTOResponse>(updatedUser);
    }
    catch (Exception e)
    {
      throw new Exception($"{e.Message}");
    }
  }

  async public Task DeleteById(long id)
  {
    try
    {
      await Service.Delete(id);
    }
    catch (Exception e)
    {
      throw new Exception($"{e.Message}");
    }
  }

}
