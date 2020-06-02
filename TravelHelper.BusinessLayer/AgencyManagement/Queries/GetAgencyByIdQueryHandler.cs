using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Helpers;
using BusinessLayer.Models.DTO;
using MediatR;
using TravelHelper.Domain.Abstractions;
using TravelHelper.Domain.Models;

namespace BusinessLayer.AgencyManagement.Queries
{
    public class GetAgencyByIdQueryHandler : IRequestHandler<GetAgencyByIdQuery, Result<AgencyDto>>
    {
        private readonly IMapper _mapper;
        private readonly IReadonlyRepository<Agency> _agencyRepository;

        public GetAgencyByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _agencyRepository = unitOfWork.GetReadonlyRepository<Agency>();
        }

        public async Task<Result<AgencyDto>> Handle(GetAgencyByIdQuery request, CancellationToken cancellationToken)
        {
            var agency = await _agencyRepository.FindSingleAsync(a => a.Id == request.Id);

            if (agency == null)
            {
                return Result.Fail<AgencyDto>($"Not found agency with id {request.Id}");
            }

            var dto = _mapper.Map<Agency, AgencyDto>(agency);

            return Result.Ok(dto);
        }
    }
}
