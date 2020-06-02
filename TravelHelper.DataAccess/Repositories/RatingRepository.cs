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
    public class RatingRepository : GenericRepository<Rating>
    {
        private readonly DbSet<Rating> _ratingDbSet;

        public RatingRepository(DbContext dbContext) : base(dbContext)
        {
            _ratingDbSet = dbContext.Set<Rating>();
        }

        public override Task<Rating> FindSingleAsync(Expression<Func<Rating, bool>> predicate)
        {
            var rating = _ratingDbSet.FirstOrDefaultAsync(predicate);

            return rating;
        }

        public override Task<List<Rating>> FindAllAsync(
            Expression<Func<Rating, bool>> predicate = null,
            Expression<Func<Rating, object>> sort = null,
            SortDirection sortDirection = SortDirection.Ascending,
            int skip = 0,
            int? take = null)
        {
            var ratings = _ratingDbSet.AsNoTracking();

            if (predicate != null)
            {
                ratings = ratings.Where(predicate);
            }

            if (sort != null)
            {
                ratings = sortDirection == SortDirection.Ascending
                    ? ratings.OrderBy(sort)
                    : ratings.OrderByDescending(sort);
            }

            ratings = ratings.Skip(skip);

            if (take != null)
            {
                ratings = ratings.Take(take.Value);
            }

            return ratings.ToListAsync();
        }
    }
}
