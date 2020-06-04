using AutoMapper;
using BusinessLayer.CategoryManagement.Commands;
using BusinessLayer.CategoryManagement.DTO;
using TravelHelper.Domain.Models;

namespace BusinessLayer.CategoryManagement.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>();

            CreateMap<CreateCategoryCommand, Category>();

            CreateMap<UpdateCategoryCommand, Category>();
        }
    }
}
