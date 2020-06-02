using System;
using BusinessLayer.Utils;
using MediatR;

namespace BusinessLayer.OrderManagement.Commands
{
    public class AddItemToBasketCommand : IRequest<Result>
    {
        public int UserId { get; set; }
        public int TourId { get; set; }
        public int PersonsCount { get; set; }
        public int Duration { get; set; }
        public DateTime StartDate { get; set; }
    }
}
