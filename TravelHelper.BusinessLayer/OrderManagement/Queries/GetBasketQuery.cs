using BusinessLayer.Utils;
using BusinessLayer.Utils.DTO;
using MediatR;

namespace BusinessLayer.OrderManagement.Queries
{
    public class GetBasketQuery : IRequest<Result<BasketDto>>
    {
        public int UserId { get; set; }
    }
}
