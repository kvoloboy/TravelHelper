using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TravelHelper.Domain.Abstractions;
using TravelHelper.Domain.Models;

namespace BusinessLayer.TourManagement.Commands
{
    public class CreateTourCommandHandler : IRequestHandler<CreateTourCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRepository<Tour> _tourRepository;

        public CreateTourCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tourRepository = _unitOfWork.GetRepository<Tour>();
        }

        public async Task<Unit> Handle(CreateTourCommand request, CancellationToken cancellationToken)
        {
            var tour = _mapper.Map<CreateTourCommand, Tour>(request);

            await _tourRepository.AddAsync(tour);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
