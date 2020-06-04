using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelHelper.Domain.Models.Identity;

namespace TravelHelper.DataAccess.Configurations
{
    public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.HasKey(rolePermission => new{rolePermission.PermissionId, rolePermission.RoleId});

            builder.HasData(new RolePermission
            {
                PermissionId = 7,
                RoleId = 2
            },
            new RolePermission
            {
                PermissionId = 1,
                RoleId = 1
            },
            new RolePermission
            {
                PermissionId = 2,
                RoleId = 1
            },
            new RolePermission
            {
                PermissionId = 3,
                RoleId = 1
            },
            new RolePermission
            {
                PermissionId = 4,
                RoleId = 1
            },
            new RolePermission
            {
                PermissionId = 5,
                RoleId = 1
            },
            new RolePermission
            {
                PermissionId = 6,
                RoleId = 1
            });
        }
    }
}
