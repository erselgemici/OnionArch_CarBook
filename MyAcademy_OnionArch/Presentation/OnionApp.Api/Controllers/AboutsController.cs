using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnionApp.Application.Base;
using OnionApp.Application.Features.Commands.AboutCommands;
using OnionApp.Application.Features.Queries.AboutQueries;
using OnionApp.Application.Features.Results.AboutResults;

namespace OnionApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<BaseResult<List<GetAboutQueryResult>>>> GetAll()
        {
            var result = await _mediator.Send(new GetAboutQuery());

            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResult<GetAboutByIdQueryResult>>> GetById(int id)
        {
            var result = await _mediator.Send(new GetAboutByIdQuery(id));

            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAboutCommand command)
        {
            var result = await _mediator.Send(command);

            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateAboutCommand command)
        {
            var result = await _mediator.Send(command);

            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new RemoveAboutCommand(id));

            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }
    }
}
