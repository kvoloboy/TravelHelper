using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TravelHelper.Domain.Abstractions;
using TravelHelper.Domain.Models;

namespace BusinessLayer.HotelManagement.Commands
{
    public class CreateHotelCommandHandler : IRequestHandler<CreateHotelCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRepository<Hotel> _hotelRepository;

        public CreateHotelCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _hotelRepository = _unitOfWork.GetRepository<Hotel>();
        }

        public async Task<Unit> Handle(CreateHotelCommand request, CancellationToken cancellationToken)
        {
            var hotel = _mapper.Map<CreateHotelCommand, Hotel>(request);

            await _hotelRepository.AddAsync(hotel);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
