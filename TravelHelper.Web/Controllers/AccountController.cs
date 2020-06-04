using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TravelHelper.Web.Models.Account;

namespace TravelHelper.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("register")]
        public IActionResult Register(RegisterViewModel model)
        {
            return View();
        }

        [HttpPost("register")]
        public IActionResult RegisterAsync()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpGet]
        public IActionResult LogInAsync()
        {
            throw new NotImplementedException();
        }
    }
}
