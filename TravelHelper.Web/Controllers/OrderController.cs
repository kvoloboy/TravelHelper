using System;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.OrderManagement.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TravelHelper.Identity.Extensions;
using TravelHelper.Web.Models.Orders;

namespace TravelHelper.Web.Controllers
{
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OrderController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("add-to-basket")]
        public async Task<IActionResult> AddToBasket(AddToBasketViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command = _mapper.Map<AddToBasketViewModel, AddItemToBasketCommand>(viewModel);
            command.UserId = User.GetId();

            var result = await _mediator.Send(command);

            if (result.Success)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, result.Error);
            return BadRequest(ModelState);
        }

        [HttpPost("confirm")]
        public IActionResult Confirm()
        {
            throw new NotImplementedException();
        }
    }
}
