using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TravelHelper.Domain.Models;

namespace TravelHelper.DataAccess.Repositories
{
    public class HotelRepository : GenericRepository<Hotel>
    {
        private readonly DbSet<Hotel> _hotelDbSet;

        public HotelRepository(DbContext dbContext) : base(dbContext)
        {
            _hotelDbSet = dbContext.Set<Hotel>();
        }

        public override Task<Hotel> FindSingleAsync(Expression<Func<Hotel, bool>> predicate)
        {
            var hotel = _hotelDbSet
                .Include(h => h.Images)
                .FirstOrDefaultAsync();

            return hotel;
        }

        public override Task<List<Hotel>> FindAllAsync(
            Expression<Func<Hotel, bool>> predicate = null,
            int? skip = null,
            int? take = null)
        {
            var hotels = _hotelDbSet
                .Include(h => h.Images)
                .AsNoTracking();

            if (predicate != null)
            {
                hotels = hotels.Where(predicate);
            }

            if (skip != null)
            {
                hotels = hotels.Skip(skip.Value);
            }

            if (take != null)
            {
                hotels = hotels.Take(take.Value);
            }

            return hotels.ToListAsync();
        }
    }
}
