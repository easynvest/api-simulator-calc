using Easynvest.SimulatorCalc.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace Easynvest.SimulatorCalc.Api.Controllers
{
    [Route("api/[controller]")]
    public class CalculatorController : Controller
    {
        private readonly IMediator _mediator;

        public CalculatorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(SimulateInvestmentCommand command)
        {
            if (command == null)
            {
                return BadRequest();
            }

            var response = await _mediator.Send(command);
            if (response == null)
            {
                return NoContent();
            }
            return Ok(response);
        }

    }
}
