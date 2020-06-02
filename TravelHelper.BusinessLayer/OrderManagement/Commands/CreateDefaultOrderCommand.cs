using BusinessLayer.Utils;
using MediatR;

namespace BusinessLayer.OrderManagement.Commands
{
    public class CreateDefaultOrderCommand : IRequest<Result>
    {
        public int UserId { get; set; }
    }
}
