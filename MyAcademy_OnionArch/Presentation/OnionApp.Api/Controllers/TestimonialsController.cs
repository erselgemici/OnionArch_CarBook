using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionApp.Application.Features.Commands.TestimonialCommands;
using OnionApp.Application.Features.Queries.TestimonialQueries;

namespace OnionApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetTestimonialQuery());
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetTestimonialByIdQuery(id));
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTestimonialCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateTestimonialCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new RemoveTestimonialCommand(id));
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }
    }
}
