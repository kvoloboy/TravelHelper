using System;
using System.Collections.Generic;
using BusinessLayer.OrderManagement.DTO;
using TravelHelper.Domain.Models.Enums;

namespace BusinessLayer.Shared.DTO
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        public IEnumerable<OrderDetailsDto> OrderDetails { get; set; }
    }
}
