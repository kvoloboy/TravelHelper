using System.Threading;
using System.Threading.Tasks;
using BusinessLayer.Shared;
using BusinessLayer.Shared.Extensions;
using BusinessLayer.Shared.Extensions.Repository;
using MediatR;
using TravelHelper.Domain.Abstractions;
using TravelHelper.Domain.Models;

namespace BusinessLayer.TourManagement.Commands
{
    public class DeleteTourCommandHandler : IRequestHandler<DeleteTourCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Tour> _tourRepository;

        public DeleteTourCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _tourRepository = _unitOfWork.GetRepository<Tour>();
        }

        public async Task<Result> Handle(DeleteTourCommand request, CancellationToken cancellationToken)
        {
            var entityPresenceResult = await _tourRepository.CheckExistence(request.Id);

            entityPresenceResult.OnSuccess(async () =>
            {
                await _tourRepository.DeleteAsync(request.Id);
                await _unitOfWork.CommitAsync();
            });

            return entityPresenceResult;
        }
    }
}
