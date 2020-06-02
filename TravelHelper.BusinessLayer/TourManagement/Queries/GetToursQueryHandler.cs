using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Models.DTO;
using MediatR;
using TravelHelper.Domain.Abstractions;
using TravelHelper.Domain.Models;

namespace BusinessLayer.TourManagement.Queries
{
    public class GetToursQueryHandler : IRequestHandler<GetToursQuery, List<TourDto>>
    {
        private readonly IMapper _mapper;
        private readonly IReadonlyRepository<Tour> _toursRepository;

        public GetToursQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _toursRepository = unitOfWork.GetReadonlyRepository<Tour>();
        }

        public async Task<List<TourDto>> Handle(GetToursQuery request, CancellationToken cancellationToken)
        {
            var tours = await _toursRepository.FindAllAsync();
            var toursDto = _mapper.Map<List<Tour>, List<TourDto>>(tours);

            return toursDto;
        }
    }
}
