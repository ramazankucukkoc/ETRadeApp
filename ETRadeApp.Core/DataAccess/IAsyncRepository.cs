using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ETRadeApp.Core.DataAccess
{
    public interface IAsyncRepository<TEntity, TKey>
        where TEntity : class
        where TKey : struct
    {
        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity?> GetByIdAsync(TKey Id);
        Task<PagedResult<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, int index = 0, int size = 10);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> AddAsync(TEntity entity);
        Task<List<TEntity>> AddRangeAsync(List<TEntity> entities);
        Task<TEntity> DeleteAsync(TEntity entity);
        Task< List<TEntity>> DeleteRangeAsync(List<TEntity> entities);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task< List<TEntity>> UpdateRangeAsync(List<TEntity> entities);
    }
}
