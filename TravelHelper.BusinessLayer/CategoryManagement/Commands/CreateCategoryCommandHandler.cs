using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Helpers;
using BusinessLayer.Models.DTO;
using MediatR;
using TravelHelper.Domain.Abstractions;
using TravelHelper.Domain.Models;

namespace BusinessLayer.CategoryManagement.Commands
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Result<CategoryDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _categoryRepository = _unitOfWork.GetRepository<Category>();
        }

        public async Task<Result<CategoryDto>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<CreateCategoryCommand, Category>(request);
            var id = await _categoryRepository.AddAsync(category);
            await _unitOfWork.CommitAsync();

            var dto = _mapper.Map<CreateCategoryCommand, CategoryDto>(request);
            dto.Id = id;

            return Result.Ok(dto);
        }
    }
}
