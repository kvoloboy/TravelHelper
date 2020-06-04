using BusinessLayer.Shared;
using MediatR;

namespace BusinessLayer.RatingManagement.Commands
{
    public class RateTourCommand : IRequest<Result>
    {
        public int UserId { get; set; }
        public int TourId { get; set; }
        public int Value { get; set; }
    }
}
