using System.Net.Http;
using System.Threading.Tasks;
using Easynvest.SimulatorCalc.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace Easynvest.SimulatorCalc.Api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IMediator _mediator;

        public ValuesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<string> Get(string name)
        {
            var response = await _mediator.Send(new Ping() { Name = name });
            return response;
        }

    }
}
