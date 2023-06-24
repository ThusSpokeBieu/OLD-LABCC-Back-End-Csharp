using FluentValidation;

namespace LABCC.BackEnd.Domain.Entities.EntidadesBase.Interfaces;
public interface IBaseService<TEntity> where TEntity : EntidadeBase
{
    Task<TEntity> Add<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;
    Task Delete(long id);
    Task<TEntity> Get();
    Task<TEntity> GetById(long id);
    Task<TEntity> Update<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;
}
