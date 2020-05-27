using BusinessLayer.Models.DTO;
using MediatR;
using TravelHelper.Domain.Models;

namespace BusinessLayer.AgencyManagement.Queries
{
    public class GetAgencyByIdQuery : IRequest<Result<AgencyDto>>
    {
        public int Id { get; set; }
    }
}
