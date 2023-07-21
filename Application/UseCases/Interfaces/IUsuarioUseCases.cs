using LABCC.BackEnd.Application.DTO.Usuarios;
using LABCC.BackEnd.Domain.Entities.Usuarios.Params;

namespace LABCC.BackEnd.Application.UseCases.Interfaces;

public interface IUsuarioUseCases
{
    public Task<ICollection<UsuarioDTOResponse>> GetAll(UsuarioParamsWithoutDefault? param);
    public Task<UsuarioDTOResponse> GetById(long id);
    public Task<UsuarioDTOResponse> CreateUser(UsuarioDTO newUser);
    public Task<UsuarioDTOResponse> FindFirstByParam(UsuarioParams param);
    public Task<UsuarioDTOResponse> Update(long id, UsuarioParams param);
    public Task DeleteById(long id);
}
