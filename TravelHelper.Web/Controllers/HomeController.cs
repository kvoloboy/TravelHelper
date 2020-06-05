using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.TourManagement.DTO;
using BusinessLayer.TourManagement.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TravelHelper.Web.Models.Tours;

namespace TravelHelper.Web.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private const int HotToursLimit = 4;

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public HomeController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var query = new GetHotToursQuery
            {
                Limit = HotToursLimit
            };
            var hotTours = await _mediator.Send(query);
            var tourViewModels = _mapper.Map<IEnumerable<TourDto>, IEnumerable<TourCatalogItemViewModel>>(hotTours);

            return View(tourViewModels);
        }
    }
}
