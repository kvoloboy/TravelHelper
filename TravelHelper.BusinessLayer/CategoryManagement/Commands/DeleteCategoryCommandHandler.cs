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
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IValidator<int> _entityPresenceValidator;

        public DeleteCategoryCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IValidator<int> entityPresenceValidator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _entityPresenceValidator = entityPresenceValidator;
            _categoryRepository = _unitOfWork.GetRepository<Category>();
        }

        public async Task<Result> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var entityPresenceResult = await _entityPresenceValidator.Validate(request.Id);

            entityPresenceResult.OnSuccess(async () =>
            {
                await _categoryRepository.DeleteAsync(request.Id);
                await _unitOfWork.CommitAsync();
            });

            return entityPresenceResult;
        }
    }
}
