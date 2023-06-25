using LABCC.BackEnd.Domain.Entities.Usuarios;
using LABCC.BackEnd.Domain.Entities.Usuarios.Interfaces;
using LABCC.BackEnd.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LABCC.BackEnd.Infrastructure.Repositories;

public class UserRepository : IUsuarioRepository
{
  private readonly MsSqlContext _db;

  public UserRepository(MsSqlContext db)
  {
    _db = db;
  }

  async public Task<IList<Usuario>> Select()
  {
    return await _db.Usuarios.ToListAsync();
  }

  async public Task<Usuario?> Select(long id) => await _db.Usuarios
    .FirstOrDefaultAsync(user => user.Id == id);

  async public Task Insert(Usuario obj)
  {
    await _db.Usuarios.AddAsync(obj);
    await _db.SaveChangesAsync();
  }

  async public Task Update(long id, Usuario obj)
  {
    Usuario? user = await _db.Usuarios.FindAsync(id) ?? throw new ArgumentException("User not found by id");
    await _db.SaveChangesAsync();
  }

  async public Task Delete(long id)
  {
    Usuario? user = await _db.Usuarios.FirstOrDefaultAsync(user => user.Id == id) ?? throw new ArgumentException("User does not exist or is already inactive");
    _db.Usuarios.Remove(user);

    await _db.SaveChangesAsync();
  }

  async public Task Activate(long id)
  {
    Usuario? user = await _db.Usuarios
      .FirstOrDefaultAsync(user => user.Id == id) ?? throw new ArgumentException("User does not exist");

    if (user.StatusId == 1) 
      throw new ArgumentException($"The user: ${user.Nome}, id: ${user.Id} is already active.");

    user.StatusId = 1;

    await _db.SaveChangesAsync();
  }
}
