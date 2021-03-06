﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Shared;
using BusinessLayer.TourManagement.DTO;
using MediatR;
using TravelHelper.Domain.Abstractions;
using TravelHelper.Domain.Models;

namespace BusinessLayer.TourManagement.Queries
{
    public class GetTourByIdQueryHandler : IRequestHandler<GetTourByIdQuery, Result<TourDto>>
    {
        private readonly IMapper _mapper;
        private readonly IReadonlyRepository<Tour> _tourReadonlyRepository;

        public GetTourByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _tourReadonlyRepository = unitOfWork.GetReadonlyRepository<Tour>();
        }

        public async Task<Result<TourDto>> Handle(GetTourByIdQuery request, CancellationToken cancellationToken)
        {
            var tour = await _tourReadonlyRepository.FindSingleAsync(t => t.Id == request.Id);

            if (tour == null)
            {
                return Result.Fail<TourDto>($"Not found tour with id: {request.Id}");
            }

            var tourDto = _mapper.Map<Tour, TourDto>(tour);

            tourDto.Rating = GetTourRating(tour.Ratings);

            return Result.Ok(tourDto);
        }

        private static double GetTourRating(ICollection<Rating> ratings)
        {
            var votesCount = ratings.Count;
            var rating = (double) ratings.Sum(r => r.Value) / votesCount;

            return rating;
        }
    }
}
