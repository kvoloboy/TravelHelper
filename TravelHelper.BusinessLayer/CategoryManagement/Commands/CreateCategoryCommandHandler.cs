using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.CategoryManagement.DTO;
using BusinessLayer.Shared;
using MediatR;
using TravelHelper.Domain.Abstractions;
using TravelHelper.Domain.Models;

namespace BusinessLayer.CategoryManagement.Commands
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _categoryRepository = _unitOfWork.GetRepository<Category>();
        }

        public async Task<Unit> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<CreateCategoryCommand, Category>(request);

            await _categoryRepository.AddAsync(category);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
