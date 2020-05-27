using MediatR;
using TravelHelper.Domain.Models;

namespace BusinessLayer.TourManagement.Queries
{
    public class GetTourByIdQuery : IRequest<Tour>
    {
        public int Id { get; set; }
    }
}