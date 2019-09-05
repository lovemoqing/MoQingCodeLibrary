using Infrastructure.IRepositorie;
using MoQing.Domain;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Repositorie
{
    public class SqlSugarBaseRepository<TEntity> : ISqlSugarBaseRepository<TEntity> where TEntity : class, IEntity, new()
    {
        private SqlSugarClient db = ConnectionFactory.CreateSqlSugarClient();

        public virtual TEntity FirstOrDefault(string id)
        {
            try
            {
                return db.Queryable<TEntity>().First(p => p.id == id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return db.Queryable<TEntity>().First(predicate);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual Task<TEntity> FirstOrDefaultAsync(string id)
        {
            try
            {
                return db.Queryable<TEntity>().FirstAsync(p => p.id == id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return db.Queryable<TEntity>().FirstAsync(predicate);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual ISugarQueryable<TEntity> GetAll()
        {
            try
            {
                return db.Queryable<TEntity>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return db.Queryable<TEntity>().Where(predicate).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual List<TEntity> GetAllList()
        {
            try
            {
                return db.Queryable<TEntity>().ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual List<TEntity> GetPageList(Expression<Func<TEntity, bool>> predicate, string orderBy, int pageIndex, int pageSize, ref int totalCount)
        {
            try
            {
                var data = db.Queryable<TEntity>();
                if (predicate != null)
                {
                    data = data.Where(predicate);
                }
                data = data.OrderBy(orderBy);
                return data.ToPageList(pageIndex, pageSize, ref totalCount);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return db.Queryable<TEntity>().Where(predicate).ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual Task<List<TEntity>> GetAllListAsync()
        {
            try
            {
                return db.Queryable<TEntity>().ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual TEntity Insert(TEntity entity)
        {
            try
            {
                return db.Insertable<TEntity>(entity).ExecuteReturnEntity();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual Task<TEntity> InsertAsync(TEntity entity)
        {
            try
            {
                return db.Insertable<TEntity>(entity).ExecuteReturnEntityAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual int InsertList(List<TEntity> T1)
        {
            try
            {
                return db.Insertable<TEntity>(T1).ExecuteCommand();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual Task<int> InsertListAsync(List<TEntity> T1)
        {
            try
            {
                return db.Insertable<TEntity>(T1).ExecuteCommandAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual int Update(TEntity entity)
        {
            try
            {
                return db.Updateable<TEntity>(entity).ExecuteCommand();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Task<int> UpdateAsync(TEntity entity)
        {
            try
            {
                return db.Updateable<TEntity>(entity).ExecuteCommandAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual int UpdateList(List<TEntity> T1)
        {
            try
            {
                //批量更新(主键要有值，主键是更新条件)
                return db.Updateable<TEntity>(T1).ExecuteCommand();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual Task<int> UpdateListAsync(List<TEntity> T1)
        {
            try
            {
                //批量更新(主键要有值，主键是更新条件)
                return db.Updateable<TEntity>(T1).ExecuteCommandAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual int Delete(TEntity entity)
        {
            try
            {
                if (entity != null)
                {
                    return db.Deleteable<TEntity>(entity).ExecuteCommand();
                }
                return 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual int Delete(string id)
        {
            try
            {
                return db.Deleteable<TEntity>(id).ExecuteCommand();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual int Delete(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                if (predicate != null)
                {
                    return db.Deleteable<TEntity>().Where(predicate).ExecuteCommand();
                }
                return 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual Task<int> DeleteAsync(string id)
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

        public virtual Task<int> DeleteAsync(TEntity entity)
        {
            try
            {
                if (entity != null)
                {
                    return db.Deleteable<TEntity>(entity).ExecuteCommandAsync();
                }
                return Task.Run(() => 0);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual Task<int> DeleteAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            try
            {
                if (predicate != null)
                {
                    return db.Deleteable<TEntity>().Where(predicate).ExecuteCommandAsync();
                }
                return Task.Run(() => 0);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual int Count(Expression<Func<TEntity, bool>> predicate = null)
        {
            try
            {
                if (predicate != null)
                {
                    return db.Queryable<TEntity>().Count(predicate);
                }
                return 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            try
            {
                if (predicate != null)
                {
                    return db.Queryable<TEntity>().CountAsync(predicate);
                }
                return Task.Run(() => 0);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
