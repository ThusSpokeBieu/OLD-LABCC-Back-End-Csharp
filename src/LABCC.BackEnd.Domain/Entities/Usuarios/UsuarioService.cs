using LABCC.BackEnd.Domain.Entities.Usuarios.Interfaces;

namespace LABCC.BackEnd.Domain.Entities.Usuarios;
public class UsuarioService : IUsuarioService
{
  private readonly IUsuarioRepository Repo;

  public UsuarioService(IUsuarioRepository repo)
  {
    Repo = repo;
  }

  async public Task Add(Usuario dto)
  {
    await Repo.Insert(dto);
  }

  public Task Delete(long id)
  {
    throw new NotImplementedException();
  }

  async public Task<ICollection<Usuario>> Get()
  {
    return await Repo.Select();
  }

  async public Task<Usuario> GetById(long id)
  {
    return await Repo.Select(id);
  }

  public Task<Usuario> Update(Usuario dto)
  {
    throw new NotImplementedException();
  }
}
