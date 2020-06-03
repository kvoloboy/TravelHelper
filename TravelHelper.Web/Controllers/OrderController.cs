using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TravelHelper.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OrderController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
    }
}
