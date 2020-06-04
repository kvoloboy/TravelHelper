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
    public class CategoryRepository : GenericRepository<Category>
    {
        private readonly DbSet<Category> _categoriesDbSet;

        public CategoryRepository(DbContext dbContext)
            : base(dbContext)
        {
            _categoriesDbSet = dbContext.Set<Category>();
        }

        public override Task<Category> FindSingleAsync(Expression<Func<Category, bool>> predicate)
        {
            var category = _categoriesDbSet
                .Include(c => c.Tours)
                .FirstOrDefaultAsync(predicate);

            return category;
        }

        public override Task<List<Category>> FindAllAsync(
            Expression<Func<Category, bool>> predicate = null,
            Expression<Func<Category, object>> sort = null,
            SortDirection sortDirection = SortDirection.Ascending,
            int skip = 0,
            int? take = null)
        {
            var categories = _categoriesDbSet
                .Include(c => c.Tours)
                .AsNoTracking();

            if (predicate != null)
            {
                categories = categories.Where(predicate);
            }

            if (sort != null)
            {
                categories = sortDirection == SortDirection.Ascending
                    ? categories.OrderBy(sort)
                    : categories.OrderByDescending(sort);
            }

            categories = categories.Skip(skip);

            if (take != null)
            {
                categories = categories.Take(take.Value);
            }

            return categories.ToListAsync();
        }
    }
}
