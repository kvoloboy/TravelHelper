using System.Threading;
using System.Threading.Tasks;
using BusinessLayer.Extensions;
using BusinessLayer.Helpers;
using BusinessLayer.Validators.Interfaces;
using MediatR;
using TravelHelper.Domain.Abstractions;
using TravelHelper.Domain.Models;

namespace BusinessLayer.AgencyManagement.Commands
{
    public class DeleteAgencyCommandHandler : IRequestHandler<DeleteAgencyCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<int> _entityPresenceValidator;
        private readonly IAsyncRepository<Agency> _agencyRepository;

        public DeleteAgencyCommandHandler(IUnitOfWork unitOfWork, IValidator<int> entityPresenceValidator)
        {
            _unitOfWork = unitOfWork;
            _entityPresenceValidator = entityPresenceValidator;
            _agencyRepository = unitOfWork.GetRepository<Agency>();
        }

        public async Task<Result> Handle(DeleteAgencyCommand request, CancellationToken cancellationToken)
        {
            var entityPresenceResult = await _entityPresenceValidator.Validate(request.Id);

            entityPresenceResult
                .OnSuccess(async () =>
                {
                    await _agencyRepository.DeleteAsync(request.Id);
                    await _unitOfWork.CommitAsync();
                });

            return entityPresenceResult;
        }
    }
}
