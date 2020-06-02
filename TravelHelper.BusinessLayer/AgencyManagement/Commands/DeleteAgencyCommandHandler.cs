using System.Threading;
using System.Threading.Tasks;
using BusinessLayer.Extensions;
using BusinessLayer.Extensions.Repository;
using BusinessLayer.Helpers;
using MediatR;
using TravelHelper.Domain.Abstractions;
using TravelHelper.Domain.Models;

namespace BusinessLayer.AgencyManagement.Commands
{
    public class DeleteAgencyCommandHandler : IRequestHandler<DeleteAgencyCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Agency> _agencyRepository;

        public DeleteAgencyCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _agencyRepository = unitOfWork.GetRepository<Agency>();
        }

        public async Task<Result> Handle(DeleteAgencyCommand request, CancellationToken cancellationToken)
        {
            var entityPresenceResult = await _agencyRepository.CheckExistence(request.Id);

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
