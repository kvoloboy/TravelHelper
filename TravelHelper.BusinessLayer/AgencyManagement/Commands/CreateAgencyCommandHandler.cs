using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Utils;
using BusinessLayer.Utils.DTO;
using MediatR;
using TravelHelper.Domain.Abstractions;
using TravelHelper.Domain.Models;

namespace BusinessLayer.AgencyManagement.Commands
{
    public class CreateAgencyCommandHandler : IRequestHandler<CreateAgencyCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRepository<Agency> _agencyRepository;

        public CreateAgencyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _agencyRepository = unitOfWork.GetRepository<Agency>();
        }

        public async Task<Result> Handle(CreateAgencyCommand request, CancellationToken cancellationToken)
        {
            var agency = _mapper.Map<CreateAgencyCommand, Agency>(request);
            await _agencyRepository.AddAsync(agency);
            await _unitOfWork.CommitAsync();

            return Result.Ok();
        }
    }
}
