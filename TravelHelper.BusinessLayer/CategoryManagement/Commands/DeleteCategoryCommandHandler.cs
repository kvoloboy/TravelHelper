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
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRepository<Category> _categoryRepository;

        public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _categoryRepository = _unitOfWork.GetRepository<Category>();
        }

        public async Task<Result> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var entityPresenceResult = await _categoryRepository.CheckExistence(request.Id);

            entityPresenceResult.OnSuccess(async () =>
            {
                await _categoryRepository.DeleteAsync(request.Id);
                await _unitOfWork.CommitAsync();
            });

            return entityPresenceResult;
        }
    }
}
