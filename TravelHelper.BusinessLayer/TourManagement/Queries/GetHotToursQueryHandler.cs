using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.TourManagement.DTO;
using MediatR;
using TravelHelper.Domain.Abstractions;
using TravelHelper.Domain.Models;

namespace BusinessLayer.TourManagement.Queries
{
    public class GetHotToursQueryHandler : IRequestHandler<GetHotToursQuery, List<TourDto>>
    {
        private readonly IReadonlyRepository<Tour> _tourReadonlyRepository;
        private readonly IMapper _mapper;

        public GetHotToursQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _tourReadonlyRepository = unitOfWork.GetReadonlyRepository<Tour>();
            _mapper = mapper;
        }

        public async Task<List<TourDto>> Handle(GetHotToursQuery request, CancellationToken cancellationToken)
        {
            var tours = await _tourReadonlyRepository.FindAllAsync(sort: tour => tour.Visits, take: request.Limit);
            var tourDtos = _mapper.Map<List<Tour>, List<TourDto>>(tours);

            return tourDtos;
        }
    }
}
