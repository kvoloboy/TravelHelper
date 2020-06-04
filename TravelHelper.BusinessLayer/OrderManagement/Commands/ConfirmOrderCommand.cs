using BusinessLayer.Shared;
using MediatR;

namespace BusinessLayer.OrderManagement.Commands
{
    public class ConfirmOrderCommand : IRequest<Result>
    {
        public int UserId { get; set; }
    }
}
