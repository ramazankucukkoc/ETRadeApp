using Dapper;
using ETRadeApp.Core.Bases;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Linq.Expressions;

namespace ETRadeApp.Core.DataAccess.Dapper
{
    public class DapperRepositoryBase<TEntity, TKey> : IAsyncRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
        where TKey : struct
    {
        private readonly string _connectitonString;
        public DapperRepositoryBase()
        {
            _connectitonString = "Data Source=RAMAZANKUCUKKOC;Initial Catalog=ETradeApp;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            using IDbConnection dbConnection = new SqlConnection(_connectitonString);
            entity.CreatedDate = DateTime.UtcNow;
            var insertQuery = BuildInsertQuery(entity);
            await dbConnection.ExecuteAsync(insertQuery, entity);
            return entity;
        }

        public Task<List<TEntity>> AddRangeAsync(List<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> DeleteRangeAsync(List<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, int index = 0, int size = 10)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity?> GetByIdAsync(TKey Id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> UpdateRangeAsync(List<TEntity> entities)
        {
            throw new NotImplementedException();
        }
        private string BuildInsertQuery(TEntity entity)
        {
            var columns = string.Join(", ", entity.GetType().GetProperties().Select(x => x.Name));
            var values = string.Join(", ", entity.GetType().GetProperties().Select(x => $"@{x.Name}"));
            return $"INSERT INTO Categories ({columns}) VALUES ({values})";
        }
    }
}
