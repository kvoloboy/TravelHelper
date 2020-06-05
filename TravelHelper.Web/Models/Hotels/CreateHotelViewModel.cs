using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace TravelHelper.Web.Models.Hotels
{
    public class CreateHotelViewModel
    {
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

        [Required(ErrorMessage = "Enter image, please")]
        public IFormFileCollection Images { get; set; }
    }
}
