using System;
using System.Collections.Generic;
using TravelHelper.Domain.Models.Enums;
using TravelHelper.Domain.Models.Identity;

namespace TravelHelper.Domain.Models
{
    public class Order : BaseEntity
    {
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }

        public ICollection<OrderDetails> Details { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }
    }
}
