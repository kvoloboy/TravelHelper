using System.Collections.Generic;
using BusinessLayer.HotelManagement.DTO;
using MediatR;

namespace BusinessLayer.HotelManagement.Commands
{
    public class CreateHotelCommand : IRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public IEnumerable<ImageDto> Images { get; set; }
    }
}
