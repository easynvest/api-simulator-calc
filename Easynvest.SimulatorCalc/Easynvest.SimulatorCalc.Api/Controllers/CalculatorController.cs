﻿using Easynvest.SimulatorCalc.Application.Commands;
using Easynvest.SimulatorCalc.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;


namespace Easynvest.SimulatorCalc.Api.Controllers
{
    [Route("[controller]")]
    public class CalculatorController : Controller
    {
        private readonly IMediator _mediator;

        public CalculatorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("simulate")]
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
