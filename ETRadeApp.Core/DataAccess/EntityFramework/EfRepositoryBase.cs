using ETRadeApp.Core.Bases;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ETRadeApp.Core.DataAccess.EntityFramework
{
    public class EfRepositoryBase<TEntity, TKey, TContext> : IAsyncRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
        where TKey : struct
        where TContext : DbContext
    {
        protected TContext _context;
        public EfRepositoryBase(TContext context)
        {
            _context = context;
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var addedEntity = await _context.Set<TEntity>().AddAsync(entity);
            entity.CreatedDate = DateTime.Now;
            await _context.SaveChangesAsync();
            return addedEntity.Entity;
        }
        public async Task<List<TEntity>> AddRangeAsync(List<TEntity> entities)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);
            entities.ForEach(x => x.UpdateDate = DateTime.Now);
            await _context.SaveChangesAsync();
            return entities;
        }
        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().CountAsync(predicate);
        }
        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            entity.DeletedDate = DateTime.Now;
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<List<TEntity>> DeleteRangeAsync(List<TEntity> entities)
        {
            _context.Entry(entities).State = EntityState.Deleted;
            entities.ForEach(x => x.DeletedDate = DateTime.Now);
            await _context.SaveChangesAsync();
            return entities;
        }
        public async Task<PagedResult<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, int index = 0, int size = 10)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if (predicate is not null)
                query = query.Where(predicate);
            if (include is not null)
                query = include(query);
            if (orderBy is not null)
                query = orderBy(query);

            var items = await query.Skip(index * size).Take(size).ToListAsync();

            var pagedResult = new PagedResult<TEntity>()
            {
                Count = await query.CountAsync(),
                Items = items
            };
            return pagedResult;
        }
        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }
        public async Task<TEntity?> GetByIdAsync(TKey Id)
        {
            return await _context.Set<TEntity>().FindAsync(Id);
        }
        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            if (entity.IsDeleted is true) entity.DeletedDate = DateTime.UtcNow;

            else entity.UpdateDate = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<List<TEntity>> UpdateRangeAsync(List<TEntity> entities)
        {
            _context.Entry(entities).State = EntityState.Modified;
            foreach (TEntity entity in entities)
            {
                if (entity.IsDeleted is true) entity.DeletedDate = DateTime.UtcNow;

                else entity.UpdateDate = DateTime.UtcNow;
            }
            await _context.SaveChangesAsync();
            return entities;
        }
    }
}
