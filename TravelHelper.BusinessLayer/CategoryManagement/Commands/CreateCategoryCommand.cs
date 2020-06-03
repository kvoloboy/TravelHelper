using BusinessLayer.CategoryManagement.DTO;
using BusinessLayer.Shared;
using MediatR;

namespace BusinessLayer.CategoryManagement.Commands
{
    public class CreateCategoryCommand : IRequest<Result<CategoryDto>>
    {
        public string Name { get; set; }
    }
}
