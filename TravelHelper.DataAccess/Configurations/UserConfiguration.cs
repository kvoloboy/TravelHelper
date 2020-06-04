using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Cryptography;
using System.Text;
using TravelHelper.Domain.Models.Identity;

namespace TravelHelper.DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(user => user.Email).IsRequired();
            builder.Property(user => user.PasswordHash).IsRequired();

            builder.HasData(new User
            {
                Id = 1,
                PasswordHash = CreateHash("qwerty"),
                Email = "artem.shporta@nure.ua",
            },
            new User
            {
                Id = 2,
                PasswordHash = CreateHash("ytrewq"),
                Email = "artem.shporta@gmail.com",
            });
        }

        public static byte[] CreateHash(string password)
        {
            var hash = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(password));

            return hash;
        }
    }
}
