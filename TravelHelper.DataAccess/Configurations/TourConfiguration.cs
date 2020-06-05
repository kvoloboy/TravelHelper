using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelHelper.Domain.Models;
using TravelHelper.Domain.Models.Enums;

namespace TravelHelper.DataAccess.Configurations
{
    public class TourConfiguration : IEntityTypeConfiguration<Tour>
    {
        public void Configure(EntityTypeBuilder<Tour> builder)
        {
            builder.Property(user => user.Name).IsRequired();
            builder.Property(user => user.Description).IsRequired();

            builder.HasData(new Tour
            {
                Id=1,
                Name = "HotLife",
                Description = "With out tarakaniysov i yje good",
                TimeOfTheYear = TimeOfTheYear.Winter,
                Visits = 1,
                PricePerDay = 10.32,
                DestinationPointId = 1,
                HotelId = 1,
                AgencyId = 1,
                CategoryId = 1
            }, new Tour
            {
                Id=2,
                Name = "ColdLife",
                Description = "With tarakanu, no s pullom",
                TimeOfTheYear = TimeOfTheYear.Summer,
                Visits = 2,
                PricePerDay = 7.42,
                DestinationPointId = 2,
                HotelId = 2,
                AgencyId = 2,
                CategoryId = 2
            }
            );
        }
    }
}

