using System.Collections.Generic;
using TravelHelper.Domain.Models.Enums;

namespace TravelHelper.Domain.Models
{
    public class Tour : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Hotel Hotel { get; set; }
        public TimeOfTheYear TimeOfTheYear { get; set; }
        public int Visits { get; set; }

        public ICollection<Rating> Ratings { get; set; }

        public int AgencyId { get; set; }
        public Agency Agency { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
