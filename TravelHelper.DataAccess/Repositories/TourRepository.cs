using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TravelHelper.Domain.Models;

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
                .Include(t => t.SourcePoint)
                .Include(t => t.Agency)
                .Include(t => t.Category)
                .Include(t => t.Hotel)
                    .ThenInclude(h=> h.Images)
                .Include(t => t.Ratings)
                .FirstOrDefaultAsync(predicate);

            return tour;
        }

        public override Task<List<Tour>> FindAllAsync(
            Expression<Func<Tour, bool>> predicate = null,
            int? skip = null,
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

            if (skip != null)
            {
                tours = tours.Skip(skip.Value);
            }

            if (take != null)
            {
                tours = tours.Take(take.Value);
            }

            return tours.ToListAsync();
        }
    }
}
