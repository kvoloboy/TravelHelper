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
    public class LocationRepository : GenericRepository<Location>
    {
        private readonly DbSet<Location> _locationDbSet;

        public LocationRepository(DbContext dbContext) : base(dbContext)
        {
            _locationDbSet = dbContext.Set<Location>();
        }

        public override Task<Location> FindSingleAsync(Expression<Func<Location, bool>> predicate)
        {
            var location = _locationDbSet
                // .Include(l => l.Tours)
                .FirstOrDefaultAsync(predicate);

            return location;
        }

        public override Task<List<Location>> FindAllAsync(
            Expression<Func<Location, bool>> predicate = null,
            Expression<Func<Location, object>> sort = null,
            SortDirection sortDirection = SortDirection.Ascending,
            int skip = 0,
            int? take = null)
        {
            var locations = _locationDbSet
                // .Include(l => l.Tours)
                .AsNoTracking();

            if (predicate != null)
            {
                locations = locations.Where(predicate);
            }

            if (sort != null)
            {
                locations = sortDirection == SortDirection.Ascending
                    ? locations.OrderBy(sort)
                    : locations.OrderByDescending(sort);
            }

            locations = locations.Skip(skip);

            if (take != null)
            {
                locations = locations.Take(take.Value);
            }

            return locations.ToListAsync();
        }
    }
}
