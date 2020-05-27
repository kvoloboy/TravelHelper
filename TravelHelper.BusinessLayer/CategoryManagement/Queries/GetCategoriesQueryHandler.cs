using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Models.DTO;
using MediatR;
using TravelHelper.Domain.Abstractions;
using TravelHelper.Domain.Models;

namespace BusinessLayer.CategoryManagement.Queries
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<CategoryDto>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncReadonlyRepository<Category> _categoryRepository;

        public GetCategoriesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _categoryRepository = unitOfWork.GetReadonlyRepository<Category>();
        }

        public async Task<List<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.FindAllAsync();
            var categoriesDto = _mapper.Map<List<Category>, List<CategoryDto>>(categories);

            return categoriesDto;
        }
    }
}
