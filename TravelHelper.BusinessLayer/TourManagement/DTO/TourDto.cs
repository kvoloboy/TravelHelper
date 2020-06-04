using BusinessLayer.AgencyManagement.DTO;
using BusinessLayer.CategoryManagement.DTO;
using BusinessLayer.HotelManagement.DTO;
using TravelHelper.Domain.Models.Enums;

namespace BusinessLayer.TourManagement.DTO
{
    public class TourDto
    {
        public int Id { get; set; }
        public HotelDto Hotel { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TimeOfTheYear TimeOfTheYear { get; set; }
        public int Visits { get; set; }
        public double PricePerDay { get; set; }
        public double Rating { get; set; }

        public int AgencyId { get; set; }
        public AgencyDto Agency { get; set; }

        public int CategoryId { get; set; }
        public CategoryDto Category { get; set; }
    }
}
