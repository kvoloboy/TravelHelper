using BusinessLayer.Utils;
using MediatR;

namespace BusinessLayer.OrderManagement.Commands
{
    public class ConfirmOrderCommand : IRequest<Result>
    {
        public int UserId { get; set; }
    }
}
