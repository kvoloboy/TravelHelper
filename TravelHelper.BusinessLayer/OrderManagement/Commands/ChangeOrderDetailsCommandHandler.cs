using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Extensions.Repository;
using BusinessLayer.Helpers;
using MediatR;
using TravelHelper.Domain.Abstractions;
using TravelHelper.Domain.Models;

namespace BusinessLayer.OrderManagement.Commands
{
    public class ChangeOrderDetailsCommandHandler : IRequestHandler<ChangeOrderDetailsCommand, Result>
    {
        private readonly IRepository<OrderDetails> _orderDetailsRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ChangeOrderDetailsCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _orderDetailsRepository = _unitOfWork.GetRepository<OrderDetails>();
        }

        public async Task<Result> Handle(ChangeOrderDetailsCommand request, CancellationToken cancellationToken)
        {
            var entityPresenceResult = await _orderDetailsRepository.CheckExistence(request.Id);

            entityPresenceResult.OnSuccess(async () =>
            {
                var orderDetails = _mapper.Map<ChangeOrderDetailsCommand, OrderDetails>(request);

                await _orderDetailsRepository.UpdateAsync(orderDetails);
                await _unitOfWork.CommitAsync();
            });

            return entityPresenceResult;
        }
    }
}
