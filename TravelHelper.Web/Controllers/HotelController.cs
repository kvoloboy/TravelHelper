using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.HotelManagement.Commands;
using BusinessLayer.HotelManagement.DTO;
using BusinessLayer.HotelManagement.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TravelHelper.Web.Models.Hotels;
using TravelHelper.Web.Services.Interfaces;

namespace TravelHelper.Web.Controllers
{
    [Route("[controller]")]
    public class HotelController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IFileUploadService _fileUploadService;

        public HotelController(IMediator mediator, IMapper mapper, IFileUploadService fileUploadService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _fileUploadService = fileUploadService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var hotelsQuery = new GetHotelsQuery();
            var hotelDtos = await _mediator.Send(hotelsQuery);

            var hotelViewModels = _mapper.Map<IEnumerable<HotelDto>, IEnumerable<HotelDetailsViewModel>>(hotelDtos);

            return View("Index", hotelViewModels);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(CreateHotelViewModel createHotelViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", createHotelViewModel);
            }

            var imagePaths = await _fileUploadService.UploadAsync(createHotelViewModel.Images.ToArray());

            var images = imagePaths.Select(path => new ImageDto
            {
                Path = path
            });

            var createHotelCommand = _mapper.Map<CreateHotelViewModel, CreateHotelCommand>(createHotelViewModel);
            createHotelCommand.Images = images;

            await _mediator.Send(createHotelCommand);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (id == default)
            {
                return NotFound();
            }

            var deleteCommand = new DeleteHotelCommand
            {
                Id = id
            };

            var result = await _mediator.Send(deleteCommand);

            if (result.Success)
            {
                return RedirectToAction(nameof(GetAllAsync));
            }

            ModelState.AddModelError(string.Empty, result.Error);

            return BadRequest(ModelState);
        }
    }
}
