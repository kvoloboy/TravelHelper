using System.Collections.Generic;
using BusinessLayer.Models.DTO;
using MediatR;

namespace BusinessLayer.CategoryManagement.Queries
{
    public class GetCategoriesQuery : IRequest<List<CategoryDto>>
    {
    }
}
