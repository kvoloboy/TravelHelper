﻿using System.Collections.Generic;

namespace TravelHelper.Domain.Models
{
    public class Hotel : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public ICollection<Image> Images { get; set; }
    }
}
