﻿using System.Collections.Generic;
using TravelHelper.API.Models.ViewModels.Images;

namespace TravelHelper.API.Models.ViewModels.Hotels
{
    public class HotelDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public IEnumerable<ImageViewModel> Images { get; set; }
    }
}
