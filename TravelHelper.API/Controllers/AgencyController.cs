using System.Threading.Tasks;
using BusinessLayer.AgencyManagement.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TravelHelper.API.Controllers
{
    [ApiController]
    [Route("agency")]
    public class AgencyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AgencyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAgencies()
        {
            var query = new GetAgenciesQuery();
            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}
