using System.Linq;
using AutoMapper;
using BusinessLayer.AgencyManagement.Commands;
using BusinessLayer.AgencyManagement.DTO;
using BusinessLayer.CategoryManagement.Commands;
using BusinessLayer.CategoryManagement.DTO;
using BusinessLayer.HotelManagement.Commands;
using BusinessLayer.HotelManagement.DTO;
using BusinessLayer.LocationsManagement.DTO;
using BusinessLayer.OrderManagement.Commands;
using BusinessLayer.OrderManagement.DTO;
using BusinessLayer.TourManagement.Commands;
using BusinessLayer.TourManagement.DTO;
using BusinessLayer.TourManagement.Queries;
using BusinessLayer.UserManagement.Commands;
using BusinessLayer.UserManagement.DTO;
using BusinessLayer.UserManagement.Queries;
using TravelHelper.Web.Models.Account;
using TravelHelper.Web.Models.Agencies;
using TravelHelper.Web.Models.Categories;
using TravelHelper.Web.Models.Hotels;
using TravelHelper.Web.Models.Images;
using TravelHelper.Web.Models.Location;
using TravelHelper.Web.Models.OrderDetails;
using TravelHelper.Web.Models.Orders;
using TravelHelper.Web.Models.Tours;
using TravelHelper.Web.Models.Tours.Filters;

namespace TravelHelper.Web.Mappings
{
    public class WebProfile : Profile
    {
        public WebProfile()
        {
            CreateMap<FilterSelectedOptionsViewModel, GetToursQuery>();
            CreateMap<TourDto, TourCatalogItemViewModel>();
            CreateMap<ModifyTourViewModel, CreateTourCommand>();
            CreateMap<TourDto, ModifyTourViewModel>();
            CreateMap<ModifyTourViewModel, UpdateTourCommand>();
            CreateMap<AddToBasketViewModel, AddItemToBasketCommand>();
            CreateMap<HotelDto, HotelDetailsViewModel>();
            CreateMap<CreateHotelViewModel, CreateHotelCommand>();
            CreateMap<HotelDto, UpdateHotelViewModel>();
            CreateMap<CategoryDto, CategoryViewModel>();
            CreateMap<CategoryViewModel, CreateCategoryCommand>();
            CreateMap<AgencyDto, AgencyViewModel>();
            CreateMap<AgencyViewModel, CreateAgencyCommand>();
            CreateMap<AgencyViewModel, UpdateAgencyCommand>();
            CreateMap<RegisterViewModel, RegisterUserCommand>();
            CreateMap<LogInViewModel, CanUserSignInQuery>();
            CreateMap<ModifyTourViewModel, ModifyTourViewModel>();
            CreateMap<TourDto, TourCatalogItemViewModel>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Hotel.Images.FirstOrDefault()));
            CreateMap<ImageDto, ImageViewModel>();
        }
    }
}
