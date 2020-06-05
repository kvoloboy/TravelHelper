using TravelHelper.Domain.Models.Enums;
using TravelHelper.Web.Models.Agencies;
using TravelHelper.Web.Models.Categories;
using TravelHelper.Web.Models.Hotels;
using TravelHelper.Web.Models.Location;

namespace TravelHelper.Web.Models.Tours
{
    public class TourDetailsViewModel
    {
        public int Id { get; set; }
        public HotelDetailsViewModel Hotel { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TimeOfTheYear TimeOfTheYear { get; set; }
        public int Visits { get; set; }
        public double PricePerDay { get; set; }
        public double Rating { get; set; }
        public AgencyViewModel Agency { get; set; }
        public CategoryViewModel Category { get; set; }
        public LocationViewModel DestinationPoint { get; set; }
    }
}
