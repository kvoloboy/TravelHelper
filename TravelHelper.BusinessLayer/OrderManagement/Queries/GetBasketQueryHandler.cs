using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.OrderManagement.DTO;
using BusinessLayer.Shared;
using MediatR;
using TravelHelper.Domain.Abstractions;
using TravelHelper.Domain.Models;
using TravelHelper.Domain.Models.Enums;

namespace BusinessLayer.OrderManagement.Queries
{
    public class GetBasketQueryHandler : IRequestHandler<GetBasketQuery, Result<BasketDto>>
    {
        private readonly IReadonlyRepository<Order> _orderRepository;
        private readonly IMapper _mapper;

        public GetBasketQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _orderRepository = unitOfWork.GetRepository<Order>();
        }

        public async Task<Result<BasketDto>> Handle(GetBasketQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.FindSingleAsync(o =>
                o.UserId == request.UserId && o.Status == OrderStatus.New);

            if (order == null)
            {
                return Result.Fail<BasketDto>($"Not found new order for user with id: {request.UserId}");
            }

            var basket = _mapper.Map<Order, BasketDto>(order);
            basket.Total = ComputeOrderTotal(order.Details);

            return Result.Ok(basket);
        }

        private static double ComputeOrderTotal(IEnumerable<OrderDetails> orderDetails)
        {
            const int maxDiscountValue = 100;

            var sum = orderDetails?.Sum(od => (od.Price - od.Price * od.Discount / maxDiscountValue) * od.Quantity) ?? 0;

            return sum;
        }
    }
}
