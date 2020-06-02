using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BusinessLayer.Helpers;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TravelHelper.Domain.Abstractions;
using TravelHelper.Domain.Models;
using TravelHelper.Domain.Models.Enums;
using TravelHelper.Domain.Models.Identity;

namespace BusinessLayer.OrderManagement.Commands
{
    public class CreateDefaultOrderCommandHandler : IRequestHandler<CreateDefaultOrderCommand, Result>
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;

        public CreateDefaultOrderCommandHandler(IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _orderRepository = _unitOfWork.GetRepository<Order>();
        }

        public async Task<Result> Handle(CreateDefaultOrderCommand request, CancellationToken cancellationToken)
        {
            var isUserExist = _userManager.Users.Any(u => u.Id == request.UserId);

            if (!isUserExist)
            {
                return Result.Fail($"Not found user with id: {request.UserId}");
            }

            var order = new Order
            {
                Status = OrderStatus.New,
                UserId = request.UserId
            };

            await _orderRepository.AddAsync(order);
            await _unitOfWork.CommitAsync();

            return Result.Ok();
        }
    }
}
