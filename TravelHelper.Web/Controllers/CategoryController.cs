using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.CategoryManagement.Commands;
using BusinessLayer.CategoryManagement.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TravelHelper.Web.Models.Categories;

namespace TravelHelper.Web.Controllers
{
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CategoryController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var query = new GetCategoriesQuery();
            var categoryDtos = await _mediator.Send(query);

            var categoryViewModels = _mapper.Map<IEnumerable<CategoryViewModel>>(categoryDtos);

            return View("Index", categoryViewModels);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View(new CategoryViewModel());
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(CategoryViewModel categoryViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", categoryViewModel);
            }

            var createCategoryCommand = _mapper.Map<CategoryViewModel, CreateCategoryCommand>(categoryViewModel);

            await _mediator.Send(createCategoryCommand);

            return RedirectToAction(nameof(GetAllAsync));
        }


        [HttpPost("delete")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (id == default)
            {
                return NotFound();
            }

            var deleteCommand = new DeleteCategoryCommand
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
