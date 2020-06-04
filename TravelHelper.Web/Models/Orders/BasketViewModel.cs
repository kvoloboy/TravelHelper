using System.Collections.Generic;
using TravelHelper.Web.Models.OrderDetails;

namespace TravelHelper.Web.Models.Orders
{
    public class BasketViewModel
    {
        public int UserId { get; set; }
        public int OrderId { get; set; }
        public double Total { get; set; }
        public IEnumerable<OrderDetailsViewModel> OrderDetails { get; set; }
    }
}
