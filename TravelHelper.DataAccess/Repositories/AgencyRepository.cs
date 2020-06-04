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
    public class AgencyRepository : GenericRepository<Agency>
    {
        private readonly DbSet<Agency> _agenciesDbSet;

        public AgencyRepository(DbContext dbContext)
            : base(dbContext)
        {
            _agenciesDbSet = dbContext.Set<Agency>();
        }

        public override Task<Agency> FindSingleAsync(Expression<Func<Agency, bool>> predicate)
        {
            var agency = _agenciesDbSet
                .Include(a => a.Tours)
                .FirstOrDefaultAsync(predicate);

            return agency;
        }

        public override Task<List<Agency>> FindAllAsync(
            Expression<Func<Agency, bool>> predicate = null,
            Expression<Func<Agency, object>> sort = null,
            SortDirection sortDirection = SortDirection.Ascending,
            int skip = 0,
            int? take = null)
        {
            var agencies = _agenciesDbSet
                .Include(a => a.Tours)
                .AsNoTracking();

            if (predicate != null)
            {
                agencies = agencies.Where(predicate);
            }

            if (sort != null)
            {
                agencies = sortDirection == SortDirection.Ascending
                    ? agencies.OrderBy(sort)
                    : agencies.OrderByDescending(sort);
            }

            agencies = agencies.Skip(skip);

            if (take != null)
            {
                agencies = agencies.Take(take.Value);
            }

            return agencies.ToListAsync();
        }
    }
}
