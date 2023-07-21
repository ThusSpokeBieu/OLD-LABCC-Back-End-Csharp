
namespace LABCC.BackEnd.Domain.Entities.EntidadesBase.Interfaces;
public interface IBaseService<TEntity, TParams> 
                          where TEntity : AggregateRoot
                          where TParams : IParams
{
  Task<TEntity> Add(TEntity dto);
  Task Delete(long id);
  Task<TEntity?> SelectOneById(long id);
  Task<TEntity?> FindFirstByParams(TParams @params);
  Task<IList<TEntity>> SelectAll();
  Task<IList<TEntity>> SelectAll(TParams @params);
  Task<TEntity?> Update(long id, TParams param);
}
