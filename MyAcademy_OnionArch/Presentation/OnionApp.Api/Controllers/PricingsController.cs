using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionApp.Application.Features.Commands.PricingCommands;
using OnionApp.Application.Features.Queries.PricingQueries;

namespace OnionApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingsController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetPricingQuery());
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetPricingByIdQuery(id));
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePricingCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdatePricingCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new RemovePricingCommand(id));
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }
    }
}
