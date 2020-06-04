using System.Collections.Generic;

namespace TravelHelper.Domain.Models
{
    public class Agency : BaseEntity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public ICollection<Tour> Tours { get; set; }
    }
}
