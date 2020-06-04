using System;
using System.ComponentModel.DataAnnotations;
using TravelHelper.Web.Models.Tours;

namespace TravelHelper.Web.Models.OrderDetails
{
    public class OrderDetailsViewModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Enter price, please")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Enter discount, please")]
        public double Discount { get; set; }
        public int PersonsCount { get; set; }


        [Required(ErrorMessage = "Enter duration, please")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "Enter begin date, please")]
        public DateTime BeginDate { get; set; }

        [Required(ErrorMessage = "Enter end date, please")]
        public DateTime EndDate { get; set; }

        public TourDetailsViewModel Tour { get; set; }
    }
}
