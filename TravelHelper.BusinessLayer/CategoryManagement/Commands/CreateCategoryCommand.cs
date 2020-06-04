using BusinessLayer.CategoryManagement.DTO;
using BusinessLayer.Shared;
using MediatR;

namespace BusinessLayer.CategoryManagement.Commands
{
    public class CreateCategoryCommand : IRequest<Unit>
    {
        public string Name { get; set; }
    }
}
