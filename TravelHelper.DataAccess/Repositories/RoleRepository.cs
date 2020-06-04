using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TravelHelper.DataAccess.Context;
using TravelHelper.Domain.Models.Enums;
using TravelHelper.Domain.Models.Identity;

namespace TravelHelper.DataAccess.Repositories
{
    public class RoleRepository : GenericRepository<Role>
    {
        private readonly DbSet<Role> _roleDbSet;

        public RoleRepository(TravelHelperDbContext dbContext)
            : base(dbContext)
        {
            _roleDbSet = dbContext.Set<Role>();
        }

        public override Task<Role> FindSingleAsync(Expression<Func<Role, bool>> predicate)
        {
            var role = _roleDbSet
                .Include(r => r.RolePermissions)
                .ThenInclude(rp => rp.Permission)
                .FirstOrDefaultAsync(predicate);

            return role;
        }

        public override Task<List<Role>> FindAllAsync(
            Expression<Func<Role, bool>> predicate = null,
            Expression<Func<Role, object>> sort = null,
            SortDirection sortDirection = SortDirection.Ascending,
            int skip = 0,
            int? take = null)
        {
            var roles = _roleDbSet
                .Include(r => r.RolePermissions)
                .ThenInclude(rp => rp.Permission)
                .AsNoTracking();

            if (predicate != null)
            {
                roles = roles.Where(predicate);
            }

            if (sort != null)
            {
                roles = sortDirection == SortDirection.Ascending
                    ? roles.OrderBy(sort)
                    : roles.OrderByDescending(sort);
            }

            roles = roles.Skip(skip);

            if (take != null)
            {
                roles = roles.Take(take.Value);
            }

            return roles.ToListAsync();
        }
    }
}
