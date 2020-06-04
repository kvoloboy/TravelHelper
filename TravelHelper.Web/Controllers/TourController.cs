using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.TourManagement.DTO;
using BusinessLayer.TourManagement.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TravelHelper.Web.Factories.Interfaces;
using TravelHelper.Web.Models.Tours;
using TravelHelper.Web.Models.Tours.Filters;

namespace TravelHelper.Web.Controllers
{
    [Route("[controller]")]
    public class TourController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IViewModelFactory<FilterSelectedOptionsViewModel, FilterViewModel> _filterViewModelFactory;

        public TourController(
            IMediator mediator,
            IMapper mapper,
            IViewModelFactory<FilterSelectedOptionsViewModel, FilterViewModel> filterViewModelFactory)
        {
            _mediator = mediator;
            _mapper = mapper;
            _filterViewModelFactory = filterViewModelFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index(FilterSelectedOptionsViewModel selectedOptions)
        {
            var toursQuery = _mapper.Map<FilterSelectedOptionsViewModel, GetToursQuery>(selectedOptions);
            var tourDtos = await _mediator.Send(toursQuery);
            var tourViewModels = _mapper.Map<IEnumerable<TourDto>, IEnumerable<TourCatalogItemViewModel>>(tourDtos);
            var filterViewModel = await _filterViewModelFactory.CreateAsync(selectedOptions);

            var catalog = new TourCatalogViewModel
            {
                Items = tourViewModels,
                Filter = filterViewModel
            };

            return View(catalog);
        }
    }
}
