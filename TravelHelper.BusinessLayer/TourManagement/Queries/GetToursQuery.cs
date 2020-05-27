using System.Collections.Generic;
using MediatR;
using TravelHelper.Domain.Models;

namespace BusinessLayer.TourManagement.Queries
{
    public class GetToursQuery : IRequest<List<Tour>>
    {

    }
}
