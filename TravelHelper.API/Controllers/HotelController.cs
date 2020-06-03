using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TravelHelper.API.Controllers
{
    public class HotelController : Controller
    {
        private readonly IMediator _mediator;

        public HotelController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
