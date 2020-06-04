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
        }
    }
}
