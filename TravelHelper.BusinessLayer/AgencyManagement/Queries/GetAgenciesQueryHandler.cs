using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Models.DTO;
using MediatR;
using TravelHelper.Domain.Abstractions;
using TravelHelper.Domain.Models;

namespace BusinessLayer.AgencyManagement.Queries
{
    public class GetAgenciesQueryHandler : IRequestHandler<GetAgenciesQuery, List<AgencyDto>>
    {
        private readonly IMapper _mapper;
        private readonly IReadonlyRepository<Agency> _agencyRepository;

        public GetAgenciesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _agencyRepository = unitOfWork.GetReadonlyRepository<Agency>();
        }

        public async Task<List<AgencyDto>> Handle(GetAgenciesQuery request, CancellationToken cancellationToken)
        {
            var agencies = await _agencyRepository.FindAllAsync();

            var agenciesDto = _mapper.Map<List<Agency>, List<AgencyDto>>(agencies);

            return agenciesDto;
        }
    }
}
