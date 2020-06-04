using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TravelHelper.Domain.Abstractions;
using TravelHelper.Domain.Models;

namespace BusinessLayer.LocationsManagement.Commands
{
    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRepository<Location> _locationRepository;

        public CreateLocationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _locationRepository = _unitOfWork.GetRepository<Location>();
        }

        public async Task<Unit> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            var location = _mapper.Map<CreateLocationCommand, Location>(request);

            await _locationRepository.AddAsync(location);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
