using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TravelHelper.Domain.Abstractions;
using TravelHelper.Domain.Models;

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
            int? skip = null,
            int? take = null)
        {
            var categories = _categoriesDbSet
                .Include(c => c.Tours)
                .AsNoTracking();

            if (predicate != null)
            {
                categories = categories.Where(predicate);
            }

            if (skip != null)
            {
                categories = categories.Skip(skip.Value);
            }

            if (take != null)
            {
                categories = categories.Take(take.Value);
            }


            return categories.ToListAsync();
        }
    }
}
