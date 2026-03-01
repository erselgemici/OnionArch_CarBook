using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnionApp.Application.Features.Commands.SocialMediaCommands;
using OnionApp.Application.Features.Queries.SocialMediaQueries;

namespace OnionApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetSocialMediaQuery());
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetSocialMediaByIdQuery(id));
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSocialMediaCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateSocialMediaCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new RemoveSocialMediaCommand(id));
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }
    }
}
