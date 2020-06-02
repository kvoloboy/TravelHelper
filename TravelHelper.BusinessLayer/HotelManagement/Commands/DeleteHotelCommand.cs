using BusinessLayer.Utils;
using MediatR;

namespace BusinessLayer.HotelManagement.Commands
{
    public class DeleteHotelCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }
}
