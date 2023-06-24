using FluentValidation;
using LABCC.BackEnd.Domain.Entities.Usuarios.Interfaces;

namespace LABCC.BackEnd.Domain.Entities.Usuarios;
internal class UsuarioService : IUsuarioService
{

    public Task<Usuario> Add<TValidator>(Usuario obj) where TValidator : AbstractValidator<Usuario>
    {
        throw new NotImplementedException();
    }

    public Task Delete(long id)
    {
        throw new NotImplementedException();
    }

    public Task<Usuario> Get()
    {
        throw new NotImplementedException();
    }

    public Task<Usuario> GetById(long id)
    {
        throw new NotImplementedException();
    }

    public Task<Usuario> Update<TValidator>(Usuario obj) where TValidator : AbstractValidator<Usuario>
    {
        throw new NotImplementedException();
    }
}
