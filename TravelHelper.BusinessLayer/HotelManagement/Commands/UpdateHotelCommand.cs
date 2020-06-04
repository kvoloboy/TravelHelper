using System.Collections.Generic;
using BusinessLayer.HotelManagement.DTO;
using BusinessLayer.Shared;
using MediatR;

namespace BusinessLayer.HotelManagement.Commands
{
    public class UpdateHotelCommand : IRequest<Result>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public double PricePerDay { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public ICollection<ImageDto> Images { get; set; }
    }
}
