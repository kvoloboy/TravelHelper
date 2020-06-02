using System.Collections.Generic;
using BusinessLayer.Models.DTO;
using MediatR;

namespace BusinessLayer.HotelManagement.Queries
{
    public class GetHotelsQuery : IRequest<List<HotelDto>>
    {

    }
}
