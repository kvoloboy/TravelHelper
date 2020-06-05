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
    public class TourRepository : GenericRepository<Tour>
    {
        private readonly DbSet<Tour> _tourDbSet;

        public TourRepository(DbContext dbContext) : base(dbContext)
        {
            _tourDbSet = dbContext.Set<Tour>();
        }

        public override Task<Tour> FindSingleAsync(Expression<Func<Tour, bool>> predicate)
        {
            var tour = _tourDbSet
                .Include(t => t.DestinationPoint)
                .Include(t => t.Agency)
                .Include(t => t.Category)
                .Include(t => t.Hotel)
                .ThenInclude(h => h.Images)
                .Include(t => t.Ratings)
                .FirstOrDefaultAsync(predicate);

            return tour;
        }

        public override Task<List<Tour>> FindAllAsync(
            Expression<Func<Tour, bool>> predicate = null,
            Expression<Func<Tour, object>> sort = null,
            SortDirection sortDirection = SortDirection.Ascending,
            int skip = 0,
            int? take = null)
        {
            var tours = _tourDbSet
                .Include(t => t.Hotel)
                .ThenInclude(h => h.Images)
                .AsNoTracking();

            if (predicate != null)
            {
                tours = tours.Where(predicate);
            }

            if (sort != null)
            {
                tours = sortDirection == SortDirection.Ascending
                    ? tours.OrderBy(sort)
                    : tours.OrderByDescending(sort);
            }

            tours = tours.Skip(skip);

            if (take != null)
            {
                tours = tours.Take(take.Value);
            }

            return tours.ToListAsync();
        }
    }
}
