using System.Threading;
using System.Threading.Tasks;
using BusinessLayer.Utils;
using BusinessLayer.Utils.Extensions;
using BusinessLayer.Utils.Extensions.Repository;
using MediatR;
using TravelHelper.Domain.Abstractions;
using TravelHelper.Domain.Models;
using TravelHelper.Domain.Models.Enums;
using TravelHelper.Domain.Models.Identity;

namespace BusinessLayer.OrderManagement.Commands
{
    public class CreateDefaultOrderCommandHandler : IRequestHandler<CreateDefaultOrderCommand, Result>
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateDefaultOrderCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _orderRepository = _unitOfWork.GetRepository<Order>();
            _userRepository = _unitOfWork.GetRepository<User>();
        }

        public async Task<Result> Handle(CreateDefaultOrderCommand request, CancellationToken cancellationToken)
        {
            var userPresenceResult = await _userRepository.CheckExistence(request.UserId);

            userPresenceResult.OnSuccess(async () =>
            {
                var order = new Order
                {
                    Status = OrderStatus.New,
                    UserId = request.UserId
                };

                await _orderRepository.AddAsync(order);
                await _unitOfWork.CommitAsync();
            });

            return userPresenceResult;
        }
    }
}
