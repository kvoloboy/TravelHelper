using AutoMapper;
using BusinessLayer.LocationsManagement.Commands;
using BusinessLayer.LocationsManagement.DTO;
using TravelHelper.Domain.Models;

namespace BusinessLayer.LocationsManagement.Mappings
{
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            CreateMap<Location, LocationDto>();

            CreateMap<CreateLocationCommand, Location>();
        }
    }
}
