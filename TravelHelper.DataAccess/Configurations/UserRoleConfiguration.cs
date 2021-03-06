﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelHelper.Domain.Models.Identity;

namespace TravelHelper.DataAccess.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(userRole => new {userRole.UserId, userRole.RoleId});

            builder.HasData(new UserRole
            {
                UserId = 1,
                RoleId = 1
            },
            new UserRole
            {
                UserId = 2,
                RoleId = 2
            });
        }
    }
}
