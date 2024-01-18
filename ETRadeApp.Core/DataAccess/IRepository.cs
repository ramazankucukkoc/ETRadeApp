using System.Linq.Expressions;

namespace ETRadeApp.Core.DataAccess
{
    public interface IRepository<TEntity, TKey>
        where TEntity : class
        where TKey : struct
    {
        TEntity? GetAsync(Expression<Func<TEntity, bool>> predicate = null);
        TEntity? GetByIdAsync(TKey Id);
        int CountAsync(Expression<Func<TEntity, bool>> predicate);
        TEntity Add(TEntity entity);
        List<TEntity> AddRangeAsync(List<TEntity> entities);
        TEntity DeleteAsync(TEntity entity);
        List<TEntity> DeleteRangeAsync(List<TEntity> entities);
        TEntity UpdateAsync(TEntity entity);
        List<TEntity> UpdateRangeAsync(List<TEntity> entities);

    }
}
