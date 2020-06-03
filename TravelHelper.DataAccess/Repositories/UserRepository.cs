using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TravelHelper.Domain.Models.Enums;
using TravelHelper.Domain.Models.Identity;

namespace TravelHelper.DataAccess.Repositories
{
    public class UserRepository : GenericRepository<User>
    {
        private readonly DbSet<User> _userDbSet;

        public UserRepository(DbContext dbContext)
            : base(dbContext)
        {
            _userDbSet = dbContext.Set<User>();
        }

        public override Task<User> FindSingleAsync(Expression<Func<User, bool>> predicate)
        {
            var user = _userDbSet
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .ThenInclude(r => r.RolePermissions)
                .ThenInclude(rp => rp.Permission)
                .FirstOrDefaultAsync(predicate);

            return user;
        }

        public override Task<List<User>> FindAllAsync(
            Expression<Func<User, bool>> predicate = null,
            Expression<Func<User, object>> sort = null,
            SortDirection sortDirection = SortDirection.Ascending,
            int skip = 0,
            int? take = null)
        {
            var users = _userDbSet
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .ThenInclude(r => r.RolePermissions)
                .ThenInclude(rp => rp.Permission)
                .AsNoTracking();

            if (sort != null)
            {
                users = sortDirection == SortDirection.Ascending
                    ? users.OrderBy(sort)
                    : users.OrderByDescending(sort);
            }

            users = users.Skip(skip);

            if (take != null)
            {
                users = users.Take(take.Value);
            }

            return users.ToListAsync();
        }
    }
}
