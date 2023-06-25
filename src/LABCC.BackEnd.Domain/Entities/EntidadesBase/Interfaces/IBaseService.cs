
namespace LABCC.BackEnd.Domain.Entities.EntidadesBase.Interfaces;
public interface IBaseService<TEntity> where TEntity : AggregateRoot 
{
  Task Add(TEntity dto);
  Task Delete(long id);
  Task<ICollection<TEntity>> Get();
  Task<TEntity> GetById(long id);
  Task<TEntity> Update(TEntity dto);
}
