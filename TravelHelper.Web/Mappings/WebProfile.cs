using AutoMapper;

namespace TravelHelper.Web.Mappings
{
    public class WebProfile : Profile
    {
        public WebProfile()
        {
            CreateMap<AgencyDto, AgencyViewModel>();
            CreateMap<CategoryDto, CategoryViewModel>();
            CreateMap<HotelDto, HotelViewModel>();
            CreateMap<ImageDto, ImageViewModel>();
            CreateMap<LocationDto, LocationViewModel>();
            CreateMap<BasketDto, BasketViewModel>();
            CreateMap<OrderDetailsDto, OrderDetailsViewModel>();
            CreateMap<OrderDto, OrderViewModel>();
            CreateMap<TourDto, TourViewModel>();
            CreateMap<PasswordDto, PasswordViewModel>();
            CreateMap<RoleDto, RoleViewModel>();
            CreateMap<UserDto, UserViewModel>();
        }
    }
}
