using BusinessLayer.Models.DTO;
using MediatR;

namespace BusinessLayer.CategoryManagement.Commands
{
    public class CreateCategoryCommand : IRequest<Result<CategoryDto>>
    {
        public string Name { get; set; }
    }
}
