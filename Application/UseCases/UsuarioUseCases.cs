using AutoMapper;
using LABCC.BackEnd.Application.DTO.Usuarios;
using LABCC.BackEnd.Application.UseCases.Interfaces;
using LABCC.BackEnd.Domain.Entities.Usuarios;
using LABCC.BackEnd.Domain.Entities.Usuarios.Interfaces;
using LABCC.BackEnd.Domain.Entities.Usuarios.Params;
using Microsoft.AspNetCore.Identity;

namespace LABCC.BackEnd.Application.UseCases;

public sealed class UsuarioUseCases : IUsuarioUseCases
{
    private readonly IUsuarioService Service;
    private readonly IMapper Mapper;
    private readonly UserManager<Usuario> UserManager;
    private readonly SignInManager<Usuario> SignInManager;

    public UsuarioUseCases(
        IUsuarioService service, 
        IMapper mapper, 
        UserManager<Usuario> userManager, 
        SignInManager<Usuario> signInManager)
    {
        Service = service;
        Mapper = mapper;
        UserManager = userManager;
        SignInManager = signInManager;
    }

    public async Task<ICollection<UsuarioDTOResponse>> GetAll(UsuarioParamsWithoutDefault? param)
    {
        try
        {
            var mappedParam = Mapper.Map<UsuarioParams>(param);
            var usuarioLista = await Service.SelectAllByQueryParams(mappedParam);
            return Mapper.Map<List<UsuarioDTOResponse>>(usuarioLista);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<UsuarioDTOResponse> GetById(string id)
    {
        try
        {
            var usuario = await Service.SelectOneById(id);

            if (usuario == null)
                return null;

            return Mapper.Map<UsuarioDTOResponse>(usuario);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<UsuarioDTOResponse> CreateUser(UsuarioDTO newUser)
    {
        try
        {
            var user = Mapper.Map<Usuario>(newUser);

            var persistedUser = await Service.Add(user);
            if (persistedUser == null)
                return null;
            return Mapper.Map<UsuarioDTOResponse>(persistedUser);
        }
        catch (Exception e)
        {
            throw new Exception($"{e.Message}");
        }
    }

    public async Task<UsuarioDTOResponse> FindFirstByParam(UsuarioParams param)
    {
        try
        {
            var user = await Service.SelectOneByQueryParams(param);
            if (user == null)
                return null;
            return Mapper.Map<UsuarioDTOResponse>(user);
        }
        catch (Exception e)
        {
            throw new Exception($"{e.Message}");
        }
    }

    public async Task<UsuarioDTOResponse> Update(string id, UsuarioParams param)
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

    public async Task DeleteById(string id)
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
