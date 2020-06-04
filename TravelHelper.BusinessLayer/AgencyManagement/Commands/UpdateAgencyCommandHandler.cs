using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Shared;
using BusinessLayer.Shared.Extensions;
using BusinessLayer.Shared.Extensions.Repository;
using MediatR;
using TravelHelper.Domain.Abstractions;
using TravelHelper.Domain.Models;

namespace BusinessLayer.AgencyManagement.Commands
{
    public class UpdateAgencyCommandHandler : IRequestHandler<UpdateAgencyCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRepository<Agency> _agencyRepository;

        public UpdateAgencyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _agencyRepository = _unitOfWork.GetRepository<Agency>();
        }

        public async Task<Result> Handle(UpdateAgencyCommand request, CancellationToken cancellationToken)
        {
            var entityPresenceResult = await _agencyRepository.CheckExistence(request.Id);

            entityPresenceResult.OnSuccess(async () =>
            {
                var agency = _mapper.Map<UpdateAgencyCommand, Agency>(request);

                await _agencyRepository.UpdateAsync(agency);
                await _unitOfWork.CommitAsync();
            });

            return Result.Ok();
        }
    }
}
