using System;

namespace TravelHelper.API.Models.ViewModels.OrderDetails
{
    public class ModifyOrderDetailsViewModel
    {
        public DateTime BeginDate { get; set; }
        public int PersonsCount { get; set; }
        public int Duration { get; set; }
    }
}
