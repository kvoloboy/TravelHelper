using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Utils.DTO;
using MediatR;
using TravelHelper.Domain.Abstractions;
using TravelHelper.Domain.Models;

namespace BusinessLayer.HotelManagement.Queries
{
    public class GetHotelsQueryHandler : IRequestHandler<GetHotelsQuery, List<HotelDto>>
    {
        private readonly IMapper _mapper;
        private readonly IReadonlyRepository<Hotel> _hotelRepository;

        public GetHotelsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _hotelRepository = unitOfWork.GetRepository<Hotel>();
        }

        public async Task<List<HotelDto>> Handle(GetHotelsQuery request, CancellationToken cancellationToken)
        {
            var hotels = await _hotelRepository.FindAllAsync();
            var hotelsDto = _mapper.Map<List<HotelDto>>(hotels);

            return hotelsDto;
        }
    }
}
