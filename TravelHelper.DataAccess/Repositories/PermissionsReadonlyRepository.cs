using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TravelHelper.Domain.Abstractions;
using TravelHelper.Domain.Models.Enums;
using TravelHelper.Domain.Models.Identity;

namespace TravelHelper.DataAccess.Repositories
{
    public class PermissionsReadonlyRepository : IReadonlyRepository<Permission>
    {
        private readonly DbSet<Permission> _permissionDbSet;

        public PermissionsReadonlyRepository(DbContext dbContext)
        {
            _permissionDbSet = dbContext.Set<Permission>();
        }

        public Task<Permission> FindSingleAsync(Expression<Func<Permission, bool>> predicate)
        {
            var permission = _permissionDbSet.FirstOrDefaultAsync(predicate);

            return permission;
        }

        public Task<List<Permission>> FindAllAsync(
            Expression<Func<Permission, bool>> predicate = null,
            Expression<Func<Permission, object>> sort = null,
            SortDirection sortDirection = SortDirection.Ascending,
            int skip = 0,
            int? take = null)
        {
            var permissions = _permissionDbSet.AsNoTracking();

            if (predicate != null)
            {
                permissions = permissions.Where(predicate);
            }

            if (sort != null)
            {
                permissions = sortDirection == SortDirection.Ascending
                    ? permissions.OrderBy(sort)
                    : permissions.OrderByDescending(sort);
            }

            permissions = permissions.Skip(skip);

            if (take != null)
            {
                permissions = permissions.Take(take.Value);
            }

            return permissions.ToListAsync();
        }

        public Task<bool> AnyAsync(Expression<Func<Permission, bool>> predicate)
        {
            var any = _permissionDbSet.AnyAsync(predicate);

            return any;
        }
    }
}
