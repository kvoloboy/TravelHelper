using BusinessLayer.Helpers;
using MediatR;

namespace BusinessLayer.OrderManagement.Commands
{
    public class CreateDefaultOrderCommand : IRequest<Result>
    {
        public int UserId { get; set; }
    }
}
