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
        }
    }
}
