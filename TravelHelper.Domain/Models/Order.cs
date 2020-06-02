using System;
using System.Collections.Generic;
using TravelHelper.Domain.Models.Enums;
using TravelHelper.Domain.Models.Identity;

namespace TravelHelper.Domain.Models
{
    public class Order : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }

        public ICollection<OrderDetails> Details { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }
    }
}
