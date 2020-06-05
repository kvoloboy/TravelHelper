using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TravelHelper.Domain.Models;

namespace TravelHelper.DataAccess.Configurations
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.Property(hotel => hotel.Name).IsRequired();
            builder.Property(hotel => hotel.Description).IsRequired();
            builder.Property(hotel => hotel.Country).IsRequired();
            builder.Property(hotel => hotel.City).IsRequired();
            builder.Property(hotel => hotel.Address).IsRequired();

            builder.HasData(new Hotel
            {
                Id=1,
                Name = "BanderClub",
                Description = "Black lives matter, very good hotel",
                Country = "Ukraine",
                City = "Kramatorsk",
                Address = "Ubeleinaya 16",
                Longitude = 37.34,
                Latitude = 48.44
            }, new Hotel
            {
                Id=2,
                Name = "ShpartaArt",
                Description = "Hotel near kramatorsk sea, big country ukraine amazing life",
                Country = "America",
                City = "NewYork",
                Address = "BakerStreet211",
                Longitude = 40.42,
                Latitude = 74
            });

        }
    }
}