using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.TourManagement.Commands;
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
        private readonly IViewModelFactory<ModifyTourViewModel> _modifyTourViewModelFactory;

        public TourController(
            IMediator mediator,
            IMapper mapper,
            IViewModelFactory<FilterSelectedOptionsViewModel, FilterViewModel> filterViewModelFactory,
            IViewModelFactory<ModifyTourViewModel> modifyTourViewModelFactory)
        {
            _mediator = mediator;
            _mapper = mapper;
            _filterViewModelFactory = filterViewModelFactory;
            _modifyTourViewModelFactory = modifyTourViewModelFactory;
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

        [HttpGet("create")]
        public async Task<IActionResult> CreateAsync()
        {
            var modifyTourViewModel = await _modifyTourViewModelFactory.CreateAsync(new ModifyTourViewModel());

            return View("Create", modifyTourViewModel);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(ModifyTourViewModel modifyTourViewModel)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = await _modifyTourViewModelFactory.CreateAsync(modifyTourViewModel);

                return View("Create", viewModel);
            }

            var command = _mapper.Map<ModifyTourViewModel, CreateTourCommand>(modifyTourViewModel);
            await _mediator.Send(command);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("update")]
        public async Task<IActionResult> UpdateAsync(int id)
        {
            var query = new GetTourByIdQuery
            {
                Id = id
            };

            var result = await _mediator.Send(query);

            if (result.Failure)
            {
                ModelState.AddModelError(string.Empty, result.Error);

                return BadRequest(ModelState);
            }

            var modifyTourViewModel = _mapper.Map<TourDto, ModifyTourViewModel>(result.Value);
            modifyTourViewModel = await _modifyTourViewModelFactory.CreateAsync(modifyTourViewModel);

            return View("Update", modifyTourViewModel);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateAsync(ModifyTourViewModel modifyTourViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", modifyTourViewModel);
            }

            var command = _mapper.Map<ModifyTourViewModel, UpdateTourCommand>(modifyTourViewModel);
            var result = await _mediator.Send(command);

            if (!result.Failure)
            {
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, result.Error);

            return View("Update", modifyTourViewModel);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (id == default)
            {
                return NotFound();
            }

            var deleteCommand = new DeleteTourCommand
            {
                Id = id
            };

            var result = await _mediator.Send(deleteCommand);

            if (result.Success)
            {
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, result.Error);

            return BadRequest(ModelState);
        }
    }
}
