using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelHelper.Domain.Models.Identity;

namespace TravelHelper.DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(user => user.Email).IsRequired();
            builder.Property(user => user.PasswordHash).IsRequired();
        }
    }
}
