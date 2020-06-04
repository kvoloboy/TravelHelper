using System.Collections.Generic;
using BusinessLayer.CategoryManagement.DTO;
using MediatR;

namespace BusinessLayer.CategoryManagement.Queries
{
    public class GetCategoriesQuery : IRequest<List<CategoryDto>>
    {
    }
}
