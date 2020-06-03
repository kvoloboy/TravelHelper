using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace TravelHelper.API.Models.ViewModels.Hotels
{
    public class UpdateHotelViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public IEnumerable<IFormFile> Images { get; set; }
    }
}
