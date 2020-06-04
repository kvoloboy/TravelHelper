using AutoMapper;
using BusinessLayer.OrderManagement.Commands;
using BusinessLayer.OrderManagement.DTO;
using TravelHelper.Domain.Models;

namespace BusinessLayer.OrderManagement.Mappings
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>();

            CreateMap<OrderDetails, OrderDetailsDto>();

            CreateMap<Order, BasketDto>()
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.Details));

            CreateMap<AddItemToBasketCommand, OrderDetails>();
        }
    }
}
