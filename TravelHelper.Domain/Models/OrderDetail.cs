namespace TravelHelper.Domain.Models
{
    public class OrderDetail : BaseEntity
    {
        public short Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int TourId { get; set; }
        public Tour Tour { get; set; }
    }
}
