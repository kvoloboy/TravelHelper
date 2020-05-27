using BusinessLayer.Models.DTO;
using MediatR;

namespace BusinessLayer.AgencyManagement.Commands
{
    public class CreateAgencyCommand : IRequest<Result<AgencyDto>>
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
    }
}
