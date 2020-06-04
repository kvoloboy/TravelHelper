using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Shared;
using BusinessLayer.Shared.Extensions;
using BusinessLayer.Shared.Extensions.Repository;
using MediatR;
using TravelHelper.Domain.Abstractions;
using TravelHelper.Domain.Models;

namespace BusinessLayer.TourManagement.Commands
{
    public class UpdateTourCommandHandler : IRequestHandler<UpdateTourCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRepository<Tour> _tourRepository;

        public UpdateTourCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tourRepository = _unitOfWork.GetRepository<Tour>();
        }

        public async Task<Result> Handle(UpdateTourCommand request, CancellationToken cancellationToken)
        {
            var entityPresenceResult = await _tourRepository.CheckExistence(request.Id);

            entityPresenceResult.OnSuccess(async () =>
            {
                var tour = _mapper.Map<UpdateTourCommand, Tour>(request);

                await _tourRepository.UpdateAsync(tour);
                await _unitOfWork.CommitAsync();
            });

            return entityPresenceResult;
        }
    }
}
