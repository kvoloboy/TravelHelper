using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelHelper.Domain.Models;

namespace TravelHelper.DataAccess.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(category => category.Name).IsRequired();
            builder.HasData(new Category
            {
                Id = 1,
                Name = "Lux"
            }, new Category
            {
                Id = 2,
                Name = "Econome"
            }, new Category
            {
                Id = 3,
                Name = "Medium"
            });
        }
    }
}
