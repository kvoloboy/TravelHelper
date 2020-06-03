using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Shared;
using BusinessLayer.Shared.Extensions;
using BusinessLayer.Shared.Extensions.Repository;
using MediatR;
using TravelHelper.Domain.Abstractions;
using TravelHelper.Domain.Models;

namespace BusinessLayer.HotelManagement.Commands
{
    public class UpdateHotelCommandHandler : IRequestHandler<UpdateHotelCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRepository<Hotel> _hotelRepository;

        public UpdateHotelCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _hotelRepository = _unitOfWork.GetRepository<Hotel>();
        }

        public async Task<Result> Handle(UpdateHotelCommand request, CancellationToken cancellationToken)
        {
            var entityPresenceResult = await _hotelRepository.CheckExistence(request.Id);

            entityPresenceResult.OnSuccess(async () =>
            {
                var hotel = _mapper.Map<UpdateHotelCommand, Hotel>(request);

                await _hotelRepository.UpdateAsync(hotel);
                await _unitOfWork.CommitAsync();
            });

            return entityPresenceResult;
        }
    }
}
