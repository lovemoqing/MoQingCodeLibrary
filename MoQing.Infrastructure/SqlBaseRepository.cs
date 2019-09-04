using MoQing.Domain.Models;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
namespace MoQing.Infrastructure
{
    public  class SqlBaseRepository<TEntity> : IRedirectRepository<TEntity> where TEntity : class, IEntity, new()
    {
        private SqlSugarClient db = ConnectionFactory.CreateSqlSugarClient();
        public virtual Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return db.Queryable<TEntity>().CountAsync(predicate);
        }

        public virtual Task<int> DeleteAsync(string id)
        {
            return db.Deleteable<TEntity>(id).ExecuteCommandAsync();
        }

        public virtual Task<int> DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return db.Deleteable<TEntity>().Where(predicate).ExecuteCommandAsync();
        }

        public virtual Task<int> DeleteAsync(TEntity entity)
        {
            return db.Deleteable(entity).ExecuteCommandAsync();
        }

        public Task<int> DeleteAsync(int id)
        {
            try
            {
                return db.Deleteable<TEntity>(id).ExecuteCommandAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual Task<TEntity> FirstOrDefaultAsync(int id)
        {
            return db.Queryable<TEntity>().FirstAsync(p => p.ID == id);
        }

        public virtual Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return db.Queryable<TEntity>().FirstAsync(predicate);
        }

        public virtual Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return db.Queryable<TEntity>().Where(predicate).ToListAsync();
        }

        public virtual Task<int> InsertAsync(TEntity entity)
        {
            return db.Insertable(entity).ExecuteCommandAsync();
        }

        public virtual Task<int> InsertListAsync(List<TEntity> T1)
        {
            return db.Insertable(T1).ExecuteCommandAsync();
        }

        public virtual Task<int> UpdateAsync(TEntity entity)
        {
            return db.Updateable(entity).ExecuteCommandAsync();
        }

        public virtual Task<int> UpdateListAsync(List<TEntity> T1)
        {
            //批量更新(主键要有值，主键是更新条件)
            return db.Updateable(T1).ExecuteCommandAsync();
        }
    }
}
