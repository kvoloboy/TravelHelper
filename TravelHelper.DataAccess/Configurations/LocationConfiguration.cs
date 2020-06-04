using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelHelper.Domain.Models;

namespace TravelHelper.DataAccess.Configurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.Property(location => location.Name).IsRequired();

            builder.HasData(new Location
            {
                Id = 1,
                Name = "Dnepr"
            },
            new Location
            {
                Id=2,
                Name = "Tadgikistan"
            });
        }
    }
}
