using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Helpers;
using BusinessLayer.Validators.Interfaces;
using MediatR;
using TravelHelper.Domain.Abstractions;
using TravelHelper.Domain.Models;

namespace BusinessLayer.CategoryManagement.Commands
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IValidator<int> _entityPresenceValidator;

        public UpdateCategoryCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IValidator<int> entityPresenceValidator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _entityPresenceValidator = entityPresenceValidator;
            _categoryRepository = _unitOfWork.GetRepository<Category>();
        }

        public async Task<Result> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var entityPresenceResult = await _entityPresenceValidator.Validate(request.Id);

            entityPresenceResult.OnSuccess(async () =>
            {
                var category = _mapper.Map<UpdateCategoryCommand, Category>(request);

                await _categoryRepository.UpdateAsync(category);
                await _unitOfWork.CommitAsync();
            });

            return Result.Ok();
        }
    }
}
