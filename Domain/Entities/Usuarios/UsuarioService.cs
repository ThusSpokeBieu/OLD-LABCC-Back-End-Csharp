﻿using LABCC.BackEnd.Domain.Entities.Usuarios.Interfaces;
using LABCC.BackEnd.Domain.Params;
using Microsoft.EntityFrameworkCore;

namespace LABCC.BackEnd.Domain.Entities.Usuarios;
public class UsuarioService : IUsuarioService
{
  private readonly IUsuarioRepository Repo;

  public UsuarioService(IUsuarioRepository repo)
  {
    Repo = repo;
  }

  async public Task<Usuario> Add(Usuario usuario)
  {
    await Repo.Insert(usuario);
    return await SelectOneByCpfOrCnpj(usuario.CpfOuCnpj);
  }

  public async Task Delete(long id)
  {
    await Repo.Delete(id);
  }

  async public Task<IList<Usuario>> SelectAll()
  {
    return await Repo.Select().ToListAsync();
  }

  async public Task<Usuario> SelectOneById(long id)
  {
    var param = new UsuarioParams { Id = id };
    var found = await Repo.Select(param).FirstOrDefaultAsync();

    if (found != null) return found;
    return null;
  }

  async public Task<Usuario> SelectOneByCpfOrCnpj(string cpfOuCnpj)
  {
    var param = new UsuarioParams { CpfOuCnpj = cpfOuCnpj };
    var found = await Repo.Select(param).FirstOrDefaultAsync();

    if (found != null) return found;
    return null;
  }


  async public Task<IList<Usuario>> SelectAllByQueryParams(UsuarioParams param)
  {
    var found = await Repo.Select(param).ToListAsync();

    if (found.Any()) return found;
    return null;
  }

  async public Task<Usuario> SelectOneByQueryParams(UsuarioParams param)
  {
    var found = await Repo.Select(param).FirstOrDefaultAsync();

    if (found != null) return found;
    return null;
  }

  public Task<Usuario> Update(long id, Usuario dto)
  {
    throw new NotImplementedException();
  }
}
