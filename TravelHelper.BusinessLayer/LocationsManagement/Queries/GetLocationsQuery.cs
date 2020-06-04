using System.Collections.Generic;
using BusinessLayer.LocationsManagement.DTO;
using MediatR;

namespace BusinessLayer.LocationsManagement.Queries
{
    public class GetLocationsQuery : IRequest<List<LocationDto>>
    {

    }
}
