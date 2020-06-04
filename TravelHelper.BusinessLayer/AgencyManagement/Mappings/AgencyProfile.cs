using AutoMapper;
using BusinessLayer.AgencyManagement.Commands;
using BusinessLayer.AgencyManagement.DTO;
using TravelHelper.Domain.Models;

namespace BusinessLayer.AgencyManagement.Mappings
{
    public class AgencyProfile : Profile
    {
        public AgencyProfile()
        {
            CreateMap<Agency, AgencyDto>();

            CreateMap<CreateAgencyCommand, Agency>();

            CreateMap<UpdateAgencyCommand, Agency>();
        }
    }
}
