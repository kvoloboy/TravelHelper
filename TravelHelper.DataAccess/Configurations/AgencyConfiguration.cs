using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelHelper.Domain.Models;

namespace TravelHelper.DataAccess.Configurations
{
    public class AgencyConfiguration : IEntityTypeConfiguration<Agency>
    {
        public void Configure(EntityTypeBuilder<Agency> builder)
        {
            builder.Property(agency => agency.Name).IsRequired();
            builder.Property(agency => agency.Phone).IsRequired();
            builder.Property(agency => agency.Description).IsRequired();

            builder.HasData(new Agency
            {
                Id = 1,
                Name = "Agency1",
                Phone = "+380956221121",
                Description ="duzche garno"
            },
            new Agency
            {
                Id=2,
                Name="Agency2",
                Phone= "+120956221126",
                Description="ne duzche garno"
            }) ;
        }
    }
}
