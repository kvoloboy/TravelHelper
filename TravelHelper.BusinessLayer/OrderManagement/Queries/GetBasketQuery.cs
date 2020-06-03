using BusinessLayer.OrderManagement.DTO;
using BusinessLayer.Shared;
using MediatR;

namespace BusinessLayer.OrderManagement.Queries
{
    public class GetBasketQuery : IRequest<Result<BasketDto>>
    {
        public int UserId { get; set; }
    }
}
