﻿using MoQing.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MoQing.Domain.IRepositories
{
    public interface ISqlBaseRepository<TEntity> where TEntity : class, IEntity
    {
        Task<TEntity> FirstOrDefaultAsync(string id);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate);
        Task<int> InsertAsync(TEntity entity);
        Task<int> InsertListAsync(List<TEntity> T1);
        Task<int> UpdateAsync(TEntity entity);
        Task<int> UpdateListAsync(List<TEntity> T1);
        Task<int> DeleteAsync(string id);
        Task<int> DeleteAsync(Expression<Func<TEntity, bool>> predicate);
        Task<int> DeleteAsync(TEntity entity);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
