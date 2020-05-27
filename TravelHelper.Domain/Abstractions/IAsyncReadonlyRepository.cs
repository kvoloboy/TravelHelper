using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TravelHelper.Domain.Models;

namespace TravelHelper.Domain.Abstractions
{
    public interface IAsyncReadonlyRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> FindSingleAsync(Expression<Func<TEntity, bool>> predicate);
        Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate = null);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
