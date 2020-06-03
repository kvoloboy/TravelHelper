using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Shared;
using MediatR;
using TravelHelper.Domain.Abstractions;
using TravelHelper.Domain.Models;
using TravelHelper.Domain.Models.Enums;

namespace BusinessLayer.OrderManagement.Commands
{
    public class AddItemToBasketCommandHandler : IRequestHandler<AddItemToBasketCommand, Result>
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<OrderDetails> _orderDetailsRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddItemToBasketCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _orderRepository = _unitOfWork.GetRepository<Order>();
            _orderDetailsRepository = _unitOfWork.GetRepository<OrderDetails>();
        }

        public async Task<Result> Handle(AddItemToBasketCommand request, CancellationToken cancellationToken)
        {
            var order = _orderRepository.FindSingleAsync(o => o.Id == request.UserId && o.Status == OrderStatus.New);

            if (order == null)
            {
                return Result.Fail($"Not found new order for user with id: {request.UserId}");
            }

            var orderDetails = _mapper.Map<AddItemToBasketCommand, OrderDetails>(request);
            orderDetails.OrderId = order.Id;

            await _orderDetailsRepository.AddAsync(orderDetails);
            await _unitOfWork.CommitAsync();

            return Result.Ok();
        }
    }
}
