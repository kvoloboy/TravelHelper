using MediatR;

namespace BusinessLayer.LocationsManagement.Commands
{
    public class CreateLocationCommand : IRequest<Unit>
    {
        public string Name { get; set; }
    }
}
