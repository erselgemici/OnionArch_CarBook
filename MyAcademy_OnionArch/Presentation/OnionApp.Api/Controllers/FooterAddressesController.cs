using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnionApp.Application.Features.Commands.FooterAddressCommands;
using OnionApp.Application.Features.Queries.FooterAddressQueries;

namespace OnionApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterAddressesController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetFooterAddressQuery());
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetFooterAddressByIdQuery(id));
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFooterAddressCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateFooterAddressCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new RemoveFooterAddressCommand(id));
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }
    }
}
