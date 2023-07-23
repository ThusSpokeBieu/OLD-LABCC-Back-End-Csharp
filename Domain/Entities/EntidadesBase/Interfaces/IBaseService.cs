namespace LABCC.BackEnd.Domain.Entities.EntidadesBase.Interfaces;

public interface IBaseService<TEntity, TParams, TId>
    where TEntity : AggregateRoot<TId>
    where TParams : IParams
{
    Task<TEntity> Add(TEntity dto);
    Task Delete(TId id);
    Task<TEntity?> SelectOneById(TId id);
    Task<TEntity?> FindFirstByParams(TParams @params);
    Task<IList<TEntity>> SelectAll();
    Task<IList<TEntity>> SelectAll(TParams @params);
    Task<TEntity?> Update(TId id, TParams param);
}
