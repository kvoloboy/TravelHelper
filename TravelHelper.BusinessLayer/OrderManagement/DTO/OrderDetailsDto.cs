using System;
using BusinessLayer.TourManagement.DTO;

namespace BusinessLayer.OrderManagement.DTO
{
    public class OrderDetailsDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int PersonsCount { get; set; }
        public int Duration { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate => BeginDate.AddDays(-Duration);

        public TourDto Tour { get; set; }
    }
}
