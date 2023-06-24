using LABCC.BackEnd.Domain.Entities.People;
using LABCC.BackEnd.Domain.Entities.Users;
using LABCC.BackEnd.Domain.Entities.Users.Interfaces;
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

  async public Task<IList<Usuario>> Select() => await _db.Users
    .Where(user => user.IsActive)
    .ToListAsync();

  async public Task<Usuario?> Select(long id) => await _db.Users
    .FirstOrDefaultAsync(user => user.Id == id && user.IsActive);

  async public Task Insert(Usuario obj)
  {
    await _db.Users.AddAsync(obj);
    await _db.SaveChangesAsync();
  }

  async public Task Update(long id, Usuario obj)
  {
    Usuario? user = await _db.Users.FindAsync(id);
    
    if (user == null)
    {
      throw new ArgumentException("User not found by id");
    }

    user.Name = obj.Name;
    user.Email = obj.Email;
    user.Document = obj.Document;
    user.BirthDate = obj.BirthDate;
    user.Gender = obj.Gender;
    user.Telephone = obj.Telephone;
    user.UserType = obj.UserType;
    user.IsActive = obj.IsActive;
    user.UpdatedAt = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

    await _db.SaveChangesAsync();
  }

  async public Task Delete(long id)
  {
    Usuario? user = await _db.Users.FirstOrDefaultAsync(user => user.Id == id);

    if (user == null || !user.IsActive)
    {
      throw new ArgumentException("User does not exist or is already inactive");
    }

    user.IsActive = false;

    await _db.SaveChangesAsync();
  }

  async public Task Activate(long id)
  {
    Usuario? user = await _db.Users
      .FirstOrDefaultAsync(user => user.Id == id) ?? throw new ArgumentException("User does not exist");

    if (user.IsActive) 
      throw new ArgumentException($"The user: ${user.Name}, id: ${user.Id} is already active.");

    user.IsActive = true;

    await _db.SaveChangesAsync();
  }
}
