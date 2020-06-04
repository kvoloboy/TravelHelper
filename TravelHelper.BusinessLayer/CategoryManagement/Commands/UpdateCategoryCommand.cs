using BusinessLayer.Shared;
using MediatR;

namespace BusinessLayer.CategoryManagement.Commands
{
    public class UpdateCategoryCommand : IRequest<Result>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
