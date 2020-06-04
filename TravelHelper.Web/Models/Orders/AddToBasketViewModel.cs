using System;
using System.ComponentModel.DataAnnotations;

namespace TravelHelper.Web.Models.Orders
{
    public class AddToBasketViewModel
    {
        [Required]
        public int TourId { get; set; }

        [Required(ErrorMessage = "Enter persons count, please")]
        public int PersonsCount { get; set; }

        [Required(ErrorMessage = "Enter tour duration, please")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "Select begin date, please")]
        public DateTime BeginDate { get; set; }
    }
}
