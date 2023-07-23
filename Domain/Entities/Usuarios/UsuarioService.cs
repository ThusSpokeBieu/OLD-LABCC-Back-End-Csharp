using LABCC.BackEnd.Domain.Entities.Usuarios.Interfaces;
using LABCC.BackEnd.Domain.Entities.Usuarios.Params;
using Microsoft.EntityFrameworkCore;

namespace LABCC.BackEnd.Domain.Entities.Usuarios;

public sealed class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository Repo;

    public UsuarioService(IUsuarioRepository repo)
    {
        Repo = repo;
    }

    public async Task<Usuario> Add(Usuario usuario)
    {
        await Repo.Insert(usuario);
        return await SelectOneByCpfOrCnpj(usuario.CpfOuCnpj);
    }

    public async Task Delete(string id)
    {
        await Repo.Delete(id);
    }

    public async Task<IList<Usuario>> SelectAll()
    {
        return await Repo.Select().ToListAsync();
    }

    public async Task<Usuario?> SelectOneById(string id)
    {
        var param = new UsuarioParams { Id = id };
        var found = await Repo.Select(param).FirstOrDefaultAsync();

        if (found != null)
            return found;
        return null;
    }

    public async Task<Usuario?> SelectOneByCpfOrCnpj(string cpfOuCnpj)
    {
        var param = new UsuarioParams { CpfOuCnpj = cpfOuCnpj };
        var found = await Repo.Select(param).FirstOrDefaultAsync();

        if (found != null)
            return found;
        return null;
    }

    public async Task<IList<Usuario>?> SelectAllByQueryParams(UsuarioParams param)
    {
        var found = await Repo.Select(param).ToListAsync();

        return found;
    }

    public async Task<Usuario?> SelectOneByQueryParams(UsuarioParams param)
    {
        var found = await Repo.Select(param).FirstOrDefaultAsync();

        return found;
    }

    public async Task<Usuario?> Update(string id, UsuarioParams param)
    {
        await Repo.Update(id, param);
        return await Repo.Select(id);
    }

    public Task<Usuario?> FindFirstByParams(UsuarioParams @params)
    {
        throw new NotImplementedException();
    }

    public Task<IList<Usuario>> SelectAll(UsuarioParams @params)
    {
        throw new NotImplementedException();
    }
}
