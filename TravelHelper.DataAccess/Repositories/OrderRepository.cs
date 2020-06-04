using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TravelHelper.Domain.Models;
using TravelHelper.Domain.Models.Enums;

namespace TravelHelper.DataAccess.Repositories
{
    public class OrderRepository : GenericRepository<Order>
    {
        private readonly DbSet<Order> _orderDbSet;

        public OrderRepository(DbContext dbContext) : base(dbContext)
        {
            _orderDbSet = dbContext.Set<Order>();
        }

        public override Task<Order> FindSingleAsync(Expression<Func<Order, bool>> predicate)
        {
            var order = _orderDbSet
                .Include(o => o.User)
                .FirstOrDefaultAsync(predicate);

            return order;
        }

        public override Task<List<Order>> FindAllAsync(
            Expression<Func<Order, bool>> predicate = null,
            Expression<Func<Order, object>> sort = null,
            SortDirection sortDirection = SortDirection.Ascending,
            int skip = 0,
            int? take = null)
        {
            var orders = _orderDbSet
                .Include(o => o.User)
                .AsNoTracking();

            if (predicate != null)
            {
                orders = orders.Where(predicate);
            }

            if (sort != null)
            {
                orders = sortDirection == SortDirection.Ascending
                    ? orders.OrderBy(sort)
                    : orders.OrderByDescending(sort);
            }

            orders = orders.Skip(skip);

            if (take != null)
            {
                orders = orders.Take(take.Value);
            }

            return orders.ToListAsync();
        }
    }
}
