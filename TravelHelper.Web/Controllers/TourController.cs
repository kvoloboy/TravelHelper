using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TravelHelper.Web.Controllers
{
    public class TourController : Controller
    {
        private readonly IMediator _mediator;

        public TourController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
