using BusinessLayer.HotelManagement.DTO;
using BusinessLayer.Shared;
using MediatR;

namespace BusinessLayer.HotelManagement.Queries
{
    public class GetHotelByIdQuery : IRequest<Result<HotelDto>>
    {
        public int Id { get; set; }
    }
}
