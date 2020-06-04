using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Shared;
using BusinessLayer.Shared.Extensions;
using BusinessLayer.Shared.Extensions.Repository;
using MediatR;
using TravelHelper.Domain.Abstractions;
using TravelHelper.Domain.Models;
using TravelHelper.Domain.Models.Identity;

namespace BusinessLayer.RatingManagement.Commands
{
    public class RateTourCommandHandler : IRequestHandler<RateTourCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRepository<Rating> _ratingRepository;
        private readonly IReadonlyRepository<User> _userReadonlyRepository;
        private readonly IReadonlyRepository<Tour> _tourReadonlyRepository;

        public RateTourCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _ratingRepository = _unitOfWork.GetRepository<Rating>();
            _tourReadonlyRepository = _unitOfWork.GetReadonlyRepository<Tour>();
            _userReadonlyRepository = _unitOfWork.GetReadonlyRepository<User>();
        }

        public async Task<Result> Handle(RateTourCommand request, CancellationToken cancellationToken)
        {
            Result result;
            var existingRating = await _ratingRepository.FindSingleAsync(r =>
                r.UserId == request.UserId && r.TourId == request.TourId);

            if (existingRating != null)
            {
                result = await UpdateRating(existingRating, request.Value);
            }
            else
            {
                result = await CreateRating(request);
            }

            return result;
        }

        private async Task<Result> UpdateRating(Rating rating, int value)
        {
            rating.Value = value;
            await _ratingRepository.UpdateAsync(rating);
            await _unitOfWork.CommitAsync();

            return Result.Ok();
        }

        private async Task<Result> CreateRating(RateTourCommand request)
        {
            var userExistenceResult = await _userReadonlyRepository.CheckExistence(request.UserId);

            if (userExistenceResult.Failure)
            {
                return userExistenceResult;
            }

            var tourExistenceResult = await _tourReadonlyRepository.CheckExistence(request.TourId);

            if (tourExistenceResult.Failure)
            {
                return tourExistenceResult;
            }

            var rating = _mapper.Map<RateTourCommand, Rating>(request);
            await _ratingRepository.AddAsync(rating);
            await _unitOfWork.CommitAsync();

            return Result.Ok();
        }
    }
}
