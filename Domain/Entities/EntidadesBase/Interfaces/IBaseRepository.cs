using LABCC.BackEnd.Domain.Params;

namespace LABCC.BackEnd.Domain.Entities.EntidadesBase.Interfaces;
public interface IBaseRepository<TEntity, TParams> 
                                          where TEntity : AggregateRoot
                                          where TParams : IParams
{
  IQueryable<TEntity> Select();
  IQueryable<TEntity> Select(TParams param);
  Task Insert(TEntity obj);
  Task Update(long id, TEntity obj);
  Task Delete(long id);
}
