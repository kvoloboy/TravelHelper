using System.Collections.Generic;

namespace BusinessLayer.Models.DTO
{
    public class BasketDto
    {
        public int OrderId { get; set; }
        public double Total { get; set; }
        public IEnumerable<OrderDetailsDto> OrderDetails { get; set; }
    }
}
