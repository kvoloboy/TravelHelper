using Microsoft.EntityFrameworkCore;
using TravelHelper.DataAccess.Configurations;
using TravelHelper.Domain.Models;
using TravelHelper.Domain.Models.Identity;

namespace TravelHelper.DataAccess.Context
{
    public class TravelHelperDbContext : DbContext
    {
        public DbSet<Agency> Agencies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<User> Users { get; set; }
        public TravelHelperDbContext(DbContextOptions<TravelHelperDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AgencyConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new HotelConfiguration());
            modelBuilder.ApplyConfiguration(new ImageConfiguration());
            modelBuilder.ApplyConfiguration(new LocationConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new RolePermissionConfiguration());
            modelBuilder.ApplyConfiguration(new TourConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
        }
    }
}
