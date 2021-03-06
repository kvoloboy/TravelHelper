﻿using TravelHelper.Domain.Models.Identity;

namespace TravelHelper.Domain.Models
{
    public class Rating : BaseEntity
    {
        public int Value { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int TourId { get; set; }
        public Tour Tour { get; set; }
    }
}
