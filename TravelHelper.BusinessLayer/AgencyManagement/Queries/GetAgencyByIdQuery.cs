using BusinessLayer.AgencyManagement.DTO;
using BusinessLayer.Shared;
using MediatR;

namespace BusinessLayer.AgencyManagement.Queries
{
    public class GetAgencyByIdQuery : IRequest<Result<AgencyDto>>
    {
        public int Id { get; set; }
    }
}
