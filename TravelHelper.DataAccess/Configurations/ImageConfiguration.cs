using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelHelper.Domain.Models;

namespace TravelHelper.DataAccess.Configurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.Property(image => image.Path).IsRequired();

            builder.HasData(new Image
            {
                Id = 1,
                Path = "~/wwwroot/img/Home/bottomWithText.png"
            });
        }
    }
}
