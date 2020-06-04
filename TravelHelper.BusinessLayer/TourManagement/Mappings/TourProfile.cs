using AutoMapper;
using BusinessLayer.TourManagement.Commands;
using BusinessLayer.TourManagement.DTO;
using TravelHelper.Domain.Models;

namespace BusinessLayer.TourManagement.Mappings
{
    public class TourProfile : Profile
    {
        public TourProfile()
        {
            CreateMap<Tour, TourDto>();

            CreateMap<CreateTourCommand, Tour>();

            CreateMap<UpdateTourCommand, Tour>();
        }
    }
}
