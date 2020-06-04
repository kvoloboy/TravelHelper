using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.LocationsManagement.DTO;
using MediatR;
using TravelHelper.Domain.Abstractions;
using TravelHelper.Domain.Models;

namespace BusinessLayer.LocationsManagement.Queries
{
    public class GetLocationsQueryHandler : IRequestHandler<GetLocationsQuery, List<LocationDto>>
    {
        private readonly IMapper _mapper;
        private readonly IReadonlyRepository<Location> _locationRepository;

        public GetLocationsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _locationRepository = unitOfWork.GetRepository<Location>();
        }

        public async Task<List<LocationDto>> Handle(GetLocationsQuery request, CancellationToken cancellationToken)
        {
            var locations = await _locationRepository.FindAllAsync();
            var locationsDtos = _mapper.Map<List<Location>, List<LocationDto>>(locations);

            return locationsDtos;
        }
    }
}
