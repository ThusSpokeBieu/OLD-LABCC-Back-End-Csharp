using LABCC.BackEnd.Domain.Entities;

namespace LABCC.BackEnd.Domain.Interfaces;
public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
  void Insert(TEntity obj);

  void Update(TEntity obj);

  void Delete(int id);

  IList<TEntity> Select();

  TEntity SelectById(int id);
}
