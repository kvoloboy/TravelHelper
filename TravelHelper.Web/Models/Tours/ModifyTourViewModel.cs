using System.Collections.Generic;
using TravelHelper.Domain.Models.Enums;
using TravelHelper.Web.Models.Agencies;
using TravelHelper.Web.Models.Categories;
using TravelHelper.Web.Models.Hotels;

namespace TravelHelper.Web.Models.Tours
{
    public class ModifyTourViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TimeOfTheYear TimeOfTheYear { get; set; }
        public double PricePerDay { get; set; }

        public int HotelId { get; set; }
        public HotelDetailsViewModel Hotel { get; set; }

        public int AgencyId { get; set; }
        public IEnumerable<AgencyViewModel> Agencies { get; set; }

        public int CategoryId { get; set; }
        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}
