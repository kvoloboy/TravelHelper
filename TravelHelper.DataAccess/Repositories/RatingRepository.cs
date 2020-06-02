using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TravelHelper.Domain.Models;

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
            int? skip = null,
            int? take = null)
        {
            var ratings = _ratingDbSet.AsNoTracking();

            if (predicate != null)
            {
                ratings = ratings.Where(predicate);
            }

            if (skip != null)
            {
                ratings = ratings.Skip(skip.Value);
            }

            if (take != null)
            {
                ratings = ratings.Take(take.Value);
            }

            return ratings.ToListAsync();

        }
    }
}
