using System;

namespace TravelHelper.Domain.Models
{
    public class OrderDetails : BaseEntity
    {
        public short Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int PersonsCount { get; set; }
        public int Duration { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate => BeginDate.AddDays(-Duration);

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int TourId { get; set; }
        public Tour Tour { get; set; }
    }
}
