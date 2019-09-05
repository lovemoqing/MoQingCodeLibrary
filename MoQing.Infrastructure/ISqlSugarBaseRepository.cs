using MoQing.Domain;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.IRepositorie
{
    /// <summary>
    /// 数据访问层父接口。
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public partial interface ISqlSugarBaseRepository<TEntity> where TEntity : class, IEntity
    {
        TEntity FirstOrDefault(string id);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FirstOrDefaultAsync(string id);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        ISugarQueryable<TEntity> GetAll();
        List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate);
        List<TEntity> GetAllList();
        List<TEntity> GetPageList(Expression<Func<TEntity, bool>> predicate, string orderBy, int pageIndex, int pageSize, ref int totalCount);
        Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate);
        Task<List<TEntity>> GetAllListAsync();
        TEntity Insert(TEntity entity);
        Task<TEntity> InsertAsync(TEntity entity);
        Task<int> InsertListAsync(List<TEntity> T1);
        int Update(TEntity entity);
        Task<int> UpdateAsync(TEntity entity);
        Task<int> UpdateListAsync(List<TEntity> T1);
        int Delete(TEntity entity);
        int Delete(string id);
        int Delete(Expression<Func<TEntity, bool>> predicate);
        Task<int> DeleteAsync(string id);
        Task<int> DeleteAsync(Expression<Func<TEntity, bool>> predicate);
        Task<int> DeleteAsync(TEntity entity);
        int Count(Expression<Func<TEntity, bool>> predicate);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);

    }
}
