using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TravelHelper.Domain.Abstractions;
using TravelHelper.Domain.Models;

namespace BusinessLayer.TourManagement.Queries
{
    public class GetTourByIdQueryHandler : IRequestHandler<GetTourByIdQuery, Tour>
    {
        private readonly IAsyncReadonlyRepository<Tour> _tourReadonlyRepository;

        public GetTourByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _tourReadonlyRepository = unitOfWork.GetReadonlyRepository<Tour>();
        }

        public Task<Tour> Handle(GetTourByIdQuery request, CancellationToken cancellationToken)
        {
            var tour = _tourReadonlyRepository.FindSingleAsync(t => t.Id == request.Id);

            return tour;
        }
    }
}