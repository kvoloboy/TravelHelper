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
    public class OrderDetailsRepository : GenericRepository<OrderDetails>
    {
        private readonly DbSet<OrderDetails> _orderDetailsDbSet;

        public OrderDetailsRepository(DbContext dbContext) : base(dbContext)
        {
            _orderDetailsDbSet = dbContext.Set<OrderDetails>();
        }

        public override Task<OrderDetails> FindSingleAsync(Expression<Func<OrderDetails, bool>> predicate)
        {
            var orderDetails = _orderDetailsDbSet
                .Include(od => od.Order)
                .Include(od => od.Tour)
                .FirstOrDefaultAsync(predicate);

            return orderDetails;
        }

        public override Task<List<OrderDetails>> FindAllAsync(
            Expression<Func<OrderDetails, bool>> predicate = null,
            Expression<Func<OrderDetails, object>> sort = null,
            SortDirection sortDirection = SortDirection.Ascending,
            int skip = 0,
            int? take = null)
        {
            var orderDetails = _orderDetailsDbSet
                .Include(od => od.Order)
                .Include(od => od.Tour)
                .AsNoTracking();

            if (predicate != null)
            {
                orderDetails = orderDetails.Where(predicate);
            }

            if (sort != null)
            {
                orderDetails = sortDirection == SortDirection.Ascending
                    ? orderDetails.OrderBy(sort)
                    : orderDetails.OrderByDescending(sort);
            }

            orderDetails = orderDetails.Skip(skip);

            if (take != null)
            {
                orderDetails = orderDetails.Take(take.Value);
            }

            return orderDetails.ToListAsync();
        }
    }
}
