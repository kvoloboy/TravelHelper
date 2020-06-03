using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.AgencyManagement.Commands;
using BusinessLayer.AgencyManagement.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TravelHelper.Web.Models.ViewModels.Agencies;

namespace TravelHelper.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AgencyController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AgencyController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAgenciesQuery();
            var agencyDtos = await _mediator.Send(query);

            var agencyViewModels = _mapper.Map<IEnumerable<AgencyViewModel>>(agencyDtos);

            return View(agencyViewModels);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View(new AgencyViewModel());
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(AgencyViewModel agencyViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(agencyViewModel);
            }

            var createAgencyCommand = _mapper.Map<AgencyViewModel, CreateAgencyCommand>(agencyViewModel);

            var result = await _mediator.Send(createAgencyCommand);

            if (result.Success)
            {
                return RedirectToAction(nameof(GetAll));
            }

            ModelState.AddModelError(string.Empty, result.Error);

            return View(agencyViewModel);
        }

        [HttpGet("update")]
        public async Task<IActionResult> Update(int id)
        {
            if (id == default)
            {
                return NotFound();
            }

            var getAgency = new GetAgencyByIdQuery
            {
                Id = id
            };

            var result = await _mediator.Send(getAgency);

            if (result.Failure)
            {
                ModelState.AddModelError(string.Empty, result.Error);

                return BadRequest(ModelState);
            }

            var agencyViewModel = _mapper.Map<AgencyViewModel>(result.Value);

            return View(agencyViewModel);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(AgencyViewModel agencyViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(agencyViewModel);
            }

            var createAgencyCommand = _mapper.Map<AgencyViewModel, UpdateAgencyCommand>(agencyViewModel);

            var result = await _mediator.Send(createAgencyCommand);

            if (result.Success)
            {
                return RedirectToAction(nameof(GetAll));
            }

            ModelState.AddModelError(string.Empty, result.Error);

            return View(agencyViewModel);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == default)
            {
                return NotFound();
            }

            var deleteCommand = new DeleteAgencyCommand
            {
                Id = id
            };

            var result = await _mediator.Send(deleteCommand);

            if (result.Success)
            {
                return RedirectToAction(nameof(GetAll));
            }

            ModelState.AddModelError(string.Empty, result.Error);

            return BadRequest(ModelState);
        }
    }
}
