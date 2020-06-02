using System.Threading;
using System.Threading.Tasks;
using BusinessLayer.Extensions;
using BusinessLayer.Extensions.Repository;
using BusinessLayer.Helpers;
using MediatR;
using TravelHelper.Domain.Abstractions;
using TravelHelper.Domain.Models;

namespace BusinessLayer.HotelManagement.Commands
{
    public class DeleteHotelCommandHandler : IRequestHandler<DeleteHotelCommand, Result>
    {
        private readonly IRepository<Hotel> _hotelRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteHotelCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _hotelRepository = unitOfWork.GetRepository<Hotel>();
        }

        public async Task<Result> Handle(DeleteHotelCommand request, CancellationToken cancellationToken)
        {
            var entityPresenceResult = await _hotelRepository.CheckExistence(request.Id);

            entityPresenceResult.OnSuccess(async () =>
            {
                await _hotelRepository.DeleteAsync(request.Id);
                await _unitOfWork.CommitAsync();
            });

            return entityPresenceResult;
        }
    }
}
