using System;
using System.Linq.Expressions;
using TravelHelper.Domain.Models;

namespace BusinessLayer.Sort.Options.Interfaces
{
    public interface ISortOption<TEntity> where TEntity : BaseEntity
    {
        SortDirection Direction { get; }

        Expression<Func<TEntity, object>> Expression { get; }
    }
}
