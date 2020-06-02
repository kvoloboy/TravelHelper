using System.Collections.Generic;
using BusinessLayer.Utils.DTO;
using MediatR;

namespace BusinessLayer.HotelManagement.Queries
{
    public class GetHotelsQuery : IRequest<List<HotelDto>>
    {

    }
}
