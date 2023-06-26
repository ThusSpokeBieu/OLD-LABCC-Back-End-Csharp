
using LABCC.BackEnd.Domain.Params;

namespace LABCC.BackEnd.Domain.Entities.EntidadesBase.Interfaces;
public interface IBaseService<TEntity, TParams> 
                          where TEntity : AggregateRoot
                          where TParams : IParams
{
  Task<TEntity> Add(TEntity dto);
  Task Delete(long id);
  Task<TEntity> SelectOneById(long id);
  Task<IList<TEntity>> SelectAll();
  Task<TEntity> Update(long id, TParams param);
}
