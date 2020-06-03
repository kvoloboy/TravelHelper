using System.Threading;
using System.Threading.Tasks;
using BusinessLayer.Shared;
using MediatR;
using TravelHelper.Domain.Abstractions;
using TravelHelper.Domain.Models;
using TravelHelper.Domain.Models.Enums;

namespace BusinessLayer.OrderManagement.Commands
{
    public class ConfirmOrderCommandHandler : IRequestHandler<ConfirmOrderCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Order> _orderRepository;

        public ConfirmOrderCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _orderRepository = _unitOfWork.GetRepository<Order>();
        }

        public async Task<Result> Handle(ConfirmOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.FindSingleAsync(o => o.UserId == request.UserId);

            if (order == null)
            {
                return Result.Fail($"Not found new order for user with id: {request.UserId}");
            }

            order.Status = OrderStatus.Payed;

            await _orderRepository.UpdateAsync(order);
            await _unitOfWork.CommitAsync();

            return Result.Ok();
        }
    }
}
