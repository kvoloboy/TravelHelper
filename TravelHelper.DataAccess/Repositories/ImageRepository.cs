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
    public class ImageRepository : GenericRepository<Image>
    {
        private readonly DbSet<Image> _imageDbSet;

        public ImageRepository(DbContext dbContext) : base(dbContext)
        {
            _imageDbSet = dbContext.Set<Image>();
        }

        public override Task<Image> FindSingleAsync(Expression<Func<Image, bool>> predicate)
        {
            var image = _imageDbSet.FirstOrDefaultAsync(predicate);

            return image;
        }

        public override Task<List<Image>> FindAllAsync(
            Expression<Func<Image, bool>> predicate = null,
            Expression<Func<Image, object>> sort = null,
            SortDirection sortDirection = SortDirection.Ascending,
            int skip = 0,
            int? take = null)
        {
            var images = _imageDbSet.AsNoTracking();

            if (predicate != null)
            {
                images = images.Where(predicate);
            }

            if (sort != null)
            {
                images = sortDirection == SortDirection.Ascending
                    ? images.OrderBy(sort)
                    : images.OrderByDescending(sort);
            }

            images = images.Skip(skip);

            if (take != null)
            {
                images = images.Take(take.Value);
            }

            return images.ToListAsync();
        }
    }
}
