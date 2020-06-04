using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TravelHelper.Domain.Models.Enums;
using TravelHelper.Web.Models.Agencies;
using TravelHelper.Web.Models.Categories;
using TravelHelper.Web.Models.Hotels;

namespace TravelHelper.Web.Models.Tours
{
    public class ModifyTourViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter name, please")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter description, please")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Enter season, please")]
        public TimeOfTheYear TimeOfTheYear { get; set; }
        [Required(ErrorMessage = "Enter price per day, please")]
        public double PricePerDay { get; set; }

        public int HotelId { get; set; }
        [Required(ErrorMessage = "Enter hotel, please")]
        public HotelDetailsViewModel Hotel { get; set; }

        public int AgencyId { get; set; }
        [Required(ErrorMessage = "Enter agency, please")]
        public IEnumerable<AgencyViewModel> Agencies { get; set; }

        public int CategoryId { get; set; }
        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}
