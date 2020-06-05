using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.OrderManagement.Commands;
using BusinessLayer.UserManagement.Commands;
using BusinessLayer.UserManagement.Queries;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using TravelHelper.Identity.Factories.Interfaces;
using TravelHelper.Web.Models.Account;

namespace TravelHelper.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IClaimsPrincipalFactory _principalFactory;
        private readonly IMapper _mapper;

        public AccountController(IMediator mediator, IClaimsPrincipalFactory principalFactory, IMapper mapper)
        {
            _mediator = mediator;
            _principalFactory = principalFactory;
            _mapper = mapper;
        }

        [HttpGet("log-in")]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost("log-in")]
        public async Task<IActionResult> LogInAsync(LogInViewModel logInViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(LogIn), logInViewModel);
            }

            var query = new CanUserSignInQuery
            {
                Email = logInViewModel.Email,
                Password = logInViewModel.Password
            };

            var result = await _mediator.Send(query);

            if (result.Failure)
            {
                ModelState.AddModelError(string.Empty, result.Error);

                return View(nameof(LogIn), logInViewModel);
            }

            await SignInUserAsync(result.Value);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Register", registerViewModel);
            }

            var registerCommand = _mapper.Map<RegisterViewModel, RegisterUserCommand>(registerViewModel);
            var creationResult = await _mediator.Send(registerCommand);

            if (creationResult.Failure)
            {
                ModelState.AddModelError(string.Empty, creationResult.Error);

                return View("Register", registerViewModel);
            }

            await SignInUserAsync(creationResult.Value);
            var createDefaultOrderCommand = new CreateDefaultOrderCommand
            {
                UserId = creationResult.Value
            };

            await _mediator.Send(createDefaultOrderCommand);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet("sign-out")]
        public async Task<IActionResult> SignOutAsync(string returnUrl)
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            if (!string.IsNullOrEmpty(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "Home");
        }

        private async Task SignInUserAsync(int userId)
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = await _principalFactory.CreateAsync(userId);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }
    }
}
