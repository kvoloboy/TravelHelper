using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Helpers;
using BusinessLayer.Validators.Interfaces;
using MediatR;
using TravelHelper.Domain.Abstractions;
using TravelHelper.Domain.Models;

namespace BusinessLayer.AgencyManagement.Commands
{
    public class UpdateAgencyCommandHandler : IRequestHandler<UpdateAgencyCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Agency> _agencyRepository;
        private readonly IValidator<int> _entityPresenceValidator;

        public UpdateAgencyCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IValidator<int> entityPresenceValidator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _entityPresenceValidator = entityPresenceValidator;
            _agencyRepository = _unitOfWork.GetRepository<Agency>();
        }

        public async Task<Result> Handle(UpdateAgencyCommand request, CancellationToken cancellationToken)
        {
            var entityPresenceResult = await _entityPresenceValidator.Validate(request.Id);

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
