using System.Collections.Generic;
using BusinessLayer.TourManagement.DTO;
using MediatR;

namespace BusinessLayer.TourManagement.Queries
{
    public class GetHotToursQuery : IRequest<List<TourDto>>
    {
        public int Limit { get; set; }
    }
}
