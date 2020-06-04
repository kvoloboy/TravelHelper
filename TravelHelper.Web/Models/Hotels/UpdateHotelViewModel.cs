using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace TravelHelper.Web.Models.Hotels
{
    public class UpdateHotelViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter name, please")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter description, please")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Enter country, please")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Enter city, please")]
        public string City { get; set; }

        [Required(ErrorMessage = "Enter address, please")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Enter longitude, please")]
        public double Longitude { get; set; }

        [Required(ErrorMessage = "Enter latitude, please")]
        public double Latitude { get; set; }

        [Required(ErrorMessage = "Enter images, please")]
        public IEnumerable<IFormFile> Images { get; set; }
    }
}
