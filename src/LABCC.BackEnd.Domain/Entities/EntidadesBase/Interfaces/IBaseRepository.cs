namespace LABCC.BackEnd.Domain.Entities.EntidadesBase.Interfaces;
public interface IBaseRepository<TEntity> where TEntity : EntidadeBase
{
    public Task<IList<TEntity>> Select();
    public Task<TEntity> Select(long id);

    public Task Insert(TEntity obj);

    public Task Update(long id, TEntity obj);

    public Task Delete(long id);
}
