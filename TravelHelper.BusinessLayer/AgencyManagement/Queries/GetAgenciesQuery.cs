using System.Collections.Generic;
using BusinessLayer.Models.DTO;
using MediatR;
using TravelHelper.Domain.Models;

namespace BusinessLayer.AgencyManagement.Queries
{
    public class GetAgenciesQuery : IRequest<List<AgencyDto>>
    {

    }
}
