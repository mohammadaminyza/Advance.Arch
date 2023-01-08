using System.Linq.Expressions;

namespace Advance.Arch.Core.Contracts.Common;

public interface ICommandRepository<TEntity>
{
    void Delete(long id);
    void Delete(TEntity entity);
    void Insert(TEntity entity);
    Task InsertAsync(TEntity entity);

    TEntity Get(long id);
    Task<TEntity> GetAsync(long id);
    bool Exists(Expression<Func<TEntity, bool>> expression);
    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression);

    int Commit();
    Task<int> CommitAsync();
}