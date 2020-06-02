using System;
using BusinessLayer.Helpers;
using MediatR;

namespace BusinessLayer.OrderManagement.Commands
{
    public class ChangeOrderDetailsCommand : IRequest<Result>
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public int PersonsCount { get; set; }
    }
}
