using BusinessLayer.Utils;
using MediatR;

namespace BusinessLayer.CategoryManagement.Commands
{
    public class DeleteCategoryCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }
}
