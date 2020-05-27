using BusinessLayer.Helpers;
using MediatR;

namespace BusinessLayer.AgencyManagement.Commands
{
    public class UpdateAgencyCommand : IRequest<Result>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
    }
}
