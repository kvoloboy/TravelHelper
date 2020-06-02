using BusinessLayer.Helpers;
using BusinessLayer.Models.DTO;
using MediatR;

namespace BusinessLayer.AgencyManagement.Queries
{
    public class GetAgencyByIdQuery : IRequest<Result<AgencyDto>>
    {
        public int Id { get; set; }
    }
}
