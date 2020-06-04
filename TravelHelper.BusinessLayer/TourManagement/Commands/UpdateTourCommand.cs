using BusinessLayer.Shared;
using MediatR;
using TravelHelper.Domain.Models.Enums;

namespace BusinessLayer.TourManagement.Commands
{
    public class UpdateTourCommand : IRequest<Result>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TimeOfTheYear TimeOfTheYear { get; set; }
        public double PricePerDay { get; set; }
        public int AgencyId { get; set; }
        public int CategoryId { get; set; }
    }
}
