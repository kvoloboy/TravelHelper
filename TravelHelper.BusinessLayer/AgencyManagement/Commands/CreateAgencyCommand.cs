using BusinessLayer.Shared;
using MediatR;

namespace BusinessLayer.AgencyManagement.Commands
{
    public class CreateAgencyCommand : IRequest<Result>
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
    }
}
