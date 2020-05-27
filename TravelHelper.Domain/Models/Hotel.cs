using System.Collections.Generic;

namespace TravelHelper.Domain.Models
{
    public class Hotel : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal PricePerDay { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public ICollection<Image> Images { get; set; }
    }
}
