using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TravelHelper.API.Controllers
{
    public class UserController : Controller
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
