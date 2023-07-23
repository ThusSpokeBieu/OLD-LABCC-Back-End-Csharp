using LABCC.BackEnd.Domain.Entities.Usuarios;

namespace LABCC.BackEnd.Domain.Entities.EntidadesBase.Interfaces;

public interface IBaseRepository<TEntity, TParams, TId>
    where TEntity : AggregateRoot<TId>
    where TParams : IParams
{
    IQueryable<TEntity> Select(TParams param);
    IQueryable<TEntity> Select();
    Task<TEntity?> Select(TId id);
    Task Insert(TEntity obj);
    Task Update(TId id, TParams obj);
    Task Delete(TId id);
}
