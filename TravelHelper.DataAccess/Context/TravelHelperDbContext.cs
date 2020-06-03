using Microsoft.EntityFrameworkCore;

namespace TravelHelper.DataAccess.Context
{
    public class TravelHelperDbContext : DbContext
    {
        public TravelHelperDbContext(DbContextOptions<TravelHelperDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }
    }
}
