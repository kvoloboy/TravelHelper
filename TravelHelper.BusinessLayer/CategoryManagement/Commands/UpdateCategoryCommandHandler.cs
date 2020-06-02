using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Extensions.Repository;
using BusinessLayer.Helpers;
using MediatR;
using TravelHelper.Domain.Abstractions;
using TravelHelper.Domain.Models;

namespace BusinessLayer.CategoryManagement.Commands
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRepository<Category> _categoryRepository;

        public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _categoryRepository = _unitOfWork.GetRepository<Category>();
        }

        public async Task<Result> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var entityPresenceResult = await _categoryRepository.CheckExistence(request.Id);

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
