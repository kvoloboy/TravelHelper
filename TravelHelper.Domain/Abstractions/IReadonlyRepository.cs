using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TravelHelper.Domain.Models;
using TravelHelper.Domain.Models.Enums;

namespace TravelHelper.Domain.Abstractions
{
    public interface IReadonlyRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> FindSingleAsync(Expression<Func<TEntity, bool>> predicate);

        Task<List<TEntity>> FindAllAsync(
            Expression<Func<TEntity, bool>> predicate = null,
            Expression<Func<TEntity, object>> sort = null,
            SortDirection sortDirection = SortDirection.Ascending,
            int skip = 0,
            int? take = null);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
