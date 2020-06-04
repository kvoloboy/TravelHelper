using System.Collections.Generic;

namespace TravelHelper.Domain.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Tour> Tours { get; set; }
    }
}
