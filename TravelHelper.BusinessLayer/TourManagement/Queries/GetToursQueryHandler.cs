using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Shared.Filter.Builders.Interfaces;
using BusinessLayer.Shared.Filter.Pipeline.Nodes;
using BusinessLayer.Shared.Sort.Builders.Interfaces;
using BusinessLayer.TourManagement.DTO;
using MediatR;
using TravelHelper.Domain.Abstractions;
using TravelHelper.Domain.Models;

namespace BusinessLayer.TourManagement.Queries
{
    public class GetToursQueryHandler : IRequestHandler<GetToursQuery, List<TourDto>>
    {
        private readonly IMapper _mapper;
        private readonly IPipelineBuilder<Expression<Func<Tour, bool>>> _pipelineBuilder;
        private readonly ISortOptionFactory _sortOptionFactory;
        private readonly IReadonlyRepository<Tour> _toursRepository;

        public GetToursQueryHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IPipelineBuilder<Expression<Func<Tour, bool>>> pipelineBuilder,
            ISortOptionFactory sortOptionFactory)
        {
            _mapper = mapper;
            _pipelineBuilder = pipelineBuilder;
            _sortOptionFactory = sortOptionFactory;
            _toursRepository = unitOfWork.GetReadonlyRepository<Tour>();
        }

        public async Task<List<TourDto>> Handle(GetToursQuery request, CancellationToken cancellationToken)
        {
            var pipeline = _pipelineBuilder
                .WithNode(new AgencyPipelineNode(request.Agencies))
                .WithNode(new CategoryPipelineNode(request.Categories))
                .WithNode(new NamePipelineNode(request.Name))
                .WithNode(new PriceRangePipelineNode(request.MinPrice, request.MaxPrice))
                .WithNode(new TimeOfTheYearPipelineNode(request.TimeOfTheYear))
                .WithNode(new SourcePointPipelineNode(request.SourcePointId))
                .WithNode(new DestinationPointPipelineNode(request.DestinationPointId))
                .Execute();

            var filter = pipeline.Execute();
            var sortOption = _sortOptionFactory.Create<Tour>(request.SortOption);

            var tours = await _toursRepository.FindAllAsync(
                filter,
                sortOption.Expression,
                sortOption.Direction,
                GetSkipValue(request.PageNumber, request.PageSize),
                request.PageSize);

            var toursDto = _mapper.Map<List<Tour>, List<TourDto>>(tours);

            return toursDto;
        }

        private static int GetSkipValue(int pageNumber, int pageSize)
        {
            return (pageNumber - 1) * pageSize;
        }
    }
}
