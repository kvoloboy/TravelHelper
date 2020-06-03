using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TravelHelper.API.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
