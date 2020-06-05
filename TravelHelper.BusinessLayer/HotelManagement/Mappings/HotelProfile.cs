using AutoMapper;
using BusinessLayer.HotelManagement.Commands;
using BusinessLayer.HotelManagement.DTO;
using TravelHelper.Domain.Models;

namespace BusinessLayer.HotelManagement.Mappings
{
    public class HotelProfile : Profile
    {
        public HotelProfile()
        {
            CreateMap<Hotel, HotelDto>();

            CreateMap<Image, ImageDto>();

            CreateMap<CreateHotelCommand, Hotel>();

            CreateMap<UpdateHotelCommand, Hotel>();
        }
    }
}
