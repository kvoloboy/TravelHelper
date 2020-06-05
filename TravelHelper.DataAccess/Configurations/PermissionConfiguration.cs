using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelHelper.Domain.Models.Identity;

namespace TravelHelper.DataAccess.Configurations
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.Property(permission => permission.Value).IsRequired();

            builder.HasData(new Permission
            {
                Id = 1,
                Value = "Manage agencies"
            },
            new Permission
            {
                Id = 2,
                Value = "Manage tours"
            },
            new Permission
            {
                Id = 3,
                Value = "Manage categories"
            },
            new Permission
            {
                Id = 4,
                Value = "Manage locations"
            },
            new Permission
            {
                Id = 5,
                Value = "Manage hotels"
            },
            new Permission
            {
                Id = 6,
                Value = "Manage orders"
            },
            new Permission
            {
                Id = 7,
                Value = "Make orders"
            });
        }
    }
}
