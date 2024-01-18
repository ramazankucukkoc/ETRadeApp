using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ETRadeApp.Core.Extensions
{
    public static class QueryableExtensions
    {
        public static async Task<IQueryable<TEntity>> GetAllAsync<TEntity>(
       this IQueryable<TEntity> source,
       Expression<Func<TEntity, bool>> predicate = null,
       Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
       Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
       int skip = 0,
       int take = 10
   ) where TEntity : class
        {
            if (predicate != null)
                source = source.Where(predicate);
            if (include != null)
                source = include(source);
            if (orderBy != null)
                source = orderBy(source);
            source = source.Skip(skip).Take(take);

            return source;
        }
    }
}
