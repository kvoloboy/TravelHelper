using System;
using TravelHelper.Web.Models.Tours;

namespace TravelHelper.Web.Models.OrderDetails
{
    public class OrderDetailsViewModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public int PersonsCount { get; set; }
        public int Duration { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public TourDetailsViewModel Tour { get; set; }
    }
}
