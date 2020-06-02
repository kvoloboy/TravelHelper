using System.Collections.Generic;
using BusinessLayer.Utils;
using BusinessLayer.Utils.DTO;
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
        public decimal PricePerDay { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public ICollection<ImageDto> Images { get; set; }
    }
}
