using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.HotelManagement.DTO;
using BusinessLayer.Shared;
using MediatR;
using TravelHelper.Domain.Abstractions;
using TravelHelper.Domain.Models;

namespace BusinessLayer.HotelManagement.Queries
{
    public class GetHotelByIdQueryHandler : IRequestHandler<GetHotelByIdQuery, Result<HotelDto>>
    {
        private readonly IMapper _mapper;
        private readonly IReadonlyRepository<Hotel> _hotelReadonlyRepository;

        public GetHotelByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _hotelReadonlyRepository = unitOfWork.GetReadonlyRepository<Hotel>();
        }


        public async Task<Result<HotelDto>> Handle(GetHotelByIdQuery request, CancellationToken cancellationToken)
        {
            var hotel = await _hotelReadonlyRepository.FindSingleAsync(h => h.Id == request.Id);

            if (hotel == null)
            {
                return Result.Fail<HotelDto>($"Not found hotel with id: {request.Id}");
            }

            var hotelDto = _mapper.Map<Hotel, HotelDto>(hotel);

            return Result.Ok(hotelDto);
        }
    }
}
