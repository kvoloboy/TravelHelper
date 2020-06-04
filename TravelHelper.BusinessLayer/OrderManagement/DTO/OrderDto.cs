using System;
using System.Collections.Generic;
using TravelHelper.Domain.Models.Enums;

namespace BusinessLayer.OrderManagement.DTO
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        public IEnumerable<OrderDetailsDto> OrderDetails { get; set; }
    }
}
