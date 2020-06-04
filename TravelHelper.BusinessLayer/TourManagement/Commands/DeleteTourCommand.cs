using BusinessLayer.Shared;
using MediatR;

namespace BusinessLayer.TourManagement.Commands
{
    public class DeleteTourCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }
}
