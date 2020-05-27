using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TravelHelper.Domain.Abstractions;
using TravelHelper.Domain.Models;

namespace BusinessLayer.TourManagement.Queries
{
    public class GetToursQueryHandler : IRequestHandler<GetToursQuery, List<Tour>>
    {
        private readonly IAsyncReadonlyRepository<Tour> _toursRepository;

        public GetToursQueryHandler(IUnitOfWork unitOfWork)
        {
            _toursRepository = unitOfWork.GetReadonlyRepository<Tour>();
        }

        public Task<List<Tour>> Handle(GetToursQuery request, CancellationToken cancellationToken)
        {
            var tours = _toursRepository.FindAllAsync();

            return tours;
        }
    }
}
