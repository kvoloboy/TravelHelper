using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TravelHelper.Domain.Models;

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
            int? skip = null,
            int? take = null)
        {
            var orders = _orderDbSet
                .Include(o => o.User)
                .AsNoTracking();

            if (predicate != null)
            {
                orders = orders.Where(predicate);
            }

            if (skip != null)
            {
                orders = orders.Skip(skip.Value);
            }

            if (take != null)
            {
                orders = orders.Take(take.Value);
            }

            return orders.ToListAsync();

        }
    }
}
