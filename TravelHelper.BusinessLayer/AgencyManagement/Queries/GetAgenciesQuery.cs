using System.Collections.Generic;
using BusinessLayer.AgencyManagement.DTO;
using MediatR;
using TravelHelper.Domain.Models;

namespace BusinessLayer.AgencyManagement.Queries
{
    public class GetAgenciesQuery : IRequest<List<AgencyDto>>
    {

    }
}
